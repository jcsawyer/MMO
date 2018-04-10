<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="mail.aspx.cs" Inherits="AJSGame.Mail" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <asp:PlaceHolder ID="ControlPlaceHolder" runat="server"></asp:PlaceHolder>
    <a href="mail.aspx?mode=inbox">Inbox</a>
    <a href="mail.aspx?mode=outbox">Outbox</a>
    <a href="mail.aspx?mode=compose">Compose</a>
</asp:Content>
