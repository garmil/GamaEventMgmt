<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventSetup.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMenu" ContentPlaceHolderID="menu" runat="server">
    <nav id="topnav" class="clear">
    <ul>
      <li><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Default.aspx" runat="server">Home</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink2" NavigateUrl="~/EventMgmt/eventSetup.aspx" runat="server">Event Setup</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink3" NavigateUrl="~/EventMgmt/eventInvitation.aspx" runat="server">Event Invitation</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink4" NavigateUrl="~/EventMgmt/eventFunctions.aspx" runat="server">Event Functions</asp:HyperLink></li>
      
    </ul>
  </nav>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="hypEventInvitation" runat="server" NavigateUrl="~/EventMgmt/eventInvitation.aspx">Event Setup</asp:HyperLink><br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table>
        <tr>
            <td>Edit existing event</td>
            <td><asp:DropDownList ID="ddlEvents" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id">
                <asp:ListItem Value="0" Text="-Select Event-"></asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="getAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEventTitle" runat="server" Text="Enter an Event Title:"></asp:Label>&nbsp;
            <td><asp:TextBox ID="tbxEventTitle" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEventAgent" runat="server" Text="Agent Email:"></asp:Label></td>
            <td><asp:TextBox ID="tbxAgentEmail" runat="server"></asp:TextBox><br /></td>
        </tr>    
    </table> 
    

    <asp:TextBox ID="tbxEvent" TextMode="MultiLine" Rows="25" Columns="80" runat="server" Wrap="False"></asp:TextBox>
    <asp:HtmlEditorExtender ID="htmeEvent" TargetControlID="tbxEvent" runat="server" EnableSanitization="false" DisplaySourceTab="True" OnImageUploadComplete="htmeEvent_ImageUploadComplete" >
        <Toolbar>
            <asp:Undo />
            <asp:Redo />
            <asp:InsertImage />
            <asp:Bold />
            <asp:Italic />
            <asp:Underline />
            <asp:StrikeThrough />
            <asp:Subscript />
            <asp:Superscript />
            <asp:JustifyLeft />
            <asp:JustifyCenter />
            <asp:JustifyRight />
            <asp:JustifyFull />
            <asp:InsertOrderedList />
            <asp:InsertUnorderedList />
            <asp:RemoveFormat />
            <asp:SelectAll />
            <asp:UnSelect />
            <asp:Delete />
            <asp:Cut />
            <asp:Copy />
            <asp:Paste />
            <asp:BackgroundColorSelector />
            <asp:ForeColorSelector />
            <asp:FontNameSelector />
            <asp:FontSizeSelector />
            <asp:Indent />
            <asp:Outdent />
            <asp:InsertHorizontalRule />
            <asp:HorizontalSeparator />
        </Toolbar>
    </asp:HtmlEditorExtender>

    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
    </ContentTemplate>

    </asp:UpdatePanel>
    
    <br />

</asp:Content>
