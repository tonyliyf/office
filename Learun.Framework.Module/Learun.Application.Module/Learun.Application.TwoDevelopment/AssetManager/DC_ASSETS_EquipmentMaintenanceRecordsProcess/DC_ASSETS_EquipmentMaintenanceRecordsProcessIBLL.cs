﻿using Learun.Util;
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
    public interface DC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity> GetPageList(Pagination pagination, string queryJson, string PID);
        /// <summary>
        /// 获取DC_ASSETS_EquipmentMaintenancePartsUse表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<PartUseModel> GetDC_ASSETS_EquipmentMaintenancePartsUseList(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_EquipmentMaintenanceRecordsProcess表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_EquipmentMaintenancePartsUse表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_EquipmentMaintenancePartsUseEntity GetDC_ASSETS_EquipmentMaintenancePartsUseEntity(string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity entity, List<DC_ASSETS_EquipmentMaintenancePartsUseEntity> dC_ASSETS_EquipmentMaintenancePartsUseList, string PID);
        #endregion

    }
}