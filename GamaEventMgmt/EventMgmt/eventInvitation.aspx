<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventInvitation.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventInvitation" %>
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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <asp:HiddenField ID="hdfFileName" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="info">
        <asp:Label ID="lblInfo" runat="server" Text="Create your email, then upload recipients"></asp:Label>
    </div>
    <div id="dvSystemMessages" class="success" runat="server" visible="false">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Text="" ></asp:Label>
    </div>
    <div id="dvWarningMessages" class="warning" runat="server" visible="false"><asp:Label ID="lblWarningMessages" runat="server" CssClass="sysInstrMessagesWarning"></asp:Label></div>
    <div id="dvErrorMEssages" class="error" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server" Text="" />
    </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    

    <asp:Label ID="lblEvent" runat="server" Text="Event: "></asp:Label>
    <asp:DropDownList ID="ddlEvent" runat="server" DataSourceID="odsEvents" DataTextField="evt_Name" DataValueField="evt_id">
        <asp:ListItem Value="0" Text="-Select Event-"></asp:ListItem>
    </asp:DropDownList>
    <asp:ObjectDataSource ID="odsEvents" runat="server" SelectMethod="GetAllEvents" TypeName="Gama.Event"></asp:ObjectDataSource>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel HeaderText="Email" runat="server" ID="tbpEmail">
            <ContentTemplate>
                <asp:TextBox ID="tbxEmailBody" runat="server" TextMode="MultiLine" Rows="20" Columns="80"></asp:TextBox>
                <ajaxToolkit:HtmlEditorExtender ID="htmeEmailBody" TargetControlID="tbxEmailBody" EnableSanitization="false" runat="server"></ajaxToolkit:HtmlEditorExtender>

            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel HeaderText="Recipients" runat="server" ID="tbpRecipients">
            <ContentTemplate>
                <asp:FileUpload ID="fupRecipients" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /><br/>
                <asp:TextBox ID="tbxRecipients" runat="server" TextMode="MultiLine" Rows="8" Columns="50"></asp:TextBox>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="tbxRecipients" WatermarkText="Enter email addresses. One email per line" runat="server"></ajaxToolkit:TextBoxWatermarkExtender>
                <asp:Button ID="btnSendMail" runat="server" Text="Send Invitation Email" OnClick="btnSendMail_Click"  />
                
                

                <asp:GridView ID="gvwRecepients" runat="server" ></asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        
    </ajaxToolkit:TabContainer>
    
    
    
</asp:Content>
