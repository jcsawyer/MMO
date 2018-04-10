<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="AJSGame.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="Styles/Game.css" rel="stylesheet" />
</head>
<body>
    <form id="AJSForm" runat="server">
        <div id="wrap">
            <div id="header">
                <a href="default.aspx">
                    <h1><%= AJSGame.Game.Title + " | " + AJSGame.Game.Version %></h1>
                </a>
            </div>
            <div id="body">
                <div id="left">
                    <div id="title">
                        <h2>Register</h2>
                    </div>
                    <p>
                        Username:
                        <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ErrorMessage="Username is required" ValidationGroup="Register" ControlToValidate="Username" Display="None"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="Username" runat="server" CssClass="textbox" Width="200px" />
                    </p>
                    <p>
                        Email:
                        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required" ValidationGroup="Register" ControlToValidate="Email" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Email is invalid" ValidationGroup="Register" ControlToValidate="Email" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="Email" runat="server" CssClass="textbox" Width="200px" />
                    </p>
                    <p>
                        Password:
                        <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Password is required" ValidationGroup="Register" ControlToValidate="Password" Display="None"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="Password" runat="server" CssClass="textbox" Width="200px" TextMode="Password" />
                    </p>
                    <p>
                        Repeat Password:
                        <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage="Passwords do not match" ValidationGroup="Register" ControlToValidate="Password" ControlToCompare="PasswordRepeat" Display="None" Operator="Equal"></asp:CompareValidator>
                        <br />
                        <asp:TextBox ID="PasswordRepeat" runat="server" CssClass="textbox" Width="200px" TextMode="Password" />
                    </p>
                    <p>
                        <asp:Button ID="Submit" runat="server" CssClass="button" Width="75px" Text="Register" ValidationGroup="Register" OnClick="RegisterButton_Click" />
                    </p>
                </div>
                <div id="right">
                    <div id="login">
                        <h2>Location</h2>
                    </div>
                    <p>
                        <asp:RadioButtonList ID="MapPositionRadio" runat="server">
                            <asp:ListItem Value="0" Selected="True">Random</asp:ListItem>
                            <asp:ListItem Value="1">North-West</asp:ListItem>
                            <asp:ListItem Value="2">North-East</asp:ListItem>
                            <asp:ListItem Value="3">South-West</asp:ListItem>
                            <asp:ListItem Value="4">South-East</asp:ListItem>
                        </asp:RadioButtonList>
                    </p>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" ValidationGroup="Register" ForeColor="Red" />
                    <ul>
                        <li>
                            <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </li>
                    </ul>
                </div>
                <div class="clear" />
            </div>
            <div id="footer">
                <small>
                    <%= AJSGame.Game.Title + " | " + AJSGame.Game.Version %>
                    <br />
                    <%= AJSGame.Game.Copyright %>
                </small>
            </div>
        </div>
    </form>
</body>
</html>
