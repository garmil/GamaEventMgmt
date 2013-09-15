<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EventAttendees.aspx.cs" Inherits="GamaEventMgmt.Reports.EventAttendees" %>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="dvSystemMessages" class="success" runat="server" visible="false">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Text="" ></asp:Label>
    </div>
    <div id="dvWarningMessages" class="warning" runat="server" visible="false"><asp:Label ID="lblWarningMessages" runat="server" CssClass="sysInstrMessagesWarning"></asp:Label></div>
    <div id="dvErrorMEssages" class="error" runat="server" visible="false">
        <asp:Label ID="lblInfo" runat="server" Text="" />

    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    <table>
        <tr>
            <td>Select existing event:</td>
            <td><asp:DropDownList ID="ddlEvents" runat="server" AppendDataBoundItems="True" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id">
                <asp:ListItem Value="0" Text="-New Event-"></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="GetAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
            
            </td>
            <td><asp:Button ID="btnAttendeeReport" runat="server" Text="Generate Report" /> &nbsp; <asp:Button ID="btnExportCsv" runat="server" Text="Export" OnClick="btnExportCsv_Click" /></td>
            <td>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessing" runat="server" Text="Processing..."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
            </td>
            
        </tr>

    </table>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
        <asp:GridView ID="gvwAttendees" runat="server"  AllowPaging="True" AllowSorting="True" DataSourceID="odsEventAttendees"></asp:GridView>
    </asp:Panel>
    <asp:ObjectDataSource ID="odsEventAttendees" runat="server" SelectMethod="getEventAttendees" TypeName="Gama.Attendee" OnSelected="odsEventAttendees_Selected" OnSelecting="odsEventAttendees_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlEvents" Name="evt_id" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    
</asp:Content>
