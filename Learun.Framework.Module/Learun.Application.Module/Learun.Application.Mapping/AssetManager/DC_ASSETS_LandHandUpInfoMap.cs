using Learun.Application.TwoDevelopment.AssetManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-23 12:01
    /// 描 述：DC_ASSETS_LandHandUpInfo
    /// </summary>
    public class DC_ASSETS_LandHandUpInfoMap : EntityTypeConfiguration<DC_ASSETS_LandHandUpInfoEntity>
    {
        public DC_ASSETS_LandHandUpInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ASSETS_LANDHANDUPINFO");
            //主键
            this.HasKey(t => t.F_LandHandUpid);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

