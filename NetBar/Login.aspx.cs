using NetBar.DataAccess;
using NetBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetBar
{
    public partial class Login : System.Web.UI.Page
    {
        UserDataAccess userAccess = new UserDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 用户登陆流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void login_Click(object sender, EventArgs e)
        {
            string name = username.Text.Trim();
            string pwd = userPwd.Text.Trim();
            if (string.IsNullOrEmpty(name)) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('用户名不能为空，请重新输入！')</script>");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('密码不能为空，请重新输入！')</script>");
                return;
            }
            UserModel userModel = new UserModel();
            userModel.UserName = name;
            //检察用户名是否存在
            bool isExist = userAccess.CheckUserExist(userModel);
            if (!isExist) {
                ClientScript.RegisterClientScriptBlock(this.GetType(),"alert","<script>alert('用户不存在，请重新输入帐号信息！')</script>");
                return;
            }
            userModel = userAccess.GetUserByName(name);
            if (userModel.Password == pwd)
            {
                //如果有returnUrl 则反回returnUrl
                string returnUrl = Request.QueryString.Get("returnUrl");
                Session["UserName"] = userModel.UserName;
                Response.Redirect(string.IsNullOrEmpty(returnUrl) ? "/index.aspx" : returnUrl);
            }
            else {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('帐号或密码有误，请重试！')</script>");
            }
        }
    }
}