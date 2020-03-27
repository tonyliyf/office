using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-16 16:28
    /// 描 述：formtable_main_131
    /// </summary>
    public interface formtable_main_131IBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<formtable_main_131Entity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取formtable_main_131表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        formtable_main_131Entity Getformtable_main_131Entity(string keyValue);
        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        formtable_main_131Entity GetDC_EngineProject_Getformtable_main_131Entity(string keyValue);


        IEnumerable<formtable_main_131Entity> GetList(string SearchValue);
        #endregion

        #region 提交数据

        /// <summary>

        #endregion

    }
}
