using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;

namespace UPCOR.TillsynKommun
{
    [ToolboxItemAttribute(false)]
    public class MinButikWP : WebPart
    {
        //private StringBuilder sbDebug = new StringBuilder();

        [WebBrowsable(true), DefaultValue("Kundkort"), Category("Default"), Personalizable(PersonalizationScope.Shared), Description("Lista med kundkort")]
        public string Kundkort {
            get;
            set;
        }
        [WebBrowsable(true), DefaultValue("Ägare"), Category("Default"), Personalizable(PersonalizationScope.Shared), Description("Lista med ägare")]
        public string Agare {
            get;
            set;
        }
        [WebBrowsable(true), DefaultValue("Försäljningsställen"), Category("Default"), Personalizable(PersonalizationScope.Shared), Description("Lista med adresser")]
        public string Adresser {
            get;
            set;
        }
        [WebBrowsable(true), DefaultValue("Kontakter"), Category("Default"), Personalizable(PersonalizationScope.Shared), Description("Lista med kontakter")]
        public string Kontakter {
            get;
            set;
        }

        protected override void CreateChildControls() {
            StringBuilder sb = new StringBuilder();

            try {
                bool bRender = true;
                Global.Debug = "Kundkort";
                SPList list = SPContext.Current.Web.Lists.TryGetList(this.Kundkort);
                Global.Debug = "Agare";
                SPList listAgare = SPContext.Current.Web.Lists.TryGetList(this.Agare);
                Global.Debug = "Adresser";
                SPList listAdresser = SPContext.Current.Web.Lists.TryGetList(this.Adresser);
                Global.Debug = "Kontakter";
                SPList listKontakter = SPContext.Current.Web.Lists.TryGetList(this.Kontakter);
                
                if (list == null) {
                    sb.Append("Lista för Kundkort är inte inställt i webbdelens inställningar");
                    bRender = false;
                }
                else if (listAgare == null) {
                    sb.Append("Lista för Ägare är inte inställt i webbdelens inställningar");
                    bRender = false;
                }
                else if (listAdresser == null) {
                    sb.Append("Lista för Adresser är inte inställt i webbdelens inställningar");
                    bRender = false;
                }
                else if (listKontakter == null) {
                    sb.Append("Lista för Kontakter är inte inställt i webbdelens inställningar");
                    bRender = false;
                }
                
                if (bRender) {
                    Global.Debug = "bRender";
                    SPListItemCollection items = list.GetItems("Title", "butikKundnummer", "butikAgare", "butikAdress", "butikKontakt");
                    if (items == null) {
                        sb.Append("Kan inte hämta innehåll i Kundkort");
                    }
                    else {
                        //if (items.Count < 10) {
                        foreach (SPListItem item in items) {
                            SPListItem liAgare = null;
                            SPListItem liAdress = null;

                            Global.Debug = "kundnummer";
                            string kundnummer = (string)item[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")];
                            Global.Debug = "agare";
                            string agare = (string)item[new Guid("50076a6a-424f-4b32-9992-9ce9ab02b1c8")];
                            Global.Debug = "adress";
                            string adress = (string)item[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
                            Global.Debug = "0001";

                            if (!string.IsNullOrWhiteSpace(agare)) {
                                string[] aAgare = agare.Split(new string[] { ";#" }, StringSplitOptions.None);
                                if (aAgare.Length == 2)
                                    liAgare = listAgare.GetItemById(int.Parse(aAgare[0]));
                            }
                            if (!string.IsNullOrWhiteSpace(adress)) {
                                string[] aAdress = adress.Split(new string[] { ";#" }, StringSplitOptions.None);
                                if (aAdress.Length == 2)
                                    liAdress = listAdresser.GetItemById(int.Parse(aAdress[0]));
                            }
                            Global.Debug = "kontakter";
                            SPFieldLookupValueCollection kontakter = (SPFieldLookupValueCollection)item[new Guid("574795f5-e29a-45b3-a51b-0d2cb0352f63")];
                            Global.Debug = "0002";

                            sb.Append("<h2>");
                            sb.Append(item.Title);
                            sb.Append("</h2>");
                            sb.Append("<br />Kundnummer: ");
                            sb.Append("<h3>");
                            sb.Append(kundnummer);
                            sb.Append("</h3>");
                            if (liAgare != null) {
                                sb.Append("<br />Ägare:<br />");
                                Global.Debug = "0003";
                                sb.Append(CreateLink(liAgare.Title, listAgare.ID, liAgare.ID));
                                Global.Debug = "0004";
                                string orgnr = (string)liAgare["Organisationsnummer"];
                                if (!string.IsNullOrWhiteSpace(orgnr)) {
                                    sb.Append(" (" + orgnr + ")");
                                }
                            }
                            if (liAdress != null) {
                                sb.Append("<br /><br />Adress:<br />");
                                Global.Debug = "0005";
                                sb.Append(CreateLink(liAdress.Title, listAdresser.ID, liAdress.ID));
                                Global.Debug = "0006";
                                string strAdress = (string)liAdress["Adress"];
                                string strPostnr = (string)liAdress["Postnummer"];
                                string strOrt = (string)liAdress["Ort"];
                                if (!string.IsNullOrWhiteSpace(strAdress)) {
                                    sb.Append("<br />" + strAdress);
                                }
                                sb.Append("<br />");
                                if (!string.IsNullOrWhiteSpace(strPostnr)) {
                                    sb.Append(strPostnr + " ");
                                }
                                if (!string.IsNullOrWhiteSpace(strOrt)) {
                                    sb.Append(strOrt);
                                }
                            }
                            sb.Append("<br /><br />Kontakt");
                            if (kontakter.Count > 1)
                                sb.Append("er");
                            sb.Append(":<br />");
                            foreach (var kontakt in kontakter) {
                                sb.Append(CreateLink(kontakt.LookupValue, listKontakter.ID, kontakt.LookupId));
                                sb.Append("<br />");
                            }
                            sb.Append("<br /><hr /><br />");
                        } // foreach
                        //} // if (items.Count < 10)

                    } // else
                } // if (list != null)
            }
            catch (Exception ex) {
                sb.Append("Message:<br />" + ex.Message + "<br /><br />Stacktrace: <br />" + ex.StackTrace.Replace("\r", "<br />") + "<br /><br />Debug: <br />" + Global.Debug + "<br /><br />Version: <br />" + Global.Version);
            }
            Controls.Add(new LiteralControl(sb.ToString()));
        } // CreateChildControls

        private string CreateLink(string title, Guid listid, int listitemid) {
            return string.Format("<a onclick=\"OpenPopUpPage('{0}/_layouts/15/listform.aspx?PageType=4&ListId={{{1}}}&ID={2}&RootFolder=*', RefreshPage); return false;\" href=\"{0}/_layouts/15/listform.aspx?PageType=4&ListId={{{1}}}&ID={2}&RootFolder=*\">{3}</a>", SPContext.Current.Site.Url, listid, listitemid, title);
        }
    } // class
}
