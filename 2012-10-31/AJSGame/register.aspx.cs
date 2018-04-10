using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using AJSGame.Core;
using AJSGame.Objects;

namespace AJSGame
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Username.Text.Trim() == "Server" | Username.Text.Trim() == "server")
            {
                ErrorLabel.Text = "Invalid Username";
            }
            else
            {
                if (Objects.User.Exists(Username.Text.Trim()))
                    ErrorLabel.Text = "User exists";
                else
                {
                    if (!Objects.User.NewUser(Username.Text.Trim(), Functions.Hash(Password.Text), Email.Text.Trim(), Convert.ToInt32(MapPositionRadio.SelectedValue)))
                        ErrorLabel.Text = "Error registering";
                    else
                    {
                        // TODO : Send welcome message
                        Response.Redirect("~/default.aspx");
                    }
                }
            }
        }
    }
}