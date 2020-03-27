using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-12-04 14:52
    /// 描 述：formtable_main_150
    /// </summary>
    public class formtable_main_150Map : EntityTypeConfiguration<formtable_main_150Entity>
    {
        public formtable_main_150Map()
        {
            #region 表、主键
            //表
            this.ToTable("FORMTABLE_MAIN_150");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

