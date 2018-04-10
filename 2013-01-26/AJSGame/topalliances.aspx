<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="topalliances.aspx.cs" Inherits="AJSGame.TopAlliances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div id="title">
        <h2>Top Alliances</h2>
    </div>
    <asp:GridView ID="AlliancesGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" DataKeyNames="ID" AllowPaging="true" PageSize="20" OnPageIndexChanging="AlliancesGridView_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="RankLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Alliance">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:HyperLink ID="TitleHyperLink" runat="server" Text='<%# String.Format("[{0}] {1}", Eval("Tag"), Eval("Name")) %>' NavigateUrl='<%# String.Format("~/viewalliance.aspx?id={0}", Eval("ID")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Members">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="MembersLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Members.Count") %>' />
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
