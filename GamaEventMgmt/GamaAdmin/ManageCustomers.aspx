<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.ManageCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3.min.js"></script>
    <link type="text/css" href="../Content/themes/base/jquery.ui.base.css" rel="stylesheet"/>
    <link type="text/css" href="../Content/themes/base/jquery.ui.all.css" rel="stylesheet" />
    
    <script type="text/javascript">
        $("#createForm").dialog(false);
        $(document).ready(function () {
            $("#btnAdd").click(function (e) {
                e.preventDefault();
                $("#createForm").dialog(false);
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="createForm" >
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
    <asp:ObjectDataSource ID="fillUsertypes" runat="server" SelectMethod="GetAllUserTypes" TypeName="GamaEventMgmt.ApplicationClasses.GamaUserAccessor"></asp:ObjectDataSource>
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

    </div>
    <button  id="btnAdd">Add New Super Customer</button>
    <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" DataSourceID="Gamauserdatasource" Width="771px">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="UsertypeId" HeaderText="User type" SortExpression="UsertypeId" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="Gamauserdatasource" runat="server" SelectMethod="GetAllUsers" TypeName="GamaEventMgmt.ApplicationClasses.GamaUserAccessor" UpdateMethod="UpdateGamaUser">
        <UpdateParameters>
            <asp:Parameter Name="usertypeId" Type="Int32"  />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="surname" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="isActive" Type="Boolean" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

</asp:Content>
