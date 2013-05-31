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
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Threading;

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
        private const string _tillsynName = "Tillsyn";
        private string _wikiFullContent;

        private Dictionary<string, Municipal> municipals = new Dictionary<string, Municipal>();
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties) {
            try {
                Global.Debug = "start";
                SPWeb web = properties.Feature.Parent as SPWeb;
                if (web == null) {
                }


                SPList listKundkort = web.Lists.TryGetList("Kundkort");
                Global.Debug = "Kundkort";
                SPList listAktiviteter = web.Lists.TryGetList("Aktiviteter");
                Global.Debug = "Aktiviteter";

                if (!web.Properties.ContainsKey("activatedOnce")) {
                    web.Properties.Add("activatedOnce", "true");
                    web.Properties.Update();

                    Global.Debug = "set activatedOnce flag";

                    if (municipals.Count > 0) {
                        Global.WriteLog("Kommuner existerar redan", EventLogEntryType.Information, 1000);
                    }
                    else {
                        municipals.Add("uppsala", new Municipal { AreaCode = "018", Name = "Uppsala", RegionLetter = "C" });
                        municipals.Add("borlänge", new Municipal { AreaCode = "0243", Name = "Borlänge", RegionLetter = "W" });
                    }

                    Global.Debug = "added municipals";

                    SPList listAgare = web.Lists.TryGetList("Ägare");
                    Global.Debug = "Ägare";
                    SPList listKontakter = web.Lists.TryGetList("Kontakter");
                    Global.Debug = "Kontakter";
                    SPList listAdresser = web.Lists.TryGetList("Adresser");
                    Global.Debug = "Adresser";
                    SPList listSidor = web.Lists.TryGetList("Webbplatssidor");
                    Global.Debug = "Webbplatssidor";
                    SPList listNyheter = web.Lists.TryGetList("Senaste nytt");
                    Global.Debug = "Senaste nytt";
                    //SPList listBlanketter = web.Lists.TryGetList("Blanketter");
                    SPList listGenvagar = web.Lists.TryGetList("Genvägar");
                    Global.Debug = "Genvägar";
                    //SPList listGruppkopplingar = web.Lists.TryGetList("Gruppkopplingar"); ??


                    if (listSidor != null) {
                        #region startsida
                        string compoundUrl = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Start.aspx");

                        //* Define page payout
                        _wikiFullContent = FormatBasicWikiLayout();
                        Global.Debug = "Skapa startsida";
                        SPFile startsida = listSidor.RootFolder.Files.Add(compoundUrl, SPTemplateFileType.WikiPage);

                        // Header
                        string relativeUrl = web.ServerRelativeUrl == "/" ? "" : web.ServerRelativeUrl;
                        _wikiFullContent = _wikiFullContent.Replace("[[HEADER]]", "<img alt=\"vinter\" src=\"" + relativeUrl + "/SiteAssets/profil_ettan_vinter_557x100.jpg\" style=\"margin: 5px;\"/><img alt=\"hj&auml;rta\" src=\"" + relativeUrl + "/SiteAssets/heart.gif\" style=\"margin: 5px;\"/>");

                        #region Nyheter
                        ListViewWebPart wpAnnouncements = new ListViewWebPart();
                        wpAnnouncements.ListName = listNyheter.ID.ToString("B").ToUpper();
                        //wpAnnouncements.ViewGuid = listNyheter.GetUncustomizedViewByBaseViewId(0).ID.ToString("B").ToUpper();
                        //wpAnnouncements.ViewGuid = listNyheter.DefaultView.ID.ToString("B").ToUpper();
                        wpAnnouncements.ViewGuid = string.Empty;
                        Guid wpAnnouncementsGuid = AddWebPartControlToPage(startsida, wpAnnouncements);
                        AddWebPartMarkUpToPage(wpAnnouncementsGuid, "[[COL1]]");
                        #endregion
                        #region Genvägar
                        ListViewWebPart wpLinks = new ListViewWebPart();
                        wpLinks.ListName = listGenvagar.ID.ToString("B").ToUpper();
                        //wpLinks.ViewGuid = listGenvagar.GetUncustomizedViewByBaseViewId(0).ID.ToString("B").ToUpper();
                        //wpLinks.ViewGuid = listGenvagar.DefaultView.ID.ToString("B").ToUpper();
                        wpLinks.ViewGuid = string.Empty;
                        Guid wpLinksGuid = AddWebPartControlToPage(startsida, wpLinks);
                        AddWebPartMarkUpToPage(wpLinksGuid, "[[COL2]]");
                        #endregion

                        Global.WriteLog("_wikiFullContent: " + _wikiFullContent, EventLogEntryType.Information, 1008);

                        startsida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        startsida.Item.UpdateOverwriteVersion();
                        Global.Debug = "Startsida skapad";
                        #endregion

                        #region lägg till försäljningsställe
                        string compoundUrl2 = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Lägg till försäljningsställe.aspx");

                        //* Define page payout
                        _wikiFullContent = FormatSimpleWikiLayout();
                        Global.Debug = "Skapa nybutiksida";
                        SPFile nybutiksida = listSidor.RootFolder.Files.Add(compoundUrl2, SPTemplateFileType.WikiPage);

                        // Header
                        _wikiFullContent = _wikiFullContent.Replace("[[COL1]]",
@"<h1>Sida för att lägga till nya försäljningsställen</h1>
<h2>STEG 1 - Lägg till ägare</h2>
[[WP1]]
<h2>STEG 2 - Lägg till adressuppgifter</h2>
[[WP2]]
<h2>STEG 3 - Lägg till kontaktperson</h2>
[[WP3]]
<h2>STEG&#160;4 - Lägg till försäljningsstället</h2>
[[WP4]]");

                        Global.Debug = "wpAgare";
                        XsltListViewWebPart wpAgare = new XsltListViewWebPart();
                        wpAgare.ChromeType = PartChromeType.None;
                        wpAgare.ListName = listAgare.ID.ToString("B").ToUpper();
                        wpAgare.ViewGuid = listAgare.Views["Tilläggsvy"].ID.ToString("B").ToUpper();
                        wpAgare.Toolbar = "Standard";
                        Guid wpAgareGuid = AddWebPartControlToPage(nybutiksida, wpAgare);
                        AddWebPartMarkUpToPage(wpAgareGuid, "[[WP1]]");

                        Global.Debug = "wpAdresser";
                        XsltListViewWebPart wpAdresser = new XsltListViewWebPart();
                        wpAdresser.ChromeType = PartChromeType.None;
                        wpAdresser.ListName = listAdresser.ID.ToString("B").ToUpper();
                        wpAdresser.ViewGuid = listAdresser.Views["Tilläggsvy"].ID.ToString("B").ToUpper();
                        wpAdresser.Toolbar = "Standard";
                        Guid wpAdresserGuid = AddWebPartControlToPage(nybutiksida, wpAdresser);
                        AddWebPartMarkUpToPage(wpAdresserGuid, "[[WP2]]");

                        Global.Debug = "wpKontakter";
                        XsltListViewWebPart wpKontakter = new XsltListViewWebPart();
                        wpKontakter.ChromeType = PartChromeType.None;
                        wpKontakter.ListName = listKontakter.ID.ToString("B").ToUpper();
                        wpKontakter.ViewGuid = listKontakter.Views["Tilläggsvy"].ID.ToString("B").ToUpper();
                        wpKontakter.Toolbar = "Standard";
                        Guid wpKontakterGuid = AddWebPartControlToPage(nybutiksida, wpKontakter);
                        AddWebPartMarkUpToPage(wpKontakterGuid, "[[WP3]]");

                        Global.Debug = "wpKundkort";
                        XsltListViewWebPart wpKundkort = new XsltListViewWebPart();
                        wpKundkort.ChromeType = PartChromeType.None;
                        wpKundkort.ListName = listKundkort.ID.ToString("B").ToUpper();
                        wpKundkort.ViewGuid = listKundkort.Views["Tilläggsvy"].ID.ToString("B").ToUpper();
                        wpKundkort.Toolbar = "Standard";
                        Guid wpKundkortGuid = AddWebPartControlToPage(nybutiksida, wpKundkort);
                        AddWebPartMarkUpToPage(wpKundkortGuid, "[[WP4]]");

                        nybutiksida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        nybutiksida.Item.UpdateOverwriteVersion();
                        Global.Debug = "Nybutiksida skapad";

                        #endregion

                        #region mitt försäljningsställe
                        string compoundUrl3 = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Mitt försäljningsställe.aspx");//* Define page payout
                        _wikiFullContent = FormatSimpleWikiLayout();
                        Global.Debug = "Skapa minbutiksida";
                        SPFile minbutiksida = listSidor.RootFolder.Files.Add(compoundUrl3, SPTemplateFileType.WikiPage);

                        Global.Debug = "wpMinButik";
                        MinButikWP wpMinButik = new MinButikWP();
                        wpMinButik.ChromeType = PartChromeType.None;
                        wpMinButik.Adresser = "Adresser";
                        wpMinButik.Agare = "Ägare";
                        wpMinButik.Kontakter = "Kontakter";
                        wpMinButik.Kundkort = "Kundkort";
                        Guid wpMinButikGuid = AddWebPartControlToPage(minbutiksida, wpMinButik);
                        AddWebPartMarkUpToPage(wpMinButikGuid, "[[COL1]]");

                        minbutiksida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        minbutiksida.Item.UpdateOverwriteVersion();
                        Global.Debug = "Nybutiksida skapad";
                        #endregion

                        #region skapa tillsynsrapport
                        //string compoundUrl4 = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Skapa tillsynsrapport.aspx");//* Define page payout
                        //_wikiFullContent = FormatSimpleWikiLayout();
                        //Global.Debug = "Skapa tillsynsrapport";
                        //SPFile skapatillsynsida = listSidor.RootFolder.Files.Add(compoundUrl4, SPTemplateFileType.WikiPage);

                        //Global.Debug = "wpTillsyn";
                        //TillsynWP wpTillsyn = new TillsynWP();
                        //wpTillsyn.ChromeType = PartChromeType.None;
                        //Guid wpTillsynGuid = AddWebPartControlToPage(skapatillsynsida, wpTillsyn);
                        //AddWebPartMarkUpToPage(wpTillsynGuid, "[[COL1]]");

                        //skapatillsynsida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        //skapatillsynsida.Item.UpdateOverwriteVersion();
                        //Global.Debug = "Skapatillsynsida skapad";
                        #endregion
                    }

                    Global.Debug = "ägare";
                    SPListItem item = listAgare.AddItem();
                    item["Title"] = "TESTÄGARE AB";
                    item.Update();

                    try {
                        Global.Debug = "kontakt";
                        item = listKontakter.AddItem();
                        item["Title"] = "Testsson";
                        item["FirstName"] = "Test";
                        item["Email"] = "test.testsson@test.se";
                        item.Update();

                        item = listKontakter.AddItem();
                        item["Title"] = "Jansson";
                        item["FirstName"] = "Peter";
                        item["Email"] = "peter.jansson@test.se";
                        item.Update();
                    }
                    catch (Exception ex) {
                        Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, EventLogEntryType.Error, 2001);
                    }

                    Global.Debug = "adress";
                    item = listAdresser.AddItem();
                    item["Title"] = "Testgatan 13b";
                    item.Update();

                    Global.Debug = "nyhet";
                    item = listNyheter.AddItem();
                    item["Title"] = "Vår online plattform för tillsyn av tobak och folköl håller på att starta upp här";
                    item["Body"] = @"Hej!

Nu har första stegen till en online plattform för tillsyn av tobak och folköl tagits. Här kan du som försäljningsställe ladda hem blanketter och ta del av utbildningsmaterial.

" + web.Title + " kommun";
                    item.Update();

                    Global.Debug = "länkar";
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
                    Global.Debug = "properties";
                    web.Properties.Update();

                }
                else {
                    Global.WriteLog("Redan aktiverad", EventLogEntryType.Information, 1000);
                }

                #region modify template
                Global.Debug = "ensure empty working directory";
                DirectoryInfo diTillsyn = new DirectoryInfo(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\TEMPLATE\LAYOUTS\UPCOR.TillsynKommun");
                string webid = web.Url.Replace("http://", "").Replace('/','_');
                string dirname = @"workdir_" + webid;
                Global.Debug = "dir: " + dirname;
                DirectoryInfo diWorkDir = diTillsyn.CreateSubdirectory(dirname);

                if (!diWorkDir.Exists)
                    diWorkDir.Create();
                foreach (FileInfo fi in diWorkDir.GetFiles()) {
                    fi.Delete();
                }

                Global.Debug = "whoami";
                Global.WriteLog(string.Format("Environment.UserName: {1}, Thread.CurrentPrincipal.Identity.Name: {2}", "", Environment.UserName, Thread.CurrentPrincipal.Identity.Name), EventLogEntryType.Information, 1000);


                Global.Debug = "extract";
                Process p = new Process();
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";
                string filename = diTillsyn.FullName + @"\template_unmodified.xsn";
                p.StartInfo.Arguments = "e \"" + filename + "\" -y -o\"" + diWorkDir.FullName + "\"";
                bool start = p.Start();
                p.WaitForExit();
                if (p.ExitCode != 0) {
                    Global.WriteLog(string.Format("7z Error:\r\n{0}\r\n\r\nFilename:\r\n{1}", p.StandardOutput.ReadToEnd(), filename), EventLogEntryType.Error, 1000);
                }

                Global.Debug = "get content type";
                SPContentType ctTillsyn = listAktiviteter.ContentTypes[_tillsynName];

                XNamespace xsf = "http://schemas.microsoft.com/office/infopath/2003/solutionDefinition";
                XNamespace xsf3 = "http://schemas.microsoft.com/office/infopath/2009/solutionDefinition/extensions";
                XNamespace xd = "http://schemas.microsoft.com/office/infopath/2003";

                Global.Debug = "modify manifest";
                XDocument doc = XDocument.Load(diWorkDir.FullName + @"\manifest.xsf");
                var xDocumentClass = doc.Element(xsf + "xDocumentClass");
                var q1 = from extension in xDocumentClass.Element(xsf + "extensions").Elements(xsf + "extension")
                         where extension.Attribute("name").Value == "SolutionDefinitionExtensions"
                         select extension;
                var node1 = q1.First().Element(xsf3 + "solutionDefinition").Element(xsf3 + "baseUrl");
                node1.Attribute("relativeUrlBase").Value = web.Url + "/Lists/Aktiviteter/Tillsyn/";
                var q2 = from dataObject in xDocumentClass.Element(xsf + "dataObjects").Elements(xsf + "dataObject")
                         where dataObject.Attribute("name").Value == "Kundkort"
                         select dataObject;
                var node2 = q2.First().Element(xsf + "query").Element(xsf + "sharepointListAdapterRW");
                node2.Attribute("sharePointListID").Value = "{" + listKundkort.ID.ToString() + "}";
                var node3 = xDocumentClass.Element(xsf + "query").Element(xsf + "sharepointListAdapterRW");
                node3.Attribute("sharePointListID").Value = "{" + listAktiviteter.ID.ToString() + "}";
                node3.Attribute("contentTypeID").Value = ctTillsyn.Id.ToString();
                doc.Save(diWorkDir.FullName + @"\manifest.xsf");

                Global.Debug = "modify view1";
                XDocument doc2 = XDocument.Load(diWorkDir.FullName + @"\view1.xsl");
                foreach (var d in doc2.Descendants("object")) {
                    d.Attribute(xd + "server").Value = web.Url + "/";
                }
                doc2.Save(diWorkDir.FullName + @"\view1.xsl");

                Global.Debug = "repack";
                string directive = "directives_" + webid + ".txt";
                string cabinet = "template_" + webid + ".xsn";
                FileInfo fiDirectives = new FileInfo(diTillsyn.FullName + '\\' + directive );
                if (fiDirectives.Exists)
                    fiDirectives.Delete();
                using (StreamWriter sw = fiDirectives.CreateText()) {
                    sw.WriteLine(".OPTION EXPLICIT");
                    sw.WriteLine(".set CabinetNameTemplate=" + cabinet);
                    sw.WriteLine(".set DiskDirectoryTemplate=\"" + diTillsyn.FullName + "\"");
                    sw.WriteLine(".set Cabinet=on");
                    sw.WriteLine(".set Compress=on");
                    foreach (FileInfo file in diWorkDir.GetFiles()) {
                        sw.WriteLine('"' + file.FullName + '"');
                    }
                }
                Process p2 = new Process();
                p2.StartInfo.RedirectStandardOutput = true;
                p2.StartInfo.UseShellExecute = false;
                //p2.StartInfo.FileName = diTillsyn.FullName + @"\makecab.exe";
                p2.StartInfo.FileName = @"c:\windows\system32\makecab.exe";
                p2.StartInfo.WorkingDirectory = diTillsyn.FullName;
                p2.StartInfo.Arguments = "/f " + fiDirectives.Name;
                bool start2 = p2.Start();
                p2.WaitForExit();
                if (p.ExitCode != 0) {
                    Global.WriteLog(string.Format("makecab Error:\r\n{0}", p2.StandardOutput.ReadToEnd()), EventLogEntryType.Error, 1000);
                }

                Global.Debug = "upload";
                FileInfo fiTemplate = new FileInfo(diTillsyn.FullName + '\\' + cabinet);
                if (fiTemplate.Exists) {
                    using (FileStream fs = fiTemplate.OpenRead()) {
                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, (int)fs.Length);
                        listAktiviteter.RootFolder.Files.Add("Lists/Aktiviteter/Tillsyn/template.xsn", data);
                    }
                }
                else {
                    Global.WriteLog("template.xsn missing", EventLogEntryType.Error, 1000);
                }
                #endregion

                Global.WriteLog("Feature Activated", EventLogEntryType.Information, 1001);
            }
            catch (Exception ex) {
                Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, EventLogEntryType.Error, 2001);
            }
        } // feature activated

        private Guid AddWebPartControlToPage(SPFile wikiFile, System.Web.UI.WebControls.WebParts.WebPart wp) {
            SPLimitedWebPartManager limitedWebPartManager = wikiFile.GetLimitedWebPartManager(PersonalizationScope.Shared);
            Guid storageKeyGuid = Guid.NewGuid();
            string storageKeyId = StorageKeyToID(storageKeyGuid);
            wp.ID = storageKeyId;
            try {
                limitedWebPartManager.AddWebPart(wp, "wpz", 0);
            }
            catch (Exception ex) {
                Global.WriteLog("limitedWebPartManager.AddWebPart\r\n\r\nMessage:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, EventLogEntryType.Error, 2005);
            }

            return storageKeyGuid;
        }

        private void AddWebPartMarkUpToPage(Guid wpGuid, string replaceToken) {
            string wpDiv = string.Format(CultureInfo.InvariantCulture, "<div class='ms-rtestate-read ms-rte-wpbox' contentEditable='false'><div class='ms-rtestate-read {0}' id='div_{0}'></div><div style='display:none' id='vid_{0}'></div></div>", new object[] { wpGuid.ToString("D") });
            _wikiFullContent = _wikiFullContent.Replace(replaceToken, wpDiv);
        }

        // 2 col & header
        private string FormatBasicWikiLayout() {
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

        public static string StorageKeyToID(Guid storageKey) {
            if (!(Guid.Empty == storageKey)) {
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
