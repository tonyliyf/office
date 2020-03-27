using Learun.Application.TwoDevelopment.LR_ReportModule;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-28 15:06
    /// 描 述：维修车辆统计报表
    /// </summary>
    public class DC_OA_VehicleRepairRecordMap : EntityTypeConfiguration<DC_OA_VehicleRepairRecordEntity>
    {
        public DC_OA_VehicleRepairRecordMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_VEHICLEREPAIRRECORD");
            //主键
            this.HasKey(t => t.F_VehicleRepairId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

