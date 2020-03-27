using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 12:12
    /// 描 述：LeaveReq_Edit
    /// </summary>
    public class LeaveReqEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        [Column("F_DEGREE")]
        public string F_Degree { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("F_NAME")]
        public string F_Name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Column("F_DEPT")]
        public string F_Dept { get; set; }
        /// <summary>
        /// 申请人分部
        /// </summary>
        [Column("F_BRANCH")]
        public string F_Branch { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        [Column("F_APPLYDATE")]
        public DateTime? F_ApplyDate { get; set; }
        /// <summary>
        /// 请假类型
        /// </summary>
        [Column("F_LEAVETYPE")]
        public string F_LeaveType { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("F_ENDDATE")]
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 请假天数
        /// </summary>
        [Column("F_LEAVEDAYS")]
        public double? F_LeaveDays { get; set; }
        /// <summary>
        /// 剩余年假天数
        /// </summary>
        [Column("F_REMAINDAYS")]
        public double? F_RemainDays { get; set; }
        /// <summary>
        /// 请假原因
        /// </summary>
        [Column("F_LEAVEREASON")]
        public string F_LeaveReason { get; set; }
        /// <summary>
        /// 签字意见
        /// </summary>
        [Column("F_OPINION")]
        public string F_Opinion { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// 实际开始日期
        /// </summary>
        [Column("F_ACTSTARTDATE")]
        public DateTime? F_ActStartDate { get; set; }
        /// <summary>
        /// 实际结束日期
        /// </summary>
        [Column("F_ACTENDDATE")]
        public DateTime? F_ActEndDate { get; set; }
        /// <summary>
        /// 实际天数
        /// </summary>
        [Column("F_ACTDAYS")]
        public double? F_ActDays { get; set; }
        /// <summary>
        /// 岗位id
        /// </summary>
        [Column("F_POSTID")]
        public string F_PostId { get; set; }
        /// <summary>
        /// F_CompanyId
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }



        /// <summary>
        /// 时间上午段
        /// </summary>
        [Column("F_StartDateIsAm")]
        public string F_StartDateIsAm { get; set; }


        /// <summary>
        /// 时间下午段
        /// </summary>
        [Column("F_EndDateIsAm")]
        public string F_EndDateIsAm { get; set; }



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

