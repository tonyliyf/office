using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-23 17:25
    /// 描 述：档案管理
    /// </summary>
    public class DC_OA_ArchivesEntity 
    {
        #region 实体成员
        /// <summary>
        /// id主键
        /// </summary>
        [Column("DC_OA_ARCHIVESID")]
        public string DC_OA_ArchivesId { get; set; }
        /// <summary>
        /// 档案类型
        /// </summary>
        [Column("DC_OA_ARCHIVETYPE")]
        public string DC_OA_ArchiveType { get; set; }
        /// <summary>
        /// 宗号
        /// </summary>
        [Column("DC_OA_NO")]
        public string DC_OA_NO { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        [Column("DC_OA_YEAR")]
        public int? DC_OA_Year { get; set; }
        /// <summary>
        /// 保管期限
        /// </summary>
        [Column("DC_OA_LIMITS")]
        public string DC_OA_Limits { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        [Column("DC_OA_NUMS")]
        public int? DC_OA_Nums { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        [Column("DC_OA_PAGES")]
        public int? DC_OA_Pages { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column("DC_OA_TITLE")]
        public string DC_OA_Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("DC_OA_CONTENT")]
        public string DC_OA_Content { get; set; }
        /// <summary>
        /// 上传附件
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
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
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public int? F_Description { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_ArchivesId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.DC_OA_ArchivesId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

