using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Message
    {
        #region Properties

        public int ID { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Body { get; set; }
        public DateTime Sent { get; set; }
        public DateTime? ReadTime { get; set; }
        public bool Read { get; set; }
        public string Type { get; set; }
        public int Twin { get; set; }

        #endregion

        #region Private Static Methods

        private static void Fill(DataRow dr, Message message)
        {
            message.ID = Convert.ToInt32(dr["id"]);
            message.Title = dr["title"].ToString();
            message.Sender = dr["sender"].ToString();
            message.Recipient = dr["recipient"].ToString();
            message.Body = dr["body"].ToString();
            message.Sent = Convert.ToDateTime(dr["sent"]);
            message.ReadTime = (dr["readtime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["readtime"]));
            message.Read = Convert.ToBoolean(dr["read"]);
            message.Type = dr["type"].ToString();
            message.Twin = Convert.ToInt32(dr["twin"]);
        }

        #endregion

        #region Public Methods

        public void Delete()
        {
            DeleteMessage(this);
            this.ID = 0;
        }

        public void UpdateRead()
        {
            UpdateMessageRead(this);
            Message Twin = GetMessage(this.Twin);
            UpdateMessageRead(Twin);
        }

        #endregion

        #region Public Static Methods

        public static Message GetMessage(int id)
        {
            Message result = new Message();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM messages WHERE id = '" + id + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                Fill(ds.Tables[0].Rows[0], result);
            return result;
        }

        public static List<Message> GetMessages()
        {
            List<Message> result = new List<Message>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM messages ORDER BY sent DESC");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Message message = new Message();
                    Fill(dr, message);
                    result.Add(message);
                }
            }
            return result;
        }

        public static List<Message> GetMessages(string where)
        {
            List<Message> result = new List<Message>();
            DataSet ds = SQL.ExecuteDataset("SELECT * FROM messages WHERE " + where + " ORDER BY sent DESC");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Message message = new Message();
                    Fill(dr, message);
                    result.Add(message);
                }
            }
            return result;
        }

        public static bool NewMessage(string title, string sender, string recipient, string body)
        {
            bool result;
            // Inbox
            Hashtable hashtableIn = new Hashtable();
            hashtableIn.Add("title", title);
            hashtableIn.Add("sender", sender);
            hashtableIn.Add("recipient", recipient);
            hashtableIn.Add("body", body);
            hashtableIn.Add("sent", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtableIn.Add("readtime", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtableIn.Add("read", 0);
            hashtableIn.Add("type", "inbox");
            hashtableIn = SQL.InsertData("messages", hashtableIn);
            // Outbox
            Hashtable hashtableOut = new Hashtable();
            hashtableOut.Add("title", title);
            hashtableOut.Add("sender", sender);
            hashtableOut.Add("recipient", recipient);
            hashtableOut.Add("body", body);
            hashtableOut.Add("sent", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtableOut.Add("readtime", AJSGame.Core.Functions.DateString(DateTime.UtcNow));
            hashtableOut.Add("read", 0);
            hashtableOut.Add("type", "outbox");
            hashtableOut.Add("twin", (int)hashtableIn["Identity"]);
            hashtableOut = SQL.InsertData("messages", hashtableOut);

            Hashtable hashtableTwinIn = new Hashtable();
            hashtableTwinIn.Add("twin", (int)hashtableOut["Identity"]);
            hashtableTwinIn = SQL.UpdateData("messages", "id = '" + hashtableIn["Identity"] + "'", hashtableTwinIn);

            if (hashtableIn["Error"] != null | hashtableOut["Error"] != null | hashtableTwinIn["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        public static void DeleteMessage(Message message)
        {
            Hashtable hashtable = SQL.DeleteData("messages", "id = '" + message.ID + "'");
        }

        public static bool UpdateMessageRead(Message message)
        {
            bool result;
            Hashtable hashtable = new Hashtable();
            if (message.Read == true)
                hashtable.Add("read", 0);
            else if (message.Read == false)
                hashtable.Add("read", 1);
            hashtable = SQL.UpdateData("messages", "id = '" + message.ID + "'", hashtable);
            if (hashtable["Error"] != null)
                result = false;
            else
                result = true;
            return result;
        }

        #endregion
    }
}