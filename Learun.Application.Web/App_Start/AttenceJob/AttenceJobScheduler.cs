using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace Learun.Application.Web.App_Start.AttenceJob
{
    public class AttenceJobScheduler
    {

        public static void Start()
        {

            
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<AttenceJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
              //每隔一个月执行一次，月头执行
              .WithIdentity("AttenceJob", "groupName")
              .WithCronSchedule("0 0/1 * * * ?  ")
              .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}