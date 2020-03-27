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
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-09 15:49
    /// 描 述：DC_OA__PartyBranch
    /// </summary>
    public class DC_OA__PartyBranchService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PartyBranchEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PartyBranchGUID,
                t.F_PartyBranchCode,
                t.F_PartyBranchName,
                t.F_PPartyBranchCode,
                t.F_ApprovalDate,
                t.F_ExpiryTime,
                t.F_Compnay,
                t.F_Remark
                ");
                strSql.Append("  FROM DC_OA_PartyBranch t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PartyBranchCode"].IsEmpty())
                {
                    dp.Add("F_PartyBranchCode", "%" + queryParam["F_PartyBranchCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PartyBranchCode Like @F_PartyBranchCode ");
                }
                if (!queryParam["F_PartyBranchName"].IsEmpty())
                {
                    dp.Add("F_PartyBranchName", "%" + queryParam["F_PartyBranchName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PartyBranchName Like @F_PartyBranchName ");
                }
                return this.BaseRepository().FindList<DC_OA_PartyBranchEntity>(strSql.ToString(),dp);
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
        /// 获取DC_OA_PartyBranch表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PartyBranchEntity GetDC_OA_PartyBranchEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PartyBranchEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PartyBranchEntity>(t=>t.F_PartyBranchGUID == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PartyBranchEntity entity)
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
