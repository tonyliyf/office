using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-16 16:28
    /// 描 述：formtable_main_131
    /// </summary>
    public class formtable_main_131Entity 
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
        /// wxrq
        /// </summary>
        [Column("WXRQ")]
        public string wxrq { get; set; }
        /// <summary>
        /// sbmc
        /// </summary>
        [Column("SBMC")]
        public string sbmc { get; set; }
        /// <summary>
        /// sqbm
        /// </summary>
        [Column("SQBM")]
        public int? sqbm { get; set; }
        /// <summary>
        /// sqyh
        /// </summary>
        [Column("SQYH")]
        public int? sqyh { get; set; }
        /// <summary>
        /// gzms
        /// </summary>
        [Column("GZMS")]
        public string gzms { get; set; }
        /// <summary>
        /// fj
        /// </summary>
        [Column("FJ")]
        public string fj { get; set; }
        /// <summary>
        /// bz
        /// </summary>
        [Column("BZ")]
        public string bz { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("yjwxje")]
        public string yjwxje { get; set; }

        /// <summary>
        /// wxdd
        /// </summary>
        [Column("WXDD")]
        public string wxdd { get; set; }
       [NotMapped]
        public string F_EquipmentName { get; set; }
        /// <summary>
        /// wxdd
        /// </summary>
        [NotMapped]
        public string lastname { get; set; }
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

