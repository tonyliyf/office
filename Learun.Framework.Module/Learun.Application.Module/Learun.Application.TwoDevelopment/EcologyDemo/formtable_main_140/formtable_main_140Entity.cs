using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-14 14:31
    /// 描 述：formtable_main_140
    /// </summary>
    public class formtable_main_140Entity 
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
        /// 没有使用
        /// </summary>
        [Column("GJXMMC")]
        public string gjxmmc { get; set; }
        /// <summary>
        /// 没有使用
        /// </summary>
        [Column("GJWTR")]
        public string gjwtr { get; set; }
        /// <summary>
        /// fdcgjjg
        /// </summary>
        [Column("FDCGJJG")]
        public string fdcgjjg { get; set; }
        /// <summary>
        /// zzzj
        /// </summary>
        [Column("ZZZJ")]
        public string zzzj { get; set; }
        /// <summary>
        /// fj
        /// </summary>
        [Column("FJ")]
        public string fj { get; set; }
        /// <summary>
        /// jbr
        /// </summary>
        [Column("JBR")]
        public string  jbr { get; set; }
        /// <summary>
        /// zzrq
        /// </summary>
        [Column("ZZRQ")]
        public string zzrq { get; set; }
        /// <summary>
        /// zzdw
        /// </summary>
        [Column("ZZDW")]
        public int? zzdw { get; set; }


        /// <summary>
        /// zzdw
        /// </summary>
        [Column("zzdwname")]
        public string zzdwname { get; set; }
        [NotMapped]
        public string lastname { get; set; }

        [NotMapped]
        public string departmentname { get; set; }

        
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

