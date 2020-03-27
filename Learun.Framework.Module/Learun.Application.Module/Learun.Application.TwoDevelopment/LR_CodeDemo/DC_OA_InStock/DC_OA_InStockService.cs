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
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 15:50
    /// 描 述：DC_OA_InStock
    /// </summary>
    public class DC_OA_InStockService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_InStockEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.DC_OA_InStockId,
                t.DC_OA_InStockNo,
                t.DC_OA_InStockTime,
                t.DC_OAInStockMoney,
                t.F_CurrentUserId,
                t.DC_OA_InStockState
                ");
                strSql.Append("  FROM DC_OA_InStock t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["DC_OA_InStockNo"].IsEmpty())
                {
                    dp.Add("DC_OA_InStockNo", "%" + queryParam["DC_OA_InStockNo"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.DC_OA_InStockNo Like @DC_OA_InStockNo ");
                }
                if (!queryParam["DC_OA_InStockTime"].IsEmpty())
                {
                    dp.Add("DC_OA_InStockTime",queryParam["DC_OA_InStockTime"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_InStockTime = @DC_OA_InStockTime ");
                }
                if (!queryParam["DC_OA_InStockState"].IsEmpty())
                {
                    dp.Add("DC_OA_InStockState",queryParam["DC_OA_InStockState"].ToString(), DbType.String);
                    strSql.Append(" AND t.DC_OA_InStockState = @DC_OA_InStockState ");
                }
                return this.BaseRepository().FindList<DC_OA_InStockEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取DC_OA_InStockDetails表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_InStockDetailsEntity> GetDC_OA_InStockDetailsList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_InStockDetailsEntity>(t=>t.DC_OA_InStockRefId == keyValue );
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
        /// 获取DC_OA_InStock表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_InStockEntity GetDC_OA_InStockEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_InStockEntity>(keyValue);
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
        /// 获取DC_OA_InStockDetails表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_InStockDetailsEntity GetDC_OA_InStockDetailsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_InStockDetailsEntity>(t=>t.DC_OA_InStockRefId == keyValue);
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
                var dC_OA_InStockEntity = GetDC_OA_InStockEntity(keyValue); 
                db.Delete<DC_OA_InStockEntity>(t=>t.DC_OA_InStockId == keyValue);
                db.Delete<DC_OA_InStockDetailsEntity>(t=>t.DC_OA_InStockRefId == dC_OA_InStockEntity.DC_OA_InStockId);
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
        public void SaveEntity(string keyValue, DC_OA_InStockEntity entity,List<DC_OA_InStockDetailsEntity> dC_OA_InStockDetailsList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_InStockEntityTmp = GetDC_OA_InStockEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_OA_InStockDetailsEntity>(t=>t.DC_OA_InStockRefId == dC_OA_InStockEntityTmp.DC_OA_InStockId);
                    foreach (DC_OA_InStockDetailsEntity item in dC_OA_InStockDetailsList)
                    {
                        item.Create();
                        item.DC_OA_InStockRefId = dC_OA_InStockEntityTmp.DC_OA_InStockId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_OA_InStockDetailsEntity item in dC_OA_InStockDetailsList)
                    {
                        item.Create();
                        item.DC_OA_InStockRefId = entity.DC_OA_InStockId;
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
        public void InStock(string keyValue, DC_OA_InStockEntity entity, List<DC_OA_InStockDetailsEntity> dC_OA_InStockDetailsList)
        {
            var db = this.BaseRepository().BeginTrans();
            var woodsService = new DC_OA_OfficeWoodsService();
            var stockWoodsService = new DC_OA_StockWoodsService();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                   entity.DC_OA_InStockState = "2";///已入库
                    db.Update(entity);
                    foreach (DC_OA_InStockDetailsEntity item in dC_OA_InStockDetailsList)
                    {
                        var dc_oa_WoodsEntity = woodsService.GetDC_OA_OfficeWoodsEntity(item.DC_OA_WoodsRefId);
                        var dc_oa_WoodsInStock = stockWoodsService.GetDC_OA_StockWoodsEntityRefWoods(item.DC_OA_WoodsRefId);
                        //判断库存是否有物品信息，有的话加数量，没有的话直接创建
                        if(dc_oa_WoodsInStock != null)
                        {
                            dc_oa_WoodsInStock.DC_OA_WoodsNumbers += item.DC_OA_InStockNums;
                            db.Update(dc_oa_WoodsInStock);
                        }
                        else
                        {
                            dc_oa_WoodsInStock = new DC_OA_StockWoodsEntity();

                            dc_oa_WoodsInStock.DC_OA_WoodType = dc_oa_WoodsEntity.DC_OA_WoodsType;
                            dc_oa_WoodsInStock.DC_OA_WoodsUnit = dc_oa_WoodsEntity.DC_Unit;
                            dc_oa_WoodsInStock.DC_OA_WoodsRefId = dc_oa_WoodsEntity.DC_OA_WoodsId;
                            dc_oa_WoodsInStock.DC_OA_WoodsName = dc_oa_WoodsEntity.DC_OA_WoodsName;
                            dc_oa_WoodsInStock.DC_OA_WoodsNumbers = item.DC_OA_InStockNums;
                            dc_oa_WoodsInStock.Create();
                            db.Insert(dc_oa_WoodsInStock);


                        }

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

        #endregion

    }
}
