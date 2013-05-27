using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.SharePoint.WebPartPages;
using System.Globalization;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Xml;
using System.Reflection;

namespace UPCOR.TillsynKommun.Features.ListsAndContentFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("93372ea4-2351-4f6b-bdc6-dca9fef21f72")]
    public class ListsAndContentFeatureEventReceiver : SPFeatureReceiver
    {
        private EventLog _log = null;
        private const string _source = "UPCOR.KundkortEventReceiver";
        private string _dbg;
        private string _wikiFullContent;
        private string _ver = "LACER v0.004 ";

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

        private Dictionary<string, Municipal> municipals = new Dictionary<string, Municipal>();
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            try {
                _dbg = "start";
                Assembly assembly = Assembly.GetExecutingAssembly();
                _ver += AssemblyName.GetAssemblyName(assembly.Location).Version.ToString() + " - ";

                SPWeb web = properties.Feature.Parent as SPWeb;
                if (web != null) {
                    if (web.Properties.ContainsKey("activatedOnce")) {
                        WriteLog("Redan aktiverad", EventLogEntryType.Information, 1000);
                        return;
                    }

                    web.Properties.Add("activatedOnce", "true");
                    web.Properties.Update();

                    _dbg = "set activatedOnce flag";

                    if (municipals.Count > 0) {
                        WriteLog("Kommuner existerar redan", EventLogEntryType.Information, 1000);
                    }
                    else {
                        municipals.Add("uppsala", new Municipal { AreaCode = "018", Name = "Uppsala", RegionLetter = "C" });
                        municipals.Add("borl�nge", new Municipal { AreaCode = "0243", Name = "Borl�nge", RegionLetter = "W" });
                    }

                    _dbg = "added municipals";

                    SPList listAgare = web.Lists.TryGetList("�gare");
                    _dbg = "�gare";
                    SPList listKontakter = web.Lists.TryGetList("Kontakter");
                    _dbg = "Kontakter";
                    SPList listAdresser = web.Lists.TryGetList("Adresser");
                    _dbg = "Adresser";
                    SPList listKundkort = web.Lists.TryGetList("Kundkort");
                    _dbg = "Kundkort";
                    SPList listSidor = web.Lists.TryGetList("Webbplatssidor");
                    _dbg = "Webbplatssidor";
                    SPList listAktiviteter = web.Lists.TryGetList("Aktiviteter");
                    _dbg = "Aktiviteter";
                    SPList listNyheter = web.Lists.TryGetList("Senaste nytt");
                    _dbg = "Senaste nytt";
                    //SPList listBlanketter = web.Lists.TryGetList("Blanketter");
                    SPList listGenvagar = web.Lists.TryGetList("Genv�gar");
                    _dbg = "Genv�gar";
                    //SPList listGruppkopplingar = web.Lists.TryGetList("Gruppkopplingar"); ??
                    

                    if (listSidor != null) {
                        #region startsida
                        string compoundUrl = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Start.aspx");

                        //* Define page payout
                        _wikiFullContent = FormatBasicWikiLayout();
                        _dbg = "Skapa startsida";
                        SPFile startsida = listSidor.RootFolder.Files.Add(compoundUrl, SPTemplateFileType.WikiPage);

                        // Header
                        _wikiFullContent = _wikiFullContent.Replace("[[HEADER]]", "<img alt=\"vinter\" src=\"" + web.ServerRelativeUrl + "/SiteAssets/profil_ettan_vinter_557x100.jpg\" style=\"margin: 5px;\"/><img alt=\"hj&auml;rta\" src=\"" + web.ServerRelativeUrl + "/SiteAssets/heart.gif\" style=\"margin: 5px;\"/>");

                        #region Nyheter
                        ListViewWebPart wpAnnouncements = new ListViewWebPart();
                        wpAnnouncements.ListName = listNyheter.ID.ToString("B").ToUpper();
                        //wpAnnouncements.ViewGuid = listNyheter.GetUncustomizedViewByBaseViewId(0).ID.ToString("B").ToUpper();
                        //wpAnnouncements.ViewGuid = listNyheter.DefaultView.ID.ToString("B").ToUpper();
                        wpAnnouncements.ViewGuid = string.Empty;
                        Guid wpAnnouncementsGuid = AddWebPartControlToPage(startsida, wpAnnouncements);
                        AddWebPartMarkUpToPage(wpAnnouncementsGuid, "[[COL1]]");
                        #endregion
                        #region Genv�gar
                        ListViewWebPart wpLinks = new ListViewWebPart();
                        wpLinks.ListName = listGenvagar.ID.ToString("B").ToUpper();
                        //wpLinks.ViewGuid = listGenvagar.GetUncustomizedViewByBaseViewId(0).ID.ToString("B").ToUpper();
                        //wpLinks.ViewGuid = listGenvagar.DefaultView.ID.ToString("B").ToUpper();
                        wpLinks.ViewGuid = string.Empty;
                        Guid wpLinksGuid = AddWebPartControlToPage(startsida, wpLinks);
                        AddWebPartMarkUpToPage(wpLinksGuid, "[[COL2]]");
                        #endregion

                        WriteLog("_wikiFullContent: " + _wikiFullContent, EventLogEntryType.Information, 1008);

                        startsida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        startsida.Item.UpdateOverwriteVersion();
                        _dbg = "Startsida skapad";
                        #endregion

                        #region l�gg till f�rs�ljningsst�lle
                        string compoundUrl2 = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "L�gg till f�rs�ljningsst�lle.aspx");

                        //* Define page payout
                        _wikiFullContent = FormatSimpleWikiLayout();
                        _dbg = "Skapa nybutiksida";
                        SPFile nybutiksida = listSidor.RootFolder.Files.Add(compoundUrl2, SPTemplateFileType.WikiPage);

                        // Header
                        _wikiFullContent = _wikiFullContent.Replace("[[COL1]]",
@"<h1>Sida f�r att l�gga till nya f�rs�ljningsst�llen</h1>
<h2>STEG 1 - L�gg till �gare</h2>
[[WP1]]
<h2>STEG 2 - L�gg till adressuppgifter</h2>
[[WP2]]
<h2>STEG 3 - L�gg till kontaktperson</h2>
[[WP3]]
<h2>STEG&#160;4 - L�gg till f�rs�ljningsst�llet</h2>
[[WP4]]");

                        _dbg = "wpAgare";
                        XsltListViewWebPart wpAgare = new XsltListViewWebPart();
                        wpAgare.ChromeType = PartChromeType.None;
                        wpAgare.ListName = listAgare.ID.ToString("B").ToUpper();
                        wpAgare.ViewGuid = listAgare.Views["Till�ggsvy"].ID.ToString("B").ToUpper();
                        wpAgare.Toolbar = "Standard";
                        Guid wpAgareGuid = AddWebPartControlToPage(nybutiksida, wpAgare);
                        AddWebPartMarkUpToPage(wpAgareGuid, "[[WP1]]");

                        _dbg = "wpAdresser";
                        XsltListViewWebPart wpAdresser = new XsltListViewWebPart();
                        wpAdresser.ChromeType = PartChromeType.None;
                        wpAdresser.ListName = listAdresser.ID.ToString("B").ToUpper();
                        wpAdresser.ViewGuid = listAdresser.Views["Till�ggsvy"].ID.ToString("B").ToUpper();
                        wpAdresser.Toolbar = "Standard";
                        Guid wpAdresserGuid = AddWebPartControlToPage(nybutiksida, wpAdresser);
                        AddWebPartMarkUpToPage(wpAdresserGuid, "[[WP2]]");

                        _dbg = "wpKontakter";
                        XsltListViewWebPart wpKontakter = new XsltListViewWebPart();
                        wpKontakter.ChromeType = PartChromeType.None;
                        wpKontakter.ListName = listKontakter.ID.ToString("B").ToUpper();
                        wpKontakter.ViewGuid = listKontakter.Views["Till�ggsvy"].ID.ToString("B").ToUpper();
                        wpKontakter.Toolbar = "Standard";
                        Guid wpKontakterGuid = AddWebPartControlToPage(nybutiksida, wpKontakter);
                        AddWebPartMarkUpToPage(wpKontakterGuid, "[[WP3]]");

                        _dbg = "wpKundkort";
                        XsltListViewWebPart wpKundkort = new XsltListViewWebPart();
                        wpKundkort.ChromeType = PartChromeType.None;
                        wpKundkort.ListName = listKundkort.ID.ToString("B").ToUpper();
                        wpKundkort.ViewGuid = listKundkort.Views["Till�ggsvy"].ID.ToString("B").ToUpper();
                        wpKundkort.Toolbar = "Standard";
                        Guid wpKundkortGuid = AddWebPartControlToPage(nybutiksida, wpKundkort);
                        AddWebPartMarkUpToPage(wpKundkortGuid, "[[WP4]]");

                        nybutiksida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        nybutiksida.Item.UpdateOverwriteVersion();
                        _dbg = "Nybutiksida skapad";

                        #endregion

                    }

                    _dbg = "�gare";
                    SPListItem item = listAgare.AddItem();
                    item["Title"] = "TEST�GARE AB";
                    item.Update();

                    _dbg = "kontakt";
                    item = listKontakter.AddItem();
                    item["Title"] = "Test Testsson";
                    item.Update();

                    _dbg = "adress";
                    item = listAdresser.AddItem();
                    item["Title"] = "Testgatan 13b";
                    item.Update();

                    _dbg = "nyhet";
                    item = listNyheter.AddItem();
                    item["Title"] = "V�r online plattform f�r tillsyn av tobak och folk�l h�ller p� att starta upp h�r";
                    item["Body"] = @"Hej!

Nu har f�rsta stegen till en online plattform f�r tillsyn av tobak och folk�l tagits. H�r kan du som f�rs�ljningsst�lle ladda hem blanketter och ta del av utbildningsmaterial.

" + web.Title + " kommun";
                    item.Update();

                    _dbg = "l�nkar";
                    item = listGenvagar.AddItem();
                    item["Title"] = "Blanketter";
                    item["URL"] = web.ServerRelativeUrl + "/Blanketter, Blanketter";
                    item.Update();
                    item = listGenvagar.AddItem();
                    item["Title"] = "Utbildningsmaterial"; 
                    item["URL"] = web.ServerRelativeUrl + "/Utbildningsmaterial, Utbildningsmaterial";
                    item.Update();


                    web.Properties.Add("lopnummer", "1000");
                    try {
                        Municipal m = municipals[web.Title.ToLower()];
                        web.Properties.Add("municipalAreaCode", m.AreaCode);
                        web.Properties.Add("municipalRegionLetter", m.RegionLetter);
                    }
                    catch { }
                    _dbg = "properties";
                    web.Properties.Update();
                }
                WriteLog("Feature Activated", EventLogEntryType.Information, 1001);
            }
            catch (Exception ex) {
                WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + _ver + _dbg, EventLogEntryType.Error, 2001);
            }
        } // feature activated

        private Guid AddWebPartControlToPage(SPFile wikiFile, System.Web.UI.WebControls.WebParts.WebPart wp)
        {
            SPLimitedWebPartManager limitedWebPartManager = wikiFile.GetLimitedWebPartManager(PersonalizationScope.Shared);
            Guid storageKeyGuid = Guid.NewGuid();
            string storageKeyId = StorageKeyToID(storageKeyGuid);
            wp.ID = storageKeyId;
            try {
                limitedWebPartManager.AddWebPart(wp, "wpz", 0);
            }
            catch (Exception ex) {
                WriteLog("limitedWebPartManager.AddWebPart\r\n\r\nMessage:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + _ver + _dbg, EventLogEntryType.Error, 2005);
            }
 
            return storageKeyGuid;
        }

        private void AddWebPartMarkUpToPage(Guid wpGuid, string replaceToken)
        {
            string wpDiv = string.Format(CultureInfo.InvariantCulture, "<div class='ms-rtestate-read ms-rte-wpbox' contentEditable='false'><div class='ms-rtestate-read {0}' id='div_{0}'></div><div style='display:none' id='vid_{0}'></div></div>", new object[] { wpGuid.ToString("D") });
            _wikiFullContent = _wikiFullContent.Replace(replaceToken, wpDiv);
        }

        // 2 col & header
        private string FormatBasicWikiLayout()
        {
            StringBuilder sb = new StringBuilder();
 
            sb.Append("<table id=\"layoutsTable\" style=\"width: 100%\">");
            sb.Append("<tbody>");
            sb.Append("<tr style=\"vertical-align: top\">");
            sb.Append("<td colspan=\"2\" style=\"width: 66.6%\">");
            sb.Append("<div class=\"ms-rte-layoutszone-outer\" style=\"width: 100%\">");
            //sb.Append("<div class=\"ms-rte-layoutszone-inner\" style=\"min-height: 60px; word-wrap: break-word\">");
            sb.Append("<div class=\"ms-rte-layoutszone-inner\" role=\"textbox\" aria-haspopup=\"true\" aria-autocomplete=\"both\" aria-multiline=\"true\">");
            sb.Append("[[HEADER]]");
            sb.Append("<p></p>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr style=\"vertical-align: top\">");
            sb.Append("<td style=\"width: 66.6%\">");
            sb.Append("<div class=\"ms-rte-layoutszone-outer\" style=\"width: 100%\">");
            //sb.Append("<div class=\"ms-rte-layoutszone-inner\" style=\"min-height: 60px; word-wrap: break-word\">");
            sb.Append("<div class=\"ms-rte-layoutszone-inner\" role=\"textbox\" aria-haspopup=\"true\" aria-autocomplete=\"both\" aria-multiline=\"true\">");
            sb.Append("[[COL1]]");
            sb.Append("<p>&#160;</p>");
            sb.Append("</div>&#160;");
            sb.Append("</div>");
            sb.Append("</td>");
            sb.Append("<td style=\"width: 33.3%\">");
            sb.Append("<div class=\"ms-rte-layoutszone-outer\" style=\"width: 100%\">");
            //sb.Append("<div class=\"ms-rte-layoutszone-inner\" style=\"min-height: 60px; word-wrap: break-word\">");
            sb.Append("<div class=\"ms-rte-layoutszone-inner\" role=\"textbox\" aria-haspopup=\"true\" aria-autocomplete=\"both\" aria-multiline=\"true\">");
            sb.Append("[[COL2]]");
            sb.Append("<p></p>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("<span id=\"layoutsData\" style=\"display: none\">true,false,2</span>");
 
            return sb.ToString();
        }

        // 1 col
        private string FormatSimpleWikiLayout() {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"ms-rte-layoutszone-outer\" style=\"width: 100%\">");
            sb.Append("<div class=\"ms-rte-layoutszone-inner\" style=\"min-height: 60px; word-wrap: break-word\">");
            sb.Append("[[COL1]]");
            sb.Append("<p>&#160;</p>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<span id=\"layoutsData\" style=\"display: none\">false,false,1</span>");

            return sb.ToString();
        }

        public static string StorageKeyToID(Guid storageKey)
        {
            if (!(Guid.Empty == storageKey))
            {
                return ("g_" + storageKey.ToString().Replace('-', '_'));
            }
            return string.Empty;
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
