﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-02 12:34
    /// 描 述：DC_OA_OverSeeWorkClosing
    /// </summary>
    public interface DC_OA_OverSeeWorkClosingIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_OverSeeWorkClosingEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkClosingDetailed表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_OverSeeWorkClosingDetailedEntity> GetDC_OA_OverSeeWorkClosingDetailedList(string keyValue);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkClosing表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkClosingEntity GetDC_OA_OverSeeWorkClosingEntity(string keyValue);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkClosingDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkClosingDetailedEntity GetDC_OA_OverSeeWorkClosingDetailedEntity(string keyValue);
        /// <summary>
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkClosingEntity GetEntityByProcessId(string processId);
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
        void SaveEntity(string keyValue, DC_OA_OverSeeWorkClosingEntity entity, List<DC_OA_OverSeeWorkClosingDetailedEntity> dC_OA_OverSeeWorkClosingDetailedList);
        #endregion
        List<DC_OA_OverSeeWorkClosingDetailedEntity> StatisticsWorkByWorkIds(string workId);
        DC_OA_OverSeeWorkEntity GetWorkEntity(string keyValue);

        string  Createflow(string MainKeyvalue);
    }
}
