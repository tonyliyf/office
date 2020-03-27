using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.EcologyDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-20 09:54
    /// 描 述：项目日志记录
    /// </summary>
    public class formtable_main_134Entity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        [Column("ID")]
        public int? id { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        /// <returns></returns>
        [Column("REQUESTID")]
        public int? requestId { get; set; }
        /// <summary>
        /// （没有使用）
        /// </summary>
        /// <returns></returns>
        [Column("XMMC")]
        public string xmmc { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        /// <returns></returns>
        [Column("RZBH")]
        public string rzbh { get; set; }
        /// <summary>
        /// 填写部门
        /// </summary>
        /// <returns></returns>
        [Column("TXBM")]
        public int? txbm { get; set; }
        /// <summary>
        /// 填写人
        /// </summary>
        /// <returns></returns>
        [Column("TXR")]
        public int? txr { get; set; }
        /// <summary>
        /// 填写时间
        /// </summary>
        /// <returns></returns>
        [Column("TXSJ")]
        public string txsj { get; set; }
        /// <summary>
        /// 上午天气
        /// </summary>
        /// <returns></returns>
        [Column("SWTQ")]
        public string swtq { get; set; }
        /// <summary>
        /// 下午天气
        /// </summary>
        /// <returns></returns>
        [Column("XWTQ")]
        public string xwtq { get; set; }
        /// <summary>
        /// 最高温度
        /// </summary>
        /// <returns></returns>
        [Column("ZGWD")]
        public string zgwd { get; set; }
        /// <summary>
        /// 最低温度
        /// </summary>
        /// <returns></returns>
        [Column("ZDWD")]
        public string zdwd { get; set; }
        /// <summary>
        /// 施工进度情况
        /// </summary>
        /// <returns></returns>
        [Column("SGJZQK")]
        public string sgjzqk { get; set; }
        /// <summary>
        /// 施工主要工作
        /// </summary>
        /// <returns></returns>
        [Column("SGZYGZ")]
        public string sgzygz { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <returns></returns>
        [Column("FJ")]
        public string fj { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        /// <returns></returns>
        [Column("RZXMMC")]
        public string rzxmmc { get; set; }
        /// <summary>
        /// 施工人数
        /// </summary>
        /// <returns></returns>
        [Column("SGRS")]
        public string sgrs { get; set; }
        /// <summary>
        /// 施工机械
        /// </summary>
        /// <returns></returns>
        [Column("SGJX")]
        public string sgjx { get; set; }
        /// <summary>
        /// 明天计划安排
        /// </summary>
        /// <returns></returns>
        [Column("MRJHAP")]
        public string mrjhap { get; set; }
        /// <summary>
        /// 天气情况
        /// </summary>
        /// <returns></returns>
        [Column("TQQK")]
        public string tqqk { get; set; }

        /// <summary>
        /// 项目id
        /// </summary>
        /// <returns></returns>
        [NotMapped]
        public string lastname { get; set; }


        [NotMapped]
        public string F_PIId { get; set; }


     
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

