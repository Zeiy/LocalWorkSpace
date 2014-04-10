using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;
using Quartz;
using Quartz.Impl;
using _77Trade.QuartzManager;

namespace _77Trade
{
    public class Global : System.Web.HttpApplication
    {
        readonly ISchedulerFactory sf = new StdSchedulerFactory();
        private ILog _log = log4net.LogManager.GetLogger("FrontLoger");
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            var scheduler = sf.GetScheduler();
            //订单还原任务是写在内存里的，如果服务器重新启动则未完成的任务会丢失，所以在服务器重新启动时，
            //设立订时任务，每两小时执行订单扫描任务，查究是否有超时未还原订单
            bool jobExist =
                   scheduler.CheckExists(new JobKey("CheckOrderStatus", "CheckOrder"));
            if (jobExist)
            {
                _log.Warn("订单检察任务已存在！");
            }
            else
            {
                string checkOrderInterval = ConfigurationManager.AppSettings.Get("checkOrderInterval");
                int checkOrderIntervalInt;
                if (!int.TryParse(checkOrderInterval, out checkOrderIntervalInt))
                {
                    checkOrderIntervalInt = 120;
                }
                IJobDetail job = JobBuilder.Create<CheckOrderJob>()
                    .WithIdentity("CheckOrderStatus", "CheckOrder")
                    .Build();
                ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                    .WithIdentity("CheckOrderTrigger", "OrderTrigger")
                    .StartNow().WithSimpleSchedule(x => x.WithIntervalInMinutes(checkOrderIntervalInt).RepeatForever())
                    .Build();
                _log.Warn("添加订单还原任务,每" + checkOrderIntervalInt + "分钟执行一次！");
                scheduler.ScheduleJob(job, trigger);
                // scheduler.Start();
            }
            scheduler.Start();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            var scheduler = sf.GetScheduler();
            scheduler.Shutdown(true);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //添加页面随机值阻止 CSRF 
            string guidStr = Guid.NewGuid().ToString();
            Session["RandomCode"] = guidStr;
        }
    }
}