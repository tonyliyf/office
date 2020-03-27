using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-06 11:15
    /// 描 述：广告牌维修记录
    /// </summary>
    public interface BusStopBillboardsRepairRecordIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<formtable_main_129Entity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取表单信息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        formtable_main_129Entity GetDC_EngineProject_formtable_main_129Entity(string keyValue);
        #endregion




    }
}
