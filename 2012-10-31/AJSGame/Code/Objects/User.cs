using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class User
    {
        #region Properties

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsBanned { get; set; }
        public bool IsPremium { get; set; }
        public bool IsProtected { get; set; }
        public int CP { get; set; }
        public int AP { get; set; }
        public int DP { get; set; }
        public int Alliance { get; set; }
        public string Role { get; set; }

        public UserProfile Profile { get; set; }
        public int Villages { get; set; }
        public int UnreadMessages { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, User user)
        {
            user.ID = Convert.ToInt32(dr["id"]);
            user.Username = dr["username"].ToString();
            user.Password = dr["password"].ToString();
            user.Email = dr["email"].ToString();
            user.Created = Convert.ToDateTime(dr["created"]);
            user.LastUpdate = Convert.ToDateTime(dr["lastupdate"]);
            user.IsBanned = Convert.ToBoolean(dr["banned"]);
            user.IsPremium = Convert.ToBoolean(dr["premium"]);
            user.IsProtected = Convert.ToBoolean(dr["protect"]);
            user.CP = Convert.ToInt32(dr["cp"]);
            user.AP = Convert.ToInt32(dr["ap"]);
            user.DP = Convert.ToInt32(dr["dp"]);
            user.Alliance = Convert.ToInt32(dr["aref"]);
            user.Role = dr["arole"].ToString();
        }

        #endregion

        #region Public Methods

        public void AddCP(int points)
        {
            AddUserCP(this, points);
        }

        public void AddAP(int points)
        {
            AddUserAP(this, points);
        }

        public void AddDP(int points)
        {
            AddUserDP(this, points);
        }

        public void ChangeAlliance(int aref)
        {
            ChangeUserAlliance(this, aref);
        }

        public bool AllianceMember()
        {
            return IsAllianceMember(this);
        }

        public void ChangeRole(string role)
        {
            ChangeUserRole(this, role);
        }

        public bool IsInRole(string role)
        {
            return UserIsInRole(this, role);
        }

        #endregion

        #region Public Static Methods

        public static User GetUser(int id)
        {
            User result = new User();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM users WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            result.Profile = UserProfile.GetUserProfile(id);
            result.Villages = AJSGame.Objects.Village.GetVillages("owner = '" + id + "'").Count;
            result.UnreadMessages = AJSGame.Objects.Message.GetMessages("recipient = '" + result.Username + "' AND [read] = 'false' AND type = 'inbox'").Count;
            result.Points = result.CP + result.AP + result.DP;

            int finalRank = 0;
            List<User> listUsers = Objects.User.GetUsers();
            listUsers = listUsers.OrderBy(x => x.Points * -1).ToList();
            for (int i = 0; i < listUsers.Count; i++)
            {
                finalRank++;
                if (listUsers[i].ID == id)
                    break;
            }
            result.Rank = finalRank;

            return result;
        }

        public static User GetUser(string username)
        {
            User result = new User();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM users WHERE username = '" + username + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            result.Profile = UserProfile.GetUserProfile(Convert.ToInt32(ds.Tables[0].Rows[0]["id"]));
            result.Villages = AJSGame.Objects.Village.GetVillages("owner = '" + Convert.ToInt32(ds.Tables[0].Rows[0]["id"]) + "'").Count;
            result.UnreadMessages = AJSGame.Objects.Message.GetMessages("recipient = '" + ds.Tables[0].Rows[0]["username"] + "' AND [read] = 'false' AND type = 'inbox'").Count;
            result.Points = result.CP + result.AP + result.DP;

            int finalRank = 0;
            List<User> listUsers = Objects.User.GetUsers();
            listUsers = listUsers.OrderBy(x => x.Points * -1).ToList();
            for (int i = 0; i < listUsers.Count; i++)
            {
                finalRank++;
                if (listUsers[i].ID == (int)ds.Tables[0].Rows[0]["id"])
                    break;
            }
            result.Rank = finalRank;
            return result;
        }

        public static List<User> GetUsers()
        {
            List<User> result = new List<User>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM users");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(dr["id"]);
                    User user = new User();
                    Fill(dr, user);
                    user.Profile = UserProfile.GetUserProfile(id);
                    user.Villages = AJSGame.Objects.Village.GetVillages("owner = '" + user.ID + "'").Count;
                    user.UnreadMessages = AJSGame.Objects.Message.GetMessages("recipient = '" + user.Username + "' AND [read] = 'false' AND type = 'inbox'").Count;
                    user.Points = user.CP + user.AP + user.DP;
                    result.Add(user);
                }
            }

            result = result.OrderBy(x => x.Points * -1).ToList();

            return result;
        }

        public static List<User> GetUsers(string where)
        {
            List<User> result = new List<User>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM users WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(dr["id"]);
                    User user = new User();
                    Fill(dr, user);
                    user.Profile = UserProfile.GetUserProfile(id);
                    user.Villages = AJSGame.Objects.Village.GetVillages("owner = '" + id + "'").Count;
                    user.UnreadMessages = AJSGame.Objects.Message.GetMessages("recipient = '" + user.Username + "' AND [read] = 'false' AND type = 'inbox'").Count;
                    user.Points = user.CP + user.AP + user.DP;
                    result.Add(user);
                }
            }

            result = result.OrderBy(x => x.Points * -1).ToList();

            return result;
        }

        public static bool Exists(int id)
        {
            bool result;
            result = SQL.Exists("users", "id = '" + id + "'");
            return result;
        }

        public static bool Exists(string username)
        {
            bool result;
            result = SQL.Exists("users", "username = '" + username + "'");
            return result;
        }

        public static bool Validate(string username, string password)
        {
            bool result;
            result = SQL.Exists("users", "username = '" + username + "' AND password = '" + password + "'");
            return result;
        }

        public static bool CheckBanned(string username)
        {
            bool result;
            result = SQL.Exists("users", "username = '" + username + "' AND banned = '1'");
            return result;
        }

        public static bool NewUser(string username, string password, string email, int sector)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("username", username);
            hashtable.Add("password", password);
            hashtable.Add("email", email);
            hashtable.Add("created", Functions.DateString(DateTime.UtcNow));
            hashtable.Add("lastupdate", Functions.DateString(DateTime.UtcNow));
            hashtable.Add("banned", 0);
            hashtable.Add("premium", 0);
            hashtable.Add("protect", 1);
            hashtable.Add("cp", 0);
            hashtable.Add("ap", 0);
            hashtable.Add("dp", 0);
            hashtable.Add("aref", 0);
            hashtable = SQL.InsertData("users", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
            {
                bool village = Village.NewVillage(User.GetUser(Convert.ToInt32(hashtable["Identity"])), sector);
                if (village)
                {
                    bool units = VillageUnits.NewVillageUnits(Village.GetCapitalVillage(Convert.ToInt32(hashtable["Identity"])).ID);
                    bool buildings = VillageBuildings.NewVillageBuildings(Village.GetCapitalVillage(Convert.ToInt32(hashtable["Identity"])).ID);
                    bool research = VillageResearch.NewVillageResearch(Village.GetCapitalVillage(Convert.ToInt32(hashtable["Identity"])).ID);
                    AJSGame.Objects.UserProfile.NewUserProfile((int)hashtable["Identity"], DateTime.MinValue, "", 7, true, "", "", "unknown", "");
                    result = true;
                }
                else
                {
                    result = false;
                    // TODO : DELETE USER
                    // TODO : DELETE USER PROFILE
                }
            }
            return result;
        }

        public static bool UpdateLastActivity(string username)
        {
            bool result = true;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("lastupdate", Functions.DateString(DateTime.UtcNow));
            hashtable = SQL.UpdateData("users", "username = '" + username + "'", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void AddUserCP(User user, int points)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("cp", user.CP + points);
            hashtable = SQL.UpdateData("users", "id = '" + user.ID + "'", hashtable);
        }

        public static void AddUserAP(User user, int points)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("ap", user.AP + points);
            hashtable = SQL.UpdateData("users", "id = '" + user.ID + "'", hashtable);
        }

        public static void AddUserDP(User user, int points)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("dp", user.DP + points);
            hashtable = SQL.UpdateData("users", "id = '" + user.ID + "'", hashtable);
        }

        public static void ChangeUserAlliance(User user, int aref)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("aref", aref);
            hashtable = SQL.UpdateData("users", "id = '" + user.ID + "'", hashtable);
            if (user.Role == "")
                AJSGame.Objects.User.ChangeUserRole(user, "member");
            if (aref == 0)
            {
                AJSGame.Objects.Message.NewMessage("Removed from alliance", "Server", user.Username, "You were removed from the alliance.");
                AJSGame.Objects.User.ChangeUserRole(user, "");
            }
        }

        public static bool IsAllianceMember(User user)
        {
            if (user.Alliance != 0)
                return true;
            else
                return false;
        }

        public static void ChangeUserRole(User user, string role)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("arole", role);
            hashtable = SQL.UpdateData("users", "id = '" + user.ID + "'", hashtable);
        }

        public static bool UserIsInRole(User user, string role)
        {
            if (user.Role != role)
                return false;
            else
                return true;
        }

        #endregion
    }
}