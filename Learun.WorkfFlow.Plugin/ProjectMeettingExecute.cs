using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Application.WorkFlow;
using Learun.DataBase.Repository;
using Learun.Application.TwoDevelopment;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.Organization;
using Learun.Util;
using Learun.Application.TwoDevelopment.ProjectManager;
using Learun.Application.Message;

namespace Learun.WorkFlow.Plugin
{
    public class ProjectMeettingExecute : RepositoryFactory, IWorkFlowMethod
    {
        private LR_StrategyInfoIBLL bll = new LR_StrategyInfoBLL();
        public void Execute(WfMethodParameter parameter)
        {
            var data = this.BaseRepository().FindEntity<DC_EngineProject_MeetingRecordEntity>(parameter.processId);
            if (data != null)
            {
                string userids = data.F_MeetingUnits;
                if (!string.IsNullOrWhiteSpace(userids))
                {
                    var arr = userids.Split(',');
                    if (arr.Length > 0)
                    {
                        StringBuilder sql;
                        foreach (var str in arr)
                        {
                            sql = new StringBuilder();
                            // sql.Append(string.Format("  insert into dc_oa_meettingrelation values('{0}','{1}',0,2) ", data.F_MeetingUnits, str));

                            sql.Append(string.Format(@"  insert into dc_oa_meettingrelation(MeettingId,Userid,Flag,MeettingType,IsJoin,IsReadorReturn,F_StartDate,F_Title,F_Address,F_Workflowid)
                          values('{0}','{1}',1,2,0,0,'{2}','{3}','{4}','{5}') ", Guid.NewGuid().ToString(), str, data.F_StartTime, data.F_MeetingContent,data.F_MeetingAddress, parameter.processId));
                            this.BaseRepository().ExecuteBySql(sql.ToString());

                            string content = string.Format("{0}{1}请您参加{2}会议", data.F_StartTime, data.F_MeetingAddress, data.F_MeetingContent);
                            bll.SendMessageByUserIds("MeetingNotice", content, userids);
                        }
                      
                    }
                }
            }
        }
    }
}
