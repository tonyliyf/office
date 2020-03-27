﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-06 16:45
    /// 描 述：DC_OA_PurchaseDeposit
    /// </summary>
    public interface DC_OA_PurchaseDepositIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_PurchaseDepositEntity> GetPageList(Pagination pagination, string queryJson,string isPower);
        /// <summary>
        /// 报表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_PurchaseDepositDetail表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_PurchaseDepositDetailEntity> GetDC_OA_PurchaseDepositDetailList(string keyValue);
        /// <summary>
        /// 获取DC_OA_PurchaseDeposit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_PurchaseDepositEntity GetDC_OA_PurchaseDepositEntity(string keyValue);
        /// <summary>
        /// 获取DC_OA_PurchaseDepositDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_PurchaseDepositDetailEntity GetDC_OA_PurchaseDepositDetailEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_PurchaseDepositEntity entity, List<DC_OA_PurchaseDepositDetailEntity> dC_OA_PurchaseDepositDetailList);
        #endregion
        DataTable GetListEntityEx(string keyValue);
        DataTable GetEntityEx(string keyValue);


      //  IEnumerable<DC_OA_PurchaseDepositEntity> GetListbyUserid(string userid);
    }
}
