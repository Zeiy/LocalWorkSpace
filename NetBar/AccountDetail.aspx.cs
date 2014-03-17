using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.DataLogic;
using DataAccess.Model;
using System;

namespace NetBar
{
    public partial class AccountDetail : PageBase
    {
        readonly AccountInfoDataAccess _accountInfoDataAccess = new AccountInfoDataAccess();
        private readonly AccountDescriptionDataAccess _accountDescriptionDataAccess = new AccountDescriptionDataAccess();
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
                if (infoModel.SecretCardBind)
                {
                    imgSecret.ImageUrl = infoModel.SecretCardImgUrl;
                }
                DplOrderStatus.SelectedItem.Text = infoModel.OrderStatus.ToString();
                DplOrderStatus.Enabled = false;
                hiddenAccountInfoID.Value = orderId;
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string[] statusName = Enum.GetNames(typeof (OrderStatus));
            for (int i = 0; i < statusName.Count(); i++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = statusName[i];
                listItem.Value = Convert.ToString(i);
                //listItem.Value = statusInt[i].ToString();
                DplOrderStatus.Items.Add(listItem);
            }
            DplOrderStatus.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string infoID = hiddenAccountInfoID.Value;
            //检察ID是否存在    检察Description 是否存在，是否判断前置状态
            int infoIDInt;
            if (!int.TryParse(infoID, out infoIDInt))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单ID读取有误，修改订单失败！')</script>");
                return;
            }
            AccountInfoModel accountInfoModel = _accountInfoDataAccess.GetModel(infoIDInt);
            //如果订单不存在
            if (accountInfoModel==null||accountInfoModel.ID<=0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单不存在，修改订单失败！')</script>");
                return;
            }
            //检察订单明细表是否存在
            List<AccountDescription> dsecriptionList =
                _accountDescriptionDataAccess.GetModelList("AccountInfoID = " + infoID);
            if (dsecriptionList.Count > 1 || dsecriptionList.Count==0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单状态有误，修改订单失败！')</script>");
                return;
            }
            AccountDescription description = _accountDescriptionDataAccess.GetModelByAccountInfoId(accountInfoModel.ID);
            //更改订单状态
            string newStatus = DplOrderStatus.SelectedValue;
            OrderStatus newOrderStatus;
            if (!Enum.TryParse(newStatus, out newOrderStatus))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单状态有误，修改订单失败！')</script>");
                return;
            }
            List<string> sqList = new List<string>();
            sqList.Add("update AccountDescription set OrderStatus = "+newStatus+" where ID="+description.ID);
            sqList.Add("update AccountInfo set OrderStatus = " + newStatus + " where ID=" + accountInfoModel.ID);
            int res =  DbHelperSQL.ExecuteSqlTran(sqList);
            if (res == 2)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('修改订单成功！')</script>");
                DplOrderStatus.Enabled = false;
            }

        }
    }
}