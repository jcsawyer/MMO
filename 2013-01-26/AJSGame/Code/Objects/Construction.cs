using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Construction
    {
        #region Properites

        public int ID { get; set; }
        public int Village { get; set; }
        public string Building { get; set; }
        public int ToLevel { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public TimeSpan TimeLeft { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Construction construction)
        {
            construction.ID = Convert.ToInt32(dr["id"]);
            construction.Village = Convert.ToInt32(dr["vref"]);
            construction.Building = dr["building"].ToString();
            construction.ToLevel = Convert.ToInt32(dr["tolevel"]);
            construction.Start = Convert.ToDateTime(dr["start"]);
            construction.Finish = Convert.ToDateTime(dr["finish"]);

            construction.TimeLeft = Functions.TimeLeft(construction.Finish);
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteConstruction(this);
            this.ID = 0;
        }

        #endregion

        #region Public Static Methods

        public static List<Construction> GetConstructions()
        {
            List<Construction> result = new List<Construction>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM constructions");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Construction construction = new Construction();
                    Fill(dr, construction);
                    result.Add(construction);
                }
            }
            return result;
        }

        public static List<Construction> GetConstructions(string where)
        {
            List<Construction> result = new List<Construction>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM constructions WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Construction construction = new Construction();
                    Fill(dr, construction);
                    result.Add(construction);
                }
            }
            return result;
        }

        public static void DeleteConstruction(Construction construction)
        {
            Hashtable hashtable = SQL.DeleteData("constructions", "id = '" + construction.ID + "'");
        }

        public static void NewConsutrction(Objects.Village vref, string building, int tolevel)
        {
            Objects.Building data = Objects.Building.GetBuilding(building, tolevel);
            Hashtable hashtable = new Hashtable();
            hashtable.Add("vref", vref.ID);
            hashtable.Add("building", building);
            hashtable.Add("tolevel", tolevel);
            DateTime start = DateTime.UtcNow;
            if (vref.Constructions.Count > 0)
                start = vref.Constructions[vref.Constructions.Count - 1].Finish;
            hashtable.Add("start", Functions.DateString(start));
            hashtable.Add("finish", Functions.DateString(start.Add(Functions.TimeReducedBuilding(vref, data.Time))));
            hashtable = SQL.InsertData("constructions", hashtable);
            vref.ResourcesRemove(data.Wood, data.Clay, data.Metal, data.Food);
        }

        #endregion
    }
}