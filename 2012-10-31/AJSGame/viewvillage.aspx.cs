using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class ViewVillage : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AJSGame.Objects.Village.Exists(Convert.ToInt32(Request.QueryString["id"])))
            {
                AJSGame.Objects.Village village = AJSGame.Objects.Village.GetVillage(Convert.ToInt32(Request.QueryString["id"]));
                AJSGame.Objects.User owner = AJSGame.Objects.User.GetUser(village.Owner);

                VillageNameTitleLabel.Text = village.Name;
                VillageNameLabel.Text = village.Name;
                CoordinatesLabel.Text = String.Format("{0}|{1}", village.X, village.Y);
                PointsLabel.Text = village.CP.ToString();
                OwnerHyperLink.Text = owner.Username;
                OwnerHyperLink.NavigateUrl = String.Format("~/viewuser.aspx?id={0}", village.Owner);
                if (owner.Alliance != 0)
                {
                    AllianceHyperLink.Text = AJSGame.Objects.Alliance.GetAlliance(owner.Alliance).Name;
                    AllianceHyperLink.NavigateUrl = String.Format("~/viewalliance.aspx?id={0}", owner.Alliance);
                }
            }
            else
                Response.Redirect("user.aspx");
        }

        protected void AttackButton_Click(object sender, EventArgs e)
        {
            AJSGame.Objects.Village village = AJSGame.Objects.Village.GetVillage(Convert.ToInt32(Request.QueryString["id"]));
            Response.Redirect("~/building.aspx?build=rally&x=" + village.X + "&y=" + village.Y);
        }

        protected void MapButton_Click(object sender, EventArgs e)
        {

        }
    }
}