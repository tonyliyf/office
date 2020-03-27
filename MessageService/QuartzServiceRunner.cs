using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Topshelf;

namespace MessageService
{
    public class QuartzServiceRunner
    {
        private readonly IScheduler scheduler;
      
        public QuartzServiceRunner()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        public void Start()
        {
            // //从配置文件中读取任务启动时间
            //// string cronExpr = ConfigurationManager.AppSettings["cronExpr"];
            //// IJobDetail job = JobBuilder.Create<DeleteDomainJob>().WithIdentity("job1", "group1").Build();
            // //创建任务运行的触发器
            //// ITrigger trigger = TriggerBuilder.Create()
            //     .WithIdentity("triggger1", "group1")
            //     .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(cronExpr)))
            //     .Build();
            // //启动任务
           

            IJobDetail job = JobBuilder.Create<BillboardsRentIncomeJob>().WithIdentity("BillboardsRentIncomeJob", "group1").Build();

            //ITrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
            //        .WithIdentity("trigger5", "group1")
            //         .StartAt(DateBuilder.FutureDate(1, IntervalUnit.Minute)).Build();// use DateBuilder to create a date in the future
    

            ITrigger trigger = new BillboardsRentIncomeJob("Advance").GetTrigger();
             scheduler.ScheduleJob(job, trigger);

          IJobDetail job1 = JobBuilder.Create<HouseRentIncomeJob>().WithIdentity("HouseRentIncomeJob", "group1").Build();
           //trigger = (ISimpleTrigger)TriggerBuilder.Create()
           //        .WithIdentity("trigger5", "group1")
           //         .StartAt(DateBuilder.FutureDate(5, IntervalUnit.Minute)).Build();

          ITrigger trigger1 = new HouseRentIncomeJob("HouseIncome").GetTrigger();
           scheduler.ScheduleJob(job1, trigger1);


            IJobDetail job2 = JobBuilder.Create<OverWorkJob>().WithIdentity("OverWorkJob", "group1").Build();
           // trigger = (ISimpleTrigger)TriggerBuilder.Create()
           //        .WithIdentity("trigger5", "group1")
           //         .StartAt(DateBuilder.FutureDate(10, IntervalUnit.Minute)).Build();
          ITrigger trigger2 = new OverWorkJob("OSNotice").GetTrigger();
           scheduler.ScheduleJob(job2, trigger2);
            scheduler.Start();

        }

        public void Stop()
        {
            scheduler.Clear();
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            return true;
        }
    }
}
