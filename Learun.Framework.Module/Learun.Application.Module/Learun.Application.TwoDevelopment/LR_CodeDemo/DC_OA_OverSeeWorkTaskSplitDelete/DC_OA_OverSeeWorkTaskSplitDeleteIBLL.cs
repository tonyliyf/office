using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-08 15:54
    /// 描 述：DC_OA_OverSeeWorkTaskSplitDelete
    /// </summary>
    public interface DC_OA_OverSeeWorkTaskSplitDeleteIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetList(string keyValue, string queryJson);
        IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetListEx(string keyValue, string queryJson);
        /// <summary>
        /// 获取DC_OA_OverSeeWorkTaskSplit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OverSeeWorkTaskSplitEntity GetDC_OA_OverSeeWorkTaskSplitEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_OverSeeWorkTaskSplitEntity entity);
        #endregion
        IEnumerable<DC_OA_OverSeeWorkTaskSplitEntity> GetList(string queryJson);
        DataTable GetNoticeMembersData(string keyValue, out string noticeContent);
    }
}
