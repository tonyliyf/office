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
    public class DC_EngineProject_ProjectPersonRiskControlAssessmentEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PPRCAID")]
        public string F_PPRCAId { get; set; }
        /// <summary>
        /// 主表主键
        /// </summary>
        [Column("F_PPRCID")]
        public string F_PPRCId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Column("F_PPRCANUM")]
        public int? F_PPRCANum { get; set; }
        /// <summary>
        /// 风险点
        /// </summary>
        [Column("F_RISKPOINT")]
        public string F_RiskPoint { get; set; }
        /// <summary>
        /// 风险等级,取值于数据字典，包括：高、中、低
        /// </summary>
        [Column("F_RISKGRADE")]
        public string F_RiskGrade { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PPRCAId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PPRCAId = keyValue;
        }
        #endregion
    }
}

