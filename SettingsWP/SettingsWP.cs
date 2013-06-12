using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace UPCOR.TillsynKommun
{
    [ToolboxItemAttribute(false)]
    public class SettingsWP : WebPart
    {
        //Button btnFix;
        TextBox txtPrefixLansbokstav;
        TextBox txtPrefixRiktnummer;
        TextBox txtLopnummer;
        TextBox txtFormel;
        Label lblResult;

        protected override void CreateChildControls() {
            try {
                Controls.Add(new LiteralControl("OBS! Ändringar i kundnummerinställningar gäller endast nya försäljningsställen.<br /><br />"));
                Table tblSettings = new Table();
                tblSettings.CellPadding = 3;
                TableRow tr; TableCell td;

                tr = new TableRow();
                td = new TableCell();
                td.ColumnSpan = 2;
                td.Controls.Add(new LiteralControl("<h3>Kundnummer</h3>"));
                tr.Controls.Add(td);
                tblSettings.Rows.Add(tr);

                tr = new TableRow();
                td = new TableCell();
                td.Controls.Add(new LiteralControl("Länsbokstav (%B): "));
                tr.Controls.Add(td);
                td = new TableCell();
                txtPrefixLansbokstav = new TextBox();
                td.Controls.Add(txtPrefixLansbokstav);
                tr.Controls.Add(td);
                tblSettings.Rows.Add(tr);

                tr = new TableRow();
                td = new TableCell();
                td.Controls.Add(new LiteralControl("Riktnummer (%R): "));
                tr.Controls.Add(td);
                td = new TableCell();
                txtPrefixRiktnummer = new TextBox();
                td.Controls.Add(txtPrefixRiktnummer);
                tr.Controls.Add(td);
                tblSettings.Rows.Add(tr);

                tr = new TableRow();
                td = new TableCell();
                td.Controls.Add(new LiteralControl("Löpnummer (%N): "));
                tr.Controls.Add(td);
                td = new TableCell();
                txtLopnummer = new TextBox();
                td.Controls.Add(txtLopnummer);
                tr.Controls.Add(td);
                tblSettings.Rows.Add(tr);

                tr = new TableRow();
                td = new TableCell();
                td.Controls.Add(new LiteralControl("Formel: "));
                tr.Controls.Add(td);
                td = new TableCell();
                txtFormel = new TextBox();
                td.Controls.Add(txtFormel);
                tr.Controls.Add(td);
                tblSettings.Rows.Add(tr);

                Controls.Add(tblSettings);

                Controls.Add(new LiteralControl("<br />"));

                lblResult = new Label();
                lblResult.Style.Add(HtmlTextWriterStyle.Color, "#f00");
                lblResult.Style.Add(HtmlTextWriterStyle.FontStyle, "italic");
                Controls.Add(lblResult);

                Controls.Add(new LiteralControl("<br /><br />"));

                Button btnSave = new Button();
                btnSave.Text = "Spara";
                btnSave.Click += btnSave_Click;
                Controls.Add(btnSave);

                this.DataBinding += SettingsWP_DataBinding;
                this.DataBind();
            }
            catch (Exception ex) {
                Controls.Add(new LiteralControl("Exception: " + ex.Message + "<br /><br />Stacktrace: " + ex.StackTrace + "<br /><br />Debug: " + Global.Debug));
            }
        }

        private void SettingsWP_DataBinding(object sender, EventArgs e) {
            txtLopnummer.Text = SPContext.Current.Web.Properties["lopnummer"];
            txtPrefixRiktnummer.Text = SPContext.Current.Web.Properties["municipalAreaCode"];
            txtPrefixLansbokstav.Text = SPContext.Current.Web.Properties["municipalRegionLetter"];
            txtFormel.Text = SPContext.Current.Web.Properties["prefixFormula"];
        }

        void btnSave_Click(object sender, EventArgs e) {
            SPContext.Current.Web.Properties["lopnummer"] = txtLopnummer.Text;
            SPContext.Current.Web.Properties["municipalAreaCode"] = txtPrefixRiktnummer.Text;
            SPContext.Current.Web.Properties["municipalRegionLetter"] = txtPrefixLansbokstav.Text;
            SPContext.Current.Web.Properties["prefixFormula"] = txtFormel.Text;
            SPContext.Current.Web.Properties.Update();
            lblResult.Text = "Inställningar sparade";
        }

        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);

            try {
                #region fixtemplate
                //Global.Debug = "fixtemplate";
                //SPWeb web = SPContext.Current.Web;
                //SPList listAktiviteter = web.Lists.TryGetList("Aktiviteter");
                //Global.Debug = "Tillsyn";
                //SPFolder folder = listAktiviteter.RootFolder.SubFolders["Tillsyn"];
                //string sn = (string)folder.Properties["_ipfs_solutionName"];
                //string ie = (string)folder.Properties["_ipfs_infopathenabled"];

                //string templateFixed = web.Properties["templateFixed"];
                //if (string.IsNullOrWhiteSpace(templateFixed)) {
                //    Global.Debug = "template.xsn 1";
                //    SPFile orig = web.GetFile("Lists/Aktiviteter/Tillsyn/template.xsn");
                //    if (!orig.Exists) {
                //        Controls.Add(new LiteralControl("Var vänlig öppna tillsynsformuläret i infopath och publicera"));
                //    }
                //    else {
                //        btnFix.Style.Clear();
                //    }
                //}
                //else if (templateFixed == "true") {
                //    Controls.Add(new LiteralControl("Tillsynsformulär utbytt<br />"));
                //    Controls.Add(new LiteralControl("_ipfs_solutionName: " + sn + "<br />" + "_ipfs_infopathenabled: " + ie + "<br /><br />"));
                //    Global.Debug = "template.xsn 2";
                //    SPFile orig = web.GetFile("Lists/Aktiviteter/Tillsyn/template.xsn");
                //    if (orig != null) {
                //        string lf = (string)orig.Properties["ipfs_listform"];
                //        string sh = (string)orig.Properties["ipfs_streamhash"];
                //        Controls.Add(new LiteralControl("template.xsn<br />ipfs_listform: " + lf + "<br />" + "ipfs_streamhash: " + sh + "<br /><br />"));
                //    }
                //    Global.Debug = "template_mod.xsn";
                //    SPFile mod = web.GetFile("Lists/Aktiviteter/Tillsyn/template_mod.xsn");
                //    if (mod != null) {
                //        string lf = (string)mod.Properties["ipfs_listform"];
                //        string sh = (string)mod.Properties["ipfs_streamhash"];
                //        Controls.Add(new LiteralControl("template_mod.xsn<br />" + "ipfs_listform: " + lf + "<br />" + "ipfs_streamhash: " + sh + "<br /><br />"));
                //    }
                //}
                #endregion
            }
            catch (Exception ex) {
                Controls.Add(new LiteralControl("Exception: " + ex.Message + "<br /><br />Stacktrace: " + ex.StackTrace + "<br /><br />Debug: " + Global.Debug));
            }
        }

        //void btnFix_Click(object sender, EventArgs e) {
        //    try {
        //        Global.Debug = "btnFix_Click";
        //        SPWeb web = SPContext.Current.Web;
        //        SPList listAktiviteter = web.Lists.TryGetList("Aktiviteter");
        //        SPFolder folder = listAktiviteter.RootFolder.SubFolders["Tillsyn"];
        //        folder.Properties["_ipfs_solutionName"] = "template_mod.xsn";
        //        folder.Update();

        //        web.Properties["templateFixed"] = "true";
        //        web.Properties.Update();

                
        //    }
        //    catch (Exception ex) {
        //        Controls.Add(new LiteralControl("Exception: " + ex.Message + "<br /><br />Stacktrace: " + ex.StackTrace + "<br /><br />Debug: " + Global.Debug));
        //    }
        //}

    }
}
