using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_ReportModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-28 15:06
    /// 描 述：维修车辆统计报表
    /// </summary>
    public class DC_OA_VehicleRepairRecordEntity 
    {
        #region 实体成员
        /// <summary>
        /// 维修记录主键
        /// </summary>
        [Column("F_VEHICLEREPAIRID")]
        public string F_VehicleRepairId { get; set; }
        /// <summary>
        /// 维修名称
        /// </summary>
        [Column("F_VEHICLEREPAIRNAME")]
        public string F_VehicleRepairName { get; set; }
        /// <summary>
        /// 车辆id
        /// </summary>
        [Column("F_VEHICLEREFID")]
        public string F_VehicleRefId { get; set; }
        /// <summary>
        /// 损坏日期
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_Startdate { get; set; }
        /// <summary>
        /// 维修原因
        /// </summary>
        [Column("F_VEHICLEREPAIRREASON")]
        public string F_VehicleRepairReason { get; set; }
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
        /// 维修地点
        /// </summary>
        [Column("F_VEHICLEPLACE")]
        public string F_VehiclePlace { get; set; }
        /// <summary>
        /// 维修单据
        /// </summary>
        [Column("F_VEHICLEREPAIRNO")]
        public string F_VehicleRepairNo { get; set; }
        /// <summary>
        /// 维修金额
        /// </summary>
        [Column("F_VEHICLEREPAIRMONEY")]
        public decimal? F_VehicleRepairMoney { get; set; }
        /// <summary>
        /// 维修申请人
        /// </summary>
        [Column("F_REPLYID")]
        public string F_ReplyId { get; set; }
        /// <summary>
        /// 预计维修金额
        /// </summary>
        [Column("F_MONEY")]
        public decimal? F_Money { get; set; }
        /// <summary>
        /// 申请公司
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        [Column("F_DEPTID")]
        public string F_DeptId { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 故障原因
        /// </summary>
        [Column("F_BREAKDOWN")]
        public string F_breakdown { get; set; }
        /// <summary>
        /// 故障类型
        /// </summary>
        [Column("F_BREAKDOWNTYPE")]
        public string F_breakdownType { get; set; }
        /// <summary>
        /// 司机
        /// </summary>
        [Column("F_DRIVER")]
        public string F_driver { get; set; }
        /// <summary>
        /// 维修项目
        /// </summary>
        [Column("F_SERVICEPEPROJECT")]
        public string F_servicepeProject { get; set;}
        /// <summary>
        /// 车牌号
        /// </summary>
        [Column("F_LICENSE")]
        public string F_license { get; set; }
        /// <summary>
        /// 预计维修开始时间
        /// </summary>
        [Column("F_VEHICLESTARTDATE")]
        public string F_VehicleStartDate { get; set; }
        /// <summary>
        /// 预计维修结束时间
        /// </summary>
        [Column("F_VEHICLEENDDATE")]
        public string F_VehicleEndDate { get; set; }
        /// <summary>
        /// 预计维修结束时间
        /// </summary>
        [Column("F_VEHICLELOCATION")]
        public string F_VehicleLocation { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ATTACHMENTS")]
        public string F_Attachments { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_VehicleRepairId = Guid.NewGuid().ToString();
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
            this.F_VehicleRepairId = keyValue;
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

