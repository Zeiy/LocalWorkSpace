using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using DataAccess;
using DataAccess.DataLogic;
using DataAccess.Model;
using Newtonsoft.Json;

namespace NetBar.AjaxServer
{
    /// <summary>
    /// AccountShenHe 的摘要说明
    /// </summary>
    public class AccountShenHe : IHttpHandler,IRequiresSessionState
    {
        private readonly AccountDescriptionDataAccess _accountDescriptionDataAccess = new AccountDescriptionDataAccess();
        private readonly AccountInfoDataAccess _accountinfodataaccess = new AccountInfoDataAccess();
        public void ProcessRequest(HttpContext context)
        {
            JsonResult result = new JsonResult();
            context.Response.ContentType = "application/json";
            string op = context.Request.Form.Get("op");
            if (string.IsNullOrEmpty(op))
            {
                result.Status = 5;
                result.ErrorMsg = "用户操作名错误，请刷新页面重试！";
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }
            //检察登陆状态
            if (context.Session["UserName"] == null)
            {
                result.Status = 0;
                result.ErrorMsg = "用户登陆超时，请刷新页面重试！";
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }
            int infoId;
            if (!int.TryParse(context.Request.Form.Get("infoID"), out infoId))
            {
                result.Status = 2;
                result.ErrorMsg = "订单ID有误，请刷新页面重试！";
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }
            //检查 AccountDescription是否存在
            AccountDescription accountDescription = _accountDescriptionDataAccess.GetModelByAccountInfoId(infoId);
            if (accountDescription==null||accountDescription.ID<=0)
            {
                result.Status = 3;
                result.ErrorMsg = "订单不存在！";
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }
            //如果不是待审核的订单
            if (accountDescription.OrderStatus != OrderStatus.ShenHe)
            {
                result.Status = 6;
                result.ErrorMsg = "订单状态有误，请重试！";
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }

            AccountInfoModel accountInfoModel = _accountinfodataaccess.GetModel(accountDescription.AccountInfoID);
            switch (op)
            {
                case "refuse":
                {
                    //添加备注信息
                    string markStr = context.Request.Form["errorContent"].Trim();
                    if (string.IsNullOrEmpty(markStr))
                    {
                        result.Status = 4;
                        result.ErrorMsg = "订单审核错误信息为空！";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    //添加错误信息，更新订单状态
                    accountDescription.OrderStatus = OrderStatus.ShenHeFail;
                    accountDescription.Remark = HttpUtility.HtmlEncode(markStr);
                    accountDescription.EditDate = DateTime.Now;
                    accountDescription.EditUser = context.Session["UserName"].ToString();
                    //更新AccountInfo表订单状态

                    accountInfoModel.OrderStatus = OrderStatus.ShenHeFail;
                    //:todo 写入数据库改成事务处理
                    var res = _accountinfodataaccess.Update(accountInfoModel);
                    if (res)
                    {
                        var description = _accountDescriptionDataAccess.Update(accountDescription);
                        if (description)
                        {
                            result.Status = 10;
                            result.ErrorMsg = "操作成功！";
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            return;
                        }
                    }
                    break;
                }
                case "commit":
                {
                    List<string> sqlList = new List<string>();
                    string sqlStr = "update AccountDescription set OrderStatus = 4 where AccountInfoID = " + accountInfoModel.ID + " and ID =" + accountDescription.ID;
                    string sqlStr1 = "update AccountInfo set OrderStatus = 4 where ID = " + accountInfoModel.ID;
                    sqlList.Add(sqlStr);
                    sqlList.Add(sqlStr1);
                    int res = DbHelperSQL.ExecuteSqlTran(sqlList);
                    if (res == 2)
                    {
                        result.Status = 10;
                        result.ErrorMsg = "操作成功！";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    else
                    {
                        result.Status = 11;
                        result.ErrorMsg = "操作失败！";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }


                    break;
                }default:
                {
                    result.Status = 8;
                    result.ErrorMsg = "操作失败！";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    break;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class JsonResult
    {
        public int Status { get; set; }
        public string ErrorMsg { get; set; }
    }
}