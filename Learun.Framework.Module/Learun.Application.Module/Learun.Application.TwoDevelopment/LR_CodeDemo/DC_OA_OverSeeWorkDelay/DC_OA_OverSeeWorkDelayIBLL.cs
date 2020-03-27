using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-02 16:37
    /// 描 述：DC_OA_OverSeeWorkDelay
    /// </summary>
    public interface DC_OA_OverSeeWorkDelayIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_OverSeeWorkDelayEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkDelayDetailed表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_OverSeeWorkDelayDetailedEntity> GetDC_OA_OverSeeWorkDelayDetailedList(string keyValue);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkDelay表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkDelayEntity GetDC_OA_OverSeeWorkDelayEntity(string keyValue);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkDelayDetailed表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkDelayDetailedEntity GetDC_OA_OverSeeWorkDelayDetailedEntity(string keyValue);
        /// <summary>
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkDelayEntity GetEntityByProcessId(string processId);
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
        void SaveEntity(string keyValue, DC_OA_OverSeeWorkDelayEntity entity, List<DC_OA_OverSeeWorkDelayDetailedEntity> dC_OA_OverSeeWorkDelayDetailedList);
        #endregion
        List<DC_OA_OverSeeWorkDelayDetailedEntity> StatisticsWorkByWorkIds(string workId);
        DC_OA_OverSeeWorkEntity GetWorkEntity(string keyValue);
        string Createflow(string MainKeyvalue);
    }
}
