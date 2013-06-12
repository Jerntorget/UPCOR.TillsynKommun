using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPCOR.TillsynKommun
{
    static public class Global
    {
        static private EventLog _log = null;

        private const string _source = "UPCOR.KundkortEventReceiver";
        private const string _version = "v0.016 ";
        static private string _debug = "";

        static private EventLog Log {
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

        static public void WriteLog(string msg, EventLogEntryType t, int id) {
            string web = "";
            try {
                web = SPContext.Current.Web.Url;
            }
            catch { }
            Log.WriteEntry(web + " " + DateTime.Now.ToString() + " " + Global.Debug + " " + _version + msg, t, id);
        }

        static public string Debug {
            get {
                return _debug;
            }
            set {
                _debug = value;
            }
        }

        static public string Version {
            get {
                return _version;
            }
        }
    }
}
