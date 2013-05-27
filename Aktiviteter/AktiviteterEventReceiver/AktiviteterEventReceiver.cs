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
        private EventLog _log = null;
        private const string _source = "UPCOR.KundkortEventReceiver";
        private string _dbg;
        private string _ver = "v0.005 ";

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

        private void WriteLog(string msg, EventLogEntryType t, int id) {
            Log.WriteEntry(DateTime.Now.ToString() + " " + _dbg + " " + _ver + msg, t, id);
        }

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties) {
            base.ItemAdded(properties);

            try {
                _dbg = "butik";
                object oButik = properties.ListItem[new Guid("a209aa87-f7e4-46cf-8865-37ea0002294b")];
                string strButik = oButik as string;

                if (strButik != null) {
                    SPFieldLookupValue butik = new SPFieldLookupValue(strButik);
                    _dbg = "ct";
                    string contenttype = properties.ListItem.ContentType.Name;
                    _dbg = "id";
                    int id = properties.ListItemId;
                    _dbg = "set";
                    properties.ListItem["Title"] = contenttype + " #" + id.ToString() + " - " + butik.LookupValue;
                    _dbg = "klar";
                    properties.ListItem.Update();
                    _dbg = "upd";
                    WriteLog("ItemAdded", EventLogEntryType.Information, 1002);
                }
            }
            catch (Exception ex) {
                WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + _dbg, EventLogEntryType.Error, 2002);
            }
        }


    }
}