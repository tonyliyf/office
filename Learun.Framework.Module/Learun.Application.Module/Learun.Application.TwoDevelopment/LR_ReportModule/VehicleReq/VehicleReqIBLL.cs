using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_ReportModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-27 16:45
    /// 描 述：VehicleReq报表
    /// </summary>
    public interface VehicleReqIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<VehicleReqEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取VehicleReq表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        VehicleReqEntity GetVehicleReqEntity(string keyValue);
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
        void SaveEntity(string keyValue, VehicleReqEntity entity);
        #endregion

    }
}
