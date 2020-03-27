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
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:28
    /// 描 述：DC_OA_OverSeeWorkTaskSplit
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitService : RepositoryFactory
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
                strSql.Append("  WHERE t.f_state != '草稿' ");
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
                if (!queryParam["F_OSWCode"].IsEmpty())
                {
                    dp.Add("F_OSWCode", "%" + queryParam["F_OSWCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OSWCode Like @F_OSWCode ");
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
                if (!queryParam["F_Department"].IsEmpty())
                {
                    dp.Add("F_Department", "%" + queryParam["F_Department"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Department Like @F_Department ");
                }
                if (!queryParam["F_LeaderUser"].IsEmpty())
                {
                    dp.Add("F_LeaderUser", "%" + queryParam["F_LeaderUser"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LeaderUser Like @F_LeaderUser ");
                }
                if (!queryParam["F_OverSeeUser"].IsEmpty())
                {
                    dp.Add("F_OverSeeUser", "%" + queryParam["F_OverSeeUser"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OverSeeUser Like @F_OverSeeUser ");
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

        public IEnumerable<DC_OA_OverSeeWorkEntity> GetPageListEx(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
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
                  ,case when t.f_state = '办结' then '办结'
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
                strSql.Append("  WHERE t.f_state!='草稿'");
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
                if (!queryParam["State"].IsEmpty())
                {
                    dp.Add("State", queryParam["State"].ToString(), DbType.String);
                    strSql.Append(@" AND (case when t.f_state = '办结' then '办结'
	                          when t.f_enddate is not null and t.f_enddate < getdate() then '逾期'
	                          when datediff(day,getdate(),t.f_enddate)<@day then '临近'
	                          else f_state end) = @State ");
                }
                if (!queryParam["F_OSWCode"].IsEmpty())
                {
                    dp.Add("F_OSWCode", "%" + queryParam["F_OSWCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OSWCode Like @F_OSWCode ");
                }
                if (!queryParam["F_OSWContent"].IsEmpty())
                {
                    dp.Add("F_OSWContent", "%" + queryParam["F_OSWContent"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OSWContent Like @F_OSWContent ");
                }
                if (!queryParam["F_Department"].IsEmpty())
                {
                    dp.Add("F_Department", "%" + queryParam["F_Department"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Department Like @F_Department ");
                }
                if (!queryParam["F_LeaderUser"].IsEmpty())
                {
                    dp.Add("F_LeaderUser", "%" + queryParam["F_LeaderUser"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_LeaderUser Like @F_LeaderUser ");
                }
                if (!queryParam["F_OverSeeUser"].IsEmpty())
                {
                    dp.Add("F_OverSeeUser", "%" + queryParam["F_OverSeeUser"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OverSeeUser Like @F_OverSeeUser ");
                }

                dp.Add("F_OneUserId", "%" + user.userId + "%", DbType.String);
                strSql.Append(" and (select count(*) from DC_OA_OverSeeWorkTaskSplit where F_OneUserId like @F_OneUserId and F_OSWId=t.F_OSWId) > 0 ");

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
                return this.BaseRepository().FindTable(@" 
            select * from [DC_OA_OverSeeWork] ");
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

        #endregion

        public List<GanttEntity> GetGanttData(string keyValue)
        {
            int noticeTimespan = Convert.ToInt32
                (this.BaseRepository().FindObject("SELECT f_itemvalue FROM [LR_Base_DataItemDetail] where F_ItemId='03747945-7dc1-41e1-a4b9-c5482bda1b97'") ?? 7);
            Func<DateTime?, string> toGanttDateStr = time =>
            {
                if (time.HasValue)
                {
                    DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)).Date;
                    return "/Date(" + ((time.Value.Date - start.Date).TotalSeconds * 1000).ToString() + ")/";
                }
                return string.Empty;
            };
            Func<int?, string> GetColor = state =>
            {
                switch (state)
                {
                    case 1: return "ganttGray";
                    case 2: return "ganttOrange";
                    case 3: return "ganttBlue";
                    case 0: return "ganttGreen";
                    default:
                        return "ganttYellow";
                }
            };
            var task = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkEntity>(c => c.F_OSWId == keyValue);
            if (task == null)
            {
                return new List<GanttEntity>();
            }
            else
            {
                List<GanttEntity> list = new List<GanttEntity>();
                var result = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_OSWId == keyValue && (c.F_ParentId == null || c.F_ParentId.Length <= 0));
                foreach (var item in result)
                {
                    var childResult = this.BaseRepository().FindList<DC_OA_OverSeeWorkTaskSplitEntity>(c => c.F_OSWId == keyValue && c.F_ParentId == item.F_SecondId).OrderBy(c => c.F_code).ToList();
                    foreach (var childItem in childResult)
                    {
                        DateTime? t = childItem.F_TaskNodeDate.HasValue ? childItem.F_TaskNodeDate.Value : task.F_EndDate;
                        var ganttEntity1 = new GanttEntity()
                        {
                            id = item.F_SecondId,
                            desc = childItem.F_TaskName,
                            name = childResult.IndexOf(childItem) == 0 ? item.F_TaskName : string.Empty,
                            values = new List<GanttValue>()
                            {
                                new GanttValue()
                                {
                                    from = childItem.F_TaskNodeDateFirst.HasValue ? toGanttDateStr(childItem.F_TaskNodeDateFirst) : toGanttDateStr(task.F_BeginDate),
                                    to = toGanttDateStr(t),
                                    customClass = (childItem.F_State == 0 && t.HasValue&&DateTime.Now>t.Value)?"ganttRed":
                                    (childItem.F_State == 0 && t.HasValue&&(t.Value-DateTime.Now).Days<=noticeTimespan)?"ganttYellow":GetColor(item.F_State),
                                    label = childItem.F_TaskContent,
                                    dataObj = new GanttDataObj(item.F_SecondId,childItem.F_ProcessId)
                                }
                            }
                        };
                        list.Add(ganttEntity1);
                    }
                    DateTime? t1 = item.F_TaskNodeDate.HasValue ? item.F_TaskNodeDate : task.F_EndDate;
                    var ganttEntity = new GanttEntity()
                    {
                        id = item.F_SecondId,
                        desc = item.F_TaskName,
                        name = childResult.IndexOf(item) == 0 ? item.F_TaskName : string.Empty,
                        values = new List<GanttValue>()
                            {
                                new GanttValue()
                                {
                                    from = item.F_TaskNodeDateFirst.HasValue ? toGanttDateStr(item.F_TaskNodeDateFirst) : toGanttDateStr(task.F_BeginDate),
                                    to =  toGanttDateStr(t1),
                                    customClass = (item.F_State == 0 && t1.HasValue&&DateTime.Now>t1.Value)?"ganttRed":
                                    (item.F_State == 0 && t1.HasValue&&(t1.Value-DateTime.Now).Days<=7)?"ganttYellow":GetColor(item.F_State),
                                    label = item.F_TaskContent,
                                    dataObj = new GanttDataObj(item.F_SecondId,item.F_ProcessId)
                                }
                            }
                    };
                    list.Add(ganttEntity);
                    //if (childResult == null || childResult.Count == 0)
                    //{
                    //    var ganttEntity = new GanttEntity()
                    //    {
                    //        id = item.F_SecondId,
                    //        desc = string.Empty,
                    //        name = item.F_TaskName,
                    //        values = new List<GanttValue>()
                    //        {

                    //        }
                    //    };
                    //    list.Add(ganttEntity);
                    //}
                }
                return list;
            }
        }

        public void ConnectProcess(string keyValue, string processId)
        {
            var entity = this.BaseRepository().FindEntity<DC_OA_OverSeeWorkTaskSplitEntity>(keyValue);
            entity.F_ProcessId = processId;
            this.BaseRepository().Update(entity);
        }
    }
}
