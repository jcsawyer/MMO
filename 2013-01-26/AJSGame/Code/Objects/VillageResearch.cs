using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class VillageResearch
    {
        #region Properties

        public bool Spearman { get; set; }
        public bool Swordsman { get; set; }
        public bool Axeman { get; set; }
        public bool LightCavalry { get; set; }
        public bool HeavyCavalry { get; set; }
        public bool Scout { get; set; }
        public bool BatteringRam { get; set; }
        public bool Catapult { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, VillageResearch research)
        {
            research.Spearman = Convert.ToBoolean(dr["spear"]);
            research.Swordsman = Convert.ToBoolean(dr["sword"]);
            research.Axeman = Convert.ToBoolean(dr["axe"]);
            research.LightCavalry = Convert.ToBoolean(dr["light"]);
            research.HeavyCavalry = Convert.ToBoolean(dr["heavy"]);
            research.Scout = Convert.ToBoolean(dr["scout"]);
            research.BatteringRam = Convert.ToBoolean(dr["ram"]);
            research.Catapult = Convert.ToBoolean(dr["cata"]);
        }

        #endregion

        #region Public Static Methods

        public static VillageResearch GetVillageResearch(int vref)
        {
            VillageResearch result = new VillageResearch();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villageresearch WHERE vref = '" + vref + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static bool NewVillageResearch(int vref)
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
            hashtable = SQL.InsertData("villageresearch", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        #endregion
    }
}
