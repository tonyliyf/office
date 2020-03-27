using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class FullcalendarResult
    {
        public FullcalendarResult(DateTime? _start, DateTime? _end, string _title)
        {
            this.start = _start.HasValue ? _start.Value.ToString("yyyy-MM-ddThh:mm:ss") : "";
            this.end = _start.HasValue ? _end.Value.ToString("yyyy-MM-ddThh:mm:ss") : "";
            this.title = _title;
        }
        public string start { get; set; }
        public string end { get; set; }
        public string title { get; set; }
    }
}
