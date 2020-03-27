using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-12-31 21:17
    /// 描 述：车辆信息管理
    /// </summary>
    public class DC_OA_VehicleMap : EntityTypeConfiguration<DC_OA_VehicleEntity>
    {
        public DC_OA_VehicleMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_VEHICLE");
            //主键
            this.HasKey(t => t.F_VehicleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

