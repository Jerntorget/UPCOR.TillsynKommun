using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI.WebControls.WebParts;
using System.Diagnostics;
using Microsoft.Office.InfoPath.Server.Controls.WebUI;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.SharePoint.Navigation;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.Publishing;

namespace UPCOR.TillsynKommun.Features.TillsynFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("44e042b2-02cd-4051-916e-0454625ef4a6")]
    public class TillsynFeatureEventReceiver : SPFeatureReceiver
    {
        private const string _tillsynName = "Tillsyn";
        private const string _permitName = "Ge försäljningstillstånd";
        private string _wikiFullContent;

        private Dictionary<string, Municipal> municipals = new Dictionary<string, Municipal>();
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties) {

            try {
                Global.Debug = "start";
                SPWeb web = properties.Feature.Parent as SPWeb;
                if (web == null) {
                }

                Global.URL = "Tillsyn FeatureActivated: " + web.Url;

                SPList listKundkort = web.Lists.TryGetList("Kundkort");
                Global.Debug = "Kundkort";
                SPList listAktiviteter = web.Lists.TryGetList("Aktiviteter");
                Global.Debug = "Aktiviteter";
                SPList listAdresser = web.Lists.TryGetList("Adresser");
                Global.Debug = "Adresser";
                SPList listAgare = web.Lists.TryGetList("Ägare");
                Global.Debug = "Ägare";
                SPList listKontakter = web.Lists.TryGetList("Kontakter");
                Global.Debug = "Kontakter";

               

                if (!web.Properties.ContainsKey("activatedOnce")) {
                    web.Properties.Add("activatedOnce", "true");
                    web.Properties.Update();
                    Global.Debug = "set activatedOnce flag";

                    #region sätt default-kommun-värden
                    if (municipals.Count > 0) {
                        Global.WriteLog("Kommuner existerar redan", EventLogEntryType.Information, 1000);
                    }
                    else {
                        municipals.Add("uppsala", new Municipal { AreaCode = "018", Name = "Uppsala", RegionLetter = "C" });
                        municipals.Add("borlänge", new Municipal { AreaCode = "0243", Name = "Borlänge", RegionLetter = "W" });
                    }
                    Global.Debug = "added municipals";
                    #endregion

                    #region hämta listor
                    //SPList listAgare = web.Lists.TryGetList("Ägare");
                    //Global.Debug = "Ägare";
                    //SPList listKontakter = web.Lists.TryGetList("Kontakter");
                    //Global.Debug = "Kontakter";
                    //SPList listAdresser = web.Lists.TryGetList("Adresser");
                    //Global.Debug = "Adresser";
                    SPList listSidor = web.Lists.TryGetList("Webbplatssidor");
                    Global.Debug = "Webbplatssidor";
                    SPList listNyheter = web.Lists.TryGetList("Senaste nytt");
                    Global.Debug = "Senaste nytt";
                    //SPList listBlanketter = web.Lists.TryGetList("Blanketter");
                    SPList listGenvagar = web.Lists.TryGetList("Genvägar");
                    Global.Debug = "Genvägar";
                    SPList listGruppkopplingar = web.Lists.TryGetList("Gruppkopplingar");
                    Global.Debug = "Gruppkopplingar";
                    SPList listGenvagarTillsynsverktyg = web.Lists.TryGetList("Genvägar för tillsynsverktyg");
                    Global.Debug = "Genvägar för tillsynsverktyg";
                    SPList listUppgifter = web.Lists.TryGetList("Uppgifter");
                    Global.Debug = "Uppgifter";
                    SPList listDokument = web.Lists.TryGetList("Dokument");
                    Global.Debug = "Dokument";



                    SPList[] lists = new SPList[] { listAgare, listKontakter, listAdresser, listSidor, listNyheter, listGenvagar, listGruppkopplingar, listGenvagarTillsynsverktyg, listUppgifter, listDokument };
                    int i = 0;
                    foreach (SPList list in lists) {
                        i++;
                        if (list == null) {
                            Global.WriteLog("Lista " + i.ToString() + " är null", EventLogEntryType.Error, 2000);
                        }
                    }
                    #endregion

                    var roleEdit = web.RoleDefinitions.GetByType(SPRoleType.Editor);
                    SPRoleAssignment assignmentMemberEdit = new SPRoleAssignment(web.AssociatedMemberGroup);
                    assignmentMemberEdit.RoleDefinitionBindings.Add(roleEdit);

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
                        wpAnnouncements.Width = "600px";
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
@"<h1>Steg-för-steg - Lägg till nytt försäljningsställe</h1>
För att underlätta inläggningen av nya försäljningställen för steg-för-steg guiden nedan. 
I de första stegen lägger du in information kring försäljningsstället, i det näst sista stegen kopplar du ihop 
angivna uppgifter och i det sista steg sätter du behörighet på försäljningsställets innehåll i portalen.<br />
<br />
Du skapar ett nytt objekt via länken <b>Nytt objekt</b>. Ange önskad information och tryck <b>Spara</b>. 
Fält markerade med * är obligatoriska.<br />
<h2>STEG 1 - Lägg till ägare</h2>
Registrera ägaren, dvs organisationsnumret för försäljningsstället. <br />
Ange <b>juridiskt namn</b>, <b>adressuppgifter</b> och <b>organisationsnummer</b>.<br />
[[WP1]]
<h2>STEG 2 - Lägg till adressuppgifter</h2>
Adressuppgifterna till försäljningsstället. <br />
Här anger du <b>försäljningsställets namn</b>, <b>besöksadress</b> och <b>telefon</b>/<b>e-post</b>.<br />
[[WP2]]
<h2>STEG 3 - Lägg till kontaktperson</h2>
Lägg till de kontaktpersoner som finns för försäljningsstället.<br />
Ange <b>efternamn</b>, <b>förnamn</b>, <b>befattning</b>, <b>företag</b>, <b>telefon</b>, <b>mobil</b> och <b>e-postadress</b>.<br />
[[WP3]]
<h2>STEG&#160;4 - Lägg till försäljningsstället</h2>
För att slutföra inläggningen av försäljningstället måste du koppla ihop uppgifterna ovan. <br />
Välj Nytt objekt, ange försäljningsstället i fältet <b>Adress</b>, Ägande organisation i <b>Ägare</b> och lägg till önskade <b>kontaktpersoner</b>.<br />
[[WP4]]
<h2>STEG 5 - Ge rättigheter</h2>
För att ge rätt behörigheter för innehållet kring försäljningsstället måste rättigheter anges. <br />
<br />
Klicka på det nyligen tillagda försäljningsstället i listan <b>Lägg till försäljningsställe</b> (ovan) och välj <b>Ge rättigheter</b>.");

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

                        #region tillsynsverktyg
                        string compoundUrl5 = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Tillsynsverktyg.aspx");//* Define page payout
                        _wikiFullContent = FormatBasicWikiLayout().Replace("[[HEADER]]", "").Replace("[[COL1]]", "[[WP1]][[WP2]]");
                        Global.Debug = "Tillsynsverktyg";
                        SPFile tillsynsverktygsida = listSidor.RootFolder.Files.Add(compoundUrl5, SPTemplateFileType.WikiPage);

                        #region Att göra
                        ListViewWebPart wpTodo = new ListViewWebPart();
                        wpTodo.ListName = listUppgifter.ID.ToString("B").ToUpper();
                        wpTodo.ViewGuid = listUppgifter.DefaultView.ID.ToString("B").ToUpper();
                        Guid wpTodoGuid = AddWebPartControlToPage(tillsynsverktygsida, wpTodo);
                        AddWebPartMarkUpToPage(wpTodoGuid, "[[WP1]]");
                        #endregion

                        #region Senaste aktiviteterna
                        ListViewWebPart wpLatest = new ListViewWebPart();
                        wpLatest.ListName = listAktiviteter.ID.ToString("B").ToUpper();
                        wpLatest.ViewGuid = string.Empty;
                        Guid wpLatestGuid = AddWebPartControlToPage(tillsynsverktygsida, wpLatest);
                        AddWebPartMarkUpToPage(wpLatestGuid, "[[WP2]]");
                        #endregion

                        #region Genvägar
                        ListViewWebPart wpLinks2 = new ListViewWebPart();
                        wpLinks2.ListName = listGenvagarTillsynsverktyg.ID.ToString("B").ToUpper();
                        wpLinks2.ViewGuid = listGenvagarTillsynsverktyg.DefaultView.ID.ToString("B").ToUpper();
                        Guid wpLinks2Guid = AddWebPartControlToPage(tillsynsverktygsida, wpLinks2);
                        AddWebPartMarkUpToPage(wpLinks2Guid, "[[COL2]]");
                        #endregion

                        tillsynsverktygsida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        tillsynsverktygsida.Item.BreakRoleInheritance(false);
                        tillsynsverktygsida.Item.RoleAssignments.Add(assignmentMemberEdit);
                        tillsynsverktygsida.Item.UpdateOverwriteVersion();

                        Global.Debug = "tillsynsverktygsida skapad";
                        #endregion

                        #region inställningar
                        string compoundUrl6 = string.Format("{0}/{1}", listSidor.RootFolder.ServerRelativeUrl, "Inställningar.aspx");//* Define page payout
                        _wikiFullContent = FormatSimpleWikiLayout();
                        Global.Debug = "Inställningar";
                        SPFile installningarsida = listSidor.RootFolder.Files.Add(compoundUrl6, SPTemplateFileType.WikiPage);

                        Global.Debug = "wpSettings";
                        SettingsWP wpSettings = new SettingsWP();
                        wpSettings.ChromeType = PartChromeType.None;
                        Guid wpSettingsGuid = AddWebPartControlToPage(installningarsida, wpSettings);
                        AddWebPartMarkUpToPage(wpSettingsGuid, "[[COL1]]");

                        installningarsida.Item[SPBuiltInFieldId.WikiField] = _wikiFullContent;
                        installningarsida.Item.BreakRoleInheritance(false);
                        installningarsida.Item.RoleAssignments.Add(assignmentMemberEdit);
                        installningarsida.Item.UpdateOverwriteVersion();
                        Global.Debug = "Installningarsida skapad";
                        #endregion
                    }

                    SPListItem item = null;

                    #region debugdata

                    //Global.Debug = "ägare";
                    //SPListItem item = listAgare.AddItem();
                    //item["Title"] = "TESTÄGARE AB";
                    //item[new Guid("0850AE15-19DD-431f-9C2F-3AFF3AE292CE")] = "123456-7890";
                    //item.Update();

                    //try {
                    //    Global.Debug = "kontakt";
                    //    item = listKontakter.AddItem();
                    //    item["Title"] = "Testsson";
                    //    item["FirstName"] = "Test";
                    //    item["Email"] = "test.testsson@test.se";
                    //    item["JobTitle"] = "testare";
                    //    item["CellPhone"] = "070 123 4567";
                    //    item.Update();

                    //    item = listKontakter.AddItem();
                    //    item["Title"] = "Jansson";
                    //    item["FirstName"] = "Peter";
                    //    item["Email"] = "peter.jansson@test.se";
                    //    item.Update();
                    //}
                    //catch (Exception ex) {
                    //    Global.WriteLog("Message:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, EventLogEntryType.Error, 2001);
                    //}

                    //Global.Debug = "adress";
                    //item = listAdresser.AddItem();
                    //item["Title"] = "Testbutiken";
                    //item["Besöksadress"] = "Testgatan 13b";
                    //item["Postnummer"] = "790 00";
                    //item["Ort"] = "Borlänge";
                    //item["Telefon"] = "0243-123456";
                    //item.Update();

                    //Global.Debug = "kundkort";
                    //item = listKundkort.AddItem();
                    //item["Title"] = "Testbutiken (W0243-1000)";
                    //item["butikAdress"] = 1;
                    //item["butikAgare"] = 1;
                    //item["butikKontakt1"] = 1;
                    //item["butikKundnummer"] = "W0243-1000";
                    //item["butikLopnummer"] = "1000";
                    //item.Update();

                    #endregion

                    #region nyhet
                    Global.Debug = "nyhet";
                    item = listNyheter.AddItem();
                    item["Title"] = "Vår online plattform för tillsyn av tobak och folköl håller på att starta upp här";
                    item["Body"] = @"Hej!

Nu har första stegen till en online plattform för tillsyn av tobak och folköl tagits. Här kan du som försäljningsställe ladda hem blanketter och ta del av utbildningsmaterial.

" + web.Title + " kommun";
                    item.Update();
                    #endregion

                    #region länkar
                    Global.Debug = "länkar";
                    item = listGenvagar.AddItem();
                    Global.Debug = "Blanketter";
                    item["Title"] = "Blanketter";
                    item["URL"] = web.ServerRelativeUrl + "/Blanketter, Blanketter";
                    item.Update();
                    item = listGenvagar.AddItem();
                    Global.Debug = "Utbildningsmaterial";
                    item["Title"] = "Utbildningsmaterial";
                    item["URL"] = web.ServerRelativeUrl + "/Utbildningsmaterial, Utbildningsmaterial";
                    item.Update();

                    item = listGenvagarTillsynsverktyg.AddItem();
                    Global.Debug = "Lägg till försäljningsställe";
                    item["Title"] = "Lägg till försäljningsställe";
                    item["URL"] = web.ServerRelativeUrl + "/SitePages/Lägg%20till%20försäljningsställe.aspx, Lägg till försäljningsställe";
                    item.Update();
                    item = listGenvagarTillsynsverktyg.AddItem();
                    Global.Debug = "Nytt tillsynsprotokoll";
                    item["Title"] = "Nytt tillsynsprotokoll";
                    item["URL"] = web.ServerRelativeUrl + "/_layouts/15/listform.aspx?PageType=8&ListId=" + System.Web.HttpUtility.UrlEncode(listAktiviteter.ID.ToString("B")).ToUpper().Replace("-", "%2D") + "&RootFolder=, Nytt tillsynsprotokoll";
                    item.Update();

                    
                    #endregion

                    #region sätt kundnummeregenskaper
                    Global.Debug = "löpnummer";
                    web.Properties.Add("lopnummer", "1000");
                    Global.Debug = "prefixformel";
                    web.Properties.Add("prefixFormula", "%B%R-%N");
                    Global.Debug = "listAdresserGUID";
                    web.Properties.Add("listAdresserGUID", listAdresser.ID.ToString());
                    Global.Debug = "listAgareGUID";
                    web.Properties.Add("listAgareGUID", listAgare.ID.ToString());
                    Global.Debug = "gruppkopplingar";
                    web.Properties.Add("listGruppkopplingarGUID", listGruppkopplingar.ID.ToString());
                    try {
                        Municipal m = municipals[web.Title.ToLower()];
                        web.Properties.Add("municipalAreaCode", m.AreaCode);
                        web.Properties.Add("municipalRegionLetter", m.RegionLetter);
                    }
                    catch { }
                    Global.Debug = "properties";
                    web.Properties.Update();
                    #endregion

                    #region lägg till navigeringslänkar

                    try {
                        SPNavigationNode blanketter = new SPNavigationNode("Blanketter", "Blanketter", false);
                        SPNavigationNode utbildningsmaterial = new SPNavigationNode("Utbildningsmaterial", "Utbildningsmaterial", false);
                        SPNavigationNode minbutik = new SPNavigationNode("Mitt försäljningsställe", "SitePages/Mitt%20försäljningsställe.aspx", false);
                        SPNavigationNode tillsynsverktyg = new SPNavigationNode("Tillsynsverktyg", "SitePages/Tillsynsverktyg.aspx", false);
                        SPNavigationNode dokument = new SPNavigationNode("Dokument", "Documents", false);
                        //dokument.Properties["Audience"] = ";;;;" + web.AssociatedMemberGroup.Name;
                        SPNavigationNode installningar = new SPNavigationNode("Inställningar", "SitePages/Inställningar.aspx", false);

                        web.Navigation.QuickLaunch.AddAsLast(blanketter);
                        web.Navigation.QuickLaunch.AddAsLast(utbildningsmaterial);
                        web.Navigation.QuickLaunch.AddAsLast(minbutik);
                        web.Navigation.QuickLaunch.AddAsLast(tillsynsverktyg);

                        SPNavigationNode senaste = SPNavigationSiteMapNode.CreateSPNavigationNode("Hantera Senaste Nytt", "Lists/Nyheter/AllItems.aspx", NodeTypes.Default, web.Navigation.QuickLaunch);
                        senaste.Properties.Add("Audience", ";;;;" + web.AssociatedMemberGroup.Name);

                        web.Navigation.QuickLaunch.AddAsLast(dokument);
                        web.Navigation.QuickLaunch.AddAsLast(installningar);

                        SPNavigationNode uppgifter = new SPNavigationNode("Att göra", "Lists/Uppgifter", false);
                        SPNavigationNode aktiviteter = new SPNavigationNode("Aktiviteter", "Lists/Aktiviteter", false);
                        SPNavigationNode kundkort = new SPNavigationNode("Försäljningsställen", "Lists/Kundkort", false);
                        //SPNavigationNode forsaljningsstallen = new SPNavigationNode("Försäljningsställen", "Lists/Adresser", false);
                        SPNavigationNode kontakter = new SPNavigationNode("Kontakter", "Lists/Kundkort/Kontaktlista.aspx", false);
                        SPNavigationNode agare = new SPNavigationNode("Ägare", "Lists/Agare", false);
                        //SPNavigationNode forsaljningstillstand = new SPNavigationNode("Försäljningstillstånd", "Lists/Forsaljningstillstand");
                        SPNavigationNode laggtill = new SPNavigationNode("Lägg till försäljningsställe", "SitePages/Lägg%20till%20försäljningsställe.aspx", false);
                        SPNavigationNode editkontakter = new SPNavigationNode("Redigera kontakter", "Lists/Kontakter/Redigeringsvy.aspx", false);
                        SPNavigationNode editagare = new SPNavigationNode("Redigera ägare", "Lists/Agare/Redigeringsvy.aspx", false);
                        SPNavigationNode editadresser = new SPNavigationNode("Redigera adresser", "Lists/Adresser/Redigeringsvy.aspx", false);

                        tillsynsverktyg.Children.AddAsFirst(uppgifter);
                        tillsynsverktyg.Children.AddAsLast(aktiviteter);
                        tillsynsverktyg.Children.AddAsLast(kundkort);
                        //                    tillsynsverktyg.Children.AddAsLast(forsaljningsstallen);
                        tillsynsverktyg.Children.AddAsLast(kontakter);
                        tillsynsverktyg.Children.AddAsLast(agare);
                        tillsynsverktyg.Children.AddAsLast(laggtill);
                        tillsynsverktyg.Children.AddAsLast(editkontakter);
                        tillsynsverktyg.Children.AddAsLast(editagare);
                        tillsynsverktyg.Children.AddAsLast(editadresser);
                    }
                    catch (Exception ex) {
                        Global.WriteLog("lägg till navigeringslänkar\r\n\r\nMessage:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, EventLogEntryType.Error, 2001);
                    }

                    #endregion

                    #region sätt rättigheter
                    try {
                        Global.Debug = "1";
                        listGenvagarTillsynsverktyg.BreakRoleInheritance(false);
                        listGenvagarTillsynsverktyg.RoleAssignments.Add(assignmentMemberEdit);
                        listGenvagarTillsynsverktyg.Update();

                        Global.Debug = "5";
                        listDokument.BreakRoleInheritance(false);
                        listDokument.RoleAssignments.Add(assignmentMemberEdit);
                        listDokument.Update();

                        listKundkort.BreakRoleInheritance(true);
                        var ra = listKundkort.RoleAssignments.GetAssignmentByPrincipal(web.AssociatedVisitorGroup);
                        ra.RoleDefinitionBindings.RemoveAll();
                        ra.Update();

                        listAgare.BreakRoleInheritance(true);
                        var ra2 = listAgare.RoleAssignments.GetAssignmentByPrincipal(web.AssociatedVisitorGroup);
                        ra2.RoleDefinitionBindings.RemoveAll();
                        ra2.Update();

                        listAdresser.BreakRoleInheritance(true);
                        var ra3 = listAdresser.RoleAssignments.GetAssignmentByPrincipal(web.AssociatedVisitorGroup);
                        ra3.RoleDefinitionBindings.RemoveAll();
                        ra3.Update();
                    }
                    catch (Exception ex) {
                        Global.WriteLog("sätt rättigheter\r\n\r\nMessage:\r\n" + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace + "\r\n\r\nDebug:\r\n" + Global.Debug, EventLogEntryType.Error, 2001);
                    }

                    #endregion
                }
                else {
                    Global.WriteLog("Redan aktiverad", EventLogEntryType.Information, 1000);
                }

                #region modify template global
                Global.Debug = "ensure empty working directory";
                DirectoryInfo diFeature = new DirectoryInfo(@"C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\15\TEMPLATE\LAYOUTS\UPCOR.TillsynKommun");
                string webid = web.Url.Replace("http://", "").Replace('/', '_');
                string dirname_insp = @"workdir_inspection_" + webid;
                string dirname_perm = @"workdir_permit_" + webid;
                DirectoryInfo diWorkDirInspection = diFeature.CreateSubdirectory(dirname_insp);
                DirectoryInfo diWorkDirPermit = diFeature.CreateSubdirectory(dirname_perm);

                if (!diWorkDirInspection.Exists)
                    diWorkDirInspection.Create();
                if (!diWorkDirPermit.Exists)
                    diWorkDirPermit.Create();

                XNamespace xsf = "http://schemas.microsoft.com/office/infopath/2003/solutionDefinition";
                XNamespace xsf2 = "http://schemas.microsoft.com/office/infopath/2006/solutionDefinition/extensions";
                XNamespace xsf3 = "http://schemas.microsoft.com/office/infopath/2009/solutionDefinition/extensions";
                XNamespace xd = "http://schemas.microsoft.com/office/infopath/2003";
                XNamespace rs = "urn:schemas-microsoft-com:rowset";
                XNamespace z = "#RowsetSchema";

                #endregion

                #region modify template tillsyn
                {
                    Global.Debug = "deleting files";
                    foreach (FileInfo fi in diWorkDirInspection.GetFiles()) {
                        fi.Delete();
                    }

                    #region extract
                    Global.Debug = "extract";
                    Process p = new Process();
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";
                    //string filename = diTillsyn.FullName + @"\75841904-0c67-4118-826f-b1319db35c6a.xsn";
                    //string filename = diFeature.FullName + @"\4BEB6318-1CE0-47BE-92C2-E9815D312C1A.xsn";
                    //string filename = diFeature.FullName + @"\inspection.xsn";
                    string filename = diFeature.FullName + @"\inspection4.xsn";

                    p.StartInfo.Arguments = "e \"" + filename + "\" -y -o\"" + diWorkDirInspection.FullName + "\"";
                    bool start = p.Start();
                    p.WaitForExit();
                    if (p.ExitCode != 0) {
                        Global.WriteLog(string.Format("7z Error:\r\n{0}\r\n\r\nFilename:\r\n{1}", p.StandardOutput.ReadToEnd(), filename), EventLogEntryType.Error, 1000);
                    }
                    #endregion

                    Global.Debug = "get content type _tillsynName";
                    SPContentType ctTillsyn = listAktiviteter.ContentTypes[_tillsynName];

                    #region modify manifest
                    Global.Debug = "modify manifest tillsyn";
                    XDocument doc = XDocument.Load(diWorkDirInspection.FullName + @"\manifest.xsf");
                    var xDocumentClass = doc.Element(xsf + "xDocumentClass");
                    var q1 = from extension in xDocumentClass.Element(xsf + "extensions").Elements(xsf + "extension")
                             where extension.Attribute("name").Value == "SolutionDefinitionExtensions"
                             select extension;
                    var node1 = q1.First().Element(xsf3 + "solutionDefinition").Element(xsf3 + "baseUrl");
                    node1.Attribute("relativeUrlBase").Value = web.Url + "/Lists/Aktiviteter/" + _tillsynName + "/";
                    var q2 = from dataObject in xDocumentClass.Element(xsf + "dataObjects").Elements(xsf + "dataObject")
                             //where dataObject.Attribute("name").Value == "Kundkort"
                             select dataObject;
                    foreach (var n in q2) {
                        SPList list = null;
                        switch(n.Attribute("name").Value) {
                            case "Kundkort":
                            case "Kundkort1":
                                list = listKundkort;
                                break;
                            case "Adresser":
                                list = listAdresser;
                                break;
                            case "Ägare":
                                list = listAgare;
                                break;
                            case "Kontakter":
                                list = listKontakter;
                                break;
                        }

                        if (list != null) {
                            var node2 = n.Element(xsf + "query").Element(xsf + "sharepointListAdapterRW");
                            node2.Attribute("sharePointListID").Value = "{" + list.ID.ToString() + "}";
                        }
                    }
                    var node3 = xDocumentClass.Element(xsf + "query").Element(xsf + "sharepointListAdapterRW");
                    node3.Attribute("sharePointListID").Value = "{" + listAktiviteter.ID.ToString() + "}";
                    node3.Attribute("contentTypeID").Value = ctTillsyn.Id.ToString();
                    var q3 = q1.First().Element(xsf2 + "solutionDefinition").Element(xsf2 + "dataConnections").Elements(xsf2 + "sharepointListAdapterRWExtension");
                    foreach (var n in q3) {
                        var oldkey = n.Attribute("queryKey").Value;
                        oldkey = oldkey.Substring(oldkey.IndexOf('<'));
                        oldkey = web.Url + "/" + oldkey;
                        Regex r = new Regex("{.*?}");
                        Guid newguid = Guid.Empty;
                        switch (n.Attribute("ref").Value) {
                            case "Kundkort1":
                                newguid = listKundkort.ID;
                                break;
                            case "Adresser":
                                newguid = listAdresser.ID;
                                break;
                            case "Ägare":
                                newguid = listAgare.ID;
                                break;
                            case "Kontakter":
                                newguid = listKontakter.ID;
                                break;
                        }
                        n.Attribute("queryKey").Value = r.Replace(oldkey, "{" + newguid.ToString() + "}");
                    }
                    doc.Save(diWorkDirInspection.FullName + @"\manifest.xsf");

                    Global.Debug = "modify view1";
                    XDocument doc2 = XDocument.Load(diWorkDirInspection.FullName + @"\view1.xsl");
                    foreach (var d in doc2.Descendants("object")) {
                        d.Attribute(xd + "server").Value = web.Url + "/";
                    }
                    doc2.Save(diWorkDirInspection.FullName + @"\view1.xsl");

                    Global.Debug = "modify offline files";
                    foreach (FileInfo fi in diWorkDirInspection.GetFiles("*_offline.xml")) {
                        XDocument doc3 = XDocument.Load(fi.FullName);
                        foreach (var n in doc3.Descendants(z + "row")) {
                            string oldFileRef = n.Attribute("ows_FileRef").Value;
                            n.Attribute("ows_FileRef").Value = oldFileRef.Replace("sites/blg27", web.ServerRelativeUrl.Substring(1));
                        }
                        doc3.Save(fi.FullName);
                    }
                    #endregion

                    #region repack
                    Global.Debug = "repack";
                    string directive = "directives_inspection_" + webid + ".txt";
                    string cabinet = "template_inspection_" + webid + ".xsn";
                    FileInfo fiDirectives = new FileInfo(diFeature.FullName + '\\' + directive);
                    if (fiDirectives.Exists)
                        fiDirectives.Delete();
                    using (StreamWriter sw = fiDirectives.CreateText()) {
                        sw.WriteLine(".OPTION EXPLICIT");
                        sw.WriteLine(".set CabinetNameTemplate=" + cabinet);
                        sw.WriteLine(".set DiskDirectoryTemplate=\"" + diFeature.FullName + "\"");
                        sw.WriteLine(".set Cabinet=on");
                        sw.WriteLine(".set Compress=on");
                        foreach (FileInfo file in diWorkDirInspection.GetFiles()) {
                            sw.WriteLine('"' + file.FullName + '"');
                        }
                    }
                    Process p2 = new Process();
                    p2.StartInfo.RedirectStandardOutput = true;
                    p2.StartInfo.UseShellExecute = false;
                    //p2.StartInfo.FileName = diTillsyn.FullName + @"\makecab.exe";
                    p2.StartInfo.FileName = @"c:\windows\system32\makecab.exe";
                    p2.StartInfo.WorkingDirectory = diFeature.FullName;
                    p2.StartInfo.Arguments = "/f " + fiDirectives.Name;
                    bool start2 = p2.Start();
                    p2.WaitForExit();
                    if (p.ExitCode != 0) {
                        Global.WriteLog(string.Format("makecab Error:\r\n{0}", p2.StandardOutput.ReadToEnd()), EventLogEntryType.Error, 1000);
                    }
                    #endregion

                    #region upload
                    Global.Debug = "upload";
                    FileInfo fiTemplate = new FileInfo(diFeature.FullName + '\\' + cabinet);
                    if (fiTemplate.Exists) {
                        // delete it if it already exists
                        SPFile f = web.GetFile("Lists/Aktiviteter/" + _tillsynName + "/template.xsn");
                        if (f.Exists)
                            f.Delete();

                        using (FileStream fs = fiTemplate.OpenRead()) {
                            byte[] data = new byte[fs.Length];
                            fs.Read(data, 0, (int)fs.Length);
                            SPFile file = listAktiviteter.RootFolder.Files.Add("Lists/Aktiviteter/" + _tillsynName + "/template.xsn", data);
                            Global.Debug = "set file properties";
                            //file.Properties["vti_contenttag"] = "{6908F1AD-3962-4293-98BB-0AA4FB54B9C9},3,1";
                            file.Properties["ipfs_streamhash"] = "0NJ+LASyxjJGhaIwPftKfwraa3YBBfJoNUPNA+oNYu4=";
                            file.Properties["ipfs_listform"] = "true";
                            file.Update();
                        }
                        Global.Debug = "set folder properties";
                        SPFolder folder = listAktiviteter.RootFolder.SubFolders["Tillsyn"];
                        folder.Properties["_ipfs_solutionName"] = "template.xsn";
                        folder.Properties["_ipfs_infopathenabled"] = "True";
                        folder.Update();
                    }
                    else {
                        Global.WriteLog("template.xsn missing", EventLogEntryType.Error, 1000);
                    }
                    #endregion
                }
                #endregion

                #region modify template permit
                {
                    Global.Debug = "delete";
                    foreach (FileInfo fi in diWorkDirPermit.GetFiles()) {
                        fi.Delete();
                    }

                    #region extract
                    Global.Debug = "extract";
                    Process p = new Process();
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";
                    string filename = diFeature.FullName + @"\givepermit.xsn";

                    p.StartInfo.Arguments = "e \"" + filename + "\" -y -o\"" + diWorkDirPermit.FullName + "\"";
                    bool start = p.Start();
                    p.WaitForExit();
                    if (p.ExitCode != 0) {
                        Global.WriteLog(string.Format("7z Error:\r\n{0}\r\n\r\nFilename:\r\n{1}", p.StandardOutput.ReadToEnd(), filename), EventLogEntryType.Error, 1000);
                    }
                    #endregion

                    Global.Debug = "get content type permit";
                    SPContentType ctPermit = listAktiviteter.ContentTypes[_permitName];

                    #region modify manifest
                    Global.Debug = "modify manifest permit";
                    XDocument doc = XDocument.Load(diWorkDirPermit.FullName + @"\manifest.xsf");
                    var xDocumentClass = doc.Element(xsf + "xDocumentClass");
                    var q1 = from extension in xDocumentClass.Element(xsf + "extensions").Elements(xsf + "extension")
                             where extension.Attribute("name").Value == "SolutionDefinitionExtensions"
                             select extension;
                    var node1 = q1.First().Element(xsf3 + "solutionDefinition").Element(xsf3 + "baseUrl");
                    node1.Attribute("relativeUrlBase").Value = web.Url + "/Lists/Aktiviteter/" + _permitName + "/";
                    var q2 = from dataObject in xDocumentClass.Element(xsf + "dataObjects").Elements(xsf + "dataObject")
                             where dataObject.Attribute("name").Value == "Kundkort"
                             select dataObject;
                    var node2 = q2.First().Element(xsf + "query").Element(xsf + "sharepointListAdapterRW");
                    node2.Attribute("sharePointListID").Value = "{" + listKundkort.ID.ToString() + "}";
                    var node3 = xDocumentClass.Element(xsf + "query").Element(xsf + "sharepointListAdapterRW");
                    node3.Attribute("sharePointListID").Value = "{" + listAktiviteter.ID.ToString() + "}";
                    node3.Attribute("contentTypeID").Value = ctPermit.Id.ToString();
                    doc.Save(diWorkDirPermit.FullName + @"\manifest.xsf");

                    //Global.Debug = "modify view1";
                    //XDocument doc2 = XDocument.Load(diWorkDir.FullName + @"\view1.xsl");
                    //foreach (var d in doc2.Descendants("object")) {
                    //    d.Attribute(xd + "server").Value = web.Url + "/";
                    //}
                    //doc2.Save(diWorkDir.FullName + @"\view1.xsl");
                    #endregion

                    #region repack
                    Global.Debug = "repack";
                    string directive = "directives_permit_" + webid + ".txt";
                    string cabinet = "template_permit_" + webid + ".xsn";
                    FileInfo fiDirectives = new FileInfo(diFeature.FullName + '\\' + directive);
                    if (fiDirectives.Exists)
                        fiDirectives.Delete();
                    using (StreamWriter sw = fiDirectives.CreateText()) {
                        sw.WriteLine(".OPTION EXPLICIT");
                        sw.WriteLine(".set CabinetNameTemplate=" + cabinet);
                        sw.WriteLine(".set DiskDirectoryTemplate=\"" + diFeature.FullName + "\"");
                        sw.WriteLine(".set Cabinet=on");
                        sw.WriteLine(".set Compress=on");
                        foreach (FileInfo file in diWorkDirPermit.GetFiles()) {
                            sw.WriteLine('"' + file.FullName + '"');
                        }
                    }
                    Process p2 = new Process();
                    p2.StartInfo.RedirectStandardOutput = true;
                    p2.StartInfo.UseShellExecute = false;
                    //p2.StartInfo.FileName = diTillsyn.FullName + @"\makecab.exe";
                    p2.StartInfo.FileName = @"c:\windows\system32\makecab.exe";
                    p2.StartInfo.WorkingDirectory = diFeature.FullName;
                    p2.StartInfo.Arguments = "/f " + fiDirectives.Name;
                    bool start2 = p2.Start();
                    p2.WaitForExit();
                    if (p.ExitCode != 0) {
                        Global.WriteLog(string.Format("makecab Error:\r\n{0}", p2.StandardOutput.ReadToEnd()), EventLogEntryType.Error, 1000);
                    }
                    #endregion

                    #region upload
                    Global.Debug = "upload";
                    FileInfo fiTemplate = new FileInfo(diFeature.FullName + '\\' + cabinet);
                    if (fiTemplate.Exists) {
                        // delete it if it already exists
                        SPFile f = web.GetFile("Lists/Aktiviteter/" + _permitName + "/template.xsn");
                        if (f.Exists)
                            f.Delete();

                        using (FileStream fs = fiTemplate.OpenRead()) {
                            byte[] data = new byte[fs.Length];
                            fs.Read(data, 0, (int)fs.Length);
                            SPFile file = listAktiviteter.RootFolder.Files.Add("Lists/Aktiviteter/" + _permitName + "/template.xsn", data);
                            Global.Debug = "set file properties";
                            //file.Properties["vti_contenttag"] = "{6908F1AD-3962-4293-98BB-0AA4FB54B9C9},3,1";
                            file.Properties["ipfs_streamhash"] = "0NJ+LASyxjJGhaIwPftKfwraa3YBBfJoNUPNA+oNYu4=";
                            file.Properties["ipfs_listform"] = "true";
                            file.Update();
                        }
                        Global.Debug = "set folder properties";
                        SPFolder folder = listAktiviteter.RootFolder.SubFolders["Ge försäljningstillstånd"];
                        folder.Properties["_ipfs_solutionName"] = "template.xsn";
                        folder.Properties["_ipfs_infopathenabled"] = "True";
                        folder.Update();
                    }
                    else {
                        Global.WriteLog("template.xsn missing", EventLogEntryType.Error, 1000);
                    }
                    #endregion
                }
                #endregion

                #region set default forms
                Global.Debug = "set default forms";
                foreach (SPContentType ct in listAktiviteter.ContentTypes) {
                    switch (ct.Name) {
                        case "Tillsyn":
                        case "Ge försäljningstillstånd":
                            ct.DisplayFormUrl = "~list/" + ct.Name + "/displayifs.aspx";
                            ct.EditFormUrl = "~list/" + ct.Name + "/editifs.aspx";
                            ct.NewFormUrl = "~list/" + ct.Name + "/newifs.aspx";
                            ct.Update();
                            break;
                        default:
                            ct.DisplayFormUrl = ct.EditFormUrl = ct.NewFormUrl = string.Empty;
                            ct.Update();
                            break;
                    }

                }

                // create our own array since it will be modified (which would throw an exception)
                var forms = new SPForm[listAktiviteter.Forms.Count];
                int j = 0;
                foreach (SPForm form in listAktiviteter.Forms) {
                    forms[j] = form;
                    j++;
                }
                foreach (var form in forms) {
                    SPFile page = web.GetFile(form.Url);
                    SPLimitedWebPartManager limitedWebPartManager = page.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                    foreach (System.Web.UI.WebControls.WebParts.WebPart wp in limitedWebPartManager.WebParts) {
                        if (wp is BrowserFormWebPart) {
                            BrowserFormWebPart bfwp = (BrowserFormWebPart)wp.WebBrowsableObject;
                            string[] aLocation = form.Url.Split('/');
                            string contenttype = aLocation[aLocation.Length - 2];
                            bfwp.FormLocation = "~list/" + contenttype + "/template.xsn";
                            limitedWebPartManager.SaveChanges(bfwp);

                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine();
                            sb.Append("BrowserFormWebPart FormLocation: ");
                            sb.AppendLine(bfwp.FormLocation);
                            sb.Append("BrowserFormWebPart Title: ");
                            sb.AppendLine(bfwp.Title);
                            sb.Append("BrowserFormWebPart ID: ");
                            sb.AppendLine(bfwp.ID);
                            sb.Append("Form URL: ");
                            sb.AppendLine(form.Url);
                            sb.Append("Form TemplateName: ");
                            sb.AppendLine(form.TemplateName);
                            sb.Append("Form ID: ");
                            sb.AppendLine(form.ID.ToString());
                            sb.Append("Form ServerRelativeUrl: ");
                            sb.AppendLine(form.ServerRelativeUrl);
                            sb.AppendLine("BrowserFormWebPart Schema: ");
                            sb.AppendLine();
                            sb.AppendLine(form.SchemaXml);

                            //Global.WriteLog(sb.ToString(), EventLogEntryType.Information, 1000);
                        }
                    } // foreach webpart
                } // foreach form

                #endregion

                #region cleanup

                Global.Debug = "cleanup";
                //diWorkDirInspection.Delete(true);
                diWorkDirPermit.Delete(true);
                foreach (FileInfo fi in diFeature.GetFiles("template*.xsn"))
                    fi.Delete();
                foreach (FileInfo fi in diFeature.GetFiles("directives*.xsn"))
                    fi.Delete();

                #endregion

                #region stäng av required på rubrik
                Global.Debug = "stäng av required på rubrik - kundkort";
                SPField title = listKundkort.Fields[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")];
                if (title != null) {
                    title.Required = false;
                    title.ShowInNewForm = false;
                    title.ShowInEditForm = false;
                    title.Update();
                }

                title = listAktiviteter.Fields[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")];
                Global.WriteLog("listAktiviteter Title - Required: " + title.Required.ToString() + ", ShowInNew: " + title.ShowInNewForm.ToString() + ", ShowInEdit: " + title.ShowInEditForm.ToString(), EventLogEntryType.Information, 1000);
                title.Required = false;
                title.ShowInNewForm = false;
                title.ShowInEditForm = false;
                title.Update();

                Global.Debug = "stäng av required på rubrik - aktiviteter";
                foreach (SPContentType ct in listAktiviteter.ContentTypes) {
                    SPFieldLink flTitle = ct.FieldLinks[new Guid("fa564e0f-0c70-4ab9-b863-0177e6ddd247")];
                    if (flTitle != null) {
                        flTitle.Required = false;
                        flTitle.Hidden = true;
                        ct.Update();
                    }
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
