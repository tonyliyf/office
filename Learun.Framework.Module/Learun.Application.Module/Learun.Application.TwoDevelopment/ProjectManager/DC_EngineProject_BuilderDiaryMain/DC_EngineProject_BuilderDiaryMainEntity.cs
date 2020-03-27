using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 10:59
    /// 描 述：DC_EngineProject_BuilderDiaryMain
    /// </summary>
    public class DC_EngineProject_BuilderDiaryMainEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_BDMID")]
        public string F_BDMId { get; set; }
        /// <summary>
        /// 工程项目信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 日志编号,取系统日志编号
        /// </summary>
        [Column("F_BDNUM")]
        public string F_BDNum { get; set; }
        /// <summary>
        /// 填写部门，取当前用户部门
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 填写部门主键，取当前用户部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 填写人主键，取当前用户主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 填写人，取当前用户
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 填写时间，取当前日期
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// 上午天气
        /// </summary>
        [Column("F_MORNINGWEATHER")]
        public string F_MorningWeather { get; set; }
        /// <summary>
        /// 下午天气
        /// </summary>
        [Column("F_AFTERNOONWEATHER")]
        public string F_AfternoonWeather { get; set; }
        /// <summary>
        /// 最高温度
        /// </summary>
        [Column("F_MAXTEMPERATURE")]
        public double? F_MaxTemperature { get; set; }
        /// <summary>
        /// 最低温度
        /// </summary>
        [Column("F_MINTEMPERATURE")]
        public double? F_MinTemperature { get; set; }
        /// <summary>
        /// 施工进展情况
        /// </summary>
        [Column("F_BUILDPROGRESS")]
        public string F_BuildProgress { get; set; }
        /// <summary>
        /// 施工主要工作
        /// </summary>
        [Column("F_BUILDMAINWORK")]
        public string F_BuildMainWork { get; set; }
        /// <summary>
        /// 现场图片
        /// </summary>
        [Column("F_SCENEPICTURES")]
        public string F_ScenePictures { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_BDMId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_BDMId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

