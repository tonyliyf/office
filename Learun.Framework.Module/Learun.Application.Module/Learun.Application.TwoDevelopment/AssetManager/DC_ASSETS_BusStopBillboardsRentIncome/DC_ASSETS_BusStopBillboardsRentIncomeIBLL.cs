using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-23 10:20
    /// 描 述：DC_ASSETS_BusStopBillboardsRentIncome
    /// </summary>
    public interface DC_ASSETS_BusStopBillboardsRentIncomeIBLL
    {
        #region 获取数据
        DC_ASSETS_BusStopBillboardsRentDetailEntity GetDC_ASSETS_BusStopBillboardsRentDetailEntity(string keyValue);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_BusStopBillboardsRentIncomeEntity> GetPageList(Pagination pagination, string queryJson,string F_BSBRDId);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_BusStopBillboardsEntity> GetPageList1();
        /// <summary>
        /// 获取DC_ASSETS_BusStopBillboardsRentIncome表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_BusStopBillboardsRentIncomeEntity GetDC_ASSETS_BusStopBillboardsRentIncomeEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_ASSETS_BusStopBillboardsRentIncomeEntity entity);

        void SaveEntity1(DC_ASSETS_BusStopBillboardsRentDetailEntity entity);
        #endregion

    }
}
