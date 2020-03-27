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
    public class DC_OA_PurchaseDepositEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PURCHASEDEPOSITID")]
        public string F_PurchaseDepositId { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 经办人ID
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
        /// 采购项目名称
        /// </summary>
        [Column("F_PURCHASENAME")]
        public string F_PurchaseName { get; set; }
        /// <summary>
        /// 采购项目编号
        /// </summary>
        [Column("F_PURCHASEPROJECTNO")]
        public string F_PurchaseProjectNo { get; set; }
        /// <summary>
        /// 当前用户公司
        /// </summary>
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
        /// <summary>
        /// 采购图纸
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// 投标保证金
        /// </summary>
        [Column("F_DEPOSITMONEY")]
        public decimal? F_DepositMoney { get; set; }
        /// <summary>
        /// 引用采购申请表主键
        /// </summary>
        [Column("F_DC_OAPURCHASEAYDUTREFID")]
        public string F_DC_OAPurchaseAydutRefid { get; set; }
        /// <summary>
        /// F_CurrentCompanyName
        /// </summary>
        [Column("F_CURRENTCOMPANYNAME")]
        public string F_CurrentCompanyName { get; set; }
        /// <summary>
        /// F_CurrentDeptName
        /// </summary>
        [Column("F_CURRENTDEPTNAME")]
        public string F_CurrentDeptName { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
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
            this.F_PurchaseDepositId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }

        public void Create(bool bGuid)
        {
           // this.F_PurchaseDepositId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
          //  UserInfo userInfo = LoginUserInfo.Get();
          //  this.F_CreateUserId = userInfo.userId;
          //  this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PurchaseDepositId = keyValue;
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

