using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class VillageBuildings
    {
        #region Properties

        public Building MainBuilding { get; set; }
        public Building Timbercamp { get; set; }
        public Building Claypit { get; set; }
        public Building Mine { get; set; }
        public Building Farm { get; set; }
        public Building Warehouse { get; set; }
        public Building Granary { get; set; }
        public Building Barracks { get; set; }
        public Building Stable { get; set; }
        public Building ResearchAcademy { get; set; }
        public Building SiegeWorkshop { get; set; }
        public Building Wall { get; set; }
        public Building Market { get; set; }
        public Building RallyPoint { get; set; }
        public Building Shelter { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, VillageBuildings buildings)
        {
            buildings.MainBuilding = Building.GetBuilding("main", Convert.ToInt32(dr["main"]));
            buildings.Timbercamp = Building.GetBuilding("timbercamp", Convert.ToInt32(dr["timbercamp"]));
            buildings.Claypit = Building.GetBuilding("claypit", Convert.ToInt32(dr["claypit"]));
            buildings.Mine = Building.GetBuilding("mine", Convert.ToInt32(dr["mine"]));
            buildings.Farm = Building.GetBuilding("farm", Convert.ToInt32(dr["farm"]));
            buildings.Warehouse = Building.GetBuilding("warehouse", Convert.ToInt32(dr["warehouse"]));
            buildings.Granary = Building.GetBuilding("granary", Convert.ToInt32(dr["granary"]));
            buildings.Barracks = Building.GetBuilding("barracks", Convert.ToInt32(dr["barracks"]));
            buildings.Stable = Building.GetBuilding("stable", Convert.ToInt32(dr["stable"]));
            buildings.ResearchAcademy = Building.GetBuilding("academy", Convert.ToInt32(dr["academy"]));
            buildings.SiegeWorkshop = Building.GetBuilding("workshop", Convert.ToInt32(dr["workshop"]));
            buildings.Wall = Building.GetBuilding("wall", Convert.ToInt32(dr["wall"]));
            buildings.Market = Building.GetBuilding("market", Convert.ToInt32(dr["market"]));
            buildings.RallyPoint = Building.GetBuilding("rally", Convert.ToInt32(dr["rally"]));
            buildings.Shelter = Building.GetBuilding("shelter", Convert.ToInt32(dr["shelter"]));
        }

        #endregion

        #region Public Methods

        public void UpdateLevel(Objects.Village village, string building)
        {
            VillageBuildings.UpdateVillageBuildingLevel(village, building);
        }

        #endregion

        #region Public Static Methods

        public static VillageBuildings GetVillageBuildings(int vref)
        {
            VillageBuildings result = new VillageBuildings();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villagebuildings WHERE vref = '" + vref + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static bool NewVillageBuildings(int vref)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("vref", vref);
            hashtable.Add("main", 0);
            hashtable.Add("timbercamp", 0);
            hashtable.Add("claypit", 0);
            hashtable.Add("mine", 0);
            hashtable.Add("farm", 0);
            hashtable.Add("warehouse", 0);
            hashtable.Add("granary", 0);
            hashtable.Add("barracks", 0);
            hashtable.Add("stable", 0);
            hashtable.Add("academy", 0);
            hashtable.Add("workshop", 0);
            hashtable.Add("wall", 0);
            hashtable.Add("market", 0);
            hashtable.Add("rally", 0);
            hashtable.Add("shelter", 0);
            hashtable = SQL.InsertData("villagebuildings", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void UpdateVillageBuildingLevel(Village village, string building)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(building, building + " + 1");
            hashtable = SQL.SimpleUpdate("villagebuildings", "vref = '" + village.ID + "'", building + " = " + building + " + 1");
        }

        #endregion
    }
}
