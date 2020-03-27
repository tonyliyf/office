using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 15:19
    /// 描 述：DC_EngineProject_ProjectInfoApprovalData
    /// </summary>
    public interface DC_EngineProject_ProjectInfoApprovalDataIBLL
    {
        #region 获取数据
        DataTable ExportData(string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_EngineProject_ProjectInfoApprovalDataEntity> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<DC_EngineProject_ProjectInfoApprovalInfo> GetPageInfoList(string queryJson);
        /// <summary>
        /// 获取DC_EngineProject_ProjectInfoApprovalData表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_EngineProject_ProjectInfoApprovalDataEntity GetDC_EngineProject_ProjectInfoApprovalDataEntity(string keyValue);


        DataTable GetProjectBeforeInfo(string queryJson);


        DataTable GetProjectInfo(string queryJosn);

        DataTable GetBeforeProjectInfoss(string projecid);
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();

        List<TreeModel> GetBeforeTree();
        List<TreeModel> GetUnitTree();

        DataTable GetSqlTree();

        DataTable GetBeforeSqlTree();

        List<TreeModel> GetBeforeInfoTree();
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
        void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoApprovalDataEntity entity);
        #endregion

    }
}
