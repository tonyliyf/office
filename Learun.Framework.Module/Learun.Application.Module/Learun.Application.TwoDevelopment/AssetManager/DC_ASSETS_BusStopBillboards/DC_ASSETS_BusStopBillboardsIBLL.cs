using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 10:05
    /// 描 述：DC_ASSETS_BusStopBillboards
    /// </summary>
    public interface DC_ASSETS_BusStopBillboardsIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_BusStopBillboardsEntity> GetPageList(string queryJson);

        DataTable GetboardsInfo();
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboards表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_BusStopBillboardsEntity GetDC_ASSETS_BusStopBillboardsEntity(string keyValue);


        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();
        DataTable ExportData(string queryJson);

        DataTable GetHouseboardsList();
        DataTable GetboardsAssigneeSearch(string F_BillboardsCategory,string SearchValue);
        DataTable GetboardsAssigneeDetail1(string State, string SearchValue);
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
        void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsEntity entity);
        #endregion

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        bool ImportEntity(DataTable dt);

    }
}
