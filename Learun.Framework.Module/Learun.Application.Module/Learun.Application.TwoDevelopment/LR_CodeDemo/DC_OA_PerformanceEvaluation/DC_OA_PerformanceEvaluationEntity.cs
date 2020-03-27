using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 16:42
    /// 描 述：DC_OA_PerformanceEvaluation
    /// </summary>
    public class DC_OA_PerformanceEvaluationEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PEID")]
        public string F_PEId { get; set; }
        /// <summary>
        /// 考核工作计划主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PUWPID")]
        public string F_PUWPId { get; set; }
        /// <summary>
        /// 考核人部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATIONDEPARTMENTID")]
        public string F_EvaluationDepartmentId { get; set; }
        /// <summary>
        /// 考核人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATIONUSERID")]
        public string F_EvaluationUserId { get; set; }
        /// <summary>
        /// 考评分值
        /// </summary>
        /// <returns></returns>
        [Column("F_EVALUATIONSCORE")]
        public int? F_EvaluationScore { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            UserInfo user = LoginUserInfo.Get();
            this.F_PEId = Guid.NewGuid().ToString();
            this.F_EvaluationDepartmentId = user.departmentId;
            this.F_EvaluationUserId = user.userId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PEId = keyValue;
        }
        #endregion
    }
}

