using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.Quartz
{
    public abstract class JobBase
    {
        public string Code { get; set; }

        public abstract void Run();
    }
}
