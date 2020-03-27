using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-21 16:31
    /// 描 述：DC_ASSETS_LandBaseIdleFeesPayment
    /// </summary>
    public class DC_ASSETS_LandBaseIdleFeesPaymentEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_LBIFPID")]
        public string F_LBIFPId { get; set; }
        /// <summary>
        /// 土地基本信息主键
        /// </summary>
        [Column("F_LBIID")]
        public string F_LBIId { get; set; }
        /// <summary>
        /// 缴纳单位
        /// </summary>
        [Column("F_PAYUNIT")]
        public string F_PayUnit { get; set; }
        /// <summary>
        /// 缴纳银行
        /// </summary>
        [Column("F_PAYBANK")]
        public string F_PayBank { get; set; }
        /// <summary>
        /// 缴纳账户
        /// </summary>
        [Column("F_PAYACCOUNT")]
        public string F_PayAccount { get; set; }
        /// <summary>
        /// 缴纳金额
        /// </summary>
        [Column("F_PAYMONEY")]
        public decimal? F_PayMoney { get; set; }
        /// <summary>
        /// 缴纳日期
        /// </summary>
        [Column("F_PAYDATE")]
        public DateTime? F_PayDate { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [Column("F_HANDLEDESCRIBE")]
        public string F_HandleDescribe { get; set; }
        /// <summary>
        /// 办理人主键
        /// </summary>
        [Column("F_HANDLEUSERID")]
        public string F_HandleUserId { get; set; }
        /// <summary>
        /// 办理人
        /// </summary>
        [Column("F_HANDLEUSER")]
        public string F_HandleUser { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
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
            this.F_LBIFPId = Guid.NewGuid().ToString();
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateDatetime = DateTime.Now;
            this.F_CreateUser = user.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_LBIFPId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

