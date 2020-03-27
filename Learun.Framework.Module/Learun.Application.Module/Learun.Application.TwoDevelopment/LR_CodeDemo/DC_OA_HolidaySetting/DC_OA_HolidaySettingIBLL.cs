using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-04 11:32
    /// 描 述：节假日设置
    /// </summary>
    public interface DC_OA_HolidaySettingIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_HolidaySettingEntity> GetList( string queryJson );
        IEnumerable<DC_OA_HolidaySettingEntity> GetList(DateTime dtStart, DateTime dtEnd);

        
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_HolidaySettingEntity> GetPageList(Pagination pagination, string queryJson);
        IEnumerable<DC_OA_HolidaySettingEntity> GetHolidayDataByMonth(DateTime time);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_HolidaySettingEntity GetEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_HolidaySettingEntity entity);

        void InitHoliday(int startyear, int endyear);
        #endregion

    }
}
