using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DataAccess.Model;
using Newtonsoft.Json;

namespace _77Trade.services
{
    /// <summary>
    /// FileDelete 的摘要说明
    /// </summary>
    public class FileDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //:todo 用户验证 Session 验证
            context.Response.ContentType = "application/json";
            JsonResult jsonResult = new JsonResult();
            string fileName = context.Request.Form["FilleName"];
            string fileType = context.Request.Form["FileType"];
            string filePath;
            filePath = HttpContext.Current.Server.MapPath("\\Uploadfile\\");
            switch (fileType)
            {
                case "ShenFenA":
                {
                    filePath += "ShenFenZheng\\";
                    break;
                }
                case "ShenFenB":
                {
                    filePath += "ShenFenZheng\\";
                    break;
                }
                case "FileSecretCard":
                {
                    filePath += "MiBaoKa\\";
                    break;
                }
            }
            bool fileExist = File.Exists(filePath + "\\" + fileName);
            if (!fileExist)
            {
                jsonResult.Status = 2;
                jsonResult.Msg = "文件不存在！";
                context.Response.Write(JsonConvert.SerializeObject(jsonResult));
                return;
            }
            try
            {
                File.Delete(filePath + "\\" + fileName);
            }
            catch (Exception)
            {
                jsonResult.Status = 3;
                context.Response.Write(JsonConvert.SerializeObject(jsonResult));
                throw;
            }
            jsonResult.Status = 1;
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