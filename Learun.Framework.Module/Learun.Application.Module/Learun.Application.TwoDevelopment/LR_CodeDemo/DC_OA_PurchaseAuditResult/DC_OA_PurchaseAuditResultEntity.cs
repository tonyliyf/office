using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-05 15:28
    /// 描 述：DC_OA_PurchaseAuditResult
    /// </summary>
    public class DC_OA_PurchaseAuditResultEntity 
    {
        #region 实体成员
        /// <summary>
        /// 引用主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEAUDITREFID")]
        public string F_PurchaseAuditRefId { get; set; }
        /// <summary>
        /// 经办人联系电话
        /// </summary>
        /// <returns></returns>
        [Column("F_DEALUSERPHONE")]
        public string F_DealUserPhone { get; set; }
        /// <summary>
        /// 预算金额（单位万元）
        /// </summary>
        /// <returns></returns>
        [Column("F_DEALMONEY")]
        public decimal? F_DealMoney { get; set; }
        /// <summary>
        /// 采购文件附件
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEFILE")]
        public string F_PurchaseFile { get; set; }
        /// <summary>
        /// 采购文件附件清单
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASELISTFILE")]
        public string F_PurchaseListFile { get; set; }
        /// <summary>
        /// 采购方式
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEMETHOD")]
        public string F_PurchaseMethod { get; set; }
        /// <summary>
        /// 代理服务费（单位元）
        /// </summary>
        /// <returns></returns>
        [Column("F_SERVICEMONEY")]
        public decimal? F_ServiceMoney { get; set; }
        /// <summary>
        /// 交易平台(自采、集团、枝江中心)
        /// </summary>
        /// <returns></returns>
        [Column("F_BUYPLATFORM")]
        public string F_buyPlatform { get; set; }
        /// <summary>
        /// 采购代理公司
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASECOMPANYID")]
        public string F_PurchaseCompanyId { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 经办人ID
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 当前部门Id
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTDEPTID")]
        public string F_CurrentDeptId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 补充资料
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 补充附件
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTIONFILE")]
        public string F_DescriptionFile { get; set; }
        /// <summary>
        /// 采购项目名称
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASENAME")]
        public string F_PurchaseName { get; set; }
        /// <summary>
        /// 采购项目编号
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEPROJECTNO")]
        public string F_PurchaseProjectNo { get; set; }
        /// <summary>
        /// 当前用户公司
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
        /// <summary>
        /// 采购图纸
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEIMAGEFILE")]
        public string F_PurchaseImageFile { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEAUDITRESULTID")]
        public string F_PurchaseAuditResultId { get; set; }
        /// <summary>
        /// 中标公司
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEINCOMPANYID")]
        public string F_PurchaseInCompanyId { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASEMONEY")]
        public decimal? F_PurchaseMoney { get; set; }
        /// <summary>
        /// 采购公司
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTCOMPANYNAME")]
        public string F_CurrentCompanyName { get; set; }
        /// <summary>
        /// 采购部门
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTDEPTNAME")]
        public string F_CurrentDeptName { get; set; }
        /// <summary>
        /// 采购代理机构名称
        /// </summary>
        /// <returns></returns>
        [Column("F_PURCHASECOMPANYNAME")]
        public string F_PurchaseCompanyName { get; set; }


        /// <summary>
        /// 采购项目分类
        /// </summary>
        [Column("F_PURCHASEPROJECTTYPE")]
        public string F_PurchaseProjectType { get; set; }


        /// <summary>
        /// 采购物资分类
        /// </summary>
        [Column("F_PURCHASEWOODTYPE")]
        public string F_PurchaseWoodType { get; set; }


        /// <summary>
        /// 是否同意
        /// </summary>
        /// <returns></returns>
        [Column("Is_agree")]
        public string Is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PurchaseAuditResultId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }

        public void Create(bool bGuid)
        {
            //this.F_PurchaseAuditResultId = Guid.NewGuid().ToString();
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
            this.F_PurchaseAuditResultId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

