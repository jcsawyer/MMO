using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class UserProfile
    {
        #region Properties

        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        public int MapSize { get; set; }
        public bool ShowImages { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, UserProfile profile)
        {
            profile.Birthday = Convert.ToDateTime(dr["birthday"].ToString());
            profile.Avatar = dr["avatar"].ToString();
            profile.MapSize = Convert.ToInt32(dr["mapsize"]);
            profile.ShowImages = Convert.ToBoolean(dr["images"]);
            profile.Name = dr["name"].ToString();
            profile.Location = dr["location"].ToString();
            profile.Gender = dr["gender"].ToString();
            profile.Description = dr["description"].ToString();
        }

        #endregion

        #region Public Static Methods

        public static UserProfile GetUserProfile(int uref)
        {
            UserProfile result = new UserProfile();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM userprofiles WHERE uref = '" + uref + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static bool NewUserProfile(int uref, DateTime birthday, string avatar, int mapsize, bool showimages, string name, string location, string gender, string description)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            hashtable.Add("uref", uref);
            hashtable.Add("birthday", AJSGame.Core.Functions.DateString(birthday));
            hashtable.Add("avatar", avatar);
            hashtable.Add("mapsize", mapsize);
            hashtable.Add("images", showimages);
            hashtable.Add("name", name);
            hashtable.Add("location", location);
            hashtable.Add("gender", gender);
            hashtable.Add("description", description);
            hashtable = SQL.InsertData("userprofiles", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        #endregion
    }
}