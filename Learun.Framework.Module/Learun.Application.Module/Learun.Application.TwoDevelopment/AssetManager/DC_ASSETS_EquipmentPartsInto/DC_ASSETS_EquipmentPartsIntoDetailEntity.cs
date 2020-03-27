using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 16:09
    /// 描 述：DC_ASSETS_EquipmentPartsInto
    /// </summary>
    public class DC_ASSETS_EquipmentPartsIntoDetailEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EPINDID")]
        public string F_EPInDId { get; set; }
        /// <summary>
        /// 配件入库主键
        /// </summary>
        [Column("F_EPINID")]
        public string F_EPInId { get; set; }
        /// <summary>
        /// 配件信息主键
        /// </summary>
        [Column("F_EPIID")]
        public string F_EPIId { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        [Column("F_INTONUM")]
        public int F_IntoNum { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EPInDId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EPInDId = keyValue;
        }
        #endregion
    }
}

