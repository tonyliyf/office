using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-06 16:45
    /// 描 述：DC_OA_PurchaseDeposit
    /// </summary>
    public class DC_OA_PurchaseDepositBLL : DC_OA_PurchaseDepositIBLL
    {
        private DC_OA_PurchaseDepositService dC_OA_PurchaseDepositService = new DC_OA_PurchaseDepositService();

        #region 获取数据

        public  DataTable GetList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetList(pagination, queryJson);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PurchaseDepositEntity> GetPageList(Pagination pagination, string queryJson,string isPower)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetPageList(pagination, queryJson,isPower);
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
        /// 获取DC_OA_PurchaseDepositDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_PurchaseDepositDetailEntity> GetDC_OA_PurchaseDepositDetailList(string keyValue)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetDC_OA_PurchaseDepositDetailList(keyValue);
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
        /// 获取DC_OA_PurchaseDeposit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PurchaseDepositEntity GetDC_OA_PurchaseDepositEntity(string keyValue)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetDC_OA_PurchaseDepositEntity(keyValue);
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
        /// 获取DC_OA_PurchaseDepositDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PurchaseDepositDetailEntity GetDC_OA_PurchaseDepositDetailEntity(string keyValue)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetDC_OA_PurchaseDepositDetailEntity(keyValue);
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
                dC_OA_PurchaseDepositService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PurchaseDepositEntity entity, List<DC_OA_PurchaseDepositDetailEntity> dC_OA_PurchaseDepositDetailList)
        {
            try
            {
                dC_OA_PurchaseDepositService.SaveEntity(keyValue, entity, dC_OA_PurchaseDepositDetailList);
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
        public DataTable GetEntityEx(string keyValue)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetEntityEx(keyValue);
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
        public DataTable GetListEntityEx(string keyValue)
        {
            try
            {
                return dC_OA_PurchaseDepositService.GetListEntityEx(keyValue);
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
