using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;
using AJSGame.Objects;

namespace AJSGame.Controls
{
    public partial class RallyPoint : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Game.Session.Village.Buildings.RallyPoint.Level >= 1)
                SendUnitsPanel.Visible = true;

            if (Request.QueryString["x"] != "" && Request.QueryString["y"] != "")
            {
                if (AJSGame.Core.Functions.IsInteger(Request.QueryString["x"]) && AJSGame.Core.Functions.IsInteger(Request.QueryString["y"]))
                {
                    XTextBox.Text = Request.QueryString["x"];
                    YTextBox.Text = Request.QueryString["y"];
                }
            }

            IncomingAttacksGridView.DataSource = AJSGame.Objects.Movement.GetMovements("tovillage = '" + AJSGame.Game.Session.Village.ID + "' AND type = 'attack'");
            IncomingAttacksGridView.DataBind();
            OutgoingAttacksGridView.DataSource = AJSGame.Objects.Movement.GetMovements("fromvillage = '" + AJSGame.Game.Session.Village.ID + "' AND type = 'attack'");
            OutgoingAttacksGridView.DataBind();
            IncomingSupportGridView.DataSource = AJSGame.Objects.Movement.GetMovements("tovillage = '" + AJSGame.Game.Session.Village.ID + "' AND type = 'support'");
            IncomingSupportGridView.DataBind();
            OutgoingSupportGridView.DataSource = AJSGame.Objects.Movement.GetMovements("fromvillage = '" + AJSGame.Game.Session.Village.ID + "' AND type = 'support'");
            OutgoingSupportGridView.DataBind();

            if (!Page.IsPostBack)
            {
                TitleLabel.Text = "Rally Point Level " + Game.Session.Village.Buildings.RallyPoint.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.RallyPoint.Attribute.ToString();
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "rally")
                        upgrades++;
                }
                if (Objects.Building.Exists("rally", Game.Session.Village.Buildings.RallyPoint.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("rally", Game.Session.Village.Buildings.RallyPoint.Level + upgrades + 1);
                    UpgradedTimeBonus.Text = upgraded.Attribute.ToString();
                    AtLevelLabel.Text = "Nubmer of attacks at level " + upgraded.Level.ToString() + ".";
                    CostToLevelLabel.Text = "Cost to upgrade to level " + upgraded.Level.ToString() + ":";
                    WoodCost.Text = upgraded.Wood.ToString();
                    ClayCost.Text = upgraded.Clay.ToString();
                    MetalCost.Text = upgraded.Metal.ToString();
                    FoodCost.Text = upgraded.Food.ToString();
                    TimeCost.Text = Functions.TimeReducedBuilding(Game.Session.Village, upgraded.Time).ToString().Substring(0, 8);

                    if (Functions.RequirementsResources(upgraded.Wood, upgraded.Clay, upgraded.Metal, upgraded.Food, Game.Session.Village) && (!AJSGame.Game.Session.User.IsPremium && AJSGame.Game.Session.Village.Constructions.Count >= 2 ? false : true))
                        Submit.Visible = true;
                    else
                        Submit.Visible = false;

                    UpgradePanel.Visible = true;
                }
                else
                {
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("rally", Game.Session.Village.Buildings.RallyPoint.Level + upgrades).Attribute.ToString();
                    AtLevelLabel.Text = "Rally Point at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "rally")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "rally", Game.Session.Village.Buildings.RallyPoint.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void AttackButton_Click(object sender, EventArgs e)
        {
            if (AJSGame.Objects.Village.Exists(Convert.ToInt32(XTextBox.Text), Convert.ToInt32(YTextBox.Text)))
            {
                AJSGame.Objects.Village toVillage = AJSGame.Objects.Village.GetVillage(Convert.ToInt32(XTextBox.Text), Convert.ToInt32(YTextBox.Text));
                int Spear = (SpearmanTextBox.Text != "" ? Convert.ToInt32(SpearmanTextBox.Text) : 0);
                int Sword = (SwordsmanTextBox.Text != "" ? Convert.ToInt32(SwordsmanTextBox.Text) : 0);
                int Axe = (AxemanTextBox.Text != "" ? Convert.ToInt32(AxemanTextBox.Text) : 0);
                int Scout = (ScoutTextBox.Text != "" ? Convert.ToInt32(ScoutTextBox.Text) : 0);
                int Light = (LightCavalryTextBox.Text != "" ? Convert.ToInt32(LightCavalryTextBox.Text) : 0);
                int Heavy = (HeavyCavalryTextBox.Text != "" ? Convert.ToInt32(HeavyCavalryTextBox.Text) : 0);
                int Ram = (RamTextBox.Text != "" ? Convert.ToInt32(RamTextBox.Text) : 0);
                int Cata = (CatapultTextBox.Text != "" ? Convert.ToInt32(CatapultTextBox.Text) : 0);

                if (Spear > AJSGame.Game.Session.Village.Units.Spearman)
                    Spear = AJSGame.Game.Session.Village.Units.Spearman;
                if (Sword > AJSGame.Game.Session.Village.Units.Swordsman)
                    Sword = AJSGame.Game.Session.Village.Units.Swordsman;
                if (Axe > AJSGame.Game.Session.Village.Units.Axeman)
                    Axe = AJSGame.Game.Session.Village.Units.Axeman;
                if (Scout > AJSGame.Game.Session.Village.Units.Scout)
                    Scout = AJSGame.Game.Session.Village.Units.Scout;
                if (Light > AJSGame.Game.Session.Village.Units.LightCavalry)
                    Light = AJSGame.Game.Session.Village.Units.LightCavalry;
                if (Heavy > AJSGame.Game.Session.Village.Units.HeavyCavalry)
                    Heavy = AJSGame.Game.Session.Village.Units.HeavyCavalry;
                if (Ram > AJSGame.Game.Session.Village.Units.BatteringRam)
                    Ram = AJSGame.Game.Session.Village.Units.BatteringRam;
                if (Cata > AJSGame.Game.Session.Village.Units.Catapult)
                    Cata = AJSGame.Game.Session.Village.Units.Catapult;

                if (Spear == 0 && Sword == 0 && Axe == 0 && Scout == 0 && Light == 0 && Heavy == 0 && Ram == 0 && Cata == 0)
                    ErrorLabel.Text = "You must send units.";
                else
                {
                    if (AJSGame.Objects.Movement.GetMovements("fromvillage = '" + AJSGame.Game.Session.Village.ID + "'").Count > AJSGame.Game.Session.Village.Buildings.RallyPoint.Attribute)
                        ErrorLabel.Text = "Too many outgoing movements in progress.";
                    else
                    {
                        AJSGame.Game.Session.Village.Units.Update("remove", Spear, Sword, Axe, Scout, Light, Heavy, Ram, Cata);
                        AJSGame.Objects.Movement.NewMovement(AJSGame.Game.Session.Village.ID, toVillage.ID, Spear, Sword, Axe, Scout, Light, Heavy, Ram, Cata, 0, 0, 0, 0, "attack");
                    }
                }
            }
            else
                ErrorLabel.Text = "Invalid coordinates.";
            Response.Redirect(Request.RawUrl);
        }

        protected void SupportButton_Click(object sender, EventArgs e)
        {
            if (AJSGame.Objects.Village.Exists(Convert.ToInt32(XTextBox.Text), Convert.ToInt32(YTextBox.Text)))
            {
                AJSGame.Objects.Village toVillage = AJSGame.Objects.Village.GetVillage(Convert.ToInt32(XTextBox.Text), Convert.ToInt32(YTextBox.Text));
                int Spear = (SpearmanTextBox.Text != "" ? Convert.ToInt32(SpearmanTextBox.Text) : 0);
                int Sword = (SwordsmanTextBox.Text != "" ? Convert.ToInt32(SwordsmanTextBox.Text) : 0);
                int Axe = (AxemanTextBox.Text != "" ? Convert.ToInt32(AxemanTextBox.Text) : 0);
                int Scout = (ScoutTextBox.Text != "" ? Convert.ToInt32(ScoutTextBox.Text) : 0);
                int Light = (LightCavalryTextBox.Text != "" ? Convert.ToInt32(LightCavalryTextBox.Text) : 0);
                int Heavy = (HeavyCavalryTextBox.Text != "" ? Convert.ToInt32(HeavyCavalryTextBox.Text) : 0);
                int Ram = (RamTextBox.Text != "" ? Convert.ToInt32(RamTextBox.Text) : 0);
                int Cata = (CatapultTextBox.Text != "" ? Convert.ToInt32(CatapultTextBox.Text) : 0);

                if (Spear > AJSGame.Game.Session.Village.Units.Spearman)
                    Spear = AJSGame.Game.Session.Village.Units.Spearman;
                if (Sword > AJSGame.Game.Session.Village.Units.Swordsman)
                    Sword = AJSGame.Game.Session.Village.Units.Swordsman;
                if (Axe > AJSGame.Game.Session.Village.Units.Axeman)
                    Axe = AJSGame.Game.Session.Village.Units.Axeman;
                if (Scout > AJSGame.Game.Session.Village.Units.Scout)
                    Scout = AJSGame.Game.Session.Village.Units.Scout;
                if (Light > AJSGame.Game.Session.Village.Units.LightCavalry)
                    Light = AJSGame.Game.Session.Village.Units.LightCavalry;
                if (Heavy > AJSGame.Game.Session.Village.Units.HeavyCavalry)
                    Heavy = AJSGame.Game.Session.Village.Units.HeavyCavalry;
                if (Ram > AJSGame.Game.Session.Village.Units.BatteringRam)
                    Ram = AJSGame.Game.Session.Village.Units.BatteringRam;
                if (Cata > AJSGame.Game.Session.Village.Units.Catapult)
                    Cata = AJSGame.Game.Session.Village.Units.Catapult;

                if (Spear == 0 && Sword == 0 && Axe == 0 && Scout == 0 && Light == 0 && Heavy == 0 && Ram == 0 && Cata == 0)
                    ErrorLabel.Text = "You must send units.";
                else
                {
                    if (AJSGame.Objects.Movement.GetMovements("fromvillage = '" + AJSGame.Game.Session.Village.ID + "'").Count > AJSGame.Game.Session.Village.Buildings.RallyPoint.Attribute)
                        ErrorLabel.Text = "Too many outgoing movements in progress.";
                    else
                    {
                        AJSGame.Game.Session.Village.Units.Update("remove", Spear, Sword, Axe, Scout, Light, Heavy, Ram, Cata);
                        AJSGame.Objects.Movement.NewMovement(AJSGame.Game.Session.Village.ID, toVillage.ID, Spear, Sword, Axe, Scout, Light, Heavy, Ram, Cata, 0, 0, 0, 0, "support");
                    }
                }
            }
            else
                ErrorLabel.Text = "Invalid coordinates.";
            Response.Redirect(Request.RawUrl);
        }

        protected void IncomingAttacksGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IncomingAttacksGridView.PageIndex = e.NewPageIndex;
            IncomingAttacksGridView.DataBind();
        }

        protected void OutgoingAttacksGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OutgoingAttacksGridView.PageIndex = e.NewPageIndex;
            OutgoingAttacksGridView.DataBind();
        }

        protected void IncomingSupportGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IncomingSupportGridView.PageIndex = e.NewPageIndex;
            IncomingSupportGridView.DataBind();
        }

        protected void OutgoingSupportGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OutgoingSupportGridView.PageIndex = e.NewPageIndex;
            OutgoingSupportGridView.DataBind();
        }
    }
}