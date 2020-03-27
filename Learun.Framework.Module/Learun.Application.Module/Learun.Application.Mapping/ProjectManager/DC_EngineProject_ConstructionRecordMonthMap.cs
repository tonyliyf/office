using Learun.Application.TwoDevelopment.ProjectManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-25 17:27
    /// 描 述：DC_EngineProject_ConstructionRecordMonth
    /// </summary>
    public class DC_EngineProject_ConstructionRecordMonthMap : EntityTypeConfiguration<DC_EngineProject_ConstructionRecordMonthEntity>
    {
        public DC_EngineProject_ConstructionRecordMonthMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ENGINEPROJECT_CONSTRUCTIONRECORDMONTH");
            //主键
            this.HasKey(t => t.F_EPCRMId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

