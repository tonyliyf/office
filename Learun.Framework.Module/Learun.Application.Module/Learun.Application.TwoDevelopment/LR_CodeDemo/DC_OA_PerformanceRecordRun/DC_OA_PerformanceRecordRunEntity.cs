using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 17:30
    /// 描 述：DC_OA_PerformanceRecordRun
    /// </summary>
    public class DC_OA_PerformanceRecordRunEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PRRID")]
        public string F_PRRId { get; set; }
        /// <summary>
        /// 考核模版主键
        /// </summary>
        [Column("F_PATID")]
        public string F_PATId { get; set; }
        /// <summary>
        /// 考核名称
        /// </summary>
        [Column("F_PERFORMANCENAME")]
        public string F_PerformanceName { get; set; }
        /// <summary>
        /// 考核起始时间
        /// </summary>
        [Column("F_PRRSTARTDATETIME")]
        public DateTime? F_PRRStartDatetime { get; set; }
        /// <summary>
        /// 考核终止时间
        /// </summary>
        [Column("F_PRRENDDATETIME")]
        public DateTime? F_PRREndDatetime { get; set; }
        /// <summary>
        /// 考核周期,从模版获取（月度：1；年度：2），可修改
        /// </summary>
        [Column("F_APPRAISALCYCLETYPE")]
        public int? F_AppraisalCycleType { get; set; }
        /// <summary>
        /// 是否自评，0：是；1：否；默认0
        /// </summary>
        [Column("F_IFSELFJUDGE")]
        public int? F_IfSelfJudge { get; set; }
        /// <summary>
        /// 考核人是否顺序考评，0：是；1：否；默认0
        /// </summary>
        [Column("F_IFORDER")]
        public int? F_Iforder { get; set; }
        /// <summary>
        /// 自评权重，小数，不得大于1
        /// </summary>
        [Column("F_SELFWEIGHT")]
        public double F_SelfWeight { get; set; }
        /// <summary>
        /// 是否定期考核提醒，用于消息服务，暂不使用
        /// </summary>
        [Column("F_IFREMIND")]
        public int? F_IfRemind { get; set; }
        /// <summary>
        /// 运行状态，0：运行；1：暂停；2：结束；3：终止。默认0
        /// </summary>
        [Column("F_RUNSTATE")]
        public int? F_RunState { get; set; }
        /// <summary>
        /// 删除标记，系统字段，用于删除标记，不做物理删除
        /// </summary>
        [Column("F_ISDELETE")]
        public int? F_IsDelete { get; set; }
        /// <summary>
        /// 发起部门主键
        /// </summary>
        [Column("F_PRRDEPARTMENTID")]
        public string F_PRRDepartmentId { get; set; }
        /// <summary>
        /// 发起人主键
        /// </summary>
        [Column("F_PRRUSERID")]
        public string F_PRRUserId { get; set; }
        /// <summary>
        /// 发起时间
        /// </summary>
        [Column("F_PRRCREATEDATE")]
        public DateTime? F_PRRCreateDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PRRId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PRRId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

