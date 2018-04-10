using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;
using AJSGame.Objects;

namespace AJSGame.Controls
{
    public partial class Inbox : AJSGame.Core.ControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InboxGridView.DataSource = AJSGame.Objects.Message.GetMessages("recipient = '" + AJSGame.Game.Session.User.Username + "' AND type = 'inbox'");
                InboxGridView.DataBind();
            }
        }

        protected void InboxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Read")) == true)
                {
                }
                else
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#3399FF");
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void InboxGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageFormView.Visible = true;
            Message message = AJSGame.Objects.Message.GetMessage((int)InboxGridView.SelectedDataKey.Value);
            if (!message.Read)
                message.UpdateRead();
        }

        protected void InboxGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InboxGridView.PageIndex = e.NewPageIndex;
            InboxGridView.DataBind();
        }

        protected void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            List<int> idCollection = new List<int>();
            for (int i = 0; i < InboxGridView.Rows.Count; i++)
            {
                CheckBox checkBox = (CheckBox)InboxGridView.Rows[i].Cells[0].FindControl("SelectCheckBox");
                if (checkBox != null)
                {
                    if (checkBox.Checked)
                        idCollection.Add((int)InboxGridView.DataKeys[i].Value);
                }
            }
            if (idCollection.Count > 0)
            {
                DeleteMultiple(idCollection);
                InboxGridView.DataBind();
            }
        }

        private void DeleteMultiple(List<int> idCollection)
        {
            foreach (int i in idCollection)
            {
                AJSGame.Objects.Message.DeleteMessage(AJSGame.Objects.Message.GetMessage(i));
            }
        }

        protected void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check = false;
            if (CheckAll.Checked)
                check = true;
            foreach (GridViewRow row in InboxGridView.Rows)
            {
                CheckBox checkBox = (CheckBox)row.Cells[0].FindControl("SelectCheckBox");
                checkBox.Checked = check;
            }
        }
    }
}