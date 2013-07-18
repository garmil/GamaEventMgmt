<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="superRegistrantRegister.aspx.cs" Inherits="GamaEventMgmt.Registration.superRegistrantRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link rel="stylesheet" href="../Stylesheets/layout.css" type="text/css" />
    <link rel="stylesheet" href="../Stylesheets/styles.css" type="text/css" />

    <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "superRegistrantRegister.aspx";
        }
        function onSuccess() {
            setTimeout(okay, 2000);
        }
        function onError() {
            setTimeout(getbacktostepone, 2000);
        }
        function okay() {
            window.parent.document.getElementById('btnOkay').click();
        }
        function cancel() {
            window.parent.document.getElementById('btnCancel').click();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="popup_Container" style="ModalPopupBG">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Register
            </div>
            <div class="TitlebarRight" onclick="cancel();">
            </div>
        </div>
        <div class="popup_Body">
            <table border="1" bordercolor="black" cellspacing="0" >
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="tbxSuperRegName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Surname:</td>
                    <td><asp:TextBox ID="tbxSuperRegSurName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td><asp:TextBox ID="tbxConfPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email Address:</td>
                    <td><asp:TextBox ID="tbxSuperRegEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Confirm Email Address:</td>
                    <td><asp:TextBox ID="tbxConfEmailAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /> </td>
                    
                </tr>
            </table>
        </div>
        <div class="popup_Buttons">
            <input id="btnOkay" type="button" value="Done" runat="server" />
            <input id="btnCancel" onclick="cancel();" type="button" value="Cancel" />
        </div>
    </div>
    </form>
</body>
</html>
