using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;
using AJSGame.Objects;
using System.Collections;

namespace AJSGame.Controls
{
    public partial class Academy : AJSGame.Core.ControlBase
    {
        int upgrades = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Game.Session.Village.Buildings.ResearchAcademy.Level >= 1)
                NewResearchPanel.Visible = true;

            #region Spearman
            AJSGame.Objects.Unit SpearData = Objects.Unit.GetUnit("spear");
            if (AJSGame.Core.Functions.RequirementsResearch("spear", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.Spearman)
                {
                    if (Functions.RequirementsResources(SpearData.Wood * 10, SpearData.Clay * 10, SpearData.Metal * 10, SpearData.Food * 10, Game.Session.Village))
                        SpearmanLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("spear").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("spear").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("spear").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("spear").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        SpearmanLiteral.Text = "Not enough resources.";
                }
                else
                    SpearmanLiteral.Text = "Unit researched.";
            }
            else
                SpearmanLiteral.Text = "Requirements not met.";
            #endregion
            #region Swordsman
            AJSGame.Objects.Unit SwordData = Objects.Unit.GetUnit("sword");
            if (AJSGame.Core.Functions.RequirementsResearch("sword", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.Swordsman)
                {
                    if (Functions.RequirementsResources(SwordData.Wood * 10, SwordData.Clay * 10, SwordData.Metal * 10, SwordData.Food * 10, Game.Session.Village))
                        SwordsmanLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("sword").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("sword").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("sword").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("sword").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        SwordsmanLiteral.Text = "Not enough resources.";
                }
                else
                    SwordsmanLiteral.Text = "Unit researched.";
            }
            else
                SwordsmanLiteral.Text = "Requirements not met.";
            #endregion
            #region Axeman
            AJSGame.Objects.Unit AxeData = Objects.Unit.GetUnit("axe");
            if (AJSGame.Core.Functions.RequirementsResearch("axe", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.Axeman)
                {
                    if (Functions.RequirementsResources(AxeData.Wood * 10, AxeData.Clay * 10, AxeData.Metal * 10, AxeData.Food * 10, Game.Session.Village))
                        AxemanLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("axe").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("axe").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("axe").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("axe").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        AxemanLiteral.Text = "Not enough resources.";
                }
                else
                    AxemanLiteral.Text = "Unit researched.";
            }
            else
                AxemanLiteral.Text = "Requirements not met.";
            #endregion
            #region Light Cavalry
            AJSGame.Objects.Unit LightData = Objects.Unit.GetUnit("light");
            if (AJSGame.Core.Functions.RequirementsResearch("light", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.LightCavalry)
                {
                    if (Functions.RequirementsResources(LightData.Wood * 10, LightData.Clay * 10, LightData.Metal * 10, LightData.Food * 10, Game.Session.Village))
                        LightLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("light").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("light").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("light").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("light").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        LightLiteral.Text = "Not enough resources.";
                }
                else
                    LightLiteral.Text = "Unit researched.";
            }
            else
                LightLiteral.Text = "Requirements not met.";
            #endregion
            #region Heavy Cavalry
            AJSGame.Objects.Unit HeavyData = Objects.Unit.GetUnit("heavy");
            if (AJSGame.Core.Functions.RequirementsResearch("heavy", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.HeavyCavalry)
                {
                    if (Functions.RequirementsResources(HeavyData.Wood * 10, HeavyData.Clay * 10, HeavyData.Metal * 10, HeavyData.Food * 10, Game.Session.Village))
                        HeavyLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("heavy").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("heavy").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("heavy").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("heavy").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        HeavyLiteral.Text = "Not enough resources.";
                }
                else
                    HeavyLiteral.Text = "Unit researched.";
            }
            else
                HeavyLiteral.Text = "Requirements not met.";
            #endregion
            #region Scout
            AJSGame.Objects.Unit ScoutData = Objects.Unit.GetUnit("scout");
            if (AJSGame.Core.Functions.RequirementsResearch("scout", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.Scout)
                {
                    if (Functions.RequirementsResources(ScoutData.Wood * 10, ScoutData.Clay * 10, ScoutData.Metal * 10, ScoutData.Food * 10, Game.Session.Village))
                        ScoutLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("scout").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("scout").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("scout").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("scout").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        ScoutLiteral.Text = "Not enough resources.";
                }
                else
                    ScoutLiteral.Text = "Unit researched.";
            }
            else
                ScoutLiteral.Text = "Requirements not met.";
            #endregion
            #region Battering Ram
            AJSGame.Objects.Unit RamData = Objects.Unit.GetUnit("ram");
            if (AJSGame.Core.Functions.RequirementsResearch("ram", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.BatteringRam)
                {
                    if (Functions.RequirementsResources(RamData.Wood * 10, RamData.Clay * 10, RamData.Metal * 10, RamData.Food * 10, Game.Session.Village))
                        RamLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("ram").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("ram").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("ram").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("ram").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        RamLiteral.Text = "Not enough resources.";
                }
                else
                    RamLiteral.Text = "Unit researched.";
            }
            else
                RamLiteral.Text = "Requirements not met.";
            #endregion
            #region Catapult
            AJSGame.Objects.Unit CataData = Objects.Unit.GetUnit("cata");
            if (AJSGame.Core.Functions.RequirementsResearch("cata", AJSGame.Game.Session.Village))
            {
                if (!AJSGame.Game.Session.Village.Research.Catapult)
                {
                    if (Functions.RequirementsResources(CataData.Wood * 10, CataData.Clay * 10, CataData.Metal * 10, CataData.Food * 10, Game.Session.Village))
                        CataLiteral.Text = "<ul><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Wood.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("cata").Wood * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Clay.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("cata").Clay * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Metal.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("cata").Metal * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li><li><img border=\"0\" width=\"9px\" height=\"9px\" src=\"Images/Resources/Food.gif\" />" + Convert.ToInt32((Objects.Unit.GetUnit("cata").Food * (Game.Session.Village.Buildings.ResearchAcademy.Attribute / (float)100)) * 10).ToString() + "</li></ul>";
                    else
                        CataLiteral.Text = "Not enough resources.";
                }
                else
                    CataLiteral.Text = "Unit researched.";
            }
            else
                CataLiteral.Text = "Requirements not met.";
            #endregion


            if (!Page.IsPostBack)
            {
                TitleLabel.Text = "Research Academy Level " + Game.Session.Village.Buildings.ResearchAcademy.Level.ToString();
                TimeBonus.Text = Game.Session.Village.Buildings.ResearchAcademy.Attribute.ToString() + "%";
                foreach (Construction construction in Game.Session.Village.Constructions)
                {
                    if (construction.Building == "academy")
                        upgrades++;
                }
                if (Objects.Building.Exists("academy", Game.Session.Village.Buildings.ResearchAcademy.Level + upgrades + 1))
                {
                    Objects.Building upgraded = Objects.Building.GetBuilding("academy", Game.Session.Village.Buildings.ResearchAcademy.Level + upgrades + 1);
                    UpgradedTimeBonus.Text = upgraded.Attribute.ToString() + "%";
                    AtLevelLabel.Text = "Research cost multiplier at level " + upgraded.Level.ToString() + ".";
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
                    UpgradedTimeBonus.Text = Objects.Building.GetBuilding("academy", Game.Session.Village.Buildings.ResearchAcademy.Level + upgrades).Attribute.ToString() + "%";
                    AtLevelLabel.Text = "Research Academy at maximum level.";
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            foreach (Construction construction in Game.Session.Village.Constructions)
            {
                if (construction.Building == "academy")
                    upgrades++;
            }
            Construction.NewConsutrction(Game.Session.Village, "academy", Game.Session.Village.Buildings.ResearchAcademy.Level + upgrades + 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void SpearmanResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("spear");
            if (!AJSGame.Game.Session.Village.Research.Spearman && AJSGame.Core.Functions.RequirementsResearch("spear", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("spear", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void SwordsmanResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("sword");
            if (!AJSGame.Game.Session.Village.Research.Swordsman && AJSGame.Core.Functions.RequirementsResearch("sword", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("sword", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void AxemanResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("axe");
            if (!AJSGame.Game.Session.Village.Research.Axeman && AJSGame.Core.Functions.RequirementsResearch("axe", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("axe", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void LightResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("light");
            if (!AJSGame.Game.Session.Village.Research.LightCavalry && AJSGame.Core.Functions.RequirementsResearch("light", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("light", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void HeavyResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("heavy");
            if (!AJSGame.Game.Session.Village.Research.HeavyCavalry && AJSGame.Core.Functions.RequirementsResearch("heavy", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("heavy", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ScoutResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("scout");
            if (!AJSGame.Game.Session.Village.Research.Scout && AJSGame.Core.Functions.RequirementsResearch("scout", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("scout", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void RamResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("ram");
            if (!AJSGame.Game.Session.Village.Research.BatteringRam && AJSGame.Core.Functions.RequirementsResearch("ram", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("ram", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void CataResearch_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Unit data = Objects.Unit.GetUnit("cata");
            if (!AJSGame.Game.Session.Village.Research.Catapult && AJSGame.Core.Functions.RequirementsResearch("cata", AJSGame.Game.Session.Village) && Functions.RequirementsResources(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10, Game.Session.Village))
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("cata", 1);
                hashtable = SQL.UpdateData("villageresearch", "vref = '" + Game.Session.Village.ID + "'", hashtable);
                Game.Session.Village.ResourcesRemove(data.Wood * 10, data.Clay * 10, data.Metal * 10, data.Food * 10);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}