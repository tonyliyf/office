using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-25 14:17
    /// 描 述：DC_OA_PRREvaluationUserRelation
    /// </summary>
    public class DC_OA_PRRSelfUserRelationEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PRRSURID")]
        public string F_PRRSURId { get; set; }
        /// <summary>
        /// 运行记录表主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PRRID")]
        public string F_PRRId { get; set; }
        /// <summary>
        /// 被考核人主键
        /// </summary>
        /// <returns></returns>
        [Column("F_SELFUSERID")]
        public string F_SelfUserId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PRRSURId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PRRSURId = keyValue;
        }
        #endregion
    }
}

