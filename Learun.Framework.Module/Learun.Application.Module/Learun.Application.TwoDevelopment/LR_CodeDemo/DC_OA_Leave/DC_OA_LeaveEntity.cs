using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-11 09:55
    /// 描 述：DC_OA_Leave
    /// </summary>
    public class DC_OA_LeaveEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_LeaveId
        /// </summary>
        [Column("DC_OA_LEAVEID")]
        public string DC_OA_LeaveId { get; set; }
        /// <summary>
        /// 请假理由
        /// </summary>
        [Column("DC_OA_LEAVEREASON")]
        public string DC_OA_LeaveReason { get; set; }
        /// <summary>
        /// 请假开始时间
        /// </summary>
        [Column("DC_OA_STARTDATE")]
        public DateTime? DC_OA_StartDate { get; set; }
        /// <summary>
        /// 请假结束时间
        /// </summary>
        [Column("DC_OA_ENDDATE")]
        public DateTime? DC_OA_EndDate { get; set; }
        /// <summary>
        /// 请假类型(事假、婚假)
        /// </summary>
        [Column("DC_OA_LEAVETYPE")]
        public string DC_OA_LeaveType { get; set; }
        /// <summary>
        /// 请假时间
        /// </summary>
        [Column("DC_OA_TIMESPAN")]
        public decimal? DC_OA_TimeSpan { get; set; }
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
        /// 部门
        /// </summary>
        [Column("F_DEPARTID")]
        public string F_DepartId { get; set; }
        /// <summary>
        /// F_CompanyId
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_LeaveId = Guid.NewGuid().ToString();
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
            this.DC_OA_LeaveId = keyValue;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

