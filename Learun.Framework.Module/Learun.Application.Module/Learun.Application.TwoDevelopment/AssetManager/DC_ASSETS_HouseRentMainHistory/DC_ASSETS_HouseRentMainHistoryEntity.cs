using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 13:45
    /// 描 述：DC_ASSETS_HouseRentMain
    /// </summary>
    public class DC_ASSETS_HouseRentMainHistoryEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_HRMID")]
        public string F_HRMId { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        [Column("F_RENTYEAR")]
        public string F_RentYear { get; set; }
        /// <summary>
        /// 批次
        /// </summary>
        [Column("F_RENTNUMBER")]
        public string F_RentNumber { get; set; }
        /// <summary>
        /// 招租名称
        /// </summary>
        [Column("F_RENTNAME")]
        public string F_RentName { get; set; }
        /// <summary>
        /// 招租单位
        /// </summary>
        [Column("F_UNIT")]
        public string F_Unit { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_ACCESSORIES")]
        public string F_Accessories { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 记录人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        /// <summary>
        /// 招租状态,取数据字典表，如进行中、暂停、结束等
        /// </summary>
        [Column("F_RENTSTATE")]
        public string F_RentState { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        [Column("F_RentTime")]
        public DateTime? F_RentTime { get; set; }


      
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_HRMId = Guid.NewGuid().ToString();
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateDatetime = DateTime.Now;
            this.F_CreateUser = user.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_HRMId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

