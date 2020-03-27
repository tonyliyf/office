﻿using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-02 16:37
    /// 描 述：DC_OA_OverSeeWorkDelay
    /// </summary>
    public class DC_OA_OverSeeWorkDelayDetailedMap : EntityTypeConfiguration<DC_OA_OverSeeWorkDelayDetailedEntity>
    {
        public DC_OA_OverSeeWorkDelayDetailedMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_OVERSEEWORKDELAYDETAILED");
            //主键
            this.HasKey(t => t.F_OSWDDId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

