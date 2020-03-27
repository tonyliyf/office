using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 11:36
    /// 描 述：DC_ASSETS_LandBaseInfo
    /// </summary>
    public class DC_ASSETS_LandBaseInfoEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_LBIID")]
        public string F_LBIId { get; set; }
        /// <summary>
        /// 土地证号
        /// </summary>
        [Column("F_LANDCERTIFICATE")]
        public string F_LandCertificate { get; set; }
        /// <summary>
        /// 宗地编号
        /// </summary>
        [Column("F_LANDNUMBER")]
        public string F_LandNumber { get; set; }
        /// <summary>
        /// 资产编号，取系统资产编号编码
        /// </summary>
        [Column("F_ASSETSNUMBER")]
        public string F_AssetsNumber { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        [Column("F_AREA")]
        public double? F_Area { get; set; }
        /// <summary>
        /// 土地使用性质，取数据字典
        /// </summary>
        [Column("F_LANDUSENATURE")]
        public string F_LandUseNature { get; set; }
        /// <summary>
        /// 土地使用权类型，取数据字典
        /// </summary>
        [Column("F_LANDUSERIGHT")]
        public string F_LandUseRight { get; set; }
        /// <summary>
        /// 出让年限
        /// </summary>
        [Column("F_TRANSFERAGE")]
        public int? F_TransferAge { get; set; }
        /// <summary>
        /// 出让单价
        /// </summary>
        [Column("F_SELLINGPRICE")]
        public double? F_SellingPrice { get; set; }
        /// <summary>
        /// 出让金额  
        /// </summary>
        [Column("F_TRANSFERAMOUNT")]
        public double? F_TransferAmount { get; set; }
        /// <summary>
        /// 宗地地址
        /// </summary>
        [Column("F_PARCELADDRESS")]
        public string F_ParcelAddress { get; set; }
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
        /// 交付日期
        /// </summary>
        [Column("F_DELIVERYDATE")]
        public DateTime? F_DeliveryDate { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 开工到期
        /// </summary>
        [Column("F_STARTLIMIT")]
        public DateTime? F_StartLimit { get; set; }
        /// <summary>
        /// 竣工日期
        /// </summary>
        [Column("F_COMPLETIONDATE")]
        public DateTime? F_CompletionDate { get; set; }
        /// <summary>
        /// 出让人，一般外部单位，手工填写
        /// </summary>
        [Column("F_TRANSFEROR")]
        public string F_Transferor { get; set; }
        /// <summary>
        /// 受让人，取单位组织公司表
        /// </summary>
        [Column("F_ASSIGNEE")]
        public string F_Assignee { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        [Column("F_CONTRACTNUMBER")]
        public string F_ContractNumber { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>
        [Column("F_CONTRACTNAME")]
        public string F_ContractName { get; set; }
        /// <summary>
        /// 合同附件
        /// </summary>
        [Column("F_CONTRACTACCESSORIES")]
        public string F_ContractAccessories { get; set; }
        /// <summary>
        /// 成交确认书附件
        /// </summary>
        [Column("F_SALESCONFIRMATION")]
        public string F_SalesConfirmation { get; set; }
        /// <summary>
        /// 票据说明
        /// </summary>
        [Column("F_NOTEDESCRIPTION")]
        public string F_NoteDescription { get; set; }
        /// <summary>
        /// 票据附件
        /// </summary>
        [Column("F_NOTEACCESSORIES")]
        public string F_NoteAccessories { get; set; }
        /// <summary>
        /// 其他资料附件
        /// </summary>
        [Column("F_OTHERACCESSORIES")]
        public string F_OtherAccessories { get; set; }
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
        /// 土地名称
        /// </summary>
        [Column("F_LANDNAME")]
        public string F_LandName { get; set; }

        /// <summary>
        /// 行政区划
        /// </summary>
        [Column("F_CommunityCode")]
        public string F_CommunityCode { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            UserInfo user = LoginUserInfo.Get();
            this.F_LBIId = Guid.NewGuid().ToString();
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
            this.F_LBIId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }

    public class DC_ASSETS_ComLandBaseInfo {

        public string F_ContractNumber { get; set; }

        public string F_ActualPrice { get; set; }
        public string F_YearNumber { get; set; }
        public string F_Renter { get; set; }
        public string F_RenterPhone { get; set; }
        public string F_RentStartTime { get; set; }
        public string F_RentEndTime { get; set; }

        public string F_HouseName { get; set; }
    }

}

