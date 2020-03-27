using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-09 15:20
    /// 描 述：DC_OA_PartyMember
    /// </summary>
    public class DC_OA_PartyMemberEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PARTYMEMBERGUID")]
        public string F_PartyMemberGUID { get; set; }
        /// <summary>
        /// 是否系统用户,如果是系统内用户，则可从系统用户表中选取；0：否；1：是；默认值为1
        /// </summary>
        [Column("F_IFSYSUSER")]
        public int? F_IfSysUser { get; set; }
        /// <summary>
        /// 如果是系统用户,则从系统用户中选取，自动保存用户主键，同时自动填写姓名、性别等；如果不是系统用户，则为空
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column("F_GENDER")]
        public string F_Gender { get; set; }
        /// <summary>
        /// 民族，从数据字典表中选取，保存名族名称
        /// </summary>
        [Column("F_NATION")]
        public string F_Nation { get; set; }
        /// <summary>
        /// 籍贯，从行政区划表中选取
        /// </summary>
        [Column("F_NATIVEPLACE")]
        public string F_NativePlace { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Column("F_BIRTHDAY")]
        public DateTime? F_Birthday { get; set; }
        /// <summary>
        /// 婚姻状况，从数据字典中选取，保存婚姻状况名称
        /// </summary>
        [Column("F_MARITALSTATUS")]
        public int? F_MaritalStatus { get; set; }
        /// <summary>
        /// 学历学位，从数据字段中选取，保存学历名称
        /// </summary>
        [Column("F_DEGREE")]
        public string F_Degree { get; set; }
        /// <summary>
        /// 毕业院校及专业
        /// </summary>
        [Column("F_MAJORS")]
        public string F_Majors { get; set; }
        /// <summary>
        /// 申请入党时间
        /// </summary>
        [Column("F_APPLYPARTYTIME")]
        public DateTime? F_ApplyPartyTime { get; set; }
        /// <summary>
        /// 入党时间
        /// </summary>
        [Column("F_JOINPARTYTIME")]
        public DateTime? F_JoinPartyTime { get; set; }
        /// <summary>
        /// 党内职务名称，从数据字典中选取，保存党内职务名称
        /// </summary>
        [Column("F_PARTYDUTIESNAME")]
        public string F_PartyDutiesName { get; set; }
        /// <summary>
        /// 所在党组织主键,对应主表主键
        /// </summary>
        [Column("F_PARTYBRANCHGUID")]
        public string F_PartyBranchGUID { get; set; }
        /// <summary>
        /// 所在党组织编号，自动从主表获取
        /// </summary>
        [Column("F_PARTYBRANCHCODE")]
        public string F_PartyBranchCode { get; set; }
        /// <summary>
        /// 所在党组织名称，自动从主表获取
        /// </summary>
        [Column("F_PARTYBRANCHNAME")]
        public string F_PartyBranchName { get; set; }
        /// <summary>
        /// 参加工作时间
        /// </summary>
        [Column("F_JOINWORKTIME")]
        public string F_JoinWorkTime { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        [Column("F_COMPANYDUTIES")]
        public string F_CompanyDuties { get; set; }
        /// <summary>
        /// 职务类型名称，取自数据字典表，存储职务类型名称
        /// </summary>
        [Column("F_OCCUPATIONTYPE")]
        public string F_OccupationType { get; set; }
        /// <summary>
        /// 户籍所在地，从行政区划表中取
        /// </summary>
        [Column("F_CENSUSREGISTER")]
        public string F_CensusRegister { get; set; }
        /// <summary>
        /// 身份证号码，注意身份证的有效检测
        /// </summary>
        [Column("F_IDCARDNO")]
        public string F_IDCardNO { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        [Column("F_HOMEADDRESS")]
        public string F_HomeAddress { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Column("F_CONTACTINFO")]
        public string F_ContactInfo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARK")]
        public string F_Remark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 手机号,注意检测有效性，可用于消息提醒
        /// </summary>
        [Column("F_PHONENUMBER")]
        public string F_PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱地址，注意有效性检测，可用户消息提醒
        /// </summary>
        [Column("F_EMAIL")]
        public string F_EMail { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PartyMemberGUID = Guid.NewGuid().ToString();
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
            this.F_PartyMemberGUID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

