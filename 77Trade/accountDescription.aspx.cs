using System.Web;
using DataAccess.DataLogic;
using DataAccess.Model;
using System;

namespace _77Trade
{
    public partial class accountDescription : UserPageBase
    {
        readonly AccountDescriptionDataAccess _accountDescriptionDataAccess = new AccountDescriptionDataAccess();
        private readonly AccountInfoDataAccess _accountInfoDataAccess = new AccountInfoDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //拿到订单ID后校验当前用户，订单状态是否为未完成状态。如果前置订单符合要求则把值写入hiddenField
                string infoId = Request.QueryString.Get("infoId");
                int accountInfoId = 0;
                if (!int.TryParse(infoId, out accountInfoId))
                {
                    //用户前置订单不存在，跳回订单生成第一步
                    Response.Redirect("/accountInfo.aspx");
                }
                //取到用户前置订单
                AccountInfoModel infoModel = _accountInfoDataAccess.GetModel(accountInfoId);
                //如果此订单不是未完成订单
                if (infoModel==null||infoModel.OrderStatus != OrderStatus.NotComplete)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('用户前置订单有误，请反回重试！');window.location.href='/accountInfo.aspx';</script>");
                    return;
                }
                //把前置订单号写入隐藏域
                accountInfoID.Value = infoId;   
            }
        }
        /// <summary>
        /// 点击生成订单后处理用户上传的订单描述信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //商品属性
            string productPropertyStr = productProperty.Text;
            //标题
            string productTitleStr = productTitle.Text;
            //价格
            string productPriceStr = productPrice.Text;
            //产品描述
            string pdDescriptionStr =HttpUtility.HtmlEncode(pdDescription.Text);
            //四人图片地址
            decimal decPrice;
            #region 数据校验
            if (!decimal.TryParse(productPriceStr, out decPrice))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('价格输入有误，请重新输入！')</script>");
                return;
            }
            #endregion
            AccountDescription description = new AccountDescription();
            //用户前置订单ID
            string accountInfoIdStr = accountInfoID.Value;
            int accountInfoIdStrInt;
            if (!int.TryParse(accountInfoIdStr, out accountInfoIdStrInt))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('用户前置订单ID有误，请反回重试！');window.location.href='/accountInfo.aspx';</script>");
                return;
            }
            description.AccountInfoID = accountInfoIdStrInt;
            description.ProductDescription = pdDescriptionStr;
            description.ProductTitle = productTitleStr;
            description.ProductProperty = productPropertyStr;
            description.Price = decPrice;
            //拿到用户订单Info,添加订单冗余字段值
            AccountInfoModel accountinfoModel = _accountInfoDataAccess.GetModel(accountInfoIdStrInt);
            if (accountinfoModel == null || accountinfoModel.ID <= 0||accountinfoModel.OrderStatus!=OrderStatus.NotComplete)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('用户前置订单信息有误，请反回重试！');window.location.href='/accountInfo.aspx';</script>");
                return;
            }
            //给冗余字段赋值，方便做列表筛选
            description.GameArea = accountinfoModel.GameArea;
            description.GameName = accountinfoModel.GameName;
            description.ServerName = accountinfoModel.ServerName;
            if(!string.IsNullOrEmpty(hiddenimggameImgA.Value.Trim()))
            {
                description.ProductImgAUrl = hiddenimggameImgA.Value.Trim();
            }
            if (!string.IsNullOrEmpty(hiddenimggameImgB.Value.Trim()))
            {
                description.ProductImgBUrl = hiddenimggameImgB.Value.Trim();
            }
            if (!string.IsNullOrEmpty(hiddenimggameImgC.Value.Trim()))
            {
                description.ProductImgCUrl = hiddenimggameImgC.Value.Trim();
            }
            if (!string.IsNullOrEmpty(hiddenimggameImgD.Value.Trim()))
            {
                description.ProductImgDUrl = hiddenimggameImgD.Value.Trim();
            }
        
           
            //生成订单号  写入订单状态
            //检察订单号是否已存在
            string orderNoStr = GeneralOrderNo();
            description.OrderNo = orderNoStr;
            description.OrderStatus = OrderStatus.ShenHe;
            description.UserID = CurrentUser.ID;
            description.EditDate = DateTime.Now;
            int res = _accountDescriptionDataAccess.Add(description);
            if (res > 0)
            { 
                //订单创建成功,更改前置订单状态
                accountinfoModel.OrderStatus = OrderStatus.ShenHe;
                bool resUpdate = _accountInfoDataAccess.Update(accountinfoModel);
                if (resUpdate)
                {
                    //跳转到订单列表页
                    Response.Redirect("AccountSaleList.aspx");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert","<script>alert('订单提交成功，进入审核状态！')</script>");
                }
            }
        }
        /// <summary>
        /// 生成一个不存在的订单号，已检察过是否存在
        /// </summary>
        /// <returns></returns>
        public string GeneralOrderNo()
        {
            for (int i = 0; i < 5; i++)
            {
                string timeNow = DateTime.Now.ToString("yyyyMMddhhmmssff");
                //zhang hao
                string orderNoStr = "ZH" + timeNow;
                bool isExist = _accountDescriptionDataAccess.Exists(orderNoStr);
                if (!isExist)
                {
                    return orderNoStr;
                }
                
            }
            return string.Empty;
        }
    }
}