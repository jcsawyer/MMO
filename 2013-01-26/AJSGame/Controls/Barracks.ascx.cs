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
    public partial class Barracks : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Training> unitsTraining = new List<Training>();
            foreach (AJSGame.Objects.Training train in AJSGame.Game.Session.Village.Training)
            {
                if (train.Type == "infantry")
                    unitsTraining.Add(train);
            }
            RecruitmentsGridView.DataSource = unitsTraining;
            RecruitmentsGridView.DataBind();

            if (RecruitmentsGridView.Rows.Count == 0)
                RecruitmentsLiteral.Visible = false;

            if (Game.Session.Village.Buildings.Barracks.Level >= 1)
                NewTrainingPanel.Visible = true;

            #region Spearman
            AJSGame.Objects.Unit SpearData = Objects.Unit.GetUnit("spear");
            if (AJSGame.Game.Session.Village.Research.Spearman)
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
            #region Swordsman
            AJSGame.Objects.Unit SwordData = Objects.Unit.GetUnit("sword");
            if (AJSGame.Game.Session.Village.Research.Swordsman)
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
            #region Axeman
            AJSGame.Objects.Unit AxeData = Objects.Unit.GetUnit("axe");
            if (AJSGame.Game.Session.Village.Research.Axeman)
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
                TitleLabel.Text = "Barracks Level " + Game.Session.Village.Buildings.Barracks.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.Barracks.Attribute.ToString() + "%";
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "barracks")
                        upgrades++;
                }
                if (Objects.Building.Exists("barracks", Game.Session.Village.Buildings.Barracks.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("barracks", Game.Session.Village.Buildings.Barracks.Level + upgrades + 1);
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
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("barracks", Game.Session.Village.Buildings.Barracks.Level + upgrades).Attribute.ToString() + "%";
                    AtLevelLabel.Text = "Barracks at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "barracks")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "barracks", Game.Session.Village.Buildings.Barracks.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void SpearmanTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit SpearData = Objects.Unit.GetUnit("spear");
            int ammount = Convert.ToInt32(SpearmanTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(SpearData.Wood * ammount, SpearData.Clay * ammount, SpearData.Metal * ammount, SpearData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "spear", Convert.ToInt32(SpearmanTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void SpearmanMaxButton_Click(object sender, EventArgs e)
        {
            SpearmanTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "spear").ToString();
        }

        protected void SwordsmanTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit SwordData = Objects.Unit.GetUnit("sword");
            int ammount = Convert.ToInt32(SwordsmanTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(SwordData.Wood * ammount, SwordData.Clay * ammount, SwordData.Metal * ammount, SwordData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "sword", Convert.ToInt32(SwordsmanTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void SwordsmanMaxButton_Click(object sender, EventArgs e)
        {
            SwordsmanTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "sword").ToString();
        }

        protected void AxemanTrain_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit AxeData = Objects.Unit.GetUnit("axe");
            int ammount = Convert.ToInt32(AxemanTextBox.Text);
            if (ammount > 0)
            {
                if (Functions.RequirementsResources(AxeData.Wood * ammount, AxeData.Clay * ammount, AxeData.Metal * ammount, AxeData.Food * ammount, Game.Session.Village))
                    Objects.Training.NewTraining(AJSGame.Game.Session.Village, "axe", Convert.ToInt32(AxemanTextBox.Text));
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void AxemanMaxButton_Click(object sender, EventArgs e)
        {
            AxemanTextBox.Text = AJSGame.Core.Functions.MaxUnits(AJSGame.Game.Session.Village, "axe").ToString();
        }
    }
}