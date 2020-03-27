using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 13:32
    /// 描 述：DC_ASSETS_EquipmentPartsInfo
    /// </summary>
    public class DC_ASSETS_EquipmentPartsInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EPIID")]
        public string F_EPIId { get; set; }
        /// <summary>
        /// 备件名称
        /// </summary>
        [Column("F_PARTSNAME")]
        public string F_PartsName { get; set; }
        /// <summary>
        /// 备件编号
        /// </summary>
        [Column("F_PARTSCODE")]
        public string F_PartsCode { get; set; }
        /// <summary>
        /// 备件类型，取自数据字典表
        /// </summary>
        [Column("F_PARTSTYPE")]
        public string F_PartsType { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [Column("F_SPECIFICATIONTYPE")]
        public string F_SpecificationType { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [Column("F_MEASUREMENTUNIT")]
        public string F_MeasurementUnit { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Column("F_UNITPRICE")]
        public double? F_UnitPrice { get; set; }
        /// <summary>
        /// 生产厂商
        /// </summary>
        [Column("F_MANUFACTURER")]
        public string F_Manufacturer { get; set; }
        /// <summary>
        /// 经销商
        /// </summary>
        [Column("F_DISTRIBUTOR")]
        public string F_Distributor { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        [Column("F_STORAGELOCATION")]
        public string F_StorageLocation { get; set; }
        /// <summary>
        /// 初始库存
        /// </summary>
        [Column("F_INITIALINVENTORY")]
        public int F_InitialInventory { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        [Column("F_MINIMUMINVENTORY")]
        public int? F_MinimumInventory { get; set; }
        /// <summary>
        /// 最大库存
        /// </summary>
        [Column("F_MAXIMUMINVENTORY")]
        public int? F_MaximumInventory { get; set; }
        /// <summary>
        /// 图片附件
        /// </summary>
        [Column("F_PICTUREACCESSORIES")]
        public string F_PictureAccessories { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 配件状态，取自数据字典表
        /// </summary>
        [Column("F_PARTSSTATE")]
        public string F_PartsState { get; set; }
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
            this.F_EPIId = Guid.NewGuid().ToString();
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
            this.F_EPIId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

