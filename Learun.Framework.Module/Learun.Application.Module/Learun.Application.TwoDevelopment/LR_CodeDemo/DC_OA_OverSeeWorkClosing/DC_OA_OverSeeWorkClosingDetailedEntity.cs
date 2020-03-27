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
    public class DC_OA_OverSeeWorkClosingDetailedEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_OSWDDID")]
        public string F_OSWDDId { get; set; }
        /// <summary>
        /// 督办任务分解主键
        /// </summary>
        [Column("F_SECONDID")]
        public string F_SecondId { get; set; }
        /// <summary>
        /// 督办工作延期审批单主键
        /// </summary>
        [Column("F_OSWCID")]
        public string F_OSWCId { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [Column("F_CODE")]
        public int? F_code { get; set; }
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
        /// 起始时间
        /// </summary>
        [Column("F_TASKNODEDATEFIRST")]
        public DateTime? F_TaskNodeDateFirst { get; set; }
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
        /// 主办单位
        /// </summary>
        [Column("F_ONEDEPARTMENT")]
        public string F_OneDepartment { get; set; }
        /// <summary>
        /// 主办人
        /// </summary>
        [Column("F_ONEUSER")]
        public string F_OneUser { get; set; }
        /// <summary>
        /// 主办领导
        /// </summary>
        [Column("F_ONELEADER")]
        public string F_OneLeader { get; set; }
        /// <summary>
        /// 协办单位,可保存多个值，采用"|"分隔
        /// </summary>
        [Column("F_TWODEPARTMENT")]
        public string F_TwoDepartment { get; set; }
        /// <summary>
        /// 协办人,可保存多个值，采用"|"分隔
        /// </summary>
        [Column("F_TWOUSER")]
        public string F_TwoUser { get; set; }
        /// <summary>
        /// 执行情况,从执行记录表拼接：执行部门+执行人+执行时间+执行情况
        /// </summary>
        [Column("F_EXECUTECONTENT")]
        public string F_ExecuteContent { get; set; }
        /// <summary>
        /// 任务状态,0：执行；1：暂停；2：终止；3：完成
        /// </summary>
        [Column("F_STATE")]
        public string F_State { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_OSWDDId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_OSWDDId = keyValue;
        }
        #endregion
    }
}

