using System;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace NetBar.GameManager
{
    public partial class GameAdd : PageBase
    {
        readonly GameInfoDataAccess _gameInfoDa = new GameInfoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            //检察当前登陆用户
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var gameNameStr = gameName.Text.Trim();
            if (string.IsNullOrEmpty(gameNameStr)) {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('游戏名不能为空，请重新输入！')</script>");
                return;
            }
            var gameInfo = new GameInfo {AddTime = DateTime.Now, GameName = gameNameStr, OperationName = ""};
            var res =  _gameInfoDa.Add(gameInfo);
            if (res > 0) { 
            //添加成功后返回列表页
                Response.Redirect("/GameManager/GameInfoMg.aspx");
            }
        }
    }
}