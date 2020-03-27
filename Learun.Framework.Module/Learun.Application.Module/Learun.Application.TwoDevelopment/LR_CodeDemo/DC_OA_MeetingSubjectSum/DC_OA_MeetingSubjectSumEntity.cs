using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-27 14:02
    /// 描 述：DC_OA_MeetingSubjectSum
    /// </summary>
    public class DC_OA_MeetingSubjectSumEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_SUBJECTSUMID")]
        public string F_SubjectSumId { get; set; }
        /// <summary>
        /// 会议内容
        /// </summary>
        [Column("F_CONTENT")]
        public string F_Content { get; set; }
        /// <summary>
        /// 会议列题id组，通过"，“隔开
        /// </summary>
        [Column("F_MEETINGSUBJECTIDS")]
        public string F_MeetingSubjectIds { get; set; }
        /// <summary>
        /// 当前用户公司
        /// </summary>
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 是否审批同意（“-1”驳回，“2”审批同意,"3"已提交专题会议当中)
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 当前部门Id
        /// </summary>
        [Column("F_CURRENTDEPTID")]
        public string F_CurrentDeptId { get; set; }
        /// <summary>
        /// 当前部门
        /// </summary>
        [Column("F_CURRENTDEPTNAME")]
        public string F_CurrentDeptName { get; set; }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
        /// <summary>
        /// 当前单位
        /// </summary>
        [Column("F_CURRENTCOMPANYNAME")]
        public string F_CurrentCompanyName { get; set; }
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
        public string F_Description { get; set; }
        /// <summary>
        /// 附件信息
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// F_SubListName
        /// </summary>
        [Column("F_SUBLISTNAME")]
        public string F_SubListName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
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
            this.F_SubjectSumId = keyValue;
        }
        #endregion
    }
}

