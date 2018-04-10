<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Compose.ascx.cs" Inherits="AJSGame.Controls.Compose" %>
<div id="title">
    <h2>Compose Message</h2>
</div>
<asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
<p>
    Username:
    <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ErrorMessage="Username is required" ControlToValidate="Username">*</asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="Username" runat="server" CssClass="textbox" Width="200px" />
</p>
<p>
    Title:
    <br />
    <asp:TextBox ID="Title" runat="server" CssClass="textbox" Width="200px" />
</p>
<p>
    Message:
    <br />
    <asp:TextBox ID="Body" runat="server" CssClass="textbox" Width="400px" Height="350px" TextMode="MultiLine" />
</p>
<p>
    <asp:Button ID="Submit" runat="server" CssClass="button" Width="75px" Text="Send" OnClick="Submit_Click" />
</p>