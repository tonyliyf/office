using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-16 11:14
    /// 描 述：DC_ASSETS_BusStopBillboardsMaintenanceRecords
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsMaintenanceRecordsService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_ASSETS_BusStopBillboardsMaintenanceRecordsService()
        {
            fieldSql= @"
                t.F_BSBMRId,
                d.F_BillboardsName as F_BSBId,
                t.F_MaintenanceNumber,
                b.F_FullName as  F_ApplicationDepartmentId,
                t.F_ApplicationDepartment,
                c.F_RealName as F_ApplicationUserId,
                t.F_ApplicationUser,
                t.F_ApplicationDate,
                t.F_FaultDescription,
                t.F_Remarks,
                t.F_CreateDepartmentId,
                t.F_CreateDepartment,
                t.F_CreateUserid,
                t.F_CreateUser,
                t.F_CreateDatetime,
                t.F_MaintenanceState,
                t.is_agree
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_ASSETS_BusStopBillboardsMaintenanceRecords t ");
                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity>(strSql.ToString());
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
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_ASSETS_BusStopBillboardsMaintenanceRecords t ");
                strSql.Append(" left join LR_Base_Department b on t.F_ApplicationDepartmentId = b.F_DepartmentId ");
                strSql.Append(" left join LR_Base_User c on t.F_ApplicationUserId = c.F_UserId ");
                
                strSql.Append(" left join DC_ASSETS_BusStopBillboards d on t.F_BSBId = d.F_BSBId ");

                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_ApplicationDate >= @StartTime AND t.F_ApplicationDate <= @EndTime ) ");
                }
                //申请人
                if (!queryParam["F_ApplicationUserId"].IsEmpty())
                {
                    dp.Add("F_ApplicationUserId", "%" + queryParam["F_ApplicationUserId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ApplicationUserId Like @F_ApplicationUserId ");
                }
                //申请部门
                if (!queryParam["F_ApplicationDepartmentId"].IsEmpty())
                {
                    dp.Add("F_ApplicationDepartmentId", "%" + queryParam["F_ApplicationDepartmentId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ApplicationDepartmentId Like @F_ApplicationDepartmentId ");
                }

                return this.BaseRepository().FindList<DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity>(strSql.ToString(), dp, pagination);
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
        public DataTable ExportData(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_ASSETS_BusStopBillboardsMaintenanceRecords t ");
                strSql.Append(" left join LR_Base_Department b on t.F_ApplicationDepartmentId = b.F_DepartmentId ");
                strSql.Append(" left join LR_Base_User c on t.F_ApplicationUserId = c.F_UserId ");

                strSql.Append(" left join DC_ASSETS_BusStopBillboards d on t.F_BSBId = d.F_BSBId ");

                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_ApplicationDate >= @StartTime AND t.F_ApplicationDate <= @EndTime ) ");
                }
                //申请人
                if (!queryParam["F_ApplicationUserId"].IsEmpty())
                {
                    dp.Add("F_ApplicationUserId", "%" + queryParam["F_ApplicationUserId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ApplicationUserId Like @F_ApplicationUserId ");
                }
                //申请部门
                if (!queryParam["F_ApplicationDepartmentId"].IsEmpty())
                {
                    dp.Add("F_ApplicationDepartmentId", "%" + queryParam["F_ApplicationDepartmentId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ApplicationDepartmentId Like @F_ApplicationDepartmentId ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_MaintenanceState", "MaintenanceState");
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
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity>(t=>t.F_BSBMRId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity entity)
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
