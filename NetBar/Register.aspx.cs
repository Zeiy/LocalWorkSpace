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
    public partial class Register : System.Web.UI.Page
    {
        UserDataAccess userDataAccess = new UserDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            string name = userName.Text.Trim();
            string pwd = userPwd.Text.Trim();
            string secondPwd = rePwd.Text.Trim();
            if (pwd != secondPwd) {
                warmMsg.Text = "两次密码输入不一致，请重新输入！";
                return;
            }
            if (string.IsNullOrEmpty(name)) {
                warmMsg.Text = "用户名不能为空！";
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                warmMsg.Text = "密码不能为空！";
                return;
            }
            //新建用户
            UserModel userModel = new UserModel();
            userModel.UserName = name;
            userModel.Password = pwd;
            bool isExist = userDataAccess.CheckUserExist(userModel);
            if (isExist) {
                warmMsg.Text = "用户名已存在，请重新输入！";
                return;
            }
            userModel = userDataAccess.InsertUser(userModel);
            if (userModel.ID > 0) {
                warmMsg.Text = "注册成功！";
            }          

        }
    }
}