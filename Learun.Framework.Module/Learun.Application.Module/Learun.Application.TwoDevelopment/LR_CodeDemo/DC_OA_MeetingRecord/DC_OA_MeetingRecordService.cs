using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-17 11:09
    /// 描 述：DC_OA_MeetingRecord
    /// </summary>
    public class DC_OA_MeetingRecordService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_MRId,
                t.F_MeetingTheme,
                t.F_MRType,
                t.F_MeetingAddress,
                t.F_ConveningDepartment,
                t.F_Convenor,
                t.F_MeetingUnits,
                t.F_MeetingAttendee,
                t.F_MeetingHost,
                t.F_StartTime,
                t.F_EndTime,
                t.F_Duration,
                t.F_MeetingtOpics,
                t.F_MNId,
                t.F_MeetingContent
                ");
                strSql.Append("  FROM DC_OA_MeetingRecord t ");
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


                return this.BaseRepository().FindList<DC_OA_MeetingRecordEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_MeetingRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingRecordEntity GetDC_OA_MeetingRecordEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingRecordEntity>(keyValue);
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
        /// 获取DC_OA_MeetingRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingRecordEntity GetDeptNoticeEntity(string keyValue)
        {
            try
            {
                DeptNoticeEntity deptEntity = this.BaseRepository().FindEntity<DeptNoticeEntity>(keyValue);

                DC_OA_MeetingRecordEntity NUM = new DC_OA_MeetingRecordEntity();
                NUM.F_MeetingTheme = deptEntity.F_Title;
                NUM.F_Convenor = deptEntity.F_Applicant;
                NUM.F_ConveningDepartment = deptEntity.F_Dept;
                NUM.F_StartTime = deptEntity.F_StartDate;
                NUM.F_EndTime = deptEntity.F_EndDate;
                NUM.F_Attachments = deptEntity.F_File;

                return NUM;
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
                this.BaseRepository().Delete<DC_OA_MeetingRecordEntity>(t=>t.F_MRId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_MeetingRecordEntity entity)
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

    }
}
