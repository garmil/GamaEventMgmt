<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventSetup.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.EventSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Obout.Ajax.UI" namespace="Obout.Ajax.UI.HTMLEditor" tagprefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMenu" ContentPlaceHolderID="menu" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="hypEventInvitation" runat="server" NavigateUrl="~/EventMgmt/eventInvitation.aspx">Event Invitations</asp:HyperLink> |
    <asp:HyperLink ID="hypEventAdmin" runat="server" NavigateUrl="eventAdmin.aspx">Event Administration</asp:HyperLink>
    <br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="info">
            <asp:Label ID="lblInfoMsg" runat="server" Text="Select an event to edit or '-New Event-' to save an event"></asp:Label>
        </div>
            <div id="dvSystemMessages" class="success" runat="server" visible="false">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Text="" ></asp:Label>
    </div>
    <div id="dvWarningMessages" class="warning" runat="server" visible="false"><asp:Label ID="lblWarningMessages" runat="server" CssClass="sysInstrMessagesWarning"></asp:Label></div>
    <div id="dvErrorMEssages" class="error" runat="server" visible="false">
        <asp:Label ID="lblInfo" runat="server" Text="" />
    </div>
    
    <table>
        <tr>
            <td>Select existing event for editing:</td>
            <td><asp:DropDownList ID="ddlEvents" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DdlEventsSelectedIndexChanged" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id">
                <asp:ListItem Value="0" Text="-New Event-"></asp:ListItem>
                </asp:DropDownList>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                <ProgressTemplate>
                    <asp:Image ID="imgProgress" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessingDDL" runat="server" Text="Processing..."></asp:Label>
                 </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="GetAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
                <asp:HyperLink ID="hypViewEvent" runat="server" Target="_blank">View Event</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblEventTitle" runat="server" Text="Enter an Event Title:"></asp:Label>&nbsp;
            <td><asp:TextBox ID="tbxEventTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEventTitle" ControlToValidate="tbxEventTitle" Display="None" runat="server" ErrorMessage="Please enter Event Title"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvEventTitle" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblNumRegs" runat="server" Text="Number of Registrants: "></asp:Label></td>
            
            <td><asp:TextBox ID="tbxNumRegistrants" runat="server"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteNumReg" TargetControlID="tbxNumRegistrants" FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
            </td>

        </tr>
        <tr>
            <td>Date From:</td>
            <td><asp:TextBox ID="tbxEventDateFrom" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="cleDateFrom" TargetControlID="tbxEventDateFrom" runat="server" Format="yyyy/MM/dd"></asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="rvfDateFrom" ControlToValidate="tbxEventDateFrom" runat="server" ErrorMessage="Please enter Date From" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="rvfDateFrom" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td>Date To:</td>
            <td><asp:TextBox ID="tbxDateEventTo" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="cleDateTo" TargetControlID="tbxDateEventTo" runat="server" Format="yyyy/MM/dd"></asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvDateTo" ControlToValidate="tbxDateEventTo" runat="server" ErrorMessage="Please enter Date To" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="rfvDateTo" runat="server" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png" Enabled="True"></asp:ValidatorCalloutExtender>
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="lblEventAgent" runat="server" Text="Agent Email:"></asp:Label></td>
            <td><asp:TextBox ID="tbxAgentEmail" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAgentEmail" runat="server" ControlToValidate="tbxAgentEmail" Display="None" ErrorMessage="Please enter an Agent's Email"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvAgentEmail" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></asp:ValidatorCalloutExtender>

                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="tbxAgentEmail" WatermarkText="Enter agents' emails. One per line" runat="server"></asp:TextBoxWatermarkExtender>
                <br /></td>
        </tr>    
    </table> 
            

<%--    <asp:TextBox ID="tbxEvent" TextMode="MultiLine" Rows="25" Columns="80" runat="server" Wrap="False"></asp:TextBox>
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
    </asp:HtmlEditorExtender>--%>
    
    <asp:Label ID="lblEventHeader" runat="server" Text="Event Header"></asp:Label>
    <obout:Editor ID="tbxEventHeader" runat="server" Height="300px" Width="100%"></obout:Editor>
    <br/>            
    <asp:Label ID="lblEvent" runat="server" Text="Event Body"></asp:Label>
    <obout:Editor ID="tbxEvent2" runat="server" Height="300px" Width="100%">
    </obout:Editor>
            
            


    <br />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessing" runat="server" Text="Processing..."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSaveClick" />&nbsp;
    <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" OnClick="BtnDeleteClick" />
    <asp:Button ID="btnUpdate" runat="server" OnClick="BtnUpdateClick" Text="Update" Visible="false" />
    </ContentTemplate>

    </asp:UpdatePanel>
    
    <br />

</asp:Content>
