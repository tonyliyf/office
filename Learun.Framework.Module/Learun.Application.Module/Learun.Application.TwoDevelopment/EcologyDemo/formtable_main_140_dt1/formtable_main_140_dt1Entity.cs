using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-14 15:07
    /// 描 述：formtable_main_140_dt1
    /// </summary>
    public class formtable_main_140_dt1Entity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// mainid
        /// </summary>
        [Column("MAINID")]
        public int? mainid { get; set; }
        /// <summary>
        /// ggmc
        /// </summary>
        [Column("GGMC")]
        public string ggmc { get; set; }
        /// <summary>
        /// cqr
        /// </summary>
        [Column("CQR")]
        public int? cqr { get; set; }
        /// <summary>
        /// zzksrq
        /// </summary>
        [Column("ZZKSRQ")]
        public string zzksrq { get; set; }
        /// <summary>
        /// zznx
        /// </summary>
        [Column("ZZNX")]
        public int? zznx { get; set; }
        /// <summary>
        /// zzdj
        /// </summary>
        [Column("ZZDJ")]
        public string zzdj { get; set; }
        /// <summary>
        /// zzsl
        /// </summary>
        [Column("ZZSL")]
        public int? zzsl { get; set; }
        /// <summary>
        /// hj
        /// </summary>
        [Column("HJ")]
        public string hj { get; set; }
        /// <summary>
        /// zzjg
        /// </summary>
        [Column("ZZJG")]
        public string zzjg { get; set; }
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

