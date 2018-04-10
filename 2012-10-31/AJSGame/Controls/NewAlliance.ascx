<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewAlliance.ascx.cs" Inherits="AJSGame.Controls.NewAlliance" %>
<div id="title">
    <h2>Create an Alliance</h2>
</div>
<asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
<p>
    Name:
    <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Name is required" ControlToValidate="Name">*</asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="Name" runat="server" CssClass="textbox" Width="200px" />
</p>
<p>
    Tag:
    <asp:RequiredFieldValidator ID="TagRequiredFieldValidator" runat="server" ErrorMessage="Tag is required" ControlToValidate="Tag">*</asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="Tag" runat="server" CssClass="textbox" Width="35px" MaxLength="4" />
</p>
<p>
    Description:
    <br />
    <asp:TextBox ID="Description" runat="server" CssClass="textbox" Width="400px" Height="350px" TextMode="MultiLine" />
</p>
<p>
    <asp:Button ID="Submit" runat="server" CssClass="button" Width="75px" Text="Create" OnClick="Submit_Click" />
</p>