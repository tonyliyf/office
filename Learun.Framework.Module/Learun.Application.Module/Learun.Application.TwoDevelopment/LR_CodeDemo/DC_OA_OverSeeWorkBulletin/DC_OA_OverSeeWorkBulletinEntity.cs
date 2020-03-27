using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-01 15:48
    /// 描 述：DC_OA_OverSeeWorkBulletin
    /// </summary>
    public class DC_OA_OverSeeWorkBulletinEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_DOBID")]
        public string F_DOBId { get; set; }
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
        /// 附件，此处附件指交办清单以外附件，交办单明细作为表单内容提交
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
        /// 是否归档,0：未归档；1：已归档；默认0
        /// </summary>
        [Column("F_IFCOMPLETION")]
        public int? F_IfCompletion { get; set; }
        /// <summary>
        /// 归档人
        /// </summary>
        [Column("F_COMPLETIONUSERID")]
        public string F_CompletionUserId { get; set; }
        /// <summary>
        /// 归档时间
        /// </summary>
        [Column("F_COMPLETIONDATE")]
        public DateTime? F_CompletionDate { get; set; }
        /// <summary>
        /// 办结状态,1:流程中；2：办结（结束）；-1：驳回；默认1
        /// </summary>
        [Column("IS_AGREE")]
        public string is_agree { get; set; }
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
            this.F_CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_DOBId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

