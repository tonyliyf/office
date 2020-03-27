using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-25 15:22
    /// 描 述：DC_EngineProject_ConstructionRecord
    /// </summary>
    public class DC_EngineProject_ConstructionRecordEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EPCRID")]
        public string F_EPCRId { get; set; }
        /// <summary>
        /// 工程项目基本信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 安全文明施工评价,取值于数据字典：良、中、差
        /// </summary>
        [Column("F_SAFETYCIVILIZATIONEVALUATION")]
        public string F_SafetyCivilizationEvaluation { get; set; }
        /// <summary>
        /// 安全文明施工检查情况
        /// </summary>
        [Column("F_SAFETYCIVILIZATIONINFO")]
        public string F_SafetyCivilizationInfo { get; set; }
        /// <summary>
        /// 施工质量评价,取值于数据字典：良、中、差
        /// </summary>
        [Column("F_QUALITYEVALUATION")]
        public string F_QualityEvaluation { get; set; }
        /// <summary>
        /// 施工质量检查验收情况
        /// </summary>
        [Column("F_QUALITYINFO")]
        public string F_QualityInfo { get; set; }
        /// <summary>
        /// 劳动力安排人数
        /// </summary>
        [Column("F_LABORNUMBER")]
        public int? F_LaborNumber { get; set; }
        /// <summary>
        /// 劳动力安排情况
        /// </summary>
        [Column("F_LABORINFO")]
        public string F_LaborInfo { get; set; }
        /// <summary>
        /// 监理方人员到岗情况
        /// </summary>
        [Column("F_SUPERVISORSCOMEINFO")]
        public string F_SupervisorsComeInfo { get; set; }
        /// <summary>
        /// 施工方人员到岗情况
        /// </summary>
        [Column("F_CONSTRUCTORCOMEINFO")]
        public string F_ConstructorComeInfo { get; set; }
        /// <summary>
        /// 项目业主方到岗情况
        /// </summary>
        [Column("F_PROJECTOWNERCOMEINFO")]
        public string F_ProjectOwnerComeInfo { get; set; }
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
        /// 填报部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 填报部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 填报人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 填报人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 填报时间
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
            this.F_EPCRId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EPCRId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

