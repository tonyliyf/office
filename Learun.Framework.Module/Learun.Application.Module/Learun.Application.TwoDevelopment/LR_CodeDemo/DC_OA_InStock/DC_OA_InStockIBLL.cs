using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 15:50
    /// 描 述：DC_OA_InStock
    /// </summary>
    public interface DC_OA_InStockIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_InStockEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_InStockDetails表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_InStockDetailsEntity> GetDC_OA_InStockDetailsList(string keyValue);
        /// <summary>
        /// 获取DC_OA_InStock表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_InStockEntity GetDC_OA_InStockEntity(string keyValue);
        /// <summary>
        /// 获取DC_OA_InStockDetails表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_InStockDetailsEntity GetDC_OA_InStockDetailsEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_InStockEntity entity,List<DC_OA_InStockDetailsEntity> dC_OA_InStockDetailsList);

        /// <summary>
        /// 入库操作
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <param name="dC_OA_InStockDetailsList"></param>
        void InStock(string keyValue, DC_OA_InStockEntity entity, List<DC_OA_InStockDetailsEntity> dC_OA_InStockDetailsList);
        #endregion

    }
}
