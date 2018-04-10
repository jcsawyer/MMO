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
    public partial class Claypit : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TitleLabel.Text = "Claypit Level " + Game.Session.Village.Buildings.Claypit.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.Claypit.Attribute.ToString();
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "claypit")
                        upgrades++;
                }
                if (Objects.Building.Exists("claypit", Game.Session.Village.Buildings.Claypit.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("claypit", Game.Session.Village.Buildings.Claypit.Level + upgrades + 1);
                    UpgradedTimeBonus.Text = upgraded.Attribute.ToString();
                    AtLevelLabel.Text = "Hourly production at level " + upgraded.Level.ToString() + ".";
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
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("claypit", Game.Session.Village.Buildings.Claypit.Level + upgrades).Attribute.ToString();
                    AtLevelLabel.Text = "Claypit at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "claypit")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "claypit", Game.Session.Village.Buildings.Claypit.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }
    }
}