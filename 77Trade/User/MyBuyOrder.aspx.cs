using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace _77Trade.User
{
    public partial class MyBuyOrder : UserPageBase
    {
        private readonly UserBuyOrderDataAccess _userBuyOrderDataAccess = new UserBuyOrderDataAccess();
        private List<UserBuyOrderPageModel> _userBuyOrderPageModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _userBuyOrderPageModel = _userBuyOrderDataAccess.GetBuyOrderPageModel(CurrentUser.ID,null);
            }
        }

        public List<UserBuyOrderPageModel> UserBuyOrderPageModel
        {
            get
            {
                if (_userBuyOrderPageModel != null) return _userBuyOrderPageModel;
                return _userBuyOrderPageModel = _userBuyOrderDataAccess.GetBuyOrderPageModel(CurrentUser.ID,null);
            }
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            var res = _userBuyOrderDataAccess.Delete(CurrentUser.ID,OrderStatus.DaiFuKuan);
            string returnUrl = Request.QueryString.Get("returnUrl");
            if (res)
            {
                //todo:删除成功，如果有 返回地址 提示是否返回商品详情页
                if (!string.IsNullOrEmpty(returnUrl))
                {

                    ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                   "<script>if(confirm('订单处理完成，是否跳转到产品页?'){window.location.href='"+returnUrl+"'}</script>");
                    return;
                }
                ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                     "<script>alert('删除成功！');window.location.href='/User/MyBuyOrder.aspx';</script>");
                return;
            }
            //todo:订单状态还原任务删除 检察订单还原任务是否存在，如果存在则删除订单还原任务
        }
    }
}