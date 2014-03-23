using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DataLogic;
using DataAccess.Model;
using Wuqi.Webdiyer;

namespace _77Trade
{
    public partial class AccountSaleList : UserPageBase
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
                    string timeSpanWhere = GetTimeSpanStr(hiddenTimeSpan.Value);
                    //订单状态 默认为审核期 值为3
                    hiddenOrderStatus.Value = "3";
                    WhereStr = "where UserID = "+CurrentUser.ID+" and OrderStatus = 3";
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
                string timeSpanStr = GetTimeSpanStr(hiddenTimeSpan.Value);
                labelTimeSpan.Text = hiddenTimeSpan.Value;
                StringBuilder stringBuilder = new StringBuilder();
                //总有时间这个条件
                stringBuilder.Append("where SubmitTime "+timeSpanStr);
                if (!string.IsNullOrEmpty(hiddenOrderStatus.Value))
                {
                    stringBuilder.Append(" and OrderStatus = " + hiddenOrderStatus.Value.Trim()+" and UserID = "+CurrentUser.ID);
                }
                //在这里填充数据，是因为，用户选择服务器，时间等条件时是客户端触发的表单提交     想其它办法
                //WhereStr = "where GameArea ='" + hiddenAreaName.Value.Trim() + "' and ServerName = '" + hiddenServerName.Value.Trim() + "' and SubmitTime "+timeSpanStr;
                int currentPageNo;
                if (!int.TryParse(Request.QueryString.Get("page"),out currentPageNo))
                {
                    currentPageNo = 1;
                }
                WhereStr = stringBuilder.ToString();
                AspNetPager1.GoToPage(currentPageNo);
            }
            #endregion
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            int rowCount, pageCount;
            _accountDescriptionsModels =
            _accountDescriptionDataAccess.GetPagedAccountDescriptionsModelsByProc(AspNetPager1.CurrentPageIndex, 10, WhereStr,hiddenOrderBy.Value.Trim(), out rowCount, out pageCount);
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
                        1, 10,WhereStr);
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
            stringBuilder.Append("/");
            stringBuilder.Append(description.ServerName.Trim());
            return stringBuilder.ToString();
        }
    }
}