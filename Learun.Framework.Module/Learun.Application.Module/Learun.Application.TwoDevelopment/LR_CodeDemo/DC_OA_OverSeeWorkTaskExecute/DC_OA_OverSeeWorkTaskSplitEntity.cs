using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:47
    /// 描 述：DC_OA_OverSeeWorkTaskExecute
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitEntity
    {
        #region 实体成员
        /// <summary>
        /// 主表主键
        /// </summary>
        [Column("F_OSWID")]
        public string F_OSWId { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_SECONDID")]
        public string F_SecondId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Column("F_CODE")]
        public int F_code { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [Column("F_TASKNAME")]
        public string F_TaskName { get; set; }
        /// <summary>
        /// 任务描述
        /// </summary>
        [Column("F_TASKCONTENT")]
        public string F_TaskContent { get; set; }
        /// <summary>
        /// 关键节点
        /// </summary>
        [Column("F_TASKNODE")]
        public string F_TaskNode { get; set; }
        /// <summary>
        /// 节点时间
        /// </summary>
        [Column("F_TASKNODEDATE")]
        public DateTime? F_TaskNodeDate { get; set; }
        /// <summary>
        /// 节点起始时间 
        /// </summary>
        [Column("F_TaskNodeDateFirst")]
        public DateTime? F_TaskNodeDateFirst { get; set; }
        /// <summary>
        /// 主办单位主键
        /// </summary>
        [Column("F_ONEDEPARTMENTID")]
        public string F_OneDepartmentId { get; set; }
        /// <summary>
        /// 主办单位
        /// </summary>
        [Column("F_ONEDEPARTMENT")]
        public string F_OneDepartment { get; set; }
        /// <summary>
        /// 主办人主键
        /// </summary>
        [Column("F_ONEUSERID")]
        public string F_OneUserId { get; set; }
        /// <summary>
        /// 主办人
        /// </summary>
        [Column("F_ONEUSER")]
        public string F_OneUser { get; set; }
        /// <summary>
        /// 主办领导主键
        /// </summary>
        [Column("F_ONELEADERID")]
        public string F_OneLeaderId { get; set; }
        /// <summary>
        /// 主办领导
        /// </summary>
        [Column("F_ONELEADER")]
        public string F_OneLeader { get; set; }
        /// <summary>
        /// 协办单位主键,可保存多个值，采用"|"分隔
        /// </summary>
        [Column("F_TWODEPARTMENTID")]
        public string F_TwoDepartmentId { get; set; }
        /// <summary>
        /// 协办单位,可保存多个值，采用"|"分隔
        /// </summary>
        [Column("F_TWODEPARTMENT")]
        public string F_TwoDepartment { get; set; }
        /// <summary>
        /// 协办人主键,可保存多个值，采用"|"分隔
        /// </summary>
        [Column("F_TWOUSERID")]
        public string F_TwoUserId { get; set; }
        /// <summary>
        /// 协办人,可保存多个值，采用"|"分隔
        /// </summary>
        [Column("F_TWOUSER")]
        public string F_TwoUser { get; set; }
        /// <summary>
        /// 任务状态,0：执行；1：暂停；2：终止；3：完成
        /// </summary>
        [Column("F_STATE")]
        public int F_State { get; set; }
        /// <summary>
        /// F_ParentId
        /// </summary>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        [Column("F_ProcessId")]
        public string F_ProcessId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_SecondId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_SecondId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

