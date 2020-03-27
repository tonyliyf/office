using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.ProjectManager;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo.Portal
{
    public class PortalService : RepositoryFactory
    {
        private DC_OA_MeettingRelationIBLL relation = new DC_OA_MeettingRelationBLL();
        public int GetMeettingNoticeCount()
        {
            UserInfo user = LoginUserInfo.Get();
            string sql = "  select count(*) from dc_oa_meettingrelation where userid = '" + user.userId + "' and flag = 0";
            return Convert.ToInt32(this.BaseRepository().FindObject(sql));
        }
        public IEnumerable<MeettingViewResult> GetMeettingDetail()
        {
            UserInfo user = LoginUserInfo.Get();
            var table = this.BaseRepository().FindTable("  select * from dc_oa_meettingrelation where userid = '" + user.userId + "' and IsReadorReturn=0");
            List<MeettingViewResult> list = new List<MeettingViewResult>();
            foreach (DataRow row in table.Rows)
            {
                int type = row["MeettingType"].ToInt();
                string key = row["MeettingId"].ToString();
               string time = row["F_StartDate"].IsEmpty() ? null : row["F_StartDate"].ToString();
                string title = row["F_Title"].ToString();
                string address = row["F_Address"].ToString();
                //switch (type)
                //{
                //    case 0:
                //        var entity = this.BaseRepository().FindEntity<DeptNoticeEntity>(key);
                //        title = entity.F_Title;
                //        time = entity.F_StartDate;
                //        address = "";
                //        break;
                //    case 1:
                //        var entity1 = this.BaseRepository().FindEntity<DC_OA_MeetingEntity>(key);
                //        title = entity1.DC_OA_MeetingContent;
                //        time = entity1.DC_OA_StartTime;
                //        address = this.BaseRepository().FindEntity<DC_OA_MeetingRoomEntity>(entity1.DC_OA_MeetingRoomRefId).DC_OA_MeetingRoomName;
                //        break;
                //    case 2:
                //        var entity3 = this.BaseRepository().FindEntity<DC_EngineProject_MeetingRecordEntity>(key);
                //        title = entity3.F_MeetingContent;
                //        time = entity3.F_StartTime;
                //        address = "";
                //        break;
                //    default:
                //        break;
                //}
                list.Add(new MeettingViewResult() { id = key, name = title, time = time, address = address });
            }
            return list;
        }
        public void SignForMeetting(string id, string F_Reason)
        {
            relation.UpdateEntity(id, F_Reason);
            //string sql = string.Empty;
            //if(F_Reason.IsEmpty())
            //{
            //    sql = "  update dc_oa_meettingrelation set IsJoin =1,IsReadorReturn=1  where meettingid = @meettingid";
            //}
            //else
            //{
            //    sql = string.Format(" update dc_oa_meettingrelation IsJoin =0,IsReadorReturn=1,F_Reason='{0}' where  meettingid = @meettingid", F_Reason);
            //}
     
            //this.BaseRepository().ExecuteBySql(sql, new { userid = LoginUserInfo.Get().userId, meettingid = id });
        }
        public int GetMaintainRecordCount()
        {
            return Convert.ToInt32(
                this.BaseRepository().FindObject("  select count(*) from dc_oa_vehiclerepairrecord where is_agree = 2 and f_createuserid = @userid",
                new { userid = LoginUserInfo.Get().userId })
                );
        }
        public DataTable GetOverSeeList(string type)
        {
            UserInfo user = LoginUserInfo.Get();
            switch (type)
            {
                case "1"://进行中
                    return this.BaseRepository().FindTable(@"
                          select top 5 f_taskname as [name],f_oswid as [id],f_tasknodedate as [date] from dc_oa_overseeworktasksplit  
                          where f_oneuserid = @userid and f_state = 0 and (f_tasknodedate is null  or f_tasknodedate > getdate()) order by f_tasknodedatefirst desc
                        ", new { userid = user.userId });
                case "2"://已逾期
                    return this.BaseRepository().FindTable(@"
                          select top 5 f_taskname as [name],f_oswid as [id],f_tasknodedate as [date] from dc_oa_overseeworktasksplit  
                          where f_oneuserid = @userid and f_state = 0 and (f_tasknodedate is not null  and f_tasknodedate < getdate()) order by f_tasknodedatefirst desc
                        ", new { userid = user.userId });
                case "3"://已结束
                    return this.BaseRepository().FindTable(@"
                          select top 5 f_taskname as [name],f_oswid as [id],f_tasknodedate as [date] from dc_oa_overseeworktasksplit  
                          where f_oneuserid = @userid and (f_state = 2 or f_state = 3) order by f_tasknodedatefirst desc 
                        ", new { userid = user.userId });
                default:
                    return null;
            }
        }


        public DataTable GetOverSeeListCount()
        {
            UserInfo user = LoginUserInfo.Get();
             DataTable dt1 = this.BaseRepository().FindTable(@"
                          select count(*) from dc_oa_overseeworktasksplit  
                          where f_oneuserid = @userid and f_state = 0 and (f_tasknodedate is null  or f_tasknodedate > getdate()) 
                        ", new { userid = user.userId });
               
               DataTable dt2 = this.BaseRepository().FindTable(@"
                          select  count(*) from dc_oa_overseeworktasksplit  
                          where f_oneuserid = @userid and f_state = 0 and (f_tasknodedate is not null  and f_tasknodedate < getdate()) 
                        ", new { userid = user.userId });
               DataTable dt3 = this.BaseRepository().FindTable(@"
                          select  count(*) from dc_oa_overseeworktasksplit  
                          where f_oneuserid = @userid and (f_state = 2 or f_state = 3) 
                        ", new { userid = user.userId });

            DataTable dtData = new DataTable();
            dtData.Columns.Add("a1");
            dtData.Columns.Add("b1");
            dtData.Columns.Add("c1");
         
            DataRow dr = dtData.NewRow();
            dr["a1"] = dt1.Rows[0][0].ToString();
            dr["b1"] = dt2.Rows[0][0].ToString();
            dr["c1"] = dt3.Rows[0][0].ToString();
            dtData.Rows.Add(dr);
            dtData.AcceptChanges();
            return dtData;
        }
        public DataTable GetMyDocumentList()
        {
            UserInfo user = LoginUserInfo.Get();
            string sql = "  select top  5  f_fileid as id ,f_filename as [name],f_createdate as [date] from  lr_oa_fileinfo where f_createuserid = @userid  order by f_createdate desc";
            return this.BaseRepository().FindTable(sql, new { userid = user.userId });
        }

        /// <summary>
        /// 获得采购
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public DataTable GetPurchase()
        {
            UserInfo users = LoginUserInfo.Get();
            string sql = "select count(*) from  DC_OA_PurchaseReply t where is_agree =2";
            string sql1 = "select count(*) from DC_OA_PurchaseAudit t where is_agree =2";
            string sql2 = "select count(*) from DC_OA_PurchaseAuditResult t where is_agree =2";
            string sql3 = "select count(*) from  DC_OA_PurchaseDeposit t where is_agree =2";
            if (users.F_Level == 1)
            {

                sql += string.Format(" and  t.F_CreateUserId = '{0}'", users.userId);
                sql1 += string.Format(" and  t.F_CreateUserId = '{0}'", users.userId);
                sql2 += string.Format(" and  t.F_CreateUserId = '{0}'", users.userId);
                sql3 += string.Format(" and  t.F_CreateUserId = '{0}'", users.userId);
            }
            else if (users.F_Level == 2)
            {
                sql += string.Format(" and  t.F_CurrentDeptId = '{0}'", users.departmentId);
                sql1 += string.Format(" and  t.F_CurrentDeptId = '{0}'", users.departmentId);
                sql2 += string.Format(" and  t.F_CurrentDeptId = '{0}'", users.departmentId);
                sql3 += string.Format(" and  t.F_CurrentDeptId = '{0}'", users.departmentId);

            }
            else if (users.F_Level == 3)
            {
                sql += string.Format(" and  t.F_CurrentCompanyId = '{0}'", users.companyId);
                sql1 += string.Format(" and  t.F_CurrentCompanyId = '{0}'", users.companyId);
                sql2 += string.Format(" and  t.F_CurrentCompanyId = '{0}'", users.companyId);
                sql3 += string.Format(" and  t.F_CurrentCompanyId = '{0}'", users.companyId);

            }
            DataTable dt = this.BaseRepository().FindTable(sql);
            DataTable dt1 = this.BaseRepository().FindTable(sql1);
            DataTable dt2 = this.BaseRepository().FindTable(sql2);
            DataTable dt3 = this.BaseRepository().FindTable(sql3);
            DataTable dtData = new DataTable();
            dtData.Columns.Add("a1");
            dtData.Columns.Add("b1");
            dtData.Columns.Add("c1");
            dtData.Columns.Add("d1");
            DataRow dr = dtData.NewRow();
            dr["a1"] = dt.Rows[0][0].ToString();
            dr["b1"] = dt1.Rows[0][0].ToString();
            dr["c1"] = dt2.Rows[0][0].ToString();
            dr["d1"] = dt3.Rows[0][0].ToString();
            dtData.Rows.Add(dr);
            dtData.AcceptChanges();
            return dtData;

        }

        /// <summary>
        /// 获得维修
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public DataTable GetMaintain()
        {
            UserInfo users = LoginUserInfo.Get();
            string sql = "select count(*) from  DC_ASSETS_BusStopBillboardsMaintenanceRecords t where is_agree =2";
            string sql1 = "select count(*) from DC_ASSETS_EquipmentMaintenanceRecords t where is_agree =2";
            string sql2 = "select count(*) from DC_OA_VehicleRepairRecord t where is_agree =2";
            if (users.F_Level == 1)
            {

                sql += string.Format(" and  t.F_CreateUserId = '{0}'", users.userId);
                sql1 += string.Format(" and  t.F_CreateUserid = '{0}'", users.userId);
                sql2 += string.Format(" and  t.F_CreateUserId = '{0}'", users.userId);
            }
            else if (users.F_Level == 2)
            {
                sql += string.Format(" and  ( select top 1 F_DepartmentId  from lr_base_user where F_UserId=t.F_CreateUserid) = '{0}'", users.departmentId);
                sql1 += string.Format(" and ( select top 1 F_DepartmentId  from lr_base_user where F_UserId=t.F_CreateUserid) = '{0}'", users.departmentId);
                sql2 += string.Format(" and  ( select top 1 F_DeptId  from lr_base_user where F_UserId=t.F_CreateUserId) = '{0}'", users.departmentId);

            }
            else if (users.F_Level == 3)
            {
                sql += string.Format(" and  (select top 1 F_CompanyId  from lr_base_user where F_UserId=t.F_CreateUserid) = '{0}'", users.companyId);
                sql1 += string.Format(" and  (select top 1 F_CompanyId  from lr_base_user where F_UserId=t.F_CreateUserid) = '{0}'", users.companyId);
                sql2 += string.Format(" and  (select top 1 F_CompanyId  from lr_base_user where F_UserId=t.F_CreateUserId) = '{0}'", users.companyId);
            }
            else if (users.F_Level == 4)
            {
                sql += string.Format(@" and  (select top 1 F_CompanyId  from lr_base_user where F_UserId=t.F_CreateUserid) in ({0}) or 
                        select top 1 F_DepartmentId  from lr_base_user where F_UserId=t.F_CreateUserid) in ({1})", users.ManageCompanyIds,users.ManageDeptIds);
                sql1 += string.Format(@" and  (select top 1 F_CompanyId  from lr_base_user where F_UserId=t.F_CreateUserid) in ({0}) or 
                        select top 1 F_DepartmentId  from lr_base_user where F_UserId=t.F_CreateUserid) in ({1})", users.ManageCompanyIds, users.ManageDeptIds);
                sql2 += string.Format(@" and  (select top 1 F_CompanyId  from lr_base_user where F_UserId=t.F_CreateUserId) in ({0}) or 
                        select top 1 F_DeptId  from lr_base_user where F_UserId=t.F_CreateUserId) in ({1})", users.ManageCompanyIds, users.ManageDeptIds);
            }
            DataTable dt = this.BaseRepository().FindTable(sql);
            DataTable dt1 = this.BaseRepository().FindTable(sql1);
            DataTable dt2 = this.BaseRepository().FindTable(sql2);
            DataTable dtData = new DataTable();
            dtData.Columns.Add("a1");
            dtData.Columns.Add("b1");
            dtData.Columns.Add("c1");
            dtData.Columns.Add("d1");
            DataRow dr = dtData.NewRow();
            dr["a1"] = "0";
            dr["b1"] = dt.Rows[0][0].ToString();
            dr["c1"] = dt1.Rows[0][0].ToString();
            dr["d1"] = dt2.Rows[0][0].ToString();
            dtData.Rows.Add(dr);
            dtData.AcceptChanges();
            return dtData;

        }

        public DataTable GetMessage()
        {
            UserInfo users = LoginUserInfo.Get();
            string sql = string.Format("select F_MessageId,FromUserName,F_CreateDate,SendContent from DC_OA_Message where IsReadorReturn =0  and  ToUserIds  like '%{0}%' ", users.userId);
            return this.BaseRepository().FindTable(sql);

        }

        public  bool EnterMessage(string Messageid)
        {
            string sql = string.Format("Update  DC_OA_Message  set IsReadorReturn =1 where F_MessageId ='{0}'", Messageid);
            return this.BaseRepository().ExecuteBySql(sql) > 0;

        }
        public class MeettingViewResult
        {
            public string id { get; set; }
            public string name { get; set; }
            public string time { get; set; }
            public string address { get; set; }
        }
    }
}
