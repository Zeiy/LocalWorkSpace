using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace NetBar.ServerManager
{
    public partial class GameDetail : PageBase
    {
        readonly GameAreaDataAccess _gameAreaDataAccess = new GameAreaDataAccess();
        readonly GameServerDataAccess _gameServerDataAccess = new GameServerDataAccess();
        readonly GameInfoDataAccess _gameInfoDataAccess = new GameInfoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            string gameId = Request.QueryString.Get("gameID");
            int gameIdInt;
            if (!int.TryParse(gameId, out gameIdInt))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('游戏ID有误，请返回列表重试！');window.location.href='GameList.aspx'</script>");
                return;
            }
            //填充Select
            if (IsPostBack) return;
            //根据游戏ID拿到游戏名称
            GameInfo gameInfo = _gameInfoDataAccess.GetModel(gameIdInt);
            if (gameInfo == null || gameInfo.ID <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('游戏ID有误，请返回列表重试！');window.location.href='GameList.aspx'</script>");
                return;
            }
            gameName.Text = gameInfo.GameName.Trim();
            hidGameID.Value = Convert.ToString(gameInfo.ID);
            //渲染下拉框
            List<GameArea> gameAreaList = _gameAreaDataAccess.GameAreaList();
            foreach (var item in gameAreaList)
            {
                ListItem listItem = new ListItem { Text = item.AreaName, Value = Convert.ToString(item.ID) };
                dplArea.Items.Add(listItem);
                DplAreaSelect.Items.Add(listItem);
            }
            List<GameServer> serverList = _gameServerDataAccess.GetGameServerByGameIDandAreaId(gameInfo.ID,
                gameAreaList[0].ID);
            foreach (var gameServer in serverList)
            {
                ListItem listItem = new ListItem();
                listItem.Text = gameServer.ServerName;
                listItem.Value = gameServer.ID.ToString();
                dplServers.Items.Add(listItem);
            }
            //添加服务器列表

        }
        /// <summary>
        /// 添加区服
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ServerAdd_Click(object sender, EventArgs e)
        {
            string gameId = hidGameID.Value;
            string areaId = dplArea.SelectedValue;
            GameInfo gameInfo = _gameInfoDataAccess.GetModel(Convert.ToInt32(gameId));
            GameServer newServer = new GameServer
            {
                AreaID = Convert.ToInt32(areaId),
                GameID = Convert.ToInt32(gameId),
                ServerName = newServerName.Text.Trim(),
                GameName = gameInfo.GameName,
                AreaName = (dplArea.SelectedItem).Text
            };
            //:todo 检查ID是否存在
            //返回新增实体的ID
            int res = _gameServerDataAccess.Add(newServer);
            if (res > 0)
            {
                //添加成功后,如果当前先区跟添加选区一样则把新服务器名添加到现有区服下拉列表
                if (dplArea.SelectedValue == DplAreaSelect.SelectedValue)
                {
                    ListItem newlistItem = new ListItem { Text = newServer.ServerName, Value = Convert.ToString(res) };
                    dplServers.Items.Add(newlistItem);
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('服务器添加成功！');</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('服务器添加失败，请重试！');window.location.href='GameInfoMg.aspx'</script>");
            }
        }
        /// <summary>
        /// 查看现有区服列表，加载相应的服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dplArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string areaId = DplAreaSelect.SelectedValue;
            string gameId = hidGameID.Value;
            int gameIDint, areaIDint;
            if (!int.TryParse(areaId, out areaIDint) || !int.TryParse(gameId, out gameIDint))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('游戏ID有误，请返回列表重试！');window.location.href='GameInfoMg.aspx'</script>");
                return;
            }
            GameInfo gameInfo = _gameInfoDataAccess.GetModel(gameIDint);
            if (gameInfo == null || gameInfo.ID <= 0)
            {
                dplServers.Items.Add(new ListItem { Value = "Wrong", Text = "读取数据出错！,请刷新页面重试" });
                return;
            }
            List<GameServer> serverList = _gameServerDataAccess.GetGameServerByGameIDandAreaId(gameIDint, areaIDint);
            dplServers.Items.Clear();
            foreach (var item in serverList)
            {
                var listItem = new ListItem { Text = item.ServerName, Value = Convert.ToString(item.ID) };
                dplServers.Items.Add(listItem);
            }
        }
        /// <summary>
        /// 删除区服
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelServer_Click(object sender, EventArgs e)
        {
            string serverId = dplServers.SelectedValue;
            int intServerId = Convert.ToInt32(serverId);
            bool res = _gameServerDataAccess.Delete(intServerId);
            if (res)
            {
                //删除成功，删除控件里的对应选项
                dplServers.Items.Remove(dplServers.Items.FindByValue(serverId));
            }
        }
    }
}
