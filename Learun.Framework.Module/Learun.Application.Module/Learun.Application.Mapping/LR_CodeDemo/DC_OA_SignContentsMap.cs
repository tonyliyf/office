using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-09 22:13
    /// 描 述：常用签字意见
    /// </summary>
    public class DC_OA_SignContentsMap : EntityTypeConfiguration<DC_OA_SignContentsEntity>
    {
        public DC_OA_SignContentsMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_SIGNCONTENTS");
            //主键
            this.HasKey(t => t.DC_OA_SignId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

