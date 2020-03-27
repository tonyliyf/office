using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 17:08
    /// 描 述：DC_OA_PerformanceUserWorkPlan
    /// </summary>
    public interface DC_OA_PerformanceUserWorkPlanIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceUserWorkPlanEntity> GetList(string queryJson);
        IEnumerable<DC_OA_PerformanceUserWorkPlanEntity> GetEvaluate2List(string queryJson);
        /// <summary>
        /// 获取DC_OA_PerformanceUserWorkPlan表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_PerformanceUserWorkPlanEntity GetDC_OA_PerformanceUserWorkPlanEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkPlanEntity entity);
        #endregion
        void SaveEvaluate3Entity(string wpid, int? score);
        DC_OA_PerformanceUserWorkPlanEntity GetEvaluateEntity(string keyValue);
    }
}
