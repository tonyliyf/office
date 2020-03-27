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
    /// 日 期：2019-04-25 15:22
    /// 描 述：DC_EngineProject_ConstructionRecord
    /// </summary>
    public class DC_EngineProject_ConstructionRecordService : RepositoryFactory
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
                t.F_EPCRId,
                f.F_ProjectName as F_PIId,
                t.F_SafetyCivilizationEvaluation,
                t.F_QualityEvaluation,
                t.F_SafetyCivilizationInfo,
                t.F_QualityInfo,
                t.F_LaborNumber,
                t.F_LaborInfo,
                t.F_SupervisorsComeInfo,
                t.F_ConstructorComeInfo,
                t.F_ProjectOwnerComeInfo
                ");
                strSql.Append(@" from DC_EngineProject_ConstructionRecord t 
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
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_SafetyCivilizationEvaluation", "F_SafetyCivilizationEvaluation");
                dic.Add("F_QualityEvaluation", "F_QualityEvaluation");
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
        public IEnumerable<DC_EngineProject_ConstructionRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EPCRId,
                t.F_PIId,
                t.F_SafetyCivilizationEvaluation,
                t.F_QualityEvaluation,
                t.F_SafetyCivilizationInfo,
                t.F_QualityInfo,
                t.F_LaborNumber,
                t.F_LaborInfo,
                t.F_SupervisorsComeInfo,
                t.F_ConstructorComeInfo,
                t.F_ProjectOwnerComeInfo
                ");
                strSql.Append("  FROM DC_EngineProject_ConstructionRecord t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId",queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ConstructionRecordEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_EngineProject_ConstructionRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ConstructionRecordEntity GetDC_EngineProject_ConstructionRecordEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ConstructionRecordEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_EngineProject_ConstructionRecordEntity>(t=>t.F_EPCRId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ConstructionRecordEntity entity)
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
