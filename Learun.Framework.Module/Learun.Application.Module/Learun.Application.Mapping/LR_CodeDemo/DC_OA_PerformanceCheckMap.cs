using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-29 15:44
    /// 描 述：DC_OA_PerformanceCheck
    /// </summary>
    public class DC_OA_PerformanceCheckMap : EntityTypeConfiguration<DC_OA_PerformanceCheckEntity>
    {
        public DC_OA_PerformanceCheckMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_PERFORMANCECHECK");
            //主键
            this.HasKey(t => t.F_EmpolyeeCheckId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

