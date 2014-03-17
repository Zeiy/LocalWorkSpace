using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace _77Trade.services
{
    /// <summary>
    /// GetGameServerList 的摘要说明
    /// </summary>
    public class GetGameServerList : IHttpHandler
    {
        private readonly GameServerDataAccess _gameServerDataAccess = new GameServerDataAccess();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string gameId = context.Request.Form.Get("gameId");
            string gameArea = context.Request.Form.Get("areaID");
            int intGameId, intGameArea;
            if (!int.TryParse(gameId, out intGameId) || !int.TryParse(gameArea, out intGameArea))
            {
                object result = new
                {
                    status = 0,
                    errorMsg ="用户参数有误！"
                };
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                return;
            }
            List<GameServer> serverList = _gameServerDataAccess.GetGameServerByGameIDandAreaId(intGameId, intGameArea);
            if (serverList != null && serverList.Count >= 0)
            {
                object result = new
                {
                    status = 1,
                    errorMsg = "成功了！",
                    ServerList = serverList
                };
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
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
}