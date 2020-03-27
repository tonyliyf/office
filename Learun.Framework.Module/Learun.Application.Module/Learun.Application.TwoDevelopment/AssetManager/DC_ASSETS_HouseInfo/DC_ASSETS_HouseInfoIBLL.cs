using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 17:40
    /// 描 述：DC_ASSETS_HouseInfo
    /// </summary>
    public interface DC_ASSETS_HouseInfoIBLL
    {
        #region 获取数据
        DataTable ExportData(string queryJson);

        DataTable ExportLandHouseData(string queryJson);


        DataTable ExportHouseData(string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_HouseInfoEntity> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<DC_ASSETS_HouseInfoEntity> GetTotalPageList(Pagination pagination, string queryJson);
        IEnumerable<DC_ASSETS_HouseInfoEntity> GetTotalNoLandPageList(Pagination pagination, string queryJson);


        IEnumerable<HouseRentInfo> GetHouseRentInfoPageList(string queryJson);
        /// <summary>
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfoEntity(string keyValue);

        DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfoByAddress(string address,string unit);

        /// <summary>
        /// 获取DC_ASSETS_HouseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_HouseInfoEntity GetDC_ASSETS_HouseInfo(string keyValue);
        
        DC_ASSETS_HouseInfoEntity GetHouseInfoLandbase(string keyValue);
        string GetOldUnitByHouseId(string HouseID);

        string GetOwnerByHouseId(string HouseID);
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree(string keyValue);
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
        void SaveEntity(string keyValue, DC_ASSETS_HouseInfoEntity entity);
        void SaveTotalEntity(string keyValue, DC_ASSETS_BuildingBaseInfoEntity Buildingentity, DC_ASSETS_HouseInfoEntity entity);
        void SaveTotalEntity(string keyValue, DC_ASSETS_LandBaseInfoEntity Landentity, DC_ASSETS_BuildingBaseInfoEntity Buildingentity, DC_ASSETS_HouseInfoEntity entity);
        #endregion
        DataTable StatisticsHouseInfo(DateTime startDate, DateTime endDate);
        DataTable StatisticsHouseInfoEx(DateTime startDate, DateTime endDate);

        void UpdateComHouse();

        bool ImportCertiate(string FileDirectory, string numbersName, ref string Msg);

        DataTable GetboardsInfo();
        DataTable GetHouseAssigneeListt(string F_FormerUnit,string SearchValue);
        DataTable GetHouseAssigneeDetail(string State,string SearchValue);
        DataTable GetHouseAssigneeSearch(string F_FormerUnit,string SearchValue);
    }
}
