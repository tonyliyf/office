using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-23 10:20
    /// 描 述：DC_ASSETS_BusStopBillboardsRentIncome
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentIncomeBLL : DC_ASSETS_BusStopBillboardsRentIncomeIBLL
    {
        private DC_ASSETS_BusStopBillboardsRentIncomeService dC_ASSETS_BusStopBillboardsRentIncomeService = new DC_ASSETS_BusStopBillboardsRentIncomeService();

        #region 获取数据
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentIncomeService.GetDC_ASSETS_BusStopBillboardsRentDetailEntity(keyValue);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentIncomeEntity> GetPageList(Pagination pagination, string queryJson,string F_BSBRDId)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentIncomeService.GetPageList(pagination, queryJson, F_BSBRDId);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsEntity> GetPageList1()
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentIncomeService.GetPageList1();
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
        /// 获取DC_ASSETS_BusStopBillboardsRentIncome表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentIncomeEntity GetDC_ASSETS_BusStopBillboardsRentIncomeEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentIncomeService.GetDC_ASSETS_BusStopBillboardsRentIncomeEntity(keyValue);
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
                dC_ASSETS_BusStopBillboardsRentIncomeService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentIncomeEntity entity)
        {
            try
            {
                dC_ASSETS_BusStopBillboardsRentIncomeService.SaveEntity(keyValue, entity);
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
        public void SaveEntity1(DC_ASSETS_BusStopBillboardsRentDetailEntity entity)
        {
            try
            {
                dC_ASSETS_BusStopBillboardsRentIncomeService.SaveEntity1(entity);
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

    }
}
