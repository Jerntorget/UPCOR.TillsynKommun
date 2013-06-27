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
        private const string _version = "<!--[[VER0.1]]-->";
        private StringBuilder _sbDebug = new StringBuilder();
        
        private string _kundnummer = null;
        //private string _gruppnamn = null;
        
        private EventLog _log = null;
        private const string _source = "UPCOR.CreateGroupWhenStore";
        private const string _delim = ": ";
        private bool _error = false;

        Guid _listGuid;
        int _itemId;

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

        private SPListItem GetItem(SPWeb web) {
            SPList kund = web.Lists.GetList(_listGuid, false);
            return kund.GetItemById(_itemId);
        }

        private SPListItem GetAgare(SPListItem item) {
            string agare = (string)item[new Guid("50076a6a-424f-4b32-9992-9ce9ab02b1c8")];
            if (!string.IsNullOrEmpty(agare)) {
                agare = agare.Substring(0, agare.IndexOf(';'));
                Guid agareGUID = new Guid(item.Web.Properties["listAgareGUID"]);
                SPList listAgare = item.Web.Lists[agareGUID];
                return listAgare.GetItemById(int.Parse(agare));
            }
            return null;
        }

        private SPListItem GetAdress(SPListItem item) {
            string adress = (string)item[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
            if (!string.IsNullOrEmpty(adress)) {
                adress = adress.Substring(0, adress.IndexOf(';'));
                Guid adresserGUID = new Guid(item.Web.Properties["listAdresserGUID"]);
                SPList listAdresser = item.Web.Lists[adresserGUID];
                return listAdresser.GetItemById(int.Parse(adress));
            }
            return null;
        }

        protected void Page_Load(object sender, EventArgs e) {
            Controls.Add(new LiteralControl(_version));

            string strId = Page.Request["Id"];
            string strList = Page.Request["List"];
            string strSource = Page.Request["Source"];

            btnGive.Click += btnGive_Click;

            _listGuid = Guid.Empty;
            _itemId = 0;

            bool parseSuccess = false;
            try {
                _listGuid = new Guid(strList);
                _itemId = int.Parse(strId);
                parseSuccess = true;
            }
            catch { }

            if (parseSuccess) {
                SPListItem item = GetItem(SPContext.Current.Web);
                if (item != null) {
                    _kundnummer = item[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")] as string;
                    //_gruppnamn
                }
            }
        }

        private void ListRights(SPListItem item, StringBuilder sb) {
            if (item.HasUniqueRoleAssignments) {
                item.Web.AllowUnsafeUpdates = true;
                foreach (SPRoleAssignment ra in item.RoleAssignments) {
                    string isCustomGroup = item.Web.Properties["group" + ra.Member.ID.ToString()];
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
                item.Web.AllowUnsafeUpdates = false;
            }
            else {
                sb.Append("Rättigheter ärvs");
                sb.Append("<br />");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();

            if (_kundnummer == null) {
                sb.Append("Kundnummer är inte satt");
            }
            else {

                SPSecurity.RunWithElevatedPrivileges(() => {
                    using (SPSite elevatedSite = new SPSite(SPContext.Current.Site.ID)) {
                        SPWeb web = elevatedSite.RootWeb;
                        SPGroup group = GetGroup(web, _kundnummer);
                        SPListItem item = GetItem(web);
                        SPListItem adress = GetAdress(item);
                        SPListItem agare = GetAgare(item);

                        if (group == null) {
                            sb.Append("Hittar ingen grupp med samma namn som kundnumret");
                        }
                        else {
                            sb.Append("Kund: ");
                            sb.Append(item.Title);
                            sb.Append("<br />");
                            sb.Append("Grupp: ");
                            sb.Append(group.Name);
                            sb.Append("<br />");
                            sb.Append("<br />");
                            sb.Append("Rättigheter på kundkort:");
                            sb.Append("<br />");

                            try {
                                ListRights(item, sb);
                            }
                            catch (Exception ex) {
                                sb.Append("Error: ");
                                sb.Append("<br />");
                                sb.Append("<br />");
                                sb.Append(ex.Message);
                                sb.Append("Stacktrace: ");
                                sb.Append("<br />");
                                sb.Append("<br />");
                                sb.Append(ex.StackTrace);
                            }

                            sb.Append("<br />");
                            if (adress == null) {
                                sb.Append("Ingen adress satt");
                                sb.Append("<br />");
                            }
                            else {
                                sb.Append("Rättigheter på adress:");
                                sb.Append("<br />");


                                try {
                                    ListRights(adress, sb);
                                }
                                catch (Exception ex) {
                                    sb.Append("Error: ");
                                    sb.Append("<br />");
                                    sb.Append("<br />");
                                    sb.Append(ex.Message);
                                    sb.Append("Stacktrace: ");
                                    sb.Append("<br />");
                                    sb.Append("<br />");
                                    sb.Append(ex.StackTrace);
                                    Log.WriteEntry("adress - " + sb.ToString().Replace("<br />", "\r\n"), EventLogEntryType.Error, 1102);
                                }

                            }

                            sb.Append("<br />");

                            if (agare == null) {
                                sb.Append("Ingen adress satt");
                                sb.Append("<br />");
                            }
                            else {
                                sb.Append("Rättigheter på ägare:");
                                sb.Append("<br />");


                                try {
                                    ListRights(agare, sb);
                                }
                                catch (Exception ex) {
                                    sb.Append("Error: ");
                                    sb.Append("<br />");
                                    sb.Append("<br />");
                                    sb.Append(ex.Message);
                                    sb.Append("Stacktrace: ");
                                    sb.Append("<br />");
                                    sb.Append("<br />");
                                    sb.Append(ex.StackTrace);
                                    Log.WriteEntry("agare - " + sb.ToString().Replace("<br />", "\r\n"), EventLogEntryType.Error, 1102);
                                }

                            }
                        }
                    }
                });
            }
            pnlCurrentRights.Controls.Add(new LiteralControl(sb.ToString()));
        }

        void btnGive_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(_kundnummer)) {
                GiveRights(_kundnummer);
            }
        }

        // Leta upp grupp med kundnummer, skapa om den inte finns
        private SPGroup GetGroup(SPWeb web, string title) {
            SPGroup group = null;
            var groups = web.SiteGroups.GetCollection(new string[] { title });
            if (groups.Count == 0) {
                web.AllowUnsafeUpdates = true;
                web.SiteGroups.Add(title, web.CurrentUser, null, string.Empty);
                group = web.SiteGroups.GetByName(title);
                web.Properties["group" + group.ID.ToString()] = "true";
                web.Properties.Update();
                web.AllowUnsafeUpdates = false;
            }
            else {
                group = groups[0];
            }
            return group;
        }

        private void GiveRights(string kundnummer) {
            try {
                SPSecurity.RunWithElevatedPrivileges(delegate() {
                    using (SPSite elevatedSite = new SPSite(SPContext.Current.Site.ID)) {
                        SPWeb elevatedWeb = elevatedSite.RootWeb;

                        SPGroup group = GetGroup(elevatedWeb, kundnummer);

                        if (group == null) {
                            Log.WriteEntry("Cannot find group", EventLogEntryType.Error, 1000);
                            _error = true;
                            return;
                        }

                        SPListItem item = GetItem(elevatedWeb);
                        SPListItem adress = GetAdress(item);
                        SPListItem agare = GetAgare(item);
                        
                        #region Leta upp behörigheten för att visa och redigera
                        _sbDebug.AppendLine("Leta upp behörigheten för att visa och redigera");
                        SPRoleDefinition roleRead = elevatedWeb.RoleDefinitions.GetByType(SPRoleType.Reader);
                        SPRoleDefinition roleEdit = elevatedWeb.RoleDefinitions.GetByType(SPRoleType.Editor);
                        SPRoleAssignment assignmentRead = new SPRoleAssignment(group);
                        assignmentRead.RoleDefinitionBindings.Add(roleRead);
                        SPRoleAssignment assignmentEdit = new SPRoleAssignment(group);
                        assignmentEdit.RoleDefinitionBindings.Add(roleEdit);
                        #endregion

                        _sbDebug.AppendLine("Ge rättigheter");

                        elevatedWeb.AllowUnsafeUpdates = true;

                        #region Ge läs-rättigheter för kundnummer-gruppen till det ändrade objektet
                        _sbDebug.AppendLine("-  Visa till det ändrade objektet");
                        _sbDebug.AppendLine("   bryter arv");
                        item.BreakRoleInheritance(true);
                        elevatedWeb.AllowUnsafeUpdates = true;
                        _sbDebug.AppendLine("   sätter assignment");
                        item.RoleAssignments.Add(assignmentRead);
                        item[new Guid("388ac965-dd63-4f98-ba2d-b42f88bdc959")] = true;
                        item.Update();
                        #endregion
                                               

                        #region Ge redigera-rättigheter för kundnummer-gruppen till adress
                        try {
                            if (adress != null) {
                                _sbDebug.AppendLine("   bryter arv");
                                adress.BreakRoleInheritance(true);
                                elevatedWeb.AllowUnsafeUpdates = true;
                                _sbDebug.AppendLine("   sätter assignment");
                                adress.RoleAssignments.Add(assignmentEdit);
                                adress.Update();
                            }
                        }
                        catch (Exception aex) {
                            _error = true;
                            _sbDebug.AppendLine("Adress Exception: " + aex.Message);
                            _sbDebug.AppendLine("Adress Stacktrace: " + aex.StackTrace);
                        }
                        #endregion

                        
                        #region Ge redigera-rättigheter för kundnummer-gruppen till ägare
                        try {
                            if (agare != null) {
                                _sbDebug.AppendLine("   bryter arv");
                                agare.BreakRoleInheritance(true);
                                elevatedWeb.AllowUnsafeUpdates = true;
                                _sbDebug.AppendLine("   sätter assignment");
                                agare.RoleAssignments.Add(assignmentEdit);
                                agare.Update();
                            }
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
