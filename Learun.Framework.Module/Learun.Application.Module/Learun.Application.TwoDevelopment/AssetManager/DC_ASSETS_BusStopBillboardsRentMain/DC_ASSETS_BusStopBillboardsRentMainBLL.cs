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
    /// 日 期：2019-03-07 11:49
    /// 描 述：广告招租
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentMainBLL : DC_ASSETS_BusStopBillboardsRentMainIBLL
    {
        private DC_ASSETS_BusStopBillboardsRentMainService dC_ASSETS_BusStopBillboardsRentMainService = new DC_ASSETS_BusStopBillboardsRentMainService();

        #region 获取数据
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsEntity GetDC_ASSETS_BusStopBillboardsEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetDC_ASSETS_BusStopBillboardsEntity(keyValue);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentMainEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentMainEntity> GetMainList()
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetMainList();
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
        public DataTable GetboardInfo()
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetboardInfo();
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
        public DataTable ExportData(string queryJson)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.ExportData(queryJson);
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
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetDC_ASSETS_BusStopBillboardsRentDetailList(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetDC_ASSETS_BusStopBillboardsRentDetailList(keyValue);
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
        /// 获取DC_ASSETS_BusStopBillboardsRentMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentMainEntity GetDC_ASSETS_BusStopBillboardsRentMainEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetDC_ASSETS_BusStopBillboardsRentMainEntity(keyValue);
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
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.GetDC_ASSETS_BusStopBillboardsRentDetailEntity(keyValue);
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
                dC_ASSETS_BusStopBillboardsRentMainService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentMainEntity entity,List<DC_ASSETS_BusStopBillboardsRentDetailEntity> dC_ASSETS_BusStopBillboardsRentDetailList)
        {
            try
            {
                dC_ASSETS_BusStopBillboardsRentMainService.SaveEntity(keyValue, entity,dC_ASSETS_BusStopBillboardsRentDetailList);
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

        public DataTable StatisticsRentAmountByYear()
        {
            try
            {
                return dC_ASSETS_BusStopBillboardsRentMainService.StatisticsRentAmountByYear();
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
