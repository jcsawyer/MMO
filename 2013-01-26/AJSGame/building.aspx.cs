using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;

namespace AJSGame
{
    public partial class Building : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl control = new UserControl();
            if (Request.QueryString["build"] != "")
            {
                if (Functions.RequirementsBuilding(Request.QueryString["build"], Game.Session.Village))
                {
                    switch (Request.QueryString["build"])
                    {
                        case "main":
                            control = (UserControl)Page.LoadControl("~/Controls/Main.ascx");
                            break;
                        case "timbercamp":
                            control = (UserControl)Page.LoadControl("~/Controls/Timbercamp.ascx");
                            break;
                        case "claypit":
                            control = (UserControl)Page.LoadControl("~/Controls/Claypit.ascx");
                            break;
                        case "mine":
                            control = (UserControl)Page.LoadControl("~/Controls/Mine.ascx");
                            break;
                        case "farm":
                            control = (UserControl)Page.LoadControl("~/Controls/Farm.ascx");
                            break;
                        case "warehouse":
                            control = (UserControl)Page.LoadControl("~/Controls/Warehouse.ascx");
                            break;
                        case "granary":
                            control = (UserControl)Page.LoadControl("~/Controls/Granary.ascx");
                            break;
                        case "barracks":
                            control = (UserControl)Page.LoadControl("~/Controls/Barracks.ascx");
                            break;
                        case "stable":
                            control = (UserControl)Page.LoadControl("~/Controls/Stable.ascx");
                            break;
                        case "academy":
                            control = (UserControl)Page.LoadControl("~/Controls/Academy.ascx");
                            break;
                        case "workshop":
                            control = (UserControl)Page.LoadControl("~/Controls/Workshop.ascx");
                            break;
                        case "wall":
                            control = (UserControl)Page.LoadControl("~/Controls/Wall.ascx");
                            break;
                        case "market":
                            Response.Redirect("village.aspx");
                            break;
                        case "rally":
                            control = (UserControl)Page.LoadControl("~/Controls/RallyPoint.ascx");
                            break;
                        case "shelter":
                            control = (UserControl)Page.LoadControl("~/Controls/Shelter.ascx");
                            break;
                        default:
                            Response.Redirect("~/village.aspx");
                            break;
                    }
                }
                else
                    Response.Redirect("~/village.aspx");
            }
            else
                Response.Redirect("~/village.aspx");
            ControlPlaceHolder.Controls.Add(control);
        }
    }
}