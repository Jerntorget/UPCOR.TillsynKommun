<%@ Assembly Name="UPCOR.TillsynKommun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f66bbd75f013e009" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRights.aspx.cs" Inherits="UPCOR.TillsynKommun.AddRights" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<style type="text/css">
    .lblResult {
        font-style: italic;
        color: #0a0;
    }
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
Den här sidan används för att ge försäljningstället rättigheter att ändra adressuppgifter, ägare samt att se sina uppgifter i "Mitt försäljningsställe"-webbdelen<br />
<br />
<asp:Panel ID="pnlCurrentRights" runat="server" />
<br />
<asp:Label ID="lblResult" CssClass="lblResult" runat="server" /><br />
<br />
<asp:Button ID="btnGive" runat="server" Text="Ge rättigheter" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Ge rättigheter
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Ge rättigheter
</asp:Content>
