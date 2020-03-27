using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.AssetManager

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 09:48
    /// 描 述：粮食土地房屋信息管理
    /// </summary>
    public class DC_ASSETS_LandBaseInfofoodEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_LBIId
        /// </summary>
        /// <returns></returns>
        [Column("F_LBIID")]
        public string F_LBIId { get; set; }
        /// <summary>
        /// F_LandCertificate
        /// </summary>
        /// <returns></returns>
        [Column("F_LANDCERTIFICATE")]
        public string F_LandCertificate { get; set; }
        /// <summary>
        /// F_LandNumber
        /// </summary>
        /// <returns></returns>
        [Column("F_LANDNUMBER")]
        public string F_LandNumber { get; set; }
        /// <summary>
        /// F_AssetsNumber
        /// </summary>
        /// <returns></returns>
        [Column("F_ASSETSNUMBER")]
        public string F_AssetsNumber { get; set; }
        /// <summary>
        /// F_Area
        /// </summary>
        /// <returns></returns>
        [Column("F_AREA")]
        public double? F_Area { get; set; }
        /// <summary>
        /// F_LandUseNature
        /// </summary>
        /// <returns></returns>
        [Column("F_LANDUSENATURE")]
        public string F_LandUseNature { get; set; }
        /// <summary>
        /// F_LandUseRight
        /// </summary>
        /// <returns></returns>
        [Column("F_LANDUSERIGHT")]
        public string F_LandUseRight { get; set; }
        /// <summary>
        /// F_TransferAge
        /// </summary>
        /// <returns></returns>
        [Column("F_TRANSFERAGE")]
        public int? F_TransferAge { get; set; }
        /// <summary>
        /// F_SellingPrice
        /// </summary>
        /// <returns></returns>
        [Column("F_SELLINGPRICE")]
        public decimal? F_SellingPrice { get; set; }
        /// <summary>
        /// F_TransferAmount
        /// </summary>
        /// <returns></returns>
        [Column("F_TRANSFERAMOUNT")]
        public double? F_TransferAmount { get; set; }
        /// <summary>
        /// F_ParcelAddress
        /// </summary>
        /// <returns></returns>
        [Column("F_PARCELADDRESS")]
        public string F_ParcelAddress { get; set; }
        /// <summary>
        /// F_CenterpointCoordinates
        /// </summary>
        /// <returns></returns>
        [Column("F_CENTERPOINTCOORDINATES")]
        public string F_CenterpointCoordinates { get; set; }
        /// <summary>
        /// F_BoundaryCoordinates
        /// </summary>
        /// <returns></returns>
        [Column("F_BOUNDARYCOORDINATES")]
        public string F_BoundaryCoordinates { get; set; }
        /// <summary>
        /// F_PictureAccessories
        /// </summary>
        /// <returns></returns>
        [Column("F_PICTUREACCESSORIES")]
        public string F_PictureAccessories { get; set; }
        /// <summary>
        /// F_DeliveryDate
        /// </summary>
        /// <returns></returns>
        [Column("F_DELIVERYDATE")]
        public DateTime? F_DeliveryDate { get; set; }
        /// <summary>
        /// F_StartDate
        /// </summary>
        /// <returns></returns>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// F_StartLimit
        /// </summary>
        /// <returns></returns>
        [Column("F_STARTLIMIT")]
        public DateTime? F_StartLimit { get; set; }
        /// <summary>
        /// F_CompletionDate
        /// </summary>
        /// <returns></returns>
        [Column("F_COMPLETIONDATE")]
        public DateTime? F_CompletionDate { get; set; }
        /// <summary>
        /// F_Transferor
        /// </summary>
        /// <returns></returns>
        [Column("F_TRANSFEROR")]
        public string F_Transferor { get; set; }
        /// <summary>
        /// F_Assignee
        /// </summary>
        /// <returns></returns>
        [Column("F_ASSIGNEE")]
        public string F_Assignee { get; set; }
        /// <summary>
        /// F_ContractNumber
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTRACTNUMBER")]
        public string F_ContractNumber { get; set; }
        /// <summary>
        /// F_ContractName
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTRACTNAME")]
        public string F_ContractName { get; set; }
        /// <summary>
        /// F_ContractAccessories
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTRACTACCESSORIES")]
        public string F_ContractAccessories { get; set; }
        /// <summary>
        /// F_SalesConfirmation
        /// </summary>
        /// <returns></returns>
        [Column("F_SALESCONFIRMATION")]
        public string F_SalesConfirmation { get; set; }
        /// <summary>
        /// F_NoteDescription
        /// </summary>
        /// <returns></returns>
        [Column("F_NOTEDESCRIPTION")]
        public string F_NoteDescription { get; set; }
        /// <summary>
        /// F_NoteAccessories
        /// </summary>
        /// <returns></returns>
        [Column("F_NOTEACCESSORIES")]
        public string F_NoteAccessories { get; set; }
        /// <summary>
        /// F_OtherAccessories
        /// </summary>
        /// <returns></returns>
        [Column("F_OTHERACCESSORIES")]
        public string F_OtherAccessories { get; set; }
        /// <summary>
        /// F_Remarks
        /// </summary>
        /// <returns></returns>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// F_CreateDepartmentId
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// F_CreateDepartment
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// F_CreateUserid
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// F_CreateUser
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// F_CreateDatetime
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// F_IfStockLand
        /// </summary>
        /// <returns></returns>
        [Column("F_IFSTOCKLAND")]
        public int? F_IfStockLand { get; set; }
        /// <summary>
        /// F_CommunityCode
        /// </summary>
        /// <returns></returns>
        [Column("F_COMMUNITYCODE")]
        public string F_CommunityCode { get; set; }
        /// <summary>
        /// F_LandName
        /// </summary>
        /// <returns></returns>
        [Column("F_LANDNAME")]
        public string F_LandName { get; set; }
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
        public void Modify( string keyValue)
        {
            this.F_LBIId = keyValue;
        }
        #endregion
    }
}

