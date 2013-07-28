<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventFunctions.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventFunctions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <div id="dvSystemMessages" class="success" runat="server" visible="false">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Text="" ></asp:Label>
    </div>
    <div id="dvWarningMessages" class="warning" runat="server" visible="false"><asp:Label ID="lblWarningMessages" runat="server" CssClass="sysInstrMessagesWarning"></asp:Label></div>
    <div id="dvErrorMEssages" class="error" runat="server" visible="false">
        <asp:Label ID="lblInfo" runat="server" Text="" />
    </div>

    <div class="dataLabelDivs"><asp:Label ID="lblEvent" runat="server" Text="Select event to link this function:"></asp:Label></div> &nbsp;
    <div class="dataCaptureDivs"><asp:DropDownList ID="ddlEvents" runat="server" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id"></asp:DropDownList></div>
    <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="getAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
    <br />
            
    <div class="dataLabelDivs"><asp:Label ID="lblEvtFuncName" runat="server" Text="Offer Name:"></asp:Label></div>
    <div class="dataCaptureDivs"><asp:TextBox ID="tbxOfferName" runat="server"></asp:TextBox></div>
    <br />
    <div class="dataLabelDivs"><asp:Label ID="lblOfferDesc" runat="server" Text="Description:"></asp:Label></div>
    <div class="dataCaptureDivs"><asp:TextBox ID="tbxOfferDesc" runat="server"></asp:TextBox></div><br />

    <div class="dataLabelDivs"><asp:Label ID="lblSeatsAvailable" runat="server" Text="Seats Available:"></asp:Label></div>
    <div class="dataCaptureDivs"><asp:TextBox ID="tbxNumSeats" runat="server"></asp:TextBox></div>
    <br />
    
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />


    

</asp:Content>
