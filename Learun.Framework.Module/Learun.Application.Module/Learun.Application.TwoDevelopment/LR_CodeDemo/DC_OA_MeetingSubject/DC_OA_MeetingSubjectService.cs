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
    /// 日 期：2019-02-26 14:36
    /// 描 述：专题会议内容申请
    /// </summary>
    public class DC_OA_MeetingSubjectService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_MeetingSubjectId,
                t.F_CurrentCompanyId,
                t.F_CurrentDeptId,
                t.F_CreateUserId,
                t.F_CreateDate,
                t.F_Files,
                t.F_Content
                ");
                strSql.Append("  FROM DC_OA_MeetingSubject t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_CurrentCompanyId"].IsEmpty())
                {
                    dp.Add("F_CurrentCompanyId", queryParam["F_CurrentCompanyId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CurrentCompanyId = @F_CurrentCompanyId ");
                }
                if (!queryParam["F_CurrentDeptId"].IsEmpty())
                {
                    dp.Add("F_CurrentDeptId", queryParam["F_CurrentDeptId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CurrentDeptId = @F_CurrentDeptId ");
                }
                if (!queryParam["F_CreateUserId"].IsEmpty())
                {
                    dp.Add("F_CreateUserId", queryParam["F_CreateUserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateUserId = @F_CreateUserId ");
                }
                if (!queryParam["F_Content"].IsEmpty())
                {
                    dp.Add("F_Content", "%" + queryParam["F_Content"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Content Like @F_Content ");
                }
                return this.BaseRepository().FindList<DC_OA_MeetingSubjectEntity>(strSql.ToString(), dp, pagination);
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


        public IEnumerable<DC_OA_MeetingSubjectEntity> GetList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  t.F_MeetingSubjectId, t.F_Content as F_Content    FROM [DC_OA_MeetingSubject] t");

                strSql.Append("  WHERE is_agree ='2' ");

                // 虚拟参数

                return this.BaseRepository().FindList<DC_OA_MeetingSubjectEntity>(strSql.ToString());
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
        /// 获取DC_OA_MeetingSubject表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingSubjectEntity GetDC_OA_MeetingSubjectEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingSubjectEntity>(keyValue);
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
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingSubjectEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingSubjectEntity>(processId);
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
                this.BaseRepository().Delete<DC_OA_MeetingSubjectEntity>(t => t.F_MeetingSubjectId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_MeetingSubjectEntity entity)
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
