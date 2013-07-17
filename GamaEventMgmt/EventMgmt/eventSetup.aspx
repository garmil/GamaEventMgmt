<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventSetup.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="hypEventInvitation" runat="server" NavigateUrl="~/EventMgmt/eventInvitation.aspx">Event Invitation</asp:HyperLink><br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table>
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
