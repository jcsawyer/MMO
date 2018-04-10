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
    public partial class Compose : AJSGame.Core.ControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (AJSGame.Objects.User.Exists(Username.Text))
            {
                if (AJSGame.Objects.Message.NewMessage(Title.Text, AJSGame.Game.Session.User.Username, Username.Text, Body.Text.ToString().Replace(Environment.NewLine, "<br />")))
                    Response.Redirect("~/mail.aspx?mode=inbox");
                else
                    ErrorLabel.Text = "Error";
            }
            else
                ErrorLabel.Text = "User does not exist";
        }
    }
}