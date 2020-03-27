using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-19 20:39
    /// 描 述：租房CPI系数
    /// </summary>
    public class DC_Assets_HouseRentCPIEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_CPIID
        /// </summary>
        [Column("F_CPIID")]
        public string F_CPIID { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        [Column("F_YEAR")]
        public string F_Year { get; set; }
        /// <summary>
        /// CPI系数
        /// </summary>
        [Column("F_VALUE")]
        public double? F_Value { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_CPIID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_CPIID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

