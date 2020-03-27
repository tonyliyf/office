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
    /// 日 期：2019-03-04 18:21
    /// 描 述：DC_OA_AppropriationApprove
    /// </summary>
    public class DC_OA_AppropriationApproveService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_AppropriationApproveEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_AAId,
                t.F_AppropriationCompanyId
                ");
                strSql.Append("  FROM DC_OA_AppropriationApprove t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_AppropriationCompanyId"].IsEmpty())
                {
                    dp.Add("F_AppropriationCompanyId", "%" + queryParam["F_AppropriationCompanyId"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_AppropriationCompanyId Like @F_AppropriationCompanyId ");
                }
                return this.BaseRepository().FindList<DC_OA_AppropriationApproveEntity>(strSql.ToString(), dp);
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
        /// 获取DC_OA_AppropriationApprove表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_AppropriationApproveEntity GetDC_OA_AppropriationApproveEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_AppropriationApproveEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_AppropriationApproveEntity>(t => t.F_AAId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_AppropriationApproveEntity entity)
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

        public DataTable GetAppropriationApproveData(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            string sql;
            var dp = new DynamicParameters(new { });
            if (!string.IsNullOrWhiteSpace(GroupBy))
            {
                if (GroupBy == "F_CreateDepartmentId")
                {
                    sql = "select  (select F_FullName from LR_Base_Department where F_DepartmentId=F_CreateDepartmentId) as F_CreateDepartment, sum(F_ApproveMoney) as [sum] from DC_OA_AppropriationApprove where 1=1";
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
                    sql = "select  " + GroupBy + ", sum(F_ApproveMoney) as [sum] from DC_OA_AppropriationApprove where 1=1";
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
                sql = @" select [F_CostTypeId] ,(  select F_FullName from LR_Base_Company where F_CompanyId=F_AppropriationCompanyId) as F_AppropriationCompany
                    ,(select F_FullName from LR_Base_Department where F_DepartmentId=F_CreateDepartmentId) as F_CreateDepartment ,
                    [F_AAName],[F_CreateDate],[F_ApproveMoney] from  DC_OA_AppropriationApprove where 1=1";
                if (startDate.HasValue && endDate.HasValue)
                {
                    dp.Add("startTime", startDate.Value, DbType.DateTime);
                    dp.Add("endTime", endDate.Value, DbType.DateTime);
                    sql += " and F_CreateDate>=@startTime and F_CreateDate<=@endTime ";
                }
            }
            return this.BaseRepository().FindTable(sql, dp);
        }
        #endregion

    }
}
