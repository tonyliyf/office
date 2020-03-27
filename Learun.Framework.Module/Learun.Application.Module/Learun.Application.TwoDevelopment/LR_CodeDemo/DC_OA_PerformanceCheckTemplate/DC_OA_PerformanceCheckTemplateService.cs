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
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-29 13:48
    /// 描 述：DC_OA_PerformanceCheckTemplate
    /// </summary>
    public class DC_OA_PerformanceCheckTemplateService : RepositoryFactory
    {
        private RoleIBLL roleBLL = new RoleBLL();
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckTemplateEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_TemplateId,
                t.F_TemplateName,
                t.F_TimeType,
                t.F_Path,
                t.F_Roleid,
                t.F_Enabled,
                t.F_Description,
                t.F_RoleNames
                ");
                strSql.Append("  FROM DC_OA_PerformanceCheckTemplate t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_TemplateName"].IsEmpty())
                {
                    dp.Add("F_TemplateName", "%" + queryParam["F_TemplateName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_TemplateName Like @F_TemplateName ");
                }
                return this.BaseRepository().FindList<DC_OA_PerformanceCheckTemplateEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_PerformanceCheckTemplate表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceCheckTemplateEntity GetDC_OA_PerformanceCheckTemplateEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceCheckTemplateEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PerformanceCheckTemplateEntity>(t=>t.F_TemplateId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceCheckTemplateEntity entity)
        {
            try
            {

                if (!string.IsNullOrEmpty(entity.F_Roleid ))
                {
                    var RoleEntity = roleBLL.GetListByRoleIds(entity.F_Roleid);

                    foreach (var roleitem in RoleEntity)
                    {
                        entity.F_RoleNames += roleitem.F_FullName;
                        entity.F_RoleNames += ",";
                    }
                    if (!string.IsNullOrEmpty(entity.F_RoleNames))
                    {
                        entity.F_RoleNames = entity.F_RoleNames.Substring(0, entity.F_RoleNames.Length - 1);
                    }
                }
                else
                {
                    entity.F_RoleNames = string.Empty;
                }

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
