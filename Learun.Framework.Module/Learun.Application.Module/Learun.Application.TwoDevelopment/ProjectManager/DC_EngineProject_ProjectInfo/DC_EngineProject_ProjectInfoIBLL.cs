using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 13:57
    /// 描 述：DC_EngineProject_ProjectInfo
    /// </summary>
    public interface DC_EngineProject_ProjectInfoIBLL
    {
        #region 获取数据
        DataTable ExportData1(string queryJson);
        DataTable ExportData(string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_EngineProject_ProjectInfoEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_EngineProject_ProjectInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_EngineProject_ProjectInfoEntity GetDC_EngineProject_ProjectInfoEntity(string keyValue);
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();

        List<TreeModel> GetPorjectTree();



        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);

        /// <summary>
        /// 修改实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void UpdeteEntity(string keyValue);

        ///// <summary>
        ///// 判断项目状态是否为已完成
        ///// <param name="keyValue">主键</param>
        ///// <summary>
        ///// <returns></returns>
        //string UpdeteEntity1(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        /// 
        void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoEntity entity);
        #endregion
        IEnumerable<DC_EngineProject_ProjectInfoEntity> StatisticsProjectInfo(DateTime startDate, DateTime endDate);
        DataTable StatisticsProjectInfoByCategory(DateTime startDate, DateTime endDate);

        IEnumerable<DC_EngineProject_ProjectInfoEntity> GetProjectInfo(string F_ProjectAddress);
        IEnumerable<DC_EngineProject_ProjectInfoEntity> GetProjectInfo1();

        DataTable  GetProjectContract(string ProjectId,string F_ItemValue, string F_PICId);

        DataTable GetProjectContract1(string projectid);

        DataTable GetProjectOS_F_State();
    }
}
