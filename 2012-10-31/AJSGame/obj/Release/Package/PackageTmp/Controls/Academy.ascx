<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Academy.ascx.cs" Inherits="AJSGame.Controls.Academy" %>
<div id="title">
    <h2>
        <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label></h2>
</div>
<p>
    The Research Academy is where your village's units are researched. Upgrading your Research Academy decreases the cost for research.
</p>
<ul>
    <li>
        <a class="tile">
            <span class="tiletitle">
                <asp:Label ID="TimeBonus" runat="server" Text=""></asp:Label>
            </span>
            <br />
            <span class="tilebody">Current research cost multiplier.
            </span>
        </a>
    </li>
    <li>
        <a class="tile">
            <span class="tiletitle">
                <asp:Label ID="UpgradedTimeBonus" runat="server" Text=""></asp:Label>
            </span>
            <br />
            <span class="tilebody">
                <asp:Label ID="AtLevelLabel" runat="server" Text=""></asp:Label>
            </span>
        </a>
    </li>
</ul>
<asp:Panel ID="UpgradePanel" runat="server" Visible="False">
    <p>
        <asp:Label ID="CostToLevelLabel" runat="server" Text=""></asp:Label>
    </p>
    <ul>
        <li>
            <asp:Image ID="WoodImage" runat="server" Width="13px" Height="13px" ImageUrl="~/Images/Resources/Wood.gif" />
            <asp:Label ID="WoodCost" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="ClayImage" runat="server" Width="13px" Height="13px" ImageUrl="~/Images/Resources/Clay.gif" />
            <asp:Label ID="ClayCost" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="MetalImage" runat="server" Width="13px" Height="13px" ImageUrl="~/Images/Resources/Metal.gif" />
            <asp:Label ID="MetalCost" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="FoodImage" runat="server" Width="13px" Height="13px" ImageUrl="~/Images/Resources/Food.gif" />
            <asp:Label ID="FoodCost" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:Image ID="TimeImage" runat="server" Width="13px" Height="13px" ImageUrl="~/Images/Resources/Time.gif" />
            <asp:Label ID="TimeCost" runat="server" Text=""></asp:Label>
        </li>
    </ul>
    <p>
        <asp:Button ID="Submit" runat="server" Text="Upgrade" CssClass="button" Width="75px" OnClick="Submit_Click" />
    </p>
</asp:Panel>
<p></p>
<asp:Panel ID="NewResearchPanel" runat="server" Visible="false">
    <ul>
        <li>
            <asp:LinkButton ID="SpearmanResearch" runat="server" CssClass="tile" Width="240px" OnClick="SpearmanResearch_Click">
                <span class="tiletitle">Spearman
                </span>
                <span class="tilebody">
                    <asp:Literal ID="SpearmanLiteral" runat="server">
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="SwordsmanResearch" runat="server" CssClass="tile" Width="240px" OnClick="SwordsmanResearch_Click">
                <span class="tiletitle">Swordsman
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="SwordsmanLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.Swordsman && AJSGame.Core.Functions.RequirementsResearch("sword", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="AxemanResearch" runat="server" CssClass="tile" Width="240px" OnClick="AxemanResearch_Click">
                <span class="tiletitle">Axeman
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="AxemanLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.Axeman && AJSGame.Core.Functions.RequirementsResearch("axe", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
    </ul>
    <ul>
        <li>
            <asp:LinkButton ID="LightResearch" runat="server" CssClass="tile" Width="240px" OnClick="LightResearch_Click">
                <span class="tiletitle">Light Cavlary
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="LightLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.LightCavalry && AJSGame.Core.Functions.RequirementsResearch("light", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="HeavyResearch" runat="server" CssClass="tile" Width="240px" OnClick="HeavyResearch_Click">
                <span class="tiletitle">Heavy Cavalry
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="HeavyLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.HeavyCavalry && AJSGame.Core.Functions.RequirementsResearch("heavy", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="ScoutResearch" runat="server" CssClass="tile" Width="240px" OnClick="ScoutResearch_Click">
                <span class="tiletitle">Scout
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="ScoutLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.Scout && AJSGame.Core.Functions.RequirementsResearch("scout", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
    </ul>
    <ul>
        <li>
            <asp:LinkButton ID="RamResearch" runat="server" CssClass="tile" Width="240px" OnClick="RamResearch_Click">
                <span class="tiletitle">Battering Ram
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="RamLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.BatteringRam && AJSGame.Core.Functions.RequirementsResearch("ram", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton ID="CataResearch" runat="server" CssClass="tile" Width="240px" OnClick="CataResearch_Click">
                <span class="tiletitle">Catapult
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="CataLiteral" runat="server" Visible='<%# !AJSGame.Game.Session.Village.Research.Catapult && AJSGame.Core.Functions.RequirementsResearch("cata", AJSGame.Game.Session.Village) %>'>
                    </asp:Literal>
                </span>
            </asp:LinkButton>
        </li>
    </ul>
</asp:Panel>
