using Learun.Util;
using System.Data;
using System.Collections.Generic;
using System;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 16:49
    /// 描 述：DC_OA_Attence
    /// </summary>
    public interface DC_OA_AttenceIBLL
    {
        #region 获取数据 

        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="queryJson">查询参数</param> 
        /// <returns></returns> 
        IEnumerable<DC_OA_AttenceEntity> GetPageList(Pagination pagination, string queryJson,string isPower);


        IEnumerable<DC_OA_AttenceEntity> GetPageList(string queryJson);

        DataTable GetAttenceRocord(string Month, string userid);
        DataTable GetAttenceRocord(DateTime dtStart,DateTime dtEnd, string userids);

        DataTable GetDataSource(string queryJson);

        /// <summary> 
        /// 获取DC_OA_Attence表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        DC_OA_AttenceEntity GetDC_OA_AttenceEntity(string keyValue);
        /// <summary> 
        /// 获取左侧树形数据 
        /// <summary> 
        /// <returns></returns> 
        List<TreeModel> GetTree();

        bool InsertDC_OA_AttenceByMonth(DateTime dtStart,DateTime dtEnd );
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
        void SaveEntity(string keyValue, DC_OA_AttenceEntity entity);
        #endregion

    }
}
