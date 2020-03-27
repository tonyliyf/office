using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 16:37
    /// 描 述：库存盘查
    /// </summary>
    public class DC_OA_StockWoodsEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_StockWoodsId
        /// </summary>
        [Column("DC_OA_STOCKWOODSID")]
        public string DC_OA_StockWoodsId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        [Column("DC_OA_WOODSREFID")]
        public string DC_OA_WoodsRefId { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [Column("DC_OA_WOODSNAME")]
        public string DC_OA_WoodsName { get; set; }
        /// <summary>
        /// 物品规格
        /// </summary>
        [Column("DC_OA_WOODSSPC")]
        public string DC_OA_WoodsSpc { get; set; }
        /// <summary>
        /// 物品类型
        /// </summary>
        [Column("DC_OA_WOODTYPE")]
        public string DC_OA_WoodType { get; set; }
        /// <summary>
        /// 物品数量
        /// </summary>
        [Column("DC_OA_WOODSNUMBERS")]
        public decimal? DC_OA_WoodsNumbers { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Column("DC_OA_WOODSUNIT")]
        public string DC_OA_WoodsUnit { get; set; }
        /// <summary>
        /// 最低警戒值
        /// </summary>
        [Column("DC_OA_LOWNUMBER")]
        public decimal? DC_OA_LowNumber { get; set; }
        /// <summary>
        /// 最高警戒值
        /// </summary>
        [Column("DC_OA_HIGHNUMBER")]
        public decimal? DC_OA_HighNumber { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [Column("DC_STOCKNAME")]
        public string DC_StockName { get; set; }
        /// <summary>
        /// 仓库堆放位置
        /// </summary>
        [Column("DC_STOCKPOSTION")]
        public string DC_StockPostion { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_StockWoodsId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.DC_OA_StockWoodsId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

