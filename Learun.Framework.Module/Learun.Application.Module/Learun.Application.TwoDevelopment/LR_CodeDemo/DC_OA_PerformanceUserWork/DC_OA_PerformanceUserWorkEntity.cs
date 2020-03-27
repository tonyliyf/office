using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 11:12
    /// 描 述：DC_OA_PerformanceUserWork
    /// </summary>
    public class DC_OA_PerformanceUserWorkEntity
    {
        #region 实体成员
        /// <summary>
        /// F_PUWId
        /// </summary>
        [Column("F_PUWID")]
        public string F_PUWId { get; set; }
        /// <summary>
        /// 考核运行记录主键
        /// </summary>
        [Column("F_PRRID")]
        public string F_PRRId { get; set; }
        /// <summary>
        /// 被考核人主键
        /// </summary>
        [Column("F_PUWUSERID")]
        public string F_PUWUserId { get; set; }
        /// <summary>
        /// 考核周期,从模版获取（月度：1；年度：2），可修改
        /// </summary>
        [Column("F_APPRAISALCYCLETYPE")]
        public int? F_AppraisalCycleType { get; set; }
        /// <summary>
        /// 当前考核周期值,如果是年度取当前年份（YYYY）,如果是月度取当前年月（YYYYMM）
        /// </summary>
        [Column("F_APPRAISALCYCLEVALUE")]
        public string F_AppraisalCycleValue { get; set; }
        /// <summary>
        /// 考核表名称,系统自动产生：考核运行表考核名称+YYYYMM月度考核，或者为 考核运行表考核名称+YYYY年度考核（依据考核运行表考核周期字段判断）
        /// </summary>
        [Column("F_PUWNAME")]
        public string F_PUWName { get; set; }
        /// <summary>
        /// 被考核人部门主键
        /// </summary>
        [Column("F_PUWDEPARTMENTID")]
        public string F_PUWDepartmentId { get; set; }
        /// <summary>
        /// 管理监督责任扣分
        /// </summary>
        [Column("F_DUTYREDUCESCORE")]
        public int? F_DutyReduceScore { get; set; }
        /// <summary>
        /// 奖励加分
        /// </summary>
        [Column("F_AWARDADDSCORE")]
        public int? F_AwardAddScore { get; set; }
        /// <summary>
        /// 自评权重，小数，不得大于1
        /// </summary>
        [Column("F_SELFWEIGHT")]
        public double F_SelfWeight { get; set; }
        /// <summary>
        /// 考核得分
        /// </summary>
        [Column("F_PERFORMANCESCORE")]
        public int? F_PerformanceScore { get; set; }
        /// <summary>
        /// 执行环节,系统字段：工作计划、考核评估、考核自评、考核评价、考核审核、考核申诉、考核面谈
        /// </summary>
        [Column("F_PEPOINT")]
        public string F_PEPoint { get; set; }
        [Column("F_IfSelfJudge")]
        public int F_IfSelfJudge { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PUWId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PUWId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
    public class DC_OA_PerformanceUserWorkModel
    {
        public string F_PUWId { get; set; }
        /// <summary>
        /// 考核运行记录主键
        /// </summary>
        public string F_PRRId { get; set; }
        /// <summary>
        /// 被考核人主键
        /// </summary>
        public string F_PUWUserId { get; set; }
        /// <summary>
        /// 考核周期,从模版获取（月度：1；年度：2），可修改
        /// </summary>
        public int? F_AppraisalCycleType { get; set; }
        /// <summary>
        /// 当前考核周期值,如果是年度取当前年份（YYYY）,如果是月度取当前年月（YYYYMM）
        /// </summary>
        public string F_AppraisalCycleValue { get; set; }
        /// <summary>
        /// 考核表名称,系统自动产生：考核运行表考核名称+YYYYMM月度考核，或者为 考核运行表考核名称+YYYY年度考核（依据考核运行表考核周期字段判断）
        /// </summary>
        public string F_PUWName { get; set; }
        /// <summary>
        /// 被考核人部门主键
        /// </summary>
        public string F_PUWDepartmentId { get; set; }
        /// <summary>
        /// 管理监督责任扣分
        /// </summary>
        public int? F_DutyReduceScore { get; set; }
        /// <summary>
        /// 奖励加分
        /// </summary>
        public int? F_AwardAddScore { get; set; }
        /// <summary>
        /// 自评权重，小数，不得大于1
        /// </summary>
        public double F_SelfWeight { get; set; }
        /// <summary>
        /// 考核得分
        /// </summary>
        public int? F_PerformanceScore { get; set; }
        /// <summary>
        /// 执行环节,系统字段：工作计划、考核评估、考核自评、考核评价、考核审核、考核申诉、考核面谈
        /// </summary>
        public string F_PEPoint { get; set; }
        public bool isChecker { get; set; }
    }
}

