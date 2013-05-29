using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Diagnostics;

namespace UPCOR.TillsynKommun.Kundkort.KundkortEventReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class KundkortEventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties) {
            base.ItemAdded(properties);

            try {
                string lopnummerStr = properties.Web.Properties["lopnummer"];
                int lopnummer;
                if (int.TryParse(lopnummerStr, out lopnummer)) {
                    string nyttLopnummer = (lopnummer + 1).ToString();
                    string code = properties.Web.Properties["municipalAreaCode"];
                    string letter = properties.Web.Properties["municipalRegionLetter"];
                    string kundnummer = letter + code + "-" + nyttLopnummer;
                    string strAdress = (string)properties.ListItem[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
                    if (!string.IsNullOrEmpty(strAdress)) {
                        SPFieldLookupValue adress = new SPFieldLookupValue(strAdress);
                        properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")] = adress.LookupValue;
                    }
                    else {
                        properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")] = kundnummer;
                    }
                    properties.ListItem[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")] = kundnummer;
                    
                    properties.ListItem.Update();
                    properties.Web.Properties["lopnummer"] = nyttLopnummer;
                    properties.Web.Properties.Update();
                }
                Global.WriteLog("Kundkort Success", EventLogEntryType.Information, 1000);
            }
            catch (Exception ex) {
                Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, EventLogEntryType.Error, 2000);
            }
        }


    }
}