using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class TopUsers : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersGridView.DataSource = AJSGame.Objects.User.GetUsers();
            UsersGridView.DataBind();
        }

        protected void UsersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersGridView.PageIndex = e.NewPageIndex;
            UsersGridView.DataBind();
        }
    }
}