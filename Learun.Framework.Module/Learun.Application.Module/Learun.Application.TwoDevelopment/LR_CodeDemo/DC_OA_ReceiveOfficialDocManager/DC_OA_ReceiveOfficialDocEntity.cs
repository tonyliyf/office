using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-14 12:10
    /// 描 述：收文管理
    /// </summary>
    public class DC_OA_ReceiveOfficialDocEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_RODID")]
        public string F_RODId { get; set; }
        /// <summary>
        /// 文件标题
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 文件字号
        /// </summary>
        [Column("F_FILECODE")]
        public string F_FileCode { get; set; }
        /// <summary>
        /// 来文部室
        /// </summary>
        [Column("F_SENDERDEPARTMENT")]
        public string F_SenderDepartment { get; set; }
        /// <summary>
        /// 密级
        /// </summary>
        [Column("F_DENSEGRADE")]
        public string F_DenseGrade { get; set; }
        /// <summary>
        /// 收文号
        /// </summary>
        [Column("F_RECEIVECODE")]
        public string F_ReceiveCode { get; set; }
        /// <summary>
        /// 份数
        /// </summary>
        [Column("F_PRINTNUM")]
        public int? F_PrintNum { get; set; }
        /// <summary>
        /// 收文时间
        /// </summary>
        [Column("F_RECEIVEDATE")]
        public DateTime? F_ReceiveDate { get; set; }
        /// <summary>
        /// 处理单模版
        /// </summary>
        [Column("F_DOCTEMPLATE")]
        public string F_DocTemplate { get; set; }
        /// <summary>
        /// 收文附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 登记单位主键
        /// </summary>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 登记单位
        /// </summary>
        [Column("F_DEPARTMENTNAME")]
        public string F_DepartmentName { get; set; }
        /// <summary>
        /// 登记人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 登记人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 拟办意见
        /// </summary>
        [Column("F_ASKFORCONTENT")]
        public string F_AskforContent { get; set; }
        /// <summary>
        /// 批示期限,用于系统自动提醒，单位小时
        /// </summary>
        [Column("F_INSTRUCTIONLIMIT")]
        public int? F_InstructionLimit { get; set; }
        /// <summary>
        /// 拟办人主键
        /// </summary>
        [Column("F_ASKFORUSERID")]
        public string F_AskforUserId { get; set; }
        /// <summary>
        /// 拟办人
        /// </summary>
        [Column("F_ASKFORUSER")]
        public string F_AskforUser { get; set; }
        /// <summary>
        /// 拟办时间
        /// </summary>
        [Column("F_ASKFORDATE")]
        public DateTime? F_AskforDate { get; set; }
        /// <summary>
        /// 分发人
        /// </summary>
        [Column("F_DISTRIBUTIONUSER")]
        public string F_DistributionUser { get; set; }
        /// <summary>
        /// 分发时间
        /// </summary>
        [Column("F_DISTRIBUTIONDATE")]
        public DateTime? F_DistributionDate { get; set; }
        /// <summary>
        /// 承办时间
        /// </summary>
        [Column("F_HANDLEDATE")]
        public DateTime? F_HandleDate { get; set; }
        /// <summary>
        /// 承办期限,用于系统自动提醒，单位小时
        /// </summary>
        [Column("F_HANDLELIMIT")]
        public int? F_HandleLimit { get; set; }
        /// <summary>
        /// 传阅时间
        /// </summary>
        [Column("F_CIRCULARDATE")]
        public DateTime? F_CircularDate { get; set; }
        /// <summary>
        /// 传阅期限,用于系统自动提醒，单位小时
        /// </summary>
        [Column("F_CIRCULARLIMIT")]
        public int? F_CircularLimit { get; set; }
        /// <summary>
        /// 处理意见
        /// </summary>
        [Column("F_DEALCONTENT")]
        public string F_DealContent { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        [Column("F_DEALUSERID")]
        public string F_DealUserId { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        [Column("F_DEALDATE")]
        public DateTime? F_DealDate { get; set; }
        /// <summary>
        /// 流程主键
        /// </summary>
        [Column("F_FLOWID")]
        public string F_FlowId { get; set; }
        /// <summary>
        /// 流程状态，对应流程可选择使用
        /// </summary>
        [Column("F_FLOWSTATE")]
        public int? F_FlowState { get; set; }
        /// <summary>
        /// 是否办结,0：未办结；1：办结；默认0
        /// </summary>
        [Column("F_IFCOMPLETION")]
        public int? F_IfCompletion { get; set; }
        /// <summary>
        /// 办结人
        /// </summary>
        [Column("F_COMPETIONUSERID")]
        public string F_CompetionUserId { get; set; }
        /// <summary>
        /// 办结时间
        /// </summary>
        [Column("F_COMPETIONDATE")]
        public DateTime? F_CompetionDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_RODId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

