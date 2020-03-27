﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 11:36
    /// 描 述：DC_ASSETS_LandBaseInfo
    /// </summary>
    public interface DC_ASSETS_LandBaseInfoIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_LandBaseInfoEntity> GetPageList(Pagination pagination, string queryJson,string type);
        /// <summary>
        /// 获取DC_ASSETS_LandBaseInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_LandBaseInfoEntity GetDC_ASSETS_LandBaseInfoEntity(string keyValue);

        DC_ASSETS_LandBaseInfoEntity GetDC_ASSETS_LandBaseInfoEntity(string landname,string ceticate);
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
        void SaveEntity(string keyValue, DC_ASSETS_LandBaseInfoEntity entity);

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        bool ImportEntity(DataTable dt);
        bool ImportEntity2NoBuilding(DataTable dt);

        #endregion
        IEnumerable<PieChartModel> StatisticsLandInfo();
        DataTable StatisticsLandInfoByArea(DateTime startDate, DateTime endDate);
        DataTable StatisticsLandInfoByAreaEx(DateTime startDate, DateTime endDate);

        DataTable ExportData(string queryJson);
        DataTable GetExportData(string queryJson);

        DataTable GetExportComLandbase();

        DataTable GetComLandbase(string queryJson);

        DataTable GetLandInfo();

        DataTable GetLandAssigneeList(string F_Assignee,string SearchValue);
        DataTable GetLandAssigneeData(string F_Assignee, string F_Transferor);
        DataTable GetLandAssigneeSearch(string F_Assignee, string SearchValue);
        
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree(string unit);
    }
}
