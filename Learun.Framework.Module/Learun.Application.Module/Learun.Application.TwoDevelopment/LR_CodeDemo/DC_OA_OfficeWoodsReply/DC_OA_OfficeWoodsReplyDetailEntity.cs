using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 16:28
    /// 描 述：DC_OA_OfficeWoodsReply
    /// </summary>
    public class DC_OA_OfficeWoodsReplyDetailEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_REPLYDETAILID")]
        public string F_ReplyDetailId { get; set; }
        /// <summary>
        /// 主表主键
        /// </summary>
        [Column("F_REPLYID")]
        public string F_ReplyId { get; set; }
        /// <summary>
        /// 物品主键
        /// </summary>
        [Column("F_WOODID")]
        public string F_WoodId { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        [Column("F_WOODNAME")]
        public string F_WoodName { get; set; }
        /// <summary>
        /// 物品规格型号
        /// </summary>
        [Column("F_WOODSPEC")]
        public string F_WoodSpec { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column("F_NUMS")]
        public double? F_Nums { get; set; }
        /// <summary>
        /// 物品单位
        /// </summary>
        [Column("F_WOODUNIT")]
        public string F_WoodUnit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_ReplyDetailId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_ReplyDetailId = keyValue;
        }
        #endregion
    }
}

