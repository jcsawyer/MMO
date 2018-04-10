<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="overview.aspx.cs" Inherits="AJSGame.Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <asp:GridView ID="VillagesGridView" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="None" OnRowCommand="VillagesGridView_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="X|Y">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Eval("X").ToString() %> | <%# Eval("Y").ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Village">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemTemplate>
                    <asp:LinkButton ID="SelectVillageButton" runat="server" Text='<%# Eval("Name") %>'
                        CommandName="Select" CommandArgument='<%# Eval("ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Points">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Eval("CP").ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Wood">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("Wood")).ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Clay">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("Clay")).ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Metal">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("Metal")).ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Food">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("Food")).ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
