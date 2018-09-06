<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="ResistorCalculator.aspx.cs" Inherits="SimpleAuction.Web.Forms.ResistorCalculator" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
    select {
        width: 150px;
        padding: 3px;
        border-radius: 5px;
    }
    div.row {
        padding: 5px;
    }
    button {
        width: 100%;
        border-radius: 3px;
    }
</style>

    <h2>Resistance Calculator</h2>
    <div class="row">
        <div class="col-md-5">
            <div class="row">
               <div class="col-md-12">
                       <h4>Please select color combination</h4>
               </div>
            </div>
           <div class="row">
               <div class="col-md-3"><asp:Label ID="Label1" runat="server" Text="Label">Band A</asp:Label></div>
               <div class="col-md-9"> <asp:DropDownList ID="ddlBandA" runat="server"></asp:DropDownList></div>
           </div>
           <div class="row">
               <div class="col-md-3"><asp:Label ID="Label2" runat="server" Text="Label">Band B</asp:Label></div>
               <div class="col-md-9"> <asp:DropDownList ID="ddlBandB" runat="server"></asp:DropDownList></div>
           </div>
           <div class="row">
               <div class="col-md-3"><asp:Label ID="Label3" runat="server" Text="Label">Band C</asp:Label></div>
               <div class="col-md-9"> <asp:DropDownList ID="ddlBandC" runat="server"></asp:DropDownList></div>
           </div>
           <div class="row">
               <div class="col-md-3"><asp:Label ID="Label4" runat="server" Text="Label">Band D</asp:Label></div>
               <div class="col-md-9"> <asp:DropDownList ID="ddlBandD" runat="server"></asp:DropDownList></div>
           </div>
           <div class="row">
               <div class="col-md-12">
                   <asp:Button ID="btnCalculate" CssClass="btn btn-primary" runat="server" OnClick="btnCalculate_Click" Text="Calculate Resistance" /> </div>
           </div>
           <div class="row">
               <div class="col-md-3"><asp:Label ID="Label5" runat="server" Text="Label">Result:</asp:Label></div>
               <div class="col-md-9"> <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label></div>
           </div>
        </div>


        <div class="col-md-7">
            <div class="row">
               <div class="col-md-12">
                   <h4>History</h4>
               </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="grdHistory" AutoGenerateColumns="true" runat="server"></asp:GridView>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
 