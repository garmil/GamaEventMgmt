<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.ManageCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr><td>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
            <td>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </td></tr>
    <tr>
        <td>
    <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label></td>
            <td>
    <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
    </td>
    </tr>
        <tr><td>
    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
            <td>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
    </td></tr>
    <tr><td>
    <asp:Label ID="lblUserType" runat="server" Text="User Type"></asp:Label></td>
            <td>
    <asp:DropDownList ID="ddlUsertype" runat="server" DataSourceID="fillUsertypes" DataTextField="GamaTypeName" DataValueField="Id"></asp:DropDownList>
    <asp:ObjectDataSource ID="fillUsertypes" runat="server" SelectMethod="GetAllUserTypes" TypeName="GamaEventMgmt.ApplicationClasses.GamaUser"></asp:ObjectDataSource>
    </td></tr>
    <tr>
        <td>
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Is Active" />
    </td>
    </tr>
    <tr>
        <td colspan="2">
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </td>
    </tr>
    </table>
</asp:Content>
