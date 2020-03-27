using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-17 11:09
    /// 描 述：DC_OA_MeetingRecord
    /// </summary>
    public interface DC_OA_MeetingRecordIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_MeetingRecordEntity> GetPageList(Pagination pagination, string queryJson);

        ///// <summary>
        ///// 获取页面显示列表数据
        ///// <summary>
        ///// <param name="queryJson">查询参数</param>
        ///// <returns></returns>
        //IEnumerable<DC_OA_MeetingRecordEntity> GetPageList1(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_MeetingRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_MeetingRecordEntity GetDC_OA_MeetingRecordEntity(string keyValue);

        /// <summary>
        /// 获取DC_OA_MeetingRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_MeetingRecordEntity GetDeptNoticeEntity(string keyValue);

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
        void SaveEntity(string keyValue, DC_OA_MeetingRecordEntity entity);
        #endregion

    }
}
