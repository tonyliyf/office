﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 11:19
    /// 描 述：DC_OA_OverSeeWork
    /// </summary>
    public interface DC_OA_OverSeeWorkIBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_OverSeeWorkEntity> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<DC_OA_OverSeeWorkEntity> GetOverSeeWork();
        /// <summary>
        /// 获取DC_OA_OverSeeWork表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkEntity GetDC_OA_OverSeeWorkEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_OverSeeWorkEntity entity);
        #endregion
        List<WorkStatisticsModel> StatisticsWorkByCurrentMonth(DateTime startDate, DateTime endDate, string executeState, string workTitle);
        IEnumerable<EChartModel> StatisticForEChart();
        IEnumerable<WorkCategoryModel> StatisticsByCategory(DateTime startDate, DateTime endDate);
        IEnumerable<EChartModel> StatisticsByCategoryEx(DateTime startDate, DateTime endDate);
        void EnterOverSeeWork(string keyValue);
        int GetCount(string state);
        int GetCount1(string state);
        int GetCount2(string state);
        void AddScore(string keyValue, double score, string advice);
        void GetScore(string keyValue, out double score, out string advice);
        DataTable GetPlatformListByState(string state);
        Dictionary<string, List<int>> GetTaskByTypeAndMonth();
        DataTable GetTaskPercentByCategory();
        int GetTaskCountByCategory(string category);
        int GetMyTaskCount();
        int GetMyTaskCountEx();
    }
}