using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-12 15:16
    /// 描 述：发文管理
    /// </summary>
    public class DC_OA_DispatchOfficialDocEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_DODID")]
        public string F_DODId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 正文,根据在线编辑插件接口存储，建议外部文件方式
        /// </summary>
        [Column("F_FILECONTENT")]
        public string F_FileContent { get; set; }
        /// <summary>
        /// 正文,清稿
        /// </summary>
        [Column("F_FileContent_New")]
        public string F_FileContent_New { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }
        /// <summary>
        /// 拟稿单位主键
        /// </summary>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// 拟稿单位
        /// </summary>
        [Column("F_DEPARTMENTNAME")]
        public string F_DepartmentName { get; set; }
        /// <summary>
        /// 拟稿人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 拟稿人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 拟稿时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 审稿时间
        /// </summary>
        [Column("F_CHECKDATE")]
        public DateTime? F_CheckDate { get; set; }
        /// <summary>
        /// 审稿期限,用于系统自动提醒，单位小时
        /// </summary>
        [Column("F_CHECKLIMIT")]
        public int? F_CheckLimit { get; set; }
        /// <summary>
        /// 复核人主键
        /// </summary>
        [Column("F_REVIEWUSERID")]
        public string F_ReviewUserId { get; set; }
        /// <summary>
        /// 复核人
        /// </summary>
        [Column("F_REVIEWUSER")]
        public string F_ReviewUser { get; set; }
        /// <summary>
        /// 复核时间
        /// </summary>
        [Column("F_REVIEWDATE")]
        public DateTime? F_ReviewDate { get; set; }
        /// <summary>
        /// 复核正文
        /// </summary>
        [Column("F_REVIEWFILECONTENT")]
        public string F_ReviewFileContent { get; set; }
        /// <summary>
        /// 校对人主键
        /// </summary>
        [Column("F_PROOFREADUSERID")]
        public string F_ProofreadUserId { get; set; }
        /// <summary>
        /// 校对人
        /// </summary>
        [Column("F_PROOFREADUSER")]
        public string F_ProofreadUser { get; set; }
        /// <summary>
        /// 校对时间
        /// </summary>
        [Column("F_PROOFREADDATE")]
        public DateTime? F_ProofreadDate { get; set; }
        /// <summary>
        /// 校对正文
        /// </summary>
        [Column("F_PROOFREADFILECONTENT")]
        public string F_ProofreadFileContent { get; set; }
        /// <summary>
        /// 签发时间
        /// </summary>
        [Column("F_SIGNDATE")]
        public DateTime? F_SignDate { get; set; }
        /// <summary>
        /// 签发期限
        /// </summary>
        [Column("F_SIGNLIMIT")]
        public int? F_SignLimit { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        [Column("F_FILECODE")]
        public string F_FileCode { get; set; }
        /// <summary>
        /// 密级
        /// </summary>
        [Column("F_DENSEGRADE")]
        public string F_DenseGrade { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        [Column("F_EMERGENCYLEVEL")]
        public string F_EmergencyLevel { get; set; }
        /// <summary>
        /// 主送
        /// </summary>
        [Column("F_SENDTO")]
        public string F_SendTo { get; set; }
        /// <summary>
        /// 抄报
        /// </summary>
        [Column("F_COPYTO")]
        public string F_CopyTo { get; set; }
        /// <summary>
        /// 是否在线发文,0：否；1：是；默认1
        /// </summary>
        [Column("F_IFONLINE")]
        public int? F_IfOnline { get; set; }
        /// <summary>
        /// 印数
        /// </summary>
        [Column("F_PRINTNUM")]
        public int? F_PrintNum { get; set; }
        /// <summary>
        /// 处理单模版
        /// </summary>
        [Column("F_DOCTEMPLATE")]
        public string F_DocTemplate { get; set; }
        /// <summary>
        /// 套红模版
        /// </summary>
        [Column("F_REDHEAD")]
        public string F_RedHead { get; set; }
        /// <summary>
        /// 印章模版
        /// </summary>
        [Column("F_STAMP")]
        public string F_Stamp { get; set; }
        /// <summary>
        /// 传阅时间
        /// </summary>
        [Column("F_CIRCULARDATE")]
        public DateTime? F_CircularDate { get; set; }
        /// <summary>
        /// 传阅期限
        /// </summary>
        [Column("F_CIRCULARLIMIT")]
        public int? F_CircularLimit { get; set; }
        /// <summary>
        /// 流程主键
        /// </summary>
        [Column("F_FLOWID")]
        public string F_FlowId { get; set; }
        /// <summary>
        /// 流程状态，可对应于流程选择使用
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
        [Column("F_COMPLETIONUSERID")]
        public string F_CompletionUserId { get; set; }
        /// <summary>
        /// 办结时间
        /// </summary>
        [Column("F_COMPLETIONDATE")]
        public DateTime? F_CompletionDate { get; set; }
        [Column("F_SendToID")]
        public string F_SendToID { get; set; }
        [Column("F_CopyToID")]
        public string F_CopyToID { get; set; }
        [Column("F_DraftDepartmentId")]

        public string F_DraftDepartmentId { get; set; }
        [Column("F_DraftUserId")]
        public string F_DraftUserId { get; set; }
        [Column("F_DraftDate")]
        public DateTime? F_DraftDate { get; set; }
        [Column("F_FileContent_ENew")]
        public string F_FileContent_ENew { get; set; }
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
            this.F_DepartmentId = userInfo.departmentId;
            this.F_FileContent_ENew = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_DODId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

