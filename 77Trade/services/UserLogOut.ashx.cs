using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using DataAccess.Model;
using Newtonsoft.Json;

namespace _77Trade.services
{
    /// <summary>
    /// UserLogOut 的摘要说明
    /// </summary>
    public class UserLogOut : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Session["UserName"] = null;
             JsonResult jsonResult = new JsonResult();
            jsonResult.Status = 1;
            jsonResult.Url = "";
            context.Response.Write(JsonConvert.SerializeObject(jsonResult));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}