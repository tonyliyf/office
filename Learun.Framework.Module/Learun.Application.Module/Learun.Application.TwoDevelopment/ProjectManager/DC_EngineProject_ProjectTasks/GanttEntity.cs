using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    public class GanttEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public List<GanttValue> values { get; set; }
    }

    public class GanttValue
    {
        public string to { get; set; }
        public string from { get; set; }
        public string desc { get; set; }
        public string label { get; set; }
        public string customClass { get; set; }
        public GanttDataObj dataObj { get; set; }
    }
    public class GanttDataObj
    {
        public GanttDataObj(string _id)
        {
            this.id = _id;
        }
        public string id { get; set; }
    }
}
