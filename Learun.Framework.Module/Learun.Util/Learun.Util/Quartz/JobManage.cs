using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Learun.Util.Quartz
{
    public class JobManage
    {
        IScheduler schedudler;
        public JobManage()
        {
            schedudler = StdSchedulerFactory.GetDefaultScheduler();
            schedudler.Start();
        }

        public void AddJob<T>(string code, int Second) where T : JobBase
        {

            JobBase jbobj = Activator.CreateInstance<T>();
            jbobj.Code = code;
            IDictionary<string, object> jbData = new Dictionary<string, object>();
            jbData.Add(code, jbobj);

            IJobDetail job1 = JobBuilder.Create<JobInstance>()
                .SetJobData(new JobDataMap(jbData)).Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(Second)
                .RepeatForever()).Build();

            schedudler.ScheduleJob(job1, trigger1);

        }

        public void AddJob(string assmbley,string className,string code, int Second)
        {

            Assembly asm = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "/bin/" + assmbley);
            Type t = asm.GetType(className);

            JobBase jbobj = asm.CreateInstance(className) as JobBase;

            jbobj.Code = code;
            IDictionary<string, object> jbData = new Dictionary<string, object>();
            jbData.Add(code, jbobj);

            IJobDetail job1 = JobBuilder.Create<JobInstance>()
                .SetJobData(new JobDataMap(jbData)).Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(Second)
                .RepeatForever()).Build();

            schedudler.ScheduleJob(job1, trigger1);

        }

        public void AddJob<T>(string code, string rule) where T : JobBase
        {
            JobBase jbInstance = Activator.CreateInstance<T>();
            jbInstance.Code = code;
            IDictionary<string, object> jbData = new Dictionary<string, object>();
            jbData.Add("name", jbInstance);

            IJobDetail job1 = JobBuilder.Create<JobInstance>()
                .SetJobData(new JobDataMap(jbData)).Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .StartNow()
                .WithCronSchedule(rule).Build();

            schedudler.ScheduleJob(job1, trigger1);
        }

        public void AddJob(string assmbley, string className, string code, string rule)
        {

            Assembly asm = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "/bin/" + assmbley);
            Type t = asm.GetType(className);

            JobBase jbobj = asm.CreateInstance(className) as JobBase;

            jbobj.Code = code;
            IDictionary<string, object> jbData = new Dictionary<string, object>();
            jbData.Add("name", jbobj);

            IJobDetail job1 = JobBuilder.Create<JobInstance>()
                .SetJobData(new JobDataMap(jbData)).Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .StartNow()
                .WithCronSchedule(rule).Build();

            schedudler.ScheduleJob(job1, trigger1);

        }



        //JobManage job = new JobManage();
        //job.AddJob<Job1>("qq1",15);
        //    job.AddJob<Job2>("bbb",6);
        //    job.AddJob<Job3>("cccc", "5 * * * * ? ");
        //public class Job2 : JobBase
        //{
        //    public override void SendMessage()
        //    {

        //        Console.Write(DateTime.Now.ToString("yyyy_mm-dd") + "---eeeee---" + this.Code);
        //        Console.WriteLine("r/n");
        //    }
        //}
    }
}
