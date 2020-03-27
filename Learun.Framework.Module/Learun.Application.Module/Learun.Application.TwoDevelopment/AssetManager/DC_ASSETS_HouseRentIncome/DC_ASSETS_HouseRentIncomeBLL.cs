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
    /// 日 期：2019-02-16 17:45
    /// 描 述：DC_ASSETS_HouseRentIncome
    /// </summary>
    public class DC_ASSETS_HouseRentIncomeBLL : DC_ASSETS_HouseRentIncomeIBLL
    {
        private DC_ASSETS_HouseRentIncomeService dC_ASSETS_HouseRentIncomeService = new DC_ASSETS_HouseRentIncomeService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseRentIncomeService.GetPageList(pagination, queryJson);
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

        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetDC_ASSETS_HouseRentIncomeEntityList(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentIncomeService.GetDC_ASSETS_HouseRentIncomeEntityList(keyValue);
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
        public DC_ASSETS_HouseRentIncomeEntityComplex GetList(string F_HRInId)
        {
            try
            {
                return dC_ASSETS_HouseRentIncomeService.GetList(F_HRInId);
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
        /// 获取DC_ASSETS_HouseRentIncome表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentIncomeEntity GetDC_ASSETS_HouseRentIncomeEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentIncomeService.GetDC_ASSETS_HouseRentIncomeEntity(keyValue);
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

        public IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetDC_ASSETS_HouseRentIncomeEntityByHDid(string HDid)
        {
            try
            {
                return dC_ASSETS_HouseRentIncomeService.GetDC_ASSETS_HouseRentIncomeEntityByHDid(HDid);
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
                dC_ASSETS_HouseRentIncomeService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentIncomeEntity entity)
        {
            try
            {
                dC_ASSETS_HouseRentIncomeService.SaveEntity(keyValue, entity);
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
        public IEnumerable<EChartModel> StatisticsForEChart()
        {
            try
            {
                return dC_ASSETS_HouseRentIncomeService.StatisticsForEChart();
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
        public void SaveEntity(string keyValue, List<DC_ASSETS_HouseRentIncomeEntity> list)
        {
            try
            {
                dC_ASSETS_HouseRentIncomeService.SaveEntity(keyValue, list);
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
