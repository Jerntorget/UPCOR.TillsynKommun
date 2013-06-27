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
                Global.URL = "Kundkort ItemAdded: " + properties.WebUrl;

                SPSecurity.RunWithElevatedPrivileges(() => {
                    using (SPSite site = new SPSite(properties.WebUrl)) {
                        using (SPWeb web = site.OpenWeb()) {
                            #region Öka på löpnummer
                            sbDebug.AppendLine("Öka på löpnummer");
                            int lopnummer;
                            string nyttLopnummer;

                            
                            #endregion

                            #region Sätt rubrik och kundnummer
                            sbDebug.AppendLine("Sätt rubrik och kundnummer");
                            string existingKundnummer  = (string)properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")];
                            string kundnummer = null;
                            if (string.IsNullOrWhiteSpace(existingKundnummer)) {

                                lock (oLopnummerLock) {
                                    string lopnummerStr = web.Properties["lopnummer"];
                                    if (int.TryParse(lopnummerStr, out lopnummer)) {
                                        nyttLopnummer = (lopnummer + 1).ToString();
                                        web.Properties["lopnummer"] = nyttLopnummer;
                                        web.Properties.Update();
                                    }
                                    else {
                                        Global.WriteLog("Kundkort löpnummer parse failed: " + lopnummerStr, EventLogEntryType.Information, 1000);
                                        return;
                                    }
                                }

                                string code = web.Properties["municipalAreaCode"];
                                string letter = web.Properties["municipalRegionLetter"];
                                string prefixFormula = web.Properties["prefixFormula"];
                                //string kundnummer = letter + code + "-" + nyttLopnummer;
                                kundnummer = prefixFormula.Replace("%B", letter).Replace("%R", code).Replace("%N", nyttLopnummer);

                                properties.ListItem[new Guid("d8c219b9-1908-4398-a2e2-75133114bf61")] = nyttLopnummer;
                            }
                            else {
                                kundnummer = existingKundnummer;
                            }
                            string strAdress = (string)properties.ListItem[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
                            if (!string.IsNullOrEmpty(strAdress)) {
                                SPFieldLookupValue adress = new SPFieldLookupValue(strAdress);
                                properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")] = adress.LookupValue + " (" + kundnummer + ")";
                            }
                            else {
                                properties.ListItem[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")] = kundnummer;
                            }
                            properties.ListItem[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")] = kundnummer;
                            
                            properties.ListItem.Update();
                            #endregion

                            #region Leta upp grupp med kundnummer, skapa om den inte finns
                            sbDebug.AppendLine("Leta upp grupp med kundnummer, skapa om den inte finns");
                            SPGroup group = null;
                            var groups = web.SiteGroups.GetCollection(new string[] { kundnummer });
                            if (groups.Count == 0) {
                                web.SiteGroups.Add(kundnummer, web.CurrentUser, null, string.Empty);
                                group = web.SiteGroups.GetByName(kundnummer);
                                web.Properties["group" + group.ID.ToString()] = "true";
                                web.Properties.Update();
                            }
                            else {
                                group = groups[0];
                            }
                            #endregion

                            #region Koppla grupp till försäljningsställe
                            sbDebug.AppendLine("Koppla grupp till försäljningsställe");
                            Guid guidGruppkopplingar = new Guid(web.Properties["listGruppkopplingarGUID"]);
                            SPList listGruppkopplingar = web.Lists[guidGruppkopplingar];
                            SPQuery q = new SPQuery();
                            q.ViewXml = string.Concat("<View><Query><Where><Eq>",
                            "<FieldRef Name='KundID' />",
                            "<Value Type='Number'>",
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

                            #region Ta bort rättigheten läs från besökare
                            string weburl = properties.WebUrl;
                            string itemurl = properties.ListItem.Url;
                            try {
                                SPSecurity.RunWithElevatedPrivileges(() => {
                                    using (SPSite elevatedSite = new SPSite(weburl)) {
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
                            catch (Exception ex) {
                                Global.WriteLog("Ta bort rättigheten läs från besökare - Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + sbDebug.ToString(), EventLogEntryType.Error, 2000);
                            }
                            #endregion
                        }
                    }
                });

            }
            catch (Exception ex) {
                Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + sbDebug.ToString(), EventLogEntryType.Error, 2000);
            }
        }
    }
}