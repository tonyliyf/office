using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 14:53
    /// 描 述：DC_EngineProject_MeetingRecord
    /// </summary>
    public class DC_EngineProject_MeetingRecordEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_MRID")]
        public string F_MRId { get; set; }
        /// <summary>
        /// 会议编号，取系统编码
        /// </summary>
        [Column("F_MRNUM")]
        public string F_MRNum { get; set; }
        /// <summary>
        /// 会议主题
        /// </summary>
        [Column("F_MEETINGTHEME")]
        public string F_MeetingTheme { get; set; }
        /// <summary>
        /// 会议地址
        /// </summary>
        [Column("F_MEETINGADDRESS")]
        public string F_MeetingAddress { get; set; }
        /// <summary>
        /// 召开部门，取部门信息表
        /// </summary>
        [Column("F_CONVENINGDEPARTMENT")]
        public string F_ConveningDepartment { get; set; }
        /// <summary>
        /// 召集人，取召开部门下的用户
        /// </summary>
        [Column("F_CONVENOR")]
        public string F_Convenor { get; set; }
        /// <summary>
        /// 主持人，填写，存在外单位情况
        /// </summary>
        [Column("F_MEETINGHOST")]
        public string F_MeetingHost { get; set; }
        /// <summary>
        /// 参会单位，手工填写，存在外单位情况
        /// </summary>
        [Column("F_MEETINGUNITS")]
        public string F_MeetingUnits { get; set; }
        /// <summary>
        /// 参会人，手工填写，存在外单位情况
        /// </summary>
        [Column("F_MEETINGATTENDEE")]
        public string F_MeetingAttendee { get; set; }
        /// <summary>
        /// 会议类型，取数据字典表
        /// </summary>
        [Column("F_MRTYPE")]
        public string F_MRType { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("F_STARTTIME")]
        public DateTime? F_StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("F_ENDTIME")]
        public DateTime? F_EndTime { get; set; }
        /// <summary>
        /// 时长(小时)
        /// </summary>
        [Column("F_DURATION")]
        public double? F_Duration { get; set; }
        /// <summary>
        /// 会议议题
        /// </summary>
        [Column("F_MEETINGTOPICS")]
        public string F_MeetingtOpics { get; set; }
        /// <summary>
        /// 会议内容
        /// </summary>
        [Column("F_MEETINGCONTENT")]
        public string F_MeetingContent { get; set; }
        /// <summary>
        /// 现场图片
        /// </summary>
        [Column("F_SCENEPICTURES")]
        public string F_ScenePictures { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
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
        /// <summary>
        /// 项目信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }

        
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create(UserInfo userInfo)
      {
            this.F_MRId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue, UserInfo userInfo)
        {
            this.F_MRId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

