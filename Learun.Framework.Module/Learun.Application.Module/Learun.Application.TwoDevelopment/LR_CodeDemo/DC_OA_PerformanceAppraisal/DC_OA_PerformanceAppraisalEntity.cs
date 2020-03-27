using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 09:40
    /// 描 述：DC_OA_PerformanceAppraisal
    /// </summary>
    public class DC_OA_PerformanceAppraisalEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PAID")]
        public string F_PAId { get; set; }
        /// <summary>
        /// 绩效考核模版主键
        /// </summary>
        [Column("F_PATID")]
        public string F_PATId { get; set; }
        /// <summary>
        /// 排序,用于表单显示顺序
        /// </summary>
        [Column("F_SORT")]
        public int? F_Sort { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>
        [Column("F_TARGETNAME")]
        public string F_TargetName { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 指标内容，对指标名称的解释
        /// </summary>
        [Column("F_TARGETCONTENT")]
        public string F_TargetContent { get; set; }
        /// <summary>
        /// 考核目标
        /// </summary>
        [Column("F_TARGET")]
        public string F_Target { get; set; }
        /// <summary>
        /// 评分说明
        /// </summary>
        [Column("F_TARGETEXPLAIN")]
        public string F_TargetExplain { get; set; }
        /// <summary>
        /// 指标分值
        /// </summary>
        [Column("F_TARGETSCORE")]
        public int? F_TargetScore { get; set; }
        /// <summary>
        /// 是否自填项，0：否；1：是。当为1时，被考核人填写考核表时，考核内容、考核目标和分值自己可编辑
        /// </summary>
        [Column("F_IFTARGETDEFINE")]
        public int? F_IfTargetDefine { get; set; }
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
            this.F_PAId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PAId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

