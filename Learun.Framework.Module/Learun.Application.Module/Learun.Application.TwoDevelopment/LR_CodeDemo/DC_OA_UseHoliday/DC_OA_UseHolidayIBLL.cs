using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 15:47
    /// 描 述：DC_OA_UseHoliday
    /// </summary>
    public interface DC_OA_UseHolidayIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<UserEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_UseHoliday表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        UserEntity GetDC_OA_UseHolidayEntity(string keyValue);
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        List<TreeModel> GetTree();
        /// <summary>
        /// 获得总年假数
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        int GetTotalDaysByUserId(string Userid);

        /// <summary>
        /// 获得已用年假数
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        double GetUserDaysByUserId(string Userid);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity();
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, double days);
        #endregion

    }
}
