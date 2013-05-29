using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UPCOR.TillsynKommun.TillsynWP
{
    [ToolboxItemAttribute(false)]
    public class TillsynWP : WebPart
    {
        Table _tbl;

        protected override void CreateChildControls() {
            //SPContentTypeId id = new SPContentTypeId("0x01005B4D0E77283349FEA58D136970995B96");
            string ctname = "Tillsyn";
            SPContentType tillsyn = SPContext.Current.Web.ContentTypes[ctname];
            _tbl = new Table();
            _tbl.CssClass = "tillsynTable";
            _tbl.CellPadding = 0;
            _tbl.CellSpacing = 0;
            List<JTClientField> fieldList = new List<JTClientField>();
            foreach (SPField field in tillsyn.Fields) {
                fieldList.Add(RenderField(field));
            }
            Controls.Add(_tbl);

            Button btnSave = new Button();
            btnSave.Text = "Spara";
            btnSave.OnClientClick = "";

            //var oTillsyn = oTillsyn || {};
            string json = JsonConvert.SerializeObject(fieldList.ToArray());
            string js = string.Format("oTillsyn = oTillsyn || {{}};{0}", "oTillsyn.fields = " + json);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "orderContext", js, true);
        }

        private JTClientField RenderField(SPField field) {
            JTClientField f = new JTClientField();
            f.Id = field.Id;
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Controls.Add(new LiteralControl(field.Title));
            tr.Controls.Add(td);
            td = new TableCell();
            td.Controls.Add(new LiteralControl(field.Description + "<br />"));
            switch (field.TypeAsString) {
                case "Boolean":
                    CheckBoxList cblBoolean = new CheckBoxList();
                    cblBoolean.Items.Add("Ja");
                    cblBoolean.Items.Add("Nej");
                    td.Controls.Add(cblBoolean);
                    break;
                case "Note":
                    TextBox txtNote = new TextBox();
                    td.Controls.Add(txtNote);
                    break;
                default:
                    break;
            }
            tr.Controls.Add(td);
            _tbl.Rows.Add(tr);
            return f;
        }
    }
}
