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
    /// 日 期：2019-04-25 17:27
    /// 描 述：DC_EngineProject_ConstructionRecordMonth
    /// </summary>
    public class DC_EngineProject_ConstructionRecordMonthService : RepositoryFactory
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
                t.F_EPCRMId,
                f.F_ProjectName as F_PIId,
                t.F_Month,
                t.F_InvestmentCompletion,
                t.F_InvestmentRatio,
                t.F_CostControlInfo,
                t.F_ContractName,
                t.F_ContractPerformanceEvaluation,
                t.F_ContractPerformanceInfo
                ");
                strSql.Append(@" from DC_EngineProject_ConstructionRecordMonth t 
left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
                if (!queryParam["F_Month"].IsEmpty())
                {
                    dp.Add("F_Month", queryParam["F_Month"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Month = @F_Month ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_Month", "years");
                dic.Add("F_ContractPerformanceEvaluation", "ContractPerformanceEvaluation");
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
        public IEnumerable<DC_EngineProject_ConstructionRecordMonthEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EPCRMId,
                t.F_PIId,
                t.F_Month,
                t.F_InvestmentCompletion,
                t.F_InvestmentRatio,
                t.F_CostControlInfo,
                t.F_ContractName,
                t.F_ContractPerformanceEvaluation,
                t.F_ContractPerformanceInfo
                ");
                strSql.Append("  FROM DC_EngineProject_ConstructionRecordMonth t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId",queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
                if (!queryParam["F_Month"].IsEmpty())
                {
                    dp.Add("F_Month",queryParam["F_Month"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Month = @F_Month ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ConstructionRecordMonthEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_EngineProject_ConstructionRecordMonth表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ConstructionRecordMonthEntity GetDC_EngineProject_ConstructionRecordMonthEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ConstructionRecordMonthEntity>(keyValue);
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
        /// 获取DC_EngineProject_ConstructionRecordMonth表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            try
            {
                string sql = " select F_PICId as value,F_ContractName as text from DC_EngineProject_ProjectInfoContract";
                return this.BaseRepository().FindTable(sql);
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
                this.BaseRepository().Delete<DC_EngineProject_ConstructionRecordMonthEntity>(t=>t.F_EPCRMId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ConstructionRecordMonthEntity entity)
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
