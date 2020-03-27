using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 21:30
    /// 描 述：DC_OA_CostReimbursementGather
    /// </summary>
    public class DC_OA_CostReimbursementGatherEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CRGID")]
        public string F_CRGId { get; set; }
        /// <summary>
        /// 资金费用类型主键
        /// </summary>
        /// <returns></returns>
        [Column("F_COSTTYPEID")]
        public string F_CostTypeId { get; set; }
        /// <summary>
        /// 资金费用类型名称
        /// </summary>
        /// <returns></returns>
        [Column("F_COSTTYPENAME")]
        public string F_CostTypeName { get; set; }
        /// <summary>
        /// 报销单位主键
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTCOMPANYID")]
        public string F_ReimbursementCompanyId { get; set; }
        /// <summary>
        /// 报销单位
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTCOMPANY")]
        public string F_ReimbursementCompany { get; set; }
        /// <summary>
        /// 报销部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTDEPARTMENTID")]
        public string F_ReimbursementDepartmentId { get; set; }
        /// <summary>
        /// 报销部门
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTDEPARTMENT")]
        public string F_ReimbursementDepartment { get; set; }
        /// <summary>
        /// 报销时间
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTDATE")]
        public DateTime? F_ReimbursementDate { get; set; }
        /// <summary>
        /// 单据张数
        /// </summary>
        /// <returns></returns>
        [Column("F_BILLSNUM")]
        public int? F_BillsNUM { get; set; }
        /// <summary>
        /// 附件张数
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENTSNUM")]
        public int? F_AttachmentsNUM { get; set; }
        /// <summary>
        /// 报销事项
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTCONTENT")]
        public string F_REimbursementContent { get; set; }
        /// <summary>
        /// 报销金额
        /// </summary>
        /// <returns></returns>
        [Column("F_REIMBURSEMENTMONEY")]
        public decimal? F_ReimbursementMoney { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <returns></returns>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 制表人部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 制表人部门
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 制表人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 制表人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 制表时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 流程主键
        /// </summary>
        /// <returns></returns>
        [Column("F_FLOWID")]
        public string F_FlowId { get; set; }
        /// <summary>
        /// 流程状态,对应流程可选择用于状态保存
        /// </summary>
        /// <returns></returns>
        [Column("F_FLOWSTATE")]
        public int? F_FlowState { get; set; }
        /// <summary>
        /// 经办人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_HANDLEUSERID")]
        public string F_HandleUserId { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        /// <returns></returns>
        [Column("F_HANDLEUSER")]
        public string F_HandleUser { get; set; }

        /// <summary>
        /// -1,驳回，2审批同意，1审批当中
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
            this.F_CRGId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
        }

        public void Create(bool isfalse)
        {
          
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_CRGId = keyValue;
        }
        #endregion
    }
}

