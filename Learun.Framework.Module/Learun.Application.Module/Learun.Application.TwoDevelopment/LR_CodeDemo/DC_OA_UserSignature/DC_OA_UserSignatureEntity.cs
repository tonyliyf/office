using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-18 11:17
    /// 描 述：DC_OA_UserSignature
    /// </summary>
    public class DC_OA_UserSignatureEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_UserId
        /// </summary>
        /// <returns></returns>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// F_Signature
        /// </summary>
        /// <returns></returns>
        [Column("F_SIGNATURE")]
        public string F_Signature { get; set; }
        /// <summary>
        /// F_Password
        /// </summary>
        /// <returns></returns>
        [Column("F_PASSWORD")]
        public string F_Password { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_UserId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_UserId = keyValue;
        }
        #endregion
    }
}

