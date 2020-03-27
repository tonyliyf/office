using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 16:32
    /// 描 述：打卡记录
    /// </summary>
    public class DC_OA_AttenceRecordEntity 
    {
        #region 实体成员
        /// <summary>
        /// 考勤记录主键
        /// </summary>
        [Column("DC_OA_ATTENCERECORDID")]
        public string DC_OA_AttenceRecordId { get; set; }
        /// <summary>
        /// 考勤日期
        /// </summary>
        [Column("DC_OA_ATTENCEDATE")]
        public DateTime? DC_OA_AttenceDate { get; set; }
        /// <summary>
        /// 考勤时间
        /// </summary>
        [Column("DC_OA_ATTENCEDATETIME")]
        public DateTime? DC_OA_AttenceDateTime { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// 打卡人部门ID
        /// </summary>
        [Column("F_OA_ATTENCEDEPTID")]
        public string F_OA_AttenceDeptId { get; set; }
        /// <summary>
        /// 打卡人公司ID
        /// </summary>
        [Column("F_OA_ATTENCECOMPANYID")]
        public string F_OA_AttenceCompanyId { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [Column("LONGITUDE")]
        public string longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Column("LATITUDE")]
        public string latitude { get; set; }
        /// <summary>
        /// 打卡类型(上午签到、上午签退、下午签到、下午签退）
        /// </summary>
        [Column("F_OA_REPAIRTYPE")]
        public string F_OA_RepairType { get; set; }
        /// <summary>
        /// 打卡来源（手机，电脑）
        /// </summary>
        [Column("F_RECORDFROM")]
        public string F_RecordFrom { get; set; }
        /// <summary>
        /// 定位地点
        /// </summary>
        [Column("F_GPSLOCATION")]
        public string F_GpsLocation { get; set; }
        /// <summary>
        /// 打卡人id
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 打卡人姓名
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create(UserInfo userInfo)
      {
            this.DC_OA_AttenceRecordId = Guid.NewGuid().ToString();
            this.F_CreateUserId = userInfo.userId;
            this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue, UserInfo userInfo)
        {
            this.DC_OA_AttenceRecordId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

