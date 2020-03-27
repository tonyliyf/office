using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-07 15:15
    /// 描 述：DC_ASSETS_BusStopBillboardsRentDetail
    /// </summary>
    public interface DC_ASSETS_BusStopBillboardsRentDetailIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetPageList(Pagination pagination, string queryJson);
        IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetList();

        IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetBusStopBillboardsRentList();

        IEnumerable<DC_ASSETS_BusStopBillboardsRentDetailEntity> GetBoardDetailList(string keyValue,string Searchvalue);

               
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboardsRentMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_BusStopBillboardsRentMainEntity GetDC_ASSETS_BusStopBillboardsRentMainEntity(string keyValue);
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboardsRentDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        /// 
        DataTable ExportData(string queryJson);
        DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity(string keyValue);

        DC_ASSETS_BusStopBillboardsEntity GetDC_ASSETS_BusStopBillboardsEntity(string keyValue);

        DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity1(string keyValue);

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();



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
        void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentMainEntity entity,DC_ASSETS_BusStopBillboardsRentDetailEntity dC_ASSETS_BusStopBillboardsRentDetailEntity);
        #endregion

    }
}
