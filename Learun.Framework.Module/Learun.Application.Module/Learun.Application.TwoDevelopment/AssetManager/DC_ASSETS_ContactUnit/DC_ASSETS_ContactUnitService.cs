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
    /// 日 期：2019-02-13 10:08
    /// 描 述：DC_ASSETS_ContactUnit
    /// </summary>
    public class DC_ASSETS_ContactUnitService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_ContactUnitEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_CUId,
                t.F_UnitName,
                t.F_UnitCode,
                t.F_UnitType,
                t.F_Contacts,
                t.F_ContactPhone,
                t.F_ContactFax,
                t.F_PostCode,
                t.F_ContactEmail,
                t.F_ContactAddress,
                t.F_DutyNumber,
                t.F_DepositBank,
                t.F_ContactAccount,
                t.F_Remarks,
                t.F_UseState
                ");
                strSql.Append("  FROM DC_ASSETS_ContactUnit t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_UnitType"].IsEmpty())
                {
                    dp.Add("F_UnitType",queryParam["F_UnitType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UnitType = @F_UnitType ");
                }
                if (!queryParam["F_UnitName"].IsEmpty())
                {
                    dp.Add("F_UnitName", "%" + queryParam["F_UnitName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UnitName Like @F_UnitName ");
                }
                if (!queryParam["F_UnitCode"].IsEmpty())
                {
                    dp.Add("F_UnitCode", "%" + queryParam["F_UnitCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_UnitCode Like @F_UnitCode ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_ContactUnitEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_ASSETS_ContactUnit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_ContactUnitEntity GetDC_ASSETS_ContactUnitEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_ContactUnitEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_ASSETS_ContactUnitEntity>(t=>t.F_CUId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_ContactUnitEntity entity)
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
