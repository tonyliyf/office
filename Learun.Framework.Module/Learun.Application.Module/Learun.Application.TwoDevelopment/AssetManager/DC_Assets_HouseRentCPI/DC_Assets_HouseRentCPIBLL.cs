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
    /// 日 期：2019-08-19 20:39
    /// 描 述：租房CPI系数
    /// </summary>
    public class DC_Assets_HouseRentCPIBLL : DC_Assets_HouseRentCPIIBLL
    {
        private DC_Assets_HouseRentCPIService dC_Assets_HouseRentCPIService = new DC_Assets_HouseRentCPIService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_Assets_HouseRentCPIEntity> GetList(string queryJson)
        {
            try
            {
                return dC_Assets_HouseRentCPIService.GetList(queryJson);
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
        /// 获取DC_Assets_HouseRentCPI表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_Assets_HouseRentCPIEntity GetDC_Assets_HouseRentCPIEntity(string keyValue)
        {
            try
            {
                return dC_Assets_HouseRentCPIService.GetDC_Assets_HouseRentCPIEntity(keyValue);
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

        public DC_Assets_HouseRentCPIEntity GetDC_Assets_HouseRentCPIEntityByYear(string Year)
        {
            try
            {
                return dC_Assets_HouseRentCPIService.GetDC_Assets_HouseRentCPIEntityByYear(Year);
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
                dC_Assets_HouseRentCPIService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_Assets_HouseRentCPIEntity entity)
        {
            try
            {
                dC_Assets_HouseRentCPIService.SaveEntity(keyValue, entity);
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
