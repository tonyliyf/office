using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-25 17:27
    /// 描 述：DC_EngineProject_ConstructionRecordMonth
    /// </summary>
    public class DC_EngineProject_ConstructionRecordMonthEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EPCRMID")]
        public string F_EPCRMId { get; set; }
        /// <summary>
        /// 项目基本信息表主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 月度,1~12
        /// </summary>
        [Column("F_MONTH")]
        public string F_Month { get; set; }
        /// <summary>
        /// 完成投资额
        /// </summary>
        [Column("F_INVESTMENTCOMPLETION")]
        public double? F_InvestmentCompletion { get; set; }
        /// <summary>
        /// 投资比率
        /// </summary>
        [Column("F_INVESTMENTRATIO")]
        public double? F_InvestmentRatio { get; set; }
        /// <summary>
        /// 成本控制情况
        /// </summary>
        [Column("F_COSTCONTROLINFO")]
        public string F_CostControlInfo { get; set; }
        /// <summary>
        /// 合同外键,可取值于合同信息表，可多选，也可为空，系统控制，对用户不可见
        /// </summary>
        [Column("F_CONTRACTKEYS")]
        public string F_ContractKeys { get; set; }
        /// <summary>
        /// 合同名称，如选择了合同信息，名称自动填写
        /// </summary>
        [Column("F_CONTRACTNAME")]
        public string F_ContractName { get; set; }
        /// <summary>
        /// 合同履约评价，取值于数据字典，如良、中、差
        /// </summary>
        [Column("F_CONTRACTPERFORMANCEEVALUATION")]
        public string F_ContractPerformanceEvaluation { get; set; }
        /// <summary>
        /// 合同履约情况
        /// </summary>
        [Column("F_CONTRACTPERFORMANCEINFO")]
        public string F_ContractPerformanceInfo { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 填报部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 填报部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 填报人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 填报人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 填报时间
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
            this.F_EPCRMId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EPCRMId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

