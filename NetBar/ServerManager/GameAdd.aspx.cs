using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace NetBar.ServerManager
{
    public partial class GameAdd : PageBase
    {
        readonly GameInfoDataAccess _gameInfoDa = new GameInfoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var gameNameStr = gameName.Text.Trim();
            if (string.IsNullOrEmpty(gameNameStr))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('游戏名不能为空，请重新输入！')</script>");
                return;
            }
            var gameInfo = new GameInfo { AddTime = DateTime.Now, GameName = gameNameStr, OperationName = "" };
            var res = _gameInfoDa.Add(gameInfo);
            if (res > 0)
            {
                //添加成功后返回列表页
                Response.Redirect("/ServerManager/GameList.aspx");
            }
        }
    }
}