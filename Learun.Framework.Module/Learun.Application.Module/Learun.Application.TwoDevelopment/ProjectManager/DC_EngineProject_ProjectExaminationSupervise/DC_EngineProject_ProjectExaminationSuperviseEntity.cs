using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-20 18:24
    /// 描 述：DC_EngineProject_ProjectExaminationSupervise
    /// </summary>
    public class DC_EngineProject_ProjectExaminationSuperviseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PESID")]
        public string F_PESId { get; set; }
        /// <summary>
        /// 工程项目信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 检查督办类型，取值于数据字典，工程项目建设阶段-项目监管-项目检查督办
        /// </summary>
        [Column("F_INSPECTIONSUPERVISIONTYPE")]
        public string F_InspectionSupervisionType { get; set; }
        /// <summary>
        /// 记录编号,取单据编码，系统自动编号
        /// </summary>
        [Column("F_PESCODE")]
        public string F_PESCode { get; set; }
        /// <summary>
        /// 检查部位
        /// </summary>
        [Column("F_EXAMINATIONPOSITION")]
        public string F_ExaminationPosition { get; set; }
        /// <summary>
        /// 检查部门,取系统部门信息表
        /// </summary>
        [Column("F_EXAMINATIONDEPARTMENT")]
        public string F_ExaminationDepartment { get; set; }
        /// <summary>
        /// 检查人员，取检查部门内用户信息
        /// </summary>
        [Column("F_EXAMINATIONUSER")]
        public string F_ExaminationUser { get; set; }
        /// <summary>
        /// 检查时间
        /// </summary>
        [Column("F_EAMINATIONDATE")]
        public DateTime? F_EaminationDate { get; set; }
        /// <summary>
        /// 检查结果
        /// </summary>
        [Column("F_EXAMINATIONRESULT")]
        public string F_ExaminationResult { get; set; }
        /// <summary>
        /// 现场图片
        /// </summary>
        [Column("F_SCENEPICTURES")]
        public string F_ScenePictures { get; set; }
        /// <summary>
        /// 附件资料
        /// </summary>
        [Column("F_ATTACHMENT")]
        public string F_Attachment { get; set; }
        /// <summary>
        /// 督办意见
        /// </summary>
        [Column("F_SUPERVISIONOPINION")]
        public string F_SupervisionOpinion { get; set; }
        /// <summary>
        /// 是否整改，0：否；1：是；默认0
        /// </summary>
        [Column("F_IFCORRECTIVE")]
        public string F_IfCorrective { get; set; }
        /// <summary>
        /// 指派单位
        /// </summary>
        [Column("F_DESIGNATEUNIT")]
        public string F_DesignateUnit { get; set; }
        /// <summary>
        /// 指派人员
        /// </summary>
        [Column("F_DESIGNATEUSER")]
        public string F_DesignateUser { get; set; }
        /// <summary>
        /// 整改时间
        /// </summary>
        [Column("F_DESIGNATEDATE")]
        public DateTime? F_DesignateDate { get; set; }
        /// <summary>
        /// 整改结果反馈
        /// </summary>
        [Column("F_RESULTFEEDBACK")]
        public string F_ResultFeedback { get; set; }
        /// <summary>
        /// 检查督办状态，0：整改中；1：办结；默认0
        /// </summary>
        [Column("F_SUPERVISIONSTATUS")]
        public string F_SupervisionStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateDatetime = DateTime.Now;
            this.F_PESId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PESId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

