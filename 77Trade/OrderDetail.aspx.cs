using System;
using System.Configuration;
using System.Text;
using DataAccess.DataLogic;
using DataAccess.Model;
using log4net;
using Quartz;
using Quartz.Impl;
using _77Trade.Logic;
using _77Trade.QuartzManager;

namespace _77Trade
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        private readonly ILog _log = LogManager.GetLogger("FrontLoger");
        private readonly AccountDescriptionDataAccess _accountDescriptionDataAccess = new AccountDescriptionDataAccess();
        private readonly UserDataAccess _userDataAccess = new UserDataAccess();
        private readonly UserOrderLogic _userOrderLogic = new UserOrderLogic();
        private readonly UserBuyOrderDataAccess _userBuyOrderDataAccess = new UserBuyOrderDataAccess();
        private readonly AccountInfoDataAccess _accountInfoDataAccess = new AccountInfoDataAccess();
        public AccountDescription CurrentAccountDescription { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //todo:判断页面第一次加载减少数据读取次数
            //根据页面传过来的订单信息(AccountDescription)ID，查到订单详细信息
            string descriptionId = Request.QueryString.Get("acDes");
            int accountDescriptionId;
            if (!int.TryParse(descriptionId, out accountDescriptionId))
            {
                CurrentAccountDescription = new AccountDescription();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                    "<script>alert('订单ID有误，请反回重试！');window.location.href='/BillList.aspx';</script>");
            }
            else
            {
                CurrentAccountDescription = _accountDescriptionDataAccess.GetModel(accountDescriptionId);
                descriptionID.Value = Convert.ToString(accountDescriptionId);
            }

        }

        protected void buyProduct_Click(object sender, EventArgs e)
        {
            //判断用户是否登陆   判断帐号状态是否可购买
            if (Session["UserName"] == null)
            {
                Response.Redirect("/User/Login.aspx?returnUrl=/OrderDetail.aspx?acDes="+descriptionID.Value.Trim());
                return;
            }
            FrontUser user = _userDataAccess.GetFrontUserByUserName(Session["UserName"].ToString());
            if (user == null || user.ID <= 0)
            {
                 ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                        "<script>alert('读取用户信息出错，请刷新页面重试！')</script>");
                    return;
            }

            //todo:检察用户订单表中是否已有未付款订单，如果有提示用户是否删除订单
            bool existOrder = _userBuyOrderDataAccess.ExistsByUserId(user.ID);
            if (existOrder)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                       "<script>alert('当前存在未处理订单！');window.location.href='/User/MyBuyOrder.aspx';</script>");
                return;
            }

            //检察订单是否处于出售状态
            //检察订单是否过了公示期,如果过了公示期直接可购买
            //可购买的话就锁定订单 直接跳转到付款页面
            //添加订单15分钟还原任务
            //付款成功修改订单状态


            //如果订单状态为公示，则检察是否已经过了公示期
            if (CurrentAccountDescription.OrderStatus == OrderStatus.GongShi)
            {
                if (CurrentAccountDescription.EditDate.AddDays(3) > DateTime.Now)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert",
                        "<script>alert('订单处于公示期，暂不可购买，请耐心等待！')</script>");
                    return;
                }
                //订单已过公示期可购买,修改订单状态为出售中
                _log.Info("订单：" + CurrentAccountDescription.OrderNo + "已过公示时间，状态可购买。公示开始时间：" +
          CurrentAccountDescription.EditDate);
                var result = _userOrderLogic.ChangeAccountStatus(CurrentAccountDescription.AccountInfoID,CurrentAccountDescription.ID, OrderStatus.GongShi, OrderStatus.ChuShou);
                if (!result)
                {
                    _log.Error("订单：" + CurrentAccountDescription.OrderNo + "已过公示时间，状态可购买。公示开始时间：" +
CurrentAccountDescription.EditDate + "    修改订单状态失败");
                    ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('更新订单状态失败，请重试！')</script>");
                    return;
                }
                
            }
            //订单本身处于出售期
            if (CurrentAccountDescription.OrderStatus == OrderStatus.ChuShou)
            {
                int res = _userOrderLogic.GeneralUserOrder(CurrentAccountDescription.OrderNo, user.ID,CurrentAccountDescription.AccountInfoID);
                if (res > 0)
                {
                    //添加订时事件，15分钟后还原订单状态为出售
                    AddOrderReNewTask(CurrentAccountDescription.OrderNo);
                    var reqUrl = Request.Url;
                    //ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('购买成功，请在15分钟内付款！')</script>");
                    Response.Redirect("/User/MyBuyOrder.aspx?returnUrl="+reqUrl.AbsolutePath+reqUrl.Query);
                    return;
                }
            }
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('生成订单失败，请重试！')</script>");
        }

        #region Tool
        /// <summary>
        /// 添加订单还原任务
        /// </summary>
        /// <param name="orderNo"></param>
        public void AddOrderReNewTask(string orderNo)
        {
            try
            {
                string orderReNewTime = ConfigurationManager.AppSettings.Get("orderReNewTime");
                int reNewTime;
                if (!int.TryParse(orderReNewTime, out reNewTime))
                {
                    reNewTime = 15;
                }
                ISchedulerFactory sf = new StdSchedulerFactory();
                var scheduler = sf.GetScheduler();
                //检察任务是否已存在
                bool jobExist =
                    scheduler.CheckExists(new JobKey("reNewOrderStatus:" + CurrentAccountDescription.OrderNo,
                        "reNewOrder"));
                if (jobExist)
                {
                    _log.Warn("任务已存在：reNewOrderStatus:" + CurrentAccountDescription.OrderNo);
                }
                else
                {

                    IJobDetail job = JobBuilder.Create<ReNewOrderStatus>()
                        .WithIdentity("reNewOrderStatus:" + CurrentAccountDescription.OrderNo, "reNewOrder")
                        .Build();
                    DateTimeOffset startTime = DateBuilder.NextGivenMinuteDate(null,reNewTime);
                    ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                        .WithIdentity("trigger1", "group1")
                        .StartAt(startTime)
                        .Build();
                    //把订单号，InfoID号写入DataMap 执行任务时修改订单状态
                    job.JobDataMap.Add("AccountInfoID", CurrentAccountDescription.AccountInfoID);
                    job.JobDataMap.Put("OrderNo", CurrentAccountDescription.OrderNo);
                    _log.Warn("添加订单还原任务：reNewOrderStatus:" + CurrentAccountDescription.OrderNo);
                    scheduler.ScheduleJob(job, trigger);
                    // scheduler.Start();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public string GetAccountPropertyByAccountModel(AccountDescription description)
        {
            var stringBuilder = new StringBuilder();
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
                    }
                case OrderStatus.ShenHe:
                    {
                        return "审核中";
                    }
                case OrderStatus.GongShi:
                    {
                        return "公示期";
                    }
                case OrderStatus.NotComplete:
                    {
                        return "订单未完成";
                    }
                default:
                    {
                        return "未知状态";
                    }
            }
        }
        #endregion

    }
}