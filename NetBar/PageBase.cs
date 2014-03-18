using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;

namespace NetBar
{
    public class PageBase:Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnInit(EventArgs e)
        {
                base.OnInit(e);
            //用户未登陆跳回登陆页
            var reqUrl = Request.Url;
                if (Session["UserName"] == null) {
                    Response.Redirect("/Login.aspx?returnUrl="+reqUrl.AbsolutePath);
                }
        }
    }
}