using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace Learun.Application.Web.App_Start.LogJob
{
    public class LogJobScheduler
    {        
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<LogJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                //每月最后一天，23点55分触发
              .WithIdentity("LogJob", "groupName2")
              .WithCronSchedule("0 */5 * * * ? ")
              .Build();
           scheduler.ScheduleJob(job, trigger);
        }
    }
}