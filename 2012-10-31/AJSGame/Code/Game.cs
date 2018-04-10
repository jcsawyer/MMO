using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AJSGame.Objects;

namespace AJSGame
{
    public class Game
    {
        public static string Title
        {
            get { return "AJSGame"; }
        }

        public static string Version
        {
            get { return "Beta 1"; }
        }

        public static string Copyright
        {
            get { return "Copyright &copy; 2012 by AJSGames.co.uk"; }
        }

        public static Session Session
        {
            get { return (Session)HttpContext.Current.Session["Session"]; }
            set { HttpContext.Current.Session["Session"] = value; }
        }
    }
}