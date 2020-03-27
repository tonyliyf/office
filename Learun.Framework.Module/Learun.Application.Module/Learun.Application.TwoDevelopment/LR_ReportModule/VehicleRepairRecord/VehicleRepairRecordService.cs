using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_ReportModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-28 15:06
    /// 描 述：维修车辆统计报表
    /// </summary>
    public class VehicleRepairRecordService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_VehicleRepairRecordEntity> GetPageList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_VehicleRepairName,
				v.F_VehicleName as F_VehicleRefId,
                t.F_license,
                t.F_driver,
                t.F_breakdownType,
                t.F_breakdown,
                t.F_VehicleLocation,
                t.F_VehicleStartDate,
                t.F_VehicleEndDate,
                t.F_Startdate,
                t.F_VehicleRepairReason,	 
                t.F_VehiclePlace,
                t.F_VehicleRepairNo,
                t.F_VehicleRepairMoney,
                t.F_ReplyId,
                t.F_Money,
                c.F_FullName as F_CompanyId,              
                d.F_FullName as F_DeptId
                ");                   
                strSql.Append("  FROM DC_OA_VehicleRepairRecord t ");
                strSql.Append("  left join DC_OA_Vehicle V on v.F_VehicleId=t.F_VehicleRefId");
                strSql.Append("  left join LR_Base_Department d  on t.F_DeptId =d.F_DepartmentId"); 
                strSql.Append("  left join LR_Base_Company c  on t.F_CompanyId =c.F_CompanyId");
                strSql.Append("  WHERE t.Is_agree=2 ");
                var queryParam = queryJson.ToJObject();

                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.datetime >= @StartTime AND t.datetime <= @EndTime ) ");
                }
                //申请人
                if (!queryParam["F_ReplyId"].IsEmpty())
                {
                    dp.Add("F_ReplyId", "%" + queryParam["F_ReplyId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ReplyId Like @F_ReplyId ");
                }
                //申请公司
                if (!queryParam["F_CompanyId"].IsEmpty())
                {
                    dp.Add("F_CompanyId", "%" + queryParam["F_CompanyId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_CompanyId Like @F_CompanyId ");
                }
                //申请部门
                if (!queryParam["F_DeptId"].IsEmpty())
                {
                    dp.Add("F_DeptId", "%" + queryParam["F_DeptId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DeptId Like @F_DeptId ");
                }

                return this.BaseRepository().FindList<DC_OA_VehicleRepairRecordEntity>(strSql.ToString(),dp);
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
        /// 获取DC_OA_VehicleRepairRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_VehicleRepairRecordEntity GetDC_OA_VehicleRepairRecordEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("WFDB").FindEntity<DC_OA_VehicleRepairRecordEntity>(keyValue);
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
                this.BaseRepository("WFDB").Delete<DC_OA_VehicleRepairRecordEntity>(t=>t.F_VehicleRepairId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_VehicleRepairRecordEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("WFDB").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("WFDB").Insert(entity);
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
