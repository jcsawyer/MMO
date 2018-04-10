<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RallyPoint.ascx.cs" Inherits="AJSGame.Controls.RallyPoint" %>
<div id="title">
    <h2>
        <asp:Label ID="TitleLabel" runat="server" Text=""></asp:Label></h2>
</div>
<p>
    The Rally Point is where your organise attacks on villages and send support. Upgrading the Rally Point allows you to send more attacks at once.
</p>
<ul>
    <li>
        <a class="tile">
            <span class="tiletitle">
                <asp:Label ID="TimeBonus" runat="server" Text=""></asp:Label>
            </span>
            <br />
            <span class="tilebody">Current number of attacks.
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
<asp:Panel ID="SendUnitsPanel" runat="server" Visible="false">
    <table width="50%">
        <tr>
            <td>
                <asp:TextBox ID="SpearmanTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Spearman</td>
            <td>
                <asp:TextBox ID="SwordsmanTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Swordsman</td>
            <td>
                <asp:TextBox ID="AxemanTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Axeman</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="ScoutTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Scout</td>
            <td>
                <asp:TextBox ID="LightCavalryTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Light Cavalry</td>
            <td>
                <asp:TextBox ID="HeavyCavalryTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Heavy Cavalry</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="RamTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Battering Ram</td>
            <td>
                <asp:TextBox ID="CatapultTextBox" runat="server" Text="0" Width="30px"></asp:TextBox>
                Catapult</td>
            <td>X:
                <asp:TextBox ID="XTextBox" runat="server" Width="30px"></asp:TextBox>
                Y:
                <asp:TextBox ID="YTextBox" runat="server" Width="30px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: right;">
                <asp:Button ID="AttackButton" runat="server" Text="Attack" CssClass="button" OnClick="AttackButton_Click" />
                <asp:Button ID="SupportButton" runat="server" Text="Support" CssClass="button" OnClick="SupportButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<p></p>
<table width="100%">
    <tr>
        <td valign="top" style="width: 50%;">
            <div id="title">
                <h2>Incoming Attacks</h2>
            </div>
            <asp:GridView ID="IncomingAttacksGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="IncomingAttacksGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Attacker">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:HyperLink ID="DefenderLabel" runat="server" Text='<%# String.Format("({0}|{1}) {2}", AJSGame.Objects.Village.GetVillage((int)Eval("From")).X, AJSGame.Objects.Village.GetVillage((int)Eval("From")).Y, AJSGame.Objects.Village.GetVillage((int)Eval("From")).Name) %>' NavigateUrl='<%# String.Format("~/viewvillage.aspx?id={0}", Eval("From")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Arrival">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="ArrivalFriendlyLabel" runat="server" Text='<%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Finish"))) %>' />
                            at
                <asp:Label ID="ArrivalLabel" runat="server" Text='<%# String.Format("{0:HH:mm:ss}", Eval("Finish")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No incoming attacks.
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
        <td valign="top">
            <div id="title">
                <h2>Outgoing Attacks</h2>
            </div>
            <asp:GridView ID="OutgoingAttacksGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="OutgoingAttacksGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Defender">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:HyperLink ID="DefenderLabel" runat="server" Text='<%# String.Format("({0}|{1}) {2}", AJSGame.Objects.Village.GetVillage((int)Eval("To")).X, AJSGame.Objects.Village.GetVillage((int)Eval("To")).Y, AJSGame.Objects.Village.GetVillage((int)Eval("To")).Name) %>' NavigateUrl='<%# String.Format("~/viewvillage.aspx?id={0}", Eval("To")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Arrival">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="ArrivalFriendlyLabel" runat="server" Text='<%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Finish"))) %>' />
                            at
                <asp:Label ID="ArrivalLabel" runat="server" Text='<%# String.Format("{0:HH:mm:ss}", Eval("Finish")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No outgoing attacks.
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td valign="top" style="width: 50%;">
            <div id="title">
                <h2>Incoming Support</h2>
            </div>
            <asp:GridView ID="IncomingSupportGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="IncomingSupportGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="From">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:HyperLink ID="SenderLabe" runat="server" Text='<%# String.Format("({0}|{1}) {2}", AJSGame.Objects.Village.GetVillage((int)Eval("From")).X, AJSGame.Objects.Village.GetVillage((int)Eval("From")).Y, AJSGame.Objects.Village.GetVillage((int)Eval("From")).Name) %>' NavigateUrl='<%# String.Format("~/viewvillage.aspx?id={0}", Eval("From")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Arrival">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="ArrivalFriendlyLabel" runat="server" Text='<%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Finish"))) %>' />
                            at
                <asp:Label ID="ArrivalLabel" runat="server" Text='<%# String.Format("{0:HH:mm:ss}", Eval("Finish")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No incoming support.
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
        <td valign="top">
            <div id="title">
                <h2>Outgoing Support</h2>
            </div>
            <asp:GridView ID="OutgoingSupportGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" DataKeyNames="ID" AllowPaging="true" PageSize="10" OnPageIndexChanging="OutgoingSupportGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Defender">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:HyperLink ID="ToLabel" runat="server" Text='<%# String.Format("({0}|{1}) {2}", AJSGame.Objects.Village.GetVillage((int)Eval("To")).X, AJSGame.Objects.Village.GetVillage((int)Eval("To")).Y, AJSGame.Objects.Village.GetVillage((int)Eval("To")).Name) %>' NavigateUrl='<%# String.Format("~/viewvillage.aspx?id={0}", Eval("To")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Arrival">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="ArrivalFriendlyLabel" runat="server" Text='<%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Finish"))) %>' />
                            at
                <asp:Label ID="ArrivalLabel" runat="server" Text='<%# String.Format("{0:HH:mm:ss}", Eval("Finish")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No outgoing support.
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
