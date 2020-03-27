using Learun.Application.TwoDevelopment.ProjectManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-20 12:20
    /// 描 述：DC_EngineProject_ProjectTasksProgress
    /// </summary>
    public class DC_EngineProject_ProjectTasksProgressMap : EntityTypeConfiguration<DC_EngineProject_ProjectTasksProgressEntity>
    {
        public DC_EngineProject_ProjectTasksProgressMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ENGINEPROJECT_PROJECTTASKSPROGRESS");
            //主键
            this.HasKey(t => t.F_PTPId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

