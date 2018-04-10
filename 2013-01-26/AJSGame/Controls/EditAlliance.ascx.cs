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
    public partial class EditAlliance : AJSGame.Core.ControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AJSGame.Objects.Alliance alliance = AJSGame.Objects.Alliance.GetAlliance(AJSGame.Game.Session.User.Alliance);

            MembersGridView.DataSource = AJSGame.Objects.User.GetUsers("aref = '" + alliance.ID + "'");
            MembersGridView.DataBind();

            AllianceTitleLabel.Text = String.Format("Edit Alliance : [{0}] {1}", alliance.Tag, alliance.Name);
            DescriptionTextbox.Text = alliance.Description.ToString().Replace("<br />", Environment.NewLine);
            AllianceNameLabel.Text = alliance.Name;
            AllianceTagLabel.Text = alliance.Tag;
            FoundedLabel.Text = String.Format("{0} by {1}", AJSGame.Core.Functions.DateFriendly(alliance.Created), alliance.Founder);
            MemberCountLabel.Text = AJSGame.Objects.User.GetUsers("aref = '" + alliance.ID + "'").Count.ToString();
            TotalPointsLabel.Text = alliance.Points.ToString();
            ConstructionPointsLabel.Text = alliance.CP.ToString();
            OffensivePointsLabel.Text = alliance.AP.ToString();
            DefensivePointsLabel.Text = alliance.DP.ToString();
            RankLabel.Text = alliance.Rank.ToString();
        }

        protected void UpdateAlliance_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Alliance alliance = AJSGame.Objects.Alliance.GetAlliance(AJSGame.Game.Session.User.Alliance);
            alliance.Update(DescriptionTextbox.Text.ToString().Replace(Environment.NewLine, "<br />"));
            Response.Redirect("~/alliance.aspx");
        }

        protected void MembersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Objects.User user = (Objects.User)e.Row.DataItem;
                DropDownList ddl = (DropDownList)e.Row.FindControl("RoleDropDownList");
                Button btn = (Button)e.Row.FindControl("RemoveButton");
                ddl.SelectedValue = user.Role;
                if (user.Username == AJSGame.Game.Session.User.Username)
                {
                    ddl.Enabled = false;
                    btn.Enabled = false;
                }
            }
        }

        protected void RoleDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            for (int i = 0; i < MembersGridView.Rows.Count; i++)
            {
                DropDownList control = (DropDownList)MembersGridView.Rows[i].FindControl("RoleDropDownList");
                if (ddl.ClientID == control.ClientID)
                {
                    Objects.User user = Objects.User.GetUser((int)MembersGridView.DataKeys[i].Value);
                    user.ChangeRole(ddl.SelectedValue);
                    break;
                }
            }
        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            for (int i = 0; i < MembersGridView.Rows.Count; i++)
            {
                Button control = (Button)MembersGridView.Rows[i].FindControl("RemoveButton");
                if (btn.ClientID == control.ClientID)
                {
                    Objects.User user = Objects.User.GetUser((int)MembersGridView.DataKeys[i].Value);
                    user.ChangeAlliance(0);
                    user.ChangeRole("");
                    Response.Redirect(Request.RawUrl);
                    break;
                }
            }
        }

        protected void DisbandAlliance_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Alliance alliance = AJSGame.Objects.Alliance.GetAlliance(AJSGame.Game.Session.User.Alliance);
            alliance.Delete();
            Response.Redirect("~/alliance.aspx");
        }
    }
}