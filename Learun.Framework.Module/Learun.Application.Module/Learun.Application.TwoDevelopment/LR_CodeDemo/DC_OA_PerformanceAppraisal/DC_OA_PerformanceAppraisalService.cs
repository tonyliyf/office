using Dapper;
using Learun.Application.Organization;
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
    /// 日 期：2019-01-24 09:40
    /// 描 述：DC_OA_PerformanceAppraisal
    /// </summary>
    public class DC_OA_PerformanceAppraisalService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceAppraisalEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PAId,
                t.F_Sort,
                t.F_TargetName,
                isnull(t.F_ParentId,0) as F_ParentId,
                t.F_TargetContent,
                t.F_Target,
                t.F_TargetExplain,
                t.F_TargetScore,
                t.F_IfTargetDefine
                ");
                strSql.Append("  FROM DC_OA_PerformanceAppraisal t ");
                strSql.Append("  WHERE 1=1 ");
                var dp = new DynamicParameters(new { });
                var queryParam = queryJson.ToJObject();
                if (!queryParam["F_PATId"].IsEmpty())
                {
                    dp.Add("F_PATId", queryParam["F_PATId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PATId = @F_PATId ");
                }
                else
                {
                    strSql.Append(" AND 1=2 ");
                }
                strSql.Append("order by F_Sort");
                // 虚拟参数
                return this.BaseRepository().FindList<DC_OA_PerformanceAppraisalEntity>(strSql.ToString(), dp);
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
        /// 获取DC_OA_PerformanceAppraisal表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceAppraisalEntity GetDC_OA_PerformanceAppraisalEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceAppraisalEntity>(keyValue);
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
                return this.BaseRepository().FindTable("   select F_PATId as id,F_TemplateName as name,0 as pid from DC_OA_PerformanceAppraisalTemplate ");
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
                this.BaseRepository().Delete<DC_OA_PerformanceAppraisalEntity>(t => t.F_PAId == keyValue);
                var list = this.BaseRepository().FindList<DC_OA_PerformanceAppraisalEntity>(t => t.F_ParentId == keyValue);
                if (list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        DeleteEntity(item.F_PAId);
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_OA_PerformanceAppraisalEntity entity)
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

        public void InsertPostRalation(string tid, string postIds)
        {
            string[] arr = postIds.Split(',');
            this.BaseRepository().Delete<DC_OA_PerformancePostRelationEntity>(c => c.F_PATId == tid);
            foreach (var item in arr)
            {
                DC_OA_PerformancePostRelationEntity entity = new DC_OA_PerformancePostRelationEntity();
                entity.Create();
                entity.F_PATId = tid;
                entity.F_PostId = item;
                this.BaseRepository().Insert(entity);
            }
        }

        public List<PostEntity> GetPostIdList(string tid, out string postIds)
        {
            var dp = new DynamicParameters(new { });
            dp.Add("F_PATId", tid, DbType.String);
            List<PostEntity> list = this.BaseRepository().FindList<PostEntity>(@"  select t1.* from LR_Base_Post t1,DC_OA_PerformancePostRelation t2
                where t1.F_PostId=t2.F_PostId and t2.F_PATId = @F_PATId", dp).ToList();
            var temp = "";
            list.ForEach(c => temp += c.F_PostId + ",");
            if (temp.Length > 0)
            {
                temp = temp.Substring(0, temp.Length - 1);
            }
            postIds = temp;
            return list;
        }
        #endregion

    }
}
