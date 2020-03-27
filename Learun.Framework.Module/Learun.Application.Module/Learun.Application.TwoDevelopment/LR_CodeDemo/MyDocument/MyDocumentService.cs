using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class MyDocumentService : RepositoryFactory
    {
        private List<TableDetail> tableList = new List<TableDetail>()
        {
            new TableDetail(2,"DeptNotice","F_Id","F_File","F_StartDate","F_Applicant","F_Title"),
            new TableDetail(3,"DC_OA_Meeting","DC_OA_MeetingId","F_Files","F_CreateDate","DC_OA_MeetingManageId","DC_OA_MeetingTitle"),
            new TableDetail(4,"DC_OA_PartyBranchMeeting","F_PartyBranchMeetingGUID","F_Attachments","F_CreateDate","F_CreateUserId","F_MeetingSummary"),
            new TableDetail(5,"DC_EngineProject_MeetingRecord","F_MRId","F_Attachments","F_CreateDatetime","F_CreateUserid","F_MeetingTheme"),
            new TableDetail(7,"DC_OA_ReceiveOfficialDoc","F_RODId","F_Attachments","F_CreateDate","F_CreateUserid","F_Title"),
            new TableDetail(8,"DC_OA_DispatchOfficialDoc","F_DODId","F_FileContent_ENew","F_CreateDate","F_CreateUserid","F_Title"),
            new TableDetail(10,"DC_OA_OverSeeWorkHandover","F_DOHId","F_Attachments","F_CreateDate","F_CreateUserid","F_Title"),
            new TableDetail(11,"DC_OA_OverSeeWorkBulletin","F_DOBId","F_Attachments","F_CreateDate","F_CreateUserid","F_Title"),
            new TableDetail(12,"DC_OA_OverSeeWorkDelay","F_OSWDId","F_Attachments","F_EndDelayDate","F_HighLeaderId","F_OSWContent"),
            new TableDetail(13,"DC_OA_OverSeeWorkClosing","F_OSWCId","F_Attachments","F_EndCloseDate","F_LeaderUserId","F_OSWContent"),
            new TableDetail(15,"DC_OA_CostReimbursementGather","F_CRGId","F_Attachments","F_CreateDate","F_CreateUserid","F_CostTypeId"),
            new TableDetail(16,"DC_OA_AppropriationApprove","F_AAId","F_Attachments","F_CreateDate","F_CreateUserid","F_AAName"),
            new TableDetail(17,"DC_OA_LargeCostPay","F_LCPId","F_Attachments","F_CreateDate","F_CreateUserid","F_CostTypeId + '大额支出'")
        };
        public List<TreeModel> GetTree()
        {
            string sql = @"
            select 1 as id ,0 as pid ,'会议管理' as [text]  union
            select 2 as id ,1 as pid ,'日常会议' as [text]  union
            select 3 as id ,1 as pid ,'专题会议' as [text]  union
            select 4 as id ,1 as pid ,'党组织会议' as [text]  union
            select 5 as id ,1 as pid ,'工程项目会议' as [text]  union
            select 6 as id ,0 as pid ,'公文管理' as [text]  union
            select 7 as id ,6 as pid ,'收文文档' as [text]  union
            select 8 as id ,6 as pid ,'发文文档' as [text]  union
            select 9 as id ,0 as pid ,'任务管理' as [text]  union
            select 10 as id ,9 as pid ,'督办任务交办' as [text]  union
            select 11 as id ,9 as pid ,'督办工作通报' as [text]  union
            select 12 as id ,9 as pid ,'督办工作延期' as [text]  union
            select 13 as id ,9 as pid ,'督办工作办结' as [text]  union
            select 14 as id ,0 as pid ,'费用报销' as [text]  union
            select 15 as id ,14 as pid ,'管理费用' as [text]  union
            select 16 as id ,14 as pid ,'资金拨付' as [text]  union
            select 17 as id ,14 as pid ,'大额支出' as [text]  union
            select 18 as id ,0 as pid ,'工作考核' as [text]  union
            select 19 as id ,18 as pid ,'考核记录' as [text]  union
            select 20 as id ,18 as pid ,'考核申诉' as [text]  union
            select 21 as id ,18 as pid ,'考核面谈记录' as [text]
            ";
            DataTable list = this.BaseRepository().FindTable(sql);
            List<TreeModel> treeList = new List<TreeModel>();
            foreach (DataRow item in list.Rows)
            {
                TreeModel node = new TreeModel
                {
                    id = item["id"].ToString(),
                    text = item["text"].ToString(),
                    value = item["id"].ToString(),
                    showcheck = false,
                    checkstate = 0,
                    isexpand = true,
                    parentId = item["pid"].ToString()
                };
                treeList.Add(node);
            }
            return treeList.ToTree();
        }
        public IEnumerable<MyDocumentViewResult> GetPageList(Pagination pagination, string queryJson)
        {
            UserInfo user = LoginUserInfo.Get();
            var queryParam = queryJson.ToJObject();
            StringBuilder sqlSb = new StringBuilder();
            if (queryParam["id"].IsEmpty())
            {
                foreach (var table in tableList)
                {
                    string temp = "t" + tableList.IndexOf(table);
                    sqlSb.Append(string.Format(@" select {0} as [key], {1} as [name],{2} as [file],{3} as [time],
                    case {8}
                    when 1 then '会议管理' 
                    when 2 then '日常会议' 
                    when 3 then '专题会议' 
                    when 4 then '党组织会议' 
                    when 5 then '工程项目会议' 
                    when 6 then '公文管理' 
                    when 7 then '收文文档'
                    when 8 then '发文文档'
                    when 9 then '任务管理'
                    when 10 then '督办任务交办'
                    when 11 then '督办工作通报' 
                    when 12 then '督办工作延期' 
                    when 13 then '督办工作办结' 
                    when 14 then '费用报销' 
                    when 15 then '管理费用' 
                    when 16 then '资金拨付' 
                    when 17 then '大额支出' 
                    when 18 then '工作考核'
                    when 19 then '考核记录' 
                    when 20 then '考核申诉'
                    when 21 then '考核面谈记录' 
			        else '' end as [type]
                    from {4} as {5}
                    where (select count(*) from lr_nwf_process where f_id={5}.{0})>0 and {6}='{7}' union all",
                             table.primaryKeyFieldName, table.formNameFieldName, table.fileFieldName, table.timeFieldName,
                             table.tableName, temp, table.userIdFieldName, user.userId, table.id));
                }
                string sql = sqlSb.ToString();
                sql = sql.Substring(0, sql.Length - "union all".Length);
                return this.BaseRepository().FindList<MyDocumentViewResult>(sql, new { }, pagination);
            }
            else
            {
                int id = queryParam["id"].ToInt();
                var table = tableList.FirstOrDefault(c => c.id == id);
                if (table == null)
                {
                    return null;
                }
                else
                {
                    sqlSb.Append(string.Format(@" select {0} as [key], {1} as [name],{2} as [file],{3} as [time],
                    case {7}
                    when 1 then '会议管理' 
                    when 2 then '日常会议' 
                    when 3 then '专题会议' 
                    when 4 then '党组织会议' 
                    when 5 then '工程项目会议' 
                    when 6 then '公文管理' 
                    when 7 then '收文文档'
                    when 8 then '发文文档'
                    when 9 then '任务管理'
                    when 10 then'督办任务交办'
                    when 11 then'督办工作通报' 
                    when 12 then'督办工作延期' 
                    when 13 then'督办工作办结' 
                    when 14 then'费用报销' 
                    when 15 then '管理费用' 
                    when 16 then '资金拨付' 
                    when 17 then '大额支出' 
                    when 18 then '工作考核'
                    when 19 then '考核记录' 
                    when 20 then'考核申诉'
                    when 21 then'考核面谈记录' 
			        else '' end as [type]
                    from {4} as t
                    where (select count(*) from lr_nwf_process where f_id=t.{0})>0 and {5}='{6}'",
                        table.primaryKeyFieldName, table.formNameFieldName, table.fileFieldName, table.timeFieldName,
                        table.tableName, table.userIdFieldName, user.userId, id));
                    return this.BaseRepository().FindList<MyDocumentViewResult>(sqlSb.ToString(), new { }, pagination);
                }
            }
        }

        public IEnumerable<MyDocumentViewResult> GetPageList1(Pagination pagination, string queryJson)
        {
            UserInfo user = LoginUserInfo.Get();
            var queryParam = queryJson.ToJObject();
            StringBuilder sqlSb = new StringBuilder();
            string where = string.Empty;
            switch (user.F_Level)
            {
                case 1:
                    where = " and {0}.{1} = '" + user.userId + "'";
                    break;
                case 2:
                    where = " and  ( select top 1 F_DepartmentId  from lr_base_user where F_UserId={0}.{1}) = '" + user.departmentId + "'";
                    break;
                case 3:
                    where = "  and  (select top 1 F_CompanyId  from lr_base_user where F_UserId={0}.{1}) = '" + user.companyId + "'";
                    break;
                case 4:
                    where = "and  (select top 1 F_CompanyId  from lr_base_user where F_UserId={0}.{1}) in (" + user.ManageCompanyIds + @") or 
                        select top 1 F_DepartmentId  from lr_base_user where F_UserId={0}.{1}) in (" + user.ManageDeptIds + ")";
                    break;
                default:
                    break;
            }
            if (queryParam["id"].IsEmpty())
            {
                foreach (var table in tableList)
                {
                    string temp = "t" + tableList.IndexOf(table);
                    string where1 = string.Format(where, temp, table.userIdFieldName);
                    sqlSb.Append(string.Format(@" select {0} as [key], {1} as [name],{2} as [file],{3} as [time],
                    case {6}
                    when 1 then '会议管理' 
                    when 2 then '日常会议' 
                    when 3 then '专题会议' 
                    when 4 then '党组织会议' 
                    when 5 then '工程项目会议' 
                    when 6 then '公文管理' 
                    when 7 then '收文文档'
                    when 8 then '发文文档'
                    when 9 then '任务管理'
                    when 10 then '督办任务交办'
                    when 11 then '督办工作通报' 
                    when 12 then '督办工作延期' 
                    when 13 then '督办工作办结' 
                    when 14 then '费用报销' 
                    when 15 then '管理费用' 
                    when 16 then '资金拨付' 
                    when 17 then '大额支出' 
                    when 18 then '工作考核'
                    when 19 then '考核记录' 
                    when 20 then '考核申诉'
                    when 21 then '考核面谈记录' 
			        else '' end as [type]
                    from {4} as {5}
                    where (select count(*) from lr_nwf_process where f_id={5}.{0})>0 {7} union all",
                             table.primaryKeyFieldName, table.formNameFieldName, table.fileFieldName, table.timeFieldName,
                             table.tableName, temp, table.id, where1));
                }
                string sql = sqlSb.ToString();
                sql = sql.Substring(0, sql.Length - "union all".Length);
                return this.BaseRepository().FindList<MyDocumentViewResult>(sql, new { }, pagination);
            }
            else
            {
                int id = queryParam["id"].ToInt();
                var table = tableList.FirstOrDefault(c => c.id == id);
                if (table == null)
                {
                    return null;
                }
                else
                {
                    where = string.Format(where, "t", table.userIdFieldName);
                    sqlSb.Append(string.Format(@" select {0} as [key], {1} as [name],{2} as [file],{3} as [time],
                    case {5}
                    when 1 then '会议管理' 
                    when 2 then '日常会议' 
                    when 3 then '专题会议' 
                    when 4 then '党组织会议' 
                    when 5 then '工程项目会议' 
                    when 6 then '公文管理' 
                    when 7 then '收文文档'
                    when 8 then '发文文档'
                    when 9 then '任务管理'
                    when 10 then'督办任务交办'
                    when 11 then'督办工作通报' 
                    when 12 then'督办工作延期' 
                    when 13 then'督办工作办结' 
                    when 14 then'费用报销' 
                    when 15 then '管理费用' 
                    when 16 then '资金拨付' 
                    when 17 then '大额支出' 
                    when 18 then '工作考核'
                    when 19 then '考核记录' 
                    when 20 then'考核申诉'
                    when 21 then'考核面谈记录' 
			        else '' end as [type]
                    from {4} as t
                    where (select count(*) from lr_nwf_process where f_id=t.{0})>0 {6}",
                        table.primaryKeyFieldName, table.formNameFieldName, table.fileFieldName, table.timeFieldName,
                        table.tableName,id,where));
                    return this.BaseRepository().FindList<MyDocumentViewResult>(sqlSb.ToString(), new { }, pagination);
                }
            }
        }

        public class TableDetail
        {
            public int id { get; set; }
            public string tableName { get; set; }
            public string fileFieldName { get; set; }
            public string timeFieldName { get; set; }
            public string userIdFieldName { get; set; }
            public string formNameFieldName { get; set; }
            public string primaryKeyFieldName { get; set; }
            public TableDetail(int id, string tableName, string primaryKeyFieldName, string fileFieldName,
                string timeFieldName, string userIdFieldName, string formNameFieldName)
            {
                this.id = id;
                this.tableName = tableName;
                this.fileFieldName = fileFieldName;
                this.timeFieldName = timeFieldName;
                this.userIdFieldName = userIdFieldName;
                this.formNameFieldName = formNameFieldName;
                this.primaryKeyFieldName = primaryKeyFieldName;
            }
        }

        public class MyDocumentViewResult
        {
            public DateTime time { get; set; }
            public string name { get; set; }
            public string file { get; set; }
            public string key { get; set; }
            public string type { get; set; }
        }
    }
}
