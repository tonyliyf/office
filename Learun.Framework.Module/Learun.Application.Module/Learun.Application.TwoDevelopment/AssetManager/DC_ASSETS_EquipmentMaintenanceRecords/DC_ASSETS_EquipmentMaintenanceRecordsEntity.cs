using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-18 11:10
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecords
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenanceRecordsEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EMRID")]
        public string F_EMRId { get; set; }
        /// <summary>
        /// 设备信息主键
        /// </summary>
        [Column("F_EIID")]
        public string F_EIId { get; set; }
        /// <summary>
        /// 维修单号,取系统维修单号
        /// </summary>
        [Column("F_MAINTENANCENUMBER")]
        public string F_MaintenanceNumber { get; set; }
        /// <summary>
        /// 申请部门主键
        /// </summary>
        [Column("F_APPLICATIONDEPARTMENTID")]
        public string F_ApplicationDepartmentId { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        [Column("F_APPLICATIONDEPARTMENT")]
        public string F_ApplicationDepartment { get; set; }
        /// <summary>
        /// 申请人主键
        /// </summary>
        [Column("F_APPLICATIONUSERID")]
        public string F_ApplicationUserId { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        [Column("F_APPLICATIONUSER")]
        public string F_ApplicationUser { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        [Column("F_APPLICATIONDATE")]
        public DateTime? F_ApplicationDate { get; set; }
        /// <summary>
        /// 故障描述
        /// </summary>
        [Column("F_FAULTDESCRIPTION")]
        public string F_FaultDescription { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
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
        /// <summary>
        /// 维修状态,0:申请中；1：维修中；2：维修完毕
        /// </summary>
        [Column("维修状态")]
        public int? State { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.State = 0;
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
            this.F_EMRId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

