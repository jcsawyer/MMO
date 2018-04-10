using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AJSGame.Core;

namespace AJSGame.Objects
{
    public class Session
    {
        public User User { get; set; }
        public Village Village { get; set; }

        public static void Update()
        {
            Session session = new Session();
            User user = Game.Session.User;
            Village village = Game.Session.Village;

            Functions.Calculate(user);
            Objects.User.UpdateLastActivity(user.Username);

            user = User.GetUser(Game.Session.User.ID);
            village = Village.GetVillage(Game.Session.Village.ID);

            session.User = user;
            session.Village = village;

            Game.Session = session;
        }
    }
}