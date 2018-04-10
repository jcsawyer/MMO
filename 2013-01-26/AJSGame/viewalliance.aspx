<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="viewalliance.aspx.cs" Inherits="AJSGame.ViewAlliance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div id="title">
        <h2>
            <asp:Label ID="AllianceTitleLabel" runat="server"></asp:Label></h2>
    </div>
    <table width="100%">
        <tr>
            <td width="50%" valign="top">
                <b>Alliance Info</b>
                <table width="100%">
                    <tr>
                        <td>Name:
                        </td>
                        <td>
                            <asp:Label ID="AllianceNameLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Tag:
                        </td>
                        <td>
                            <asp:Label ID="AllianceTagLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Founded:
                        </td>
                        <td>
                            <asp:Label ID="FoundedLabel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Members:
                        </td>
                        <td>
                            <asp:Label ID="MemberCountLabel" runat="server" Text=""></asp:Label></td>
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
                <b>Members</b>
                <asp:GridView ID="MembersGridView" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField HeaderText="Username">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:HyperLink ID="UsernameHyperLink" runat="server" Text='<%# Eval("Username") %>' NavigateUrl='<%# String.Format("~/viewuser.aspx?id={0}", Eval("ID")) %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Villages">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Eval("Villages").ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Con.">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Eval("CP").ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Off.">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Eval("AP").ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Def.">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Eval("DP").ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top">
                <b>Description</b>
                <br />
                <asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
