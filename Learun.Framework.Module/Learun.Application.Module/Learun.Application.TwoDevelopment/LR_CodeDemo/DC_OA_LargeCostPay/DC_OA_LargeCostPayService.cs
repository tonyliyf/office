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
    /// 日 期：2019-03-07 13:14
    /// 描 述：DC_OA_LargeCostPay
    /// </summary>
    public class DC_OA_LargeCostPayService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_LargeCostPayEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_LCPId,
                t.F_CustomerId
                ");
                strSql.Append("  FROM DC_OA_LargeCostPay t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_LargeCostPayEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_LargeCostPay表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_LargeCostPayEntity GetDC_OA_LargeCostPayEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_LargeCostPayEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_LargeCostPayEntity>(t => t.F_LCPId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_LargeCostPayEntity entity)
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


        public DataTable GetLargeCostPayData(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            string sql;
            var dp = new DynamicParameters(new { });
            if (!string.IsNullOrWhiteSpace(GroupBy))
            {
                if (GroupBy == "F_CreateDepartmentId")
                {
                    sql = @"select  (select F_FullName from LR_Base_Department where F_DepartmentId=F_CreateDepartmentId) as F_CreateDepartment, sum(F_Money) as [sum] " +
                        "from DC_OA_LargeCostPay where 1=1";
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        dp.Add("startTime", startDate.Value, DbType.DateTime);
                        dp.Add("endTime", endDate.Value, DbType.DateTime);
                        sql += " and F_CreateDate>=@startTime and F_CreateDate<=@endTime ";
                    }
                    sql += "group by " + GroupBy;
                }
                else
                {
                    sql = "select  " + GroupBy + ", sum(F_Money) as [sum] from DC_OA_LargeCostPay where 1=1";
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        dp.Add("startTime", startDate.Value, DbType.DateTime);
                        dp.Add("endTime", endDate.Value, DbType.DateTime);
                        sql += " and F_CreateDate>=@startTime and F_CreateDate<=@endTime ";
                    }
                    sql += "group by " + GroupBy;
                }
            }
            else
            {
                sql = @" select (  select top 1 F_FullName from LR_Base_Company where F_CompanyId=F_CompanyId) as F_Company
                    ,(select top 1 F_FullName from LR_Base_Department where F_DepartmentId=F_CreateDepartmentId) as F_CreateDepartment ,F_MoneyUse,
                    [F_CreateDate],[F_Money] from  DC_OA_LargeCostPay where 1=1";
                if (startDate.HasValue && endDate.HasValue)
                {
                    dp.Add("startTime", startDate.Value, DbType.DateTime);
                    dp.Add("endTime", endDate.Value, DbType.DateTime);
                    sql += " and F_CreateDate>=@startTime and F_CreateDate<=@endTime ";
                }
            }
         
            return this.BaseRepository().FindTable(sql, dp);
        }

        public DataTable GetLargeCostPayData1(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            string sql;
            var dp = new DynamicParameters(new { });
           
                    sql = @"select  F_FormerUnit as [type], sum(F_BuildingValue) as [money] from DC_ASSETS_BuildingBaseInfo  where 1=1 ";
                    //if (startDate.HasValue && endDate.HasValue)
                    //{
                    //    dp.Add("startTime", startDate.Value, DbType.DateTime);
                    //    dp.Add("endTime", endDate.Value, DbType.DateTime);
                    //    sql += " and F_CompletionTime>=@startTime and F_CompletionTime<=@endTime ";
                    //}
            sql += " GROUP BY F_FormerUnit";

         
            return this.BaseRepository().FindTable(sql, dp);
        }


        public DataTable GetLargeCostPayData2(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            //当前年份
            string year= DateTime.Now.Year.ToString(); ;
            string sql;
            var dp = new DynamicParameters(new { });

            sql = "select d.F_BillboardsName as name ,d.F_InstallationLocation as address,sum(b.F_money) as [money] from DC_ASSETS_BusStopBillboards d right outer join";
            sql += " (select * from DC_ASSETS_BusStopBillboardsMaintenanceRecords  where F_ApplicationDate like '%" + year + "%') b";
            sql += " on b.F_BSBId=d.F_BSBId    GROUP BY F_BillboardsName,F_InstallationLocation";

            return this.BaseRepository().FindTable(sql, dp);
        }
    }
}
