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
    public partial class Granary : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TitleLabel.Text = "Granary Level " + Game.Session.Village.Buildings.Granary.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.Granary.Attribute.ToString();
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "granary")
                        upgrades++;
                }
                if (Objects.Building.Exists("granary", Game.Session.Village.Buildings.Granary.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("granary", Game.Session.Village.Buildings.Granary.Level + upgrades + 1);
                    UpgradedTimeBonus.Text = upgraded.Attribute.ToString();
                    AtLevelLabel.Text = "Capacity at level " + upgraded.Level.ToString() + ".";
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
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("granary", Game.Session.Village.Buildings.Granary.Level + upgrades).Attribute.ToString();
                    AtLevelLabel.Text = "Granary at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "granary")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "granary", Game.Session.Village.Buildings.Granary.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }
    }
}