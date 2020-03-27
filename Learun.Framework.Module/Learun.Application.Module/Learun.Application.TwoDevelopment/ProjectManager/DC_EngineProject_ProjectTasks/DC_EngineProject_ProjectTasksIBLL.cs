using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-19 14:16
    /// 描 述：DC_EngineProject_ProjectTasks
    /// </summary>
    public interface DC_EngineProject_ProjectTasksIBLL
    {
        #region 获取数据
        DataTable ExportData(string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_EngineProject_ProjectTasksEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_EngineProject_ProjectTasks表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_EngineProject_ProjectTasksEntity GetDC_EngineProject_ProjectTasksEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_EngineProject_ProjectTasksEntity entity);
        #endregion
        List<GanttEntity> GetGanttData(string keyValue);
    }
}
