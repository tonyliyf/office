using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-29 15:44
    /// 描 述：DC_OA_PerformanceCheck
    /// </summary>
    public class DC_OA_PerformanceCheckEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EMPOLYEECHECKID")]
        public string F_EmpolyeeCheckId { get; set; }
        /// <summary>
        /// 被考核员工id
        /// </summary>
        [Column("F_CHECKUSERID")]
        public string F_CheckUserid { get; set; }
        /// <summary>
        /// 被考核员工部门Id
        /// </summary>
        [Column("F_CHECKUSERDEPTID")]
        public string F_CheckUserDeptId { get; set; }
        /// <summary>
        /// 被考核员工公司Id
        /// </summary>
        [Column("F_CHECKUSERCOMPAYID")]
        public string F_CheckUserCompayId { get; set; }
        /// <summary>
        /// 引用哪个考核模板
        /// </summary>
        [Column("F_CHECKTEMPLATEREFID")]
        public string F_CheckTemplateRefid { get; set; }
        /// <summary>
        /// 考核状态（0，草稿、1，审稿中，2审稿通过，-1驳回）
        /// </summary>
        [Column("F_CHECKSATE")]
        public string F_CheckSate { get; set; }
        /// <summary>
        /// 考核结果
        /// </summary>
        [Column("F_CHECKRESULT")]
        public string F_CheckResult { get; set; }
        /// <summary>
        /// 考核分数
        /// </summary>
        [Column("F_CHECKNUMBER")]
        public decimal? F_CheckNumber { get; set; }
        /// <summary>
        /// 考核开始时间
        /// </summary>
        [Column("F_CHECKSTARTTIME")]
        public DateTime? F_CheckStartTime { get; set; }
        /// <summary>
        /// 考核结束时间
        /// </summary>
        [Column("F_CHECKENDTIME")]
        public DateTime? F_CheckEndTime { get; set; }
        /// <summary>
        /// 考核人
        /// </summary>
        [Column("F_AUDITUSERID")]
        public string F_AuditUserid { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 考核模板类型（年度，季度，月度）取自数据字典,从模板中自动带过来，用于后期统计
        /// </summary>
        [Column("F_TIMETYPE")]
        public string F_TimeType { get; set; }
        /// <summary>
        /// 创建部门
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// 考核周期标签 （月度显示考核月底201903，年度显示2019，季度2019第一季度）
        /// </summary>
        [Column("F_DATELABEL")]
        public string F_DateLabel { get; set; }
        /// <summary>
        /// F_Content
        /// </summary>
        [Column("F_CONTENT")]
        public string F_Content { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_BASENUMBER")]
        public decimal? F_BaseNumber { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_JIXAONUMBER")]
        public decimal? F_JixaoNumber { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_RECNUMBERCOMMENTS")]
        public string F_RecNumberComments { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_ADDNUMBER")]
        public decimal? F_AddNumber { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_ADDNUMBERCOMMENTS")]
        public string F_AddNumberComments { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_POSITION")]
        public string F_Position { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_KOFENNUM")]
        public decimal? F_KofenNum { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_JIAFENNUM")]
        public decimal? F_JiafenNum { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_MANAGECOMMENTS")]
        public decimal? F_manageComments { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_GENERALMANAGERSCORE")]
        public decimal? F_GeneralManagerScore { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_CHAIRMANSCORE")]
        public decimal? F_ChairmanScore { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_DERIVENUM")]
        public decimal? F_deriveNum { get; set; }

        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_GENERALNUMBER")]
        public decimal? F_GeneralNumber { get; set; }
        /// <summary>
        /// F_BaseNumber
        /// </summary>
        [Column("F_ChairmanNumber")]
        public decimal? F_ChairmanNumber { get; set; }

        [Column("F_LEVEL")]
        public int? F_Level { get; set; }
  
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EmpolyeeCheckId = Guid.NewGuid().ToString();
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CheckSate = "0";
            this.F_CheckUserCompayId = userInfo.companyId;
            this.F_CreateDatetime = DateTime.Now;
            this.F_CreateDepartmentId = userInfo.departmentId;
            this.F_CheckUserid = userInfo.userId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EmpolyeeCheckId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

