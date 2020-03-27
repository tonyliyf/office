using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-18 17:47
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecordsProcess
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EMRPID")]
        public string F_EMRPId { get; set; }
        /// <summary>
        /// 设备维修记录主键
        /// </summary>
        [Column("F_EMRID")]
        public string F_EMRId { get; set; }
        /// <summary>
        /// 维修负责部门主键
        /// </summary>
        [Column("F_MAINTENANCEDEPARTMENTID")]
        public string F_MaintenanceDepartmentId { get; set; }
        /// <summary>
        /// 维修负责部门
        /// </summary>
        [Column("F_MAINTENANCEDEPARTMENT")]
        public string F_MaintenanceDepartment { get; set; }
        /// <summary>
        /// 维修负责人主键
        /// </summary>
        [Column("F_MAINTENANCEUSERID")]
        public string F_MaintenanceUserId { get; set; }
        /// <summary>
        /// 维修负责人
        /// </summary>
        [Column("F_MAINTENANCEUSER")]
        public string F_MaintenanceUser { get; set; }
        /// <summary>
        /// 故障类别,取数据字典
        /// </summary>
        [Column("F_FAULTCLASSIFICATION")]
        public string F_FaultClassification { get; set; }
        /// <summary>
        /// 故障分析
        /// </summary>
        [Column("F_FAULTANALYSIS")]
        public string F_FaultAnalysis { get; set; }
        /// <summary>
        /// 维修级别，取数据字典
        /// </summary>
        [Column("F_MAINTENANCELEVEL")]
        public string F_MaintenanceLevel { get; set; }
        /// <summary>
        /// 维修费用
        /// </summary>
        [Column("F_MAINTENANCECOSTS")]
        public double? F_MaintenanceCosts { get; set; }
        /// <summary>
        /// 维修说明
        /// </summary>
        [Column("F_MAINTENANCEINSTRUCTIONS")]
        public string F_MaintenanceInstructions { get; set; }
        /// <summary>
        /// 维修时间
        /// </summary>
        [Column("F_MAINTENANCEDATE")]
        public DateTime? F_MaintenanceDate { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 记录人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EMRPId = Guid.NewGuid().ToString();
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateDatetime = DateTime.Now;
            this.F_CreateUser = user.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EMRPId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

