using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SimpleAuction.Service;
using SimpleAuction.Service.Resistors;
using SimpleAuction.Core.Domain;

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

                grdHistory.DataSource = _resistorService.GetTopRequests(5);
                grdHistory.DataBind();
            }
        }

    
 

        private ListItem[] GetListItems(IEnumerable<ResistorColor> colors)
        {
            return colors.Select(x => new ListItem { Value = x.Name, Text = x.Name }).ToArray();
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            var request = new ResistorCalculationRequest { ColorBandA = ddlBandA.SelectedValue, ColorBandB = ddlBandB.SelectedValue, ColorBandC = ddlBandC.SelectedValue, ColorBandD = ddlBandD.SelectedValue };
            request.CalculatedValue = _resistorService.GetResistance(request.ColorBandA, request.ColorBandB, request.ColorBandC, request.ColorBandD);
            request.RequestDateUtc = DateTime.UtcNow;
            _resistorService.SaveRequest(request);
            lblResult.Text = request.CalculatedValue.ToString(ResistanceFormat);
            grdHistory.DataSource = _resistorService.GetTopRequests(5);
            grdHistory.DataBind();
        }
    }
}