using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleAuction.Service;
using SimpleAuction.Service.Resistors;

namespace SimpleAuction.Web.Forms
{
    public partial class ResistorCalculator : System.Web.UI.Page
    {
        private ResistorService _resistorService = new ResistorService();
        const string ResistanceFormat = "#,##0.####";

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                ddlBandA.Items.AddRange(GetListItems(_resistorService.GetSignificantColors()));
                ddlBandB.Items.AddRange(GetListItems(_resistorService.GetSignificantColors()));
                ddlBandC.Items.AddRange(GetListItems(_resistorService.GetMultiplierColors()));
                ddlBandD.Items.AddRange(GetListItems(_resistorService.GetToleranceColors()));

                lblResult.Text = "";
            }
        }

    
 

        private ListItem[] GetListItems(IEnumerable<ResistorMediator.Color> colors)
        {
            return colors.Select(x => new ListItem { Value = x.Name, Text = x.Name }).ToArray();
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            lblResult.Text = _resistorService.GetResistance(ddlBandA.SelectedValue, ddlBandB.SelectedValue, ddlBandC.SelectedValue, ddlBandD.SelectedValue).ToString(ResistanceFormat);
        }
    }
}