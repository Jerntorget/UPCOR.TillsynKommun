using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Diagnostics;
using System.Text;

namespace UPCOR.TillsynKommun.Kundkort.KundkortEventReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class KundkortEventReceiver : SPItemEventReceiver
    {
        static object oLopnummerLock = new object();
        StringBuilder sbDebug = new StringBuilder();

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties) {
            base.ItemAdded(properties);

            try {
                #region Öka på löpnummer
                sbDebug.AppendLine("Öka på löpnummer");
                string lopnummerStr = properties.Web.Properties["lopnummer"];
                int lopnummer;
                string nyttLopnummer;

                lock (oLopnummerLock) {
                    if (int.TryParse(lopnummerStr, out lopnummer)) {
                        nyttLopnummer = (lopnummer + 1).ToString();
                        properties.Web.Properties["lopnummer"] = nyttLopnummer;
                        properties.Web.Properties.Update();
                    }
                    else {
                        Global.WriteLog("Kundkort löpnummer parse failed", EventLogEntryType.Information, 1000);
                        return;
                    }
                }
                #endregion

                #region Sätt rubrik och kundnummer
                sbDebug.AppendLine("Sätt rubrik och kundnummer");
                string code = properties.Web.Properties["municipalAreaCode"];
                string letter = properties.Web.Properties["municipalRegionLetter"];
                string prefixFormula = properties.Web.Properties["prefixFormula"];
                //string kundnummer = letter + code + "-" + nyttLopnummer;
                string kundnummer = prefixFormula.Replace("%B", letter).Replace("%R", code).Replace("%N", nyttLopnummer);
                string strAdress = (string)properties.ListItem[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
                if (!string.IsNullOrEmpty(strAdress)) {
                    SPFieldLookupValue adress = new SPFieldLookupValue(strAdress);
                    properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")] = adress.LookupValue + " (" + kundnummer + ")";
                }
                else {
                    properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")] = kundnummer;
                }
                properties.ListItem[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")] = kundnummer;
                properties.ListItem[new Guid("d8c219b9-1908-4398-a2e2-75133114bf61")] = nyttLopnummer;
                properties.ListItem.Update();
                #endregion

                #region Leta upp grupp med kundnummer, skapa om den inte finns
                sbDebug.AppendLine("Leta upp grupp med kundnummer, skapa om den inte finns");
                SPGroup group = null;
                var groups = properties.Web.SiteGroups.GetCollection(new string[] { kundnummer });
                if (groups.Count == 0) {
                    properties.Web.SiteGroups.Add(kundnummer, properties.Web.CurrentUser, null, string.Empty);
                    group = properties.Web.SiteGroups.GetByName(kundnummer);
                }
                else {
                    group = groups[0];
                }

                if (group != null) {
                    properties.Web.Properties["group" + group.ID.ToString()] = "true";
                    properties.Web.Properties.Update();
                }
                #endregion

                #region Koppla grupp till försäljningsställe
                sbDebug.AppendLine("Koppla grupp till försäljningsställe");
                Guid guidGruppkopplingar = new Guid(properties.Web.Properties["listGruppkopplingarGUID"]);
                SPList listGruppkopplingar = properties.Web.Lists[guidGruppkopplingar];
                SPQuery q = new SPQuery();
                q.ViewXml = string.Concat("<View><Query><Where><Eq>",
                "<FieldRef Name='KundID' />",
                "<Value Type='Number'>" ,
                    properties.ListItemId.ToString(),
                "</Value>",
                "</Eq></Where></Query></View>");
                SPListItemCollection items = listGruppkopplingar.GetItems(q);
                if (items.Count == 0) {
                    sbDebug.AppendLine("0 items i grupper för försäljningsställen");
                    SPListItem item = listGruppkopplingar.AddItem();
                    item["KundID"] = properties.ListItemId;
                    item["GruppID"] = group.ID;
                    item.Update();
                }
                else {
                    sbDebug.AppendLine("Minst 1 item i grupper för försäljningsställen");
                    foreach (SPListItem item in items) {
                        item["GruppID"] = group.ID;
                        item.Update();
                    }
                }
                #endregion

            }
            catch (Exception ex) {
                Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + sbDebug.ToString(), EventLogEntryType.Error, 2000);
            }
        }


    }
}