using Learun.Util;
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
    public interface DC_ASSETS_HouseRentMainIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_HouseRentMainEntity> GetPageList(Pagination pagination, string queryJson);


        DataTable GetHouseInfo();
        IEnumerable<DC_ASSETS_HouseRentMainEntity> GetMainList();
        IEnumerable<DC_ASSETS_HouseRentDetail_InfoEntity> GetDetail_InfoList();

        IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetDetail(string numbersName);
        /// <summary>
        /// 获取DC_ASSETS_HouseRentDetail表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<RentHouseModel> GetDC_ASSETS_HouseRentDetailList(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_HouseRentMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_HouseRentMainEntity GetDC_ASSETS_HouseRentMainEntity(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntity(string keyValue);

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
        void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainEntity entity, List<DC_ASSETS_HouseRentDetailEntity> dC_ASSETS_HouseRentDetailList);
        void SaveEntity(string keyValue, DC_ASSETS_HouseRentMainEntity entity);
        #endregion
        IEnumerable<PieChartModel> StatisticsRentInfo();

        bool ImportEntity(DataTable dt);

        bool ImportRent(DataTable dt, ref string msg);

        bool ImportPlan(DataTable dt);

        bool ImportCertiate(string FileDirectory,string numbersName, ref string Msg);
    }
}
