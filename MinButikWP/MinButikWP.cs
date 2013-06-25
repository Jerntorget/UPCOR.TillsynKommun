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
                    SPListItemCollection items = list.GetItems("Title", "butikKundnummer", "butikAgare", "butikAdress", "butikKontakt1", "butikKontakt2", "butikKontakt3");
                    if (items == null) {
                        sb.Append("Kan inte hämta innehåll i Kundkort");
                    }
                    else {
                        //if (items.Count < 10) {
                        foreach (SPListItem item in items) {
                            SPListItem liAgare = null;
                            SPListItem liAdress = null;
                            SPListItem liKontakt1 = null;
                            SPListItem liKontakt2 = null;
                            SPListItem liKontakt3 = null;
                            string kontakt1name = null;
                            string kontakt2name = null;
                            string kontakt3name = null;


                            Global.Debug = "kundnummer";
                            string kundnummer = (string)item[new Guid("353eabaa-f0d3-40cc-acc3-4c6b23d3a64f")];
                            Global.Debug = "agare";
                            string agare = (string)item[new Guid("50076a6a-424f-4b32-9992-9ce9ab02b1c8")];
                            Global.Debug = "adress";
                            string adress = (string)item[new Guid("b5c833ef-df4e-44f3-9ed5-316ed61a59c9")];
                            Global.Debug = "kontakt1";
                            string kontakt1 = (string)item[new Guid("dc99b56d-9b8e-4dcb-b22e-9db4dd74abeb")];
                            Global.Debug = "kontakt2";
                            string kontakt2 = (string)item[new Guid("fb69a780-58bb-48b1-a070-57c7e7df3a24")];
                            Global.Debug = "kontakt3";
                            string kontakt3 = (string)item[new Guid("3c56ce65-d09e-4c7b-85f6-7046d1438fd8")];
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
                            if (!string.IsNullOrWhiteSpace(kontakt1)) {
                                string[] aKontakt1 = kontakt1.Split(new string[] { ";#" }, StringSplitOptions.None);
                                if (aKontakt1.Length == 2) {
                                    liKontakt1 = listKontakter.GetItemById(int.Parse(aKontakt1[0]));
                                    kontakt1name = aKontakt1[1];
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(kontakt2)) {
                                string[] aKontakt2 = kontakt2.Split(new string[] { ";#" }, StringSplitOptions.None);
                                if (aKontakt2.Length == 2) {
                                    liKontakt2 = listKontakter.GetItemById(int.Parse(aKontakt2[0]));
                                    kontakt2name = aKontakt2[1];
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(kontakt3)) {
                                string[] aKontakt3 = kontakt3.Split(new string[] { ";#" }, StringSplitOptions.None);
                                if (aKontakt3.Length == 2) {
                                    liKontakt3 = listKontakter.GetItemById(int.Parse(aKontakt3[0]));
                                    kontakt3name = aKontakt3[1];
                                }
                            }
                            //SPFieldLookupValueCollection kontakter = (SPFieldLookupValueCollection)item[new Guid("574795f5-e29a-45b3-a51b-0d2cb0352f63")];
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
                                string strAdress = (string)liAdress["Besöksadress"];
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
                            if (liKontakt2 != null)
                                sb.Append("er");
                            sb.Append(":<br />");
                            if (liKontakt1 != null) {
                                sb.Append(CreateLink(kontakt1name, listKontakter.ID, liKontakt1.ID));
                                sb.Append("<br />");
                            }
                            if (liKontakt2 != null) {
                                sb.Append(CreateLink(kontakt2name, listKontakter.ID, liKontakt2.ID));
                                sb.Append("<br />");
                            }
                            if (liKontakt3 != null) {
                                sb.Append(CreateLink(kontakt3name, listKontakter.ID, liKontakt3.ID));
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
