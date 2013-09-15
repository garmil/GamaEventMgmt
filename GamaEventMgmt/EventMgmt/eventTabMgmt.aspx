<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventTabMgmt.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventTabMgmt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <nav id="topnav" class="clear">
    <ul>
      <li><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Default.aspx" runat="server">Home</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink5" NavigateUrl="~/GamaAdmin/manageUsers.aspx" runat="server">Users</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink2" NavigateUrl="~/EventMgmt/eventSetup.aspx" runat="server">Event Setup</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink3" NavigateUrl="~/EventMgmt/eventInvitation.aspx" runat="server">Event Invitation</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink4" NavigateUrl="~/EventMgmt/eventTabMgmt.aspx" runat="server">Tab Management</asp:HyperLink></li>
      <li><asp:HyperLink ID="hypReports" runat="server" NavigateUrl="~/Reports/default.aspx">Reports</asp:HyperLink></li>
      
    </ul>
  </nav>
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessing" runat="server" Text="Processing..."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="dataLabelDivs"><asp:Label ID="lblEvent" runat="server" Text="Select Event:"></asp:Label></div> &nbsp;
    <div class="dataCaptureDivs">
        <asp:DropDownList ID="ddlEvents" runat="server" AutoPostBack="true" DataSourceID="odsEvents" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged" AppendDataBoundItems="true" DataTextField="evt_Name" DataValueField="evt_id">
            <asp:ListItem Value="0" Text="-Select Event-"></asp:ListItem>
        </asp:DropDownList></div>
    <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="GetAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
    <br />
    
    <div class="checkBoxLists">
        <asp:CheckBoxList ID="cblTabs" runat="server" DataSourceID="odsTabNames" DataTextField="tbn_Name" DataValueField="tbn_id" OnDataBound="cblTabs_DataBound"></asp:CheckBoxList>
        <asp:ObjectDataSource ID="odsTabNames" runat="server" SelectMethod="getAllTabNames" TypeName="Gama.TabFormMgmt"></asp:ObjectDataSource>
    </div><br />
    <div class="dataCaptureDivs">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>

</asp:Content>
