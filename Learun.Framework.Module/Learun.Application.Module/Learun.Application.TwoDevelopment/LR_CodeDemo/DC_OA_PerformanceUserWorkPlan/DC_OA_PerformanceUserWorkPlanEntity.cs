using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 17:08
    /// 描 述：DC_OA_PerformanceUserWorkPlan
    /// </summary>
    public class DC_OA_PerformanceUserWorkPlanEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PUWPID")]
        public string F_PUWPId { get; set; }
        /// <summary>
        /// 考核工作记录主键
        /// </summary>
        [Column("F_PUWID")]
        public string F_PUWId { get; set; }
        /// <summary>
        /// 指标名称，如果是自填项，可编辑
        /// </summary>
        [Column("F_TARGETNAME")]
        public string F_TargetName { get; set; }
        /// <summary>
        /// 指标内容，如果是自填项，可编辑
        /// </summary>
        [Column("F_TARGETCONTENT")]
        public string F_TargetContent { get; set; }
        /// <summary>
        /// 考核目标，如果是自填项，可编辑
        /// </summary>
        [Column("F_TARGET")]
        public string F_Target { get; set; }
        /// <summary>
        /// 评分说明，如果是自填项，可编辑
        /// </summary>
        [Column("F_TARGETEXPLAIN")]
        public string F_TargetExplain { get; set; }
        /// <summary>
        /// 指标分值，如果是自填项，可编辑
        /// </summary>
        [Column("F_TARGETSCORE")]
        public int? F_TargetScore { get; set; }
        /// <summary>
        /// 排序,用于表单显示顺序，如果是自填项，可编辑
        /// </summary>
        [Column("F_SORT")]
        public int? F_Sort { get; set; }
        /// <summary>
        /// 父级主键，如果是自填项，可编辑
        /// </summary>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 完成情况，自评环节填写
        /// </summary>
        [Column("F_PERFORMANCEINFO")]
        public string F_PerformanceInfo { get; set; }
        /// <summary>
        /// 自评分值，自评环节填写
        /// </summary>
        [Column("F_SELFSCORE")]
        public int? F_SelfScore { get; set; }
        [Column("F_IfTargetDefine")]
        public int? F_IfTargetDefine { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PUWPId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PUWPId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

