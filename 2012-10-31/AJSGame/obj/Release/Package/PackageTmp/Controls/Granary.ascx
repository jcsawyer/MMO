<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Granary.ascx.cs" Inherits="AJSGame.Controls.Granary" %>
<div id="title">
    <h2>
        <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label></h2>
</div>
<p>
    The Granary is where your village stores it's collected food. Upgrading your Granary increases your food capacity.
</p>
<ul>
    <li>
        <a class="tile">
            <span class="tiletitle">
                <asp:Label ID="TimeBonus" runat="server" Text=""></asp:Label>
            </span>
            <br />
            <span class="tilebody">Current capacity.
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
