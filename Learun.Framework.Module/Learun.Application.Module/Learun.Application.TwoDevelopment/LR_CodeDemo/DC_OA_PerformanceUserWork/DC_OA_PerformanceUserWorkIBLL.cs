using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 11:12
    /// 描 述：DC_OA_PerformanceUserWork
    /// </summary>
    public interface DC_OA_PerformanceUserWorkIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceUserWorkModel> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_PerformanceUserWork表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_PerformanceUserWorkEntity GetDC_OA_PerformanceUserWorkEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkEntity entity);
        #endregion
        void DoExcute(string rid);
        bool ExistWork(string rid);
        bool BeginCheck(string wid);
        bool Evaluate1(string wid, string text, int agree);
        bool Evaluate2(string wid);
        bool Evaluate3(string wid);
        bool Evaluate4(string wid, string text, int agree, int? decScore, int? incScore, int? resultScore);
    }
}
