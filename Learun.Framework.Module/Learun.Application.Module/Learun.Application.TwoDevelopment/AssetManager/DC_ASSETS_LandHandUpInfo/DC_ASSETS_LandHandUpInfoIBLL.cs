using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-23 12:01
    /// 描 述：DC_ASSETS_LandHandUpInfo
    /// </summary>
    public interface DC_ASSETS_LandHandUpInfoIBLL
    {
        #region 获取数据
        DataTable ExportData(string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_ASSETS_LandHandUpInfoEntity> GetPageList(Pagination pagination, string queryJson);
        DataTable GetLandHandlist();
        DataTable GetLandUpInfo();
        DataTable GetLandHandSearch(string F_Assignee,string SearchValue);
        /// <summary>
        /// 获取DC_ASSETS_LandHandUpInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_ASSETS_LandHandUpInfoEntity GetDC_ASSETS_LandHandUpInfoEntity(string keyValue);
        #endregion

        bool ImportEntity(DataTable dt);
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
        void SaveEntity(string keyValue, DC_ASSETS_LandHandUpInfoEntity entity);
        #endregion

    }
}
