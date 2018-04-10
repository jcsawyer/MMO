using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Unit
    {
        #region Properties

        public string Name { get; set; }
        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Metal { get; set; }
        public int Food { get; set; }
        public TimeSpan Time { get; set; }
        public int Population { get; set; }
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int DefenceCav { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Unit unit)
        {
            unit.Name = dr["name"].ToString();
            unit.Wood = Convert.ToInt32(dr["wood"]);
            unit.Clay = Convert.ToInt32(dr["clay"]);
            unit.Metal = Convert.ToInt32(dr["metal"]);
            unit.Food = Convert.ToInt32(dr["food"]);
            unit.Time = TimeSpan.Parse(dr["time"].ToString());
            unit.Population = Convert.ToInt32(dr["population"]);
            unit.Speed = Convert.ToInt32(dr["speed"]);
            unit.Attack = Convert.ToInt32(dr["attack"]);
            unit.Defence = Convert.ToInt32(dr["defence"]);
            unit.DefenceCav = Convert.ToInt32(dr["defencecav"]);
            unit.Type = dr["type"].ToString();
            unit.Capacity = Convert.ToInt32(dr["capacity"]);
        }

        #endregion

        #region Public Static Methods

        public static Unit GetUnit(string unit)
        {
            Unit result = new Unit();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM units WHERE name = '" + unit + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static List<Unit> GetUnits()
        {
            List<Unit> result = new List<Unit>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM units");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Unit unit = new Unit();
                    Fill(dr, unit);
                    result.Add(unit);
                }
            }
            return result;
        }

        public static List<Unit> GetUnits(string where)
        {
            List<Unit> result = new List<Unit>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM units WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Unit unit = new Unit();
                    Fill(dr, unit);
                    result.Add(unit);
                }
            }
            return result;
        }

        #endregion
    }
}