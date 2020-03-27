using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-02 10:05
    /// 描 述：督办任务评论
    /// </summary>
    public class uf_dbrwplbMap : EntityTypeConfiguration<uf_dbrwplbEntity>
    {
        public uf_dbrwplbMap()
        {
            #region 表、主键
            //表
            this.ToTable("UF_DBRWPLB");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

