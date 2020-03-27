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
    /// 日 期：2019-02-06 16:45
    /// 描 述：DC_OA_PurchaseDeposit
    /// </summary>
    public class DC_OA_PurchaseDepositService : RepositoryFactory
    {
        #region 获取数据



       public DataTable GetList(Pagination pagination, string queryJson)
        {
        
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
               t.f_purchasename,
               t.f_purchaseprojectno,
               t.f_currentcompanyid,
               t.f_currentdeptid,
               t.f_depositmoney,
               t.F_PurchaseDepositId
                ");
                strSql.Append("  FROM DC_OA_PurchaseDeposit t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindTable(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_OA_PurchaseDepositEntity> GetPageList(Pagination pagination, string queryJson,string isPower)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PurchaseDepositId,
                t.F_PurchaseName,
                t.F_PurchaseProjectNo,
                t.F_CurrentCompanyId,
                t.F_CurrentDeptId,
                t.F_DepositMoney
                ");
                strSql.Append("  FROM DC_OA_PurchaseDeposit t where t.is_agree =2 ");
                if (!isPower.IsEmpty())
                {
                    if (user.F_Level == 1)
                    {
                        strSql.Append(string.Format(" and  t.F_CreateUserId = '{0}'", user.userId));

                    }
                    else if (user.F_Level == 2)
                    {
                        strSql.Append(string.Format(" and  t.F_CurrentDeptId = '{0}'", user.departmentId));
                    }
                    else if (user.F_Level == 3)
                    {
                        strSql.Append(string.Format(" and  t.F_CurrentCompanyId = '{0}'", user.companyId));
                    }
                }
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_PurchaseDepositEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_PurchaseDepositDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_PurchaseDepositDetailEntity> GetDC_OA_PurchaseDepositDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_PurchaseDepositDetailEntity>(t => t.F_PurchaseDepositRefId == keyValue);
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
        /// 获取DC_OA_PurchaseDeposit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PurchaseDepositEntity GetDC_OA_PurchaseDepositEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PurchaseDepositEntity>(keyValue);
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
        /// 获取DC_OA_PurchaseDepositDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PurchaseDepositDetailEntity GetDC_OA_PurchaseDepositDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PurchaseDepositDetailEntity>(t => t.F_PurchaseDepositRefId == keyValue);
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
                var dC_OA_PurchaseDepositEntity = GetDC_OA_PurchaseDepositEntity(keyValue);
                db.Delete<DC_OA_PurchaseDepositEntity>(t => t.F_PurchaseDepositId == keyValue);
                db.Delete<DC_OA_PurchaseDepositDetailEntity>(t => t.F_PurchaseDepositRefId == dC_OA_PurchaseDepositEntity.F_PurchaseDepositId);
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
        public void SaveEntity(string keyValue, DC_OA_PurchaseDepositEntity entity, List<DC_OA_PurchaseDepositDetailEntity> dC_OA_PurchaseDepositDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_PurchaseDepositEntityTmp = GetDC_OA_PurchaseDepositEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_OA_PurchaseDepositDetailEntity>(t => t.F_PurchaseDepositRefId == dC_OA_PurchaseDepositEntityTmp.F_PurchaseDepositId);
                    foreach (DC_OA_PurchaseDepositDetailEntity item in dC_OA_PurchaseDepositDetailList)
                    {
                        item.Create();
                        item.F_PurchaseDepositRefId = dC_OA_PurchaseDepositEntityTmp.F_PurchaseDepositId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_OA_PurchaseDepositDetailEntity item in dC_OA_PurchaseDepositDetailList)
                    {
                        item.Create();
                        item.F_PurchaseDepositRefId = entity.F_PurchaseDepositId;
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
        public DataTable GetEntityEx(string keyValue)
        {
            string sql = @" select (select top 1 F_FullName from LR_Base_Department where F_DepartmentId=t.F_CurrentDeptId) as [department],
                                t.[F_PurchaseProjectNo] as [projectno],
                                t.[F_PurchaseName] as [projectname],
                                round(t.[F_DepositMoney],2) as [money]
                                from [DC_OA_PurchaseDeposit] t where t.F_PurchaseDepositId=@F_PurchaseDepositId";
            return this.BaseRepository().FindTable(sql, new { F_PurchaseDepositId = keyValue });
        }
        public DataTable GetListEntityEx(string keyValue)
        {
            string sql = @"   select 
                          (select top 1 F_UnitName from [DC_ASSETS_ContactUnit] where F_CUId=t.F_OrganizeId) as [name],
                          round(t.F_money,2) as [money],
                          case  when t.F_ISReturn=1 then '是' else '否' end as [yesorno],
                          t.F_NoReason as [reason]
                          from DC_OA_PurchaseDepositDetail t where t.F_PurchaseDepositRefId=@F_PurchaseDepositRefId";
            return this.BaseRepository().FindTable(sql, new { F_PurchaseDepositRefId = keyValue });
        }
    }
}
