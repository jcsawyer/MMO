using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Invite
    {
        #region Properties

        public int ID { get; set; }
        public int Alliance { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Invite invite)
        {
            invite.ID = Convert.ToInt32(dr["id"]);
            invite.Alliance = Convert.ToInt32(dr["aref"]);
            invite.Username = dr["username"].ToString();
            invite.Timestamp = Convert.ToDateTime(dr["timestamp"]);
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteInvite(this);
            this.ID = 0;
        }

        #endregion

        #region Public Static Methods

        public static Invite GetInvite(int id)
        {
            Invite result = new Invite();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM invites WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static List<Invite> GetInvites()
        {
            List<Invite> result = new List<Invite>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM invites");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Invite invite = new Invite();
                    Fill(dr, invite);
                    result.Add(invite);
                }
            }
            return result;
        }

        public static List<Invite> GetInvites(string where)
        {
            List<Invite> result = new List<Invite>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM invites WHERE " + where);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Invite invite = new Invite();
                    Fill(dr, invite);
                    result.Add(invite);
                }
            }
            return result;
        }

        public static bool Exists(string username, int aref)
        {
            bool result;
            bool boolInvite = SQL.Exists("invites", "username = '" + username + "' AND aref = '" + aref + "'");
            if (!boolInvite)
                result = false;
            else
                result = true;
            return result;
        }

        public static bool NewInvite(int aref, string username)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("aref", aref);
            hashtable.Add("username", username);
            hashtable.Add("timestamp", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtable = SQL.InsertData("invites", hashtable);

            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void DeleteInvite(Invite invite)
        {
            Hashtable hashtable = SQL.DeleteData("invites", "id = '" + invite.ID + "'");
        }

        #endregion
    }
}