<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AJSGame.Default" %>

<%@ Register Src="~/Controls/Login.ascx" TagPrefix="ajs" TagName="Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= AJSGame.Game.Title + " | " + AJSGame.Game.Version %></title>
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
                        <h2><%= AJSGame.Game.Title %></h2>
                    </div>
                    <p>
                        <%= AJSGame.Game.Title %> is an upcoming browser based MMO. Take control of a village and build your empire to control the World!
                    </p>
                    <ul>
                        <li>
                            <a class="tile" href="register.aspx">
                                <span class="tiletitle">Register</span>
                                <br />
                                <span class="tilebody"><%= AJSGame.Game.Title %> is free to play, sign up now!</span>
                            </a>
                        </li>
                        <li>
                            <a class="tile" href="#">
                                <span class="tiletitle">Blog</span>
                                <br />
                                <span class="tilebody">Read up on the game's development.</span>
                            </a>
                        </li>
                        <li>
                            <a class="tile" href="#">
                                <span class="tiletitle">Forum</span>
                                <br />
                                <span class="tilebody">Check out what's being talked about on the forums.</span>
                            </a>
                        </li>
                        <li>
                            <a class="tile" href="http://www.ajsgames.co.uk">
                                <span class="tiletitle">AJSGames</span>
                                <br />
                                <span class="tilebody">Visit AJSGames.co.uk for more games.</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <div id="right">
                    <div id="login">
                        <h2>Login</h2>
                    </div>
                    <ajs:Login runat="server" ID="LoginControl" />
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
