using Learun.Application.TwoDevelopment.AssetManager;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-07 15:15
    /// 描 述：DC_ASSETS_BusStopBillboardsRentDetail
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentDetailMap : EntityTypeConfiguration<DC_ASSETS_BusStopBillboardsRentDetailEntity>
    {
        public DC_ASSETS_BusStopBillboardsRentDetailMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_ASSETS_BUSSTOPBILLBOARDSRENTDETAIL");
            //主键
            this.HasKey(t => t.F_BSBRDId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

