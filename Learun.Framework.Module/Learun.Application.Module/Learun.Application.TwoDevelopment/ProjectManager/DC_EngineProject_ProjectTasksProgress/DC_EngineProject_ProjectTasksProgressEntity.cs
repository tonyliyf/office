using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-20 12:20
    /// 描 述：DC_EngineProject_ProjectTasksProgress
    /// </summary>
    public class DC_EngineProject_ProjectTasksProgressEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PTPID")]
        public string F_PTPId { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PTID")]
        public string F_PTId { get; set; }
        /// <summary>
        /// 项目阶段主键，取值项目进度计划表，不可编辑
        /// </summary>
        [Column("F_PROJECTSTAGE")]
        public string F_ProjectStage { get; set; }
        /// <summary>
        /// 任务编号，取值项目进度计划表，不可编辑
        /// </summary>
        [Column("F_TASKITEMNUMBER")]
        public string F_TaskItemNumber { get; set; }
        /// <summary>
        /// 任务名称，取值项目进度计划表，不可编辑
        /// </summary>
        [Column("F_TASKNAME")]
        public string F_TaskName { get; set; }
        /// <summary>
        /// 计量单位，取值项目进度计划表，不可编辑
        /// </summary>
        [Column("F_MEASUREMENTUNIT")]
        public string F_MeasurementUnit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        [Column("F_PROJECTQUANTITIES")]
        public int? F_ProjectQuantities { get; set; }
        /// <summary>
        /// 综合单价
        /// </summary>
        [Column("F_UNITPRICE")]
        public double? F_UnitPrice { get; set; }
        /// <summary>
        /// 合计，非编辑列，自动计算：工程量乘以综合单价
        /// </summary>
        [Column("F_COSTTOTAL")]
        public double? F_CostTotal { get; set; }
        /// <summary>
        /// 计划开工日期,不可编辑，取值计划表
        /// </summary>
        [Column("F_PLANNEDSTARTDATE")]
        public DateTime? F_PlannedStartDate { get; set; }
        /// <summary>
        /// 实际开工日期
        /// </summary>
        [Column("F_ACTUALSTARTDATE")]
        public DateTime? F_ActualStartDate { get; set; }
        /// <summary>
        /// 计划完成日期，,不可编辑，取值计划表
        /// </summary>
        [Column("F_PLANNEDENDDATE")]
        public DateTime? F_PlannedEndDate { get; set; }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        [Column("F_ACTUALENDDATE")]
        public DateTime? F_ActualEndDate { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
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
            this.F_PTPId = Guid.NewGuid().ToString();
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
            this.F_PTPId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

