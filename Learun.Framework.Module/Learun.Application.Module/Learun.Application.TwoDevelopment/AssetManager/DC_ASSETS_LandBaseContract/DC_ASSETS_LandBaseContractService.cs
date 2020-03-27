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
    /// 日 期：2019-02-21 15:37
    /// 描 述：DC_ASSETS_LandBaseContract
    /// </summary>
    public class DC_ASSETS_LandBaseContractService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_LandBaseContractEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_LBCId,
                t.F_LBIId,
                t.F_ContractState,
                t.F_HandleDate,
                t.F_HandleUserId,
                t.F_HandleDescribe
                ");
                strSql.Append("  FROM DC_ASSETS_LandBaseContract t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ContractState"].IsEmpty())
                {
                    dp.Add("F_ContractState", queryParam["F_ContractState"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ContractState = @F_ContractState ");
                }
                if (!queryParam["F_LBIId"].IsEmpty())
                {
                    dp.Add("F_LBIId", queryParam["F_LBIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_LBIId = @F_LBIId ");
                }
                return this.BaseRepository().FindList<DC_ASSETS_LandBaseContractEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_ASSETS_LandBaseContract表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_LandBaseContractEntity GetDC_ASSETS_LandBaseContractEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_ASSETS_LandBaseContractEntity>(keyValue);
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable("   select F_LBIId as id ,F_LandNumber as name ,0 as pid from DC_ASSETS_LandBaseInfo ");
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
                this.BaseRepository().Delete<DC_ASSETS_LandBaseContractEntity>(t => t.F_LBCId == keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_LandBaseContractEntity entity)
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
