using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-29 15:44
    /// 描 述：DC_OA_PerformanceCheck
    /// </summary>
    public interface DC_OA_PerformanceCheckIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageListH(string queryJson);
        /// <summary>
        /// 获取报表显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList1(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取部门领导年度显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList3(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取部门员工汇总显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList4(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取部门领导汇总显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList5(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取部门员工汇总显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList6(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取部门员工汇总显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList7(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取部门员工汇总显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList8(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取报表显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        DataTable GetPageList2(string queryJson);

        /// <summary>
        /// 获取报表显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        DataTable GetPageList12(string queryJson);
        /// <summary>
        /// 获取DC_OA_PerformanceCheck表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_PerformanceCheckEntity GetDC_OA_PerformanceCheckEntity(string keyValue);

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
        void SaveEntity(string keyValue, DC_OA_PerformanceCheckEntity entity);
        DC_OA_PerformanceCheckTemplateEntity GetTemplateEntity(int type);
        bool Commit(string keyValue, string checkerid);
        bool SaveEntityEx(string keyValue, DC_OA_PerformanceCheckEntity entity);
        #endregion

    }
}
