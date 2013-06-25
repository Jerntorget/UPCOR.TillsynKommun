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
                object oButik = properties.ListItem[new Guid("a209aa87-f7e4-46cf-8865-37ea0002294b")];
                string strButik = oButik as string;

                if (strButik != null) {
                    SPFieldLookupValue butik = new SPFieldLookupValue(strButik);
                    Global.Debug = "ct";
                    string contenttype = properties.ListItem.ContentType.Name;
                    Global.Debug = "id";
                    int id = properties.ListItemId;
                    Global.Debug = "set";
                    properties.ListItem["Title"] = contenttype + " #" + id.ToString() + " - " + butik.LookupValue;
                    #region Sätt rättigheter
                    Global.Debug = "Sätt rättigheter";
                    Guid guidGruppkopplingar = new Guid(properties.Web.Properties["listGruppkopplingarGUID"]);
                    SPList listGruppkopplingar = properties.Web.Lists[guidGruppkopplingar];
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
                        SPGroup group = properties.Web.SiteGroups.GetByID((int)gruppid);
                        var roleRead = properties.Web.RoleDefinitions.GetByType(SPRoleType.Reader);
                        var roleEdit = properties.Web.RoleDefinitions.GetByType(SPRoleType.Editor);
                        var roleAdmin = properties.Web.RoleDefinitions.GetByType(SPRoleType.Administrator);
                        SPRoleAssignment assignmentRead = new SPRoleAssignment(group);
                        assignmentRead.RoleDefinitionBindings.Add(roleRead);
                        SPRoleAssignment assignmentEdit = new SPRoleAssignment(properties.Web.AssociatedMemberGroup);
                        assignmentEdit.RoleDefinitionBindings.Add(roleEdit);
                        SPRoleAssignment assignmentAdmin = new SPRoleAssignment(properties.Web.AssociatedOwnerGroup);
                        assignmentAdmin.RoleDefinitionBindings.Add(roleAdmin);

                        #region Ge visa-rättigheter till försäljningsstället, redigera till medlemmar, fullständiga till ägare
                        Global.Debug = "Ge visa-rättigheter till försäljningsstället, redigera till medlemmar, fullständiga till ägare";
                        properties.ListItem.ResetRoleInheritance();
                        properties.ListItem.BreakRoleInheritance(false);

                        properties.ListItem.RoleAssignments.Add(assignmentRead);
                        properties.ListItem.RoleAssignments.Add(assignmentEdit);
                        properties.ListItem.RoleAssignments.Add(assignmentAdmin);
                        #endregion
                    }
                    else {
                        Global.Debug = "Hittar flera grupper för kund";
                    }
                    #endregion
                    properties.ListItem.Update();
                    Global.Debug = "upd";
                    Global.WriteLog("ItemAdded", EventLogEntryType.Information, 1002);
                }
            }
            catch (Exception ex) {
                Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + Global.Debug, EventLogEntryType.Error, 2002);
            }
        }
    }
}