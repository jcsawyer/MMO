using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Movement
    {
        #region Properties

        public int ID { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Spearman { get; set; }
        public int Swordsman { get; set; }
        public int Axeman { get; set; }
        public int Scout { get; set; }
        public int LightCavalry { get; set; }
        public int HeavyCavalry { get; set; }
        public int BatteringRam { get; set; }
        public int Catapult { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Metal { get; set; }
        public int Food { get; set; }
        public string Type { get; set; }

        public int AttackerStrength { get; set; }
        public int AttackerDefence { get; set; }
        public int AttackerCavDefence { get; set; }
        public int AttackerScout { get; set; }
        public int DefenderStrength { get; set; }
        public int DefenderDefence { get; set; }
        public int DefenderCavDefence { get; set; }
        public int DefenderScout { get; set; }
        public int Capacity { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Movement movement)
        {
            movement.ID = Convert.ToInt32(dr["id"]);
            movement.From = Convert.ToInt32(dr["fromvillage"]);
            movement.To = Convert.ToInt32(dr["tovillage"]);
            movement.Spearman = Convert.ToInt32(dr["spear"]);
            movement.Swordsman = Convert.ToInt32(dr["sword"]);
            movement.Axeman = Convert.ToInt32(dr["axe"]);
            movement.Scout = Convert.ToInt32(dr["scout"]);
            movement.LightCavalry = Convert.ToInt32(dr["light"]);
            movement.HeavyCavalry = Convert.ToInt32(dr["heavy"]);
            movement.BatteringRam = Convert.ToInt32(dr["ram"]);
            movement.Catapult = Convert.ToInt32(dr["cata"]);
            movement.Start = Convert.ToDateTime(dr["start"]);
            movement.Finish = Convert.ToDateTime(dr["finish"]);
            movement.Wood = Convert.ToInt32(dr["wood"]);
            movement.Clay = Convert.ToInt32(dr["clay"]);
            movement.Metal = Convert.ToInt32(dr["metal"]);
            movement.Food = Convert.ToInt32(dr["food"]);
            movement.Type = dr["type"].ToString();
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteMovement(this);
            this.ID = 0;
        }

        // TODO : Return movement if mistake was made

        #endregion

        #region Public Static Methods

        public static Movement GetMovement(int id)
        {
            AJSGame.Objects.Unit StatsSpear = AJSGame.Objects.Unit.GetUnit("spear");
            AJSGame.Objects.Unit StatsSword = AJSGame.Objects.Unit.GetUnit("sword");
            AJSGame.Objects.Unit StatsAxe = AJSGame.Objects.Unit.GetUnit("axe");
            AJSGame.Objects.Unit StatsScout = AJSGame.Objects.Unit.GetUnit("scout");
            AJSGame.Objects.Unit StatsLight = AJSGame.Objects.Unit.GetUnit("light");
            AJSGame.Objects.Unit StatsHeavy = AJSGame.Objects.Unit.GetUnit("heavy");
            AJSGame.Objects.Unit StatsRam = AJSGame.Objects.Unit.GetUnit("ram");
            AJSGame.Objects.Unit StatsCata = AJSGame.Objects.Unit.GetUnit("cata");

            Movement result = new Movement();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM movements WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);

            AJSGame.Objects.Village defender = AJSGame.Objects.Village.GetVillage(result.To);

            result.AttackerStrength = (StatsSpear.Attack * result.Spearman) + (StatsSword.Attack * result.Swordsman) + (StatsAxe.Attack * result.Axeman) + (StatsScout.Attack * result.Scout) + (StatsLight.Attack * result.LightCavalry) + (StatsHeavy.Attack * result.HeavyCavalry) + (StatsRam.Attack * result.BatteringRam) + (StatsCata.Attack * result.Catapult);
            result.AttackerDefence = (StatsSpear.Defence * result.Spearman) + (StatsSword.Defence * result.Swordsman) + (StatsAxe.Defence * result.Axeman) + (StatsScout.Defence * result.Scout) + (StatsLight.Defence * result.LightCavalry) + (StatsHeavy.Defence * result.HeavyCavalry) + (StatsRam.Defence * result.BatteringRam) + (StatsCata.Defence * result.Catapult);
            result.AttackerCavDefence = (StatsSpear.DefenceCav * result.Spearman) + (StatsSword.DefenceCav * result.Swordsman) + (StatsAxe.DefenceCav * result.Axeman) + (StatsScout.DefenceCav * result.Scout) + (StatsLight.DefenceCav * result.LightCavalry) + (StatsHeavy.DefenceCav * result.HeavyCavalry) + (StatsRam.DefenceCav * result.BatteringRam) + (StatsCata.DefenceCav * result.Catapult);
            result.AttackerScout = (StatsScout.Attack * result.Scout);
            result.DefenderStrength = (StatsSpear.Attack * defender.Units.Spearman) + (StatsSword.Attack * defender.Units.Swordsman) + (StatsAxe.Attack * defender.Units.Axeman) + (StatsScout.Attack * defender.Units.Scout) + (StatsLight.Attack * defender.Units.LightCavalry) + (StatsHeavy.Attack * defender.Units.HeavyCavalry) + (StatsRam.Attack * defender.Units.BatteringRam) + (StatsCata.Attack * defender.Units.Catapult);
            result.DefenderDefence = (StatsSpear.Defence * defender.Units.Spearman) + (StatsSword.Defence * defender.Units.Swordsman) + (StatsAxe.Defence * defender.Units.Axeman) + (StatsScout.Defence * defender.Units.Scout) + (StatsLight.Defence * defender.Units.LightCavalry) + (StatsHeavy.Defence * defender.Units.HeavyCavalry) + (StatsRam.Defence * defender.Units.BatteringRam) + (StatsCata.Defence * defender.Units.Catapult);
            result.DefenderCavDefence = (StatsSpear.DefenceCav * defender.Units.Spearman) + (StatsSword.DefenceCav * defender.Units.Swordsman) + (StatsAxe.DefenceCav * defender.Units.Axeman) + (StatsScout.DefenceCav * defender.Units.Scout) + (StatsLight.DefenceCav * defender.Units.LightCavalry) + (StatsHeavy.DefenceCav * defender.Units.HeavyCavalry) + (StatsRam.DefenceCav * defender.Units.BatteringRam) + (StatsCata.DefenceCav * defender.Units.Catapult);
            result.DefenderScout = (StatsScout.Defence * result.Scout);
            result.Capacity = (StatsSpear.Capacity * result.Spearman) + (StatsSword.Capacity * result.Swordsman) + (StatsAxe.Capacity * result.Axeman) + (StatsScout.Capacity * result.Scout) + (StatsLight.Capacity * result.LightCavalry) + (StatsHeavy.Capacity * result.HeavyCavalry) + (StatsRam.Capacity * result.BatteringRam) + (StatsCata.Capacity * result.Catapult);

            return result;
        }

        public static List<Movement> GetMovements()
        {
            AJSGame.Objects.Unit StatsSpear = AJSGame.Objects.Unit.GetUnit("spear");
            AJSGame.Objects.Unit StatsSword = AJSGame.Objects.Unit.GetUnit("sword");
            AJSGame.Objects.Unit StatsAxe = AJSGame.Objects.Unit.GetUnit("axe");
            AJSGame.Objects.Unit StatsScout = AJSGame.Objects.Unit.GetUnit("scout");
            AJSGame.Objects.Unit StatsLight = AJSGame.Objects.Unit.GetUnit("light");
            AJSGame.Objects.Unit StatsHeavy = AJSGame.Objects.Unit.GetUnit("heavy");
            AJSGame.Objects.Unit StatsRam = AJSGame.Objects.Unit.GetUnit("ram");
            AJSGame.Objects.Unit StatsCata = AJSGame.Objects.Unit.GetUnit("cata");

            List<Movement> result = new List<Movement>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM movements ORDER BY finish DESC");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Movement movement = new Movement();
                    Fill(dr, movement);
                    AJSGame.Objects.Village defender = AJSGame.Objects.Village.GetVillage(movement.To);

                    movement.AttackerStrength = (StatsSpear.Attack * movement.Spearman) + (StatsSword.Attack * movement.Swordsman) + (StatsAxe.Attack * movement.Axeman) + (StatsScout.Attack * movement.Scout) + (StatsLight.Attack * movement.LightCavalry) + (StatsHeavy.Attack * movement.HeavyCavalry) + (StatsRam.Attack * movement.BatteringRam) + (StatsCata.Attack * movement.Catapult);
                    movement.AttackerDefence = (StatsSpear.Defence * movement.Spearman) + (StatsSword.Defence * movement.Swordsman) + (StatsAxe.Defence * movement.Axeman) + (StatsScout.Defence * movement.Scout) + (StatsLight.Defence * movement.LightCavalry) + (StatsHeavy.Defence * movement.HeavyCavalry) + (StatsRam.Defence * movement.BatteringRam) + (StatsCata.Defence * movement.Catapult);
                    movement.AttackerCavDefence = (StatsSpear.DefenceCav * movement.Spearman) + (StatsSword.DefenceCav * movement.Swordsman) + (StatsAxe.DefenceCav * movement.Axeman) + (StatsScout.DefenceCav * movement.Scout) + (StatsLight.DefenceCav * movement.LightCavalry) + (StatsHeavy.DefenceCav * movement.HeavyCavalry) + (StatsRam.DefenceCav * movement.BatteringRam) + (StatsCata.DefenceCav * movement.Catapult);
                    movement.AttackerScout = (StatsScout.Attack * movement.Scout);
                    movement.DefenderStrength = (StatsSpear.Attack * defender.Units.Spearman) + (StatsSword.Attack * defender.Units.Swordsman) + (StatsAxe.Attack * defender.Units.Axeman) + (StatsScout.Attack * defender.Units.Scout) + (StatsLight.Attack * defender.Units.LightCavalry) + (StatsHeavy.Attack * defender.Units.HeavyCavalry) + (StatsRam.Attack * defender.Units.BatteringRam) + (StatsCata.Attack * defender.Units.Catapult);
                    movement.DefenderDefence = (StatsSpear.Defence * defender.Units.Spearman) + (StatsSword.Defence * defender.Units.Swordsman) + (StatsAxe.Defence * defender.Units.Axeman) + (StatsScout.Defence * defender.Units.Scout) + (StatsLight.Defence * defender.Units.LightCavalry) + (StatsHeavy.Defence * defender.Units.HeavyCavalry) + (StatsRam.Defence * defender.Units.BatteringRam) + (StatsCata.Defence * defender.Units.Catapult);
                    movement.DefenderCavDefence = (StatsSpear.DefenceCav * defender.Units.Spearman) + (StatsSword.DefenceCav * defender.Units.Swordsman) + (StatsAxe.DefenceCav * defender.Units.Axeman) + (StatsScout.DefenceCav * defender.Units.Scout) + (StatsLight.DefenceCav * defender.Units.LightCavalry) + (StatsHeavy.DefenceCav * defender.Units.HeavyCavalry) + (StatsRam.DefenceCav * defender.Units.BatteringRam) + (StatsCata.DefenceCav * defender.Units.Catapult);
                    movement.DefenderScout = (StatsScout.Defence * movement.Scout);
                    movement.Capacity = (StatsSpear.Capacity * movement.Spearman) + (StatsSword.Capacity * movement.Swordsman) + (StatsAxe.Capacity * movement.Axeman) + (StatsScout.Capacity * movement.Scout) + (StatsLight.Capacity * movement.LightCavalry) + (StatsHeavy.Capacity * movement.HeavyCavalry) + (StatsRam.Capacity * movement.BatteringRam) + (StatsCata.Capacity * movement.Catapult);

                    result.Add(movement);
                }
            }
            return result;
        }

        public static List<Movement> GetMovements(string where)
        {
            AJSGame.Objects.Unit StatsSpear = AJSGame.Objects.Unit.GetUnit("spear");
            AJSGame.Objects.Unit StatsSword = AJSGame.Objects.Unit.GetUnit("sword");
            AJSGame.Objects.Unit StatsAxe = AJSGame.Objects.Unit.GetUnit("axe");
            AJSGame.Objects.Unit StatsScout = AJSGame.Objects.Unit.GetUnit("scout");
            AJSGame.Objects.Unit StatsLight = AJSGame.Objects.Unit.GetUnit("light");
            AJSGame.Objects.Unit StatsHeavy = AJSGame.Objects.Unit.GetUnit("heavy");
            AJSGame.Objects.Unit StatsRam = AJSGame.Objects.Unit.GetUnit("ram");
            AJSGame.Objects.Unit StatsCata = AJSGame.Objects.Unit.GetUnit("cata");

            List<Movement> result = new List<Movement>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM movements WHERE " + where + " ORDER BY finish DESC");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Movement movement = new Movement();
                    Fill(dr, movement);
                    AJSGame.Objects.Village defender = AJSGame.Objects.Village.GetVillage(movement.To);

                    movement.AttackerStrength = (StatsSpear.Attack * movement.Spearman) + (StatsSword.Attack * movement.Swordsman) + (StatsAxe.Attack * movement.Axeman) + (StatsScout.Attack * movement.Scout) + (StatsLight.Attack * movement.LightCavalry) + (StatsHeavy.Attack * movement.HeavyCavalry) + (StatsRam.Attack * movement.BatteringRam) + (StatsCata.Attack * movement.Catapult);
                    movement.AttackerDefence = (StatsSpear.Defence * movement.Spearman) + (StatsSword.Defence * movement.Swordsman) + (StatsAxe.Defence * movement.Axeman) + (StatsScout.Defence * movement.Scout) + (StatsLight.Defence * movement.LightCavalry) + (StatsHeavy.Defence * movement.HeavyCavalry) + (StatsRam.Defence * movement.BatteringRam) + (StatsCata.Defence * movement.Catapult);
                    movement.AttackerCavDefence = (StatsSpear.DefenceCav * movement.Spearman) + (StatsSword.DefenceCav * movement.Swordsman) + (StatsAxe.DefenceCav * movement.Axeman) + (StatsScout.DefenceCav * movement.Scout) + (StatsLight.DefenceCav * movement.LightCavalry) + (StatsHeavy.DefenceCav * movement.HeavyCavalry) + (StatsRam.DefenceCav * movement.BatteringRam) + (StatsCata.DefenceCav * movement.Catapult);
                    movement.AttackerScout = (StatsScout.Attack * movement.Scout);
                    movement.DefenderStrength = (StatsSpear.Attack * defender.Units.Spearman) + (StatsSword.Attack * defender.Units.Swordsman) + (StatsAxe.Attack * defender.Units.Axeman) + (StatsScout.Attack * defender.Units.Scout) + (StatsLight.Attack * defender.Units.LightCavalry) + (StatsHeavy.Attack * defender.Units.HeavyCavalry) + (StatsRam.Attack * defender.Units.BatteringRam) + (StatsCata.Attack * defender.Units.Catapult);
                    movement.DefenderDefence = (StatsSpear.Defence * defender.Units.Spearman) + (StatsSword.Defence * defender.Units.Swordsman) + (StatsAxe.Defence * defender.Units.Axeman) + (StatsScout.Defence * defender.Units.Scout) + (StatsLight.Defence * defender.Units.LightCavalry) + (StatsHeavy.Defence * defender.Units.HeavyCavalry) + (StatsRam.Defence * defender.Units.BatteringRam) + (StatsCata.Defence * defender.Units.Catapult);
                    movement.DefenderCavDefence = (StatsSpear.DefenceCav * defender.Units.Spearman) + (StatsSword.DefenceCav * defender.Units.Swordsman) + (StatsAxe.DefenceCav * defender.Units.Axeman) + (StatsScout.DefenceCav * defender.Units.Scout) + (StatsLight.DefenceCav * defender.Units.LightCavalry) + (StatsHeavy.DefenceCav * defender.Units.HeavyCavalry) + (StatsRam.DefenceCav * defender.Units.BatteringRam) + (StatsCata.DefenceCav * defender.Units.Catapult);
                    movement.DefenderScout = (StatsScout.Defence * movement.Scout);
                    movement.Capacity = (StatsSpear.Capacity * movement.Spearman) + (StatsSword.Capacity * movement.Swordsman) + (StatsAxe.Capacity * movement.Axeman) + (StatsScout.Capacity * movement.Scout) + (StatsLight.Capacity * movement.LightCavalry) + (StatsHeavy.Capacity * movement.HeavyCavalry) + (StatsRam.Capacity * movement.BatteringRam) + (StatsCata.Capacity * movement.Catapult);

                    result.Add(movement);
                }
            }
            return result;
        }

        public static bool NewMovement(int fromVillage, int toVillage, int spear, int sword, int axe, int scout, int light, int heavy, int ram, int cata, int wood, int clay, int metal, int food, string type)
        {
            AJSGame.Objects.Unit StatsSpear = AJSGame.Objects.Unit.GetUnit("spear");
            AJSGame.Objects.Unit StatsSword = AJSGame.Objects.Unit.GetUnit("sword");
            AJSGame.Objects.Unit StatsAxe = AJSGame.Objects.Unit.GetUnit("axe");
            AJSGame.Objects.Unit StatsScout = AJSGame.Objects.Unit.GetUnit("scout");
            AJSGame.Objects.Unit StatsLight = AJSGame.Objects.Unit.GetUnit("light");
            AJSGame.Objects.Unit StatsHeavy = AJSGame.Objects.Unit.GetUnit("heavy");
            AJSGame.Objects.Unit StatsRam = AJSGame.Objects.Unit.GetUnit("ram");
            AJSGame.Objects.Unit StatsCata = AJSGame.Objects.Unit.GetUnit("cata");
            
            
            AJSGame.Objects.Village attacker = AJSGame.Objects.Village.GetVillage(fromVillage);
            AJSGame.Objects.Village defender = AJSGame.Objects.Village.GetVillage(toVillage);

            int distanceX = Math.Abs(attacker.X - defender.X);
            int distanceY = Math.Abs(attacker.Y - defender.Y);
            int distance = distanceX + distanceY;

            DateTime finish = DateTime.UtcNow;
            TimeSpan time = new TimeSpan();
            if (scout > 0)
                time = TimeSpan.FromMinutes(double.Parse((StatsScout.Speed * distance).ToString()));
            if (light > 0)
                time = TimeSpan.FromMinutes(double.Parse((StatsLight.Speed * distance).ToString()));
            if (heavy > 0)
                time = TimeSpan.FromMinutes(double.Parse((StatsHeavy.Speed * distance).ToString()));
            if (sword > 0)
                time = TimeSpan.FromMinutes(double.Parse((StatsSword.Speed * distance).ToString()));
            if (axe > 0)
                time = TimeSpan.FromMinutes(double.Parse((StatsAxe.Speed * distance).ToString()));
            if (spear > 0)
                time = TimeSpan.FromMinutes(double.Parse((StatsSpear.Speed * distance).ToString()));

            finish = finish.Add(time);

            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("fromvillage", fromVillage);
            hashtable.Add("tovillage", toVillage);
            hashtable.Add("spear", spear);
            hashtable.Add("sword", sword);
            hashtable.Add("axe", axe);
            hashtable.Add("scout", scout);
            hashtable.Add("light", light);
            hashtable.Add("heavy", heavy);
            hashtable.Add("ram", ram);
            hashtable.Add("cata", cata);
            hashtable.Add("start", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtable.Add("finish", finish);
            hashtable.Add("wood", 0);
            hashtable.Add("clay", 0);
            hashtable.Add("metal", 0);
            hashtable.Add("food", 0);
            hashtable.Add("type", type);
            hashtable = SQL.InsertData("movements", hashtable);

            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public void DeleteMovement(Movement movement)
        {
            Hashtable hashtable = SQL.DeleteData("movements", "id = '" + movement.ID + "'");
        }

        #endregion
    }
}