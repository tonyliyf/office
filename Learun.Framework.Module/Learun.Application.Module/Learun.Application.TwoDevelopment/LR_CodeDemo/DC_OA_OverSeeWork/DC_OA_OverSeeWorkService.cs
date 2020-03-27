using Dapper;
using Learun.Application.Message;
using Learun.Application.Organization;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 11:19
    /// 描 述：DC_OA_OverSeeWork
    /// </summary>
    public class DC_OA_OverSeeWorkService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OverSeeWorkEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                int noticeTimespan = Convert.ToInt32
                (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                 t.[F_OSWId]
                  ,t.[F_OSWCode]
                  ,t.[F_OSWContent]
                  ,t.[F_Attachments]
                  ,t.[F_BeginDate]
                  ,t.[F_EndDate]
                  ,t.[F_DepartmentId]
                  ,t.[F_Department]
                  ,t.[F_LeaderUserId]
                  ,t.[F_LeaderUser]
                  ,t.[F_OverSeeUserId]
                  ,t.[F_OverSeeUser]
                  ,t.[F_Marks]
                  ,case when t.f_state = '办结' then '办结' when t.f_state = '草稿' then '草稿'
	              when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
	              when datediff(day,getdate(),t.f_enddate)<@day then '临近'
	              else f_state end as F_State
                  ,t.[F_OSWType]
                  ,t.[F_DOHId]
                  ,t.[F_HighLeaderId]
                  ,t.[F_HighLeader]
                  ,t.[F_OSCaptain]
                  ,t.[F_VisitFrom]
                  ,t.[F_CreateDate]
                  ,t.[F_Draft]
                ");
                strSql.Append("  FROM DC_OA_OverSeeWork t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("day", noticeTimespan, DbType.Int32);
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_BeginDate >= @startTime AND t.F_BeginDate <= @endTime ) ");
                }
                if (!queryParam["F_BeginDate"].IsEmpty())
                {
                    dp.Add("F_BeginDate", queryParam["F_BeginDate"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BeginDate = @F_BeginDate ");
                }
                if (!queryParam["F_OSWContent"].IsEmpty())
                {
                    dp.Add("F_OSWContent", "%" + queryParam["F_OSWContent"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OSWContent Like @F_OSWContent ");
                }
                if (!queryParam["State"].IsEmpty())
                {
                    dp.Add("State", queryParam["State"].ToString(), DbType.String);
                    strSql.Append(@" AND (case when t.f_state = '办结' then '办结' when t.f_state = '草稿' then '草稿'
	                          when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
	                          when datediff(day,getdate(),t.f_enddate)<@day then '临近'
	                          else f_state end) = @State ");
                }
                if (!queryParam["F_DepartmentId"].IsEmpty())
                {
                    dp.Add("F_DepartmentId", queryParam["F_DepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DepartmentId = @F_DepartmentId ");
                }
                pagination.sidx = "F_OSCaptain,F_OSWCode";
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkEntity>(strSql.ToString(), dp, pagination);
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


        public IEnumerable<DC_OA_OverSeeWorkEntity> GetOverSeeWork()
        {
            try
            {
               
                var strSql = new StringBuilder();
                strSql.Append(@"select *from DC_OA_OverSeeWork t 
where t.F_state != '办结' and t.F_state = '草稿' ");
                return this.BaseRepository().FindList<DC_OA_OverSeeWorkEntity>(strSql.ToString());
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
        /// 获取DC_OA_OverSeeWork表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OverSeeWorkEntity GetDC_OA_OverSeeWorkEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OverSeeWorkEntity>(keyValue);
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
                return this.BaseRepository().FindTable(@" SELECT  [F_DepartmentId]
	                  ,[F_ParentId]
                      ,[F_FullName]
                  FROM [LR_Base_Department] ");
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
                var list = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_OSWId == keyValue);
                foreach (var item in list)
                {
                    this.BaseRepository().Delete<DC_OA_OverSeeWorkTaskExecuteEntity>(c => c.F_SecondId == item.F_SecondId);
                    this.BaseRepository().Delete(item);
                }
                this.BaseRepository().Delete<DC_OA_OverSeeWorkEntity>(t => t.F_OSWId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OverSeeWorkEntity entity)
        {
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
                    userNames = userNames.Substring(0, userNames.Length - 1);
                }
                return userNames;
            };
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    entity.F_Department = this.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == entity.F_DepartmentId).F_FullName;
                    entity.F_LeaderUser = Func3(entity.F_LeaderUserId);
                    entity.F_OverSeeUser = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == entity.F_OverSeeUserId).F_RealName;
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    entity.F_State = "草稿";
                    entity.F_Draft = 1;
                    entity.F_Department = this.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == entity.F_DepartmentId).F_FullName;
                    entity.F_LeaderUser = Func3(entity.F_LeaderUserId);
                    entity.F_OverSeeUser = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == entity.F_OverSeeUserId).F_RealName;
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

        #endregion
        public void EnterOverSeeWork(string keyValue)
        {
            var entity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkEntity>(keyValue);
            entity.F_Draft = 0;
            entity.F_State = "执行中";
            new LR_StrategyInfoBLL().SendMessageByUserIds("overworkNotice", string.Format("工作项\"{0}\"已下达", entity.F_OSWContent), entity.F_LeaderUserId, LoginUserInfo.Get().userId);
            this.BaseRepository().Update(entity);
        }

        public List<WorkStatisticsModel> StatisticsWorkByCurrentMonth(DateTime startDate, DateTime endDate, string executeState, string workTitle)
        {
            UserInfo userinfo = LoginUserInfo.Get();
            List<WorkStatisticsModel> result = new List<WorkStatisticsModel>();
            Func<int, string> Func0 = state =>
            {
                switch (state)
                {
                    case 0: return "执行";
                    case 1: return "暂停";
                    case 2: return "终止";
                    case 3: return "完成";
                    default:
                        return "";
                }
            };
            Func<string, string> Func1 = userid =>
            {
                var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == userid);
                return user == null ? "" : user.F_RealName;
            };
            Func<string, string> Func2 = departmentid =>
            {
                var department = this.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == departmentid);
                return department == null ? "" : department.F_FullName;
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
                if (userNames.Length > 0)
                {
                    userNames = userNames.Substring(0, userNames.Length - 1);
                }
                return userNames;
            };
            Func<string, string> Func4 = departmentids =>
            {
                if (string.IsNullOrWhiteSpace(departmentids))
                {
                    return string.Empty;
                }
                var userDepartmentIdArr = departmentids.Split(',');
                List<string> userDepartmentList = new List<string>();
                foreach (var departmentid in userDepartmentIdArr)
                {
                    userDepartmentList.Add(Func2(departmentid));
                }
                string userDeparmentIds = string.Empty;
                userDepartmentList.ForEach(c => userDeparmentIds += c + ",");
                if (userDeparmentIds.Length > 0)
                {
                    userDeparmentIds = userDeparmentIds.Substring(0, userDeparmentIds.Length - 1);
                }
                return userDeparmentIds;
            };
            Action<List<WorkStatisticsModel>, DC_OA_OverSeeWorkEntity, DC_OA_OverSeeWorkTaskSplitEntity, DC_OA_OverSeeWorkTaskSplitEntity> Func5 =
            (list, workEntity, splitEntity, splitChildEntity) =>
            {
                var tempSplitEntity = splitChildEntity == null ? splitEntity : splitChildEntity;
                var executeData = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskExecuteEntity>(c => c.F_SecondId == tempSplitEntity.F_SecondId)
                .OrderBy(c => c.F_ExecuteDate);
                StringBuilder tempExecute = new StringBuilder();
                foreach (var executeItem in executeData)
                {
                    tempExecute.Append(executeItem.F_ExecuteDate.ToString("yyyy年MM月dd日") + "，" +
                        Func1(executeItem.F_CreateUserId)
                        + "：" + executeItem.F_ExecuteContent + "；");
                }
                var sEntity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkScoreEntity>(c => c.F_SecondId == tempSplitEntity.F_SecondId && c.F_EvaluateUserId == userinfo.userId);
                list.Add(new WorkStatisticsModel()
                {
                    id = tempSplitEntity.F_SecondId,
                    dutyDepartment = Func2(workEntity.F_DepartmentId),
                    dutyLeader = Func3(workEntity.F_HighLeaderId),
                    dutyOwner = Func3(workEntity.F_LeaderUserId),
                    endTime = tempSplitEntity.F_TaskNodeDate.HasValue ? tempSplitEntity.F_TaskNodeDate : workEntity.F_EndDate,
                    executeContent = tempExecute.ToString(),
                    executeState = Func0(tempSplitEntity.F_State),
                    helpDepartment = Func4(tempSplitEntity.F_TwoDepartmentId),
                    helpDutyOwner = Func3(tempSplitEntity.F_TwoUserId),
                    mainDepartment = Func2(tempSplitEntity.F_OneDepartmentId),
                    mainDepartmentDutyOwner = Func3(tempSplitEntity.F_OneUserId),
                    mainDepartmentLeader = Func3(tempSplitEntity.F_OneLeaderId),
                    workContent = workEntity.F_OSWContent,
                    orderBy = tempSplitEntity.F_code.ToString(),
                    workSplit1 = tempSplitEntity.F_TaskName,
                    workSplit2 = (splitChildEntity == null) ? string.Empty : splitChildEntity.F_TaskName,
                    workType = workEntity.F_OSWType,
                    workTitle = workEntity.F_OSCaptain,
                    createDate = workEntity.F_CreateDate,
                    score = sEntity == null ? 0 : sEntity.F_OSWScore.Value
                });
            };
            var workData = this.BaseRepository().FindList<DC_OA_OverSeeWorkEntity>(c => (c.F_BeginDate >= startDate && c.F_BeginDate <= endDate) || c.F_State == "执行中");
            foreach (var workItem in workData)
            {
                var workSplit1Data = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => string.IsNullOrEmpty(c.F_ParentId) && c.F_OSWId == workItem.F_OSWId);
                foreach (var workSplit1 in workSplit1Data)
                {
                    Func5(result, workItem, workSplit1, null);
                    var workSplit2Data = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_SecondId == workSplit1.F_ParentId);
                    foreach (var workSplit2 in workSplit2Data)
                    {
                        Func5(result, workItem, workSplit1, workSplit2);
                    }
                }
            }
            List<WorkStatisticsModel> num = null;
            if (!String.IsNullOrEmpty(executeState))
            {

                num = result.OrderBy(c => c.orderBy).OrderBy(B => B.executeState.Contains(executeState)).ToList();
            }
            else if (!String.IsNullOrEmpty(workTitle))
            {
                num = result.OrderBy(c => c.orderBy).OrderBy(B => B.workTitle.Contains(workTitle)).ToList();
            }
            else
            {
                num = result.OrderBy(c => c.workContent).ToList();
            }
            return num;
        }

        public IEnumerable<EChartModel> StatisticForEChart()
        {
            string sql = @"  select count(*) as count ,f_oswtype as [type],f_state as state
              from dc_oa_overseework where f_oswtype is not null and f_oswtype!='' group by f_oswtype,f_state";
            return this.BaseRepository().FindList<EChartModel>(sql);
        }

        public IEnumerable<WorkCategoryModel> StatisticsByCategory(DateTime startDate, DateTime endDate)
        {
            string sql = @"   select ROW_NUMBER() over(order by f_state) as id,
                          count(*) as count,
                          f_state  as state
                          ,f_oswtype as type  from dc_oa_overseework
                          where F_BeginDate>=@StartDate and F_BeginDate<=@EndDate and f_oswtype is not null and f_oswtype!=''
                           group by f_state,f_oswtype order by f_state";
            var result = this.BaseRepository().FindList<WorkCategoryModel>(sql, new { StartDate = startDate, EndDate = endDate }).ToList();
            result.Add(new WorkCategoryModel() { id = result.Count + 1, count = result.Sum(c => c.count), state = "合计", type = "" });
            return result;
        }
        public IEnumerable<EChartModel> StatisticsByCategoryEx(DateTime startDate, DateTime endDate)
        {
            string sql = @"  select count(*) as count ,f_oswtype as [type],f_state as state
              from dc_oa_overseework where F_BeginDate>=@StartDate and F_BeginDate<=@EndDate and f_oswtype is not null and f_oswtype!='' group by f_oswtype,f_state";
            return this.BaseRepository().FindList<EChartModel>(sql, new { StartDate = startDate, EndDate = endDate });
        }

        public int GetCount(string state)
        {
            int noticeTimespan = Convert.ToInt32
              (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
            return this.BaseRepository().FindObject(@"select count(*) from dc_oa_overseework  where (case when f_state = '办结' then '办结' when f_state ='草稿' then '草稿'
	                  when f_enddate is not null and f_enddate < getdate() then '逾期'
	                  when datediff(day,getdate(),f_enddate)<@day then '临近'
	                  else f_state end) =@state", new { state = state, day = noticeTimespan }).ToInt();
        }
        public int GetCount1(string state)
        {
            int noticeTimespan = Convert.ToInt32
              (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
            UserInfo user = LoginUserInfo.Get();
            string sql = @"select count(*) from dc_oa_overseework t where (case when t.f_state = '办结' then '办结'  when t.f_state = '草稿' then '草稿'
	                  when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
	                  when datediff(day,getdate(),t.f_enddate)<@day then '临近'
	                  else t.f_state end) =@state";
            sql += " and (select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @F_OneUserId and F_OSWId=t.F_OSWId) > 0 ";
            return this.BaseRepository().FindObject(sql, new { state = state, F_OneUserId = "%" + LoginUserInfo.Get().userId + "%", day = noticeTimespan }).ToInt();
        }
        public int GetCount2(string state)
        {
            int noticeTimespan = Convert.ToInt32
              (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
            UserInfo user = LoginUserInfo.Get();
            string sql = @"select count(*) from dc_oa_overseework t where (case when t.f_state = '办结' then '办结'  when t.f_state = '草稿' then '草稿'
	                  when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
	                  when datediff(day,getdate(),t.f_enddate)<@day then '临近'
	                  else t.f_state end) =@state";
            sql += @" and ((select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @F_OneUserId and F_OSWId=t.F_OSWId) > 0
                      or t.F_OverSeeUserId like @F_OneUserId or t.F_HighLeaderId like @F_OneUserId or t.F_LeaderUserId like @F_OneUserId
                      or (select count(*) from dc_oa_overseeworktasksplit where f_oneuserid like @F_OneUserId and f_oswid = t.f_oswid) > 0
                      or (select count(*) from dc_oa_overseeworktasksplit where f_twouserid like @F_OneUserId and f_oswid = t.f_oswid) > 0)";
            return this.BaseRepository().FindObject(sql, new { state = state, F_OneUserId = "%" + LoginUserInfo.Get().userId + "%", day = noticeTimespan }).ToInt();
        }
        public void AddScore(string keyValue, double score, string advice)
        {
            UserInfo user = LoginUserInfo.Get();
            var sEntity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkTaskSplitEntity>(keyValue);
            var entity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkScoreEntity>(c => c.F_SecondId == keyValue && c.F_EvaluateUserId == user.userId);
            if (entity == null)
            {
                entity = new DC_OA_OverSeeWorkScoreEntity();
                entity.Create();
                entity.F_EvaluateDate = DateTime.Now;
                entity.F_EvaluateDepartmentId = user.departmentId;
                entity.F_EvaluateUserId = user.userId;
                entity.F_OSWCode = sEntity.F_code.ToString();
                entity.F_SecondId = keyValue;
                entity.F_OSWSContent = advice;
                entity.F_OSWContent = sEntity.F_TaskContent;
                entity.F_OSWScore = score;
                this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.F_OSWScore = score;
                this.BaseRepository().Update(entity);
            }
        }

        public void GetScore(string keyValue, out double score, out string advice)
        {
            UserInfo user = LoginUserInfo.Get();
            var entity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkScoreEntity>(c => c.F_SecondId == keyValue && c.F_EvaluateUserId == user.userId);
            if (entity == null)
            {
                score = 0;
                advice = "";
            }
            else
            {
                score = entity.F_OSWScore.Value;
                advice = entity.F_OSWSContent;
            }
        }
        public DataTable GetList1(string state)
        {
            int noticeTimespan = Convert.ToInt32
              (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
            return this.BaseRepository().FindTable(@"select top 7 f_oswcontent as [name],
            f_oswid as id,
            (select top 1 f_realname from lr_base_user where f_userid=t.F_OverSeeUserId) as [username],
            f_createdate as [time]
            from dc_oa_overseework t
            where (case when t.f_state = '办结' then '办结' when t.f_state = '草稿' then '草稿'
            when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
            when datediff(day,getdate(),t.f_enddate)<@day then '临近'
            else f_state end) = @State order by f_createdate desc", new { State = state, day = noticeTimespan });
        }

        public DataTable GetPlatformListByState(string state)
        {
            int noticeTimespan = Convert.ToInt32
            (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
            string sql = string.Format(@"  select top 7
              t.f_oswcontent as [name],
              t.f_enddate as [date]
              from dc_oa_overseework t where 
            ((select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @userid and F_OSWId=t.F_OSWId) > 0 
             or t.F_OverSeeUserId like @userid or t.F_HighLeaderId like @userid or t.F_LeaderUserId like @userid
             or (select count(*) from dc_oa_overseeworktasksplit where f_oneuserid like @userid and f_oswid = t.f_oswid) > 0
             or (select count(*) from dc_oa_overseeworktasksplit where f_twouserid like @userid and f_oswid = t.f_oswid) > 0)
                 and 
            (case when t.f_state = '办结' then '办结'  when t.f_state = '草稿' then '草稿'
                   when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
                   when datediff(day,getdate(),t.f_enddate)<@day then '临近'
                   else t.f_state end)= @state order by f_enddate desc");
            return this.BaseRepository().FindTable(sql, new { userid = "%" + LoginUserInfo.Get().userId + "%", state = state, day = noticeTimespan });
        }
        public Dictionary<string, List<int>> GetTaskByTypeAndMonth()
        {
            var typeList = this.BaseRepository().FindList<string>("  select distinct f_oswtype  from dc_oa_overseework");
            var dt = this.BaseRepository().FindTable(@"  select month(t.f_enddate) as [month],t.f_oswtype as [type],count(*) as [count] from dc_oa_overseework t
                where t.f_oswtype is not null and t.f_enddate is not null and year(t.f_enddate) = year(getdate())
                and   ((select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @userid and F_OSWId=t.F_OSWId) > 0
                or t.F_OverSeeUserId like @userid or t.F_HighLeaderId like @userid or t.F_LeaderUserId like @userid
                or (select count(*) from dc_oa_overseeworktasksplit where f_oneuserid like @userid and f_oswid = t.f_oswid) > 0
                or (select count(*) from dc_oa_overseeworktasksplit where f_twouserid like @userid and f_oswid = t.f_oswid) > 0)
                group by t.f_oswtype,month(t.f_enddate)", new { userid = "%" + LoginUserInfo.Get().userId + "%" });
            Dictionary<string, List<int>> ret = new Dictionary<string, List<int>>();
            foreach (var str in typeList)
            {
                var list = new List<int>();
                for (int month = 1; month <= 12; month++)
                {
                    var row = dt.AsEnumerable().FirstOrDefault(c => c["month"].ToString() == month.ToString() && c["type"].ToString() == str);
                    if (row == null)
                    {
                        list.Add(0);
                    }
                    else
                    {
                        list.Add(Convert.ToInt32(row["count"]));
                    }
                }
                ret.Add(str, list);
            }
            return ret;
        }
        public DataTable GetTaskPercentByCategory()
        {
            return this.BaseRepository().FindTable(@" select f_oswtype as [name],count(*) as [value] from dc_oa_overseework t
                where  (select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @userid and F_OSWId=t.F_OSWId) > 0
                or t.F_OverSeeUserId like @userid or t.F_HighLeaderId like @userid or t.F_LeaderUserId like @userid
                or (select count(*) from dc_oa_overseeworktasksplit where f_oneuserid like @userid and f_oswid = t.f_oswid) > 0
                or (select count(*) from dc_oa_overseeworktasksplit where f_twouserid like @userid and f_oswid = t.f_oswid) > 0
                group by f_oswtype", new { userid="%"+LoginUserInfo.Get().userId+"%"});
        }
        public int GetTaskCountByCategory(string category)
        {
            return this.BaseRepository().FindObject(@"  select count(*) from dc_oa_overseework t where t.f_oswtype= @category
            and ((select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @userid and F_OSWId=t.F_OSWId) > 0 
            or t.F_OverSeeUserId like @userid or t.F_HighLeaderId like @userid or t.F_LeaderUserId like @userid)", new { category = category, userid = "%" + LoginUserInfo.Get().userId + "%" }).ToInt();
        }
        public int GetMyTaskCount()
        {
            return this.BaseRepository().FindObject(@"  select count(*)
                  from dc_oa_overseework t 
                  where (select count(*) from dc_oa_overseeworktasksplit where f_oneuserid like @userid and f_oswid = t.f_oswid) > 0", new { userid = "%" + LoginUserInfo.Get().userId + "%" }).ToInt();
        }
        public int GetMyTaskCountEx()
        {
            return this.BaseRepository().FindObject(@"  select count(*)
                  from dc_oa_overseework t
                  where (select count(*) from dc_oa_overseeworktasksplit where f_twouserid like @userid and f_oswid = t.f_oswid) > 0", new { userid = "%" + LoginUserInfo.Get().userId + "%" }).ToInt();
        }
    }
}
