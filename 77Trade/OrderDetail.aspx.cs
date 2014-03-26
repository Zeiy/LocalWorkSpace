using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.DataLogic;
using DataAccess.Model;

namespace _77Trade
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        private readonly AccountDescriptionDataAccess _accountDescriptionDataAccess = new AccountDescriptionDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            //根据页面传过来的订单信息(AccountDescription)ID，查到订单详细信息
            string descriptionId = Request.QueryString.Get("acDes");
            int accountDescriptionId;
            if (!int.TryParse(descriptionId, out accountDescriptionId))
            {
                CurrentAccountDescription = new AccountDescription();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单ID有误，请反回重试！');window.location.href='/BillList.aspx';</script>");
            }
            else
            {
                CurrentAccountDescription = _accountDescriptionDataAccess.GetModel(accountDescriptionId);
                descriptionID.Value = Convert.ToString(accountDescriptionId);
            }
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
        public string GetOrderStatusStr(OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.ChuShou:
                    {
                        return "出售中";
                        break;
                    }
                case OrderStatus.ShenHe:
                    {
                        return "审核中";
                        break;
                    }
                case OrderStatus.GongShi:
                    {
                        return "公示期";
                        break;
                    }
                case OrderStatus.NotComplete:
                    {
                        return "订单未完成";
                        break;
                    }
                default:
                    {
                        return "未知状态";
                        break;
                    }
            }
        }
        public AccountDescription CurrentAccountDescription { get; set; }

        protected void buyProduct_Click(object sender, EventArgs e)
        {
            //判断用户是否登陆   判断帐号状态是否可购买
            if (Session["UserName"] == null)
            {
                Response.Redirect("/User/Login.aspx?returnUrl=/OrderDetail.aspx?acDes="+descriptionID.Value.Trim());
                return;
            }
            //检察订单是否处于出售状态
            OrderStatus currentStatus = CurrentAccountDescription.OrderStatus;
            //生成订单
            Response.Redirect("/User/Login.aspx?returnUrl=/OrderDetail.aspx?acDes=" + descriptionID.Value.Trim());
        }
    }
}