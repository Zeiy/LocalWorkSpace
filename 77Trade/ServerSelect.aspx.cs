using DataAccess.DataLogic;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _77Trade
{
    public partial class ServerSelect : System.Web.UI.Page
    {
        public List<GameAreas> GameAreasList = new List<GameAreas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //拿到区服信息
            //区服所属的服务器
            string gameID = Request.QueryString.Get("gameID");
            int intGameID;
            if (!int.TryParse(gameID, out intGameID)) {
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('游戏ID出错')</script>");
                //直接反回主页
                Response.Redirect("/Index.aspx");
                return;
            }
            GameAreaDataAccess gameAreaDA = new GameAreaDataAccess();
            GameServerDataAccess gsDA = new GameServerDataAccess();
            List<GameArea> areaList = gameAreaDA.GameAreaList();
            if (areaList == null || areaList.Count <= 0) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('读取服务器信息失败，请返回首页重试！');window.location.href='/Index.aspx'</script>");
                return;
            }
          
            foreach (var item in areaList)
            {
                GameAreas gas = new GameAreas();
                gas.AreaName = item.AreaName;
                gas.ServerList = gsDA.GetGameServerByGameIDandAreaId(intGameID, item.ID);
                GameAreasList.Add(gas);
            }
        }
    }
    public class GameAreas
    {
        public string AreaName { get; set; }
        public List<GameServer> ServerList { get; set; }

    }
}