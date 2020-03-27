using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 14:32
    /// 描 述：DC_ASSETS_HouseRentDetail
    /// </summary>
    public interface DC_ASSETS_HouseRentDetaiHistoryIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取已租房屋的数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetList();
        IEnumerable<DC_ASSETS_HouseRentDetaiHistoryEntity> GetRentPageList(Pagination pagination, string queryJson);
        IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetRentList(string ids);


        IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetRentDetailinfo(string keyValue,string SearchValue);



        /// <summary>
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntity(string keyValue);

        DC_ASSETS_HouseRentDetailEntity GetDC_ASSETS_HouseRentDetailEntityByHouseId(string keyValue);

        /// <summary>
        /// 获取DC_ASSETS_HouseRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_HouseRentDetaiHistoryEntity GetHouseRentDetailEntity(string keyValue);

        IEnumerable<DC_ASSETS_HouseRentDetailEntity> GetHouseRentDetailList();
        IEnumerable<DC_ASSETS_HouseRentIncomeEntity> GetHouseRentDetailInfoList();
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();


        IEnumerable<DC_ASSETS_HouseRentDetail_InfoHistoryEntity> GetDC_ASSETS_HouseRentDetailInfoList(string keyValue);

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
        void SaveEntity(string keyValue, DC_ASSETS_HouseRentDetaiHistoryEntity entity);

        void SaveEntity(string keyValue, DC_ASSETS_HouseRentDetailEntity entity, List<DC_ASSETS_HouseRentDetail_InfoEntity> dC_ASSETS_HouseRentDetailInfoList);
        #endregion
        double GetMinRentPrice(string keyValue);

    }
}
