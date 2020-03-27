using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.AssetManager

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 13:34
    /// 描 述：DC_ASSETS_EquipmentPartsRelation
    /// </summary>
    public class DC_ASSETS_EquipmentPartsRelationEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EPRID")]
        public string F_EPRId { get; set; }
        /// <summary>
        /// 设备配件记录主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EPIID")]
        public string F_EPIId { get; set; }
        /// <summary>
        /// 设备记录主键
        /// </summary>
        /// <returns></returns>
        [Column("F_EIID")]
        public string F_EIId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EPRId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EPRId = keyValue;
        }
        #endregion
    }
}

