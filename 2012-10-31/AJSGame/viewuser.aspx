<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="viewuser.aspx.cs" Inherits="AJSGame.ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div id="title">
        <h2>
            <asp:Label ID="UsernameTitleLabel" runat="server"></asp:Label></h2>
    </div>
    <table width="100%">
        <tr>
            <td width="50%" valign="top">
                <center>
                    <asp:Image ID="AvatarImage" runat="server" />
                </center>
                <b>User Info</b>
                <table width="100%">
                    <tr>
                        <td>Username:
                        </td>
                        <td>
                            <asp:Label ID="UsernameLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Alliance:
                        </td>
                        <td>
                            <asp:HyperLink ID="AllianceHyperLink" runat="server" Text=""></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>Member since:
                        </td>
                        <td>
                            <asp:Label ID="CreatedLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Points:
                        </td>
                        <td>
                            <asp:Label ID="TotalPointsLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Construction:
                        </td>
                        <td>
                            <asp:Label ID="ConstructionPointsLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Offensive
                        </td>
                        <td>
                            <asp:Label ID="OffensivePointsLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Defensive
                        </td>
                        <td>
                            <asp:Label ID="DefensivePointsLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Rank
                        </td>
                        <td>
                            <asp:Label ID="RankLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <b>Villages</b>
                <asp:GridView ID="VillagesGridView" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField HeaderText="Village">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:HyperLink ID="VillageHyperLink" runat="server" Text='<%# String.Format("({0}|{1}) {2}", Eval("x"), Eval("y"), Eval("Name")) %>' NavigateUrl='<%# String.Format("~/viewvillage.aspx?id={0}", Eval("id")) %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Points">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Eval("CP").ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top">
                <b>Profile</b>
                <table width="100%">
                    <tr>
                        <td>Name:
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Location:
                        </td>
                        <td>
                            <asp:Label ID="LocationLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Gender:
                        </td>
                        <td>
                            <asp:Label ID="GenderLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <b>Description</b>
                <br />
                <asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
