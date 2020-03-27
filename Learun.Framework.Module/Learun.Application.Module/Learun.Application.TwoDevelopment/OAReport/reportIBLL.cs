using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.OAReport
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 10:44
    /// 描 述：报表
    /// </summary>
    public interface reportIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        DataTable GetList(string queryJson);

        DataTable GetLeaderData(DateTime dtStart,DateTime dtEnd);


        DataTable GetFlowData();
    }
}
        #endregion 

