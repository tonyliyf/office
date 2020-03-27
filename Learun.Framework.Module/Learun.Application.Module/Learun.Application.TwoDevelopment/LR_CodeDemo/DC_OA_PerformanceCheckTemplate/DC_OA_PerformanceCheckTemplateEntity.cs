using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-29 13:48
    /// 描 述：DC_OA_PerformanceCheckTemplate
    /// </summary>
    public class DC_OA_PerformanceCheckTemplateEntity 
    {
        #region 实体成员
        /// <summary>
        /// 绩效考核模板主键
        /// </summary>
        [Column("F_TEMPLATEID")]
        public string F_TemplateId { get; set; }
        /// <summary>
        /// 考核模板名称
        /// </summary>
        [Column("F_TEMPLATENAME")]
        public string F_TemplateName { get; set; }
        /// <summary>
        /// 考核模板类型（年度，季度，月度）取自数据字典
        /// </summary>
        [Column("F_TIMETYPE")]
        public string F_TimeType { get; set; }
        /// <summary>
        /// 被考核人，关联角色，由角色判断用户需要用哪个模板
        /// </summary>
        [Column("F_ROLEID")]
        public string F_Roleid { get; set; }
        /// <summary>
        /// 是否启用，默认  1启用，0禁止，默认启用
        /// </summary>
        [Column("F_ENABLED")]
        public string F_Enabled { get; set; }
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
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 创建部门
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// 模板内容（可存放html)
        /// </summary>
        [Column("F_CONTENT")]
        public string F_Content { get; set; }
        /// <summary>
        /// 模板文件路径
        /// </summary>
        [Column("F_PATH")]
        public string F_Path { get; set; }
        [Column("F_ROLENAMES")]
        public string F_RoleNames { get; set; }

        [Column("F_LEVEL")]
        public int F_level { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_TemplateId = Guid.NewGuid().ToString();
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

