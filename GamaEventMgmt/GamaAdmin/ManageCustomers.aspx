<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.ManageCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3.min.js"></script>
    <link type="text/css" href="../Content/themes/base/jquery.ui.base.css" rel="stylesheet" />
    <link type="text/css" href="../Content/themes/base/jquery.ui.all.css" rel="stylesheet" />

    <script type="text/javascript">
        var name = $("#txtName"),
      email = $("#txtEmail"),
      surname = $("#txtSurname"),
      allFields = $([]).add(name).add(email).add(surname),
      tips = $(".validateTips");
        $(document).ready(function () {
            $("#btnAdd").click(function (e) {
                e.preventDefault();
                $("#createForm").dialog({
                    autoOpen: true,
                    height: 350,
                    width: 300,
                    modal: true,
                    buttons: {
                        "Create an account": function() {

                            $.post("GamaAdmin/ManageCustomers/BtnSaveClick", {
                                    name: $("#txtName").val(),
                                    surname: $("#txtSurname").val(),
                                    Email: $("#txtName").val(),
                                    Type: $("#type").val()
                                }, function(data, status) {
                                    alert("Data: " + data + "\nStatus: " + status);
                                });
                        },
                        Cancel: function() {
                            $(this).dialog("close");
                        }
                    },
                    close: function() {
                        //TODO: Add close function here
                    }
                });
            });
            
            $.get("ManageCustomers.aspx/GetAllTypes", function (data, status) {
                var options = $("#type");
                alert(data);
   /*             $.each(data, function() {
                    options.append($("<option />").val(this.Id).text(this.Name));
                });*/
            });


        
        });
        function updateTips(t) {
            tips
              .text(t)
              .addClass("ui-state-highlight");
            setTimeout(function () {
                tips.removeClass("ui-state-highlight", 1500);
            }, 500);
        }

        function checkLength(o, n, min, max) {
            if (o.val().length > max || o.val().length < min) {
                o.addClass("ui-state-error");
                updateTips("Length of " + n + " must be between " +
                  min + " and " + max + ".");
                return false;
            } else {
                return true;
            }
        }

        function checkRegexp(o, regexp, n) {
            if (!(regexp.test(o.val()))) {
                o.addClass("ui-state-error");
                updateTips(n);
                return false;
            } else {
                return true;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="createForm" style="display: none">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                <td>
                    <input type="text" id="txtName" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label></td>
                <td>
                    <input type="text" id="txtSurname" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                <td>
                    <input type="text" id="txtEmail" /></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUserType" runat="server" Text="User Type"></asp:Label></td>
                <td>
                  <%--  <asp:DropDownList ID="ddlUsertype" runat="server" DataSourceID="fillUsertypes" DataTextField="GamaTypeName" DataValueField="Id"></asp:DropDownList>
                    <asp:ObjectDataSource ID="fillUsertypes" runat="server" SelectMethod="GetAllUserTypes" TypeName="GamaEventMgmt.ApplicationClasses.GamaUserAccessor"></asp:ObjectDataSource>--%>
                    <select id="type">
                        <option selected="selected">-- Select One --</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Is Active <input type="checkbox" id="chkActive" title="Is Active" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%--<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
                </td>
            </tr>
        </table>

    </div>
    <button id="btnAdd">Add New Super Customer</button>
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
            <asp:Parameter Name="usertypeId" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="surname" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="isActive" Type="Boolean" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

</asp:Content>
