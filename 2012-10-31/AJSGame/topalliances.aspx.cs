using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJSGame
{
    public partial class TopAlliances : AJSGame.Core.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlliancesGridView.DataSource = AJSGame.Objects.Alliance.GetAlliances();
            AlliancesGridView.DataBind();
        }

        protected void AlliancesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AlliancesGridView.PageIndex = e.NewPageIndex;
            AlliancesGridView.DataBind();
        }
    }
}