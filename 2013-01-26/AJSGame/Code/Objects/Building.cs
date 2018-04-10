using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Building
    {
        #region Properties

        public string Name { get; set; }
        public int Level { get; set; }
        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Metal { get; set; }
        public int Food { get; set; }
        public TimeSpan Time { get; set; }
        public int Attribute { get; set; }
        public int Points { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Building building)
        {
            building.Name = dr["name"].ToString();
            building.Level = Convert.ToInt32(dr["level"]);
            building.Wood = Convert.ToInt32(dr["wood"]);
            building.Clay = Convert.ToInt32(dr["clay"]);
            building.Metal = Convert.ToInt32(dr["metal"]);
            building.Food = Convert.ToInt32(dr["food"]);
            building.Time = TimeSpan.Parse(dr["time"].ToString());
            building.Attribute = Convert.ToInt32(dr["attribute"]);
            building.Points = Convert.ToInt32(dr["points"]);
        }

        #endregion

        #region Public Static Methods

        public static Building GetBuilding(string building, int level)
        {
            Building result = new Building();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM buildings WHERE name = '" + building + "' AND level = '" + level + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static bool Exists(string building, int level)
        {
            bool result;
            result = SQL.Exists("buildings", "name = '" + building + "' AND level = '" + level + "'");
            return result;
        }

        #endregion
    }
}
