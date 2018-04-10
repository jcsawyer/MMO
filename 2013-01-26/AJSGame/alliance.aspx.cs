using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;
using AJSGame.Objects;

namespace AJSGame
{
    public partial class Alliance : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl control = new UserControl();
            if (!AJSGame.Objects.User.IsAllianceMember(AJSGame.Game.Session.User))
                control = (UserControl)Page.LoadControl("~/Controls/NewAlliance.ascx");
            else
                control = (UserControl)Page.LoadControl("~/Controls/Alliance.ascx");

            if (Request.QueryString["mode"] != null && (AJSGame.Game.Session.User.Role == "leader" | AJSGame.Game.Session.User.Role == "officer"))
            {
                switch (Request.QueryString["mode"])
                {
                    case "edit":
                        control = (UserControl)Page.LoadControl("~/Controls/EditAlliance.ascx");
                        break;
                }
            }

            ControlPlaceHolder.Controls.Add(control);
        }
    }
}