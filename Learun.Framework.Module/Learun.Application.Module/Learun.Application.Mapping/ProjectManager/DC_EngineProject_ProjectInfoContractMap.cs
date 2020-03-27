using Learun.Application.TwoDevelopment.ProjectManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-15 15:20
    /// 描 述：DC_EngineProject_ProjectInfoContract
    /// </summary>
    public class DC_EngineProject_ProjectInfoContractMap : EntityTypeConfiguration<DC_EngineProject_ProjectInfoContractEntity>
    {
        public DC_EngineProject_ProjectInfoContractMap()
        {
            //#region 表、主键
            ////表
            //this.ToTable("formtable_main_130");
            ////主键
            //this.HasKey(t => t.F_PICId);
            //#endregion

            //#region 配置关系
            //#endregion

            #region 表、主键
            //表
            this.ToTable("DC_ENGINEPROJECT_PROJECTINFOCONTRACT");
            //主键
            this.HasKey(t => t.F_PICId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

