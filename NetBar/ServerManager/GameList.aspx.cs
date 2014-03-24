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
    public partial class GameList : PageBase
    {
        readonly GameInfoDataAccess _gameinfoDa = new GameInfoDataAccess();
        private List<GameInfo> _ameInfoList;
        public List<GameInfo> GameInfoList
        {
            get { return _ameInfoList; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //列出游戏列表
            if (!IsPostBack)
            {
                _ameInfoList = _gameinfoDa.GameInfoList();
            }
        }
    }
}