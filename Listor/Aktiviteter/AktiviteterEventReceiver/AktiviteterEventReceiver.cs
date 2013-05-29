using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Diagnostics;
using System.Text;

namespace UPCOR.TillsynKommun.Aktiviteter.AktiviteterEventReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class AktiviteterEventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties) {
            base.ItemAdded(properties);

            try {
                Global.Debug = "butik";
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
                    Global.Debug = "klar";
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