using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 15:09
    /// 描 述：DC_OA_YearHolidayRule
    /// </summary>
    public class DC_OA_YearHolidayRuleMap : EntityTypeConfiguration<DC_OA_YearHolidayRuleEntity>
    {
        public DC_OA_YearHolidayRuleMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_YEARHOLIDAYRULE");
            //主键
            this.HasKey(t => t.F_HolidayRuleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

