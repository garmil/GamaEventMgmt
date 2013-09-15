<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbChanges.aspx.cs" Inherits="GamaEventMgmt.GamaAdmin.dbChanges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbxScriptChanges" Rows="8" TextMode="MultiLine" Width="800px" runat="server"></asp:TextBox><br/>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
