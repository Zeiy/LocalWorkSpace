using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace _77Trade.services
{
    /// <summary>
    /// fileSave 的摘要说明
    /// </summary>
    public class FileSave : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //用户选择多次上传图片时，上传时会提交所有上传文件
            string imgType = context.Request.Form["Sign"];
            string uploadPath = HttpContext.Current.Server.MapPath("\\Uploadfile\\");
            //如果上传文件分类为空直接返回
            if (string.IsNullOrEmpty(imgType)) {
                return;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            HttpPostedFile file;
            switch (imgType) { 
                case "ShenFenA":{
                    file = context.Request.Files["ShenFenA"];
                    uploadPath += "ShenFenZheng\\";
                break;
                }
                case "ShenFenB": {
                    file = context.Request.Files["ShenFenB"];
                    uploadPath += "ShenFenZheng\\";
                    break;
                }
                case "FileSecretCard":{
                    file = context.Request.Files["FileSecretCard"];
                    uploadPath += "MiBaoKa\\";
                    break;
                }
                case "gameImg":
                {
                    file = context.Request.Files["gameImg"];
                    uploadPath += "gameImg\\";
                    break;
                }

                default: { return; }
            }
            //限制同一用户上传图片个数，一个用户只能上传四张图片
            if (file != null)
            {
                //判断文件类型 gif|jpe?g|png
                string extension = Path.GetExtension(file.FileName);
                if (extension != ".gif" && extension != ".jpeg" && extension != ".jpg" && extension != ".png") {
                    context.Response.ContentType = "application/json";
                    context.Response.Charset = "utf-8";
                    context.Response.Write("错误文件类型");
                    return;
                }
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file.InputStream);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                string md5Name = sb.ToString();
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //图片名称由用户ID+图片名称（密保卡、身份证a,身份证b）
                file.SaveAs(uploadPath + md5Name + extension);
                ImgSaveResult imgSaveResult = new ImgSaveResult();
                imgSaveResult.Status = 1;
                imgSaveResult.FileName = md5Name + extension;
                string jsonStr = JsonConvert.SerializeObject(imgSaveResult);
                context.Response.Write(jsonStr);
            }
            else
            {
                context.Response.Write("0");
            }  
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class ImgSaveResult
        {
            public string FileName { get; set; }
            public int Status { get; set; }
        }
    }
}