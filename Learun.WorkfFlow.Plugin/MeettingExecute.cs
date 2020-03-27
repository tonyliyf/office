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
using Learun.Application.Message;

namespace Learun.WorkFlow.Plugin
{
    public class MeettingExecute : RepositoryFactory, IWorkFlowMethod
    {
        private LR_StrategyInfoIBLL bll = new LR_StrategyInfoBLL();
        public void Execute(WfMethodParameter parameter)
        {
            var data = this.BaseRepository().FindEntity<DC_OA_MeetingEntity>(parameter.processId);
            if (data != null)
            {
                string userids = data.DC_OA_MeetingIds;
                if (!string.IsNullOrWhiteSpace(userids))
                {
                    var arr = userids.Split(',');
                    if (arr.Length > 0)
                    {
                        StringBuilder sql;
                        foreach (var str in arr)
                        {
                            sql = new StringBuilder();
                            string address = this.BaseRepository().FindEntity<DC_OA_MeetingRoomEntity>(data.DC_OA_MeetingRoomRefId).DC_OA_MeetingRoomName;
                            //  sql.Append(string.Format("  insert into dc_oa_meettingrelation values('{0}','{1}',0,1) ", data.DC_OA_MeetingIds, str));

                            sql.Append(string.Format(@"  insert into dc_oa_meettingrelation(MeettingId,Userid,Flag,MeettingType,IsJoin,IsReadorReturn,F_StartDate,F_Title,F_Address,F_Workflowid)
                          values('{0}','{1}',1,1,0,0,'{2}','{3}','{4}','{5}') ", Guid.NewGuid().ToString(), str, data.DC_OA_StartTime, data.DC_OA_MeetingContent, address, parameter.processId));
                            this.BaseRepository().ExecuteBySql(sql.ToString());

                            string content = string.Format("{0}{1}请您参加{2}会议", data.DC_OA_StartTime, address, data.DC_OA_MeetingContent);
                            bll.SendMessageByUserIds("MeetingNotice", content, userids);
                        }
                        
                    }
                }
            }
        }
    }
}
