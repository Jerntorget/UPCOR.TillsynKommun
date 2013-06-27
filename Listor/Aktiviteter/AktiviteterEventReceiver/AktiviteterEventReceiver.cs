using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Diagnostics;

namespace UPCOR.TillsynKommun.Listor.Aktiviteter
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class AktiviteterEventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties) {
            base.ItemAdded(properties);

            try {
                Global.Debug = "butik";
                Global.URL = "Aktiviteter ItemAdded: " + properties.WebUrl;
                SPSecurity.RunWithElevatedPrivileges(() => {
                    using (SPSite site = new SPSite(properties.WebUrl)) {
                        using (SPWeb web = site.OpenWeb()) {
                            string serverRelativeListItemUrl = SPUrlUtility.CombineUrl(web.ServerRelativeUrl, properties.ListItem.Url);
                            SPListItem aktivitet = web.GetListItem(serverRelativeListItemUrl);

                            object oButik = aktivitet[new Guid("a209aa87-f7e4-46cf-8865-37ea0002294b")];
                            string strButik = oButik as string;

                            if (strButik != null) {
                                SPFieldLookupValue butik = new SPFieldLookupValue(strButik);
                                Global.Debug = "ct";
                                string contenttype = aktivitet.ContentType.Name;
                                Global.Debug = "id";
                                int id = properties.ListItemId;
                                Global.Debug = "set";
                                aktivitet["Title"] = contenttype + " #" + id.ToString() + " - " + butik.LookupValue;
                                #region Sätt rättigheter
                                Global.Debug = "Sätt rättigheter";
                                Guid guidGruppkopplingar = new Guid(web.Properties["listGruppkopplingarGUID"]);
                                SPList listGruppkopplingar = web.Lists[guidGruppkopplingar];
                                SPQuery q = new SPQuery();
                                q.ViewXml = string.Concat("<View><Query><Where><Eq>",
                            "<FieldRef Name='KundID' />",
                            "<Value Type='Number'>",
                                butik.LookupId.ToString(),
                            "</Value>",
                            "</Eq></Where></Query></View>");
                                SPListItemCollection items = listGruppkopplingar.GetItems(q);
                                if (items.Count == 0) {
                                    Global.Debug = "Hittar inte grupp för kund";
                                }
                                else if (items.Count == 1) {
                                    SPListItem item = items[0];
                                    double gruppid = (double)item["GruppID"];
                                    SPGroup group = web.SiteGroups.GetByID((int)gruppid);
                                    var roleRead = web.RoleDefinitions.GetByType(SPRoleType.Reader);
                                    var roleEdit = web.RoleDefinitions.GetByType(SPRoleType.Editor);
                                    var roleAdmin = web.RoleDefinitions.GetByType(SPRoleType.Administrator);
                                    SPRoleAssignment assignmentRead = new SPRoleAssignment(group);
                                    assignmentRead.RoleDefinitionBindings.Add(roleRead);
                                    SPRoleAssignment assignmentEdit = new SPRoleAssignment(web.AssociatedMemberGroup);
                                    assignmentEdit.RoleDefinitionBindings.Add(roleEdit);
                                    SPRoleAssignment assignmentAdmin = new SPRoleAssignment(web.AssociatedOwnerGroup);
                                    assignmentAdmin.RoleDefinitionBindings.Add(roleAdmin);

                                    #region Ge visa-rättigheter till försäljningsstället, redigera till medlemmar, fullständiga till ägare
                                    Global.Debug = "Ge visa-rättigheter till försäljningsstället, redigera till medlemmar, fullständiga till ägare";
                                    aktivitet.ResetRoleInheritance();
                                    aktivitet.BreakRoleInheritance(false);

                                    aktivitet.RoleAssignments.Add(assignmentRead);
                                    aktivitet.RoleAssignments.Add(assignmentEdit);
                                    aktivitet.RoleAssignments.Add(assignmentAdmin);
                                    #endregion
                                }
                                else {
                                    Global.Debug = "Hittar flera grupper för kund";
                                }
                                #endregion
                                aktivitet.Update();
                                Global.Debug = "upd";
                                Global.WriteLog("ItemAdded", EventLogEntryType.Information, 1002);
                            }
                        }
                    }
                });
            }
            catch (Exception ex) {
                Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + Global.Debug, EventLogEntryType.Error, 2002);
            }
        }
    }
}