using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 11:19
    /// 描 述：DC_OA_OverSeeWork
    /// </summary>
    public class DC_OA_OverSeeWorkEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_OSWID")]
        public string F_OSWId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Column("F_OSWCODE")]
        public string F_OSWCode { get; set; }
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
        /// 备注
        /// </summary>
        [Column("F_MARKS")]
        public string F_Marks { get; set; }
        /// <summary>
        /// 状态,0：执行；1：暂停；2：终止；3：完成
        /// </summary>
        [Column("F_STATE")]
        public string F_State { get; set; }
        [Column("F_OSWType")]
        public string F_OSWType { get; set; }
        [Column("F_DOHId")]
        public string F_DOHId { get; set; }
        [Column("F_HighLeaderId")]
        public string F_HighLeaderId { get; set; }
        [Column("F_HighLeader")]
        public string F_HighLeader { get; set; }
        [Column("F_OSCaptain")]
        public string F_OSCaptain { get; set; }


        [Column("F_VISITFROM")]
        public string F_VisitFrom { get; set; }
        [Column("F_CreateDate")]
        public DateTime? F_CreateDate { get; set; }
        [Column("F_Draft")]
        public int F_Draft { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_OSWId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_OSWId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

