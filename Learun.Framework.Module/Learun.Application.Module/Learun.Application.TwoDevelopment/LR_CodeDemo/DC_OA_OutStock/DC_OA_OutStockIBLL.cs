using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-10 15:49
    /// 描 述：DC_OA_OutStock
    /// </summary>
    public interface DC_OA_OutStockIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DC_OA_OutStockEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取DC_OA_OutStockDetails表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<DC_OA_OutStockDetailsEntity> GetDC_OA_OutStockDetailsList(string keyValue);
        /// <summary>
        /// 获取DC_OA_OutStock表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OutStockEntity GetDC_OA_OutStockEntity(string keyValue);
        /// <summary>
        /// 获取DC_OA_OutStockDetails表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        DC_OA_OutStockDetailsEntity GetDC_OA_OutStockDetailsEntity(string keyValue);
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
        void SaveEntity(string keyValue, DC_OA_OutStockEntity entity,List<DC_OA_OutStockDetailsEntity> dC_OA_OutStockDetailsList);
        #endregion
        bool OutStock(string keyValue, DC_OA_OutStockEntity entity, List<DC_OA_OutStockDetailsEntity> dC_OA_InStockDetailsList);
    }
}
