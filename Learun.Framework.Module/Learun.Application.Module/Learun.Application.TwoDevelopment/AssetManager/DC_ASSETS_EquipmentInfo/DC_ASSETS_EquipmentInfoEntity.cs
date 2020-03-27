using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 11:09
    /// 描 述：DC_ASSETS_EquipmentInfo
    /// </summary>
    public class DC_ASSETS_EquipmentInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EIID")]
        public string F_EIId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [Column("F_EQUIPMENTNAME")]
        public string F_EquipmentName { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        [Column("F_EQUIPMENTNUMBER")]
        public string F_EquipmentNumber { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [Column("F_SPECIFICATIONTYPE")]
        public string F_SpecificationType { get; set; }
        /// <summary>
        /// 设备类别，取自数据字典
        /// </summary>
        [Column("F_EQUIPMENTCATEGORY")]
        public string F_EquipmentCategory { get; set; }
        /// <summary>
        /// 生产厂商，取自往来单位表
        /// </summary>
        [Column("F_MANUFACTURER")]
        public string F_Manufacturer { get; set; }
        /// <summary>
        /// 资产原值
        /// </summary>
        [Column("F_ORIGINALVALUEASSETS")]
        public double? F_OriginalValueAssets { get; set; }
        /// <summary>
        /// 总功率kw
        /// </summary>
        [Column("F_TOTALPOWERKW")]
        public double? F_TotalPowerKW { get; set; }
        /// <summary>
        /// 经销商，取自往来单位表
        /// </summary>
        [Column("F_DISTRIBUTOR")]
        public string F_Distributor { get; set; }
        /// <summary>
        /// 设备标识，取自数据字典表，如：一般设备、大型设备等
        /// </summary>
        [Column("F_DEVICEIDENTIFICATION")]
        public string F_DeviceIdentification { get; set; }
        /// <summary>
        /// 购置时间
        /// </summary>
        [Column("F_ACQUISITIONTIME")]
        public DateTime? F_AcquisitionTime { get; set; }
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
        /// 操作人主键
        /// </summary>
        [Column("F_OPERATORID")]
        public string F_OperatorId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Column("F_OPERATOR")]
        public string F_Operator { get; set; }
        /// <summary>
        /// 净残值
        /// </summary>
        [Column("F_NETSALVAGEVALUE")]
        public double? F_NetSalvageValue { get; set; }
        /// <summary>
        /// 安装地点
        /// </summary>
        [Column("F_INSTALLATIONLOCATION")]
        public string F_InstallationLocation { get; set; }
        /// <summary>
        /// 折旧方法,取数据字典表
        /// </summary>
        [Column("F_DEPRECIATIONMETHOD")]
        public string F_DepreciationMethod { get; set; }
        /// <summary>
        /// 折旧年限
        /// </summary>
        [Column("F_USEFULYEAR")]
        public double? F_UsefulYear { get; set; }
        /// <summary>
        /// 本月折旧
        /// </summary>
        [Column("F_DEPRECIATIONTHISMONTH")]
        public double? F_DepreciationThisMonth { get; set; }
        /// <summary>
        /// 累计折旧
        /// </summary>
        [Column("F_ACCUMULATEDDEPRECIATION")]
        public double? F_AccumulatedDepreciation { get; set; }
        /// <summary>
        /// 净值
        /// </summary>
        [Column("F_NETWORTH")]
        public double? F_NetWorth { get; set; }
        /// <summary>
        /// 图片附件
        /// </summary>
        [Column("F_PICTUREACCESSORIES")]
        public string F_PictureAccessories { get; set; }
        /// <summary>
        /// 使用状况，取自数据字典，如在用、报废等
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EIId = Guid.NewGuid().ToString();
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
            this.F_EIId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

