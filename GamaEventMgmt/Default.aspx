<%@ Page Title="" Language="C#" MasterPageFile="~/Gama.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GamaEventMgmt.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

    <asp:HyperLink ID="hypEventSetup" runat="server" NavigateUrl="~/EventMgmt/eventSetup.aspx">Even Setup</asp:HyperLink>
    <asp:HyperLink ID="hypRegisterAttendee" runat="server" NavigateUrl="~/Registration/Register.aspx">Register</asp:HyperLink>
    <asp:HyperLink ID="hypEventFunction" runat="server" NavigateUrl="~/EventFunctions/evtLimitedOffers.aspx">Event Functions</asp:HyperLink>
    <asp:HyperLink ID="hypAdmin" runat="server" NavigateUrl="~/GamaAdmin/ManageCustomers.aspx">Gama Admin</asp:HyperLink>

</asp:Content>
