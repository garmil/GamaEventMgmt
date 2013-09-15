<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="eventView.aspx.cs" Inherits="GamaEventMgmt.EventMgmt.eventView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:HyperLink ID="hypRegisterFromEvtView" runat="server">Register for this event</asp:HyperLink><br/>
    <asp:Literal ID="ltrHTML" runat="server"></asp:Literal>
</asp:Content>
