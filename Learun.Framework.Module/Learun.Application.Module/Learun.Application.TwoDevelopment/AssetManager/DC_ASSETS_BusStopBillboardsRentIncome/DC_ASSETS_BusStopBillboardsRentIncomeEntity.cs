using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-23 10:20
    /// 描 述：DC_ASSETS_BusStopBillboardsRentIncome
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentIncomeEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_HRINID")]
        public string F_HRInId { get; set; }
        /// <summary>
        /// 招租信息明细表主键
        /// </summary>
        [Column("F_BSBRDID")]
        public string F_BSBRDId { get; set; }
        /// <summary>
        /// 第年度
        /// </summary>
        [Column("F_YEARNUMBER")]
        public int? F_YearNumber { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        [Column("F_YEAR")]
        public string F_Year { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        [Column("F_CONTRACTNUMBER")]
        public string F_ContractNumber { get; set; }
        /// <summary>
        /// 合同签约日期
        /// </summary>
        [Column("F_CONTRACTSIGNDATE")]
        public DateTime? F_ContractSignDate { get; set; }
        /// <summary>
        /// 实际价格
        /// </summary>
        [Column("F_ACTUALPRICE")]
        public double? F_ActualPrice { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ACCESSORIES")]
        public string F_Accessories { get; set; }
        /// <summary>
        /// 当年CPI指数
        /// </summary>
        [Column("F_CPI")]
        public double? F_CPI { get; set; }
        /// <summary>
        /// 计算公式，取数据字典表，解析公式自动计算
        /// </summary>
        [Column("F_CALCULATIONFORMULA")]
        public string F_CalculationFormula { get; set; }
        /// <summary>
        /// 缴纳银行
        /// </summary>
        [Column("F_PAYINGBANK")]
        public string F_PayingBank { get; set; }
        /// <summary>
        /// 交款账号
        /// </summary>
        [Column("F_PAYMENTACCOUNT")]
        public string F_PaymentAccount { get; set; }
        /// <summary>
        /// 交款时间
        /// </summary>
        [Column("F_PAYMENTDATE")]
        public DateTime? F_PaymentDate { get; set; }
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
            this.F_HRInId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_HRInId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

