<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="viewvillage.aspx.cs" Inherits="AJSGame.ViewVillage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div id="title">
        <h2>
            <asp:Label ID="VillageNameTitleLabel" runat="server" Text=""></asp:Label></h2>
    </div>
    <b>Village Info</b>
    <table>
        <tr>
            <td>Village Name:
            </td>
            <td>
                <asp:Label ID="VillageNameLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Coordinates:
            </td>
            <td>
                <asp:Label ID="CoordinatesLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Points:
            </td>
            <td>
                <asp:Label ID="PointsLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Owner:
            </td>
            <td>
                <asp:HyperLink ID="OwnerHyperLink" runat="server"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>Alliance:
            </td>
            <td>
                <asp:HyperLink ID="AllianceHyperLink" runat="server"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="MapButton" runat="server" Text="Center Map" OnClick="MapButton_Click" CssClass="button" />
                <asp:Button ID="AttackButton" runat="server" Text="Send Troops" OnClick="AttackButton_Click" CssClass="button" />
            </td>
        </tr>
    </table>
</asp:Content>
