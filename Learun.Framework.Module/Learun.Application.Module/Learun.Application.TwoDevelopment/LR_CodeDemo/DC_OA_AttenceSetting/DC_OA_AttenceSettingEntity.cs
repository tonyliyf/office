using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-16 17:54
    /// 描 述：考勤参数设置
    /// </summary>
    public class DC_OA_AttenceSettingEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_AttenceSettingId
        /// </summary>
        [Column("DC_OA_ATTENCESETTINGID")]
        public string DC_OA_AttenceSettingId { get; set; }
        /// <summary>
        /// 考勤中心点设置
        /// </summary>
        [Column("DC_OA_ATTENCECENTERPLACE")]
        public string DC_OA_AttenceCenterPlace { get; set; }
        /// <summary>
        /// 考勤中心经度
        /// </summary>
        [Column("DC_OA_ATTENCELONGITUDE")]
        public string DC_OA_AttenceLongitude { get; set; }
        /// <summary>
        /// 考勤中心纬度
        /// </summary>
        [Column("DC_OA_ATTENCELATITUDE")]
        public string DC_OA_AttenceLatitude { get; set; }
        /// <summary>
        /// 考勤距离有效范围
        /// </summary>
        [Column("DC_OA_ATTENCEDISTANCE")]
        public decimal? DC_OA_AttenceDistance { get; set; }
        /// <summary>
        /// 早上上班时间
        /// </summary>
        [Column("DC_OA_ATTENCETIMEUP1")]
        public DateTime? DC_OA_AttenceTimeUp1 { get; set; }
        /// <summary>
        /// 中午下班时间
        /// </summary>
        [Column("DC_OA_ATTENCETIMEOUT1")]
        public DateTime? DC_OA_AttenceTimeOut1 { get; set; }
        /// <summary>
        /// 下午上班时间
        /// </summary>
        [Column("DC_OA_ATTENCETTIMEUP2")]
        public DateTime? DC_OA_AttencetTimeUp2 { get; set; }
        /// <summary>
        /// 下午下班时间
        /// </summary>
        [Column("DC_OA_ATTENCETIMEOUT2")]
        public DateTime? DC_OA_AttenceTimeOut2 { get; set; }
        /// <summary>
        /// 中班上班时间（预留字段）
        /// </summary>
        [Column("DC_OA_ATTENCETIMEUP3")]
        public DateTime? DC_OA_AttenceTimeUp3 { get; set; }
        /// <summary>
        /// 中班下班时间（预留字段）
        /// </summary>
        [Column("DC_OA_ATTENCETIMEOUT3")]
        public DateTime? DC_OA_AttenceTimeOut3 { get; set; }
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
        public int? F_Description { get; set; }
        /// <summary>
        /// 晚班下班时间
        /// </summary>
        [Column("DC_OA_ATTENCETIMEOUT4")]
        public DateTime? DC_OA_AttenceTimeOut4 { get; set; }
        /// <summary>
        /// 晚班上班时间
        /// </summary>
        [Column("DC_OA_ATTENCETIMEUP4")]
        public DateTime? DC_OA_AttenceTimeUp4 { get; set; }
        /// <summary>
        /// 考勤类型（平常，夏令时）
        /// </summary>
        [Column("DC_OAATTENCETYPE")]
        public string DC_OAAttenceType { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_AttenceSettingId = Guid.NewGuid().ToString();
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
            this.DC_OA_AttenceSettingId = keyValue;
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

