using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Model;

namespace _77Trade
{
    public partial class Common : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string CurrentUserName {
            get
            {
                if (Session["UserName"] == null)
                {
                    return "游客";
                }
                else
                {
                    return Session["UserName"].ToString();
                }
            }
        }
    }
}