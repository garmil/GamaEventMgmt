<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="evtLimitedOffers.aspx.cs" Inherits="GamaEventMgmt.EventFunctions.evtLimitedOffers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> &nbsp;
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessing" runat="server" Text="Processing..."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        
    <table>
        <tr>
        <td><asp:Label ID="lblEvent" runat="server" Text="Event:"></asp:Label></td>
        <td><asp:DropDownList ID="ddlEvent" runat="server" AppendDataBoundItems="true" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id">
        <asp:ListItem Value="0" Text="-Select Event"></asp:ListItem>
            </asp:DropDownList>
        <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="GetAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
        </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEvtLimitedOffer" runat="server" Text="Event Limited Offer Name"></asp:Label></td>
            <td><asp:TextBox ID="tbxEvtLimitedOffer" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEvtLimitedOfferDesc" runat="server" Text="Limit Offer Desc:"></asp:Label></td>
            <td><asp:TextBox ID="tbxEvtLimOfferDesc" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblNumSeats" runat="server" Text="Number of seats available:"></asp:Label></td>
            <td><asp:TextBox ID="tbxNumSeats" runat="server"></asp:TextBox></td>
        </tr>
    <tr>
        <td colspan="2">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />  
        </td>
    </tr>
    </table>
    <asp:Label ID="lblSystemMessage" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
