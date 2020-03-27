using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-12-04 14:52
    /// 描 述：formtable_main_150
    /// </summary>
    public class formtable_main_150Entity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// requestId
        /// </summary>
        [Column("REQUESTID")]
        public int? requestId { get; set; }
        /// <summary>
        /// xmmc
        /// </summary>
        [Column("XMMC")]
        public string xmmc { get; set; }
        /// <summary>
        /// bm
        /// </summary>
        [NotMapped]
        public int? bm { get; set; }
        /// <summary>
        /// yd
        /// </summary>
        [Column("YD")]
        public int? yd { get; set; }
        /// <summary>
        /// jd
        /// </summary>
        [Column("JD")]
        public decimal? jd { get; set; }
        /// <summary>
        /// txsj
        /// </summary>
        [Column("TXSJ")]
        public string txsj { get; set; }
        /// <summary>
        /// hbnr
        /// </summary>
        [Column("HBNR")]
        public string hbnr { get; set; }
        /// <summary>
        /// xyjh
        /// </summary>
        [Column("XYJH")]
        public string xyjh { get; set; }
        /// <summary>
        /// bz
        /// </summary>
        [Column("BZ")]
        public string bz { get; set; }
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
        #region 扩展字段
        #endregion
    }
}

