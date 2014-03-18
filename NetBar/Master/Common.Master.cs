using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetBar.Master
{
    public partial class Common : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOut(object sender,EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("/Login.aspx");
        }
    }
}