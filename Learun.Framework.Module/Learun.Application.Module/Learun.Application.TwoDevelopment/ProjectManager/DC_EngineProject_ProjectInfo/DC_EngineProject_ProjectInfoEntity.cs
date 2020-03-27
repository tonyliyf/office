using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 13:57
    /// 描 述：DC_EngineProject_ProjectInfo
    /// </summary>
    public class DC_EngineProject_ProjectInfoEntity 
    {

        //t1.[F_ProjectYear]
        //          ,t1.[F_JRYCompany]
        //          ,t1.[F_ProjectState]
        //          ,t1.[F_ProjectBuildType]
        //          ,t1.[F_EngineeringCost]
        //          ,t2.F_AreaName as F_CommunityCode
        //          ,t1.[F_ProjectAddress]
        //          ,t1.[F_PlannedStartDate]
        //          ,t1.[F_PlannedEndDate]
        //          ,t1.[F_ProjectProgress]



        #region 实体成员
        /// <summary>
        /// 立项年度
        /// </summary>
        [Column("F_PROJECTYEAR")]
        public string F_ProjectYear { get; set; }
        /// <summary>
        /// 项目所属公司,取值公司信息表
        /// </summary>
        [Column("F_JRYCOMPANY")]
        public string F_JRYCompany { get; set; }
        /// <summary>
        /// 项目状态，0：执行中；1：延期；2:暂停；3：终止；4：已验收；5：已结案
        /// </summary>
        [Column("F_PROJECTSTATE")]
        public string F_ProjectState { get; set; }
        /// <summary> 
        /// 项目建设类型，取值数据字典，工程项目建设类型
        /// </summary>
        [Column("F_PROJECTBUILDTYPE")]
        public string F_ProjectBuildType { get; set; }
        /// <summary>
        /// 工程造价，单位：万元
        /// </summary>
        [Column("F_ENGINEERINGCOST")]
        public double? F_EngineeringCost { get; set; }
        /// <summary>
        /// 行政区划,取行政区划表
        /// </summary>
        [Column("F_COMMUNITYCODE")]
        public string F_CommunityCode { get; set; }
        /// <summary>
        /// 项目地址
        /// </summary>
        [Column("F_PROJECTADDRESS")]
        public string F_ProjectAddress { get; set; }
        /// <summary>
        /// 计划开工日期
        /// </summary>
        [Column("F_PLANNEDSTARTDATE")]
        public DateTime? F_PlannedStartDate { get; set; }
        /// <summary>
        /// 计划完成日期
        /// </summary>
        [Column("F_PLANNEDENDDATE")]
        public DateTime? F_PlannedEndDate { get; set; }
        /// <summary>
        /// 工程进度
        /// </summary>
        [Column("F_PROJECTPROGRESS")]
        public int? F_ProjectProgress { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("F_PROJECTITEMNUMBER")]
        public string F_ProjectItemNumber { get; set; }
 
        /// <summary>
        /// 项目规模分类，取值数据字典工程项目规模分类
        /// </summary>
        [Column("F_PROJECTSIZECLASSIFY")]
        public string F_ProjectSizeClassify { get; set; }
        /// <summary>
        /// 项目类型,取值于数据字典工程项目类型
        /// </summary>
        [Column("F_PROJECTTYPE")]
        public string F_ProjectType { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Column("F_PROJECTNAME")]
        public string F_ProjectName { get; set; }
        /// <summary>
        /// 父级节点
        /// </summary>
        [Column("F_PARENTID")]
        public string F_ParentId { get; set; }
        /// <summary>
        /// 立项日期
        /// </summary>
        [Column("F_PROJECTAPPROVALDATE")]
        public DateTime? F_ProjectApprovalDate { get; set; }
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
        /// 工程量估算，单位：天
        /// </summary>
        [Column("F_PROJECTQUANTITYESTIMATION")]
        public int? F_ProjectQuantityEstimation { get; set; }
        /// <summary>
        /// 预期利润，单位：万元
        /// </summary>
        [Column("F_EXPECTEDPROFIT")]
        public decimal? F_ExpectedProfit { get; set; }
        /// <summary>
        /// 工程工期,从计划开工完成计算后转换，如4年，用户可编辑
        /// </summary>
        [Column("F_PROJECTYEARS")]
        public string F_ProjectYears { get; set; }
        /// <summary>
        /// 实际开工日期
        /// </summary>
        [Column("F_ACTUALSTARTDATE")]
        public DateTime? F_ActualStartDate { get; set; }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        [Column("F_ACTUALENDDATE")]
        public DateTime? F_ActualEndDate { get; set; }
        /// <summary>
        /// 工程进度说明
        /// </summary>
        [Column("F_PROJECTPROGRESSSTATEMENT")]
        public string F_ProjectProgressStatement { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }

        /// <summary>
        /// 分管领导
        /// </summary>
        [Column("F_CHARGELEADER")]
        public string F_ChargeLeader { get; set; }
        /// <summary>
        /// 立项部门
        /// </summary>
        [Column("F_SETUPDEPARTMENT")]
        public string F_SetupDepartment { get; set; }
        /// <summary>
        /// 立项人
        /// </summary>
        [Column("F_SETUPUSER")]
        public string F_SetupUser { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
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
        /// 进度百分比
        /// </summary>
        [NotMapped]
        public float? Percent { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PIId = Guid.NewGuid().ToString();
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
            this.F_PIId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

