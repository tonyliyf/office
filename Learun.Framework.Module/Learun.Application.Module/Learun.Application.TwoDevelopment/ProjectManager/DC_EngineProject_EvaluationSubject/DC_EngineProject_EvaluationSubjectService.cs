using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-03 15:13
    /// 描 述：项目评价科目
    /// </summary>
    public class DC_EngineProject_EvaluationSubjectService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_EvaluationSubjectEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ProjectEvaluationId,
                t.F_ProjectEvaluationItem,
                t.F_ProjectEvaluationParentId,
                t.F_EvaluationScore,
                t.F_Sort,
                t.F_ProjectEvaluationContent
                ");
                strSql.Append("  FROM DC_EngineProject_EvaluationSubject t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ProjectEvaluationItem"].IsEmpty())
                {
                    dp.Add("F_ProjectEvaluationItem", "%" + queryParam["F_ProjectEvaluationItem"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ProjectEvaluationItem Like @F_ProjectEvaluationItem ");
                }

                if (!queryParam["F_ProjectEvaluationParentId"].IsEmpty())
                {
                    dp.Add("F_ProjectEvaluationParentId",  queryParam["F_ProjectEvaluationParentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ProjectEvaluationParentId = @F_ProjectEvaluationParentId ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_EvaluationSubjectEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_EngineProject_EvaluationSubject表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_EvaluationSubjectEntity GetDC_EngineProject_EvaluationSubjectEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_EvaluationSubjectEntity>(keyValue);
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
                return this.BaseRepository().FindTable(" select * from DC_EngineProject_EvaluationSubject order by F_sort ");
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
        public DataTable GetSubjectTree()
        {
            try
            {
                return this.BaseRepository().FindTable(@"select t.* from DC_EngineProject_EvaluationSubject  t, DC_EngineProject_EvaluationSubject p
where t.F_ProjectEvaluationId = p.F_ProjectEvaluationParentId oder by F_sort");
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
                this.BaseRepository().Delete<DC_EngineProject_EvaluationSubjectEntity>(t=>t.F_ProjectEvaluationId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_EvaluationSubjectEntity entity)
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
