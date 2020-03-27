using Learun.Application.Organization;
using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 14:36
    /// 描 述：专题会议内容申请
    /// </summary>
    public class DC_OA_MeetingSubjectEntity
    {
        CompanyIBLL companybll = new CompanyBLL();
        DepartmentIBLL departbll = new DepartmentBLL();
        #region 实体成员
        /// <summary>
        /// 会议议题主键
        /// </summary>
        [Column("F_MEETINGSUBJECTID")]
        public string F_MeetingSubjectId { get; set; }
        /// <summary>
        /// 会议提交内容
        /// </summary>
        [Column("F_CONTENT")]
        public string F_Content { get; set; }
        /// <summary>
        /// 当前用户公司
        /// </summary>
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
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
        /// 当前部门Id
        /// </summary>
        [Column("F_CURRENTDEPTID")]
        public string F_CurrentDeptId { get; set; }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
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
        /// 当前部门
        /// </summary>
        [Column("F_CURRENTDEPTNAME")]
        public string F_CurrentDeptName { get; set; }
        /// <summary>
        /// 当前单位
        /// </summary>
        [Column("F_CURRENTCOMPANYNAME")]
        public string F_CurrentCompanyName { get; set; }
        /// <summary>
        /// 是否审批同意（“-1”驳回，“2”审批同意,"3"已提交汇总当中）
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 附件信息
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        [Column("F_ReportCompany")]
        public string F_ReportCompany { get; set; }
        [Column("F_AttendCompany")]
        public string F_AttendCompany { get; set; }
        [Column("F_MeetingDuring")]
        public string F_MeetingDuring { get; set; }
        [Column("F_StartTime")]
        public string F_StartTime { get; set; }
        [Column("F_IsHRSub")]
        public string F_IsHRSub { get; set; }
        [Column("F_ReplyReason")]
        public string F_ReplyReason { get; set; }
        [Column("F_DealSituation")]
        public string F_DealSituation { get; set; }
        [Column("F_Telephone")]
        public string F_Telephone { get; set; }
        [Column("F_Image")]
        public string F_Image { get; set; }
        [Column("F_SubjectSumId")]
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
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;

            //this.F_CurrentCompanyName= companybll.GetEntity(userInfo.companyId).F_FullName;
            //this.F_CurrentDeptName = departbll.GetEntity(userInfo.departmentId).F_FullName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_MeetingSubjectId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

