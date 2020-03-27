using Dapper;
using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;
using Learun.Util.Operat;
using Learun.Cache.Base;
using Learun.Cache.Factory;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 16:49
    /// 描 述：DC_OA_Attence
    /// </summary>
    public class DC_OA_AttenceService : RepositoryFactory
    {

        private DC_OA_HolidaySettingIBLL dC_OA_HolidaySettingIBLL = new DC_OA_HolidaySettingBLL();//节假日操作
        private DC_OA_AttenceSettingIBLL dC_OA_AttenceSettingIBLL = new DC_OA_AttenceSettingBLL();//考勤设置
        private DC_OA_AttenceRecordIBLL dC_OA_AttenceRecordIBLL = new DC_OA_AttenceRecordBLL();//打卡记录
        private DC_OA_AttenceRepairRocordIBLL dc_OA_AttenceRepairdIBLL = new DC_OA_AttenceRepairRocordBLL();//  补卡记录
        private LeaveReqIBLL leaveReqIBLL = new LeaveReqBLL(); //leave请假
        private EvectionReqIBLL evectionReqIBLL = new EvectionReqBLL();//出差
        private ExtraWorkReqIBLL extraWorkIBLL = new ExtraWorkReqBLL();//加班
        private DC_OA_AttenceRecordIBLL DC_OA_AttenceRecordBLL = new DC_OA_AttenceRecordBLL();//考勤记录
        private UserIBLL userIBLL = new UserBLL();
        private CompanyIBLL companybll = new CompanyBLL();
        private DepartmentIBLL departbll = new DepartmentBLL();
        private DC_OA_PersonBackUpIBLL personBackBll = new DC_OA_PersonBackUpBLL();
        private PostIBLL postIBLL = new PostBLL();
        private DC_OA_AttenceSettingIBLL settingBLL = new DC_OA_AttenceSettingBLL();
        private ICache cache = CacheFactory.CaChe();
        #region 获取数据 


        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="queryJson">查询参数</param> 
        /// <returns></returns> 
        public IEnumerable<DC_OA_AttenceEntity> GetPageList(Pagination pagination, string queryJson,string isPower)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
                t.f_oa_attenceusername,
                t.f_deptname, 
                t.postname,
                t.dc_oa_attencemonth, 
                t.f_sumdays, 
                t.f_comondays, 
                t.f_leavedays, 
                t.f_outdays,    
                t.f_forgetnums, 
                t.f_repairnums, 
                t.f_laternums, 
                t.f_outforgetnums, 
                t.f_notworkdays, 
                t.f_thingdays, 
                t.f_xiujiadays, 
                t.f_personbackdays, 
                t.f_sickleavedays, 
                t.f_tiaodays, 
                t.f_workhours, 
                t.day1, 
                t.day2, 
                t.day3, 
                t.day4, 
                t.day5, 
                t.day6, 
                t.day7, 
                t.day8, 
                t.day9, 
                t.day10, 
                t.day11, 
                t.day12, 
                t.day13, 
                t.day14, 
                t.day15, 
                t.day16, 
                t.day17, 
                t.day18, 
                t.day19, 
                t.day20, 
                t.day21, 
                t.day22, 
                t.day23, 
                t.day24, 
                t.day25, 
                t.day26, 
                t.day27, 
                t.day28, 
                t.day29, 
                t.day30, 
                t.day31,
                t.dc_oa_attenceid, 
                t.f_enabledmark, 
                t.f_createuserid, 
                t.f_modifyusername, 
                t.f_modifyuserid, 
                t.f_deletemark, 
                t.f_modifydate, 
                t.f_createusername, 
                t.f_createdate, 
                t.f_description, 
                t.f_oa_attenceuserid, 
                t.f_oa_attencedeptid, 
                t.f_oa_attencecompanyid, 
                t.f_oa_attencetype, 
                t.f_companyname
                ");
                strSql.Append("  FROM DC_OA_Attence t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数 
                DateTime dtstart = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                UserInfo user = LoginUserInfo.Get();
                var dp = new DynamicParameters(new { });
                if (!queryParam["DC_OA_AttenceMonth"].IsEmpty())
                {
                    dp.Add("DC_OA_AttenceMonth", queryParam["DC_OA_AttenceMonth"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_AttenceMonth = @DC_OA_AttenceMonth ");
                }
                else
                {
                    dp.Add("DC_OA_AttenceMonth", dtstart.ToString("yyyyMM"), DbType.String);
                    strSql.Append(" AND t.DC_OA_AttenceMonth = @DC_OA_AttenceMonth ");

                }
                if(!string.IsNullOrEmpty(isPower))
                {
                    if (user.F_Level == 1)
                    {
                        strSql.Append(string.Format(" and  t.F_CreateUserId = '{0}'", user.userId));

                    }
                    else if (user.F_Level == 2)
                    {
                        strSql.Append(string.Format(" and  t.F_OA_AttenceDeptId = '{0}'", user.departmentId));
                    }
                    else if (user.F_Level == 3)
                    {
                        strSql.Append(string.Format(" and  t.F_OA_AttenceCompanyId = '{0}'", user.companyId));
                    }

                }
                if (!queryParam["F_OA_AttenceDeptId"].IsEmpty())
                {
                    dp.Add("F_OA_AttenceDeptId", queryParam["F_OA_AttenceDeptId"].ToString(), DbType.String);
                    strSql.Append(" AND (t.F_OA_AttenceCompanyId =@F_OA_AttenceDeptId or t.F_OA_AttenceDeptId = @F_OA_AttenceDeptId)");
                }
                // pagination.rows = 25;
                return this.BaseRepository().FindList<DC_OA_AttenceEntity>(strSql.ToString(), dp, pagination).OrderBy(i => i.F_OA_AttenceDeptId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        public DataTable GetDataSource(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
               
                t.DC_OA_AttenceId, 
                t.DC_OA_AttenceMonth, 
                t.F_OA_AttenceUserName,
                t.F_DeptName, 
                t.PostName,
                t.F_EnabledMark, 
                t.F_CreateUserId, 
                t.F_ModifyUserName, 
                t.F_ModifyUserId, 
                t.F_DeleteMark, 
                t.F_ModifyDate, 
                t.F_CreateUserName, 
                t.F_CreateDate, 
                t.F_Description, 
                t.F_OA_AttenceUserId, 
                t.F_OA_AttenceDeptId, 
                t.F_OA_AttenceCompanyId, 
                t.F_OA_AttenceType, 
                t.F_CompanyName, 
               
                t.F_SumDays, 
                t.F_ComonDays, 
                t.F_LeaveDays, 
                t.F_ForgetNums, 
                t.F_RepairNums, 
                t.F_OutDays, 
                t.F_laterNums, 
                t.F_OutForgetNums, 
                t.F_NotWorkDays, 
                t.F_thingDays, 
                t.F_xiujiaDays, 
                t.F_PersonBackDays, 
                t.F_SickLeaveDays, 
                t.F_TiaoDays, 
                t.F_WorkHours, 
                t.day1, 
                t.day2, 
                t.day3, 
                t.day4, 
                t.day5, 
                t.day6, 
                t.day7, 
                t.day8, 
                t.day9, 
                t.day10, 
                t.day11, 
                t.day12, 
                t.day13, 
                t.day14, 
                t.day15, 
                t.day16, 
                t.day17, 
                t.day18, 
                t.day19, 
                t.day20, 
                t.day21, 
                t.day22, 
                t.day23, 
                t.day24, 
                t.day25, 
                t.day26, 
                t.day27, 
                t.day28, 
                t.day29, 
                t.day30, 
                t.day31 
                ");
                strSql.Append("  FROM DC_OA_Attence t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数 
                DateTime dtstart = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                var dp = new DynamicParameters(new { });
                if (!queryParam["DC_OA_AttenceMonth"].IsEmpty())
                {
                    dp.Add("DC_OA_AttenceMonth", queryParam["DC_OA_AttenceMonth"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_AttenceMonth = @DC_OA_AttenceMonth ");
                }
                else
                {
                    dp.Add("DC_OA_AttenceMonth", dtstart.ToString("yyyyMM"), DbType.String);
                    strSql.Append(" AND t.DC_OA_AttenceMonth = @DC_OA_AttenceMonth ");

                }
                if (!queryParam["F_OA_AttenceDeptId"].IsEmpty())
                {
                    dp.Add("F_OA_AttenceDeptId", queryParam["F_OA_AttenceDeptId"].ToString(), DbType.String);
                    strSql.Append(" AND (t.F_OA_AttenceCompanyId =@F_OA_AttenceDeptId or t.F_OA_AttenceDeptId = @F_OA_AttenceDeptId)");
                }
                strSql.Append(" order by F_OA_AttenceCompanyId,F_OA_AttenceDeptId ");
                // pagination.rows = 25;
                return this.BaseRepository().FindTable(strSql.ToString(), dp);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }



        }


        public DataTable GetAttenceRocord(string Month, string userid)
        {
            int year =int.Parse( Month.Substring(0, 4));
            int month = int.Parse(Month.Substring(4, 2));
            DateTime dtstart = new DateTime(year,month,1);
            DateTime dtEnd = new DateTime(year, month + 1, 1);
            return GetAttenceMonth(dtstart, dtEnd, userid);

        }

        public IEnumerable<DC_OA_AttenceEntity> GetPageList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
                t.dc_oa_attenceid, 
                t.f_oa_attenceuserid, 
                t.dc_oa_attencemonth, 
                t.f_oa_attencedeptid, 
                t.f_sumdays, 
                t.f_comondays, 
                t.f_leavedays, 
                t.f_forgetnums, 
                t.f_repairnums, 
                t.f_outdays, 
                t.f_laternums 
                ");
                strSql.Append("  FROM dc_oa_attence t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数 
                var dp = new DynamicParameters(new { });
                if (!queryParam["dc_oa_attencemonth"].IsEmpty())
                {
                    dp.Add("dc_oa_attencemonth", queryParam["dc_oa_attencemonth"].ToString(), DbType.String);
                    strSql.Append(" AND t.dc_oa_attencemonth = @dc_oa_attencemonth ");
                }
                if (!queryParam["f_oa_attenceuserid"].IsEmpty())
                {
                    dp.Add("f_oa_attenceuserid", queryParam["f_oa_attenceuserid"].ToString(), DbType.String);
                    strSql.Append(" AND t.f_oa_attenceuserid = @f_oa_attenceuserid ");
                }
                return this.BaseRepository().FindList<DC_OA_AttenceEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary> 
        /// 获取DC_OA_Attence表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DC_OA_AttenceEntity GetDC_OA_AttenceEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_AttenceEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary> 
        /// 获取树形数据 
        /// </summary> 
        /// <returns></returns> 
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(" select * from LR_Base_Department ");
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据 

        /// <summary> 
        /// 删除实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<DC_OA_AttenceEntity>(t => t.DC_OA_AttenceId == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary> 
        /// 保存实体数据（新增、修改） 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public void SaveEntity(string keyValue, DC_OA_AttenceEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        public float GetDay(DateTime dtStart, DateTime dtEnd, string starts, string ends, DateTime currentDays)
        {
            DateTime dtNextDays = currentDays.AddDays(1);

            if (dtStart >= currentDays && dtEnd < dtNextDays)
            {
                if (starts == ends)
                {

                    return 0.5f;
                }
                else if(starts=="1" &&ends=="2")
                {
                    return 1.0f;
                }

            }
            else if (dtStart < currentDays && dtEnd < dtNextDays)
            {
                if (ends == "1")
                {

                    return 0.5f;
                }
                else if(ends=="2")
                {
                    return 1.0f;
                }

            }
            else if (dtStart >= currentDays && dtEnd > dtNextDays)
            {
                if (starts == "2")
                {

                    return 0.5f;
                }
                else
                {
                    return 1.0f;
                }


            }
            else if (dtStart < currentDays && dtEnd > dtNextDays)
            {
                return 1.0f;
            }

            return 0f;

        }


        public float GetDay(DateTime dtStart, DateTime dtEnd, DateTime currentDays)
        {
            DateTime dtNextDays = currentDays.AddDays(1);

            if (dtStart >= currentDays&&dtStart<=dtNextDays)
            {
                return 1.0f;

            }
            else if(dtEnd>=currentDays&&dtEnd<=dtNextDays)
            {
                return 1.0f;
            }
        
            return 0f;

        }

        public DataTable GetAttenceMonth(DateTime dtStart, DateTime dtEnd, string userids)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("userid"));
            for (int i = 1; i <= 31; i++)
            {
                dt.Columns.Add(new DataColumn("day" + i));

            }

            int days = DateTime.DaysInMonth(dtStart.Year, dtStart.Month);
            var Leavelist = leaveReqIBLL.GetList(dtStart, dtEnd);//在此区间内的请假,审批同意的请假
            var Evectionlist = evectionReqIBLL.GetList(dtStart, dtEnd);//在此区间内的出差 审批同意的出差申请
            var Repairlist = dc_OA_AttenceRepairdIBLL.GetList(dtStart, dtEnd);//在此区间内的补卡记录
            var AttenceRecordList = dC_OA_AttenceRecordIBLL.GetList(dtStart, dtEnd);//考勤原始记录
            var holidaySettingList = dC_OA_HolidaySettingIBLL.GetList(dtStart, dtEnd);//在此区间内的天数设置上班，假日，周六等
            var ExtWorkList = extraWorkIBLL.GetList(dtStart, dtEnd);//加班记录
            var PersonBackupList = personBackBll.GetList(dtStart, dtEnd);
           
            DC_OA_AttenceSettingEntity settingEntity = cache.Read<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", CacheId.language);
            if (settingEntity == null)
            {
                settingEntity = settingBLL.GetEnableDC_OA_AttenceSettingEntity();
                cache.Write<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", settingEntity, CacheId.language);
            }
            string[] usergroup = userids.Split(',');

            foreach (var users in usergroup)
            {
                var userLeaveList = Leavelist.Where(item => item.F_Name == users);//用户请假天数
                var useEvectionList = Evectionlist.Where(item => item.F_UserId == users);//用户出差天数
                var useRepairList = Repairlist.Where(item => item.F_CreateUserId == users);//用户补卡次数
                var userRecordList = AttenceRecordList.Where(item => item.F_CreateUserName == users);//用户打考勤记录
                var userExtWorkList = ExtWorkList.Where(item => item.F_Applicant == users);//用户加班记录
                var personBackList = PersonBackupList.Where(item => item.DC_OA_UserId == users);//报备记录
              
                float f = 0;
                DataRow dr = dt.NewRow();

                for (int i = 0;; i++)
                {
                    var day = dtStart.AddDays(i);//获取天数
                    if (day >= dtEnd) break;
                    var holiday = holidaySettingList.Where(item => item.DC_OA_Date == day).SingleOrDefault();
                   
                    dr["userid"] = users;
                    int m = i + 1;
                    dr["day" + m] = "0";
                    if (holiday.DC_OA_IsWork == 0) //工作日
                    {
                        if (userLeaveList != null && userLeaveList.Count() > 0)
                        {
                            //请假做判断，请假按事假，年假，调休做判断

                            foreach (var leave in userLeaveList)
                            {
                                f = 0f;
                                f = GetDay((DateTime)leave.F_StartDate, (DateTime)leave.F_EndDate, day);
                                if (f > 0)
                                {
                                    dr["day" + m] = "1";
                                    continue;
                                }
                            }
                        }

                       else  if (useEvectionList != null && useEvectionList.Count() > 0)
                        {
                            foreach (var evection in useEvectionList)
                            {
                                f = 0.0f;
                                f = GetDay((DateTime)evection.F_StartDate, (DateTime)evection.F_EndDate, day);
                                if (f > 0)
                                {
                                    dr["day" + m] = "2";
                                    continue;
                                }

                            }
                        }

                        else if (userExtWorkList != null && userExtWorkList.Count() > 0)
                        {
                            foreach (var evection in userExtWorkList)
                            {
                                f = 0.0f;
                               if (((DateTime)evection.F_StartDate).ToString("yyyyMMdd")==day.ToString("yyyyMMdd"))
                                {
                                    dr["day" + m] = "3";
                                    continue;
                                }
                             

                            }


                        }


                    }
                }
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }









        public bool InsertDC_OA_AttenceByMonth(DateTime dtStart, DateTime dtEnd)
        {
            //姓名，部门，工号，出勤天数，休息天数，迟到次数，早退次数，上班缺卡次数，下班缺卡次数，
            //旷工天数，出差天数，事假，公休假，外出报备,病假，调休

            var db = this.BaseRepository().BeginTrans();
            // int g = 0;
            try
            {
                ///定时任务，每个月第一天生成上个月人员考勤记录
                //考勤生成，根据 假日表（节假日，周未不记考勤）、请假表，出差记录表，打卡记录及补卡记录生成
                //获取上个月，所有人出差记录
                //获取上个月，所有人打卡记录
                //获取上个月，所有人请假记录
                //获取上个月，所有人补卡记录
                //获取上个月假日，周未
                //获取考勤设置，判断上下班时间是否正常
                //获取上个月第一天
                //DateTime dtStart = Time.FirstDayOfPreviousMonth(DateTime.Now);
                //获取这个月第一天
                // DateTime dtEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                string month = dtStart.ToString("yyyyMM");
                this.BaseRepository().Delete<DC_OA_AttenceEntity>(t => t.DC_OA_AttenceMonth == month);

                DC_OA_AttenceEntity entity = null;
                List<UserEntity> Userlist = userIBLL.GetAllList();//所有人
                var Leavelist = leaveReqIBLL.GetList(dtStart, dtEnd);//在此区间内的请假,审批同意的请假
                var Evectionlist = evectionReqIBLL.GetList(dtStart, dtEnd);//在此区间内的出差 审批同意的出差申请
                var Repairlist = dc_OA_AttenceRepairdIBLL.GetList(dtStart, dtEnd);//在此区间内的补卡记录
                var AttenceRecordList = dC_OA_AttenceRecordIBLL.GetList(dtStart, dtEnd);//考勤原始记录
                var holidaySettingList = dC_OA_HolidaySettingIBLL.GetList(dtStart, dtEnd);//在此区间内的天数设置上班，假日，周六等
                var ExtWorkList = extraWorkIBLL.GetList(dtStart, dtEnd);//加班记录
                var PersonBackupList = personBackBll.GetList(dtStart, dtEnd);
                DC_OA_AttenceSettingEntity settingEntity = cache.Read<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", CacheId.language);
                if (settingEntity == null)
                {
                    settingEntity = settingBLL.GetEnableDC_OA_AttenceSettingEntity();
                    cache.Write<DC_OA_AttenceSettingEntity>("DC_OA_AttenceSetting", settingEntity, CacheId.language);
                }

                int SumDays = 0; //正常出勤天数
                float ComonDays = 0; //出勤天数
                float LeaveDays = 0;//请假天数
                int ForgetNums = 0;//上班缺卡
                int RepairNums = 0;//补卡次数
                float OutDays = 0;//出差天数
                int lastNums = 0;//迟到早退
                int OutForgetNums = 0;//下班缺卡
                float NotWorkDays = 0;//旷工天数
                float thingDays = 0;//事假天数
                float xiujiaDays = 0;//休假天数
                float SickLeaveDays = 0;//病假天数
                float TiaoDays = 0; //调休天数
                int BackDays = 0;//报备天数


                foreach (var users in Userlist)
                {
                    if (users.F_Account.ToLower() == "system" || users.F_Account.ToLower() == "admin") continue;
                    var userLeaveList = Leavelist.Where(item => item.F_Name== users.F_UserId);//用户请假天数
                    var useEvectionList = Evectionlist.Where(item => item.F_UserId == users.F_UserId);//用户出差天数
                    var useRepairList = Repairlist.Where(item => item.F_CreateUserId == users.F_UserId);//用户补卡次数
                    var userRecordList = AttenceRecordList.Where(item => item.F_CreateUserName == users.F_UserId);//用户打考勤记录
                    var userExtWorkList = ExtWorkList.Where(item => item.F_Applicant == users.F_UserId);//用户加班记录
                    var personBackList = PersonBackupList.Where(item => item.DC_OA_UserId == users.F_UserId);//报备记录
                    entity = new DC_OA_AttenceEntity();
                    entity.DC_OA_AttenceMonth = month;//月季度
                    entity.F_OA_AttenceUserId = users.F_UserId;//用户id
                    entity.F_OA_AttenceUserName = users.F_RealName;//用户名称
                    entity.F_OA_AttenceDeptId = users.F_DepartmentId;//用户部门
                    entity.F_OA_AttenceCompanyId = users.F_CompanyId;//用户公司
                    CompanyEntity companyentity = companybll.GetEntity(users.F_CompanyId);
                    DepartmentEntity departentity = departbll.GetEntity(users.F_DepartmentId);
                    entity.F_DeptName = departentity.F_FullName;//用户部门名称
                    entity.F_CompanyName = companyentity.F_FullName;//用户公司名称 
                    var postList = postIBLL.GetPostList(users.F_UserId);//用户岗位
                                                                        //获取岗位 收到
                    foreach (var item in postList)
                    {
                        entity.PostName += item.F_Name;
                        entity.PostName += ",";
                    }
                    if (!string.IsNullOrEmpty(entity.PostName))
                    {
                        entity.PostName = entity.PostName.Substring(0, entity.PostName.Length - 1);
                    }
                    //entity.F_DeptName 
                    if (useRepairList != null && useRepairList.Count() > 0)
                    {
                        RepairNums = useRepairList.Count();
                    }
                    entity.F_RepairNums = RepairNums;//补卡次数


                    for (int i = 0; ; i++)
                    {
                        var day = dtStart.AddDays(i);//获取天数

                        //DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        //    settingEntity.DC_OA_AttenceTimeUp1.Value.Hour, settingEntity.DC_OA_AttenceTimeUp1.Value.Minute, 0);//早上上班时间
                        //DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        //  settingEntity.DC_OA_AttenceTimeOut1.Value.Hour, settingEntity.DC_OA_AttenceTimeOut1.Value.Minute, 0);//中午下班时间
                        //DateTime dt3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        //   settingEntity.DC_OA_AttencetTimeUp2.Value.Hour, settingEntity.DC_OA_AttencetTimeUp2.Value.Minute, 0);//下午上班时间
                        //DateTime dt4 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        //  settingEntity.DC_OA_AttenceTimeOut2.Value.Hour, settingEntity.DC_OA_AttenceTimeOut2.Value.Minute, 0);//下午下班时间

                        //对于打卡，如果每日小于早上打卡时间8：00，有一次有效，中午下班，则在中午12点下班，至中午1点有效，
                        //下午上班（2点）， 则1点至2点有效，下午下班（6点），晚于6点有效
                        if (day >= dtEnd) break;
                        float f = 0;//临时变量

                        string info = string.Empty;//填充每个日期信息

                        string temp = string.Empty;

                        var holiday = holidaySettingList.Where(item => item.DC_OA_Date == day).SingleOrDefault();
                        if (holiday.DC_OA_IsWork == 0) //工作日
                        {
                            SumDays += 1;
                            bool bHaveInfo = false;

                            //特殊情况 请假，出差
                            //请假的
                            if (userLeaveList != null && userLeaveList.Count() > 0)
                            {
                                //请假做判断，请假按事假，年假，调休做判断

                                foreach (var leave in userLeaveList)
                                {
                                    f = 0f;

                                    f = GetDay((DateTime)leave.F_StartDate, (DateTime)leave.F_EndDate, leave.F_StartDateIsAm, leave.F_EndDateIsAm, day);

                                    //请假天数增加
                                    LeaveDays += f;
                                    bHaveInfo = true;

                                    if (leave.F_LeaveType == ((int)LeaveType.事假).ToString())
                                    {
                                        thingDays += f;
                                        info += string.Format("事假{0};", temp);
                                    }
                                    else if (leave.F_LeaveType == ((int)LeaveType.年假).ToString())
                                    {
                                        xiujiaDays += f;
                                        info += string.Format("年假{0};", temp);

                                    }
                                    else if (leave.F_LeaveType == ((int)LeaveType.病假).ToString())
                                    {
                                        SickLeaveDays += f;
                                        info += string.Format("病假{0};", temp);
                                    }
                                    else if (leave.F_LeaveType == ((int)LeaveType.调休).ToString())
                                    {
                                        TiaoDays += f;
                                        info += string.Format("调休{0};", temp);
                                    }

                                }
                            }
                            //出差的
                            if (useEvectionList != null && useEvectionList.Count() > 0)
                            {
                                foreach (var evection in useEvectionList)
                                {
                                    f = 0.0f;
                                    f = GetDay((DateTime)evection.F_StartDate, (DateTime)evection.F_EndDate, evection.F_StartDateIsAm, evection.F_EndDateIsAm, day);
                                    bHaveInfo = true;
                                    OutDays += f;
                                    ComonDays += f;

                                }
                            }

                            //打卡考勤
                            if (!bHaveInfo)//如果没有请假出差，则计算打卡
                            {
                                var useDayRecordList = userRecordList.Where(item => item.DC_OA_AttenceDate == day).OrderBy(item => item.DC_OA_AttenceDateTime);
                                if (useDayRecordList != null && useDayRecordList.Count() > 0)// 打卡计算方式 四次打卡都正常
                                {
                                    var record1 = useDayRecordList.Where(item => item.F_OA_RepairType == "上班打卡");//上班记录是否正常，小于上班时间
                                                                                                                 //var record2 = useDayRecordList.Where(item => item.F_OA_RepairType == "上午签退"); //中午下班打卡
                                                                                                                 //var record3 = useDayRecordList.Where(item => item.F_OA_RepairType == "下午签到");//上班记录是否正常，小于上班时间
                                    var record4 = useDayRecordList.Where(item => item.F_OA_RepairType == "下班打卡"); //中午下班打卡
                                    bool bflag1 = record1 != null && record1.Count() > 0;
                                    //bool bflag2 = record2 != null && record2.Count() > 0;
                                    //bool bflag3 = record3 != null && record3.Count() > 0;
                                    bool bflag4 = record4 != null && record4.Count() > 0;

                                    if (bflag1 && bflag4)
                                    {
                                        ComonDays += 1; //正常天数据加1
                                        info = "正常";
                                    }
                                }
                            }

                        }
                        else
                        {

                            foreach (var backitem in personBackList)
                            {
                                if (backitem.DC_OA_Startdate.ToDate() <= day && day <= backitem.DC_OA_Enddate)
                                {
                                    BackDays += 1;
                                    info = "报备";

                                }
                            }
                            //是否有加班
                            //没有的话
                            info = "休息";

                        }

                        if (info == string.Empty) //表明没有打卡记录，没有请假出差记录，也不是休息天，也没有加班，则矿工处理
                        {
                            info = "缺勤";

                        }

                        var daytemp = string.Format("day{0}", i + 1);
                        PropertyInfo pi = entity.GetType().GetProperty(daytemp);
                        if (pi != null)
                            pi.SetValue(entity, info, null);

                    }
                    entity.F_SumDays = SumDays;
                    entity.F_ComonDays = (int)ComonDays;
                    entity.F_LeaveDays = LeaveDays;
                    entity.F_ForgetNums = ForgetNums;
                    entity.F_RepairNums = RepairNums;
                    entity.F_OutDays = OutDays;
                    entity.F_laterNums = lastNums;
                    entity.F_OutForgetNums = OutForgetNums;
                    entity.F_NotWorkDays = NotWorkDays;
                    entity.F_thingDays = thingDays;
                    entity.F_xiujiaDays = xiujiaDays;
                    entity.F_SickLeaveDays = SickLeaveDays;
                    entity.F_TiaoDays = TiaoDays;
                    entity.F_PersonBackDays = BackDays;
                    entity.Create();
                    db.Insert(entity);
                    SumDays = 0; //正常出勤天数
                    ComonDays = 0; //出勤天数
                    LeaveDays = 0;//请假天数
                    ForgetNums = 0;//上班缺卡
                    RepairNums = 0;//补卡次数
                    OutDays = 0;//出差天数
                    lastNums = 0;//迟到早退
                    OutForgetNums = 0;//下班缺卡
                    NotWorkDays = 0;//旷工天数
                    thingDays = 0;//事假天数
                    xiujiaDays = 0;//休假天数
                    SickLeaveDays = 0;//病假天数
                    TiaoDays = 0; //调休天数
                    BackDays = 0;//报备天数

                }
                db.Commit();
                return true;
            }
            catch (Exception ex)
            {
                //  int f = g;
                string msg = ex.Message;
                db.Rollback();
                return false;
            }

        }
        #endregion

    }
}
