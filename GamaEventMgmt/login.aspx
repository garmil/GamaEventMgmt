<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GamaEventMgmt.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Stylesheets/layout.css" type="text/css" />
    <link rel="stylesheet" href="../Stylesheets/styles.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center" width="25%">
        <tr>
            <td>Email Address:</td>
            <td><asp:TextBox ID="tbxEmailAddress" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:HyperLink ID="hypForgotPassword" runat="server" NavigateUrl="~/forgotPassword.aspx">Forgot Password</asp:HyperLink></td>
        </tr>
    </table>

</asp:Content>
