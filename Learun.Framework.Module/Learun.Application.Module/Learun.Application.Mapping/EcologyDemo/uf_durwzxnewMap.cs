using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-09 16:38
    /// 描 述：督办任务执行表
    /// </summary>
    public class uf_durwzxnewMap : EntityTypeConfiguration<uf_durwzxnewEntity>
    {
        public uf_durwzxnewMap()
        {
            #region 表、主键
            //表
            this.ToTable("UF_DURWZXNEW");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

