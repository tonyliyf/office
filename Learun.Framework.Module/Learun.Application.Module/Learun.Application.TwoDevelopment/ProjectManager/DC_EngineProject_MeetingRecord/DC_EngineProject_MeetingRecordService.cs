using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 14:53
    /// 描 述：DC_EngineProject_MeetingRecord
    /// </summary>
    public class DC_EngineProject_MeetingRecordService : RepositoryFactory
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
                t.F_MRId,
                t.F_MeetingTheme,
                t.F_MRNum,
                t.F_MeetingAddress,
                d.F_FullName as F_ConveningDepartment,
                e.F_RealName as F_Convenor,
                t.F_MRType,
                t.F_MeetingHost,
                t.F_MeetingUnits,
                t.F_MeetingAttendee,
                t.F_StartTime,
                t.F_EndTime,
                t.F_Duration,
                t.F_MeetingtOpics,
                t.F_MeetingContent
                ");
                strSql.Append(@" from DC_EngineProject_MeetingRecord t 

left join LR_Base_Department d on t.F_CreateDepartmentId=d.F_DepartmentId

left join  LR_Base_User e on t.F_CreateUserid=e.F_UserId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_StartTime >= @startTime AND t.F_StartTime <= @endTime ) ");
                }
                if (!queryParam["F_MeetingTheme"].IsEmpty())
                {
                    dp.Add("F_MeetingTheme", "%" + queryParam["F_MeetingTheme"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MeetingTheme Like @F_MeetingTheme ");
                }
                if (!queryParam["F_ConveningDepartment"].IsEmpty())
                {
                    dp.Add("F_ConveningDepartment", queryParam["F_ConveningDepartment"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ConveningDepartment = @F_ConveningDepartment ");
                }
                if (!queryParam["F_Convenor"].IsEmpty())
                {
                    dp.Add("F_Convenor", queryParam["F_Convenor"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Convenor = @F_Convenor ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_MRType", "ConventionNum");     
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


        public DataTable GetMeetingRecordData()
        {
            try
            {
                var strSql = new StringBuilder();
       
                strSql.Append(@"
SELECT
	b.*,
	g.F_FolderId AS Attachments_FolderId 
FROM
	(
SELECT
	a.F_MeetingTheme,
	a.F_MRNum,
	a.F_MeetingAddress,
	c.F_FullName AS F_ConveningDepartment,
	b.F_RealName AS F_Convenor,
	a.F_MeetingHost,
	a.F_MeetingUnits,
	a.F_MeetingAttendee,
	a.F_StartTime,
	a.F_EndTime,
	a.F_Duration,
	a.F_MeetingtOpics,
	a.F_MeetingContent,
	a.F_ScenePictures,
	a.F_Attachments,
	j.F_ProjectName,
	a.F_PIId,
	f.F_FolderId AS ScenePictures_F_FolderId 
FROM
	DC_EngineProject_MeetingRecord a
	LEFT JOIN LR_Base_User b ON a.F_Convenor = b.F_UserId
	LEFT JOIN LR_Base_Department c ON c.F_DepartmentId = a.F_ConveningDepartment
	LEFT JOIN LR_Base_AnnexesFile f ON f.F_FolderId = a.F_ScenePictures
	LEFT JOIN DC_EngineProject_ProjectInfo j ON j.F_PIId= a.F_PIId 
	) b
	LEFT JOIN LR_Base_AnnexesFile g ON g.F_FolderId = b.F_Attachments 
ORDER BY
	b.F_StartTime DESC
                ");

              

                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
               
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
        /// 获取页面显示列表分页数据
        /// <summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_MeetingRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_MRId,
                t.F_MeetingTheme,
                t.F_MRNum,
                t.F_MeetingAddress,
                t.F_ConveningDepartment,
                t.F_Convenor,
                t.F_MRType,
                t.F_MeetingHost,
                t.F_MeetingUnits,
                t.F_MeetingAttendee,
                t.F_StartTime,
                t.F_EndTime,
                t.F_Duration,
                t.F_MeetingtOpics,
                t.F_MeetingContent,
                t.F_PIId
                ");
                strSql.Append("  FROM DC_EngineProject_MeetingRecord t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_StartTime >= @startTime AND t.F_StartTime <= @endTime ) ");
                }
                if (!queryParam["F_MeetingTheme"].IsEmpty())
                {
                    dp.Add("F_MeetingTheme", "%" + queryParam["F_MeetingTheme"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MeetingTheme Like @F_MeetingTheme ");
                }
                if (!queryParam["F_ConveningDepartment"].IsEmpty())
                {
                    dp.Add("F_ConveningDepartment",queryParam["F_ConveningDepartment"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ConveningDepartment = @F_ConveningDepartment ");
                }
                if (!queryParam["F_Convenor"].IsEmpty())
                {
                    dp.Add("F_Convenor",queryParam["F_Convenor"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Convenor = @F_Convenor ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_MeetingRecordEntity>(strSql.ToString(),dp, pagination);
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
        public IEnumerable<DC_EngineProject_MeetingRecordEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_MRId,
                t.F_MeetingTheme,
                t.F_MRNum,
                t.F_MeetingAddress,
                t.F_ConveningDepartment,
                t.F_Convenor,
                t.F_MRType,
                t.F_MeetingHost,
                t.F_MeetingUnits,
                t.F_MeetingAttendee,
                t.F_StartTime,
                t.F_EndTime,
                t.F_Duration,
                t.F_MeetingtOpics,
                t.F_MeetingContent
                ");
                strSql.Append("  FROM DC_EngineProject_MeetingRecord t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_StartTime >= @startTime AND t.F_StartTime <= @endTime ) ");
                }
                if (!queryParam["F_MeetingTheme"].IsEmpty())
                {
                    dp.Add("F_MeetingTheme", "%" + queryParam["F_MeetingTheme"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_MeetingTheme Like @F_MeetingTheme ");
                }
                if (!queryParam["F_ConveningDepartment"].IsEmpty())
                {
                    dp.Add("F_ConveningDepartment",queryParam["F_ConveningDepartment"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ConveningDepartment = @F_ConveningDepartment ");
                }
                if (!queryParam["F_Convenor"].IsEmpty())
                {
                    dp.Add("F_Convenor",queryParam["F_Convenor"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Convenor = @F_Convenor ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_MeetingRecordEntity>(strSql.ToString(),dp);
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
        /// 获取DC_EngineProject_MeetingRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_MeetingRecordEntity GetDC_EngineProject_MeetingRecordEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_MeetingRecordEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_EngineProject_MeetingRecordEntity>(t=>t.F_MRId == keyValue);
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
        public void SaveEntity( UserInfo userInfo, string keyValue, DC_EngineProject_MeetingRecordEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue,userInfo);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create(userInfo);
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

    }
}
