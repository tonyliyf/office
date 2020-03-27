using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-06 11:15
    /// 描 述：广告牌维修记录
    /// </summary>
    public class formtable_main_129Entity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// 广告牌id
        /// </summary>
        [Column("REQUESTID")]
        public int? requestId { get; set; }
        /// <summary>
        /// 维修日期（没使用）
        /// </summary>
        [Column("WXRQ")]
        public string wxrq { get; set; }
        /// <summary>
        /// 广告牌名称
        /// </summary>
        [Column("GGPMC")]
        public string ggpmc { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        [Column("SQBM")]
        public int? sqbm { get; set; }
        /// <summary>
        /// 申请用户
        /// </summary>
        [Column("SQYH")]
        public int? sqyh { get; set; }
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
        /// <summary>
        /// 备注
        /// </summary>
        [Column("BZ")]
        public string bz { get; set; }
        /// <summary>
        /// 维修地点（没使用）
        /// </summary>
        [Column("WXDD")]
        public string wxdd { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Column("RQ")]
        public string rq { get; set; }


        /// <summary>
        /// 申请用户名
        /// </summary>
        [NotMapped]
        
        public string lastname { get; set; }

        /// <summary>
        /// 广告牌名称
        /// </summary>

        [NotMapped]
        public string F_BillboardsName { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        [NotMapped]
        public string F_InstallationLocation { get; set; }

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

