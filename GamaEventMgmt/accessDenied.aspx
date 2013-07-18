<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="accessDenied.aspx.cs" Inherits="GamaEventMgmt.accessDenied" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dvErrorMEssages" class="error" runat="server" visible="true">
        
        <table >
            <tr>
                <td align="center"><asp:Label ID="lblInfo" runat="server" Text="Access Denied. You have insufficient rights to access this page." Font-Bold="True" Font-Size="Larger" /></td>
            </tr>
            <tr>
                <td align="center"><asp:Image ID="imgAccessDenied" runat="server" AlternateText="Access Denied" ImageUrl="~/images/accessDenied.png" ImageAlign="Middle" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
