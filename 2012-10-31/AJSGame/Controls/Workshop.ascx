<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Workshop.ascx.cs" Inherits="AJSGame.Controls.Workshop" %>
<div id="title">
    <h2>
        <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label></h2>
</div>
<p>
    The Siege Workshop is where your village trains it's siege units. Upgrading your Siege Workshop decreases the time to train units.
</p>
<ul>
    <li>
        <a class="tile">
            <span class="tiletitle">
                <asp:Label ID="TimeBonus" runat="server" Text=""></asp:Label>
            </span>
            <br />
            <span class="tilebody">Current recruitment time multiplier.
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
<asp:Panel ID="NewTrainingPanel" runat="server" Visible="false">
    <ul>
        <li>
            <div class="tile" style="width: 240px;">
                <span class="tiletitle">Battering Ram
                </span>
                <span class="tilebody">
                    <asp:Literal ID="RamLiteral" runat="server" Visible="false">
                        Unit not researched.
                    </asp:Literal>
                    <asp:Panel ID="RamPanel" runat="server" Visible="false">
                        <ul>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Wood.gif" /><%= AJSGame.Objects.Unit.GetUnit("ram").Wood.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Clay.gif" /><%= AJSGame.Objects.Unit.GetUnit("ram").Clay.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Metal.gif" /><%= AJSGame.Objects.Unit.GetUnit("ram").Metal.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Food.gif" /><%= AJSGame.Objects.Unit.GetUnit("ram").Food.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Time.gif" /><%= AJSGame.Core.Functions.TimeReducedRecruitment(AJSGame.Game.Session.Village, AJSGame.Objects.Unit.GetUnit("ram").Time, "siege").ToString().Substring(0, 8) %></li>
                        </ul>
                        <asp:TextBox ID="RamTextBox" runat="server" Text="0" TextMode="Number" CssClass="textbox" Width="30px"></asp:TextBox>
                        <asp:LinkButton ID="RamMaxButton" runat="server" ForeColor="White" OnClick="RamMaxButton_Click"><%= "(" + AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "ram") + ")" %></asp:LinkButton>
                        <asp:Button ID="RamTrain" runat="server" Text="Train" CssClass="button" OnClick="RamTrain_Click"></asp:Button>
                    </asp:Panel>
                </span>
            </div>

        </li>
        <li>
            <div class="tile" style="width: 240px;">
                <span class="tiletitle">Catapult
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="CataLiteral" runat="server" Visible="false">
                        Unit not researched.
                    </asp:Literal>
                    <asp:Panel ID="CataPanel" runat="server" Visible="false">
                        <ul>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Wood.gif" /><%= AJSGame.Objects.Unit.GetUnit("cata").Wood.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Clay.gif" /><%= AJSGame.Objects.Unit.GetUnit("cata").Clay.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Metal.gif" /><%= AJSGame.Objects.Unit.GetUnit("cata").Metal.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Food.gif" /><%= AJSGame.Objects.Unit.GetUnit("cata").Food.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Time.gif" /><%= AJSGame.Core.Functions.TimeReducedRecruitment(AJSGame.Game.Session.Village, AJSGame.Objects.Unit.GetUnit("cata").Time, "siege").ToString().Substring(0, 8) %></li>
                        </ul>
                        <asp:TextBox ID="CataTextBox" runat="server" Text="0" TextMode="Number" CssClass="textbox" Width="30px"></asp:TextBox>
                        <asp:LinkButton ID="CataMaxButton" runat="server" ForeColor="White" OnClick="CataMaxButton_Click"><%= "(" + AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "cata") + ")" %></asp:LinkButton>
                        <asp:Button ID="CataTrain" runat="server" Text="Train" CssClass="button" OnClick="CataTrain_Click"></asp:Button>
                    </asp:Panel>
                </span>
            </div>
        </li>
    </ul>
</asp:Panel>
<p></p>
<div id="constructions">
    <asp:Literal ID="RecruitmentsLiteral" runat="server">
        <h2>Recruitment</h2>
    </asp:Literal>
    <asp:GridView ID="RecruitmentsGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" CellSpacing="0" ShowHeader="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# Eval("Ammount").ToString() %>
                    <%# AJSGame.Core.Functions.LabelsUnit(Eval("Unit").ToString()) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <%# AJSGame.Core.Functions.DateFriendly(AJSGame.Core.Functions.MutliFinishedTime((DateTime)Eval("Start"), (int)Eval("Ammount"), (TimeSpan)Eval("Time"))) %>
                        at
                        <%# String.Format("{0:HH:mm:ss}", AJSGame.Core.Functions.MutliFinishedTime((DateTime)Eval("Start"), (int)Eval("Ammount"), (TimeSpan)Eval("Time"))).ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <span id='<%# "timer" + (Container.DataItemIndex + 1) %>'>
                        <%# String.Format("{0:00}:{1:D2}:{2:D2}", AJSGame.Core.Functions.TimeLeftMulti((int)Eval("Ammount"), (TimeSpan)Eval("Time"), Convert.ToDateTime(Eval("Start"))).TotalHours, AJSGame.Core.Functions.TimeLeftMulti((int)Eval("Ammount"), (TimeSpan)Eval("Time"), Convert.ToDateTime(Eval("Start"))).Minutes, AJSGame.Core.Functions.TimeLeftMulti((int)Eval("Ammount"), (TimeSpan)Eval("Time"), Convert.ToDateTime(Eval("Start"))).Seconds) %>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
