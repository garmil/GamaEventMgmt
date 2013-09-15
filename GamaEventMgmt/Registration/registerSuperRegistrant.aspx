<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="registerSuperRegistrant.aspx.cs" Inherits="GamaEventMgmt.Registration.registerSuperRegistrant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

    <table >
        <tr>
            <td>Name:</td>
            <td><asp:TextBox ID="tbxSuperRegName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name:</td>
            <td><asp:TextBox ID="tbxSuperRegSurName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Confirm Password:</td>
            <td><asp:TextBox ID="tbxConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="cmvpassword" runat="server" Display="None" ErrorMessage="Passwords do not match" ControlToCompare="tbxPassword" ControlToValidate="tbxConfPassword"></asp:CompareValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" EnableViewState="false" TargetControlID="cmvpassword" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></ajaxToolkit:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td>Email Address:</td>
            <td><asp:TextBox ID="tbxSuperRegEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Confirm Email Address:</td>
            <td><asp:TextBox ID="tbxConfEmailAddress" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ErrorMessage="Email does not match" ControlToCompare="tbxSuperRegEmail" ControlToValidate="tbxConfEmailAddress"></asp:CompareValidator>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" EnableViewState="false" TargetControlID="cmvpassword" CssClass="customCalloutStyle" WarningIconImageUrl="~/images/warning.png" CloseImageUrl="~/images/close.png"></ajaxToolkit:ValidatorCalloutExtender>

            </td>
        </tr>
        <tr>
            <td align="center"><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /> </td>
            <td><asp:Button ID="btnCancel" runat="server" Text="Cancel" /></td>
                    
        </tr>
    </table>
</asp:Content>
