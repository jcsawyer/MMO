using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Village
    {
        #region Properties

        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }
        public bool IsCapital { get; set; }
        public int CP { get; set; }
        public float Wood { get; set; }
        public float Clay { get; set; }
        public float Metal { get; set; }
        public float Food { get; set; }
        public int MaxStore { get; set; }
        public int MaxFood { get; set; }
        public DateTime LastUpdate { get; set; }

        public VillageUnits Units { get; set; }
        public VillageBuildings Buildings { get; set; }
        public VillageResearch Research { get; set; }

        public List<Construction> Constructions { get; set; }
        public List<Training> Training { get; set; }

        public List<Movement> Movements { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Village village)
        {
            village.ID = Convert.ToInt32(dr["id"]);
            village.X = Convert.ToInt32(dr["x"]);
            village.Y = Convert.ToInt32(dr["y"]);
            village.Name = dr["name"].ToString();
            village.Owner = Convert.ToInt32(dr["owner"]);
            village.IsCapital = Convert.ToBoolean(dr["capital"]);
            village.CP = Convert.ToInt32(dr["cp"]);
            village.Wood = float.Parse(dr["wood"].ToString());
            village.Clay = float.Parse(dr["clay"].ToString());
            village.Metal = float.Parse(dr["metal"].ToString());
            village.Food = float.Parse(dr["food"].ToString());
            village.MaxStore = Convert.ToInt32(dr["maxstore"]);
            village.MaxFood = Convert.ToInt32(dr["maxfood"]);
            village.LastUpdate = Convert.ToDateTime(dr["lastupdate"]);
        }

        #endregion

        #region Public Methods

        public void FinishConstructions()
        {
            Village.FinishVillageConstructions(this);
        }

        public void AddCP(int points)
        {
            Village.AddVillageCP(this, points);
        }

        public void UpdateMaxStore(int max)
        {
            Village.UpdateVillageMaxStore(this, max);
        }

        public void UpdateMaxFood(int max)
        {
            Village.UpdateVillageMaxFood(this, max);
        }

        public void ResourcesRemove(int wood, int clay, int metal, int food)
        {
            Village.VillageResourcesRemove(this, wood, clay, metal, food);
        }

        public void ResourcesUpdate()
        {
            Village.VillageResourcesUpdate(this);
        }

        public void ResourcesPrune()
        {
            Village.VillageResourcesPrune(this);
        }

        public void UpdateLastUpdate()
        {
            Village.VillageUpdateLastUpdate(this);
        }

        public void FinishTraining()
        {
            Village.VillageFinishTraining(this);
        }

        public void AddUnits(string unit, int ammount)
        {
            Village.VillageAddUnits(this, unit, ammount);
        }

        public void RemoveUnits(string unit, int ammount)
        {
            Village.VillageRemoveUnits(this, unit, ammount);
        }

        public void FinishAttacks()
        {
            Village.FinishVillageAttacks(this);
        }

        #endregion

        #region Public Static Methods

        public static Village GetVillage(int id)
        {
            Village result = new Village();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villages WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            result.Units = VillageUnits.GetVillageUnits(id);
            result.Buildings = VillageBuildings.GetVillageBuildings(id);
            result.Research = VillageResearch.GetVillageResearch(id);
            result.Constructions = Construction.GetConstructions("vref = '" + id + "'");
            result.Training = Objects.Training.GetTrainings("vref = '" + id + "'");
            result.Movements = Objects.Movement.GetMovements("fromvillage = '" + id + "' OR tovillage = '" + id + "'");
            return result;
        }

        public static Village GetVillage(int x, int y)
        {
            Village result = new Village();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villages WHERE x = '" + x + "' AND y = '" + y + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            result.Units = VillageUnits.GetVillageUnits(result.ID);
            result.Buildings = VillageBuildings.GetVillageBuildings(result.ID);
            result.Research = VillageResearch.GetVillageResearch(result.ID);
            result.Constructions = Construction.GetConstructions("vref = '" + result.ID + "'");
            result.Training = Objects.Training.GetTrainings("vref = '" + result.ID + "'");
            result.Movements = Objects.Movement.GetMovements("fromvillage = '" + result.ID + "' OR tovillage = '" + result.ID + "'");
            return result;
        }

        public static Village GetCapitalVillage(int owner)
        {
            Village result = new Village();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villages WHERE owner = '" + owner + "' AND capital = '1'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            result.Units = VillageUnits.GetVillageUnits(id);
            result.Buildings = VillageBuildings.GetVillageBuildings(id);
            result.Research = VillageResearch.GetVillageResearch(id);
            result.Constructions = Construction.GetConstructions("vref = '" + id + "'");
            result.Training = Objects.Training.GetTrainings("vref = '" + id + "'");
            result.Movements = Objects.Movement.GetMovements("fromvillage = '" + id + "' OR tovillage = '" + id + "'");
            return result;
        }

        public static List<Village> GetVillages()
        {
            List<Village> result = new List<Village>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villages ORDER BY cp DESC");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int vref = Convert.ToInt32(dr["id"]);
                    Village village = new Village();
                    Fill(dr, village);
                    village.Units = VillageUnits.GetVillageUnits(vref);
                    village.Buildings = VillageBuildings.GetVillageBuildings(vref);
                    village.Research = VillageResearch.GetVillageResearch(vref);
                    village.Constructions = Construction.GetConstructions("vref = '" + vref + "'");
                    village.Training = Objects.Training.GetTrainings("vref = '" + vref + "'");
                    village.Movements = Objects.Movement.GetMovements("fromvillage = '" + vref + "' OR tovillage = '" + vref + "'");
                    result.Add(village);
                }
            }
            return result;
        }

        public static List<Village> GetVillages(string where)
        {
            List<Village> result = new List<Village>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM villages WHERE " + where + " ORDER BY cp DESC");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int vref = Convert.ToInt32(dr["id"]);
                    Village village = new Village();
                    Fill(dr, village);
                    village.Units = VillageUnits.GetVillageUnits(vref);
                    village.Buildings = VillageBuildings.GetVillageBuildings(vref);
                    village.Research = VillageResearch.GetVillageResearch(vref);
                    village.Constructions = Construction.GetConstructions("vref = '" + vref + "'");
                    village.Training = Objects.Training.GetTrainings("vref = '" + vref + "'");
                    village.Movements = Objects.Movement.GetMovements("fromvillage = '" + vref + "' OR tovillage = '" + vref + "'");
                    result.Add(village);
                }
            }
            return result;
        }

        public static bool Exists(int id)
        {
            bool result;
            result = SQL.Exists("villages", "id = '" + id + "'");
            return result;
        }

        public static bool Exists(int x, int y)
        {
            bool result;
            result = SQL.Exists("villages", "x = '" + x + "' AND y = '" + y + "'");
            return result;
        }

        public static bool NewVillage(User user, int sector)
        {
            bool result;
            if (Village.GetVillages().Count == 0)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("x", 0);
                hashtable.Add("y", 0);
                hashtable.Add("name", "jcsawyer village");
                hashtable.Add("owner", user.ID);
                hashtable.Add("capital", 1);
                hashtable.Add("cp", 0);
                hashtable.Add("wood", 800);
                hashtable.Add("clay", 800);
                hashtable.Add("metal", 500);
                hashtable.Add("food", 1200);
                hashtable.Add("maxstore", 1000);
                hashtable.Add("maxfood", 1500);
                hashtable.Add("lastupdate", Functions.DateString(DateTime.UtcNow));
                hashtable = SQL.InsertData("villages", hashtable);
                if (hashtable["Error"] != null)
                    result = false;
                else
                    result = true;
            }
            else
            {
                int villages = Village.GetVillages("owner = '" + user.ID + "'").Count;
                string name;
                int capital;
                if (villages >= 1)
                {
                    name = user.Username + "s village " + (villages + 1);
                    capital = 0;
                }
                else
                {
                    name = user.Username + "s village";
                    capital = 1;
                }
                string xy = Functions.NewCoOrdinates(sector);
                string x = xy.Split(',')[0];
                string y = xy.Split(',')[1];
                Hashtable hashtable = new Hashtable();
                hashtable.Add("x", x);
                hashtable.Add("y", y);
                hashtable.Add("name", name);
                hashtable.Add("owner", user.ID);
                hashtable.Add("capital", capital);
                hashtable.Add("cp", 0);
                hashtable.Add("wood", 800);
                hashtable.Add("clay", 800);
                hashtable.Add("metal", 500);
                hashtable.Add("food", 1200);
                hashtable.Add("maxstore", 1000);
                hashtable.Add("maxfood", 1500);
                hashtable.Add("lastupdate", Functions.DateString(DateTime.UtcNow));
                hashtable = SQL.InsertData("villages", hashtable);
                if (hashtable["Error"] != null)
                    result = false;
                else
                    result = true;
            }
            return result;
        }

        public static void AddVillageCP(Village village, int points)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("cp", village.CP + points);
            hashtable = SQL.UpdateData("villages", "id = '" + village.ID + "'", hashtable);
        }

        public static void UpdateVillageMaxStore(Village village, int max)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("maxstore", max);
            hashtable = SQL.UpdateData("villages", "id = '" + village.ID + "'", hashtable);
        }

        public static void UpdateVillageMaxFood(Village village, int max)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("maxfood", max);
            hashtable = SQL.UpdateData("villages", "id = '" + village.ID + "'", hashtable);
        }

        public static void FinishVillageConstructions(Village village)
        {
            User owner = User.GetUser(village.Owner);
            List<Construction> consutrctions = Construction.GetConstructions("vref = '" + village.ID + "'");
            foreach (Construction construction in consutrctions)
            {
                Building data = Building.GetBuilding(construction.Building, construction.ToLevel);
                if (construction.Finish <= DateTime.UtcNow)
                {
                    village.AddCP(data.Points);
                    owner.AddCP(data.Points);
                    if (construction.Building == "warehouse")
                        village.UpdateMaxStore(data.Attribute);
                    if (construction.Building == "granary")
                        village.UpdateMaxFood(data.Attribute);
                    village.Buildings.UpdateLevel(village, construction.Building);
                    construction.Delete();
                }
            }
        }

        public static void VillageResourcesRemove(Village village, int wood, int clay, int metal, int food)
        {
            Hashtable hashtable = new Hashtable();
            hashtable = SQL.SimpleUpdate("villages", "id = '" + village.ID + "'", "wood = wood - " + wood + ", clay = clay - " + clay + ", metal = metal - " + metal + ", food = food - " + food);
        }

        public static void VillageResourcesUpdate(Village village)
        {
            float passed = (float)((TimeSpan)(DateTime.UtcNow - village.LastUpdate)).TotalSeconds;
            float wood = (village.Buildings.Timbercamp.Attribute / (float)3600) * passed;
            float clay = (village.Buildings.Claypit.Attribute / (float)3600) * passed;
            float metal = (village.Buildings.Mine.Attribute / (float)3600) * passed;
            float food = (village.Buildings.Farm.Attribute / (float)3600) * passed;
            Hashtable hashtable = new Hashtable();
            hashtable = SQL.SimpleUpdate("villages", "id = '" + village.ID + "'", "wood = wood + " + wood + ", clay = clay + " + clay + ", metal = metal + " + metal + ", food = food + " + food);

            village.Wood = village.Wood + wood;
            village.Clay = village.Clay + clay;
            village.Metal = village.Metal + metal;
            village.Food = village.Food + food;
        }

        public static void VillageResourcesPrune(Village village)
        {
            float wood = village.Wood;
            float clay = village.Clay;
            float metal = village.Metal;
            float food = village.Food;

            if (wood > village.MaxStore)
                wood = village.MaxStore;
            if (clay > village.MaxStore)
                clay = village.MaxStore;
            if (metal > village.MaxStore)
                metal = village.MaxStore;
            if (food > village.MaxFood)
                food = village.MaxFood;

            Hashtable hashtable = new Hashtable();
            hashtable = SQL.SimpleUpdate("villages", "id = '" + village.ID + "'", "wood = " + wood + ", clay = " + clay + ", metal = " + metal + ", food = " + food);

            village.Wood = wood;
            village.Clay = clay;
            village.Metal = metal;
            village.Food = food;
        }

        public static void VillageUpdateLastUpdate(Village village)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("lastupdate", DateTime.UtcNow);
            hashtable = SQL.UpdateData("villages", "id = '" + village.ID + "'", hashtable);
        }

        public static void VillageFinishTraining(Village village)
        {
            User owner = User.GetUser(village.Owner);
            List<Training> trainings = Objects.Training.GetTrainings("vref = '" + village.ID + "'");
            foreach (Training training in trainings)
            {
                if (training.Start <= DateTime.UtcNow)
                {
                    if (training.Ammount > 0)
                    {
                        TimeSpan passed = (TimeSpan)(DateTime.UtcNow - (DateTime)training.Start);
                        if (passed != TimeSpan.Zero)
                        {
                            int trained = Convert.ToInt32(passed.Ticks / TimeSpan.Parse(training.Time.ToString()).Ticks);
                            if (trained > 0)
                            {
                                if (training.Ammount - trained <= 0)
                                {
                                    village.AddUnits(training.Unit, training.Ammount);
                                    training.Delete();
                                }
                                else
                                {
                                    village.AddUnits(training.Unit, trained);
                                    training.Update(trained);
                                }
                            }
                        }
                    }
                    else
                        training.Delete();
                }
            }
        }

        public static void VillageAddUnits(Village village, string unit, int ammount)
        {
            SQL.SimpleUpdate("villageunits", "vref = '" + village.ID + "'", unit + " = " + unit + " + " + ammount);
            village.Units = Objects.VillageUnits.GetVillageUnits(village.ID);
        }

        public static void VillageRemoveUnits(Village village, string unit, int ammount)
        {
            SQL.SimpleUpdate("villageunits", "vref = '" + village.ID + "'", unit + " = " + unit + " - " + ammount);
            village.Units = Objects.VillageUnits.GetVillageUnits(village.ID);
        }

        public static void FinishVillageAttacks(Village village)
        {
            List<AJSGame.Objects.Movement> attacks = AJSGame.Objects.Movement.GetMovements("fromvillage = '" + village.ID + "' AND type = 'attack'");
            foreach (Objects.Movement attack in attacks)
            {
                if (attack.Finish <= DateTime.UtcNow)
                {
                    Objects.Village attackerVillage = Objects.Village.GetVillage(attack.From);
                    Objects.User attacker = Objects.User.GetUser(attackerVillage.Owner);
                    Objects.Village defenderVillage = Objects.Village.GetVillage(attack.To);
                    Objects.User defender = Objects.User.GetUser(defenderVillage.Owner);

                    Core.Functions.Calculate(defender);

                    bool win = false;
                    double attackerLoss = 1.0;
                    double attackerScoutLoss = 1.0;
                    double defenderLoss = 1.0;
                    double defenderScoutLoss = 1.0;
                    if (attack.AttackerStrength > attack.DefenderDefence)
                    {
                        win = true;
                        defenderLoss = Math.Pow((double)attack.AttackerStrength / attack.DefenderDefence, 1.5);
                        defenderScoutLoss = Math.Pow((double)attack.AttackerScout / attack.DefenderScout, 1.5);
                    }
                    else
                    {
                        attackerLoss = Math.Pow((double)attack.DefenderDefence / attack.AttackerStrength, 1.5);
                        attackerScoutLoss = Math.Pow((double)attack.DefenderScout / attack.AttackerScout, 1.5);
                    }

                    int ASpearLost = (int)(attack.Spearman - Math.Floor(attack.Spearman * attackerLoss));
                    int DSpearLost = (int)(defenderVillage.Units.Spearman - Math.Floor(defenderVillage.Units.Spearman * defenderLoss));
                    int ASwordLost = (int)(attack.Swordsman - Math.Floor(attack.Swordsman * attackerLoss));
                    int DSwordLost = (int)(defenderVillage.Units.Swordsman - Math.Floor(defenderVillage.Units.Swordsman * defenderLoss));
                    int AAxeLost = (int)(attack.Axeman - Math.Floor(attack.Axeman * attackerLoss));
                    int DAxeLost = (int)(defenderVillage.Units.Axeman - Math.Floor(defenderVillage.Units.Axeman * defenderLoss));
                    int AScoutLost = (int)(attack.Scout - Math.Floor(attack.Scout * attackerScoutLoss));
                    int DScoutLost = (int)(defenderVillage.Units.Scout - Math.Floor(defenderVillage.Units.Scout * defenderScoutLoss));
                    int ALightLost = (int)(attack.LightCavalry - Math.Floor(attack.LightCavalry * attackerLoss));
                    int DLightLost = (int)(defenderVillage.Units.LightCavalry - Math.Floor(defenderVillage.Units.LightCavalry * defenderLoss));
                    int AHeavyLost = (int)(attack.HeavyCavalry - Math.Floor(attack.HeavyCavalry * attackerLoss));
                    int DHeavyLost = (int)(defenderVillage.Units.HeavyCavalry - Math.Floor(defenderVillage.Units.HeavyCavalry * defenderLoss));
                    int ARamLost = (int)(attack.BatteringRam - Math.Floor(attack.BatteringRam * attackerLoss));
                    int DRamLost = (int)(defenderVillage.Units.BatteringRam - Math.Floor(defenderVillage.Units.BatteringRam * defenderLoss));
                    int ACataLost = (int)(attack.Catapult - Math.Floor(attack.Catapult * attackerLoss));
                    int DCataLost = (int)(defenderVillage.Units.Catapult - Math.Floor(defenderVillage.Units.Catapult * defenderLoss));

                    int woodTaken = 0;
                    int clayTaken = 0;
                    int metalTaken = 0;
                    int foodTaken = 0;
                    if (win == true)
                    {
                        while ((woodTaken + clayTaken + metalTaken + foodTaken) <= ((int)defenderVillage.Wood + (int)defenderVillage.Clay + (int)defenderVillage.Metal + (int)defenderVillage.Food))
                        {
                            if ((woodTaken + clayTaken + metalTaken + foodTaken) >= attack.Capacity)
                                break;
                            if (woodTaken < defenderVillage.Wood)
                                woodTaken++;
                            if (clayTaken < defenderVillage.Clay)
                                clayTaken++;
                            if (metalTaken < defenderVillage.Metal)
                                metalTaken++;
                            if (foodTaken < defenderVillage.Food)
                                foodTaken++;
                        }
                    }

                    if (defenderVillage.Units.Scout == 0 && attack.Spearman == 0 && attack.Swordsman == 0 && attack.Axeman == 0 && attack.Scout > 0 && attack.LightCavalry == 0 && attack.HeavyCavalry == 0 && attack.BatteringRam == 0 && attack.Catapult == 0)
                    {
                        Objects.Report.NewReport(attacker.ID, attackerVillage.ID, defenderVillage.ID, 0, 0, 0, 0, 0, 0, attack.Scout, 0, 0, 0, 0, 0, 0, 0, 0, 0, defenderVillage.Units.Spearman, 0, defenderVillage.Units.Swordsman, 0, defenderVillage.Units.Axeman, 0, 0, 0, defenderVillage.Units.LightCavalry, 0, defenderVillage.Units.HeavyCavalry, 0, defenderVillage.Units.BatteringRam, 0, defenderVillage.Units.Catapult, 0,
                            0, 0, 0, 0, (int)defenderVillage.Wood, (int)defenderVillage.Clay, (int)defenderVillage.Metal, (int)defenderVillage.Food, defenderVillage.Buildings.MainBuilding.Level, defenderVillage.Buildings.Timbercamp.Level, defenderVillage.Buildings.Claypit.Level, defenderVillage.Buildings.Mine.Level, defenderVillage.Buildings.Farm.Level, defenderVillage.Buildings.Warehouse.Level, defenderVillage.Buildings.Granary.Level, defenderVillage.Buildings.Barracks.Level, defenderVillage.Buildings.Stable.Level, defenderVillage.Buildings.ResearchAcademy.Level, defenderVillage.Buildings.SiegeWorkshop.Level, defenderVillage.Buildings.Wall.Level, defenderVillage.Buildings.Market.Level, defenderVillage.Buildings.RallyPoint.Level, defenderVillage.Buildings.Shelter.Level);
                    }
                    else
                    {
                        int ScoutPercent = (AScoutLost / attack.Scout) * 100;
                        if (win == true)
                        {
                            Objects.Report.NewReport(attacker.ID, attackerVillage.ID, defenderVillage.ID, attack.Spearman, ASpearLost, attack.Swordsman, ASwordLost, attack.Axeman, AAxeLost, attack.Scout, AScoutLost, attack.LightCavalry, ALightLost, attack.HeavyCavalry, AHeavyLost, attack.BatteringRam, ARamLost, attack.Catapult, ACataLost,
                                    defenderVillage.Units.Spearman, DSpearLost, defenderVillage.Units.Swordsman, DSwordLost, defenderVillage.Units.Axeman, DAxeLost, defenderVillage.Units.Scout, DScoutLost, defenderVillage.Units.LightCavalry, DLightLost, defenderVillage.Units.HeavyCavalry, DHeavyLost, defenderVillage.Units.BatteringRam, DRamLost, defenderVillage.Units.Catapult, DCataLost,
                                    woodTaken, clayTaken, metalTaken, foodTaken,
                                    ScoutPercent >= 50 ? (int)defenderVillage.Wood : 0, ScoutPercent >= 50 ? (int)defenderVillage.Clay : 0, ScoutPercent >= 50 ? (int)defenderVillage.Metal : 0, ScoutPercent >= 50 ? (int)defenderVillage.Food : 0,
                                    ScoutPercent >= 100 ? defenderVillage.Buildings.MainBuilding.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Timbercamp.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Claypit.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Mine.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Farm.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Warehouse.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Granary.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Barracks.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Stable.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.ResearchAcademy.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.SiegeWorkshop.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Wall.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Market.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.RallyPoint.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Shelter.Level : 0);
                            Objects.Report.NewReport(defender.ID, attackerVillage.ID, defenderVillage.ID, attack.Spearman, ASpearLost, attack.Swordsman, ASwordLost, attack.Axeman, AAxeLost, attack.Scout, AScoutLost, attack.LightCavalry, ALightLost, attack.HeavyCavalry, AHeavyLost, attack.BatteringRam, ARamLost, attack.Catapult, ACataLost,
                                    defenderVillage.Units.Spearman, DSpearLost, defenderVillage.Units.Swordsman, DSwordLost, defenderVillage.Units.Axeman, DAxeLost, defenderVillage.Units.Scout, DScoutLost, defenderVillage.Units.LightCavalry, DLightLost, defenderVillage.Units.HeavyCavalry, DHeavyLost, defenderVillage.Units.BatteringRam, DRamLost, defenderVillage.Units.Catapult, DCataLost,
                                    woodTaken, clayTaken, metalTaken, foodTaken,
                                    ScoutPercent >= 50 ? (int)defenderVillage.Wood : 0, ScoutPercent >= 50 ? (int)defenderVillage.Clay : 0, ScoutPercent >= 50 ? (int)defenderVillage.Metal : 0, ScoutPercent >= 50 ? (int)defenderVillage.Food : 0,
                                    ScoutPercent >= 100 ? defenderVillage.Buildings.MainBuilding.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Timbercamp.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Claypit.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Mine.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Farm.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Warehouse.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Granary.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Barracks.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Stable.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.ResearchAcademy.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.SiegeWorkshop.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Wall.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Market.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.RallyPoint.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Shelter.Level : 0);
                        }
                        else
                        {
                            Objects.Report.NewReport(attacker.ID, attackerVillage.ID, defenderVillage.ID, attack.Spearman, ASpearLost, attack.Swordsman, ASwordLost, attack.Axeman, AAxeLost, attack.Scout, AScoutLost, attack.LightCavalry, ALightLost, attack.HeavyCavalry, AHeavyLost, attack.BatteringRam, ARamLost, attack.Catapult, ACataLost,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    woodTaken, clayTaken, metalTaken, foodTaken,
                                    ScoutPercent >= 50 ? (int)defenderVillage.Wood : 0, ScoutPercent >= 50 ? (int)defenderVillage.Clay : 0, ScoutPercent >= 50 ? (int)defenderVillage.Metal : 0, ScoutPercent >= 50 ? (int)defenderVillage.Food : 0,
                                    ScoutPercent >= 100 ? defenderVillage.Buildings.MainBuilding.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Timbercamp.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Claypit.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Mine.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Farm.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Warehouse.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Granary.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Barracks.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Stable.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.ResearchAcademy.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.SiegeWorkshop.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Wall.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Market.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.RallyPoint.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Shelter.Level : 0);
                            Objects.Report.NewReport(defender.ID, attackerVillage.ID, defenderVillage.ID, attack.Spearman, ASpearLost, attack.Swordsman, ASwordLost, attack.Axeman, AAxeLost, attack.Scout, AScoutLost, attack.LightCavalry, ALightLost, attack.HeavyCavalry, AHeavyLost, attack.BatteringRam, ARamLost, attack.Catapult, ACataLost,
                                    defenderVillage.Units.Spearman, DSpearLost, defenderVillage.Units.Swordsman, DSwordLost, defenderVillage.Units.Axeman, DAxeLost, defenderVillage.Units.Scout, DScoutLost, defenderVillage.Units.LightCavalry, DLightLost, defenderVillage.Units.HeavyCavalry, DHeavyLost, defenderVillage.Units.BatteringRam, DRamLost, defenderVillage.Units.Catapult, DCataLost,
                                    woodTaken, clayTaken, metalTaken, foodTaken,
                                    ScoutPercent >= 50 ? (int)defenderVillage.Wood : 0, ScoutPercent >= 50 ? (int)defenderVillage.Clay : 0, ScoutPercent >= 50 ? (int)defenderVillage.Metal : 0, ScoutPercent >= 50 ? (int)defenderVillage.Food : 0,
                                    ScoutPercent >= 100 ? defenderVillage.Buildings.MainBuilding.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Timbercamp.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Claypit.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Mine.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Farm.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Warehouse.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Granary.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Barracks.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Stable.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.ResearchAcademy.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.SiegeWorkshop.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Wall.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Market.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.RallyPoint.Level : 0, ScoutPercent >= 100 ? defenderVillage.Buildings.Shelter.Level : 0);
                        }
                    }

                    attack.Delete();
                }
            }
        }

        #endregion
    }
}