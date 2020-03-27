﻿using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-12-31 16:09
    /// 描 述：办公物品管理
    /// </summary>
    public class DC_OA_OfficeWoodsService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OfficeWoodsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_WoodsId,
                t.DC_OA_WoodsName,
                t.DC_OA_WoodsNO,
                t.DC_OA_WoodsType,
                t.DC_Price,
                t.DC_Unit,
                t.F_Description,
                t.F_CreateUserId
                ");
                strSql.Append("  FROM DC_OA_OfficeWoods t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["DC_OA_WoodsName"].IsEmpty())
                {
                    dp.Add("DC_OA_WoodsName", "%" + queryParam["DC_OA_WoodsName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.DC_OA_WoodsName Like @DC_OA_WoodsName ");
                }
                if (!queryParam["DC_OA_WoodsType"].IsEmpty())
                {
                    dp.Add("DC_OA_WoodsType",queryParam["DC_OA_WoodsType"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_WoodsType = @DC_OA_WoodsType ");
                }
                return this.BaseRepository().FindList<DC_OA_OfficeWoodsEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_OfficeWoods表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OfficeWoodsEntity GetDC_OA_OfficeWoodsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OfficeWoodsEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_OfficeWoodsEntity>(t=>t.DC_OA_WoodsId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_OfficeWoodsEntity entity)
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
