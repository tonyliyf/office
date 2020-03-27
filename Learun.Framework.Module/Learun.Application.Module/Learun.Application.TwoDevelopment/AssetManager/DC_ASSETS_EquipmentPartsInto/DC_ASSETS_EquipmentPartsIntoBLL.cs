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
    /// 日 期：2019-02-14 16:09
    /// 描 述：DC_ASSETS_EquipmentPartsInto
    /// </summary>
    public class DC_ASSETS_EquipmentPartsIntoBLL : DC_ASSETS_EquipmentPartsIntoIBLL
    {
        private DC_ASSETS_EquipmentPartsIntoService dC_ASSETS_EquipmentPartsIntoService = new DC_ASSETS_EquipmentPartsIntoService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentPartsIntoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsIntoService.GetPageList(pagination, queryJson);
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
                return dC_ASSETS_EquipmentPartsIntoService.ExportData(queryJson);
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
        /// 获取DC_ASSETS_EquipmentPartsIntoDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentPartsIntoDetailEntity> GetDC_ASSETS_EquipmentPartsIntoDetailList(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsIntoService.GetDC_ASSETS_EquipmentPartsIntoDetailList(keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsInto表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsIntoEntity GetDC_ASSETS_EquipmentPartsIntoEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsIntoService.GetDC_ASSETS_EquipmentPartsIntoEntity(keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsIntoDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsIntoDetailEntity GetDC_ASSETS_EquipmentPartsIntoDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsIntoService.GetDC_ASSETS_EquipmentPartsIntoDetailEntity(keyValue);
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
                dC_ASSETS_EquipmentPartsIntoService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentPartsIntoEntity entity, List<DC_ASSETS_EquipmentPartsIntoDetailEntity> dC_ASSETS_EquipmentPartsIntoDetailList)
        {
            try
            {
                dC_ASSETS_EquipmentPartsIntoService.SaveEntity(keyValue, entity, dC_ASSETS_EquipmentPartsIntoDetailList);
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
        public List<DeviceDetailModel> GetDetail(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsIntoService.GetDetail(keyValue);
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
