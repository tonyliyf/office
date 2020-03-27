using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-14 15:07
    /// 描 述：formtable_main_140_dt1
    /// </summary>
    public class formtable_main_140_dt1Service : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<formtable_main_140_dt1Entity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.id,
                t.ggmc,
                t.cqr,
                t.zzksrq,
                t.zznx,
                t.zzdj,
                t.zzjg,
                t.zzsl,
                t.mainid
                ");
                strSql.Append("  FROM ecology.dbo.formtable_main_140_dt1 t ");
                strSql.Append("  WHERE 1=1");
                var queryParam = queryJson.ToJObject();

                strSql.Append("  and t.mainid=" + queryParam["keyValue1"].ToString() + "");
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["ggmc"].IsEmpty())
                {
                    dp.Add("ggmc", "%" + queryParam["ggmc"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.ggmc Like @ggmc ");
                }
                if (!queryParam["zzksrq"].IsEmpty())
                {
                    dp.Add("zzksrq",queryParam["zzksrq"].ToString(), DbType.String);
                    strSql.Append(" AND t.zzksrq = @zzksrq ");
                }
                return this.BaseRepository().FindList<formtable_main_140_dt1Entity>(strSql.ToString(),dp, pagination);
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
        /// 获取formtable_main_140_dt1表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public formtable_main_140_dt1Entity Getformtable_main_140_dt1Entity(string keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<formtable_main_140_dt1Entity>(keyValue);
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
                this.BaseRepository("ecologySql").Delete<formtable_main_140_dt1Entity>(t=>t.id == keyValue.ToInt());
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
        public void SaveEntity(string keyValue, formtable_main_140_dt1Entity entity)
        {
            try
            {
                //if (!string.IsNullOrEmpty(keyValue))
                //{
                //    entity.Modify(keyValue.ToInt());
                //    this.BaseRepository("ecologySql").Update(entity);
                //}
                //else
                //{
                    entity.mainid = keyValue.ToInt();
                    this.BaseRepository("ecologySql").Insert(entity);
                //}
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
