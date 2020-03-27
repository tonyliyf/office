using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-10 15:49
    /// 描 述：DC_OA_OutStock
    /// </summary>
    public class DC_OA_OutStockDetailsEntity
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_OutStockDetailsId
        /// </summary>
        [Column("DC_OA_OUTSTOCKDETAILSID")]
        public string DC_OA_OutStockDetailsId { get; set; }
        /// <summary>
        /// 主表id
        /// </summary>
        [Column("DC_OA_OUTSTOCKREFID")]
        public string DC_OA_OutStockRefId { get; set; }
        /// <summary>
        /// 办公用品Id
        /// </summary>
        [Column("DC_OA_WOODSREFID")]
        public string DC_OA_WoodsRefId { get; set; }
        /// <summary>
        /// 办公用品名称
        /// </summary>
        [Column("DC_OA_WOODSNAME")]
        public string DC_OA_WoodsName { get; set; }
        /// <summary>
        /// 办公用品编码
        /// </summary>
        [Column("DC_OA_WOODSNO")]
        public string DC_OA_WoodsNo { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>
        [Column("DC_OA_OUTSTOCKNUMS")]
        public decimal? DC_OA_OutStockNums { get; set; }
        /// <summary>
        /// 保留字段
        /// </summary>
        [Column("DC_OA_OUTSTOCKSTATES")]
        public string DC_OA_OutStockStates { get; set; }
        /// <summary>
        /// 单价（保留字段）
        /// </summary>
        [Column("DC_OA_OUTSTOCKPRICE")]
        public decimal? DC_OA_OutStockPrice { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_OutStockDetailsId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.DC_OA_OutStockDetailsId = keyValue;
        }
        #endregion
    }
}

