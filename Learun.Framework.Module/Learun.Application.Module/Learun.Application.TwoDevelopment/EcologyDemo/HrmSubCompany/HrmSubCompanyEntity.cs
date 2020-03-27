using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.EcologyDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:15
    /// 描 述：HrmSubCompany
    /// </summary>
    public class HrmSubCompanyEntity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// subcompanyname
        /// </summary>
        /// <returns></returns>
        [Column("SUBCOMPANYNAME")]
        public string subcompanyname { get; set; }
        /// <summary>
        /// subcompanydesc
        /// </summary>
        /// <returns></returns>
        [Column("SUBCOMPANYDESC")]
        public string subcompanydesc { get; set; }
        /// <summary>
        /// companyid
        /// </summary>
        /// <returns></returns>
        [Column("COMPANYID")]
        public byte? companyid { get; set; }
        /// <summary>
        /// supsubcomid
        /// </summary>
        /// <returns></returns>
        [Column("SUPSUBCOMID")]
        public int? supsubcomid { get; set; }
        /// <summary>
        /// url
        /// </summary>
        /// <returns></returns>
        [Column("URL")]
        public string url { get; set; }
        /// <summary>
        /// showorder
        /// </summary>
        /// <returns></returns>
        [Column("SHOWORDER")]
        public int? showorder { get; set; }
        /// <summary>
        /// canceled
        /// </summary>
        /// <returns></returns>
        [Column("CANCELED")]
        public string canceled { get; set; }
        /// <summary>
        /// subcompanycode
        /// </summary>
        /// <returns></returns>
        [Column("SUBCOMPANYCODE")]
        public string subcompanycode { get; set; }
        /// <summary>
        /// outkey
        /// </summary>
        /// <returns></returns>
        [Column("OUTKEY")]
        public string outkey { get; set; }
        /// <summary>
        /// budgetAtuoMoveOrder
        /// </summary>
        /// <returns></returns>
        [Column("BUDGETATUOMOVEORDER")]
        public int? budgetAtuoMoveOrder { get; set; }
        /// <summary>
        /// ecology_pinyin_search
        /// </summary>
        /// <returns></returns>
        [Column("ECOLOGY_PINYIN_SEARCH")]
        public string ecology_pinyin_search { get; set; }
        /// <summary>
        /// limitUsers
        /// </summary>
        /// <returns></returns>
        [Column("LIMITUSERS")]
        public int? limitUsers { get; set; }
        /// <summary>
        /// tlevel
        /// </summary>
        /// <returns></returns>
        [Column("TLEVEL")]
        public int? tlevel { get; set; }
        /// <summary>
        /// created
        /// </summary>
        /// <returns></returns>
        [Column("CREATED")]
        public DateTime? created { get; set; }
        /// <summary>
        /// creater
        /// </summary>
        /// <returns></returns>
        [Column("CREATER")]
        public int? creater { get; set; }
        /// <summary>
        /// modified
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIED")]
        public DateTime? modified { get; set; }
        /// <summary>
        /// modifier
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIER")]
        public int? modifier { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify( int keyValue)
        {
            this.id = keyValue;
        }
        #endregion
    }
}

