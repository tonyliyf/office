using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 15:19
    /// 描 述：DC_EngineProject_ProjectInfoApprovalData
    /// </summary>
    public class DC_EngineProject_ProjectInfoApprovalDataEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PICADID")]
        public string F_PICADId { get; set; }
        /// <summary>
        /// 工程项目基本信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 项目阶段主键,取值于数据字典表工程项目阶段
        /// </summary>
        [Column("F_PROJECTSTAGE")]
        public string F_ProjectStage { get; set; }
        /// <summary>
        /// 资料编号
        /// </summary>
        [Column("F_DATACODE")]
        public string F_DataCode { get; set; }
        /// <summary>
        /// 资料名称
        /// </summary>
        [Column("F_DATANAME")]
        public string F_DataName { get; set; }
        /// <summary>
        /// 照片
        /// </summary>
        [Column("F_DATAPHOTO")]
        public string F_DataPhoto { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENT")]
        public string F_Attachment { get; set; }
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

        /// <summary>
        /// 任务负责部门
        /// </summary>
        [Column("F_TASKDEPARTMENT")]
        public string F_TaskDepartment { get; set; }


        /// <summary>
        /// 任务负责人
        /// </summary>
        [Column("F_TaskLeader")]
        public string F_TaskLeader { get; set; }

               
        /// <summary>
        /// 计划开始时间
        /// </summary>
        [Column("F_PlannedStartDate")]
        public DateTime? F_PlannedStartDate { get; set; }


        /// <summary>
        /// 计划结束时间
        /// </summary>
        [Column("F_PlannedEndDate")]
        public DateTime? F_PlannedEndDate { get; set; }


        /// <summary>
        /// 实际完成时间
        /// </summary>
        [Column("F_ActualEndDate")]
        public DateTime? F_ActualEndDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_CreateDatetime = DateTime.Now;
            this.F_PICADId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PICADId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }

    public class DC_EngineProject_ProjectInfoApprovalInfo
    {
        #region 实体成员
            

        public string F_ItemId { get; set; }

        public string F_ItemCode { get; set; }
        public string F_ProjectStage { get; set; }
     
        public string F_DataCode { get; set; }
           
        public string F_DataName { get; set; }
       
        public string F_DataPhoto { get; set; }
       
        public string F_Attachment { get; set; }
    
        public string F_ParentId { get; set; }

        public string F_ItemName { get; set; }

        #endregion


    }


}

