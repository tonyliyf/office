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
    /// 日 期：2019-01-23 17:25
    /// 描 述：档案管理
    /// </summary>
    public class DC_OA_ArchivesService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_ArchivesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_ArchivesId,
                t.DC_OA_ArchiveType,
                t.DC_OA_NO,
                t.DC_OA_Year,
                t.DC_OA_Limits,
                t.DC_OA_Nums,
                t.DC_OA_Pages,
                t.DC_OA_Title,
                t.DC_OA_Content,
                t.F_Files
                ");
                strSql.Append("  FROM DC_OA_Archives t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["DC_OA_ArchiveType"].IsEmpty())
                {
                    dp.Add("DC_OA_ArchiveType",queryParam["DC_OA_ArchiveType"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_ArchiveType = @DC_OA_ArchiveType ");
                }
                if (!queryParam["DC_OA_Year"].IsEmpty())
                {
                    dp.Add("DC_OA_Year", "%" + queryParam["DC_OA_Year"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.DC_OA_Year Like @DC_OA_Year ");
                }
                if (!queryParam["DC_OA_Limits"].IsEmpty())
                {
                    dp.Add("DC_OA_Limits",queryParam["DC_OA_Limits"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_Limits = @DC_OA_Limits ");
                }
                if (!queryParam["DC_OA_Title"].IsEmpty())
                {
                    dp.Add("DC_OA_Title", "%" + queryParam["DC_OA_Title"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.DC_OA_Title Like @DC_OA_Title ");
                }
                return this.BaseRepository().FindList<DC_OA_ArchivesEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_Archives表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_ArchivesEntity GetDC_OA_ArchivesEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_ArchivesEntity>(keyValue);
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
                return this.BaseRepository().FindTable(@" SELECT t.F_ParentId,t.F_ItemName,t.F_ItemValue  FROM LR_Base_DataItemDetail  t  left join LR_Base_DataItem d on 
t.F_ItemId =d.F_ItemId where d.F_ItemCode='ArchivesType' ");
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
                this.BaseRepository().Delete<DC_OA_ArchivesEntity>(t=>t.DC_OA_ArchivesId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_ArchivesEntity entity)
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
