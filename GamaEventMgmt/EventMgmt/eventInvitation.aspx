<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventInvitation.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventInvitation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <asp:HiddenField ID="hdfFileName" runat="server" />
    <asp:Label ID="lblEvent" runat="server" Text="Event: "></asp:Label>
    <asp:DropDownList ID="ddlEvent" runat="server" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id">
        <asp:ListItem Value="0" Text="-Select Event-"></asp:ListItem>
    </asp:DropDownList>
    <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="getAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
        <ajaxToolkit:TabPanel HeaderText="Email" runat="server" ID="tbpEmail">
            <ContentTemplate>
                <asp:TextBox ID="tbxEmailBody" runat="server" TextMode="MultiLine" Rows="20" Columns="80"></asp:TextBox>
                <ajaxToolkit:HtmlEditorExtender ID="htmeEmailBody" TargetControlID="tbxEmailBody" EnableSanitization="false" runat="server"></ajaxToolkit:HtmlEditorExtender>

            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel HeaderText="Recipients" runat="server" ActiveTabIndex="0" ID="tbpRecipients">
            <ContentTemplate>
                <asp:FileUpload ID="fupRecipients" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />

                <asp:GridView ID="gvwRecepients" runat="server"></asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        
    </ajaxToolkit:TabContainer>
    
    <asp:Button ID="btnSendMail" runat="server" Text="Send Invitation Email" OnClick="btnSendMail_Click" />
    
</asp:Content>
