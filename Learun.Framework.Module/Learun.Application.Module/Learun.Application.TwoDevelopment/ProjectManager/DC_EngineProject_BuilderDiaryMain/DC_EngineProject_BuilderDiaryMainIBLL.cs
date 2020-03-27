using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.EcologyDemo;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 10:59
    /// 描 述：DC_EngineProject_BuilderDiaryMain
    /// </summary>
    public interface DC_EngineProject_BuilderDiaryMainIBLL
    {
        #region 获取数据
        DataTable ExportData(string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<formtable_main_134Entity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_EngineProject_BuilderDiaryDetail表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_EngineProject_BuilderDiaryDetailEntity> GetDC_EngineProject_BuilderDiaryDetailList(string keyValue);
        /// <summary>
        /// 获取DC_EngineProject_BuilderDiaryMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_EngineProject_BuilderDiaryMainEntity GetDC_EngineProject_BuilderDiaryMainEntity(string keyValue);
        /// <summary>
        /// 获取DC_EngineProject_BuilderDiaryDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_EngineProject_BuilderDiaryDetailEntity GetDC_EngineProject_BuilderDiaryDetailEntity(string keyValue);


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
        void SaveEntity(string keyValue, DC_EngineProject_BuilderDiaryMainEntity entity,List<DC_EngineProject_BuilderDiaryDetailEntity> dC_EngineProject_BuilderDiaryDetailList);


        DataTable GetMainRecord(string Projectid,string code);
        DataTable MaxTime (string Projectid);
        DataTable MinTime(string Projectid);
        formtable_main_134Entity SelectRecord(string id);

        #endregion

    }
}
