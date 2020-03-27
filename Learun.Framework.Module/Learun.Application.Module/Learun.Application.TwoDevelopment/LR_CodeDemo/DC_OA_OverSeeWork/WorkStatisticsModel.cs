using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class WorkStatisticsModel
    {
        public string id { get; set; }
        public string orderBy { get; set; }
        public DateTime? createDate { get; set; }
        public string workTitle { get; set; }
        public string workType { get; set; }
        public string workContent { get; set; }
        public string executeState { get; set; }
        public string executeContent { get; set; }
        public DateTime? endTime { get; set; }
        public string dutyDepartment { get; set; }
        public string dutyLeader { get; set; }
        public string mainDepartment { get; set; }
        public string mainDepartmentDutyOwner { get; set; }
        public string mainDepartmentLeader { get; set; }   
        public string dutyOwner { get; set; }
        public string helpDepartment { get; set; }
        public string helpDutyOwner { get; set; }
        public string workSplit1 { get; set; }
        public string workSplit2 { get; set; }
        public double score { get; set; }
    }
}
