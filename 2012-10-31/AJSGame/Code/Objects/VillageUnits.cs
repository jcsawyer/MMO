using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class VillageUnits
    {
        #region Properties

        public int Village { get; set; }
        public int Spearman { get; set; }
        public int Swordsman { get; set; }
        public int Axeman { get; set; }
        public int LightCavalry { get; set; }
        public int HeavyCavalry { get; set; }
        public int Scout { get; set; }
        public int BatteringRam { get; set; }
        public int Catapult { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, VillageUnits units)
        {
            units.Village = Convert.ToInt32(dr["vref"]);
            units.Spearman = Convert.ToInt32(dr["spear"]);
            units.Swordsman = Convert.ToInt32(dr["sword"]);
            units.Axeman = Convert.ToInt32(dr["axe"]);
            units.LightCavalry = Convert.ToInt32(dr["light"]);
            units.HeavyCavalry = Convert.ToInt32(dr["heavy"]);
            units.Scout = Convert.ToInt32(dr["scout"]);
            units.BatteringRam = Convert.ToInt32(dr["ram"]);
            units.Catapult = Convert.ToInt32(dr["cata"]);
        }

        #endregion

        #region Public Methods

        public void Update(string mode, int spear, int sword, int axe, int scout, int light, int heavy, int ram, int cata)
        {
            UpdateVillageUnits(this, mode, spear, sword, axe, scout, light, heavy, ram, cata);
        }

        #endregion

        #region Public Static Methods

        public static VillageUnits GetVillageUnits(int vref)
        {
            VillageUnits result = new VillageUnits();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villageunits WHERE vref = '" + vref + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static bool NewVillageUnits(int vref)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("vref", vref);
            hashtable.Add("spear", 0);
            hashtable.Add("sword", 0);
            hashtable.Add("axe", 0);
            hashtable.Add("light", 0);
            hashtable.Add("heavy", 0);
            hashtable.Add("scout", 0);
            hashtable.Add("ram", 0);
            hashtable.Add("cata", 0);
            hashtable = SQL.InsertData("villageunits", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void UpdateVillageUnits(VillageUnits villageUnits, string mode, int spear, int sword, int axe, int scout, int light, int heavy, int ram, int cata)
        {
            Hashtable hashtable = new Hashtable();
            if (mode == "add")
            {
                hashtable.Add("spear", villageUnits.Spearman + spear);
                hashtable.Add("sword", villageUnits.Swordsman + sword);
                hashtable.Add("axe", villageUnits.Axeman + axe);
                hashtable.Add("scout", villageUnits.Scout + scout);
                hashtable.Add("light", villageUnits.LightCavalry + light);
                hashtable.Add("heavy", villageUnits.HeavyCavalry + heavy);
                hashtable.Add("ram", villageUnits.BatteringRam + ram);
                hashtable.Add("cata", villageUnits.Catapult + cata);
            }
            else if (mode == "remove")
            {
                hashtable.Add("spear", villageUnits.Spearman - spear);
                hashtable.Add("sword", villageUnits.Swordsman - sword);
                hashtable.Add("axe", villageUnits.Axeman - axe);
                hashtable.Add("scout", villageUnits.Scout - scout);
                hashtable.Add("light", villageUnits.LightCavalry - light);
                hashtable.Add("heavy", villageUnits.HeavyCavalry - heavy);
                hashtable.Add("ram", villageUnits.BatteringRam - ram);
                hashtable.Add("cata", villageUnits.Catapult - cata);
            }
            hashtable = SQL.UpdateData("villageunits", "vref = '" + villageUnits.Village + "'", hashtable);
        }

        #endregion
    }
}
