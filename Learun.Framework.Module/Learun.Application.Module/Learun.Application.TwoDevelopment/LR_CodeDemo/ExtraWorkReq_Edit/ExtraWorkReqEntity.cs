using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 13:41
    /// 描 述：ExtraWorkReq_Edit
    /// </summary>
    public class ExtraWorkReqEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// F_Title
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        [Column("F_DEGREE")]
        public string F_Degree { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        [Column("F_APPLICANT")]
        public string F_Applicant { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        [Column("F_DEPT")]
        public string F_Dept { get; set; }
        /// <summary>
        /// 所属分部
        /// </summary>
        [Column("F_BRANCH")]
        public string F_Branch { get; set; }
        /// <summary>
        /// 加班类型
        /// </summary>
        [Column("F_TYPE")]
        public string F_Type { get; set; }
        /// <summary>
        /// 加班事由
        /// </summary>
        [Column("F_REASON")]
        public string F_Reason { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("F_ENDDATE")]
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 加班时长
        /// </summary>
        [Column("F_DURATION")]
        public double? F_Duration { get; set; }
        /// <summary>
        /// 关联流程
        /// </summary>
        [Column("F_PROCESS")]
        public string F_Process { get; set; }
        /// <summary>
        /// 关联文档
        /// </summary>
        [Column("F_FILE")]
        public string F_File { get; set; }
        /// <summary>
        /// 关联项目
        /// </summary>
        [Column("F_PROJECT")]
        public string F_Project { get; set; }
        /// <summary>
        /// 关联客户
        /// </summary>
        [Column("F_CUSTOMER")]
        public string F_Customer { get; set; }
        /// <summary>
        /// 签字意见
        /// </summary>
        [Column("F_OPINION")]
        public string F_Opinion { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_Id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

