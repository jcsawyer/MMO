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
    public partial class Workshop : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Training> unitsTraining = new List<Training>();
            foreach (AJSGame.Objects.Training train in AJSGame.Game.Session.Village.Training)
            {
                if (train.Type == "siege")
                    unitsTraining.Add(train);
            }
            RecruitmentsGridView.DataSource = unitsTraining;
            RecruitmentsGridView.DataBind();

            if (RecruitmentsGridView.Rows.Count == 0)
                RecruitmentsLiteral.Visible = false;

            if (Game.Session.Village.Buildings.Barracks.Level >= 1)
                NewTrainingPanel.Visible = true;

            #region Battering Ram
            AJSGame.Objects.Unit RamData = Objects.Unit.GetUnit("ram");
            if (AJSGame.Game.Session.Village.Research.BatteringRam)
            {
                if (Functions.RequirementsResources(RamData.Wood, RamData.Clay, RamData.Metal, RamData.Food, Game.Session.Village))
                    RamPanel.Visible = true;
                else
                {
                    RamLiteral.Text = "Not enough resources.";
                    RamLiteral.Visible = true;
                }
            }
            else
                RamLiteral.Visible = true;
            #endregion
            #region Catapult
            AJSGame.Objects.Unit CataData = Objects.Unit.GetUnit("cata");
            if (AJSGame.Game.Session.Village.Research.Catapult)
            {
                if (Functions.RequirementsResources(CataData.Wood, CataData.Clay, CataData.Metal, CataData.Food, Game.Session.Village))
                    CataPanel.Visible = true;
                else
                {
                    CataLiteral.Text = "Not enough resources.";
                    CataLiteral.Visible = true;
                }
            }
            else
                CataLiteral.Visible = true;
            #endregion

            if (!Page.IsPostBack)
            {
                TitleLabel.Text = "Siege Workshop Level " + Game.Session.Village.Buildings.SiegeWorkshop.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.SiegeWorkshop.Attribute.ToString() + "%";
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "workshop")
                        upgrades++;
                }
                if (Objects.Building.Exists("workshop", Game.Session.Village.Buildings.SiegeWorkshop.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("workshop", Game.Session.Village.Buildings.SiegeWorkshop.Level + upgrades + 1);
                    UpgradedTimeBonus.Text = upgraded.Attribute.ToString() + "%";
                    AtLevelLabel.Text = "Recruitment time multiplier at level " + upgraded.Level.ToString() + ".";
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
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("workshop", Game.Session.Village.Buildings.SiegeWorkshop.Level + upgrades).Attribute.ToString() + "%";
                    AtLevelLabel.Text = "Siege Workshop at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "workshop")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "workshop", Game.Session.Village.Buildings.SiegeWorkshop.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void RamTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit RamData = Objects.Unit.GetUnit("ram");
            int ammount = Convert.ToInt32(RamTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(RamData.Wood * ammount, RamData.Clay * ammount, RamData.Metal * ammount, RamData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "ram", Convert.ToInt32(RamTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void RamMaxButton_Click(object sender, EventArgs e)
        {
            RamTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "ram").ToString();
        }

        protected void CataTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit CataData = Objects.Unit.GetUnit("cata");
            int ammount = Convert.ToInt32(CataTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(CataData.Wood * ammount, CataData.Clay * ammount, CataData.Metal * ammount, CataData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "cata", Convert.ToInt32(CataTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void CataMaxButton_Click(object sender, EventArgs e)
        {
            CataTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "cata").ToString();
        }
    }
}