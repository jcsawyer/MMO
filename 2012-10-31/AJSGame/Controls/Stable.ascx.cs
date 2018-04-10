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
    public partial class Stable : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Training> unitsTraining = new List<Training>();
            foreach (AJSGame.Objects.Training train in AJSGame.Game.Session.Village.Training)
            {
                if (train.Type == "cavalry")
                    unitsTraining.Add(train);
            }
            RecruitmentsGridView.DataSource = unitsTraining;
            RecruitmentsGridView.DataBind();

            if (RecruitmentsGridView.Rows.Count == 0)
                RecruitmentsLiteral.Visible = false;

            if (Game.Session.Village.Buildings.Stable.Level >= 1)
                NewTrainingPanel.Visible = true;

            #region Light Cavalry
            AJSGame.Objects.Unit SpearData = Objects.Unit.GetUnit("light");
            if (AJSGame.Game.Session.Village.Research.LightCavalry)
            {
                if (Functions.RequirementsResources(SpearData.Wood, SpearData.Clay, SpearData.Metal, SpearData.Food, Game.Session.Village))
                    SpearmanPanel.Visible = true;
                else
                {
                    SpearmanLiteral.Text = "Not enough resources.";
                    SpearmanLiteral.Visible = true;
                }
            }
            else
                SpearmanLiteral.Visible = true;
            #endregion
            #region Heavy Cavalry
            AJSGame.Objects.Unit SwordData = Objects.Unit.GetUnit("heavy");
            if (AJSGame.Game.Session.Village.Research.HeavyCavalry)
            {
                if (Functions.RequirementsResources(SwordData.Wood, SwordData.Clay, SwordData.Metal, SwordData.Food, Game.Session.Village))
                    SwordsmanPanel.Visible = true;
                else
                {
                    SwordsmanLiteral.Text = "Not enough resources.";
                    SwordsmanLiteral.Visible = true;
                }
            }
            else
                SwordsmanLiteral.Visible = true;
            #endregion
            #region Scout
            AJSGame.Objects.Unit AxeData = Objects.Unit.GetUnit("scout");
            if (AJSGame.Game.Session.Village.Research.Scout)
            {
                if (Functions.RequirementsResources(AxeData.Wood, AxeData.Clay, AxeData.Metal, AxeData.Food, Game.Session.Village))
                    AxemanPanel.Visible = true;
                else
                {
                    AxemanLiteral.Text = "Not enough resources.";
                    AxemanLiteral.Visible = true;
                }
            }
            else
                AxemanLiteral.Visible = true;
            #endregion

            if (!Page.IsPostBack)
            {
                TitleLabel.Text = "Stable Level " + Game.Session.Village.Buildings.Stable.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.Stable.Attribute.ToString() + "%";
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "stable")
                        upgrades++;
                }
                if (Objects.Building.Exists("stable", Game.Session.Village.Buildings.Stable.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("stable", Game.Session.Village.Buildings.Stable.Level + upgrades + 1);
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
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("stable", Game.Session.Village.Buildings.Stable.Level + upgrades).Attribute.ToString() + "%";
                    AtLevelLabel.Text = "Stable at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "stable")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "stable", Game.Session.Village.Buildings.Stable.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void SpearmanTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit SpearData = Objects.Unit.GetUnit("light");
            int ammount = Convert.ToInt32(SpearmanTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(SpearData.Wood * ammount, SpearData.Clay * ammount, SpearData.Metal * ammount, SpearData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "light", Convert.ToInt32(SpearmanTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void SpearmanMaxButton_Click(object sender, EventArgs e)
        {
            SpearmanTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "light").ToString();
        }

        protected void SwordsmanTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit SwordData = Objects.Unit.GetUnit("heavy");
            int ammount = Convert.ToInt32(SwordsmanTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(SwordData.Wood * ammount, SwordData.Clay * ammount, SwordData.Metal * ammount, SwordData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "heavy", Convert.ToInt32(SwordsmanTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void SwordsmanMaxButton_Click(object sender, EventArgs e)
        {
            SwordsmanTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "heavy").ToString();
        }

        protected void AxemanTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit AxeData = Objects.Unit.GetUnit("scout");
            int ammount = Convert.ToInt32(AxemanTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(AxeData.Wood * ammount, AxeData.Clay * ammount, AxeData.Metal * ammount, AxeData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "scout", Convert.ToInt32(AxemanTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void AxemanMaxButton_Click(object sender, EventArgs e)
        {
            AxemanTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "scout").ToString();
        }
    }
}