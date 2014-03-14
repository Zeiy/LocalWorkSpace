using DataAccess.DataLogic;
using DataAccess.Model;
using System;

namespace NetBar
{
    public partial class AccountDetail : PageBase
    {
        readonly AccountInfoDataAccess _accountInfoDataAccess = new AccountInfoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            //通用页面传过来的ID值查到订单信息展示订单，
            //默认所有的字段只读，当用户点编辑时，所有字段可编辑，并显示保存按钮，
            //当用户点击保存时更新字段
            
            string orderId = Request.QueryString.Get("InfoID");
            int intOrderId;
            //读取订单ID，如果ID错误则跳回列表页
            if (!int.TryParse(orderId, out intOrderId)) {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单ID有误，返回列表页面！');window.location.href='/Index.aspx'</script>");
                return;
            }
            //读取订单信息
            if (!IsPostBack)
            {
                AccountInfoModel infoModel = _accountInfoDataAccess.GetModel(intOrderId);
                if (infoModel == null || infoModel.ID <= 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单数据有误，请返回列表页面重试！');window.location.href='/Index.aspx'</script>");
                    return;
                }
                gameName.Text = infoModel.GameName;
                gameName.ReadOnly = true;
                gameArea.Text = infoModel.GameArea;
                gameArea.ReadOnly = true;
                gameAccount.Text = infoModel.GameAccount;
                gameAccount.ReadOnly = true;
                gamePwd.Text = infoModel.GamePassword;
                gamePwd.ReadOnly = true;
                QQMobile.Text = infoModel.QQMobile;
                QQMobile.ReadOnly = true;
                email.Text = infoModel.Email;
                email.ReadOnly = true;
                shenfenZheng.Text = infoModel.IdCardNo;
                shenfenZheng.ReadOnly = true;
                secretCard.Text = infoModel.SecretCardNo;
                secretCard.ReadOnly = true;
                //订单状态
                OrderStatus.SelectedItem.Text = infoModel.OrderStatus.ToString();
                OrderStatus.Enabled = false;
            }
        }
    }
}