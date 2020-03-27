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
    /// 日 期：2019-03-12 12:57
    /// 描 述：DC_OA_PerformanceUserWorkInterview
    /// </summary>
    public class DC_OA_PerformanceUserWorkInterviewService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceUserWorkInterviewEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PUWIId,
                t.F_BeInterviewDepartment,
                t.F_BeInterviewUser,
                t.F_BeInterviewPost,
                t.F_InterviewUser,
                t.F_InterviewDate,
                t.F_InterviewAddress,
                t.F_InterviewContentA,
                t.F_InterviewContentB,
                t.F_InterviewContentC,
                t.F_InterviewContentD
                ");
                strSql.Append("  FROM DC_OA_PerformanceUserWorkInterview t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_InterviewDate >= @startTime AND t.F_InterviewDate <= @endTime ) ");
                }
                if (!queryParam["F_BeInterviewDepartment"].IsEmpty())
                {
                    dp.Add("F_BeInterviewDepartment", queryParam["F_BeInterviewDepartment"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BeInterviewDepartment = @F_BeInterviewDepartment ");
                }
                if (!queryParam["F_BeInterviewUser"].IsEmpty())
                {
                    dp.Add("F_BeInterviewUser", queryParam["F_BeInterviewUser"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_BeInterviewUser = @F_BeInterviewUser ");
                }
                if (!queryParam["F_InterviewUser"].IsEmpty())
                {
                    dp.Add("F_InterviewUser", queryParam["F_InterviewUser"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_InterviewUser = @F_InterviewUser ");
                }
                
                return this.BaseRepository().FindList<DC_OA_PerformanceUserWorkInterviewEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_PerformanceUserWorkInterview表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceUserWorkInterviewEntity GetDC_OA_PerformanceUserWorkInterviewEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkInterviewEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PerformanceUserWorkInterviewEntity>(t => t.F_PUWIId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkInterviewEntity entity)
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
        public void Execute(string cid, int r, string advice = "")
        {
            string sql;
            switch (r)
            {
                //被面谈人确认
                case 1:
                    sql = "update DC_OA_PerformanceUserWorkInterview set F_IfBeInterviewConfirm=1,F_BeInterviewConfirmDate=getdate() where F_PUWIId = '"
                        +cid+"'";
                    break;
                //面谈人确认
                case 2:
                    sql = "update DC_OA_PerformanceUserWorkInterview set F_IfInterviewConfirm=1,F_IfInterviewConfirmDate=getdate() where F_PUWIId = '"
                        + cid + "'";
                    break;
                //考核办意见
                case 3:
                    sql = "update DC_OA_PerformanceUserWorkInterview set F_ExamineOpinion='"+advice+"' where F_PUWIId = '"+cid+"'";
                    break;
                default:
                    return;
            }
            this.BaseRepository().ExecuteBySql(sql);
        }

    }
}
