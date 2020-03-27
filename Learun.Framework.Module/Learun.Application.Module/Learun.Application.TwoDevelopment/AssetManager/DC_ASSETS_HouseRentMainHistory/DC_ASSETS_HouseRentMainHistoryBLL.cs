﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 13:45
    /// 描 述：DC_ASSETS_HouseRentMain
    /// </summary>
    public class DC_ASSETS_HouseRentMainHistoryBLL : DC_ASSETS_HouseRentMainHistoryIBLL
    {
        private DC_ASSETS_HouseRentMainHistoryService dC_ASSETS_HouseRentMainService = new DC_ASSETS_HouseRentMainHistoryService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData1(string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.ExportData1(queryJson);
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
                return dC_ASSETS_HouseRentMainService.ExportData(queryJson);
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
        public IEnumerable<DC_ASSETS_HouseRentMainHistoryEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.GetPageList(pagination, queryJson);
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
        public IEnumerable<DC_ASSETS_HouseRentMainHistoryEntity> GetMainList()
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.GetMainList();
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
        /// 获取DC_ASSETS_HouseRentDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<RentHouseModel> GetDC_ASSETS_HouseRentDetailList(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.GetDC_ASSETS_HouseRentDetailList(keyValue);
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
        /// 获取DC_ASSETS_HouseRentMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentMainHistoryEntity GetDC_ASSETS_HouseRentMainEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.GetDC_ASSETS_HouseRentMainEntity(keyValue);
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
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_HouseRentDetaiHistoryEntity GetDC_ASSETS_HouseRentDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.GetDC_ASSETS_HouseRentDetailEntity(keyValue);
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
                dC_ASSETS_HouseRentMainService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainHistoryEntity entity, List<DC_ASSETS_HouseRentDetaiHistoryEntity> dC_ASSETS_HouseRentDetailList)
        {
            try
            {
                dC_ASSETS_HouseRentMainService.SaveEntity(keyValue, entity, dC_ASSETS_HouseRentDetailList);
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
        public void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainHistoryEntity entity)
        {
            try
            {
                dC_ASSETS_HouseRentMainService.SaveEntity(keyValue, entity);
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
        public IEnumerable<PieChartModel> StatisticsRentInfo()
        {
            try
            {
                return dC_ASSETS_HouseRentMainService.StatisticsRentInfo();
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


        public bool ImportEntity(DataTable dt)
        {

            try
            {
                bool btrue = dC_ASSETS_HouseRentMainService.ImportBuildingEntity(dt);
                //dC_ASSETS_BuildingBaseInfoService.UpdateBuildValue();
                return btrue;
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

        public bool ImportRent(DataTable dt)
        {

            try
            {
                bool btrue = dC_ASSETS_HouseRentMainService.ImportRent(dt);
                //dC_ASSETS_BuildingBaseInfoService.UpdateBuildValue();
                return btrue;
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


     


        public bool ImportPlan(DataTable dt)
        {

            try
            {
                bool btrue = dC_ASSETS_HouseRentMainService.ImportPlan(dt);
                //dC_ASSETS_BuildingBaseInfoService.UpdateBuildValue();
                return btrue;
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
