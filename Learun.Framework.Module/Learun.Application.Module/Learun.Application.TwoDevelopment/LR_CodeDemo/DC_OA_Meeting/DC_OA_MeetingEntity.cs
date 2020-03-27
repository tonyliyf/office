using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-27 15:58
    /// 描 述：DC_OA_Meeting
    /// </summary>
    public class DC_OA_MeetingEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_MeetingId
        /// </summary>
        [Column("DC_OA_MEETINGID")]
        public string DC_OA_MeetingId { get; set; }
        /// <summary>
        /// 会议室Id
        /// </summary>
        [Column("DC_OA_MEETINGROOMREFID")]
        public string DC_OA_MeetingRoomRefId { get; set; }
        /// <summary>
        /// 会议标题
        /// </summary>
        [Column("DC_OA_MEETINGTITLE")]
        public string DC_OA_MeetingTitle { get; set; }
        /// <summary>
        /// 会议主题
        /// </summary>
        [Column("DC_OA_MEETINGTOPIC")]
        public string DC_OA_MeetingTopic { get; set; }
        /// <summary>
        /// 会议内容
        /// </summary>
        [Column("DC_OA_MEETINGCONTENT")]
        public string DC_OA_MeetingContent { get; set; }
        /// <summary>
        /// 会议主持id
        /// </summary>
        [Column("DC_OA_MEETINGMANAGEID")]
        public string DC_OA_MeetingManageId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("DC_OA_STARTTIME")]
        public DateTime? DC_OA_StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("DC_OA_ENDTIME")]
        public DateTime? DC_OA_EndTime { get; set; }
        /// <summary>
        /// 会议结果
        /// </summary>
        [Column("DC_OA_RESULT")]
        public string DC_OA_Result { get; set; }
        /// <summary>
        /// 会议相关人员id
        /// </summary>
        [Column("DC_OA_MEETINGIDS")]
        public string DC_OA_MeetingIds { get; set; }
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
        /// 会议类型（1.一般会议,2.专题会议)
        /// </summary>
        [Column("F_MEETINGTYPE")]
        public string F_MeetingType { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 附件信息
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// 专题汇总id
        /// </summary>
        [Column("F_SUBJECTSUMID")]
        public string F_SubjectSumId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
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
            this.DC_OA_MeetingId = keyValue;
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

