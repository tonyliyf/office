using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-23 12:01
    /// 描 述：DC_ASSETS_LandHandUpInfo
    /// </summary>
    public class DC_ASSETS_LandHandUpInfoEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_LANDHANDUPID")]
        public string F_LandHandUpid { get; set; }
        /// <summary>
        /// 摘牌单位
        /// </summary>
        [Column("F_MANAGERDEPT")]
        public string F_ManagerDept { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        [Column("F_CONTRACTNO")]
        public string F_ContractNo { get; set; }
        /// <summary>
        /// 土地证号
        /// </summary>
        [Column("F_LANDNO")]
        public string F_LandNo { get; set; }
        /// <summary>
        /// 宗地坐落
        /// </summary>
        [Column("F_ADDRESS")]
        public string F_Address { get; set; }
        /// <summary>
        /// 面积(m2)
        /// </summary>
        [Column("F_AREA")]
        public double? F_Area { get; set; }
        /// <summary>
        /// 出让金（万元）
        /// </summary>
        [Column("F_TOTALMONEY")]
        public double? F_TotalMoney { get; set; }
        /// <summary>
        /// 中心点坐标
        /// </summary>
        [Column("F_CENTERPOINTCOORDINATES")]
        public string F_CenterpointCoordinates { get; set; }
        /// <summary>
        /// 边界坐标
        /// </summary>
        [Column("F_BOUNDARYCOORDINATES")]
        public string F_BoundaryCoordinates { get; set; }
        /// <summary>
        /// 约定开工时间
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 开工到期时间
        /// </summary>
        [Column("F_STARTENDDATE")]
        public DateTime? F_StartEndDate { get; set; }
        /// <summary>
        /// 竣工时间
        /// </summary>
        [Column("F_ENDDATE")]
        public DateTime? F_EndDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 状态（取自数据字典 土地招拍挂状态  1.需解除合同，2已解除合同 3已开工和竣工 4存量土地，5 新约定开工时间
        /// </summary>
        [Column("F_STATE")]
        public string F_State { get; set; }

        /// <summary>
        /// 土地使用权类型
        /// </summary>
        [Column("F_LANDUSERIGHT")]
        public string F_LandUseRight { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [Column("F_CONTRACTNAME")]
        public string F_ContractName { get; set; }
        /// <summary>
        /// 合同附件
        /// </summary>
        [Column("F_CONTRACTACCESSORIES")]
        public string F_ContractAccessories { get; set; }
        /// <summary>
        /// 成交确认书附件
        /// </summary>
        [Column("F_SALESCONFIRMATION")]
        public string F_SalesConfirmation { get; set; }
        /// <summary>
        /// 票据说明
        /// </summary>
        [Column("F_NOTEDESCRIPTION")]
        public string F_NoteDescription { get; set; }
        /// <summary>
        /// 票据附件
        /// </summary>
        [Column("F_NOTEACCESSORIES")]
        public string F_NoteAccessories { get; set; }
        /// <summary>
        /// 其他资料附件
        /// </summary>
        [Column("F_OTHERACCESSORIES")]
        public string F_OtherAccessories { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_LandHandUpid = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_LandHandUpid = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

