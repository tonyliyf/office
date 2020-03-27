using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Logger;
using Quartz;

namespace MessageService
{
    public class SampleJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            LoggerFactory.Info("SampleJob running...eeeeee");
        }
    }
}
