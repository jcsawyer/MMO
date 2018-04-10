<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="topusers.aspx.cs" Inherits="AJSGame.TopUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div id="title">
        <h2>Top Users</h2>
    </div>
    <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" DataKeyNames="ID" AllowPaging="true" PageSize="1" OnPageIndexChanging="UsersGridView_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="RankLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:HyperLink ID="AllianceHyperLink" runat="server" Text='<%# (int)Eval("Alliance") == 0 ? "" : String.Format("[{0}]", AJSGame.Objects.Alliance.GetAlliance((int)Eval("Alliance")).Tag) %>' NavigateUrl='<%# String.Format("~/viewalliance.aspx?id={0}", Eval("Alliance")) %>' />
                    <asp:HyperLink ID="TitleHyperLink" runat="server" Text='<%# Eval("Username") %>' NavigateUrl='<%# String.Format("~/viewuser.aspx?id={0}", Eval("ID")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Points">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="ConstructionLabel" runat="server" Text='<%# Eval("Points") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Construction">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="ConstructionLabel" runat="server" Text='<%# Eval("CP") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Attack">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="AttackLabel" runat="server" Text='<%# Eval("AP") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Defence">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="DenfenceLabel" runat="server" Text='<%# Eval("DP") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
