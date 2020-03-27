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
    /// 日 期：2019-02-15 13:51
    /// 描 述：DC_ASSETS_EquipmentPartsOut
    /// </summary>
    public class DC_ASSETS_EquipmentPartsOutBLL : DC_ASSETS_EquipmentPartsOutIBLL
    {
        private DC_ASSETS_EquipmentPartsOutService dC_ASSETS_EquipmentPartsOutService = new DC_ASSETS_EquipmentPartsOutService();

        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.ExportData(queryJson);
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
        public IEnumerable<DC_ASSETS_EquipmentPartsOutEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.GetPageList(pagination, queryJson);
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
        /// 获取DC_ASSETS_EquipmentPartsOutDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentPartsOutDetailEntity> GetDC_ASSETS_EquipmentPartsOutDetailList(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.GetDC_ASSETS_EquipmentPartsOutDetailList(keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsOut表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsOutEntity GetDC_ASSETS_EquipmentPartsOutEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.GetDC_ASSETS_EquipmentPartsOutEntity(keyValue);
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
        /// 获取DC_ASSETS_EquipmentPartsOutDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentPartsOutDetailEntity GetDC_ASSETS_EquipmentPartsOutDetailEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.GetDC_ASSETS_EquipmentPartsOutDetailEntity(keyValue);
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
                dC_ASSETS_EquipmentPartsOutService.DeleteEntity(keyValue);
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
        public bool SaveEntity(string keyValue, DC_ASSETS_EquipmentPartsOutEntity entity, List<DC_ASSETS_EquipmentPartsOutDetailEntity> dC_ASSETS_EquipmentPartsOutDetailList)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.SaveEntity(keyValue, entity, dC_ASSETS_EquipmentPartsOutDetailList);
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
        public List<DeviceDetailModel> GetDetail(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentPartsOutService.GetDetail(keyValue);
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
