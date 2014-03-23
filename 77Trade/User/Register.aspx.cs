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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly UserDataAccess _userDataAccess = new UserDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //:todo 数据校验
            string userMoblie = userMobile.Text.Trim();
            string userPwdStr = userPwd.Text.Trim();
            string payPwdStr = payPwd.Text.Trim();
            string secretQuesStr = secretQuestion.Text.Trim();
            string secretAnswerStr = secretAnswer.Text.Trim();
            string email = userEmail.Text.Trim();
            //检察用户是否已存在
            bool checkUserExist = _userDataAccess.CheckExistByUserName(userMoblie);
            if (checkUserExist)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('用户已存在！');</script>");
                return;
            }
            FrontUser frontUser = new FrontUser();
            frontUser.UserName = userMoblie;
            //用户昵称名，暂用帐户名
            frontUser.UserRoleName = userMoblie;
            frontUser.UserStatus = UserStatus.Normal;
            frontUser.Email = email;
            frontUser.Mobile = userMoblie;
            frontUser.Password = userPwdStr;
            frontUser.PayPassword = payPwdStr;
            frontUser.SecretAnswer = secretAnswerStr;
            frontUser.SecretQuestion = secretQuesStr;
            var res = _userDataAccess.Add(frontUser);
            if (res > 0)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('注册成功！');</script>");
            }
        }
    }
}