using Learun.Application.TwoDevelopment.ProjectManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 15:56
    /// 描 述：工程项目单位信息管理
    /// </summary>
    public class DC_EngineProject_ProjectInfoUnitMap : EntityTypeConfiguration<DC_EngineProject_ProjectInfoUnitEntity>
    {
        public DC_EngineProject_ProjectInfoUnitMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ENGINEPROJECT_PROJECTINFOUNIT");
            //主键
            this.HasKey(t => t.F_PIUId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

