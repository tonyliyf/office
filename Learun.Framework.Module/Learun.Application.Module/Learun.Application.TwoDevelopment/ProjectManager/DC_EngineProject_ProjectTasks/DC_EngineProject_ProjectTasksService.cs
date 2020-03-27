using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-19 14:16
    /// 描 述：DC_EngineProject_ProjectTasks
    /// </summary>
    public class DC_EngineProject_ProjectTasksService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PTId,
                t.F_TaskItemNumber,
                t.F_TaskName,
                t.F_MeasurementUnit,
                t.F_ProjectQuantities,
                t.F_UnitPrice,
                t.F_CostTotal,
                t.F_TaskState,
                t.F_IfMilestone,
                d.F_FullName as F_TaskDepartment,
                e.F_RealName as F_TaskLeader,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate,
                t.F_Attachments,
                t.F_Remarks
                ");
                strSql.Append(@" from DC_EngineProject_ProjectTasks t 

left join LR_Base_Department d on t.F_TaskDepartment=d.F_DepartmentId

left join  LR_Base_User e on t.F_TaskLeader=e.F_UserId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_PlannedStartDate >= @startTime AND t.F_PlannedStartDate <= @endTime ) ");
                }
                if (!queryParam["F_TaskItemNumber"].IsEmpty())
                {
                    dp.Add("F_TaskItemNumber", "%" + queryParam["F_TaskItemNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_TaskItemNumber Like @F_TaskItemNumber ");
                }
                if (!queryParam["F_TaskName"].IsEmpty())
                {
                    dp.Add("F_TaskName", "%" + queryParam["F_TaskName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_TaskName Like @F_TaskName ");
                }
                if (!queryParam["F_TaskState"].IsEmpty())
                {
                    dp.Add("F_TaskState", queryParam["F_TaskState"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_TaskState = @F_TaskState ");
                }
                if (!queryParam["TID"].IsEmpty())
                {
                    dp.Add("TID", queryParam["TID"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @TID ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_TaskState", "EProTaskState");
                dic.Add("F_IfMilestone", "YesOrNo"); 
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
                return dt;
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectTasksEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PTId,
                t.F_TaskItemNumber,
                t.F_TaskName,
                t.F_MeasurementUnit,
                t.F_ProjectQuantities,
                t.F_UnitPrice,
                t.F_CostTotal,
                t.F_TaskState,
                t.F_IfMilestone,
                t.F_TaskDepartment,
                t.F_TaskLeader,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate,
                t.F_Attachments,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectTasks t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_PlannedStartDate >= @startTime AND t.F_PlannedStartDate <= @endTime ) ");
                }
                if (!queryParam["F_TaskItemNumber"].IsEmpty())
                {
                    dp.Add("F_TaskItemNumber", "%" + queryParam["F_TaskItemNumber"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_TaskItemNumber Like @F_TaskItemNumber ");
                }
                if (!queryParam["F_TaskName"].IsEmpty())
                {
                    dp.Add("F_TaskName", "%" + queryParam["F_TaskName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_TaskName Like @F_TaskName ");
                }
                if (!queryParam["F_TaskState"].IsEmpty())
                {
                    dp.Add("F_TaskState", queryParam["F_TaskState"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_TaskState = @F_TaskState ");
                }
                if (!queryParam["TID"].IsEmpty())
                {
                    dp.Add("TID", queryParam["TID"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @TID ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectTasksEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_EngineProject_ProjectTasks表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectTasksEntity GetDC_EngineProject_ProjectTasksEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectTasksEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_EngineProject_ProjectTasksEntity>(t => t.F_PTId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectTasksEntity entity)
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

        public List<GanttEntity> GetGanttData(string keyValue)
        {
            Func<DateTime?, string> toGanttDateStr = time =>
            {
                if (time.HasValue)
                {
                    DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)).Date;
                    return "/Date(" + ((time.Value.Date - start.Date).TotalSeconds * 1000).ToString() + ")/";
                }
                return string.Empty;
            };
            Func<string, string> GetColor = state =>
            {
                switch (state)
                {
                    case "执行中": return "ganttBlue";
                    case "延期": return "ganttOrange";
                    case "暂停": return "ganttYellow";
                    case "终止": return "ganttRed";
                    case "已验收":
                    case "已结案": return "ganttGreen";
                    default:
                        return "ganttYellow";
                }
            };
            var list = this.BaseRepository().FindList<DC_EngineProject_ProjectTasksEntity>(c => c.F_PIId == keyValue&&c.F_PlannedEndDate.HasValue&&c.F_PlannedStartDate.HasValue);
            List<GanttEntity> result = new List<GanttEntity>();
            foreach (var item in list)
            {
                var entity = new GanttEntity()
                {
                    id = item.F_PTId,
                    desc = item.F_Remarks,
                    name = item.F_TaskName,
                    values = new List<GanttValue>()
                    {
                        new GanttValue()
                        {
                            label=item.F_TaskName,
                            customClass=GetColor(item.F_TaskState),
                            desc=item.F_Remarks,
                            from=toGanttDateStr(item.F_PlannedStartDate),
                            to=toGanttDateStr(item.F_PlannedEndDate),
                            dataObj=new GanttDataObj(item.F_PTId)
                        }
                    }
                };
                result.Add(entity);
            }
            return result;
        }
        #endregion

    }
}
