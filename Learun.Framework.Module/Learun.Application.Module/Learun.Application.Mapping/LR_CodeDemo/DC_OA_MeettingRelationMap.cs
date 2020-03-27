using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-29 11:22
    /// 描 述：会议通知回执
    /// </summary>
    public class DC_OA_MeettingRelationMap : EntityTypeConfiguration<DC_OA_MeettingRelationEntity>
    {
        public DC_OA_MeettingRelationMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_MEETTINGRELATION");
            //主键
            this.HasKey(t => t.MeettingId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

