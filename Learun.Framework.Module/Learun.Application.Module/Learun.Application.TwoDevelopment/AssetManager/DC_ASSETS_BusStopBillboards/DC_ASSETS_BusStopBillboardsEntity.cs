using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 10:05
    /// 描 述：DC_ASSETS_BusStopBillboards
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_BSBID")]
        public string F_BSBId { get; set; }
        /// <summary>
        /// 广告牌名称
        /// </summary>
        [Column("F_BILLBOARDSNAME")]
        public string F_BillboardsName { get; set; }
        /// <summary>
        /// 广告牌编号
        /// </summary>
        [Column("F_BILLBOARDSNUMBER")]
        public string F_BillboardsNumber { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [Column("F_SPECIFICATIONTYPE")]
        public string F_SpecificationType { get; set; }
        /// <summary>
        /// 广告牌类别，取自数据字典
        /// </summary>
        [Column("F_BILLBOARDSCATEGORY")]
        public string F_BillboardsCategory { get; set; }
        /// <summary>
        /// 生产厂商，取自往来单位表
        /// </summary>
        [Column("F_MANUFACTURER")]
        public string F_Manufacturer { get; set; }
        /// <summary>
        /// 服务商，取自往来单位表
        /// </summary>
        [Column("F_SERVICEPROVIDER")]
        public string F_ServiceProvider { get; set; }
        /// <summary>
        /// 广告牌标识，取自数据字典表
        /// </summary>
        [Column("F_BILLBOARDSIDENTIFICATION")]
        public string F_BillboardsIdentification { get; set; }
        /// <summary>
        /// 安装时间
        /// </summary>
        [Column("F_INSTALLATIONTIME")]
        public DateTime? F_InstallationTime { get; set; }
        /// <summary>
        /// 安装地点
        /// </summary>
        [Column("F_INSTALLATIONLOCATION")]
        public string F_InstallationLocation { get; set; }
        /// <summary>
        /// 中心点坐标
        /// </summary>
        [Column("F_CENTERPOINTCOORDINATES")]
        public string F_CenterpointCoordinates { get; set; }
        /// <summary>
        /// 边界坐标
        /// </summary>
        [Column("F_BOUNDARYCOORDINATES")]
        public string F_BoundaryCoordinates { get; set; }
        /// <summary>
        /// 图片附件
        /// </summary>
        [Column("F_PICTUREACCESSORIES")]
        public string F_PictureAccessories { get; set; }
        /// <summary>
        /// 使用部门主键
        /// </summary>
        [Column("F_USEDEPARTMENTID")]
        public string F_UseDepartmentId { get; set; }
        /// <summary>
        /// 使用部门
        /// </summary>
        [Column("F_USEDEPARTMENT")]
        public string F_UseDepartment { get; set; }
        /// <summary>
        /// 资产负责人主键
        /// </summary>
        [Column("F_LEADERID")]
        public string F_LeaderId { get; set; }
        /// <summary>
        /// 资产负责人
        /// </summary>
        [Column("F_LEADER")]
        public string F_Leader { get; set; }
        /// <summary>
        /// 管理人主键
        /// </summary>
        [Column("F_MANAGERID")]
        public string F_ManagerId { get; set; }
        /// <summary>
        /// 管理人
        /// </summary>
        [Column("F_MANAGER")]
        public string F_Manager { get; set; }
        /// <summary>
        /// 使用状况，取自数据字典，如在用、维修等
        /// </summary>
        [Column("F_USESTATE")]
        public string F_UseState { get; set; }
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
        /// 特别说明
        /// </summary>
        [Column("F_REMARK")]
        public DateTime? F_Remark { get; set; }

        
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_BSBId = Guid.NewGuid().ToString();
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
            this.F_BSBId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

