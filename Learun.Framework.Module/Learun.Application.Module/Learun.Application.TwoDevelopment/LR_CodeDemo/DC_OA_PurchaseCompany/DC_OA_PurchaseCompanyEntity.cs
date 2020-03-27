using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-02 13:20
    /// 描 述：DC_OA_PurchaseCompany
    /// </summary>
    public class DC_OA_PurchaseCompanyEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PURCHASECOMPANYID")]
        public string F_PurchaseCompanyId { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        [Column("F_PURCHASECOMPANYNAME")]
        public string F_PurchaseCompanyName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Column("F_PURCHASECONTACTUSER")]
        public string F_PurchaseContactUser { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("F_PURCHASECONTACTPHONE")]
        public string F_PurchaseContactPhone { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
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
        /// 公司类型（代理单位，建设单位，采购单位）预留字段
        /// </summary>
        [Column("F_COMPANYTYPE")]
        public string F_CompanyType { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Column("F_ADDRESS")]
        public string F_Address { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PurchaseCompanyId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PurchaseCompanyId = keyValue;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

