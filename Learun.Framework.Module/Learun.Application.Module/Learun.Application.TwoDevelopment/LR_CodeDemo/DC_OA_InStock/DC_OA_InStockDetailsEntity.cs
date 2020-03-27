using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 15:50
    /// 描 述：DC_OA_InStock
    /// </summary>
    public class DC_OA_InStockDetailsEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_InStockDetailsId
        /// </summary>
        [Column("DC_OA_INSTOCKDETAILSID")]
        public string DC_OA_InStockDetailsId { get; set; }
        /// <summary>
        /// 主表id
        /// </summary>
        [Column("DC_OA_INSTOCKREFID")]
        public string DC_OA_InStockRefId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        [Column("DC_OA_WOODSREFID")]
        public string DC_OA_WoodsRefId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Column("DC_OA_WOODSNAME")]
        public string DC_OA_WoodsName { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        [Column("DC_OA_WOODSNO")]
        public string DC_OA_WoodsNo { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        [Column("DC_OA_INSTOCKNUMS")]
        public decimal? DC_OA_InStockNums { get; set; }
        /// <summary>
        /// 保留字段
        /// </summary>
        [Column("DC_OA_INSTOCKSTATES")]
        public string DC_OA_InStockStates { get; set; }
        /// <summary>
        /// 单价（保留字段）
        /// </summary>
        [Column("DC_OA_INSTOCKPRICE")]
        public decimal? DC_OA_InStockPrice { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_InStockDetailsId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.DC_OA_InStockDetailsId = keyValue;
        }
        #endregion
    }
}

