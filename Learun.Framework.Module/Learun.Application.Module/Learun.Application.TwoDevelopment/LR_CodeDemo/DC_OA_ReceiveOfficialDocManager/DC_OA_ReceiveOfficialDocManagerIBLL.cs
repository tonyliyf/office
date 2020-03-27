﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.WorkFlow;


namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-14 12:10
    /// 描 述：收文管理
    /// </summary>
    public interface DC_OA_ReceiveOfficialDocManagerIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_ReceiveOfficialDocEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取LR_NWF_TaskLog表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<NWFTaskLogEntity> GetLR_NWF_TaskLogList(string keyValue);
        /// <summary>
        /// 获取DC_OA_ReceiveOfficialDoc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_ReceiveOfficialDocEntity GetDC_OA_ReceiveOfficialDocEntity(string keyValue);
        /// <summary>
        /// 获取LR_NWF_TaskLog表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        NWFTaskLogEntity GetNWFTaskLogEntity(string keyValue);
        /// <summary>
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_ReceiveOfficialDocEntity GetEntityByProcessId(string processId);
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
        void SaveEntity(string keyValue, DC_OA_ReceiveOfficialDocEntity entity, List<NWFTaskLogEntity> lR_NWF_TaskLogList);
        void DoComplete(string keyValue);
        List<string> GetAdviceByProcessId(string keyValue, string signaturePath);
        #endregion

        IEnumerable<ReciveFileReturnDataModel> GetDealIndexPageList(Pagination pagination, string queryJson);
        List<selectdata> GetProcessStep();
    }
}