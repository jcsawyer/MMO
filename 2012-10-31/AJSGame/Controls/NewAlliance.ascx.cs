using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJSGame.Core;
using AJSGame.Objects;

namespace AJSGame.Controls
{
    public partial class NewAlliance : AJSGame.Core.ControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (!AJSGame.Objects.Alliance.Exists(Name.Text, Tag.Text))
            {
                AJSGame.Objects.Alliance.NewAlliance(Name.Text, Tag.Text, Description.Text.ToString().Replace(Environment.NewLine, "<br />"), AJSGame.Game.Session.User);
                Response.Redirect(Request.RawUrl);
            }
            else
                ErrorLabel.Text = "Alliance name or tag already exists.";
        }
    }
}