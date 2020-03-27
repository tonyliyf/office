using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-18 17:47
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecordsProcess
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenancePartsUseEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EMPUID")]
        public string F_EMPUId { get; set; }
        /// <summary>
        /// 设备维修过程主键
        /// </summary>
        [Column("F_EMRPID")]
        public string F_EMRPId { get; set; }
        /// <summary>
        /// 配件信息主键
        /// </summary>
        [Column("F_EPIID")]
        public string F_EPIId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Column("F_USENUMBER")]
        public int? F_UseNumber { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Column("F_UNITPRICE")]
        public double? F_UnitPrice { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        [Column("F_ACCOUNTCOSTS")]
        public double? F_AccountCosts { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EMPUId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EMPUId = keyValue;
        }
        #endregion
    }
}

