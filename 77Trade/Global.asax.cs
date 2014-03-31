using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;

namespace _77Trade
{
    public class Global : System.Web.HttpApplication
    {
        readonly ISchedulerFactory sf = new StdSchedulerFactory();
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            var scheduler = sf.GetScheduler();
            scheduler.Start();
        }

        protected void Application_end(object sender, EventArgs e)
        {
            var scheduler = sf.GetScheduler();
            scheduler.Shutdown(true);
        }
    }
}