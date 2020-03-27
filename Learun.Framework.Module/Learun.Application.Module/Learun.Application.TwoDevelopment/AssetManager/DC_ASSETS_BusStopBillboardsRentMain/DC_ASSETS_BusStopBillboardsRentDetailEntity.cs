using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-07 11:49
    /// 描 述：广告招租
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentDetailEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_BSBRDID")]
        public string F_BSBRDId { get; set; }
        /// <summary>
        /// 招租信息主表主键
        /// </summary>
        [Column("F_BSBRMID")]
        public string F_BSBRMId { get; set; }
        /// <summary>
        /// 广告牌信息主键
        /// </summary>
        [Column("F_BSBID")]
        public string F_BSBId { get; set; }
        /// <summary>
        /// 招标类型,取值于数据字典，如公开招标、暗标等
        /// </summary>
        [Column("F_TENDERTYPE")]
        public string F_TenderType { get; set; }
        /// <summary>
        /// 租赁状态,取数据字典表，如待租、已租、终止等
        /// </summary>
        [Column("F_LEASESTATE")]
        public string F_LeaseState { get; set; }
        /// <summary>
        /// 评估价
        /// </summary>
        [Column("F_VALUATIONPRICE")]
        public double? F_ValuationPrice { get; set; }
        /// <summary>
        /// 招租底价
        /// </summary>
        [Column("F_RENTRESERVEPRICE")]
        public double? F_RentReservePrice { get; set; }
        /// <summary>
        /// 竟租保证金
        /// </summary>
        [Column("F_RENTDEPOSIT")]
        public double? F_RentDeposit { get; set; }
        /// <summary>
        /// 出租年限，注意与租赁起始日期、租赁结束日期的一致性
        /// </summary>
        [Column("F_RENTAGE")]
        public int? F_RentAge { get; set; }
        /// <summary>
        /// 实际价格
        /// </summary>
        [Column("F_ACTUALPRICE")]
        public double? F_ActualPrice { get; set; }
        /// <summary>
        /// 租赁人姓名
        /// </summary>
        [Column("F_RENTER")]
        public string F_Renter { get; set; }
        /// <summary>
        /// 租赁人身份证号
        /// </summary>
        [Column("F_RENTERIDNO")]
        public string F_RenterIDNo { get; set; }
        /// <summary>
        /// 租赁人单位名称
        /// </summary>
        [Column("F_RENTERCOMPANY")]
        public string F_RenterCompany { get; set; }
        /// <summary>
        /// 租赁人联系电话
        /// </summary>
        [Column("F_RENTERPHONE")]
        public string F_RenterPhone { get; set; }
        /// <summary>
        /// 出租面积
        /// </summary>
        [Column("F_RENTAREA")]
        public double? F_RentArea { get; set; }
        /// <summary>
        /// 租赁起始时间
        /// </summary>
        [Column("F_RENTSTARTTIME")]
        public DateTime? F_RentStartTime { get; set; }
        /// <summary>
        /// 租赁结束时间，依据出租年限和租赁起始日期自动得出
        /// </summary>
        [Column("F_RENTENDTIME")]
        public DateTime? F_RentEndTime { get; set; }
        /// <summary>
        /// 租金提醒,设置租赁起始后提醒天数
        /// </summary>
        [Column("F_RENTREMINDER")]
        public int? F_RentReminder { get; set; }
        /// <summary>
        /// 租金到期,设置租赁起始后到期天数
        /// </summary>
        [Column("F_EXPIREREMINDER")]
        public int? F_ExpireReminder { get; set; }
        /// <summary>
        /// 租金提醒日期,系统自动处理，依据租金提醒设置、租赁起始日期和出租年限计算
        /// </summary>
        [Column("F_RENTREMINDERDATE")]
        public DateTime? F_RentReminderDate { get; set; }
        /// <summary>
        /// 租金到期日期,系统自动处理，依据租金到期设置、租赁起始日期和出租年限计算
        /// </summary>
        [Column("F_EXPIREREMINDERDATE")]
        public DateTime? F_ExpireReminderDate { get; set; }
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
        /// 广告牌名称
        /// </summary>
        [Column("F_BILLBOARDSNAME")]
        public string F_BillboardsName { get; set; }

        [NotMapped]
        public string F_InstallationLocation { get; set; }


        [NotMapped]
        public string F_CenterpointCoordinates { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_BSBRDId = Guid.NewGuid().ToString();
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
            this.F_BSBRDId = keyValue;
        }
        #endregion
    }
}

