using Learun.Util;
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
    public interface DC_ASSETS_EquipmentPartsOutIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_EquipmentPartsOutEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_ASSETS_EquipmentPartsOutDetail表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_EquipmentPartsOutDetailEntity> GetDC_ASSETS_EquipmentPartsOutDetailList(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_EquipmentPartsOut表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_EquipmentPartsOutEntity GetDC_ASSETS_EquipmentPartsOutEntity(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_EquipmentPartsOutDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_EquipmentPartsOutDetailEntity GetDC_ASSETS_EquipmentPartsOutDetailEntity(string keyValue);

        DataTable ExportData(string queryJson);
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
        bool SaveEntity(string keyValue, DC_ASSETS_EquipmentPartsOutEntity entity, List<DC_ASSETS_EquipmentPartsOutDetailEntity> dC_ASSETS_EquipmentPartsOutDetailList);
        #endregion
        List<DeviceDetailModel> GetDetail(string keyValue);

    }
}
