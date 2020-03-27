using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-15 15:20
    /// 描 述：DC_EngineProject_ProjectInfoContract
    /// </summary>
    public class DC_EngineProject_ProjectInfoContractEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PICID")]
        public string F_PICId { get; set; }
      
        /// <summary>
        /// 工程项目基本信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        ///// <summary>
        ///// 项目阶段主键,取值于数据字典表工程项目阶段
        ///// </summary>
        //[Column("F_PROJECTSTAGE")]
        //public string F_ProjectStage { get; set; }
        /// <summary>
        /// 合同分类,取值于数据字典，工程项目合同分类，如建设工程施工合同、劳务分包合同、专业分包合同、物资设备采购供应合同、房地产开发合作合同、代建合同、租赁合同、融资合同、担保合同等
        /// </summary>
        [Column("F_CONTRACTTYPE")]
        public string F_ContractType { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        [Column("F_CONTRACTCODE")]
        public string F_ContractCode { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>
        [Column("F_CONTRACTNAME")]
        public string F_ContractName { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary>
        [Column("F_CONTRACTMONEY")]
        public double? F_ContractMoney { get; set; }
        /// <summary>
        /// 结算方式,取值于数据字典，结算方式（财务管理）
        /// </summary>
        [Column("F_SETTLEMENTMETHOD")]
        public string F_SettlementMethod { get; set; }
        /// <summary>
        /// 付款方式,取值于数据字典，付款方式（财务管理）
        /// </summary>
        [Column("F_PAYMETHOD")]
        public string F_PayMethod { get; set; }
        /// <summary>
        /// 合同附件
        /// </summary>
        [Column("F_CONTRACTAPPENDICES")]
        public string F_ContractAppendices { get; set; }
        /// <summary>
        /// 甲方单位
        /// </summary>
        [Column("F_PARTYAUNIT")]
        public string F_PartyAUnit { get; set; }
        /// <summary>
        /// 甲方责任人
        /// </summary>
        [Column("F_PARTYABLAMEMAN")]
        public string F_PartyABlameMan { get; set; }
        /// <summary>
        /// 乙方单位
        /// </summary>
        [Column("F_PARTYBUNIT")]
        public string F_PartyBUnit { get; set; }
        /// <summary>
        /// 乙方责任人
        /// </summary>
        [Column("F_PARTYBBLAMEMAN")]
        public string F_PartyBBlameMan { get; set; }
        /// <summary>
        /// 签订时间
        /// </summary>
        [Column("F_SIGNINGTIME")]
        public DateTime? F_SigningTime { get; set; }
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


        [Column("ID")]
        public int?  id { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PICId = Guid.NewGuid().ToString();
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserid = userInfo.userId;
            this.F_CreateDepartmentId = userInfo.departmentId;
            this.F_CreateDatetime = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PICId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }

   
}

