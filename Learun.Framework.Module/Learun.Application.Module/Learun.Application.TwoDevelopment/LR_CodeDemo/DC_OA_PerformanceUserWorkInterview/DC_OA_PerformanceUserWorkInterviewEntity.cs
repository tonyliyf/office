using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-12 12:57
    /// 描 述：DC_OA_PerformanceUserWorkInterview
    /// </summary>
    public class DC_OA_PerformanceUserWorkInterviewEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PUWIID")]
        public string F_PUWIId { get; set; }
        /// <summary>
        /// 考核工作记录主键
        /// </summary>
        [Column("F_PUWID")]
        public string F_PUWId { get; set; }
        /// <summary>
        /// 被面谈人
        /// </summary>
        [Column("F_BEINTERVIEWUSER")]
        public string F_BeInterviewUser { get; set; }
        /// <summary>
        /// 被面谈人部门
        /// </summary>
        [Column("F_BEINTERVIEWDEPARTMENT")]
        public string F_BeInterviewDepartment { get; set; }
        /// <summary>
        /// 被面谈人岗位
        /// </summary>
        [Column("F_BEINTERVIEWPOST")]
        public string F_BeInterviewPost { get; set; }
        /// <summary>
        /// 面谈人
        /// </summary>
        [Column("F_INTERVIEWUSER")]
        public string F_InterviewUser { get; set; }
        /// <summary>
        /// 面谈人部门
        /// </summary>
        [Column("F_INTERVIEWDEPARTMENT")]
        public string F_InterviewDepartment { get; set; }
        /// <summary>
        /// 面谈人岗位
        /// </summary>
        [Column("F_INTERVIEWPOST")]
        public string F_InterviewPost { get; set; }
        /// <summary>
        /// 面谈时间
        /// </summary>
        [Column("F_INTERVIEWDATE")]
        public DateTime? F_InterviewDate { get; set; }
        /// <summary>
        /// 面谈地点
        /// </summary>
        [Column("F_INTERVIEWADDRESS")]
        public string F_InterviewAddress { get; set; }
        /// <summary>
        /// 面谈内容一
        /// </summary>
        [Column("F_INTERVIEWCONTENTA")]
        public string F_InterviewContentA { get; set; }
        /// <summary>
        /// 面谈内容二
        /// </summary>
        [Column("F_INTERVIEWCONTENTB")]
        public string F_InterviewContentB { get; set; }
        /// <summary>
        /// 面谈内容三
        /// </summary>
        [Column("F_INTERVIEWCONTENTC")]
        public string F_InterviewContentC { get; set; }
        /// <summary>
        /// 面谈内容四
        /// </summary>
        [Column("F_INTERVIEWCONTENTD")]
        public string F_InterviewContentD { get; set; }
        /// <summary>
        /// 计划是否一致
        /// </summary>
        [Column("F_IFAGREEMENT")]
        public int? F_IfAgreement { get; set; }
        /// <summary>
        /// 计划内容
        /// </summary>
        [Column("F_PLANCONTENT")]
        public string F_PlanContent { get; set; }
        /// <summary>
        /// 被面谈人是否确认
        /// </summary>
        [Column("F_IFBEINTERVIEWCONFIRM")]
        public int? F_IfBeInterviewConfirm { get; set; }
        /// <summary>
        /// 被面谈人确认时间
        /// </summary>
        [Column("F_BEINTERVIEWCONFIRMDATE")]
        public DateTime? F_BeInterviewConfirmDate { get; set; }
        /// <summary>
        /// 面谈人是否确认
        /// </summary>
        [Column("F_IFINTERVIEWCONFIRM")]
        public int? F_IfInterviewConfirm { get; set; }
        /// <summary>
        /// 面谈人确认时间
        /// </summary>
        [Column("F_IFINTERVIEWCONFIRMDATE")]
        public DateTime? F_IfInterviewConfirmDate { get; set; }
        /// <summary>
        /// 考核办签收意见
        /// </summary>
        [Column("F_EXAMINEOPINION")]
        public string F_ExamineOpinion { get; set; }
        /// <summary>
        /// 是否归档
        /// </summary>
        [Column("F_IFFILED")]
        public int? F_IfFiled { get; set; }
        /// <summary>
        /// 考核办签收人
        /// </summary>
        [Column("F_EXAMINEUSER")]
        public string F_ExamineUser { get; set; }
        /// <summary>
        /// 考核办签收时间
        /// </summary>
        [Column("F_EXAMINEDATE")]
        public DateTime? F_ExamineDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PUWIId = Guid.NewGuid().ToString();
            this.F_IfBeInterviewConfirm = 0;
            this.F_IfInterviewConfirm = 0;
            this.F_IfFiled = 0;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PUWIId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

