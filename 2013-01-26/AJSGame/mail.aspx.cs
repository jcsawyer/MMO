using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class Mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl control = new UserControl();
            if (Request.QueryString["mode"] != "")
            {
                switch (Request.QueryString["mode"])
                {
                    case "inbox":
                        control = (UserControl)Page.LoadControl("~/Controls/Inbox.ascx");
                        break;
                    case "outbox":
                        control = (UserControl)Page.LoadControl("~/Controls/Outbox.ascx");
                        break;
                    case "compose":
                        control = (UserControl)Page.LoadControl("~/Controls/Compose.ascx");
                        break;
                    default:
                        Response.Redirect("~/village.aspx");
                        break;
                }
            }
            else
                Response.Redirect("~/village.aspx");
            ControlPlaceHolder.Controls.Add(control);
        }
    }
}