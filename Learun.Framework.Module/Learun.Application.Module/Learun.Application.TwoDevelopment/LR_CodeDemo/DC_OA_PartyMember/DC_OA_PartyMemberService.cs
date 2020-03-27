using Dapper;
using Learun.Application.Organization;
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
    /// 日 期：2019-01-09 15:20
    /// 描 述：DC_OA_PartyMember
    /// </summary>
    public class DC_OA_PartyMemberService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PartyMemberEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_UserId,
                t.F_PartyMemberGUID,
                t.F_RealName,
                t.F_Gender,
                t.F_Nation,
                t.F_NativePlace,
                t.F_Birthday,
                t.F_PartyBranchGUID,
                t.F_Remark
                ");
                strSql.Append("  FROM DC_OA_PartyMember t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_RealName"].IsEmpty())
                {
                    dp.Add("F_RealName", "%" + queryParam["F_RealName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_RealName Like @F_RealName ");
                }
                if (!queryParam["F_Gender"].IsEmpty())
                {
                    dp.Add("F_Gender", queryParam["F_Gender"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Gender = @F_Gender ");
                }
                if (!queryParam["F_PartyBranchGUID"].IsEmpty())
                {
                    dp.Add("F_PartyBranchGUID", queryParam["F_PartyBranchGUID"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PartyBranchGUID = @F_PartyBranchGUID ");
                }
                return this.BaseRepository().FindList<DC_OA_PartyMemberEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_PartyMember表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PartyMemberEntity GetDC_OA_PartyMemberEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PartyMemberEntity>(keyValue);
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
                return this.BaseRepository().FindTable(@" SELECT
      [F_PartyBranchGUID]
      ,[F_PartyBranchName]
      ,[F_PPartyBranchCode]
  FROM [DC_OA_PartyBranch] ");
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
                this.BaseRepository().Delete<DC_OA_PartyMemberEntity>(t => t.F_PartyMemberGUID == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PartyMemberEntity entity, List<DC_OA_PartyMemberDependentsEntity> dC_OA_PartyMemberDependentsList)
        {
            var result = this.BaseRepository().FindEntity<DC_OA_PartyBranchEntity>(c => c.F_PartyBranchGUID == entity.F_PartyBranchGUID);
            entity.F_PartyBranchCode = result.F_PartyBranchCode;
            entity.F_PartyBranchName = result.F_PartyBranchName;
            var users = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == entity.F_UserId);
            entity.F_RealName = users.F_RealName;
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                    foreach (DC_OA_PartyMemberDependentsEntity item in dC_OA_PartyMemberDependentsList)
                    {
                        item.Create();
                        item.F_PartyMemberGUID = entity.F_PartyMemberGUID;
                        this.BaseRepository().Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                    foreach (DC_OA_PartyMemberDependentsEntity item in dC_OA_PartyMemberDependentsList)
                    {
                        item.Create();
                        item.F_PartyMemberGUID = entity.F_PartyMemberGUID;
                        this.BaseRepository().Insert(item);
                    }
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
        /// <summary>
        /// 获取DC_OA_PartyMemberDependents表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_PartyMemberDependentsEntity> GetDC_OA_PartyMemberDependentsList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_PartyMemberDependentsEntity>(t => t.F_PartyMemberGUID == keyValue);
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
