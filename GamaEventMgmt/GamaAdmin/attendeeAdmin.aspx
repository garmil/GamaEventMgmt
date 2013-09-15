<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="attendeeAdmin.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.attendeeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMenu" ContentPlaceHolderID="menu" runat="server">
    <nav id="topnav" class="clear">
    <ul>
      <li><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Default.aspx" runat="server">Home</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink5" NavigateUrl="manageUsers.aspx" runat="server">Users</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink2" NavigateUrl="~/EventMgmt/eventSetup.aspx" runat="server">Event Setup</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink3" NavigateUrl="~/EventMgmt/eventInvitation.aspx" runat="server">Event Invitation</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink4" NavigateUrl="~/EventMgmt/eventTabMgmt.aspx" runat="server">Tab Management</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink6" NavigateUrl="attendeeAdmin.aspx" runat="server">Registrant Admin</asp:HyperLink></li>
      
    </ul>
  </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Select registrant:</td>
            <td>
                <asp:DropDownList ID="ddlRegistrants" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataValueField="atn_id" DataTextField="attendee" OnSelectedIndexChanged="ddlRegistrants_SelectedIndexChanged" >
                <asp:ListItem Value="0" Text="-Select Registrant"></asp:ListItem>  
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsRegistrants" runat="server" SelectMethod="getAllAttendees" TypeName="Gama.Attendee">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="active" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                
            </td>
        </tr>
    </table>
    
    <asp:GridView ID="gvwAttendeeEvents" runat="server">
        
    </asp:GridView>


</asp:Content>
