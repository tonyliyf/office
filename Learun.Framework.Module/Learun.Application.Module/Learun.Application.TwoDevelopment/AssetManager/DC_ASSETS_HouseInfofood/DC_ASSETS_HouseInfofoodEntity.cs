using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.AssetManager

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 10:22
    /// 描 述：DC_ASSETS_HouseInfofood
    /// </summary>
    public class DC_ASSETS_HouseInfofoodEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_HOUSEID")]
        public string F_HouseID { get; set; }
        /// <summary>
        /// 建筑基本信息表主键
        /// </summary>
        [Column("F_BBIID")]
        public string F_BBIId { get; set; }
        /// <summary>
        /// 单元编码，楼栋编号+单元编号
        /// </summary>
        [Column("F_UNITCODE")]
        public string F_UnitCode { get; set; }
        /// <summary>
        /// 资产编号，取系统资产编号编码
        /// </summary>
        [Column("F_ASSETSNUMBER")]
        public string F_AssetsNumber { get; set; }
        /// <summary>
        /// 单元编码，楼栋编号+单元编号+楼层编号+房屋编号
        /// </summary>
        [Column("F_HOUSECODE")]
        public string F_HouseCode { get; set; }
        /// <summary>
        /// 房屋名称
        /// </summary>
        [Column("F_HOUSENAME")]
        public string F_HouseName { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        [Column("F_UNITNUMBER")]
        public string F_UnitNumber { get; set; }
        /// <summary>
        /// 楼层号
        /// </summary>
        [Column("F_FLOORNUMBER")]
        public string F_FloorNumber { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        [Column("F_ROOMNUMBER")]
        public string F_RoomNumber { get; set; }
        /// <summary>
        /// 房间用途分类，取值于数据字典，如成套住宅、非成套住宅、集体宿舍、商业服务、办公、经营、公共设施等
        /// </summary>
        [Column("F_USECATEGORIES")]
        public string F_UseCategories { get; set; }
        /// <summary>
        /// 房屋使用性质，取值于数据字典，如自住房、出租房、商用房屋等
        /// </summary>
        [Column("F_ROOMUSAGE")]
        public string F_RoomUsage { get; set; }
        /// <summary>
        /// 房产地址
        /// </summary>
        [Column("F_BUILDINGADDRESS")]
        public string F_BuildingAddress { get; set; }
        /// <summary>
        /// 房产证发证机关
        /// </summary>
        [Column("F_PROOFUNIT")]
        public string F_ProofUnit { get; set; }
        /// <summary>
        /// 房产证号
        /// </summary>
        [Column("F_CERTIFICATENO")]
        public string F_CertificateNo { get; set; }
        /// <summary>
        /// 房产证发放日期
        /// </summary>
        [Column("F_PROOFDATE")]
        public DateTime? F_ProofDate { get; set; }
        /// <summary>
        /// 产权人姓名
        /// </summary>
        [Column("F_PROPERTYOWNER")]
        public string F_PropertyOwner { get; set; }
        /// <summary>
        /// 产权人联系电话
        /// </summary>
        [Column("F_PROPERTYOWNERPHONE")]
        public string F_PropertyOwnerPhone { get; set; }
        /// <summary>
        /// 产权人证件类型，取值于数据字典，如身份证、居住证、签证、护照、户口本、军人证、团员证、党员证、港澳通行证等
        /// </summary>
        [Column("F_PROPERTYOWNERCERTIFICATETYPE")]
        public string F_PropertyOwnerCertificateType { get; set; }
        /// <summary>
        /// 产权人证件号
        /// </summary>
        [Column("F_PROPERTYOWNERCERFIFICATENO")]
        public string F_PropertyOwnerCerfificateNo { get; set; }


        /// <summary>
        /// 土地证号
        /// </summary>
        [Column("F_LANDCERTIFICATENO")]
        public string F_LandCertificateNo { get; set; }
        /// <summary>
        /// 购置日期
        /// </summary>
        [Column("F_PURCHASEDATE")]
        public DateTime? F_PurchaseDate { get; set; }
        /// <summary>
        /// 使用状态
        /// </summary>
        [Column("F_USESTATUS")]
        public string F_UseStatus { get; set; }
        /// <summary>
        /// 房屋面积
        /// </summary>
        [Column("F_HOUSEAREA")]
        public double? F_HouseArea { get; set; }
        /// <summary>
        /// 房屋出租用途，取值于数据字典，如门店、个人居住、单位办公、商用、生产、商住两用、其他
        /// </summary>
        [Column("F_RENTPURPOSE")]
        public string F_RentPurpose { get; set; }
        /// <summary>
        /// 招租年限
        /// </summary>
        [Column("F_RENTAGE")]
        public int? F_RentAge { get; set; }
        /// <summary>
        /// 图片附件
        /// </summary>
        [Column("F_PICTUREACCESSORIES")]
        public string F_PictureAccessories { get; set; }
        /// <summary>
        /// 有效状态, 0:有效；1：无效；默认0
        /// </summary>
        [Column("F_IFUSE")]
        public string F_IfUse { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 房屋租赁备案证
        /// </summary>
        [Column("F_FWZLBAZ")]
        public string F_Fwzlbaz { get; set; }
        /// <summary>
        /// 危房等级，取值于数据字典，如A级、B级、C级
        /// </summary>
        [Column("F_RENTCERTIFICATENO")]
        public string F_RentCertificateNo { get; set; }
        /// <summary>
        /// 土地面积
        /// </summary>
        [Column("F_LANDAREA")]
        public string F_LandArea { get; set; }
        /// <summary>
        /// 录入部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 录入部门
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 录入人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }

        /// <summary>
        ///账面价值（万元）
        /// </summary>
        [Column("F_BUILDINGVALUE")]
        public double? F_BuildingValue { get; set; }


        /// <summary>
        //房屋附件
        /// </summary>
        [NotMapped]
        public string F_PictureAccessories_HouseInfo { get; set; }


        /// <summary>
        /// 房屋用途
        /// </summary>
        [NotMapped]
        public string F_UseCategories_build { get; set; }

        /// <summary>
        /// 使用性质
        /// </summary>
        [NotMapped]
        public string F_RoomUsage_build { get; set; }
        /// <summary>
        /// 所用权人
        /// </summary>
        [NotMapped]
        public string F_PropertyOwner_build { get; set; }
        /// <summary>
        /// 产权人证件类型
        /// </summary>
        [NotMapped]
        public string F_PropertyOwnerCertificateType_build { get; set; }
        /// <summary>
        /// 使用状态
        /// </summary>
        [NotMapped]
        public string F_UseStatus_build { get; set; }
        /// <summary>
        /// 出租用途
        /// </summary>
        [NotMapped]
        public string F_RentPurpose_build { get; set; }
        /// <summary>
        /// 有效状态
        /// </summary>
        [NotMapped]
        public string F_IfUse_build { get; set; }
        /// <summary>
        /// 图片附件
        /// </summary>
        [NotMapped]
        public string F_PictureAccessories_build { get; set; }
        /// <summary>
        /// 危房等级
        /// </summary>
        [NotMapped]
        public string F_RentCertificateNo_build { get; set; }


        ////新增部分

        /// <summary>
        /// 原单位
        /// </summary>
        [NotMapped]
        public string F_Transferor { get; set; }

        /// <summary>
        /// 土地名称
        /// </summary>
        [NotMapped]
        public string F_LandName { get; set; }

        /// <summary>
        /// 宗地地址
        /// </summary>
        [NotMapped]
        public string F_ParcelAddress { get; set; }

        /// <summary>
        /// 所有权人
        /// </summary>
        [NotMapped]
        public string F_Assignee { get; set; }


        /// <summary>
        /// 土地证号
        /// </summary>
        [NotMapped]
        public string F_LandCertificate { get; set; }


        /// <summary>
        /// 土地证号
        /// </summary>
        [NotMapped]
        public string F_BuildingClass { get; set; }



        /// <summary>
        /// 使用面积
        /// </summary>
        [NotMapped]
        public double? F_Area { get; set; }


        /// <summary>
        /// 土地使用权类型，取数据字典
        /// </summary>
        [NotMapped]
        public string F_LandUseRight { get; set; }


        /// <summary>
        /// 土地用途，取数据字典
        /// </summary>
        [NotMapped]
        public string F_LandUseNature { get; set; }

        /// <summary>
        ///账面价值(元)
        /// </summary>
        [NotMapped]
        public double? F_TransferAmount { get; set; }

        /// <summary>
        ///建筑面积
        /// </summary>
        [NotMapped]
        public double? F_ConstructionArea { get; set; }

        /// <summary>
        /// 总楼层
        /// </summary>
        [NotMapped]
        public string F_ConstructionFloorCount { get; set; }

        /// <summary>
        /// 原管联系人
        /// </summary>
        [NotMapped]
        public string F_FormerUnitContacts { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [NotMapped]
        public string F_ContactsPhone { get; set; }

        [NotMapped]
        public string F_CommunityCode { get; set; }

        [NotMapped]
        public string F_CenterpointCoordinates { get; set; }

        [NotMapped]
        public string F_ContractNumber { get; set; }

        [NotMapped]
        public string F_ContractAccessories { get; set; }

        [NotMapped]
        public string F_SalesConfirmation { get; set; }
        [NotMapped]
        public string F_NoteDescription { get; set; }

        [NotMapped]
        public string F_NoteAccessories { get; set; }

        [NotMapped]
        public string F_OtherAccessories { get; set; }

        [NotMapped]
        public string F_Oldunit { get; set; }

        [NotMapped]
        public string F_ConstructionName { get; set; }

        [NotMapped]
        public string F_Address { get; set; }
        [NotMapped]
        public string F_FormerUnit { get; set; }



        [NotMapped]
        public double? F_UsageArea { get; set; }

        [NotMapped]
        public string F_LBIId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_HouseID = Guid.NewGuid().ToString();
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
            this.F_HouseID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

