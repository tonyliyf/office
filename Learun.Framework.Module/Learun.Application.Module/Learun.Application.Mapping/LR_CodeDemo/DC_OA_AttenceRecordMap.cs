using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 16:32
    /// 描 述：打卡记录
    /// </summary>
    public class DC_OA_AttenceRecordMap : EntityTypeConfiguration<DC_OA_AttenceRecordEntity>
    {
        public DC_OA_AttenceRecordMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_ATTENCERECORD");
            //主键
            this.HasKey(t => t.DC_OA_AttenceRecordId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

