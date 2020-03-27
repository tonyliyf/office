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
    /// 日 期：2019-03-21 11:44
    /// 描 述：DC_EngineProject_ProjectPersonRiskControl
    /// </summary>
    public class DC_EngineProject_ProjectPersonRiskControlService : RepositoryFactory
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
                t.F_PPRCId,
                f.F_ProjectName as F_PIId,
                d.F_FullName as F_PPRCDepartment,
                t.F_PPRCUser,
                t.F_PPRCPost,
                t.F_PPRCDuty,
                t.F_PCRCDate,
                t.F_MainFunctions,
                t.F_RiskControlMeasures,
                t.F_ChargeOpinion
                ");
                strSql.Append(@" from DC_EngineProject_ProjectPersonRiskControl t 

left join LR_Base_Department d on t.F_PPRCDepartment=d.F_DepartmentId

left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
               
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
              
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
        public IEnumerable<DC_EngineProject_ProjectPersonRiskControlEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PPRCId,
                t.F_PIId,
                t.F_PPRCDepartment,
                t.F_PPRCUser,
                t.F_PPRCPost,
                t.F_PPRCDuty,
                t.F_PCRCDate,
                t.F_MainFunctions,
                t.F_RiskControlMeasures,
                t.F_ChargeOpinion
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectPersonRiskControl t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_EngineProject_ProjectPersonRiskControlEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_EngineProject_ProjectPersonRiskControlAssessment表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity> GetDC_EngineProject_ProjectPersonRiskControlAssessmentList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity>(t=>t.F_PPRCId == keyValue );
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
        /// 获取DC_EngineProject_ProjectPersonRiskControl表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectPersonRiskControlEntity GetDC_EngineProject_ProjectPersonRiskControlEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectPersonRiskControlEntity>(keyValue);
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
        /// 获取DC_EngineProject_ProjectPersonRiskControlAssessment表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectPersonRiskControlAssessmentEntity GetDC_EngineProject_ProjectPersonRiskControlAssessmentEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity>(t=>t.F_PPRCId == keyValue);
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
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var dC_EngineProject_ProjectPersonRiskControlEntity = GetDC_EngineProject_ProjectPersonRiskControlEntity(keyValue); 
                db.Delete<DC_EngineProject_ProjectPersonRiskControlEntity>(t=>t.F_PPRCId == keyValue);
                db.Delete<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity>(t=>t.F_PPRCId == dC_EngineProject_ProjectPersonRiskControlEntity.F_PPRCId);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectPersonRiskControlEntity entity,List<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity> dC_EngineProject_ProjectPersonRiskControlAssessmentList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_EngineProject_ProjectPersonRiskControlEntityTmp = GetDC_EngineProject_ProjectPersonRiskControlEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_EngineProject_ProjectPersonRiskControlAssessmentEntity>(t=>t.F_PPRCId == dC_EngineProject_ProjectPersonRiskControlEntityTmp.F_PPRCId);
                    foreach (DC_EngineProject_ProjectPersonRiskControlAssessmentEntity item in dC_EngineProject_ProjectPersonRiskControlAssessmentList)
                    {
                        item.Create();
                        item.F_PPRCId = dC_EngineProject_ProjectPersonRiskControlEntityTmp.F_PPRCId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_EngineProject_ProjectPersonRiskControlAssessmentEntity item in dC_EngineProject_ProjectPersonRiskControlAssessmentList)
                    {
                        item.Create();
                        item.F_PPRCId = entity.F_PPRCId;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
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
