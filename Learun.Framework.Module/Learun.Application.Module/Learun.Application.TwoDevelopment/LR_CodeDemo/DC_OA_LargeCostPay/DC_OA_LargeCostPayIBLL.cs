﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-07 13:14
    /// 描 述：DC_OA_LargeCostPay
    /// </summary>
    public interface DC_OA_LargeCostPayIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_LargeCostPayEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_LargeCostPay表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_LargeCostPayEntity GetDC_OA_LargeCostPayEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_LargeCostPayEntity entity);
        #endregion
        DataTable GetLargeCostPayData(DateTime? startDate, DateTime? endDate, string GroupBy);

        DataTable GetLargeCostPayData1(DateTime? startDate, DateTime? endDate, string GroupBy);
        DataTable GetLargeCostPayData2(DateTime? startDate, DateTime? endDate, string GroupBy);

    }
}