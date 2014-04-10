using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.DataLogic;
using DataAccess.Model;
using Newtonsoft.Json;

namespace NetBar.AccessPort
{
    /// <summary>
    /// GetDaiShenHeOrder 的摘要说明
    /// </summary>
    public class GetDaiShenHeOrder : IHttpHandler
    {
        private readonly AccountInfoDataAccess _accountDescriptionDataAccess = new AccountInfoDataAccess();

        public void ProcessRequest(HttpContext context)
        {
            JsonResult jsonResult = new JsonResult();
            //参数处理
            string operationType = context.Request.Form["op"];
            int intOperation;
            if (!int.TryParse(operationType, out intOperation))
            {
                intOperation = 0;
            }
            switch (intOperation)
            {
                case 1:
                {
                    jsonResult.Status = 1;
                    jsonResult.Msg = "Success";
                    context.Response.Write(JsonConvert.SerializeObject(jsonResult));
                    break;

                }
                default:
                {
                    context.Response.ContentType = "application/json";
                    var result = _accountDescriptionDataAccess.GetAccountInfoModelsList(" OrderStatus =3");
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    break;
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    public class JsonResult

    {
        public int Status { get; set; }
        public string Msg { get; set; }
    }

}