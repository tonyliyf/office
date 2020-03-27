using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.EcologyDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-02 10:05
    /// 描 述：督办任务评论
    /// </summary>
    public class uf_dbrwplbEntity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// requestId
        /// </summary>
        /// <returns></returns>
        [Column("REQUESTID")]
        public int? requestId { get; set; }
        /// <summary>
        /// maxzrwid
        /// </summary>
        /// <returns></returns>
        [Column("MAXZRWID")]
        public string maxzrwid { get; set; }
        /// <summary>
        /// minzrwid
        /// </summary>
        /// <returns></returns>
        [Column("MINZRWID")]
        public string minzrwid { get; set; }
        /// <summary>
        /// plbm
        /// </summary>
        /// <returns></returns>
        [Column("PLBM")]
        public int? plbm { get; set; }
        /// <summary>
        /// plr
        /// </summary>
        /// <returns></returns>
        [Column("PLR")]
        public int? plr { get; set; }
        /// <summary>
        /// plsj
        /// </summary>
        /// <returns></returns>
        [Column("PLSJ")]
        public DateTime plsj { get; set; }
        /// <summary>
        /// pllr
        /// </summary>
        /// <returns></returns>
        [Column("PLLR")]
        public string pllr { get; set; }
        /// <summary>
        /// bz
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string bz { get; set; }
        /// <summary>
        /// maxzrwmc
        /// </summary>
        /// <returns></returns>
        [Column("MAXZRWMC")]
        public string maxzrwmc { get; set; }
        /// <summary>
        /// minzrwmc
        /// </summary>
        /// <returns></returns>
        [Column("MINZRWMC")]
        public string minzrwmc { get; set; }
        /// <summary>
        /// plzt
        /// </summary>
        /// <returns></returns>
        [Column("PLZT")]
        public int? plzt { get; set; }


        [Column("Replyid")]
        public int? replyid { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.plsj = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(int? keyValue)
        {
            this.id = keyValue;
        }
        #endregion
    }
}

