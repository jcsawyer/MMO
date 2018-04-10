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
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool validated = Objects.User.Validate(Username.Text.Trim(), Functions.Hash(Password.Text));
            bool banned = Objects.User.CheckBanned(Username.Text.Trim());
            if (validated)
            {
                if (!banned)
                {
                    Objects.Session session = new Session();
                    Objects.User user = new User();
                    Objects.Village village = new Objects.Village();

                    user = User.GetUser(Username.Text.Trim());
                    village = Objects.Village.GetCapitalVillage(user.ID);

                    session.User = user;
                    session.Village = village;

                    Game.Session = session;

                    int villages = Objects.Village.GetVillages("owner = '" + user.ID + "'").Count;
                    if (villages == 1)
                        Response.Redirect("~/village.aspx");
                    else
                        Response.Redirect("~/overview.aspx");
                }
                else
                    ErrorLabel.Text = "Account banned";
            }
            else
                ErrorLabel.Text = "Login failed";
        }
    }
}