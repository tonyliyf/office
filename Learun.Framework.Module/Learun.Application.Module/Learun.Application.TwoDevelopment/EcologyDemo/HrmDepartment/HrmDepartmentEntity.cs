using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.EcologyDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-02 15:33
    /// 描 述：HrmDepartment
    /// </summary>
    public class HrmDepartmentEntity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// departmentmark
        /// </summary>
        /// <returns></returns>
        [Column("DEPARTMENTMARK")]
        public string departmentmark { get; set; }
        /// <summary>
        /// departmentname
        /// </summary>
        /// <returns></returns>
        [Column("DEPARTMENTNAME")]
        public string departmentname { get; set; }
        /// <summary>
        /// subcompanyid1
        /// </summary>
        /// <returns></returns>
        [Column("SUBCOMPANYID1")]
        public int? subcompanyid1 { get; set; }
        /// <summary>
        /// supdepid
        /// </summary>
        /// <returns></returns>
        [Column("SUPDEPID")]
        public int? supdepid { get; set; }
        /// <summary>
        /// allsupdepid
        /// </summary>
        /// <returns></returns>
        [Column("ALLSUPDEPID")]
        public string allsupdepid { get; set; }
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
        /// departmentcode
        /// </summary>
        /// <returns></returns>
        [Column("DEPARTMENTCODE")]
        public string departmentcode { get; set; }
        /// <summary>
        /// coadjutant
        /// </summary>
        /// <returns></returns>
        [Column("COADJUTANT")]
        public int? coadjutant { get; set; }
        /// <summary>
        /// zzjgbmfzr
        /// </summary>
        /// <returns></returns>
        [Column("ZZJGBMFZR")]
        public string zzjgbmfzr { get; set; }
        /// <summary>
        /// zzjgbmfgld
        /// </summary>
        /// <returns></returns>
        [Column("ZZJGBMFGLD")]
        public string zzjgbmfgld { get; set; }
        /// <summary>
        /// jzglbmfzr
        /// </summary>
        /// <returns></returns>
        [Column("JZGLBMFZR")]
        public string jzglbmfzr { get; set; }
        /// <summary>
        /// jzglbmfgld
        /// </summary>
        /// <returns></returns>
        [Column("JZGLBMFGLD")]
        public string jzglbmfgld { get; set; }
        /// <summary>
        /// bmfzr
        /// </summary>
        /// <returns></returns>
        [Column("BMFZR")]
        public string bmfzr { get; set; }
        /// <summary>
        /// bmfgld
        /// </summary>
        /// <returns></returns>
        [Column("BMFGLD")]
        public string bmfgld { get; set; }
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
        public void Modify(int? keyValue)
        {
            this.id = keyValue;
        }
        #endregion
    }
}

