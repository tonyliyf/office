using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 12:10
    /// 描 述：DC_OA_PerformanceExecute
    /// </summary>
    public class DC_OA_PerformanceExecuteEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PEID")]
        public string F_PEId { get; set; }
        /// <summary>
        /// 工作计划表主键
        /// </summary>
        [Column("F_PUWID")]
        public string F_PUWId { get; set; }
        /// <summary>
        /// 执行环节,系统字段：工作计划、考核评估、考核自评、考核评价、考核审核、考核申诉、考核面谈
        /// </summary>
        [Column("F_PEPOINT")]
        public string F_PEPoint { get; set; }
        /// <summary>
        /// 执行状态，0：执行中；1：通过；2：不通过
        /// </summary>
        [Column("F_POINTSTATE")]
        public int? F_PointState { get; set; }
        /// <summary>
        /// 执行人部门主键
        /// </summary>
        [Column("F_POINTDEPARTMENTID")]
        public string F_PointDepartmentId { get; set; }
        /// <summary>
        /// 执行人主键
        /// </summary>
        [Column("F_POINTUSERID")]
        public string F_PointUserId { get; set; }
        /// <summary>
        /// 执行意见
        /// </summary>
        [Column("F_POINTTEXT")]
        public string F_PointText { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        [Column("F_POINTDATETIME")]
        public DateTime? F_PointDateTime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            UserInfo info = LoginUserInfo.Get();
            this.F_PEId = Guid.NewGuid().ToString();
            this.F_PointDateTime = DateTime.Now;
            this.F_PointUserId = info.userId;
            this.F_PointDepartmentId = info.departmentId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PEId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

