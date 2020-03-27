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
    public class DC_OA_InStockEntity 
    {
        #region 实体成员
        /// <summary>
        /// 入库单据id
        /// </summary>
        [Column("DC_OA_INSTOCKID")]
        public string DC_OA_InStockId { get; set; }
        /// <summary>
        /// 入库单据编号
        /// </summary>
        [Column("DC_OA_INSTOCKNO")]
        public string DC_OA_InStockNo { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        [Column("DC_OA_INSTOCKTIME")]
        public DateTime? DC_OA_InStockTime { get; set; }
        /// <summary>
        /// 入库状态（1，未入库，2已入库）
        /// </summary>
        [Column("DC_OA_INSTOCKSTATE")]
        public string DC_OA_InStockState { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
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
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public int? F_Description { get; set; }
        /// <summary>
        /// 入库总金额
        /// </summary>
        [Column("DC_OAINSTOCKMONEY")]
        public decimal? DC_OAInStockMoney { get; set; }
        /// <summary>
        /// 来自办公申请单据
        /// </summary>
        [Column("DC_OA_FROMNO")]
        public string DC_OA_FromNo { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_InStockId = Guid.NewGuid().ToString();
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
            this.DC_OA_InStockId = keyValue;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

