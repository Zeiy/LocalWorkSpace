using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace _77Trade
{
    public class UserPageBase:Page
    {
        private UserDataAccess _userdatatAccess = new UserDataAccess();
        private FrontUser _frontUser;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //用户未登陆跳回登陆页
            //参数处理
            var reqUrl = Request.Url;
            if (Session["UserName"] == null)
            {
                Response.Redirect("/User/Login.aspx?returnUrl=" + reqUrl.AbsolutePath + reqUrl.Query);
            }
        }

        public FrontUser CurrentUser {
            get
            {
                if (_frontUser != null) return _frontUser;
                return _frontUser = _userdatatAccess.GetFrontUserByUserName(Session["UserName"].ToString());
            }
        }
    }
}