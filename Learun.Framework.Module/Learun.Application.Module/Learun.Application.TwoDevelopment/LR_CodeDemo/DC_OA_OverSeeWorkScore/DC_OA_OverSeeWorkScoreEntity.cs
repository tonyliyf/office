using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-17 17:13
    /// 描 述：DC_OA_OverSeeWorkScore
    /// </summary>
    public class DC_OA_OverSeeWorkScoreEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_OSWSID")]
        public string F_OSWSId { get; set; }
        /// <summary>
        /// 主表主键，督办任务分解表主键
        /// </summary>
        /// <returns></returns>
        [Column("F_SECONDID")]
        public string F_SecondId { get; set; }
        /// <summary>
        /// 编号，取值主表
        /// </summary>
        /// <returns></returns>
        [Column("F_OSWCODE")]
        public string F_OSWCode { get; set; }
        /// <summary>
        /// 工作事项，取值主表
        /// </summary>
        /// <returns></returns>
        [Column("F_OSWCONTENT")]
        public string F_OSWContent { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        /// <returns></returns>
        [Column("F_OSWSCORE")]
        public double? F_OSWScore { get; set; }
        /// <summary>
        /// 评价
        /// </summary>
        /// <returns></returns>
        [Column("F_OSWSCONTENT")]
        public string F_OSWSContent { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATEDATE")]
        public DateTime? F_EvaluateDate { get; set; }
        /// <summary>
        /// 评价人部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATEDEPARTMENTID")]
        public string F_EvaluateDepartmentId { get; set; }
        /// <summary>
        /// 评价人部门
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATEDEPARTMENT")]
        public string F_EvaluateDepartment { get; set; }
        /// <summary>
        /// 评价人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATEUSERID")]
        public string F_EvaluateUserId { get; set; }
        /// <summary>
        /// 评价人
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATEUSER")]
        public string F_EvaluateUser { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_OSWSId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_OSWSId = keyValue;
        }
        #endregion
    }
}

