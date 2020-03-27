using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-12-31 21:17
    /// 描 述：车辆信息管理
    /// </summary>
    public class DC_OA_VehicleEntity 
    {
        #region 实体成员
        /// <summary>
        /// 车辆主键
        /// </summary>
        [Column("F_VEHICLEID")]
        public string F_VehicleId { get; set; }
        /// <summary>
        /// 车辆名称
        /// </summary>
        [Column("F_VEHICLENAME")]
        public string F_VehicleName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [Column("F_VEHICLESPEC")]
        public string F_VehicleSpec { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [Column("F_VEHICLETPYE")]
        public string F_VehicleTpye { get; set; }
        /// <summary>
        /// 使用日期
        /// </summary>
        [Column("F_VEHICLESTARTDATE")]
        public string F_VehicleStartDate { get; set; }
        /// <summary>
        /// 默认司机
        /// </summary>
        [Column("F_VEHICLEDEFAULUSEID")]
        public string F_VehicleDefaulUseId { get; set; }
        /// <summary>
        /// 是否可使用：1可正常使用 2维修当中，3报废
        /// </summary>
        [Column("F_STATE")]
        public string F_State { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public int? F_Description { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [Column("F_VEHICLENO")]
        public string F_VehicleNO { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_VehicleId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_VehicleId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

