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


namespace Learun.WorkFlow.Plugin
{
    public class OverSeeWorkHandoverExecute : RepositoryFactory, IWorkFlowMethod
    {
        public void Execute(WfMethodParameter parameter)
        {
            Func<string, string> GetUserName = userid =>
            {
                var user = this.BaseRepository().FindEntity<UserEntity>(userid);
                return user == null ? "" : user.F_RealName;
            };
            Func<string, string> GetDepartmentName = departmentid =>
            {
                var department = this.BaseRepository().FindEntity<DepartmentEntity>(departmentid);
                return department == null ? "" : department.F_FullName;
            };
            Func<string, string> GetCompanyName = companyid =>
            {
                var company = this.BaseRepository().FindEntity<CompanyEntity>(companyid);
                return company == null ? "" : company.F_FullName;
            };

            Func<string, string> Func1 = userid =>
            {
                var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == userid);
                return user == null ? "" : user.F_RealName;
            };
            Func<string, string> Func3 = userids =>
            {
                if (string.IsNullOrWhiteSpace(userids))
                {
                    return string.Empty;
                }
                var userIdArr = userids.Split(',');
                List<string> userNameList = new List<string>();
                foreach (var userid in userIdArr)
                {
                    userNameList.Add(Func1(userid));
                }
                string userNames = string.Empty;
                userNameList.ForEach(c => userNames += c + ",");
                if (userNames.Length >= 0)
                {
                    userNames.Substring(0, userNames.Length - 1);
                }
                return userNames;
            };
            var srcList = this.BaseRepository().FindList<DC_OA_OverSeeWorkHandoverDetailEntity>(c => c.F_DOHId == parameter.processId);
            var OsApplyEntity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkHandoverEntity>(c => c.F_DOHId == parameter.processId);
            int i = 1;
            foreach (var item in srcList)
            {
                DC_OA_OverSeeWorkEntity entity = new DC_OA_OverSeeWorkEntity()
                {
                    F_Attachments = item.F_Attachments,
                    F_BeginDate = item.F_BeginDate,
                    F_DepartmentId = item.F_DepartmentId,
                    F_Department = GetDepartmentName(item.F_DepartmentId),
                    F_EndDate = item.F_EndDate,
                    F_LeaderUserId = item.F_LeaderUserId,
                    F_LeaderUser = Func3(item.F_LeaderUserId),
                    F_Marks = item.F_Marks,
                    F_OSWCode = item.F_OSWCode,
                    F_OSWContent = item.F_OSWContent,
                    F_OverSeeUserId = item.F_OverSeeUserId,
                    F_OverSeeUser = GetUserName(item.F_OverSeeUserId),
                    F_State = "执行中",
                    F_OSWId = Guid.NewGuid().ToString(),
                    F_DOHId = item.F_DOHId,
                    F_HighLeaderId = item.F_HighLeaderId,
                    F_HighLeader = GetUserName(item.F_HighLeaderId),
                    F_OSWType = item.F_OSWType,
                    F_OSCaptain = OsApplyEntity.F_Title,
                    F_CreateDate = DateTime.Now,
                    F_Draft = 0                   
                };
                DC_OA_OverSeeWorkTaskSplitEntity entity1 = new DC_OA_OverSeeWorkTaskSplitEntity()
                {
                    F_code = i++,
                    F_OneDepartment = entity.F_Department,
                    F_OneDepartmentId = entity.F_DepartmentId,
                    F_OneLeader = entity.F_HighLeader,
                    F_OneLeaderId = entity.F_HighLeaderId,
                    F_OneUser = entity.F_LeaderUser,
                    F_OneUserId = entity.F_LeaderUserId,
                    F_OSWId = entity.F_OSWId,
                    F_ParentId = "",
                    F_SecondId = Guid.NewGuid().ToString(),
                    F_State = 0,
                    F_TaskContent = entity.F_Marks,
                    F_TaskName = entity.F_OSWContent,
                    F_TwoUser = "",
                    F_TwoUserId = "",
                    F_TwoDepartment = "",
                    F_TwoDepartmentId = "",
                    F_TaskNode = (entity.F_EndDate.HasValue ? entity.F_EndDate.Value.ToString("yyyy年MM月dd日") : ""),
                    F_TaskNodeDate = entity.F_EndDate,
                    F_TaskNodeDateFirst = entity.F_BeginDate
                };
                this.BaseRepository().Insert(entity);
                this.BaseRepository().Insert(entity1);
            }
        }
    }
}
