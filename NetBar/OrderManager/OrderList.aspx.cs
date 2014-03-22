using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace NetBar.OrderManager
{
    public partial class OrderList : PageBase
    {
        readonly AccountInfoDataAccess _access = new AccountInfoDataAccess();
        private List<AccountInfoModel> _accountList;
        protected void Page_Load(object sender, EventArgs e)
        {
            //:todo 事件混乱会读取两次
            if (!IsPostBack)
            {
                int recordCount, pageCount;
                _accountList = _access.GetPagedAccountInfoModelsByProc(AspNetPager1.CurrentPageIndex, 10, "", out recordCount, out pageCount);
                AspNetPager1.RecordCount = recordCount;
            }
        }
        public List<AccountInfoModel> AccountList
        {
            get { return _accountList ?? _access.GetPagedAccountInfoModelsByProc(1, 10, ""); }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            int recordCount, pageCount;
            _accountList = _access.GetPagedAccountInfoModelsByProc(AspNetPager1.CurrentPageIndex, 10, "", out recordCount, out pageCount);
        }
    }
}