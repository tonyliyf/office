using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-08 09:46
    /// 描 述：formtable_main_139
    /// </summary>
    public class formtable_main_139Map : EntityTypeConfiguration<formtable_main_139Entity>
    {
        public formtable_main_139Map()
        {
            #region 表、主键
            //表
            this.ToTable("FORMTABLE_MAIN_139");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

