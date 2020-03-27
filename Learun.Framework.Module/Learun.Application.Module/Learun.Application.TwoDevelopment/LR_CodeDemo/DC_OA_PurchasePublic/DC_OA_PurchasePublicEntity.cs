using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicEntity
    {
        #region 实体成员 
        /// <summary> 
        /// 主键 
        /// </summary> 
        [Column("F_PURCHASEPUBLICID")]
        public string F_PurchasePublicId { get; set; }
        /// <summary> 
        /// 采购审核表主键 
        /// </summary> 
        [Column("F_PURCHASEAUDITREFID")]
        public string F_PurchaseAuditRefId { get; set; }
        /// <summary> 
        /// 当前用户公司 
        /// </summary> 
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
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
        /// 当前部门Id 
        /// </summary> 
        [Column("F_CURRENTDEPTID")]
        public string F_CurrentDeptId { get; set; }
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
        /// <summary> 
        /// 备注 
        /// </summary> 
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary> 
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意 
        /// </summary> 
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary> 
        /// 当前公司 
        /// </summary> 
        [Column("F_CURRENTCOMPANYNAME")]
        public string F_CurrentCompanyName { get; set; }
        /// <summary> 
        /// 当前部门 
        /// </summary> 
        [Column("F_CURRENTDEPTNAME")]
        public string F_CurrentDeptName { get; set; }
        /// <summary> 
        /// 项目名称 
        /// </summary> 
        [Column("F_PURCHASENAME")]
        public string F_PurchaseName { get; set; }
        /// <summary> 
        /// 交易方式 
        /// </summary> 
        [Column("F_PURCHASEMETHOD")]
        public string F_PurchaseMethod { get; set; }
        /// <summary> 
        /// 交易平台 
        /// </summary> 
        [Column("F_BUYPLATFORM")]
        public string F_buyPlatform { get; set; }
        /// <summary> 
        /// 交易金额 
        /// </summary> 
        [Column("F_DEALMONEY")]
        public decimal? F_DealMoney { get; set; }
        /// <summary> 
        /// 经办人电话 
        /// </summary> 
        [Column("F_DEALUSERPHONE")]
        public string F_DealUserPhone { get; set; }
        /// <summary> 
        /// 项目编号 
        /// </summary> 
        [Column("F_PURCHASEPROJECTNO")]
        public string F_PurchaseProjectNo { get; set; }
        #endregion

        #region 扩展操作 
        /// <summary> 
        /// 新增调用 
        /// </summary> 
        public void Create()
        {
            this.F_PurchasePublicId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }

        public void Create(bool bGuid)
        {
            this.F_PurchasePublicId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
           // UserInfo userInfo = LoginUserInfo.Get();
           // this.F_CreateUserId = userInfo.userId;
           // this.F_CreateUserName = userInfo.realName;
        }
        /// <summary> 
        /// 编辑调用 
        /// </summary> 
        /// <param name="keyValue"></param> 
        public void Modify(string keyValue)
        {
            this.F_PurchasePublicId = keyValue;
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

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicDetailEntity
    {
        #region 实体成员 
        /// <summary> 
        /// DC_OA_PurchasePublicDetailId 
        /// </summary> 
        [Column("DC_OA_PURCHASEPUBLICDETAILID")]
        public string DC_OA_PurchasePublicDetailId { get; set; }
        /// <summary> 
        /// DC_OA_PurchasePublicRefId 
        /// </summary> 
        [Column("DC_OA_PURCHASEPUBLICREFID")]
        public string DC_OA_PurchasePublicRefId { get; set; }
        /// <summary> 
        /// 发布时间 
        /// </summary> 
        [Column("F_PUBLICTIME")]
        public DateTime? F_PublicTime { get; set; }
        /// <summary> 
        /// 澄清公告时间 
        /// </summary> 
        [Column("F_AUDITPUBLICTIME")]
        public DateTime? F_AuditPublicTime { get; set; }
        /// <summary> 
        /// 第二次澄清公告时间  
        /// </summary> 
        [Column("F_SECONDAUDITPUBLICTIME")]
        public DateTime? F_SecondAuditPublicTime { get; set; }
        /// <summary> 
        /// 开标时间 
        /// </summary> 
        [Column("F_OPENTIME")]
        public DateTime? F_OpenTime { get; set; }
        /// <summary> 
        /// 延期开标时间 
        /// </summary> 
        [Column("F_OPENTIMELATER")]
        public DateTime? F_OpenTimelater { get; set; }
        /// <summary> 
        ///  是否采购成功  
        /// </summary> 
        [Column("F_ISPURCHASE")]
        public string F_IsPurchase { get; set; }
        #endregion

        #region 扩展操作 
        /// <summary> 
        /// 新增调用 
        /// </summary> 
        public void Create()
        {
            this.DC_OA_PurchasePublicDetailId = Guid.NewGuid().ToString();
        }
        /// <summary> 
        /// 编辑调用 
        /// </summary> 
        /// <param name="keyValue"></param> 
        public void Modify(string keyValue)
        {
            this.DC_OA_PurchasePublicDetailId = keyValue;
        }
        #endregion
    }
}
