using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class Overview : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VillagesGridView.DataSource = AJSGame.Objects.Village.GetVillages("owner = '" + AJSGame.Game.Session.User.ID + "'");
            VillagesGridView.DataBind();
        }

        protected void VillagesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int id;
                id = Convert.ToInt32(e.CommandArgument);

                AJSGame.Game.Session.Village = AJSGame.Objects.Village.GetVillage(id);

                Response.Redirect("~/village.aspx");
            }
        }
    }
}