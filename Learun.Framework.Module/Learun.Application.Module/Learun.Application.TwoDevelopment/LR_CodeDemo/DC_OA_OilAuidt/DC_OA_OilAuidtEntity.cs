using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 16:08
    /// 描 述：DC_OA_OilAuidt
    /// </summary>
    public class DC_OA_OilAuidtEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_OILID")]
        public string F_OilId { get; set; }
        /// <summary>
        /// 车辆Id
        /// </summary>
        [Column("F_VEHILCEID")]
        public string F_VehilceId { get; set; }
        /// <summary>
        /// 加油时间
        /// </summary>
        [Column("F_ADDOILDATETIME")]
        public DateTime? F_AddOilDateTime { get; set; }
        /// <summary>
        /// 加油里程
        /// </summary>
        [Column("F_ADDDISTANCE")]
        public decimal? F_AddDistance { get; set; }
        /// <summary>
        /// 加油数量
        /// </summary>
        [Column("F_COUNTS")]
        public decimal? F_Counts { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Column("F_MONEY")]
        public decimal? F_Money { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Column("F_PRICE")]
        public decimal? F_Price { get; set; }
        /// <summary>
        /// 油料名称(90#)
        /// </summary>
        [Column("F_OILDNAME")]
        public string F_OildName { get; set; }
        /// <summary>
        /// 申请司机id
        /// </summary>
        [Column("F_REPLY")]
        public string F_Reply { get; set; }
        /// <summary>
        /// 是否审批同意（“-1”驳回，“2”审批同意）
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 当前用户公司
        /// </summary>
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
        /// <summary>
        /// 当前部门Id
        /// </summary>
        [Column("F_CURRENTDEPTID")]
        public string F_CurrentDeptId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_FILES")]
        public string F_Files { get; set; }
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
        public void Modify(string keyValue)
        {
            this.F_OilId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

