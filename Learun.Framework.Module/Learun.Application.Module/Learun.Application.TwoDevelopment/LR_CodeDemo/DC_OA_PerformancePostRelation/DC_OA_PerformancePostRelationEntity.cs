using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 12:24
    /// 描 述：DC_OA_PerformancePostRelation
    /// </summary>
    public class DC_OA_PerformancePostRelationEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PPRID")]
        public string F_PPRId { get; set; }
        /// <summary>
        /// 绩效考核模版主键
        /// </summary>
        /// <returns></returns>
        [Column("F_PATID")]
        public string F_PATId { get; set; }
        /// <summary>
        /// 岗位主键
        /// </summary>
        /// <returns></returns>
        [Column("F_POSTID")]
        public string F_PostId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PPRId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_PPRId = keyValue;
        }
        #endregion
    }
}

