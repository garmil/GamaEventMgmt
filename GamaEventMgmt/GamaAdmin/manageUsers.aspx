<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="manageUsers.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.manageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
    <nav id="topnav" class="clear">
    <ul>
    <li><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Default.aspx" runat="server">Home</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink5" NavigateUrl="manageUsers.aspx" runat="server">Users</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink2" NavigateUrl="~/EventMgmt/eventSetup.aspx" runat="server">Event Setup</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink3" NavigateUrl="~/EventMgmt/eventInvitation.aspx" runat="server">Event Invitation</asp:HyperLink></li>
      <li><asp:HyperLink ID="HyperLink4" NavigateUrl="~/EventMgmt/eventTabMgmt.aspx" runat="server">Tab Management</asp:HyperLink></li>
      <li><asp:HyperLink ID="hypReports" runat="server" NavigateUrl="~/Reports/default.aspx">Reports</asp:HyperLink></li>
    </ul>
   </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    
     <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ajax-busy.gif" /><asp:Label ID="lblProcessing" runat="server" Text="Processing..."></asp:Label>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="dvSystemMessages" class="success" runat="server" visible="false">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Text="" ></asp:Label>
    </div>
    <div id="dvWarningMessages" class="warning" runat="server" visible="false"><asp:Label ID="lblWarningMessages" runat="server" CssClass="sysInstrMessagesWarning"></asp:Label></div>
    <div id="dvErrorMEssages" class="error" runat="server" visible="false">
        <asp:Label ID="lblInfo" runat="server" Text="" />

    </div>

    <asp:GridView ID="gvwUsers" runat="server" ShowFooter="True" AutoGenerateColumns="False" DataKeyNames="usr_id,ust_id" OnRowCommand="gvwUsers_RowCommand" OnRowDataBound="gvwUsers_RowDataBound" OnRowCancelingEdit="gvwUsers_RowCancelingEdit" OnRowDeleting="gvwUsers_RowDeleting" OnRowEditing="gvwUsers_RowEditing" OnRowUpdating="gvwUsers_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="Name" SortExpression="usr_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditName" runat="server" Text='<%# Bind("usr_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewName" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("usr_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name" SortExpression="usr_Surname">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditSurname" runat="server" Text='<%# Bind("usr_Surname") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewSurname" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSurname" runat="server" Text='<%# Bind("usr_Surname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="usr_Email">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditEmail" runat="server" Text='<%# Bind("usr_Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewEmail" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("usr_Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Type" SortExpression="ust_id">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlEditUserType" runat="server" AppendDataBoundItems="True" DataTextField="ust_UserType" DataValueField="ust_id">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlNewUserType" runat="server" AppendDataBoundItems="True" DataTextField="ust_UserType" DataValueField="ust_id">
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUserType" runat="server" Text='<%# Bind("ust_UserType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password" SortExpression="usr_Password">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxEditPassword" runat="server" Text='<%# Bind("usr_Password") %>' TextMode="Password"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="tbxEditPassword" WatermarkText="Password" runat="server"></ajaxToolkit:TextBoxWatermarkExtender>
                    <br/>
                    <asp:TextBox ID="tbxEditConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="tbxEditConfPassword" WatermarkText="Confirm Password" runat="server"></ajaxToolkit:TextBoxWatermarkExtender>
                    <asp:CompareValidator ID="cmvEditPassword" runat="server" ErrorMessage="Passwwords do not match" Display="None" ControlToCompare="tbxEditPassword" ControlToValidate="tbxEditConfPassword"></asp:CompareValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="vceConfEditPassword" TargetControlID="cmvEditPassword" runat="server"  CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></ajaxToolkit:ValidatorCalloutExtender>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="tbxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="tbxNewPassword" WatermarkText="Password" runat="server"></ajaxToolkit:TextBoxWatermarkExtender>
                    <br/>
                    <asp:TextBox ID="tbxNewConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" WatermarkText="Confirm Password" TargetControlID="tbxNewPassword" runat="server"></ajaxToolkit:TextBoxWatermarkExtender>
                    <asp:CompareValidator ID="cmvNewPassword" runat="server" ErrorMessage="Passwwords do not match" Display="None" ControlToCompare="tbxNewPassword" ControlToValidate="tbxNewConfPassword"></asp:CompareValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="vceConfEditPassword" TargetControlID="cmvNewPassword" runat="server"  CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></ajaxToolkit:ValidatorCalloutExtender>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("usr_Password") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" SortExpression="usr_Active">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkEditActive" runat="server" Checked='<%#Eval("usr_Active").ToString()=="1"?true:false %>'/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:CheckBox ID="chkNewActive" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblActive" runat="server" Text='<%#Eval("usr_Active").ToString()=="True"?"Active":"Inactive" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Verified" SortExpression="usr_Verified">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkEditVerified" runat="server" Checked='<%#Eval("usr_Verified").ToString()=="1"?true:false %>'/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:CheckBox ID="chkNewVerified" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblVerified" runat="server" Text='<%#Eval("usr_Verified").ToString()=="1"?"Verified":"Not Verified" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="lbtAddNew" runat="server" CommandName="AddNew">Add New</asp:LinkButton>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
        
    </asp:GridView>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
