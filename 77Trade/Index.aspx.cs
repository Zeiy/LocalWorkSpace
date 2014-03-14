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
    public partial class Index : System.Web.UI.Page
    {
        GameInfoDataAccess gameInfoDataAccess = new GameInfoDataAccess();
        private List<GameInfo> _gameInfoList;
        protected void Page_Load(object sender, EventArgs e)
        {
            //拿到游戏信息，渲染页面
            if (!IsPostBack) {
                _gameInfoList = gameInfoDataAccess.GameInfoList();
            }

        }
        /// <summary>
        /// 游戏列表
        /// </summary>
        public List<GameInfo> GameInfoList
        {
            get { return _gameInfoList; }
            set
            {
                _gameInfoList = gameInfoDataAccess.GameInfoList();
            }
        }
    }
}