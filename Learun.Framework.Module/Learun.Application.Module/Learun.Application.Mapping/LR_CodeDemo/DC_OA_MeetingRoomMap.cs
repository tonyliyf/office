using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 17:44
    /// 描 述：会议室管理
    /// </summary>
    public class DC_OA_MeetingRoomMap : EntityTypeConfiguration<DC_OA_MeetingRoomEntity>
    {
        public DC_OA_MeetingRoomMap()
        {
            #region 表、主键
            //表
            this.ToTable("DC_OA_MEETINGROOM");
            //主键
            this.HasKey(t => t.Dc_OA_MeetingRoomId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

