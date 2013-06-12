using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.UI;

namespace UPCOR.TillsynKommun
{
    public partial class AddRights : LayoutsPageBase
    {
        private StringBuilder _sbDebug = new StringBuilder();
        private SPList _list = null;
        private SPListItem _item = null;
        private SPGroup _group = null;
        private string _kundnummer = null;
        private SPListItem _itemAdresser = null;
        private SPListItem _itemAgare = null;
        private EventLog _log = null;
        private const string _source = "UPCOR.CreateGroupWhenStore";
        private const string _delim = ": ";
        private bool _error = false;

        public EventLog Log {
            get {
                if (_log == null) {
                    if (!EventLog.SourceExists(_source))
                        EventLog.CreateEventSource(_source, "Application");
                    _log = new EventLog();
                    _log.Source = _source;
                }
                return _log;
            }
        }

        private SPListItem Agare {
            get {
                if (_itemAgare == null) {
                    string agare = (string)_item[new Guid("50076a6a-424f-4b32-9992-9ce9ab02b1c8")];
                    agare = agare.Substring(0, agare.IndexOf(';'));
                    Guid agareGUID = new Guid(SPContext.Current.Web.Properties["listAgareGUID"]);
                    SPList listAgare = SPContext.Current.Web.Lists[agareGUID];
                    _itemAgare = listAgare.GetItemById(int.Parse(agare));
                }
                return _itemAgare;
            }
        }

         private SPListItem Adress {
            get {
                if (_itemAdresser == null) {
                    string adress = (string)_item[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
                    adress = adress.Substring(0, adress.IndexOf(';'));
                    Guid adresserGUID = new Guid(SPContext.Current.Web.Properties["listAdresserGUID"]);
                    SPList listAdresser = SPContext.Current.Web.Lists[adresserGUID];
                    _itemAdresser = listAdresser.GetItemById(int.Parse(adress));
                }
                return _itemAdresser;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            string strId = Page.Request["Id"];
            string strList = Page.Request["List"];
            string strSource = Page.Request["Source"];


            btnGive.Click += btnGive_Click;

            Guid listGuid = Guid.Empty;
            int itemId = 0;
            bool parseSuccess = false;
            try {
                listGuid = new Guid(strList);
                itemId = int.Parse(strId);
                parseSuccess = true;
            }
            catch {}

            if (parseSuccess) {
                _list = SPContext.Current.Web.Lists.GetList(listGuid, false);
                _item = _list.GetItemById(itemId);
                if (_item != null) {
                    _kundnummer = _item[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")] as string;
                }
             }
        }

        private void ListRights(SPListItem item, StringBuilder sb) {
            if (item.HasUniqueRoleAssignments) {
                foreach (SPRoleAssignment ra in item.RoleAssignments) {
                    string isCustomGroup = SPContext.Current.Web.Properties["group" + ra.Member.ID.ToString()];
                    if (!string.IsNullOrWhiteSpace(isCustomGroup)) {
                        bool hasAccess = false;
                        StringBuilder sb2 = new StringBuilder();
                        sb2.Append("[");
                        sb2.Append(ra.Member.Name);
                        sb2.Append("] ");
                        foreach (SPRoleDefinition def in ra.RoleDefinitionBindings) {
                            //if (def.Name == "Begränsad åtkomst")
                            //    continue;
                            if (def.Type == SPRoleType.Guest)
                                continue;
                            sb2.Append(def.Name);
                            sb2.Append(", ");
                            hasAccess = true;
                        }
                        sb2.Length -= 2;
                        sb2.Append("<br />");
                        if (hasAccess)
                            sb.Append(sb2);
                    }
                }
            }
            else {
                sb.Append("Rättigheter ärvs");
                sb.Append("<br />");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e) {
            if(_kundnummer != null) {
                if (_group == null) {
                    GetGroup(SPContext.Current.Web, _kundnummer);
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("Kund: ");
                sb.Append(_item.Title);
                sb.Append("<br />");
                sb.Append("Grupp: ");
                sb.Append(_group.Name);
                sb.Append("<br />");
                sb.Append("<br />");
                sb.Append("Rättigheter på kundkort:");
                sb.Append("<br />");

                ListRights(_item, sb);

                sb.Append("<br />");
                sb.Append("Rättigheter på adress:");
                sb.Append("<br />");

                ListRights(Adress, sb);

                sb.Append("<br />");
                sb.Append("Rättigheter på ägare:");
                sb.Append("<br />");

                ListRights(Agare, sb);

                pnlCurrentRights.Controls.Add(new LiteralControl(sb.ToString()));
            }
        }

        void btnGive_Click(object sender, EventArgs e) {
            if (_item != null) {
                string kundnummer = _item[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")] as string;
                if (!string.IsNullOrWhiteSpace(kundnummer)) {
                    GiveRights(kundnummer);
                }
            }
        }

        // Leta upp grupp med kundnummer, skapa om den inte finns
        private void GetGroup(SPWeb web, string title) {
            var groups = web.SiteGroups.GetCollection(new string[] { title });
            if (groups.Count == 0) {
                web.SiteGroups.Add(title, web.CurrentUser, null, string.Empty);
                _group = web.SiteGroups.GetByName(title);
            }
            else {
                _group = groups[0];
            }

            if (_group != null) {
                web.AllowUnsafeUpdates = true;
                web.Properties["group" + _group.ID.ToString()] = "true";
                web.Properties.Update();
                web.AllowUnsafeUpdates = false;
            }
        }

        private void GiveRights(string kundnummer) {
            try {
                SPSecurity.RunWithElevatedPrivileges(delegate() {
                    using (SPSite elevatedSite = new SPSite(SPContext.Current.Site.ID)) {
                        SPWeb elevatedWeb = elevatedSite.RootWeb;

                        GetGroup(elevatedWeb, kundnummer);

                        if (_group == null) {
                            Log.WriteEntry("Cannot find group", EventLogEntryType.Error, 1000);
                            _error = true;
                            return;
                        }

                        #region Leta upp behörigheten för att visa och redigera
                        _sbDebug.AppendLine("Leta upp behörigheten för att visa och redigera");
                        SPRoleDefinition roleRead = elevatedWeb.RoleDefinitions.GetByType(SPRoleType.Reader);
                        SPRoleDefinition roleEdit = elevatedWeb.RoleDefinitions.GetByType(SPRoleType.Editor);
                        SPRoleAssignment assignmentRead = new SPRoleAssignment(_group);
                        assignmentRead.RoleDefinitionBindings.Add(roleRead);
                        SPRoleAssignment assignmentEdit = new SPRoleAssignment(_group);
                        assignmentEdit.RoleDefinitionBindings.Add(roleEdit);
                        #endregion

                        _sbDebug.AppendLine("Ge rättigheter");

                        elevatedWeb.AllowUnsafeUpdates = true;

                        #region Ge läs-rättigheter för kundnummer-gruppen till det ändrade objektet
                        _sbDebug.AppendLine("-  Visa till det ändrade objektet");
                        _sbDebug.AppendLine("   bryter arv");
                        _item.BreakRoleInheritance(true);
                        _sbDebug.AppendLine("   sätter assignment");
                        _item.RoleAssignments.Add(assignmentRead);
                        _item.Update();
                        #endregion

                        elevatedWeb.AllowUnsafeUpdates = true;

                        #region Ge redigera-rättigheter för kundnummer-gruppen till adress
                        try {
                            _sbDebug.AppendLine("   bryter arv");
                            Adress.BreakRoleInheritance(true);
                            _sbDebug.AppendLine("   sätter assignment");
                            Adress.RoleAssignments.Add(assignmentEdit);
                            Adress.Update();

                        }
                        catch (Exception aex) {
                            _error = true;
                            _sbDebug.AppendLine("Adress Exception: " + aex.Message);
                            _sbDebug.AppendLine("Adress Stacktrace: " + aex.StackTrace);
                        }
                        #endregion

                        elevatedWeb.AllowUnsafeUpdates = true;

                        #region Ge redigera-rättigheter för kundnummer-gruppen till ägare
                        string agare = null;
                        try {
                            _sbDebug.AppendLine("   bryter arv");
                            Agare.BreakRoleInheritance(true);
                            _sbDebug.AppendLine("   sätter assignment");
                            Agare.RoleAssignments.Add(assignmentEdit);
                            Agare.Update();
                        }
                        catch (Exception aaex) {
                            _error = true;
                            _sbDebug.AppendLine("_x00c4_gare Exception: " + aaex.Message);
                            _sbDebug.AppendLine("_x00c4_gare Stacktrace: " + aaex.StackTrace);
                        }
                        #endregion

                        elevatedWeb.AllowUnsafeUpdates = false;
                    }
                });
            }
            catch (Exception ex) {
                _error = true;
                _sbDebug.AppendLine("outer Exception: " + ex.Message);
                _sbDebug.AppendLine("outer Stacktrace: " + ex.StackTrace);
                #region Logga exception
                StringBuilder sbErr = new StringBuilder();
                sbErr.AppendLine("Misslyckades att ge rättigheter!");
                sbErr.AppendLine();
                sbErr.AppendLine("Debug: ");
                sbErr.AppendLine(_sbDebug.ToString());
                sbErr.AppendLine();
                sbErr.AppendLine("Message: " + ex.Message);
                sbErr.AppendLine("Stacktrace: " + ex.StackTrace);
                Log.WriteEntry(sbErr.ToString(), EventLogEntryType.Error, 1102);
                #endregion
            }

            if (_error) {
                lblResult.Text = _sbDebug.ToString().Replace("\r", "<br />");
            }
            else {
                lblResult.Text = "Rättigheter givna";
            }
        }
    }
}
