using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 15:47
    /// 描 述：DC_OA_UseHoliday
    /// </summary>
    public class DC_OA_UseHolidayEntity
    {
        #region 实体成员
        /// <summary>
        /// F_HolidayInfoId
        /// </summary>
        [Column("F_HOLIDAYINFOID")]
        public string F_HolidayInfoId { get; set; }
        /// <summary>
        /// F_UserId
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// F_CompanyId
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// F_DeptId
        /// </summary>
        [Column("F_DEPTID")]
        public string F_DeptId { get; set; }
        /// <summary>
        /// 已休年假
        /// </summary>
        [Column("F_USERHOLIDAY")]
        public double? F_UserHoliday { get; set; }
        /// <summary>
        /// 总年假
        /// </summary>
        [Column("F_TOTALHOLIDAY")]
        public double? F_TotalHoliday { get; set; }
        /// <summary>
        /// 剩余年假
        /// </summary>
        [Column("F_OTHERDAY")]
        public double? F_Otherday { get; set; }
        /// <summary>
        /// 有效标志 1，有效，0无效
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// F_CreateUserId
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// F_CreateDate
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// F_CreateUserName
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// F_ModifyDate
        /// </summary>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// F_ModifyUserId
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// F_ModifyUserName
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_HolidayInfoId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_HolidayInfoId = keyValue;
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

