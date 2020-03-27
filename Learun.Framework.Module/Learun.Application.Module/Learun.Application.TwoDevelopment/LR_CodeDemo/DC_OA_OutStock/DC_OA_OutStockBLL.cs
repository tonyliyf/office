using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-10 15:49
    /// 描 述：DC_OA_OutStock
    /// </summary>
    public class DC_OA_OutStockBLL : DC_OA_OutStockIBLL
    {
        private DC_OA_OutStockService dC_OA_OutStockService = new DC_OA_OutStockService();

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
                return dC_OA_OutStockService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                return dC_OA_OutStockService.GetDC_OA_OutStockDetailsList(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                return dC_OA_OutStockService.GetDC_OA_OutStockEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                return dC_OA_OutStockService.GetDC_OA_OutStockDetailsEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                dC_OA_OutStockService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
            try
            {
                dC_OA_OutStockService.SaveEntity(keyValue, entity, dC_OA_OutStockDetailsList);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion
        public bool OutStock(string keyValue, DC_OA_OutStockEntity entity, List<DC_OA_OutStockDetailsEntity> dC_OA_InStockDetailsList)
        {
            try
            {
                return dC_OA_OutStockService.OutStock(keyValue, entity, dC_OA_InStockDetailsList);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

    }
}
