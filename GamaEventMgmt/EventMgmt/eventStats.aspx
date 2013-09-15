<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventStats.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventStats" %>
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
    
    <a href="#" onclick="window.history.go(-1); return false;">Back</a>

    <asp:GridView ID="gvwEventStats" runat="server" GridLines="None" width="40%"  
    CssClass="mGrid"  
    PagerStyle-CssClass="pgr"  
    AlternatingRowStyle-CssClass="alt" DataSourceID="odsEventStats">
        
    </asp:GridView>
    <asp:ObjectDataSource ID="odsEventStats" runat="server"  SelectMethod="getEventAttendantStats" TypeName="Gama.Event">
        <SelectParameters>
            <asp:QueryStringParameter Name="evtId" QueryStringField="evtId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
