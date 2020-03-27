using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 09:28
    /// 描 述：DC_OA_PerformanceAppraisalTemplate
    /// </summary>
    public class DC_OA_PerformanceAppraisalTemplateEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PATID")]
        public string F_PATId { get; set; }
        /// <summary>
        /// 考核周期类型（月度：1；年度：2）
        /// </summary>
        [Column("F_APPRAISALCYCLETYPE")]
        public int? F_AppraisalCycleType { get; set; }
        /// <summary>
        /// 模版编号
        /// </summary>
        [Column("F_TEMPLATECODE")]
        public string F_TemplateCode { get; set; }
        /// <summary>
        /// 模版名称
        /// </summary>
        [Column("F_TEMPLATENAME")]
        public string F_TemplateName { get; set; }
        /// <summary>
        /// 模版总分，默认值：100 ；可用于控制指标分值合计不得超出
        /// </summary>
        [Column("F_PATTOTALSCORE")]
        public int? F_PATTotalScore { get; set; }
        /// <summary>
        /// 创建者部门主键
        /// </summary>
        [Column("F_PATDEPARTMENTID")]
        public string F_PATDepartmentId { get; set; }
        /// <summary>
        /// 创建人主键
        /// </summary>
        [Column("F_PATUSERID")]
        public string F_PATUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_PATCREATEDATE")]
        public DateTime? F_PATCreateDate { get; set; }
        /// <summary>
        /// 启用状态（0：启用；1：禁用；默认0）
        /// </summary>
        [Column("F_IFENABLE")]
        public int? F_IfEnable { get; set; }
        /// <summary>
        /// 删除标记，系统字段，用于删除标记，不做物理删除
        /// </summary>
        [Column("F_ISDELETE")]
        public int? F_IsDelete { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PATId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PATId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

