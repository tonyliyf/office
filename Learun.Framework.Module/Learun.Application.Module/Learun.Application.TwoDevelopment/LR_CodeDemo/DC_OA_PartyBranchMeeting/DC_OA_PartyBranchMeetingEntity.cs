using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-17 22:13
    /// 描 述：党员会议通知
    /// </summary>
    public class DC_OA_PartyBranchMeetingEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PARTYBRANCHMEETINGGUID")]
        public string F_PartyBranchMeetingGUID { get; set; }
        /// <summary>
        /// 党组织主键，取自党组织信息表
        /// </summary>
        [Column("F_PARTYBRANCHGUID")]
        public string F_PartyBranchGUID { get; set; }
        /// <summary>
        /// 会议开始时间
        /// </summary>
        [Column("F_MEETINGTIMESTART")]
        public DateTime? F_MeetingTimeStart { get; set; }
        /// <summary>
        /// 会议结束时间
        /// </summary>
        [Column("F_MEETINGTIMEEND")]
        public DateTime? F_MeetingTimeEnd { get; set; }
        /// <summary>
        /// 可选择系统内会议室，存储会议室主键，系统自动赋值地点为会议室名称，不选则为空
        /// </summary>
        [Column("F_MEETINGPLACEID")]
        public string F_MeetingPlaceId { get; set; }
        /// <summary>
        /// 会议地点，如选择会议室则自动取值会议室名称，否则用户填写
        /// </summary>
        [Column("F_MEETINGPLACE")]
        public string F_MeetingPlace { get; set; }
        /// <summary>
        /// 主持人主键，取自党员信息表，存储主键
        /// </summary>
        [Column("F_MEETINGCOMPERECODE")]
        public string F_MeetingCompereCode { get; set; }
        /// <summary>
        /// 取自党员信息表，存储党员名称
        /// </summary>
        [Column("F_MEETINGCOMPERENAME")]
        public string F_MeetingCompereName { get; set; }
        /// <summary>
        /// 记录人主键，取自党员信息表，存储主键
        /// </summary>
        [Column("F_MEETINGRECORDERCODE")]
        public string F_MeetingRecorderCode { get; set; }
        /// <summary>
        /// 记录人姓名，取自党员信息表，存储名称
        /// </summary>
        [Column("F_MEETINGRECORDERNAME")]
        public string F_MeetingRecorderName { get; set; }
        /// <summary>
        /// 会议事项简介
        /// </summary>
        [Column("F_MEETINGSUMMARY")]
        public string F_MeetingSummary { get; set; }
        /// <summary>
        /// 会议记录文档，用于记录会议详细内容
        /// </summary>
        [Column("F_MEETINGDOC")]
        public string F_MeetingDoc { get; set; }
        /// <summary>
        /// 会议附件，用于存储会议附件地址，可多附件，采用“|”分隔
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
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
        /// 与会者主键,取自党员信息表，多选存储主键，采用“|”分隔
        /// </summary>
        [Column("F_MEETINGCONVENTIONERID")]
        public string F_MeetingConventionerId { get; set; }
        /// <summary>
        /// 与会者,取自党员信息表，多选存储姓名，采用“|”分隔
        /// </summary>
        [Column("F_MEETINGCONVENTIONER")]
        public string F_MeetingConventioner { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PartyBranchMeetingGUID = Guid.NewGuid().ToString();
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
            this.F_PartyBranchMeetingGUID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

