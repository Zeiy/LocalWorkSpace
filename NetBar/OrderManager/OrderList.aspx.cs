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
        public List<AccountInfoModel> _accountList;
        protected void Page_Load(object sender, EventArgs e)
        {
            AspNetPager1.RecordCount = 1000;
            if (!IsPostBack)
            {
                _accountList = _access.GetAllData();
            }
        }
        public List<AccountInfoModel> AccountList
        {
            get { return _accountList; }
            set
            {
                _accountList = _access.GetAllData();
            }
        }
    }
}