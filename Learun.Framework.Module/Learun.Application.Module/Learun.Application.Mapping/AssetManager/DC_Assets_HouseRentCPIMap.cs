using Learun.Application.TwoDevelopment.AssetManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-19 20:39
    /// 描 述：租房CPI系数
    /// </summary>
    public class DC_Assets_HouseRentCPIMap : EntityTypeConfiguration<DC_Assets_HouseRentCPIEntity>
    {
        public DC_Assets_HouseRentCPIMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ASSETS_HOUSERENTCPI");
            //主键
            this.HasKey(t => t.F_CPIID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

