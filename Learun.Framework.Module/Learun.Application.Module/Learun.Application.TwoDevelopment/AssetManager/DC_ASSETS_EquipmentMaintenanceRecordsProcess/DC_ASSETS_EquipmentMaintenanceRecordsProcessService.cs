using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-18 17:47
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecordsProcess
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenanceRecordsProcessService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity> GetPageList(Pagination pagination, string queryJson, string PID)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_EMRPId,
                t.F_MaintenanceLevel,
                t.F_FaultClassification,
                t.F_MaintenanceDepartmentId,
                t.F_MaintenanceUserId,
                t.F_MaintenanceCosts,
                t.F_MaintenanceDate,
                t.F_FaultAnalysis,
                t.F_MaintenanceInstructions
                ");
                strSql.Append("  FROM DC_ASSETS_EquipmentMaintenanceRecordsProcess t ");
                strSql.Append("  WHERE t.F_EMRId=@F_EMRId ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_EMRId", PID, DbType.String);
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_MaintenanceDate >= @startTime AND t.F_MaintenanceDate <= @endTime ) ");
                }
                if (!queryParam["F_MaintenanceLevel"].IsEmpty())
                {
                    dp.Add("F_MaintenanceLevel", queryParam["F_MaintenanceLevel"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_MaintenanceLevel = @F_MaintenanceLevel ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_ASSETS_EquipmentMaintenancePartsUse表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<PartUseModel> GetDC_ASSETS_EquipmentMaintenancePartsUseList(string keyValue)
        {
            try
            {
                //return this.BaseRepository().FindList<DC_ASSETS_EquipmentMaintenancePartsUseEntity>(t=>t.F_EMRPId == keyValue );
                string sql = @"  select t2.F_PartsName as name,t2.F_SpecificationType as type,t2.F_PartsCode as code,t2.F_EPIId,t1.F_UseNumber,t1.F_UnitPrice,t1.F_AccountCosts
                                  from DC_ASSETS_EquipmentMaintenancePartsUse t1,DC_ASSETS_EquipmentPartsInfo t2
                                  where t1.F_EPIId=t2.F_EPIId and t1.F_EMRPId=@F_EMRPId";
                var dp = new DynamicParameters(new { F_EMRPId = keyValue });
                return this.BaseRepository().FindList<PartUseModel>(sql, dp);
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
        /// 获取DC_ASSETS_EquipmentMaintenanceRecordsProcess表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity>(keyValue);
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
        /// 获取DC_ASSETS_EquipmentMaintenancePartsUse表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentMaintenancePartsUseEntity GetDC_ASSETS_EquipmentMaintenancePartsUseEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentMaintenancePartsUseEntity>(t => t.F_EMRPId == keyValue);
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
                var dC_ASSETS_EquipmentMaintenanceRecordsProcessEntity = GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(keyValue);
                db.Delete<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity>(t => t.F_EMRPId == keyValue);
                db.Delete<DC_ASSETS_EquipmentMaintenancePartsUseEntity>(t => t.F_EMRPId == dC_ASSETS_EquipmentMaintenanceRecordsProcessEntity.F_EMRPId);
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
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity entity, List<DC_ASSETS_EquipmentMaintenancePartsUseEntity> dC_ASSETS_EquipmentMaintenancePartsUseList, string PID)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_ASSETS_EquipmentMaintenanceRecordsProcessEntityTmp = GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_ASSETS_EquipmentMaintenancePartsUseEntity>(t => t.F_EMRPId == dC_ASSETS_EquipmentMaintenanceRecordsProcessEntityTmp.F_EMRPId);
                    foreach (DC_ASSETS_EquipmentMaintenancePartsUseEntity item in dC_ASSETS_EquipmentMaintenancePartsUseList)
                    {
                        item.Create();
                        item.F_EMRPId = dC_ASSETS_EquipmentMaintenanceRecordsProcessEntityTmp.F_EMRPId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    entity.F_EMRId = PID;
                    db.Insert(entity);
                    foreach (DC_ASSETS_EquipmentMaintenancePartsUseEntity item in dC_ASSETS_EquipmentMaintenancePartsUseList)
                    {
                        item.Create();
                        item.F_EMRPId = entity.F_EMRPId;
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
