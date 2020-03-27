using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-21 11:44
    /// 描 述：DC_EngineProject_ProjectPersonRiskControl
    /// </summary>
    public class DC_EngineProject_ProjectPersonRiskControlEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PPRCID")]
        public string F_PPRCId { get; set; }
        /// <summary>
        /// 工程项目信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 部门,取系统部门信息表
        /// </summary>
        [Column("F_PPRCDEPARTMENT")]
        public string F_PPRCDepartment { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("F_PPRCUSER")]
        public string F_PPRCUser { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        [Column("F_PPRCPOST")]
        public string F_PPRCPost { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [Column("F_PPRCDUTY")]
        public string F_PPRCDuty { get; set; }
        /// <summary>
        /// 填表时间
        /// </summary>
        [Column("F_PCRCDATE")]
        public DateTime? F_PCRCDate { get; set; }
        /// <summary>
        /// 主要职能
        /// </summary>
        [Column("F_MAINFUNCTIONS")]
        public string F_MainFunctions { get; set; }
        /// <summary>
        /// 廉政风险防控措施
        /// </summary>
        [Column("F_RISKCONTROLMEASURES")]
        public string F_RiskControlMeasures { get; set; }
        /// <summary>
        /// 主管领导意见
        /// </summary>
        [Column("F_CHARGEOPINION")]
        public string F_ChargeOpinion { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PPRCId = Guid.NewGuid().ToString();
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateDatetime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PPRCId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

