using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-06 16:45
    /// 描 述：DC_OA_PurchaseDeposit
    /// </summary>
    public class DC_OA_PurchaseDepositDetailEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_PurchaseDepositDetailid
        /// </summary>
        [Column("F_PURCHASEDEPOSITDETAILID")]
        public string F_PurchaseDepositDetailid { get; set; }
        /// <summary>
        /// 引用主表主键
        /// </summary>
        [Column("F_PURCHASEDEPOSITREFID")]
        public string F_PurchaseDepositRefId { get; set; }
        /// <summary>
        /// 组织名称
        /// </summary>
        [Column("F_ORGANIZENAME")]
        public string F_organizeName { get; set; }
        /// <summary>
        /// 退还金额
        /// </summary>
        [Column("F_MONEY")]
        public decimal? F_money { get; set; }
        /// <summary>
        /// 是否退还
        /// </summary>
        [Column("F_ISRETURN")]
        public string F_ISReturn { get; set; }
        /// <summary>
        /// 不退还原因
        /// </summary>
        [Column("F_NOREASON")]
        public string F_NoReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRPITION")]
        public string F_Descrpition { get; set; }
        /// <summary>
        /// F_OrganizeId
        /// </summary>
        [Column("F_ORGANIZEID")]
        public string F_OrganizeId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PurchaseDepositDetailid = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PurchaseDepositDetailid = keyValue;
        }
        #endregion
    }
}

