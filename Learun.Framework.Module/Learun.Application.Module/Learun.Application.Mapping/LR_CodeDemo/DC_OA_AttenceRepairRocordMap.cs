﻿using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-10 14:09
    /// 描 述：DC_OA_AttenceRepairRocord
    /// </summary>
    public class DC_OA_AttenceRepairRocordMap : EntityTypeConfiguration<DC_OA_AttenceRepairRocordEntity>
    {
        public DC_OA_AttenceRepairRocordMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_ATTENCEREPAIRROCORD");
            //主键

            //主键
            this.HasKey(t => t.DC_OA_RepairRecordId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

