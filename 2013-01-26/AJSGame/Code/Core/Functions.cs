using AJSGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AJSGame.Core
{
    public class Functions
    {
        #region Security

        public static string Hash(string str)
        {
            MD5 hasher = MD5.Create();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
                builder.Append(data[i].ToString("x2"));
            return builder.ToString();
        }

        #endregion

        #region Time

        public static string DateString(DateTime dt)
        {
            string result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        public static string DateFriendly(DateTime dt)
        {
            string result;
            DateTime timestamp = DateTime.UtcNow;
            int diff = (dt - timestamp).Days;
            if (diff == -1)
                result = "Yesturday";
            else if (-7 <= diff && diff <= -2)
                result = "Last " + dt.DayOfWeek.ToString();
            else if (diff == 0)
                result = "Today";
            else if (diff == 1)
                result = "Tomorrow";
            else if (1 <= diff && diff <= 7)
                result = "This " + dt.DayOfWeek.ToString();
            else if (7 <= diff && diff <= 14)
                result = "Next " + dt.DayOfWeek.ToString();
            else
                result = dt.ToString("dd-MM-yy");
            return result;
        }

        #endregion

        #region Labels

        public static string LabelsBuilding(string building)
        {
            string result;
            switch (building)
            {
                default:
                    result = "";
                    break;
                case "main":
                    result = "Main Building";
                    break;
                case "timbercamp":
                    result = "Timbercamp";
                    break;
                case "claypit":
                    result = "Claypit";
                    break;
                case "mine":
                    result = "Mine";
                    break;
                case "farm":
                    result = "Farm";
                    break;
                case "warehouse":
                    result = "Warehouse";
                    break;
                case "granary":
                    result = "Granary";
                    break;
                case "barracks":
                    result = "Barracks";
                    break;
                case "stable":
                    result = "Stable";
                    break;
                case "academy":
                    result = "Research Academy";
                    break;
                case "workshop":
                    result = "Siege Workshop";
                    break;
                case "wall":
                    result = "Wall";
                    break;
                case "rally":
                    result = "Rally Point";
                    break;
                case "shelter":
                    result = "Shelter";
                    break;
            }
            return result;
        }

        public static string LabelsUnit(string unit)
        {
            string result;
            switch (unit)
            {
                default:
                    result = "";
                    break;
                case "spear":
                    result = "Spearman";
                    break;
                case "sword":
                    result = "Swordsman";
                    break;
                case "axe":
                    result = "Axeman";
                    break;
                case "light":
                    result = "Light Cavalry";
                    break;
                case "heavy":
                    result = "Heavy Cavalry";
                    break;
                case "scout":
                    result = "Scout";
                    break;
                case "ram":
                    result = "Battering Ram";
                    break;
                case "cata":
                    result = "Catapult";
                    break;
            }
            return result;
        }

        public static string LabelsRole(string role)
        {
            string result;
            switch (role)
            {
                default:
                    result = "";
                    break;
                case "leader":
                    result = "Leader";
                    break;
                case "officer":
                    result = "Officer";
                    break;
                case "diplomat":
                    result = "Diplomat";
                    break;
                case "member":
                    result = "Member";
                    break;
            }
            return result;
        }

        public static string LabelsGender(string gender)
        {
            string result;
            switch (gender)
            {
                default:
                    result = "";
                    break;
                case "male":
                    result = "Male";
                    break;
                case "female":
                    result = "Female";
                    break;
                case "unkown":
                    result = "Unkown";
                    break;
            }
            return result;
        }

        #endregion

        #region General Validation

        public static bool IsInteger(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Game Validation

        public static bool RequirementsBuilding(string building, Objects.Village village)
        {
            bool result;
            switch (building)
            {
                default:
                    result = false;
                    break; 
                case "main":
                    // No requirements
                    result = true;
                    break;
                case "timbercamp":
                    // Level 1 Main Building
                    if (village.Buildings.MainBuilding.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "claypit":
                    // Level 1 Main Building
                    if (village.Buildings.MainBuilding.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "mine":
                    // Level 1 Main Building
                    if (village.Buildings.MainBuilding.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "farm":
                    // Level 1 Main Building
                    if (village.Buildings.MainBuilding.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "warehouse":
                    // Level 1 Main Building
                    if (village.Buildings.MainBuilding.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "granary":
                    // Level 1 Main Building && Level 1 Farm
                    if (village.Buildings.MainBuilding.Level >= 1 && village.Buildings.Farm.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "barracks":
                    // Level 3 Main Building && Level 1 Research Academy
                    if (village.Buildings.MainBuilding.Level >= 3 && village.Buildings.ResearchAcademy.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "stable":
                    // Level 10 Main Building && Level 5 Barracks && Level 5 Research Academy
                    if (village.Buildings.MainBuilding.Level >= 10 && village.Buildings.Barracks.Level >= 5 && village.Buildings.ResearchAcademy.Level >= 5)
                        result = true;
                    else
                        result = false;
                    break;
                case "academy":
                    // Level 3 Main Building
                    if (village.Buildings.MainBuilding.Level >= 3)
                        result = true;
                    else
                        result = false;
                    break;
                case "workshop":
                    // Level 10 Main Building && Level 10 Research Academy
                    if (village.Buildings.MainBuilding.Level >= 10 && village.Buildings.ResearchAcademy.Level >= 10)
                        result = true;
                    else
                        result = false;
                    break;
                case "wall":
                    // Level 1 Main Building
                    if (village.Buildings.MainBuilding.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "rally":
                    // No requirements
                    result = true;
                    break;
                case "shelter":
                    // No requirements
                    result = true;
                    break;
            }
            return result;
        }

        public static bool RequirementsUnit(string unit, Objects.Village village)
        {
            bool result;
            switch (unit)
            {
                default:
                    result = false;
                    break;
                case "spear":
                    if (village.Research.Spearman)
                        result = true;
                    else
                        result = false;
                    break;
                case "sword":
                    if (village.Research.Swordsman)
                        result = true;
                    else
                        result = false;
                    break;
                case "axe":
                    if (village.Research.Axeman)
                        result = true;
                    else
                        result = false;
                    break;
                case "light":
                    if (village.Research.LightCavalry)
                        result = true;
                    else
                        result = false;
                    break;
                case "heavy":
                    if (village.Research.HeavyCavalry)
                        result = true;
                    else
                        result = false;
                    break;
                case "scout":
                    if (village.Research.Scout)
                        result = true;
                    else
                        result = false;
                    break;
                case "ram":
                    if (village.Research.BatteringRam)
                        result = true;
                    else
                        result = false;
                    break;
                case "cata":
                    if (village.Research.Catapult)
                        result = true;
                    else
                        result = false;
                    break;
            }
            return result;
        }

        public static bool RequirementsResearch(string unit, Objects.Village village)
        {
            bool result;
            switch (unit)
            {
                default:
                    result = false;
                    break;
                case "spear":
                    if (village.Buildings.Barracks.Level >= 1 && village.Buildings.ResearchAcademy.Level >= 1)
                        result = true;
                    else
                        result = false;
                    break;
                case "sword":
                    if (village.Buildings.Barracks.Level >= 2 && village.Buildings.ResearchAcademy.Level >= 3)
                        result = true;
                    else
                        result = false;
                    break;
                case "axe":
                    if (village.Buildings.Barracks.Level >= 3 && village.Buildings.ResearchAcademy.Level >= 5)
                        result = true;
                    else
                        result = false;
                    break;
                case "light":
                    if (village.Buildings.Stable.Level >= 3 && village.Buildings.ResearchAcademy.Level >= 8)
                        result = true;
                    else
                        result = false;
                    break;
                case "heavy":
                    if (village.Buildings.Stable.Level >= 5 && village.Buildings.ResearchAcademy.Level >= 10)
                        result = true;
                    else
                        result = false;
                    break;
                case "scout":
                    if (village.Buildings.Stable.Level >= 1 && village.Buildings.ResearchAcademy.Level >= 5)
                        result = true;
                    else
                        result = false;
                    break;
                case "ram":
                    if (village.Buildings.SiegeWorkshop.Level >= 1 && village.Buildings.ResearchAcademy.Level >= 10)
                        result = true;
                    else
                        result = false;
                    break;
                case "cata":
                    if (village.Buildings.SiegeWorkshop.Level >= 10 && village.Buildings.ResearchAcademy.Level >= 15)
                        result = true;
                    else
                        result = false;
                    break;
            }
            return result;
        }

        public static bool RequirementsResources(int costWood, int costClay, int costMetal, int costFood, Objects.Village village)
        {
            if (costWood > village.Wood || costClay > village.Clay || costMetal > village.Metal || costFood > village.Food)
                return false;
            else
                return true;
        }

        public static bool RequirementsPremium(User user)
        {
            if (user.IsPremium == true)
                return true;
            else
                return false;
        }

        #endregion

        #region Game Time

        public static TimeSpan TimeLeft(DateTime timestamp)
        {
            TimeSpan result;
            DateTime now = DateTime.UtcNow;
            result = timestamp - now;
            return result;
        }

        public static TimeSpan TimeLeftMulti(int ammount, TimeSpan time, DateTime timestamp)
        {
            TimeSpan result;
            DateTime now = DateTime.UtcNow;
            TimeSpan additional = TimeSpan.FromTicks(time.Ticks * ammount);
            DateTime final = timestamp.Add(additional);
            result = final - now;
            return result;
        }

        public static TimeSpan TimeLeftMultiNext(DateTime timestamp, TimeSpan time)
        {
            TimeSpan result = new TimeSpan();
            DateTime now = DateTime.UtcNow;
            DateTime final = timestamp.Add(time);
            result = final.Subtract(now);
            return result;
        }

        public static DateTime MutliFinishedTime(DateTime start, int ammount, TimeSpan time)
        {
            TimeSpan total = TimeSpan.FromTicks(time.Ticks * ammount);
            DateTime finish;
            finish = start.Add(total);
            return finish;
        }

        public static TimeSpan TimeReducedBuilding(Objects.Village village, TimeSpan time)
        {
            TimeSpan result = new TimeSpan();
            float multiplier = (float)village.Buildings.MainBuilding.Attribute / 100;
            result = TimeSpan.FromTicks((long)(time.Ticks * multiplier));
            return result;
        }

        public static TimeSpan TimeReducedResearch(Objects.Village village, TimeSpan time)
        {
            TimeSpan result = new TimeSpan();
            float multiplier = (float)village.Buildings.ResearchAcademy.Attribute / 100;
            result = TimeSpan.FromTicks((long)(time.Ticks * multiplier));
            return result;
        }

        public static TimeSpan TimeReducedRecruitment(Objects.Village village, TimeSpan time, string type)
        {
            TimeSpan result = new TimeSpan();
            float multiplier;
            switch (type)
            {
                case "infantry":
                    multiplier = (float)village.Buildings.Barracks.Attribute / 100;
                    break;
                case "cavalry":
                    multiplier = (float)village.Buildings.Stable.Attribute / 100;
                    break;
                case "siege":
                    multiplier = (float)village.Buildings.SiegeWorkshop.Attribute / 100;
                    break;
                default:
                    multiplier = 1;
                    break;
            }
            result = TimeSpan.FromTicks((long)(time.Ticks * multiplier));
            return result;
        }      

        #endregion

        #region Game Algorithms

        public static string NewCoOrdinates(int sector)
        {
            string xy;

            int userCount = Objects.User.GetUsers().Count;
            int starter = -3;
            int newx = 0;
            int newy = 0;
            Random rand = new Random();
            if (userCount > 20)
                starter = -3 * (int)Math.Floor((double)(userCount / 20));
            bool found = false;
            if (userCount == 1)
                found = true;
            userCount = (int)Math.Floor((double)(Math.Pow((double)userCount, (double)0.75)));
            while (found == false)
            {
                switch (sector)
                {
                    case 0:
                        // Random
                        sector = rand.Next(1, 4);
                        break;
                    case 1:
                        // -x +y
                        newx = starter + rand.Next(starter, (userCount));
                        newy = (starter * -1) + rand.Next((userCount * -1), userCount);
                        break;
                    case 2:
                        // +x +y
                        newx = (starter * -1) + rand.Next((userCount * -1), userCount);
                        newy = (starter * -1) + rand.Next((userCount * -1), userCount);
                        break;
                    case 3:
                        // -x -y
                        newx = starter + rand.Next(starter, (userCount));
                        newy = starter + rand.Next(starter, (userCount));
                        break;
                    case 4:
                        // +x -y
                        newx = (starter * -1) + rand.Next((userCount * -1), userCount);
                        newy = starter + rand.Next(starter, (userCount));
                        break;
                    default:
                        break;
                }

                if (!Objects.Village.Exists(newx, newy))
                {
                    List<Objects.Village> localVillages = Objects.Village.GetVillages("(x BETWEEN '" + (newx - 3) + "' AND '" + (newx + 3) + "') AND (y BETWEEN '" + (newy - 3) + "' AND '" + (newy + 3) + "')");
                    if (localVillages.Count > 2 && localVillages.Count < 4)
                        found = true;
                }
            }

            xy = newx + "," + newy;

            return xy;
        }

        #endregion

        #region Max Calculations

        public static int MaxUnits(Objects.Village village, string unit)
        {
            int result = 0;
            Objects.Unit data = Objects.Unit.GetUnit(unit);
            double wood = Math.Floor(Convert.ToDouble(village.Wood / data.Wood));
            double clay = Math.Floor(Convert.ToDouble(village.Clay / data.Clay));
            double metal = Math.Floor(Convert.ToDouble(village.Metal / data.Metal));
            double food = Math.Floor(Convert.ToDouble(village.Food / data.Food));
            int smallest = Convert.ToInt32(wood);
            if (clay < smallest)
                smallest = Convert.ToInt32(clay);
            if (metal < smallest)
                smallest = Convert.ToInt32(metal);
            if (food < smallest)
                smallest = Convert.ToInt32(food);
            result = smallest;
            return result;
        }

        #endregion

        #region Game Calculation

        public static void Calculate(Objects.User user)
        {
            List<Objects.Village> villages = Objects.Village.GetVillages("owner = '" + user.ID + "'");
            foreach (Objects.Village village in villages)
            {
                village.FinishConstructions();
                // Finish Trade
                village.ResourcesUpdate();
                village.ResourcesPrune();
                village.FinishTraining();
                // Finish Movements
                village.FinishAttacks();
                // Finish Defences
                village.UpdateLastUpdate();
            }
        }

        #endregion
    }
}