using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;

namespace AJSGame
{
    public partial class Village : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsutrctionsGridView.DataSource = AJSGame.Game.Session.Village.Constructions;
            ConsutrctionsGridView.DataBind();

            if (ConsutrctionsGridView.Rows.Count == 0)
                ConstructionsLiteral.Visible = false;

            Objects.Village village = Game.Session.Village;

            MainBuildingHyperLink.Visible = Functions.RequirementsBuilding("main", village);
            TimbercampHyperLink.Visible = Functions.RequirementsBuilding("timbercamp", village);
            ClaypitHyperLink.Visible = Functions.RequirementsBuilding("claypit", village);
            MineHyperLink.Visible = Functions.RequirementsBuilding("mine", village);
            FarmHyperLink.Visible = Functions.RequirementsBuilding("farm", village);
            WarehouseHyperLink.Visible = Functions.RequirementsBuilding("warehouse", village);
            GranaryHyperLink.Visible = Functions.RequirementsBuilding("granary", village);
            BarracksHyperLink.Visible = Functions.RequirementsBuilding("barracks", village);
            StableHyperLink.Visible = Functions.RequirementsBuilding("stable", village);
            ResearchAcademyHyperLink.Visible = Functions.RequirementsBuilding("academy", village);
            SiegeWorkshopHyperLink.Visible = Functions.RequirementsBuilding("workshop", village);
            WallHyperLink.Visible = Functions.RequirementsBuilding("wall", village);
            RallyPointHyperLink.Visible = Functions.RequirementsBuilding("rally", village);
            ShelterHyperLink.Visible = Functions.RequirementsBuilding("shelter", village);

            if (village.Units.Spearman > 0)
                SpearmanLabel.Text = village.Units.Spearman + " Spearman<br />";
            if (village.Units.Swordsman > 0)
                SwordsmanLabel.Text = village.Units.Swordsman + " Swordsman<br />";
            if (village.Units.Axeman > 0)
                AxemanLabel.Text = village.Units.Axeman + " Axeman<br />";
            if (village.Units.LightCavalry > 0)
                LightCavalryLabel.Text = village.Units.LightCavalry + " Light Cavalry<br />";
            if (village.Units.HeavyCavalry > 0)
                HeavyCavalryLabel.Text = village.Units.HeavyCavalry + " Heavy Cavalry<br />";
            if (village.Units.Scout > 0)
                ScoutLabel.Text = village.Units.Scout + " Scout<br />";
            if (village.Units.BatteringRam > 0)
                BatteringRamLabel.Text = village.Units.BatteringRam + " Battering Ram<br />";
            if (village.Units.Catapult > 0)
                CatapultLabel.Text = village.Units.Catapult + " Catapult<br />";
        }
    }
}