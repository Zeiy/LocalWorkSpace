using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace _77Trade.User
{
    public partial class Login : System.Web.UI.Page
    {
        private UserDataAccess _userDataAccess = new UserDataAccess();
        private string _returnUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            _returnUrl = Request.QueryString.Get("returnUrl");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
          
            string userNameStr = UserName.Text.Trim();
            string passWord = Password.Text.Trim();
            FrontUser frontUser = _userDataAccess.GetFrontUserByUserName(userNameStr);
            if (frontUser == null || frontUser.ID <= 0)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('用户信息验证失败！');</script>");
                return;
            }
            if (passWord == frontUser.Password)
            {

                //通过验证 把用户名写入Session
                Session["UserName"] = userNameStr;
                if (!string.IsNullOrEmpty(_returnUrl))
                {
                    Response.Redirect(_returnUrl);
                }
                else
                {
                    Response.Redirect("/AccountSaleList.aspx");
                }
            }
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('用户信息验证失败！');</script>");
        }
    }
}