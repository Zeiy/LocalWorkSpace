using DataAccess.Model;
using System;
using System.Collections.Generic;
using DataAccess.DataLogic;

namespace NetBar
{
    public partial class Index : PageBase
    {
        readonly AccountInfoDataAccess _access = new AccountInfoDataAccess();
        public List<AccountInfoModel> _accountList;
        protected  void Page_Load(object sender, EventArgs e)
        {
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