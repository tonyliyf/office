using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_ReportModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-27 16:45
    /// 描 述：VehicleReq报表
    /// </summary>
    public class VehicleReqEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        [Column("F_DEGREE")]
        public string F_Degree { get; set; }
        /// <summary>
        /// 车辆使用情况
        /// </summary>
        [Column("F_CARUSAGE")]
        public string F_CarUsage { get; set; }
        /// <summary>
        /// 车辆
        /// </summary>
        [Column("F_VEHICLE")]
        public string F_Vehicle { get; set; }
        /// <summary>
        /// 司机
        /// </summary>
        [Column("F_DRIVER")]
        public string F_Driver { get; set; }
        /// <summary>
        /// 用车人
        /// </summary>
        [Column("F_USER")]
        public string F_User { get; set; }
        /// <summary>
        /// 用车部门
        /// </summary>
        [Column("F_DEPT")]
        public string F_Dept { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        [Column("F_APPLICANT")]
        public string F_Applicant { get; set; }
        /// <summary>
        /// 事由
        /// </summary>
        [Column("F_CAUSE")]
        public string F_Cause { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        [Column("F_COST")]
        public string F_Cost { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        [Column("F_MILEAGE")]
        public string F_Mileage { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        [Column("F_TOTALPRICE")]
        public string F_TotalPrice { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("F_STARTTIME")]
        public DateTime? F_StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("F_ENDTIME")]
        public DateTime? F_EndTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_NOTE")]
        public string F_Note { get; set; }
        /// <summary>
        /// 经理
        /// </summary>
        [Column("F_MANAGER")]
        public string F_Manager { get; set; }
        /// <summary>
        /// 签字意见
        /// </summary>
        [Column("F_OPINION")]
        public string F_Opinion { get; set; }
        /// <summary>
        /// 0草稿，1审批当中 ，2审批同意，-1驳回
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_Id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

