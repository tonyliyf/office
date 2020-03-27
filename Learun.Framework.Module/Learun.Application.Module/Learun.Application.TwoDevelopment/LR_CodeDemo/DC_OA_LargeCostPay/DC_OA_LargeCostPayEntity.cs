using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-07 13:14
    /// 描 述：DC_OA_LargeCostPay
    /// </summary>
    public class DC_OA_LargeCostPayEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_LCPID")]
        public string F_LCPId { get; set; }
        /// <summary>
        /// 资金费用类型主键
        /// </summary>
        [Column("F_COSTTYPEID")]
        public string F_CostTypeId { get; set; }
        /// <summary>
        /// 资金费用类型名称
        /// </summary>
        [Column("F_COSTTYPENAME")]
        public string F_CostTypeName { get; set; }
        /// <summary>
        /// 报销单位主键
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// 申请单位
        /// </summary>
        [Column("F_COMPANY")]
        public string F_Company { get; set; }
        /// <summary>
        /// 客户单位主键
        /// </summary>
        [Column("F_CUSTOMERID")]
        public string F_CustomerId { get; set; }
        /// <summary>
        /// 客户单位
        /// </summary>
        [Column("F_CUSTOMER")]
        public string F_Customer { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        [Column("F_APPLICATIONDATE")]
        public DateTime? F_ApplicationDate { get; set; }
        /// <summary>
        /// 单据张数
        /// </summary>
        [Column("F_BILLSNUM")]
        public int? F_BillsNUM { get; set; }
        /// <summary>
        /// 附件张数
        /// </summary>
        [Column("F_ATTACHMENTSNUM")]
        public int? F_AttachmentsNUM { get; set; }
        /// <summary>
        /// 资金用途
        /// </summary>
        [Column("F_MONEYUSE")]
        public string F_MoneyUse { get; set; }
        /// <summary>
        /// 报销金额
        /// </summary>
        [Column("F_MONEY")]
        public decimal? F_Money { get; set; }
        /// <summary>
        /// 收款银行
        /// </summary>
        [Column("F_RECEIVEBANK")]
        public string F_ReceiveBank { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 制表人部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 制表人部门
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 制表人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 制表人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 制表时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 流程主键
        /// </summary>
        [Column("F_FLOWID")]
        public string F_FlowId { get; set; }
        /// <summary>
        /// 流程状态,对应流程可选择用于状态保存
        /// </summary>
        [Column("F_FLOWSTATE")]
        public int? F_FlowState { get; set; }
        /// <summary>
        /// 经办人主键
        /// </summary>
        [Column("F_HANDLEUSERID")]
        public string F_HandleUserId { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [Column("F_HANDLEUSER")]
        public string F_HandleUser { get; set; }
        /// <summary>
        /// Is_agree
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_LCPId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_LCPId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

