<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="eventAdmin.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventAdmin" %>
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
    

    
    <table>
        <tr>
            <td><asp:Label ID="lblDateFrom" runat="server" Text="Start Date From:"></asp:Label></td>
            <td><asp:TextBox ID="tbxDateFrom" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="cleDateFrom" runat="server" DefaultView="Months" TargetControlID="tbxDateFrom" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
            </td>
            <td><asp:Label ID="lblDateTo" runat="server" Text="Start Date To:"></asp:Label></td>
            <td><asp:TextBox ID="tbxDateTo" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="cleDateTo" DefaultView="Months" runat="server" TargetControlID="tbxDateTo" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
            <td><asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" /></td>
            
        </tr>
    </table>
    
    <asp:GridView ID="gvwEvents" runat="server" AutoGenerateColumns="False"  DataKeyNames="evt_GUID" 
    GridLines="None"  
    AllowPaging="True"  
    CssClass="mGrid"  
    PagerStyle-CssClass="pgr"  
    AlternatingRowStyle-CssClass="alt" AllowSorting="True" DataSourceID="odsEvents" OnRowCommand="gvwEvents_RowCommand">
       <Columns>
           <asp:BoundField HeaderText="Event" DataField="Event Name" SortExpression="Event Name"/>
           <asp:BoundField HeaderText="Event Start" DataField="Event Start" SortExpression="Event Start"/>
           <asp:BoundField HeaderText="Event End" DataField="Event End" SortExpression="Event End"/>
           <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtSelect" runat="server" CausesValidation="false" 
                    CommandName="SelectRecord" Text="View Event" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtViewStats" runat="server" CausesValidation="false" 
                    CommandName="viewStats" Text="View Statistics" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtViewAttendants" runat="server" CausesValidation="false" 
                    CommandName="viewAttendants" Text="View Attendants" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
       </Columns> 
        
    </asp:GridView>
    <asp:ObjectDataSource ID="odsEvents" runat="server" OnSelecting="odsEvents_Selecting" SelectMethod="getEventsByDateRange" TypeName="Gama.Event">
        <SelectParameters>
            <asp:Parameter Name="dateFrom" Type="String" />
            <asp:Parameter Name="dateTo" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
