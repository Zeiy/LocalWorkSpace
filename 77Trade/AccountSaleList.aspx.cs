using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;
using Wuqi.Webdiyer;

namespace _77Trade
{
    public partial class AccountSaleList : System.Web.UI.Page
    {
        private readonly AccountInfoDataAccess _accountInfoDataAccess = new AccountInfoDataAccess();
        private readonly AccountDescriptionDataAccess _accountDescriptionDataAccess = new AccountDescriptionDataAccess();
        private readonly GameServerDataAccess _gameServerDataAccess = new GameServerDataAccess();
        private readonly GameAreaDataAccess _gameAreaDataAccess = new GameAreaDataAccess();
        private List<AccountDescription> _accountDescriptionsModels;
        public string WhereStr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 1.如果页面带有参数则根据参数来做筛选条件
             * 2.页面没有参数，则是无筛选条件渲染页面
             * 
             */
            #region 页面初次加载
            if (!IsPostBack)
            {
                int serverId;
                string serverIdStr = Request.QueryString.Get("serverID");
                //根据游戏服务器ID拿到所属区服渲染区服信息
                if (!int.TryParse(serverIdStr, out serverId))
                {
                    labelGameArea.Text = "选择区服";
                    lableGameServer.Text = "选择服务器";
                    WhereStr = string.Empty;
                    CurrentServers = new List<GameServer>();
                }
                else
                {
                    GameServer gameServer = _gameServerDataAccess.GetModel(serverId);
                    //根据服务器ID拿到AreaID
                    GameArea gamesArea = _gameAreaDataAccess.GetModel(gameServer.AreaID);
                    //把游戏名写入hiddenfield 用于区服查询
                    hiddenGameName.Value = gameServer.GameName;
                    hiddenAreaName.Value = gamesArea.AreaName;
                    hiddenServerName.Value = gameServer.ServerName;
                    //根据AreaID拿到Area里的所有服务器名，渲染页面
                    CurrentServers = _gameServerDataAccess.GetGameServerByGameIDandAreaId(gameServer.GameID, gameServer.AreaID);
                    labelGameArea.Text = gamesArea.AreaName;
                    lableGameServer.Text = gameServer.ServerName;
                    //第一次进入页面区服信息为空，则不做筛选
                    //:todo 区服，时间显示
                    //处理时间信息
                    string timeSpanWhere = GetTimeSpanStr(hiddenTimeSpan.Value);

                    WhereStr = "where GameArea ='" + gamesArea.AreaName + "' and ServerName = '" +
                               gameServer.ServerName.Trim() + "'";
                }
                //给时间添加一个默认值
                hiddenTimeSpan.Value = "2012-11-06至2016-11-13";
                int rowCount = 0, outPageCount = 0;
                _accountDescriptionsModels = _accountDescriptionDataAccess.GetPagedAccountDescriptionsModelsByProc(1, 10, WhereStr,"",
                    out rowCount, out outPageCount);
                AspNetPager1.RecordCount = rowCount;
                AspNetPager1.PageSize = 10;
            }
            #endregion

            #region 普通页面请求
            else
            {
                labelGameArea.Text = string.IsNullOrEmpty(hiddenAreaName.Value) ? "选择区服" : hiddenAreaName.Value.Trim();
                lableGameServer.Text = string.IsNullOrEmpty(hiddenServerName.Value) ? "选择服务器" : hiddenServerName.Value.Trim();
                CurrentServers = _gameServerDataAccess.GetGameServerByGameNameandAreaName(string.IsNullOrEmpty(hiddenGameName.Value.Trim())?"征途":hiddenGameName.Value.Trim(), hiddenAreaName.Value.Trim());
                string timeSpanStr = GetTimeSpanStr(hiddenTimeSpan.Value);
                labelTimeSpan.Text = hiddenTimeSpan.Value;
                StringBuilder stringBuilder = new StringBuilder();
                //总有时间这个条件
                stringBuilder.Append("where SubmitTime "+timeSpanStr);
                if (!string.IsNullOrEmpty(hiddenAreaName.Value))
                {
                   stringBuilder.Append(" and GameArea = '"+hiddenAreaName.Value.Trim()+"'");
                }
                if (!string.IsNullOrEmpty(hiddenServerName.Value))
                {
                    stringBuilder.Append(" and ServerName = '"+hiddenServerName.Value.Trim()+"'");
                }
                //WhereStr = "where GameArea ='" + hiddenAreaName.Value.Trim() + "' and ServerName = '" + hiddenServerName.Value.Trim() + "' and SubmitTime "+timeSpanStr;
                WhereStr = stringBuilder.ToString();
                int rowCount, pageCount;
                _accountDescriptionsModels =
                _accountDescriptionDataAccess.GetPagedAccountDescriptionsModelsByProc(1, 10, WhereStr,null, out rowCount, out pageCount);
                AspNetPager1.RecordCount = rowCount;
            }
            #endregion
        }
        /// <summary>
        /// 用于页面服务器筛选列表
        /// </summary>
        public List<GameServer> CurrentServers { get; set; }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            int rowCount, pageCount;
            _accountDescriptionsModels =
            _accountDescriptionDataAccess.GetPagedAccountDescriptionsModelsByProc(AspNetPager1.CurrentPageIndex, 10, WhereStr,null, out rowCount, out pageCount);
            AspNetPager1.RecordCount = rowCount;
        }

        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {

        }
        public List<AccountDescription> CurrentPageInfoModels
        {
            get
            {
                if (_accountDescriptionsModels == null)
                {
                    _accountDescriptionsModels = _accountDescriptionDataAccess.GetPagedAccountDescriptionsModelsByProc(
                        1, 10, "");
                    return _accountDescriptionsModels;
                }
                return _accountDescriptionsModels;

            }
        }
        /// <summary>
        /// 处理页面提交的时间，转换成可以SQL查询的 where 语句 如果转换不成功则返回最大时间范围
        /// </summary>
        /// <param name="timeSpan">开始结束时间字符串，例如： 2013-11-06至2014-11-13</param>
        /// <returns>如果成功返回相应的可用Where查询字符串，否则返回最大时间范围</returns>
        public string GetTimeSpanStr(string timeSpan)
        {
            if (string.IsNullOrEmpty(timeSpan))
            {
                timeSpan = "2012-11-06至2016-11-13";
            }
            string beginTimeStr, endTimeStr;
            DateTime beginTime, endTime;
            string[] timePoint = timeSpan.Split('至');
            if (!DateTime.TryParse(timePoint[0].Trim(), out beginTime))
            {
                beginTimeStr = DateTime.MinValue.ToString();
            }
            else
            {
                beginTimeStr = beginTime.ToString();
            }
            if (!DateTime.TryParse(timePoint[1].Trim(), out endTime))
            {
                endTimeStr = DateTime.MaxValue.ToString();
            }
            else
            {
                endTimeStr = endTime.ToString();
            }
            return "between '"+beginTimeStr+"' and '"+endTimeStr+"'";
        }

        public string GetAccountPropertyByAccountModel(AccountDescription description)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(description.GameName.Trim());
            stringBuilder.Append("/");
            stringBuilder.Append(description.GameArea.Trim());
            stringBuilder.Append(description.ServerName.Trim());
            stringBuilder.Append("/");
            return stringBuilder.ToString();
        }
    }
}