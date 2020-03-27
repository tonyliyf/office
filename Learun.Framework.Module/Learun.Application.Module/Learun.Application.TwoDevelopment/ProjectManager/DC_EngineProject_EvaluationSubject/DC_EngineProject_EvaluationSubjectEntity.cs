using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-03 15:13
    /// 描 述：项目评价科目
    /// </summary>
    public class DC_EngineProject_EvaluationSubjectEntity 
    {
        #region 实体成员
        /// <summary>
        /// 项目评价科目id
        /// </summary>
        [Column("F_PROJECTEVALUATIONID")]
        public string F_ProjectEvaluationId { get; set; }
        /// <summary>
        /// 项目评价科目
        /// </summary>
        [Column("F_PROJECTEVALUATIONITEM")]
        public string F_ProjectEvaluationItem { get; set; }
        /// <summary>
        /// 父级科目id
        /// </summary>
        [Column("F_PROJECTEVALUATIONPARENTID")]
        public string F_ProjectEvaluationParentId { get; set; }
        /// <summary>
        /// 评分总分
        /// </summary>
        [Column("F_EVALUATIONSCORE")]
        public decimal? F_EvaluationScore { get; set; }
        /// <summary>
        /// 评分等级
        /// </summary>
        [Column("F_EVALUATIONLEVEL")]
        public string F_EvaluationLevel { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        [Column("F_PROJECTEVALUATIONCONTENT")]
        public string F_ProjectEvaluationContent { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// F_CreateUserId
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }


        [Column("F_Sort")]
        public  int? F_Sort { get; set; }
        /// <summary>
        /// F_CreateUserName
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDateTime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_ProjectEvaluationId = Guid.NewGuid().ToString();
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_ProjectEvaluationId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

