<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="registrationCompleted.aspx.cs" Inherits="GamaEventMgmt.Registration.registrationCompleted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dvSystemMessages" class="success" runat="server" visible="True">
        &nbsp;<asp:Label ID="lblDisplayMessages" runat="server" Font-Size="Large" Text="Thank you for registering to this event. Our agents have been notified and will contact you shortly" ></asp:Label>
    </div>
    
        <table align="center">
            <tr>
                <td align="center"><asp:Image ID="imgRegSuccess" runat="server" AlternateText="Registration Completed" ImageUrl="../images/Travel-Airplane-icon.png" ImageAlign="Middle" /></td>
            </tr>
        </table>
</asp:Content>
