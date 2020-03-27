using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.AssetManager

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 10:05
    /// 描 述：DC_ASSETS_BuildingBaseInfo
    /// </summary>
    public class DC_ASSETS_BuildingBaseInfofoodEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_BBIID")]
        public string F_BBIId { get; set; }
        /// <summary>
        /// 行政区划,取行政区划表
        /// </summary>
        /// <returns></returns>
        [Column("F_COMMUNITYCODE")]
        public string F_CommunityCode { get; set; }
        /// <summary>
        /// 地址编码
        /// </summary>
        /// <returns></returns>
        [Column("F_ADDRESSCODE")]
        public string F_AddressCode { get; set; }
        /// <summary>
        /// 地址名称
        /// </summary>
        /// <returns></returns>
        [Column("F_ADDRESS")]
        public string F_Address { get; set; }
        /// <summary>
        /// 建筑编码
        /// </summary>
        /// <returns></returns>
        [Column("F_CONSTRUCTIONCODE")]
        public string F_ConstructionCode { get; set; }
        /// <summary>
        /// 建筑名称
        /// </summary>
        /// <returns></returns>
        [Column("F_CONSTRUCTIONNAME")]
        public string F_ConstructionName { get; set; }
        /// <summary>
        /// 建筑高度
        /// </summary>
        /// <returns></returns>
        [Column("F_CONSTRUCTIONHEIGHT")]
        public decimal? F_ConstructionHeight { get; set; }
        /// <summary>
        /// 建筑层数
        /// </summary>
        /// <returns></returns>
        [Column("F_CONSTRUCTIONFLOORCOUNT")]
        public int? F_ConstructionFloorCount { get; set; }
        /// <summary>
        /// 单元数
        /// </summary>
        /// <returns></returns>
        [Column("F_UNITCOUNT")]
        public int? F_UnitCount { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        /// <returns></returns>
        [Column("F_CONSTRUCTIONAREA")]
        public double? F_ConstructionArea { get; set; }
        /// <summary>
        /// 使用面积
        /// </summary>
        /// <returns></returns>
        [Column("F_USAGEAREA")]
        public double? F_UsageArea { get; set; }
        /// <summary>
        /// 占地面积
        /// </summary>
        /// <returns></returns>
        [Column("F_COVERAREA")]
        public double? F_CoverArea { get; set; }
        /// <summary>
        /// 建筑用途分类，取值于数据字典，如厂房、写字楼、商业大楼、普通住宅、公寓、别墅等
        /// </summary>
        /// <returns></returns>
        [Column("F_USECATEGORIES")]
        public string F_UseCategories { get; set; }
        /// <summary>
        /// 建筑结构分类，取值于数据字典，如砖木结构、砖混结构、钢筋混凝土结构、钢结构、其他结构等
        /// </summary>
        /// <returns></returns>
        [Column("F_STRUCTURECLASSIFICATION")]
        public string F_StructureClassification { get; set; }
        /// <summary>
        /// 使用年限
        /// </summary>
        /// <returns></returns>
        [Column("F_AVAILABLEYEARS")]
        public int? F_AvailableYears { get; set; }
        /// <summary>
        /// 使用现状
        /// </summary>
        /// <returns></returns>
        [Column("F_USESITUATION")]
        public string F_UseSituation { get; set; }
        /// <summary>
        /// 竣工时间
        /// </summary>
        /// <returns></returns>
        [Column("F_COMPLETIONTIME")]
        public DateTime? F_CompletionTime { get; set; }
        /// <summary>
        /// 消防等级，取值于数据字典，如一级、二级、三级、四级
        /// </summary>
        /// <returns></returns>
        [Column("F_FIRERATING")]
        public string F_FireRating { get; set; }
        /// <summary>
        /// 建筑备案号
        /// </summary>
        /// <returns></returns>
        [Column("F_BUILDINGRECORDNUMBER")]
        public string F_BuildingRecordNumber { get; set; }
        /// <summary>
        /// 图片附件
        /// </summary>
        /// <returns></returns>
        [Column("F_PICTUREACCESSORIES")]
        public string F_PictureAccessories { get; set; }
        /// <summary>
        /// 其他附件
        /// </summary>
        /// <returns></returns>
        [Column("F_OTHERACCESSORIES")]
        public string F_OtherAccessories { get; set; }
        /// <summary>
        /// 原管理单位
        /// </summary>
        /// <returns></returns>
        [Column("F_FORMERUNIT")]
        public string F_FormerUnit { get; set; }
        /// <summary>
        /// 原管联系人
        /// </summary>
        /// <returns></returns>
        [Column("F_FORMERUNITCONTACTS")]
        public string F_FormerUnitContacts { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        /// <returns></returns>
        [Column("F_CONTACTSPHONE")]
        public string F_ContactsPhone { get; set; }
        /// <summary>
        /// 有效状态, 0:有效；1：无效；默认0
        /// </summary>
        /// <returns></returns>
        [Column("F_IFUSE")]
        public int? F_IfUse { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 建筑中心坐标
        /// </summary>
        /// <returns></returns>
        [Column("F_CENTERPOINTCOORDINATES")]
        public string F_CenterpointCoordinates { get; set; }
        /// <summary>
        /// 建筑边界坐标
        /// </summary>
        /// <returns></returns>
        [Column("F_BOUNDARYCOORDINATES")]
        public string F_BoundaryCoordinates { get; set; }
        /// <summary>
        /// 录入部门主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 录入部门
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 录入人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// 资产性质
        /// </summary>
        /// <returns></returns>
        [Column("F_BUILDINGCLASS")]
        public string F_BuildingClass { get; set; }
        /// <summary>
        /// 入账价值（万元）
        /// </summary>
        /// <returns></returns>
        [Column("F_BUILDINGVALUE")]
        public double? F_BuildingValue { get; set; }
        /// <summary>
        /// 土地信息主键
        /// </summary>
        /// <returns></returns>
        [Column("F_LBIID")]
        public string F_LBIId { get; set; }
        /// <summary>
        /// 原单位
        /// </summary>
        /// <returns></returns>
        [Column("F_OLDUNIT")]
        public string F_OldUnit { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_BBIId = Guid.NewGuid().ToString();
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
            this.F_BBIId = keyValue;
        }
        #endregion
    }
}

