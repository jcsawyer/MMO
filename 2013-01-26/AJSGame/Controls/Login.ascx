<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="AJSGame.Controls.Login" %>
<p>
    Username:
    <asp:TextBox ID="Username" runat="server" CssClass="textbox" ValidationGroup="login" Width="95%" />
</p>
<p>
    Password:
    <asp:TextBox ID="Password" runat="server" CssClass="textbox" TextMode="Password" ValidationGroup="login" Width="95%" />
</p>
<p style="text-align: right;">
    <asp:Button ID="Submit" runat="server" CssClass="button" ValidationGroup="login" Text="Login" Width="75px" OnClick="Submit_Click" />
</p>
<p>
    <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
</p>