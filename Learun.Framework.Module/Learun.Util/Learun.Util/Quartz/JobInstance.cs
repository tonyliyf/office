using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Learun.Util.Quartz
{
    public class JobInstance : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            IDictionary<string, object> jobs = context.JobDetail.JobDataMap;

            if (jobs != null)
            {
                foreach (var item in jobs.Values)
                {
                    JobBase jobObj = item as JobBase;
                    jobObj.Run();
                }

            }

        }
    }
}
