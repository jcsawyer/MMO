using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJSGame.Core
{
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["Session"] != null)
            {
                Objects.Session.Update();
            }
            else
                Response.Redirect("~/default.aspx");

            base.OnPreInit(e);
        }
    }
}