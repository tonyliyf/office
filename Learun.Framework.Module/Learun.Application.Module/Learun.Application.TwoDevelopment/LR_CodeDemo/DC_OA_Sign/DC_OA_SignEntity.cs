using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-01 21:42
    /// 描 述：电子签章信息管理
    /// </summary>
    public class DC_OA_SignEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_SignId
        /// </summary>
        [Column("DC_OA_SIGNID")]
        public string DC_OA_SignId { get; set; }
        /// <summary>
        /// 用章名称
        /// </summary>
        [Column("DC_OA_SIGNNAME")]
        public string DC_OA_SignName { get; set; }
        /// <summary>
        /// 用章类型（1单位公章，2私人印章）
        /// </summary>
        [Column("DC_OA_TYPE")]
        public string DC_OA_Type { get; set; }
        /// <summary>
        /// 使用密码
        /// </summary>
        [Column("DC_OA_USEPWD")]
        public string DC_OA_UsePwd { get; set; }
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
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public int? F_Description { get; set; }
        /// <summary>
        /// 电子印章图片名称
        /// </summary>
        [Column("F_SIGNIMAGFILE")]
        public string F_SignImagFile { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_SignId = Guid.NewGuid().ToString();
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
            this.DC_OA_SignId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

