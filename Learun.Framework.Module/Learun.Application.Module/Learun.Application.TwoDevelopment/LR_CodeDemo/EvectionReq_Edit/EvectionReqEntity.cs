using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 10:02
    /// 描 述：EvectionReq_Edit
    /// </summary>
    public class EvectionReqEntity
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        [Column("F_DEGREE")]
        public string F_Degree { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("F_NAME")]
        public string F_Name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Column("F_DEPT")]
        public string F_Dept { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        [Column("F_APPLYDATE")]
        public DateTime? F_ApplyDate { get; set; }
        /// <summary>
        /// 外出类型
        /// </summary>
        [Column("F_OUTTYPE")]
        public string F_OutType { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [Column("F_ENDDATE")]
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 外出天数
        /// </summary>
        [Column("F_OUTDAYS")]
        public double? F_OutDays { get; set; }
        /// <summary>
        /// 出差原因
        /// </summary>
        [Column("F_OUTREASON")]
        public string F_OutReason { get; set; }
        /// <summary>
        /// 是否需要借款
        /// </summary>
        [Column("F_ISBORROW")]
        public string F_IsBorrow { get; set; }
        /// <summary>
        /// 借款金额
        /// </summary>
        [Column("F_BORROWMONEY")]
        public double? F_BorrowMoney { get; set; }
        /// <summary>
        /// 还款日期
        /// </summary>
        [Column("F_RETURNDATE")]
        public DateTime? F_ReturnDate { get; set; }
        /// <summary>
        /// 相关客户
        /// </summary>
        [Column("F_CUSTOMER")]
        public string F_Customer { get; set; }
        /// <summary>
        /// 客户经理
        /// </summary>
        [Column("F_CUSTMANAGER")]
        public string F_CustManager { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        [Column("F_CONTRACTID")]
        public string F_ContractId { get; set; }
        /// <summary>
        /// 相关项目
        /// </summary>
        [Column("F_PROJECT")]
        public string F_Project { get; set; }
        /// <summary>
        /// 项目经理
        /// </summary>
        [Column("F_PROJMANAGER")]
        public string F_ProjManager { get; set; }
        /// <summary>
        /// 相关文档
        /// </summary>
        [Column("F_FILE")]
        public string F_File { get; set; }
        /// <summary>
        /// 相关流程
        /// </summary>
        [Column("F_PROCESS")]
        public string F_Process { get; set; }
        /// <summary>
        /// 签字意见
        /// </summary>
        [Column("F_OPINION")]
        public string F_Opinion { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// 交通工具（火车，飞机，轮船，长途汽车）取自字典
        /// </summary>
        [Column("F_TRAFFICE")]
        public string F_Traffice { get; set; }
        /// <summary>
        /// 取自字典（单程，往返）取自字典
        /// </summary>
        [Column("F_RETURN")]
        public string F_Return { get; set; }
        /// <summary>
        /// 出发地
        /// </summary>
        [Column("F_FROMPLACE")]
        public string F_FromPlace { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        [Column("F_TOPLACE")]
        public string F_ToPlace { get; set; }


        /// <summary>
        /// 目的地
        /// </summary>
        [Column("F_MIDPLACE")]
        public string F_MidPlace { get; set; }

        
        /// <summary>
        /// 实际开始时间
        /// </summary>
        [Column("F_ACTSTARTDATE")]
        public DateTime? F_ActStartDate { get; set; }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        [Column("F_ACTENDDATE")]
        public DateTime? F_ActEndDate { get; set; }
        /// <summary>
        /// 实际天数
        /// </summary>
        [Column("F_ACTDAYS")]
        public decimal? F_ActDays { get; set; }
        /// <summary>
        /// 人员岗位
        /// </summary>
        [Column("F_POSTID")]
        public string F_PostId { get; set; }



        /// <summary>
        /// 时间上午段
        /// </summary>
        [Column("F_StartDateIsAm")]
        public string F_StartDateIsAm { get; set; }


        /// <summary>
        /// 时间下午段
        /// </summary>
        [Column("F_EndDateIsAm")]
        public string F_EndDateIsAm { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_Id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

