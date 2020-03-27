using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 10:08
    /// 描 述：DC_ASSETS_ContactUnit
    /// </summary>
    public class DC_ASSETS_ContactUnitEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_CUID")]
        public string F_CUId { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        [Column("F_UNITCODE")]
        public string F_UnitCode { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [Column("F_UNITNAME")]
        public string F_UnitName { get; set; }
        /// <summary>
        /// 单位类型，取自数据字典表，如供应商、经销商、生产厂商、服务商等
        /// </summary>
        [Column("F_UNITTYPE")]
        public string F_UnitType { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Column("F_CONTACTS")]
        public string F_Contacts { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("F_CONTACTPHONE")]
        public string F_ContactPhone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Column("F_CONTACTFAX")]
        public string F_ContactFax { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [Column("F_POSTCODE")]
        public string F_PostCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Column("F_CONTACTADDRESS")]
        public string F_ContactAddress { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Column("F_CONTACTEMAIL")]
        public string F_ContactEmail { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        [Column("F_DUTYNUMBER")]
        public string F_DutyNumber { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        [Column("F_DEPOSITBANK")]
        public string F_DepositBank { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        [Column("F_CONTACTACCOUNT")]
        public string F_ContactAccount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 使用状态，0：有效；1：停止使用；默认0
        /// </summary>
        [Column("F_USESTATE")]
        public int? F_UseState { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 记录人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            UserInfo user = LoginUserInfo.Get();
            this.F_CUId = Guid.NewGuid().ToString();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateUser = user.realName;
            this.F_CreateDatetime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_CUId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

