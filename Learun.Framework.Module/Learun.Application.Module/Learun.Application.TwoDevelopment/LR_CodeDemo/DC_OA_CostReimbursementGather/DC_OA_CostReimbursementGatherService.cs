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
    /// 日 期：2019-02-26 21:30
    /// 描 述：DC_OA_CostReimbursementGather
    /// </summary>
    public class DC_OA_CostReimbursementGatherService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public DC_OA_CostReimbursementGatherService()
        {
            fieldSql = @"
                t.F_CRGId,
                t.F_CostTypeId,
                t.F_CostTypeName,
                t.F_ReimbursementCompanyId,
                t.F_ReimbursementCompany,
                t.F_ReimbursementDepartmentId,
                t.F_ReimbursementDepartment,
                t.F_ReimbursementDate,
                t.F_BillsNUM,
                t.F_AttachmentsNUM,
                t.F_REimbursementContent,
                t.F_ReimbursementMoney,
                t.F_Attachments,
                t.F_CreateDepartmentId,
                t.F_CreateDepartment,
                t.F_CreateUserId,
                t.F_CreateUser,
                t.F_CreateDate,
                t.F_FlowId,
                t.F_FlowState,
                t.F_HandleUserId,
                t.F_HandleUser,
                t.Is_agree
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_CostReimbursementGatherEntity> GetList(string queryJson)
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
                strSql.Append(" FROM DC_OA_CostReimbursementGather t ");
                return this.BaseRepository().FindList<DC_OA_CostReimbursementGatherEntity>(strSql.ToString());
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
        public IEnumerable<DC_OA_CostReimbursementGatherEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM DC_OA_CostReimbursementGather t ");
                return this.BaseRepository().FindList<DC_OA_CostReimbursementGatherEntity>(strSql.ToString(), pagination);
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
        public DC_OA_CostReimbursementGatherEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_CostReimbursementGatherEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_CostReimbursementGatherEntity>(t => t.F_CRGId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_CostReimbursementGatherEntity entity)
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
        public DataTable GetCostReimbursementGatherData(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            string sql;
            var dp = new DynamicParameters(new { });
            if (!string.IsNullOrWhiteSpace(GroupBy))
            {
                if (GroupBy == "F_CreateDepartmentId")
                {
                    sql = "select  (select F_FullName from LR_Base_Department where F_DepartmentId=F_CreateDepartmentId) as F_CreateDepartment, sum(F_ReimbursementMoney) as [sum] from DC_OA_CostReimbursementGather where 1=1";
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
                    sql = "select  " + GroupBy + ", sum(F_ReimbursementMoney) as [sum] from DC_OA_CostReimbursementGather where 1=1";
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
                sql = @" select [F_CostTypeId] ,(  select F_FullName from LR_Base_Company where F_CompanyId=F_ReimbursementCompanyId) as F_ReimbursementCompany,
                        (select F_FullName from LR_Base_Department where F_DepartmentId=F_CreateDepartmentId) as F_CreateDepartment
                        ,[F_REimbursementContent],[F_CreateDate],[F_ReimbursementMoney] from  DC_OA_CostReimbursementGather where 1=1";
                if (startDate.HasValue && endDate.HasValue)
                {
                    dp.Add("startTime", startDate.Value, DbType.DateTime);
                    dp.Add("endTime", endDate.Value, DbType.DateTime);
                    sql += " and F_CreateDate>=@startTime and F_CreateDate<=@endTime ";
                }
            }
            return this.BaseRepository().FindTable(sql, dp);
        }
    }
}
