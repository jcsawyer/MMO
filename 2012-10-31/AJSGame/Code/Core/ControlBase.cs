using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJSGame.Core
{
    public class ControlBase : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["Session"] != null)
            {
                Objects.Session.Update();
                Objects.User.UpdateLastActivity(Game.Session.User.Username);
            }
            else
                Response.Redirect("~/default.aspx");

            base.OnInit(e);
        }
    }
}