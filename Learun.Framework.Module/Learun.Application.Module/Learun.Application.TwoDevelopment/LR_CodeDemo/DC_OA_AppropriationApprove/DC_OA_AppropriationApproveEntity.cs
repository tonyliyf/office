using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-04 18:21
    /// 描 述：DC_OA_AppropriationApprove
    /// </summary>
    public class DC_OA_AppropriationApproveEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_AAID")]
        public string F_AAId { get; set; }
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
        /// 拨付单位主键
        /// </summary>
        [Column("F_APPROPRIATIONCOMPANYID")]
        public string F_AppropriationCompanyId { get; set; }
        /// <summary>
        /// 拨付单位
        /// </summary>
        [Column("F_APPROPRIATIONCOMPANY")]
        public string F_AppropriationCompany { get; set; }
        /// <summary>
        /// 单据名称
        /// </summary>
        [Column("F_AANAME")]
        public string F_AAName { get; set; }
        /// <summary>
        /// F_ApproveMoney
        /// </summary>
        [Column("F_APPROVEMONEY")]
        public decimal? F_ApproveMoney { get; set; }
        /// <summary>
        /// 款项说明
        /// </summary>
        [Column("F_FUNDEXPLAIN")]
        public string F_FundExplain { get; set; }
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
        /// 经办部门主键
        /// </summary>
        [Column("F_HANDLEDEPARTMENTID")]
        public string F_HandleDepartmentId { get; set; }
        /// <summary>
        /// 经办人部门
        /// </summary>
        [Column("F_HANDLEDEPARTMENT")]
        public string F_HandleDepartment { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_AAId = Guid.NewGuid().ToString();
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
            this.F_AAId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

