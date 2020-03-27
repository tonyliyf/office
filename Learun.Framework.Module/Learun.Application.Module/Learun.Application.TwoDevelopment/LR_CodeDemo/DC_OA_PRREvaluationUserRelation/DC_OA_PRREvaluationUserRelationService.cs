using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 15:26
    /// 描 述：DC_OA_PRREvaluationUserRelation
    /// </summary>
    public class DC_OA_PRREvaluationUserRelationService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PRREvaluationUserRelationEntity> GetList(string rid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PRRSURId,
                t.F_EvaluationUserId,
                t.F_EvaluationWeight,
                t.F_EvaluationSort
                ");
                strSql.Append("  FROM DC_OA_PRREvaluationUserRelation t ");
                strSql.Append("  WHERE t.F_PRRId=@F_PRRId ");
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_PRRId", rid, DbType.String);
                return this.BaseRepository().FindList<DC_OA_PRREvaluationUserRelationEntity>(strSql.ToString(), dp);
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
        /// 获取DC_OA_PRREvaluationUserRelation表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PRREvaluationUserRelationEntity GetDC_OA_PRREvaluationUserRelationEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PRREvaluationUserRelationEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PRREvaluationUserRelationEntity>(t => t.F_PRRSURId == keyValue);
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
        public bool SaveEntity(string keyValue, DC_OA_PRREvaluationUserRelationEntity entity)
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
                    if (this.BaseRepository().FindList<DC_OA_PRREvaluationUserRelationEntity>(c => c.F_PRRId == entity.F_PRRId && c.F_EvaluationUserId == entity.F_EvaluationUserId).Count() > 0)
                    {
                        return false;
                    }
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
                return true;
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
