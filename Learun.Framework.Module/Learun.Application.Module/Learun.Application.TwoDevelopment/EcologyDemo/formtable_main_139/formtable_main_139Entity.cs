using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-08 09:46
    /// 描 述：formtable_main_139
    /// </summary>
    public class formtable_main_139Entity 
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
        /// 房屋id
        /// </summary>
        [Column("FWMC")]
        public string fwmc { get; set; }
        /// <summary>
        /// 维修日期
        /// </summary>
        [Column("WXRQ")]
        public string wxrq { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        [Column("SQBM")]
        public int? sqbm { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        [Column("SQYH")]
        public int? sqyh { get; set; }
        /// <summary>
        /// 预计维修金额
        /// </summary>
        [Column("YJWXJE")]
        public string yjwxje { get; set; }
        /// <summary>
        /// 维修地点
        /// </summary>
        [Column("WXDD")]
        public string wxdd { get; set; }
        /// <summary>
        /// 故障描述
        /// </summary>
        [Column("GZMS")]
        public string gzms { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("FJ")]
        public string fj { get; set; }

        [NotMapped]
        public string F_HouseName { get; set; }
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

