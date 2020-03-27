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
    /// 日 期：2019-02-27 14:02
    /// 描 述：DC_OA_MeetingSubjectSum
    /// </summary>
    public class DC_OA_MeetingSubjectSumService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_MeetingSubjectId,
                t1.F_SubListName,
                t1.F_Content
                ");
                strSql.Append("  FROM DC_OA_MeetingSubject t ");
                strSql.Append("  LEFT JOIN DC_OA_MeetingSubjectSum t1 ON t1.F_MeetingSubjectIds = t.F_MeetingSubjectId ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_MeetingSubjectEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_MeetingSubjectSum表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetDC_OA_MeetingSubjectSumList(string keyValue)
        {
            try
            {
                var entity = this.BaseRepository().FindEntity<DC_OA_MeetingSubjectSumEntity>(keyValue);
                return this.BaseRepository().FindList<DC_OA_MeetingSubjectEntity>(t => entity.F_MeetingSubjectIds.Contains(t.F_MeetingSubjectId));
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
        public IEnumerable<DC_OA_MeetingSubjectEntity> GetDC_OA_MeetingSubjectList()
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_MeetingSubjectEntity>(t => t.Is_agree == "2");
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
        /// 获取DC_OA_MeetingSubject表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingSubjectEntity GetDC_OA_MeetingSubjectEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingSubjectEntity>(keyValue);
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
        /// 获取DC_OA_MeetingSubjectSum表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_MeetingSubjectSumEntity GetDC_OA_MeetingSubjectSumEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_MeetingSubjectSumEntity>(keyValue);
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
                var dC_OA_MeetingSubjectEntity = GetDC_OA_MeetingSubjectEntity(keyValue);
                db.Delete<DC_OA_MeetingSubjectEntity>(t => t.F_MeetingSubjectId == keyValue);
                db.Delete<DC_OA_MeetingSubjectSumEntity>(t => t.F_MeetingSubjectIds == dC_OA_MeetingSubjectEntity.F_MeetingSubjectId);
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
        public void SaveEntity(string keyValue, DC_OA_MeetingSubjectSumEntity entity, List<DC_OA_MeetingSubjectEntity> dC_OA_MeetingSubjectList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var strids = "";
                entity.F_MeetingSubjectIds = strids;
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    foreach (var item in dC_OA_MeetingSubjectList)
                    {
                        strids += item.F_MeetingSubjectId + ",";
                        item.Is_agree = "3";
                        item.F_SubjectSumId = keyValue;
                        db.Update(item);
                    }
                    if (strids.Length > 0)
                    {
                        strids = strids.Substring(0, strids.Length - 1);
                    }
                    db.Update(entity);
                }
                else
                {
                    entity.Create();
                    foreach (var item in dC_OA_MeetingSubjectList)
                    {
                        strids += item.F_MeetingSubjectId + ",";
                        item.Is_agree = "3";
                        item.F_SubjectSumId = entity.F_SubjectSumId;
                        db.Update(item);
                    }
                    if (strids.Length > 0)
                    {
                        strids = strids.Substring(0, strids.Length - 1);
                    }
                    db.Insert(entity);
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

    }
}
