using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.AssetManager

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-16 11:14
    /// 描 述：DC_ASSETS_BusStopBillboardsMaintenanceRecords
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsMaintenanceRecordsEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_BSBMRID")]
        public string F_BSBMRId { get; set; }
        /// <summary>
        /// 广告牌信息主键
        /// </summary>
        /// <returns></returns>
        [Column("F_BSBID")]
        public string F_BSBId { get; set; }
        /// <summary>
        /// 维修单号,取系统维修单号
        /// </summary>
        /// <returns></returns>
        [Column("F_MAINTENANCENUMBER")]
        public string F_MaintenanceNumber { get; set; }
        /// <summary>
        /// 申请部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_APPLICATIONDEPARTMENTID")]
        public string F_ApplicationDepartmentId { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        /// <returns></returns>
        [Column("F_APPLICATIONDEPARTMENT")]
        public string F_ApplicationDepartment { get; set; }
        /// <summary>
        /// 申请人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_APPLICATIONUSERID")]
        public string F_ApplicationUserId { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        /// <returns></returns>
        [Column("F_APPLICATIONUSER")]
        public string F_ApplicationUser { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        /// <returns></returns>
        [Column("F_APPLICATIONDATE")]
        public DateTime? F_ApplicationDate { get; set; }
        /// <summary>
        /// 故障描述
        /// </summary>
        /// <returns></returns>
        [Column("F_FAULTDESCRIPTION")]
        public string F_FaultDescription { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 记录人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// 维修状态,0:申请中；1：维修中；2：维修完毕
        /// </summary>
        /// <returns></returns>
        [Column("F_MAINTENANCESTATE")]
        public string F_MaintenanceState { get; set; }
        /// <summary>
        /// 办结状态,1:流程中；2：办结（结束）；-1：驳回；默认1
        /// </summary>
        /// <returns></returns>
        [Column("IS_AGREE")]
        public string is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_BSBMRId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_BSBMRId = keyValue;
        }
        #endregion
    }
}

