<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stable.ascx.cs" Inherits="AJSGame.Controls.Stable" %>
<div id="title">
    <h2>
        <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label></h2>
</div>
<p>
    The Stable is where your village trains it's cavalry units. Upgrading your Stable decreases the time to train units.
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
                <span class="tiletitle">Light Cavalry
                </span>
                <span class="tilebody">
                    <asp:Literal ID="SpearmanLiteral" runat="server" Visible="false">
                        Unit not researched.
                    </asp:Literal>
                    <asp:Panel ID="SpearmanPanel" runat="server" Visible="false">
                        <ul>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Wood.gif" /><%= AJSGame.Objects.Unit.GetUnit("light").Wood.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Clay.gif" /><%= AJSGame.Objects.Unit.GetUnit("light").Clay.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Metal.gif" /><%= AJSGame.Objects.Unit.GetUnit("light").Metal.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Food.gif" /><%= AJSGame.Objects.Unit.GetUnit("light").Food.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Time.gif" /><%= AJSGame.Core.Functions.TimeReducedRecruitment(AJSGame.Game.Session.Village, AJSGame.Objects.Unit.GetUnit("light").Time, "cavalry").ToString().Substring(0, 8) %></li>
                        </ul>
                        <asp:TextBox ID="SpearmanTextBox" runat="server" Text="0" TextMode="Number" CssClass="textbox" Width="30px"></asp:TextBox>
                        <asp:LinkButton ID="SpearmanMaxButton" runat="server" ForeColor="White" OnClick="SpearmanMaxButton_Click"><%= "(" + AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "light") + ")" %></asp:LinkButton>
                        <asp:Button ID="SpearmanTrain" runat="server" Text="Train" CssClass="button" OnClick="SpearmanTrain_Click"></asp:Button>
                    </asp:Panel>
                </span>
            </div>

        </li>
        <li>
            <div class="tile" style="width: 240px;">
                <span class="tiletitle">Heavy Cavalry
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="SwordsmanLiteral" runat="server" Visible="false">
                        Unit not researched.
                    </asp:Literal>
                    <asp:Panel ID="SwordsmanPanel" runat="server" Visible="false">
                        <ul>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Wood.gif" /><%= AJSGame.Objects.Unit.GetUnit("heavy").Wood.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Clay.gif" /><%= AJSGame.Objects.Unit.GetUnit("heavy").Clay.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Metal.gif" /><%= AJSGame.Objects.Unit.GetUnit("heavy").Metal.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Food.gif" /><%= AJSGame.Objects.Unit.GetUnit("heavy").Food.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Time.gif" /><%= AJSGame.Core.Functions.TimeReducedRecruitment(AJSGame.Game.Session.Village, AJSGame.Objects.Unit.GetUnit("heavy").Time, "cavalry").ToString().Substring(0, 8) %></li>
                        </ul>
                        <asp:TextBox ID="SwordsmanTextBox" runat="server" Text="0" TextMode="Number" CssClass="textbox" Width="30px"></asp:TextBox>
                        <asp:LinkButton ID="SwordsmanMaxButton" runat="server" ForeColor="White" OnClick="SwordsmanMaxButton_Click"><%= "(" + AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "heavy") + ")" %></asp:LinkButton>
                        <asp:Button ID="SwordsmanTrain" runat="server" Text="Train" CssClass="button" OnClick="SwordsmanTrain_Click"></asp:Button>
                    </asp:Panel>
                </span>
            </div>
        </li>
        <li>
            <div class="tile" style="width: 240px;">
                <span class="tiletitle">Scout
                </span>
                <br />
                <span class="tilebody">
                    <asp:Literal ID="AxemanLiteral" runat="server" Visible="false">
                        Unit not researched.
                    </asp:Literal>
                    <asp:Panel ID="AxemanPanel" runat="server" Visible="false">
                        <ul>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Wood.gif" /><%= AJSGame.Objects.Unit.GetUnit("scout").Wood.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Clay.gif" /><%= AJSGame.Objects.Unit.GetUnit("scout").Clay.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Metal.gif" /><%= AJSGame.Objects.Unit.GetUnit("scout").Metal.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Food.gif" /><%= AJSGame.Objects.Unit.GetUnit("scout").Food.ToString() %></li>
                            <li>
                                <img width="9px" height="9px" src="Images/Resources/Time.gif" /><%= AJSGame.Core.Functions.TimeReducedRecruitment(AJSGame.Game.Session.Village, AJSGame.Objects.Unit.GetUnit("scout").Time, "cavalry").ToString().Substring(0, 8) %></li>
                        </ul>
                        <asp:TextBox ID="AxemanTextBox" runat="server" Text="0" TextMode="Number" CssClass="textbox" Width="30px"></asp:TextBox>
                        <asp:LinkButton ID="AxemanMaxButton" runat="server" ForeColor="White" OnClick="AxemanMaxButton_Click"><%= "(" + AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "scout") + ")" %></asp:LinkButton>
                        <asp:Button ID="AxemanTrainButton" runat="server" Text="Train" CssClass="button" OnClick="AxemanTrain_Click"></asp:Button>
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
