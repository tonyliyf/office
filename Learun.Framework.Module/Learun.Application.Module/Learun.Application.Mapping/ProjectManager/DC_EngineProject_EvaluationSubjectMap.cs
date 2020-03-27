using Learun.Application.TwoDevelopment.ProjectManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-03 15:13
    /// 描 述：项目评价科目
    /// </summary>
    public class DC_EngineProject_EvaluationSubjectMap : EntityTypeConfiguration<DC_EngineProject_EvaluationSubjectEntity>
    {
        public DC_EngineProject_EvaluationSubjectMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ENGINEPROJECT_EVALUATIONSUBJECT");
            //主键
            this.HasKey(t => t.F_ProjectEvaluationId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

