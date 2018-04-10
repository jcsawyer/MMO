using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class ViewAlliance : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AJSGame.Objects.Alliance.Exists(Convert.ToInt32(Request.QueryString["id"])))
            {
                AJSGame.Objects.Alliance alliance = AJSGame.Objects.Alliance.GetAlliance(Convert.ToInt32(Request.QueryString["id"]));

                MembersGridView.DataSource = AJSGame.Objects.User.GetUsers("aref = '" + alliance.ID + "'");
                MembersGridView.DataBind();

                AllianceTitleLabel.Text = String.Format("[{0}] {1}", alliance.Tag, alliance.Name);
                DescriptionLabel.Text = alliance.Description;
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
            else
                Response.Redirect("alliance.aspx");
        }
    }
}