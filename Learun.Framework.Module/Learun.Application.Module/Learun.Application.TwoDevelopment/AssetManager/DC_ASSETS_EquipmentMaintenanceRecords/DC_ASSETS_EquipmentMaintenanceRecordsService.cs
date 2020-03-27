using Dapper;
using Learun.Application.Organization;
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
    /// 日 期：2019-02-18 11:10
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecords
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenanceRecordsService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentMaintenanceRecordsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                       t1.[F_EMRId]
                      ,t1.[F_EIId]
                      ,t1.[F_MaintenanceNumber]
                      ,t1.[F_ApplicationDepartmentId]
                      ,t1.[F_ApplicationDepartment]
                      ,t1.[F_ApplicationUserId]
                      ,t1.[F_ApplicationUser]
                      ,t1.[F_ApplicationDate]
                      ,t1.[F_FaultDescription]
                      ,t1.[F_Remarks]
                      ,t1.[维修状态] as State
	                  ,t2.F_EquipmentNumber as F_CreateUser
	                  ,t2.F_SpecificationType asF_CreateDatetime
                    ");
                strSql.Append("from [DC_ASSETS_EquipmentMaintenanceRecords] t1,[dbo].[DC_ASSETS_EquipmentInfo] t2 ");
                strSql.Append("  where t1.F_EIId=t2.F_EIId and t1.[维修状态]!=0 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ApplicationUserId"].IsEmpty())
                {
                    dp.Add("F_ApplicationUserId", queryParam["F_ApplicationUserId"].ToString(), DbType.String);
                    strSql.Append(" AND t1.F_ApplicationUserId = @F_ApplicationUserId ");
                }
                if (!queryParam["F_ApplicationDate"].IsEmpty())
                {
                    dp.Add("F_ApplicationDate", queryParam["F_ApplicationDate"].ToString(), DbType.String);
                    strSql.Append(" AND t1.F_ApplicationDate = @F_ApplicationDate ");
                }
                if (!queryParam["F_EIId"].IsEmpty())
                {
                    dp.Add("F_EIId", "%" + queryParam["F_EIId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t1.F_EIId Like @F_EIId ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_EquipmentMaintenanceRecordsEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_ASSETS_EquipmentMaintenanceRecords表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentMaintenanceRecordsEntity GetDC_ASSETS_EquipmentMaintenanceRecordsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentMaintenanceRecordsEntity>(keyValue);
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
        public DC_ASSETS_EquipmentMaintenanceRecordsEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_EquipmentMaintenanceRecordsEntity>(t => t.F_EMRId == processId);
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
                this.BaseRepository().Delete<DC_ASSETS_EquipmentMaintenanceRecordsEntity>(t => t.F_EMRId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentMaintenanceRecordsEntity entity)
        {
            try
            {
                var user = base.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == entity.F_ApplicationUserId);
                entity.F_ApplicationUser = user.F_RealName;
                entity.F_ApplicationDepartmentId = user.F_DepartmentId;
                if (user != null)
                {
                    var department = base.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == user.F_DepartmentId);
                    if (department != null)
                    {
                        entity.F_ApplicationDepartment = department.F_FullName;
                    }
                }
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

        public void DoComplete(string keyValue)
        {
            var entity = this.BaseRepository().FindEntity<DC_ASSETS_EquipmentMaintenanceRecordsEntity>(keyValue);
            if (entity != null)
            {
                entity.State = 2;
                this.BaseRepository().Update(entity);
            }
        }

        #endregion

    }
}
