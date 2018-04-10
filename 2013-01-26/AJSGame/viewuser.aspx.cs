using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class ViewUser : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AJSGame.Objects.User.Exists(Convert.ToInt32(Request.QueryString["id"])))
            {
                AJSGame.Objects.User user = AJSGame.Objects.User.GetUser(Convert.ToInt32(Request.QueryString["id"]));

                VillagesGridView.DataSource = AJSGame.Objects.Village.GetVillages("owner = '" + user.ID + "'");
                VillagesGridView.DataBind();

                UsernameTitleLabel.Text = (user.Alliance != 0 ? String.Format("[{0}] {1}", AJSGame.Objects.Alliance.GetAlliance(user.Alliance).Tag, user.Username) : user.Username);
                AvatarImage.ImageUrl = (user.Profile.Avatar != "" ? String.Format("~/Images/Avatars/{0}.gif", user.Profile.Avatar) : "~/Images/Avatars/Blank.gif");
                UsernameLabel.Text = user.Username;
                AllianceHyperLink.Text = (user.Alliance != 0 ? AJSGame.Objects.Alliance.GetAlliance(user.Alliance).Name : "");
                AllianceHyperLink.NavigateUrl = (user.Alliance != 0 ? String.Format("~/viewalliance.aspx?id={0}", AJSGame.Objects.Alliance.GetAlliance(user.Alliance).ID) : "");
                CreatedLabel.Text = AJSGame.Core.Functions.DateFriendly(user.Created);
                TotalPointsLabel.Text = user.Points.ToString();
                ConstructionPointsLabel.Text = user.CP.ToString();
                OffensivePointsLabel.Text = user.AP.ToString();
                DefensivePointsLabel.Text = user.DP.ToString();
                RankLabel.Text = user.Rank.ToString();
                NameLabel.Text = user.Profile.Name;
                LocationLabel.Text = user.Profile.Location;
                GenderLabel.Text = AJSGame.Core.Functions.LabelsGender(user.Profile.Gender);
                DescriptionLabel.Text = user.Profile.Description;
            }
            else
                Response.Redirect("user.aspx");
        }
    }
}