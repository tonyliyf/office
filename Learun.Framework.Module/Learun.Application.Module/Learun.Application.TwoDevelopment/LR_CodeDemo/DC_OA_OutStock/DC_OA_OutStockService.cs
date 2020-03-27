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
    /// 日 期：2019-01-10 15:49
    /// 描 述：DC_OA_OutStock
    /// </summary>
    public class DC_OA_OutStockService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OutStockEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_OutStockId,
                t.DC_OA_OutStockNo,
                t.DC_OA_OutStockTime,
                t.DC_OA_OutStockMoney,
                t.DC_OA_OutStockState
                ");
                strSql.Append("  FROM DC_OA_OutStock t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND (( t.DC_OA_OutStockTime >= @startTime AND t.DC_OA_OutStockTime <= @endTime ) or DC_OA_OutStockTime is null)  ");
                }
                if (!queryParam["DC_OA_OutStockNo"].IsEmpty())
                {
                    dp.Add("DC_OA_OutStockNo", "%" + queryParam["DC_OA_OutStockNo"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.DC_OA_OutStockNo Like @DC_OA_OutStockNo ");
                }
                if (!queryParam["DC_OA_OutStockState"].IsEmpty())
                {
                    dp.Add("DC_OA_OutStockState", queryParam["DC_OA_OutStockState"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_OutStockState = @DC_OA_OutStockState ");
                }
                return this.BaseRepository().FindList<DC_OA_OutStockEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_OutStockDetails表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OutStockDetailsEntity> GetDC_OA_OutStockDetailsList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_OutStockDetailsEntity>(t => t.DC_OA_OutStockRefId == keyValue);
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
        /// 获取DC_OA_OutStock表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OutStockEntity GetDC_OA_OutStockEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OutStockEntity>(keyValue);
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
        /// 获取DC_OA_OutStockDetails表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OutStockDetailsEntity GetDC_OA_OutStockDetailsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OutStockDetailsEntity>(t => t.DC_OA_OutStockRefId == keyValue);
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
                var dC_OA_OutStockEntity = GetDC_OA_OutStockEntity(keyValue);
                db.Delete<DC_OA_OutStockEntity>(t => t.DC_OA_OutStockId == keyValue);
                db.Delete<DC_OA_OutStockDetailsEntity>(t => t.DC_OA_OutStockRefId == dC_OA_OutStockEntity.DC_OA_OutStockId);
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
        public void SaveEntity(string keyValue, DC_OA_OutStockEntity entity, List<DC_OA_OutStockDetailsEntity> dC_OA_OutStockDetailsList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_OutStockEntityTmp = GetDC_OA_OutStockEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_OA_OutStockDetailsEntity>(t => t.DC_OA_OutStockRefId == dC_OA_OutStockEntityTmp.DC_OA_OutStockId);
                    foreach (DC_OA_OutStockDetailsEntity item in dC_OA_OutStockDetailsList)
                    {
                        item.Create();
                        item.DC_OA_OutStockRefId = dC_OA_OutStockEntityTmp.DC_OA_OutStockId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_OA_OutStockDetailsEntity item in dC_OA_OutStockDetailsList)
                    {
                        item.Create();
                        item.DC_OA_OutStockRefId = entity.DC_OA_OutStockId;
                        db.Insert(item);
                    }
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


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public bool OutStock(string keyValue, DC_OA_OutStockEntity entity, List<DC_OA_OutStockDetailsEntity> dC_OA_InStockDetailsList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.DC_OA_OutStockState = "2";///已入库
                    db.Update(entity);
                    foreach (DC_OA_OutStockDetailsEntity item in dC_OA_InStockDetailsList)
                    {
                        var dc_oa_WoodsEntity = db.FindEntity<DC_OA_OfficeWoodsEntity>(c => c.DC_OA_WoodsId == item.DC_OA_WoodsRefId);
                        var dc_oa_WoodsInStock = db.FindEntity<DC_OA_StockWoodsEntity>(c => c.DC_OA_WoodsRefId == item.DC_OA_WoodsRefId);
                        //判断库存是否有物品信息，有的话加数量，没有的话直接创建
                        if (dc_oa_WoodsInStock != null)
                        {
                            dc_oa_WoodsInStock.DC_OA_WoodsNumbers -= item.DC_OA_OutStockNums;
                            if (dc_oa_WoodsInStock.DC_OA_WoodsNumbers < 0)
                            {
                                db.Rollback();
                                return false;
                            }
                            db.Update(dc_oa_WoodsInStock);
                        }
                    }

                }

                db.Commit();
                return true;
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
