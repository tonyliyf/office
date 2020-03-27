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
    /// 日 期：2019-03-07 13:14
    /// 描 述：DC_OA_LargeCostPay
    /// </summary>
    public class DC_OA_LargeCostPayBLL : DC_OA_LargeCostPayIBLL
    {
        private DC_OA_LargeCostPayService dC_OA_LargeCostPayService = new DC_OA_LargeCostPayService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_LargeCostPayEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_OA_LargeCostPayService.GetPageList(pagination, queryJson);
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
        /// 获取DC_OA_LargeCostPay表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_LargeCostPayEntity GetDC_OA_LargeCostPayEntity(string keyValue)
        {
            try
            {
                return dC_OA_LargeCostPayService.GetDC_OA_LargeCostPayEntity(keyValue);
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
                dC_OA_LargeCostPayService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_LargeCostPayEntity entity)
        {
            try
            {
                dC_OA_LargeCostPayService.SaveEntity(keyValue, entity);
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
        public DataTable GetLargeCostPayData(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            try
            {
                return dC_OA_LargeCostPayService.GetLargeCostPayData(startDate, endDate, GroupBy);
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

        public DataTable GetLargeCostPayData1(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            try
            {
                DataTable num = dC_OA_LargeCostPayService.GetLargeCostPayData1(startDate, endDate, GroupBy);
                return num;
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
        public DataTable GetLargeCostPayData2(DateTime? startDate, DateTime? endDate, string GroupBy)
        {
            try
            {
                DataTable num = dC_OA_LargeCostPayService.GetLargeCostPayData2(startDate, endDate, GroupBy);
                return num;
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
