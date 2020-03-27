using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-02 12:34
    /// 描 述：DC_OA_OverSeeWorkClosing
    /// </summary>
    public class DC_OA_OverSeeWorkClosingEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_OSWCID")]
        public string F_OSWCId { get; set; }
        /// <summary>
        /// 督查督办工作表主键
        /// </summary>
        [Column("F_OSWID")]
        public string F_OSWId { get; set; }
        /// <summary>
        /// 工作事项
        /// </summary>
        [Column("F_OSWCONTENT")]
        public string F_OSWContent { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("F_BEGINDATE")]
        public DateTime? F_BeginDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("F_ENDDATE")]
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 牵头部门主键
        /// </summary>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 牵头部门
        /// </summary>
        [Column("F_DEPARTMENT")]
        public string F_Department { get; set; }
        /// <summary>
        /// 牵头部门责任人主键
        /// </summary>
        [Column("F_LEADERUSERID")]
        public string F_LeaderUserId { get; set; }
        /// <summary>
        /// 牵头部门责任人
        /// </summary>
        [Column("F_LEADERUSER")]
        public string F_LeaderUser { get; set; }
        /// <summary>
        /// 督办人主键
        /// </summary>
        [Column("F_OVERSEEUSERID")]
        public string F_OverSeeUserId { get; set; }
        /// <summary>
        /// 督办人
        /// </summary>
        [Column("F_OVERSEEUSER")]
        public string F_OverSeeUser { get; set; }
        /// <summary>
        /// 督办工作分类，取值于数据字典表，如日常督办、重点建设项目、投资项目、政府工作报告、总经理办公室
        /// </summary>
        [Column("F_OSWTYPE")]
        public string F_OSWType { get; set; }
        /// <summary>
        /// 责任领导主键
        /// </summary>
        [Column("F_HIGHLEADERID")]
        public string F_HighLeaderId { get; set; }
        /// <summary>
        /// 责任领导
        /// </summary>
        [Column("F_HIGHLEADER")]
        public string F_HighLeader { get; set; }
        /// <summary>
        /// 实际办结时间
        /// </summary>
        [Column("F_ENDCLOSEDATE")]
        public DateTime? F_EndCloseDate { get; set; }
        /// <summary>
        /// 申请办结说明
        /// </summary>
        [Column("F_CLOSEEXPLAIN")]
        public string F_CloseExplain { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_OSWCId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

