<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Outbox.ascx.cs" Inherits="AJSGame.Controls.Outbox" %>
<div id="title">
    <h2>Outbox</h2>
</div>
<asp:GridView ID="InboxGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" OnRowDataBound="InboxGridView_RowDataBound" DataKeyNames="ID" OnSelectedIndexChanged="InboxGridView_SelectedIndexChanged" AllowPaging="true" PageSize="15" OnPageIndexChanging="InboxGridView_PageIndexChanging">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="SelectCheckBox" runat="server" Checked="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemTemplate>
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sender">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:Label ID="SenderLabel" runat="server" Text='<%# Eval("Sender") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date/Time">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
                <asp:Label ID="SentFriendlyLabel" runat="server" Text='<%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Sent"))) %>' />
                at
                <asp:Label ID="SentLabel" runat="server" Text='<%# String.Format("{0:HH:mm:ss}", Eval("Sent")) %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="ViewMessageButton" runat="server" Text="View" CommandArgument="ID" CommandName="Select" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:CheckBox ID="CheckAll" runat="server" OnCheckedChanged="CheckAll_CheckedChanged" AutoPostBack="true" /><asp:Button ID="DeleteSelectedButton" runat="server" Text="Delete" OnClick="DeleteSelectedButton_Click" />
<p></p>
<div id="constructions">
    <asp:FormView ID="MessageFormView" runat="server" DataSourceID="ObjectDataSource1" Width="100%" Visible="false">
        <ItemTemplate>
            <table width="100%" cellspacing="0" cellpadding="0"">
                <tr style="background-color: #333333; color: white; height: 50px; padding: 5px 0px 5px 0px;">
                    <td width="50%">
                        <b>Title: </b>
                        <asp:Label ID="MessageTitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <b>Date/Time: </b>
                        <asp:Label ID="MessageSentFriendlyLabel" runat="server" Text='<%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Sent"))) %>' />
                        at
                        <asp:Label ID="MessageSentLabel" runat="server" Text='<%# String.Format("{0:HH:mm:ss}", Eval("Sent")) %>' />
                    </td>
                </tr>
                <tr style="background-color: #3399FF; color: white;">
                    <td colspan="2" style="overflow-y: scroll; width: 100%; height: 350px; vertical-align: top; padding: 5px 5px 5px 5px;">
                        <asp:Label ID="MessageBodyLabel" runat="server" Text='<%# Eval("Body") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMessage" TypeName="AJSGame.Objects.Message">
        <SelectParameters>
            <asp:ControlParameter ControlID="InboxGridView" Name="id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
