﻿using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:15
    /// 描 述：HrmSubCompany
    /// </summary>
    public class HrmSubCompanyMap : EntityTypeConfiguration<HrmSubCompanyEntity>
    {
        public HrmSubCompanyMap()
        {
            #region 表、主键
            //表
            this.ToTable("HRMSUBCOMPANY");
            //主键
            #endregion
            //主键
            this.HasKey(t => t.id);
            #region 配置关系
            #endregion
        }
    }
}
