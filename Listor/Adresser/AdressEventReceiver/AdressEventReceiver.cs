using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace UPCOR.TillsynKommun.Listor.Adresser.AdressEventReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class AdressEventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties) {
            base.ItemAdded(properties);

            SPSecurity.RunWithElevatedPrivileges(() => {
                using (SPSite elevatedSite = new SPSite(properties.WebUrl)) {
                    using (SPWeb elevatedWeb = elevatedSite.OpenWeb()) {
                        string serverRelativeListItemUrl = SPUrlUtility.CombineUrl(properties.Web.ServerRelativeUrl, properties.ListItem.Url);
                        SPListItem item = elevatedWeb.GetListItem(serverRelativeListItemUrl);
                        item.BreakRoleInheritance(true);
                        item.RoleAssignments.Remove(elevatedWeb.AssociatedVisitorGroup);
                        item.Update();
                    }
                }
            });
        }
    }
}