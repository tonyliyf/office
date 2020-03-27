using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-14 12:57
    /// 描 述：DC_OA_DispatchOfficialPaintTemplate
    /// </summary>
    public class DC_OA_DispatchOfficialPaintTemplateEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_TEMPLATEID")]
        public string F_TemplateId { get; set; }
        /// <summary>
        /// 头部
        /// </summary>
        [Column("F_FIRSTTEMPLATE")]
        public string F_FirstTemplate { get; set; }
        /// <summary>
        /// 中间
        /// </summary>
        [Column("F_SECOUNDTEMPLATE")]
        public string F_SecoundTemplate { get; set; }
        /// <summary>
        /// 尾部
        /// </summary>
        [Column("F_THIRDTEMPLATE")]
        public string F_ThirdTemplate { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        [Column("F_TEMLATETYPEID")]
        public string F_TemlateTypeId { get; set; }
        /// <summary>
        /// F_TemplateName
        /// </summary>
        [Column("F_TEMPLATENAME")]
        public string F_TemplateName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_TemplateId = Guid.NewGuid().ToString();
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
            this.F_TemplateId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

