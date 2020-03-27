﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-12-04 14:52
    /// 描 述：formtable_main_150
    /// </summary>
    public interface formtable_main_150IBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<formtable_main_150Entity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取formtable_main_150表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        formtable_main_150Entity Getformtable_main_150Entity(string keyValue);
        DataTable Getformtable_main_150List(string F_PIId);

        formtable_main_150Entity GetLastformtable_main_150Entity(string F_PIId);
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
        void SaveEntity(string keyValue, formtable_main_150Entity entity);
        #endregion

    }
}
