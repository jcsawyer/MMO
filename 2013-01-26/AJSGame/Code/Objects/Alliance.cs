using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Alliance
    {
        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int FounderID { get; set; }
        public DateTime Created { get; set; }

        public string Founder { get; set; }
        public List<User> Members { get; set; }
        public int CP { get; set; }
        public int AP { get; set; }
        public int DP { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Alliance alliance)
        {
            alliance.ID = Convert.ToInt32(dr["id"]);
            alliance.Name = dr["name"].ToString();
            alliance.Tag = dr["tag"].ToString();
            alliance.Description = dr["description"].ToString();
            alliance.FounderID = Convert.ToInt32(dr["founder"]);
            alliance.Created = Convert.ToDateTime(dr["timestamp"]);
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteAlliance(this);
            this.ID = 0;
        }

        public void Update(string description)
        {
            UpdateAlliance(this, description);
        }

        #endregion

        #region Public Static Methods

        public static Alliance GetAlliance(int id)
        {
            Alliance result = new Alliance();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM alliances WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            result.Founder = AJSGame.Objects.User.GetUser(result.FounderID).Username;
            result.Members = AJSGame.Objects.User.GetUsers("aref = '" + id + "'");
            foreach (AJSGame.Objects.User user in result.Members)
            {
                result.CP += user.CP;
                result.AP += user.AP;
                result.DP += user.DP;
            }
            result.Points = result.CP + result.AP + result.DP;

            int finalRank = 0;
            List<Alliance> listAlliances = Objects.Alliance.GetAlliances();
            listAlliances = listAlliances.OrderBy(x => x.Points * -1).ToList();
            /*listAlliances.Sort(delegate(Alliance a, Alliance b)
            {
                return a.Rank.CompareTo(b.Points) * -1;
            });*/
            for (int i = 0; i < listAlliances.Count; i++)
            {
                finalRank++;
                if (listAlliances[i].ID == id)
                    break;
            }
            result.Rank = finalRank;

            return result;
        }

        public static List<Alliance> GetAlliances()
        {
            List<Alliance> result = new List<Alliance>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM alliances");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Alliance alliance = new Alliance();
                    Fill(dr, alliance);
                    alliance.Founder = AJSGame.Objects.User.GetUser(Convert.ToInt32(alliance.FounderID)).Username;
                    alliance.Members = AJSGame.Objects.User.GetUsers("aref = '" + alliance.ID + "'");
                    foreach (AJSGame.Objects.User user in alliance.Members)
                    {
                        alliance.CP += user.CP;
                        alliance.AP += user.AP;
                        alliance.DP += user.DP;
                    }
                    alliance.Points = alliance.CP + alliance.AP + alliance.DP;

                    result.Add(alliance);
                }
            }

            result = result.OrderBy(x => x.Points * -1).ToList();
            /*result.Sort(delegate(Alliance a, Alliance b)
            {
                return a.Rank.CompareTo(b.Points) * -1;
            });*/

            return result;
        }

        public static List<Alliance> GetAlliances(string where)
        {
            List<Alliance> result = new List<Alliance>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM alliances WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Alliance alliance = new Alliance();
                    Fill(dr, alliance);
                    alliance.Founder = AJSGame.Objects.User.GetUser(Convert.ToInt32(alliance.FounderID)).Username;
                    alliance.Members = AJSGame.Objects.User.GetUsers("aref = '" + alliance.ID + "'");
                    foreach (AJSGame.Objects.User user in alliance.Members)
                    {
                        alliance.CP += user.CP;
                        alliance.AP += user.AP;
                        alliance.DP += user.DP;
                    }
                    alliance.Points = alliance.CP + alliance.AP + alliance.DP;

                    result.Add(alliance);
                }
            }

            result = result.OrderBy(x => x.Points).ToList();
            /*result.Sort(delegate(Alliance a, Alliance b)
            {
                return a.Rank.CompareTo(b.Points) * -1;
            });*/

            return result;
        }

        public static bool Exists(int id)
        {
            bool result;
            bool boolID = SQL.Exists("alliances", "id = '" + id + "'");
            if (!boolID)
                result = false;
            else
                result = true;
            return result;
        }

        public static bool Exists(string name, string tag)
        {
            bool result;
            bool boolName = SQL.Exists("alliances", "name = '" + name + "'");
            bool boolTag = SQL.Exists("alliances", "tag = '" + tag + "'");

            if (!boolName | !boolTag)
                result = false;
            else
                result = true;

            return result;
        }

        public static bool NewAlliance(string name, string tag, string description, User founder)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("name", name);
            hashtable.Add("tag", tag);
            hashtable.Add("description", description);
            hashtable.Add("founder", founder.ID);
            hashtable.Add("timestamp", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtable = SQL.InsertData("alliances", hashtable);

            founder.ChangeAlliance((int)hashtable["Identity"]);
            founder.ChangeRole("leader");

            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void DeleteAlliance(Alliance alliance)
        {
            List<User> users = AJSGame.Objects.User.GetUsers("aref = '" + alliance.ID + "'");
            foreach (User user in users)
            {
                user.ChangeAlliance(0);
                user.ChangeRole("");
                AJSGame.Objects.Message.NewMessage("Alliance Disbanded", "Server", user.Username, "Your alliance has been disbanded.");
            }
            Hashtable hashtable = SQL.DeleteData("alliances", "id = '" + alliance.ID + "'");
        }

        public static void UpdateAlliance(Alliance alliance, string description)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("description", description);
            hashtable = SQL.UpdateData("alliances", "id = '" + alliance.ID + "'", hashtable);
        }

        #endregion
    }
}