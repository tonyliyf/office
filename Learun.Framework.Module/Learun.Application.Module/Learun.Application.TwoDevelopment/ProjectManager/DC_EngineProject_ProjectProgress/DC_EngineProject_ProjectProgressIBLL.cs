using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-01 16:53
    /// 描 述：DC_EngineProject_ProjectProgress
    /// </summary>
    public interface DC_EngineProject_ProjectProgressIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_EngineProject_ProjectProgressEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 门户数据查询
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        DataTable GetProjectProgress(string projectid);
        /// <summary>
        /// 获取DC_EngineProject_ProjectProgress表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_EngineProject_ProjectProgressEntity GetDC_EngineProject_ProjectProgressEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_EngineProject_ProjectProgressEntity entity);
        #endregion

    }
}
