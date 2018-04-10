using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Training
    {
        #region Properties

        public int ID { get; set; }
        public int Village { get; set; }
        public string Unit { get; set; }
        public int Ammount { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Time { get; set; }
        public string Type { get; set; }

        public TimeSpan TimeLeft { get; set; }
        public TimeSpan TimeLeftNext { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Training training)
        {
            training.ID = Convert.ToInt32(dr["id"]);
            training.Village = Convert.ToInt32(dr["vref"]);
            training.Unit = dr["unit"].ToString();
            training.Ammount = Convert.ToInt32(dr["ammount"]);
            training.Start = Convert.ToDateTime(dr["start"]);
            training.Time = TimeSpan.Parse(dr["time"].ToString());
            training.Type = dr["type"].ToString();

            training.TimeLeft = Functions.TimeLeftMulti(training.Ammount, training.Time, training.Start);
            training.TimeLeftNext = Functions.TimeLeftMultiNext(training.Start, training.Time);
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteTraining(this);
            this.ID = 0;
        }

        public void Update(int ammount)
        {
            UpdateTraining(this, ammount);
        }

        #endregion

        #region Public Static Methods

        public static List<Training> GetTraining()
        {
            List<Training> result = new List<Training>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM training");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Training training = new Training();
                    Fill(dr, training);
                    result.Add(training);
                }
            }
            return result;
        }

        public static List<Training> GetTrainings(string where)
        {
            List<Training> result = new List<Training>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM training WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Training training = new Training();
                    Fill(dr, training);
                    result.Add(training);
                }
            }
            return result;
        }

        public static void DeleteTraining(Training training)
        {
            Hashtable hashtable = SQL.DeleteData("training", "id = '" + training.ID + "'");
        }

        public static void NewTraining(Objects.Village vref, string unit, int ammount)
        {
            Objects.Unit data = Objects.Unit.GetUnit(unit);
            Hashtable hashtable = new Hashtable();
            hashtable.Add("vref", vref.ID);
            hashtable.Add("unit", unit);
            hashtable.Add("ammount", ammount);
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < Game.Session.Village.Training.Count; i++)
            {
                Objects.Unit trainUnit = Objects.Unit.GetUnit(Game.Session.Village.Training[i].Unit);
                if (data.Type == "infantry")
                {
                    if (trainUnit.Type == "infantry")
                    {
                        start = DateTime.UtcNow;
                        start = start.Add(Game.Session.Village.Training[i].TimeLeft);
                    }
                }
                if (data.Type == "cavalry")
                {
                    if (trainUnit.Type == "cavalry")
                    {
                        start = DateTime.UtcNow;
                        start = start.Add(Game.Session.Village.Training[i].TimeLeft);
                    }
                }
                if (data.Type == "siege")
                {
                    if (trainUnit.Type == "siege")
                    {
                        start = DateTime.UtcNow;
                        start = start.Add(Game.Session.Village.Training[i].TimeLeft);
                    }
                }
            }
            hashtable.Add("start", start);
            hashtable.Add("time", Functions.TimeReducedRecruitment(vref, data.Time, data.Type));
            Objects.Unit unitTrain = Objects.Unit.GetUnit(unit);
            hashtable.Add("type", unitTrain.Type);
            hashtable = SQL.InsertData("training", hashtable);
            vref.ResourcesRemove(data.Wood * ammount, data.Clay * ammount, data.Metal * ammount, data.Food * ammount);
        }

        public static void UpdateTraining(Training training, int ammount)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("ammount", training.Ammount - ammount);
            hashtable.Add("start", Functions.DateString(DateTime.UtcNow));
            hashtable = SQL.UpdateData("training", "id = '" + training.ID + "'", hashtable);

            training.Ammount = training.Ammount - ammount;
        }

        #endregion
    }
}