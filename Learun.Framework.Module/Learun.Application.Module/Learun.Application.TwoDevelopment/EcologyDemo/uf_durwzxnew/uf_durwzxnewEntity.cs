using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.EcologyDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-09 16:38
    /// 描 述：督办任务执行表
    /// </summary>
    public class uf_durwzxnewEntity 
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
        /// lxmxid
        /// </summary>
        /// <returns></returns>
        [Column("LXMXID")]
        public string lxmxid { get; set; }
        /// <summary>
        /// rwztz
        /// </summary>
        /// <returns></returns>
        [Column("RWZTZ")]
        public int? rwztz { get; set; }
        /// <summary>
        /// zrwmc
        /// </summary>
        /// <returns></returns>
        [Column("ZRWMC")]
        public string zrwmc { get; set; }
        /// <summary>
        /// rwzt
        /// </summary>
        /// <returns></returns>
        [Column("RWZT")]
        public int? rwzt { get; set; }
        /// <summary>
        /// rwmc
        /// </summary>
        /// <returns></returns>
        [Column("RWMC")]
        public string rwmc { get; set; }
        /// <summary>
        /// rwbh
        /// </summary>
        /// <returns></returns>
        [Column("RWBH")]
        public string rwbh { get; set; }
        /// <summary>
        /// zbr
        /// </summary>
        /// <returns></returns>
        [Column("ZBR")]
        public int? zbr { get; set; }
        /// <summary>
        /// zbbm
        /// </summary>
        /// <returns></returns>
        [Column("ZBBM")]
        public int? zbbm { get; set; }
        /// <summary>
        /// zxr
        /// </summary>
        /// <returns></returns>
        [Column("ZXR")]
        public int? zxr { get; set; }
        /// <summary>
        /// ssks
        /// </summary>
        /// <returns></returns>
        [Column("SSKS")]
        public int? ssks { get; set; }
        /// <summary>
        /// jbrq
        /// </summary>
        /// <returns></returns>
        [Column("JBRQ")]
        public string jbrq { get; set; }
        /// <summary>
        /// yqbjrq
        /// </summary>
        /// <returns></returns>
        [Column("YQBJRQ")]
        public string yqbjrq { get; set; }
        /// <summary>
        /// rwlx
        /// </summary>
        /// <returns></returns>
        [Column("RWLX")]
        public string rwlx { get; set; }
        /// <summary>
        /// formmodeid
        /// </summary>
        /// <returns></returns>
        [Column("FORMMODEID")]
        public int? formmodeid { get; set; }
        /// <summary>
        /// modedatacreater
        /// </summary>
        /// <returns></returns>
        [Column("MODEDATACREATER")]
        public int? modedatacreater { get; set; }
        /// <summary>
        /// modedatacreatertype
        /// </summary>
        /// <returns></returns>
        [Column("MODEDATACREATERTYPE")]
        public int? modedatacreatertype { get; set; }
        /// <summary>
        /// modedatacreatedate
        /// </summary>
        /// <returns></returns>
        [Column("MODEDATACREATEDATE")]
        public string modedatacreatedate { get; set; }
        /// <summary>
        /// modedatacreatetime
        /// </summary>
        /// <returns></returns>
        [Column("MODEDATACREATETIME")]
        public string modedatacreatetime { get; set; }
        /// <summary>
        /// fj
        /// </summary>
        /// <returns></returns>
        [Column("FJ")]
        public string fj { get; set; }
        /// <summary>
        /// zrwsxbh
        /// </summary>
        /// <returns></returns>
        [Column("ZRWSXBH")]
        public string zrwsxbh { get; set; }
        /// <summary>
        /// MODEUUID
        /// </summary>
        /// <returns></returns>
        [Column("MODEUUID")]
        public string MODEUUID { get; set; }
        /// <summary>
        /// jd
        /// </summary>
        /// <returns></returns>
        [Column("JD")]
        public int? jd { get; set; }
        /// <summary>
        /// jdfk
        /// </summary>
        /// <returns></returns>
        [Column("JDFK")]
        public decimal? jdfk { get; set; }
        /// <summary>
        /// zrwztnew
        /// </summary>
        /// <returns></returns>
        [Column("ZRWZTNEW")]
        public int? zrwztnew { get; set; }
        /// <summary>
        /// zrld
        /// </summary>
        /// <returns></returns>
        [Column("ZRLD")]
        public string zrld { get; set; }
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

