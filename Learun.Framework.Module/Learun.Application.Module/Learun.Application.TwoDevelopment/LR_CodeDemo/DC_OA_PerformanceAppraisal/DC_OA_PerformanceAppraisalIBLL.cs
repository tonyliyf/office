using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 09:40
    /// 描 述：DC_OA_PerformanceAppraisal
    /// </summary>
    public interface DC_OA_PerformanceAppraisalIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceAppraisalEntity> GetList(string queryJson);
        /// <summary>
        /// 获取DC_OA_PerformanceAppraisal表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_PerformanceAppraisalEntity GetDC_OA_PerformanceAppraisalEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_PerformanceAppraisalEntity entity);
        #endregion


        void InsertPostRalation(string tid, string postIds);
        List<PostEntity> GetPostIdList(string tid, out string postIds);
    }
}
