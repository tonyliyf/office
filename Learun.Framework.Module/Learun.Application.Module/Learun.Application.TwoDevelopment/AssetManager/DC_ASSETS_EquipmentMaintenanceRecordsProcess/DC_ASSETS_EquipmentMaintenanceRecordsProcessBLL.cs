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
    /// 日 期：2019-02-18 17:47
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecordsProcess
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenanceRecordsProcessBLL : DC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL
    {
        private DC_ASSETS_EquipmentMaintenanceRecordsProcessService dC_ASSETS_EquipmentMaintenanceRecordsProcessService = new DC_ASSETS_EquipmentMaintenanceRecordsProcessService();

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity> GetPageList(Pagination pagination, string queryJson, string PID)
        {
            try
            {
                return dC_ASSETS_EquipmentMaintenanceRecordsProcessService.GetPageList(pagination, queryJson, PID);
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
        /// 获取DC_ASSETS_EquipmentMaintenancePartsUse表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<PartUseModel> GetDC_ASSETS_EquipmentMaintenancePartsUseList(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentMaintenanceRecordsProcessService.GetDC_ASSETS_EquipmentMaintenancePartsUseList(keyValue);
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
        /// 获取DC_ASSETS_EquipmentMaintenanceRecordsProcess表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentMaintenanceRecordsProcessService.GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(keyValue);
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
        /// 获取DC_ASSETS_EquipmentMaintenancePartsUse表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_ASSETS_EquipmentMaintenancePartsUseEntity GetDC_ASSETS_EquipmentMaintenancePartsUseEntity(string keyValue)
        {
            try
            {
                return dC_ASSETS_EquipmentMaintenanceRecordsProcessService.GetDC_ASSETS_EquipmentMaintenancePartsUseEntity(keyValue);
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
                dC_ASSETS_EquipmentMaintenanceRecordsProcessService.DeleteEntity(keyValue);
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
        public void SaveEntity(string keyValue, DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity entity, List<DC_ASSETS_EquipmentMaintenancePartsUseEntity> dC_ASSETS_EquipmentMaintenancePartsUseList, string PID)
        {
            try
            {
                dC_ASSETS_EquipmentMaintenanceRecordsProcessService.SaveEntity(keyValue, entity, dC_ASSETS_EquipmentMaintenancePartsUseList, PID);
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
