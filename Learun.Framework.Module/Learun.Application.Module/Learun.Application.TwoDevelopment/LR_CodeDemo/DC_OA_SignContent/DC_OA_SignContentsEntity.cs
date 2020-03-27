using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-09 22:13
    /// 描 述：常用签字意见
    /// </summary>
    public class DC_OA_SignContentsEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_SignId
        /// </summary>
        [Column("DC_OA_SIGNID")]
        public string DC_OA_SignId { get; set; }
        /// <summary>
        /// 签字意见
        /// </summary>
        [Column("DC_OA_CONTENT")]
        public string DC_OA_Content { get; set; }
        /// <summary>
        /// 0,公共常用意见 ,1私人常用意见
        /// </summary>
        [Column("SIGN_TYPE")]
        public int? Sign_Type { get; set; }
        /// <summary>
        ///  是否启用 1启用,0 不启用(默认启用)
        /// </summary>
        [Column("ISENABLED")]
        public int? IsEnabled { get; set; }
        /// <summary>
        /// 分类,备用字段(按功能类型分),暂时不用
        /// </summary>
        [Column("SIGN_CLASS")]
        public string Sign_Class { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Column("F_USERID")]
        public string F_Userid { get; set; }
        /// <summary>
        /// F_CreateDate
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_SignId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
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

