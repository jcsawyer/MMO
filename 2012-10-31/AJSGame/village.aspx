<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="village.aspx.cs" Inherits="AJSGame.Village" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div id="left">
        <div id="title">
            <h2><%= AJSGame.Game.Session.Village.Name %></h2>
        </div>
        <p>
            <asp:HyperLink ID="MainBuildingHyperLink" runat="server" NavigateUrl="~/building.aspx?build=main">Main Building Level <%= AJSGame.Game.Session.Village.Buildings.MainBuilding.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="TimbercampHyperLink" runat="server" NavigateUrl="~/building.aspx?build=timbercamp">Timbercamp Level <%= AJSGame.Game.Session.Village.Buildings.Timbercamp.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="ClaypitHyperLink" runat="server" NavigateUrl="~/building.aspx?build=claypit">Claypit Level <%= AJSGame.Game.Session.Village.Buildings.Claypit.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="MineHyperLink" runat="server" NavigateUrl="~/building.aspx?build=mine">Mine Level <%= AJSGame.Game.Session.Village.Buildings.Mine.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="FarmHyperLink" runat="server" NavigateUrl="~/building.aspx?build=farm">Farm Level <%= AJSGame.Game.Session.Village.Buildings.Farm.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="WarehouseHyperLink" runat="server" NavigateUrl="~/building.aspx?build=warehouse">Warehouse Level <%= AJSGame.Game.Session.Village.Buildings.Warehouse.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="GranaryHyperLink" runat="server" NavigateUrl="~/building.aspx?build=granary">Granary Level <%= AJSGame.Game.Session.Village.Buildings.Granary.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="BarracksHyperLink" runat="server" NavigateUrl="~/building.aspx?build=barracks">Barracks Level <%= AJSGame.Game.Session.Village.Buildings.Barracks.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="StableHyperLink" runat="server" NavigateUrl="~/building.aspx?build=stable">Stable Level <%= AJSGame.Game.Session.Village.Buildings.Stable.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="ResearchAcademyHyperLink" runat="server" NavigateUrl="~/building.aspx?build=academy">Research Academy Level <%= AJSGame.Game.Session.Village.Buildings.ResearchAcademy.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="SiegeWorkshopHyperLink" runat="server" NavigateUrl="~/building.aspx?build=workshop">Siege Workshop Level <%= AJSGame.Game.Session.Village.Buildings.SiegeWorkshop.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="WallHyperLink" runat="server" NavigateUrl="~/building.aspx?build=wall">Wall Level <%= AJSGame.Game.Session.Village.Buildings.Wall.Level.ToString() %></asp:HyperLink>
            <br />
            Market
            <br />
            <asp:HyperLink ID="RallyPointHyperLink" runat="server" NavigateUrl="~/building.aspx?build=rally">Rally Point Level <%= AJSGame.Game.Session.Village.Buildings.RallyPoint.Level.ToString() %></asp:HyperLink>
            <br />
            <asp:HyperLink ID="ShelterHyperLink" runat="server" NavigateUrl="~/building.aspx?build=shelter">Shelter Level <%= AJSGame.Game.Session.Village.Buildings.Shelter.Level.ToString() %></asp:HyperLink>
        </p>
    </div>
    <div id="right">
        <div id="login">
            <h2>Production</h2>
            <p>
                <img width="13px" height="13px" src="Images/Resources/Wood.gif" />
                <b><%= AJSGame.Game.Session.Village.Buildings.Timbercamp.Attribute.ToString() %></b> Wood per hour
                <br />
                <img width="13px" height="13px" src="Images/Resources/Clay.gif" />
                <b><%= AJSGame.Game.Session.Village.Buildings.Claypit.Attribute.ToString() %></b> Clay per hour
                <br />
                <img width="13px" height="13px" src="Images/Resources/Metal.gif" />
                <b><%= AJSGame.Game.Session.Village.Buildings.Mine.Attribute.ToString() %></b> Metal per hour
                <br />
                <img width="13px" height="13px" src="Images/Resources/Food.gif" />
                <b><%= AJSGame.Game.Session.Village.Buildings.Farm.Attribute.ToString() %></b> Food per hour
            </p>
        </div>
        <p>
        </p>
        <h2>Units</h2>
        <p>
            <asp:Label ID="SpearmanLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="SwordsmanLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="AxemanLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="LightCavalryLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="HeavyCavalryLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="ScoutLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="BatteringRamLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="CatapultLabel" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <div class="clear"></div>
    <div id="constructions">
        <asp:Literal ID="ConstructionsLiteral" runat="server"><h2>Constructions</h2></asp:Literal>
        <asp:GridView ID="ConsutrctionsGridView" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" CellPadding="0" CellSpacing="0" ShowHeader="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# AJSGame.Core.Functions.LabelsBuilding(Eval("Building").ToString()) %>
                        level
                        <%# Eval("ToLevel") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%# AJSGame.Core.Functions.DateFriendly(Convert.ToDateTime(Eval("Finish"))) %>
                        at
                        <%# String.Format("{0:HH:mm:ss}", Eval("Finish")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <span id="<%# "timer" + (Container.DataItemIndex + 1) %>">
                            <%# Eval("TimeLeft").ToString().Substring(0, 8) %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
