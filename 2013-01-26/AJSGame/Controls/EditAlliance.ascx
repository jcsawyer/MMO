<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAlliance.ascx.cs" Inherits="AJSGame.Controls.EditAlliance" %>
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
            <asp:GridView ID="MembersGridView" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal" OnRowDataBound="MembersGridView_RowDataBound" DataKeyNames="ID">
                <Columns>
                    <asp:TemplateField HeaderText="Username">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:HyperLink ID="UsernameHyperLink" runat="server" Text='<%# Eval("Username") %>' NavigateUrl='<%# String.Format("~/viewuser.aspx?id={0}", Eval("ID")) %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Role">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="RoleLabel" runat="server" Text='<%# AJSGame.Core.Functions.LabelsRole(Eval("Role").ToString()) %>' Visible='<%# AJSGame.Game.Session.User.Role == "leader" ? false : true %>'></asp:Label>
                            <asp:DropDownList ID="RoleDropDownList" runat="server" Visible='<%# AJSGame.Game.Session.User.Role == "leader" ? true : false %>' AutoPostBack="true" OnSelectedIndexChanged="RoleDropDownList_SelectedIndexChanged1">
                                <asp:ListItem Text="Leader" Value="leader" />
                                <asp:ListItem Text="Officer" Value="officer" />
                                <asp:ListItem Text="Diplomat" Value="diplomat" />
                                <asp:ListItem Text="Member" Value="member" />
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Button ID="RemoveButton" runat="server" Text="Remove" Visible='<%# AJSGame.Game.Session.User.Role == "leader" ? true : false %>' OnClick="RemoveButton_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        <td valign="top">
            <b>Description</b>
            <br />
            <asp:TextBox ID="DescriptionTextbox" runat="server" Text="" Width="100%" TextMode="MultiLine" Height="400px"></asp:TextBox>
            <br />
            <asp:Button ID="UpdateAlliance" runat="server" Text="Save" OnClick="UpdateAlliance_Click" />
            <asp:Button ID="DisbandAlliance" runat="server" Text="Disband Alliance" Visible='<%# AJSGame.Game.Session.User.Role == "leader" ? true : false %>' OnClick="DisbandAlliance_Click" />
        </td>
    </tr>
</table>
