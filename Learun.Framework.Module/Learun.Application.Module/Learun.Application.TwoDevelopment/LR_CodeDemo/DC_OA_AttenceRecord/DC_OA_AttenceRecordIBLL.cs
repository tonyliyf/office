﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 16:32
    /// 描 述：打卡记录
    /// </summary>
    public interface DC_OA_AttenceRecordIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表分页数据
        /// <summary>
        /// <param name="pagination">查询参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_AttenceRecordEntity> GetPageList(Pagination pagination, string queryJson);


        IEnumerable<DC_OA_AttenceRecordEntity> GetMyPageList(UserInfo userInfo,Pagination pagination, string queryJson);
        DataTable GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_AttenceRecordEntity> GetList(string queryJson);


        IEnumerable<DC_OA_AttenceRecordEntity> GetList(DateTime dt ,DateTime dtEnd);
        /// <summary>
        /// 获取DC_OA_AttenceRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_AttenceRecordEntity GetDC_OA_AttenceRecordEntity(string keyValue);
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
        void SaveEntity(UserInfo userInfo, string keyValue, DC_OA_AttenceRecordEntity entity);

        void SaveRecord(UserInfo userInfo, DC_OA_AttenceRecordEntity entity);


        bool SaveRecord(UserInfo userInfo,DC_OA_AttenceRecordEntity entity, ref string Msg);

        bool SaveRecord(UserInfo userInfo, string longitude, string latitude, ref string Msg);
        #endregion

    }
}