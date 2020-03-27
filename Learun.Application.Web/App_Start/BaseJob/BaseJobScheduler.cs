using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace Learun.Application.Web.App_Start.BaseJob
{
    public class BaseJobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<BaseJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
              //每月最后一天，23点55分触发
              .WithIdentity("LogJob", "groupName15")
               .WithCronSchedule("0 */2 * * * ? ")
              //.WithCronSchedule("30 * * * * ?")
              .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}