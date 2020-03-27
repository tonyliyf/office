using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.AssetManager

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-18 12:34
    /// 描 述：租户信息表
    /// </summary>
    public class DC_ASSETS_HouseRentDetail_InfoHistoryEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTINFOID")]
        public string F_RentInfoId { get; set; }
        /// <summary>
        /// 租赁信息主键
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTDETAILID")]
        public string F_RentDetailId { get; set; }
        /// <summary>
        /// 租赁人姓名
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTER")]
        public string F_Renter { get; set; }
        /// <summary>
        /// 租赁人身份证
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTERIDNO")]
        public string F_RenterIDNo { get; set; }
        /// <summary>
        /// 租赁面积
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTAREA")]
        public double? F_RentArea { get; set; }
        /// <summary>
        /// 租赁人单位名称
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTERCOMPANY")]
        public string F_RenterCompany { get; set; }
        /// <summary>
        /// 租赁人电话
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTERPHONE")]
        public string F_RenterPhone { get; set; }


        /// <summary>
        /// 做啥事
        /// </summary>
        /// <returns></returns>
        [Column("F_DoThings")]
        public string F_DoThings { get; set; }
        /// <summary>
        /// 竞租保证金
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTDEPOSIT")]
        public double? F_RentDeposit { get; set; }

        /// <summary>
        /// 招租底价
        /// </summary>
        [Column("F_RENTRESERVEPRICE")]
        public double F_RentReservePrice { get; set; }


        /// <summary>
        /// 实际价格
        /// </summary>
        /// <returns></returns>
        [Column("F_ACTUALPRICE")]
        public double? F_ActualPrice { get; set; }
        /// <summary>
        /// 出租年限，注意与租赁起始日期、租赁结束日期的一致性
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTAGE")]
        public int? F_RentAge { get; set; }
        /// <summary>
        /// 租赁起始时间
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTSTARTTIME")]
        public DateTime? F_RentStartTime { get; set; }
        /// <summary>
        /// 租赁结束时间，依据出租年限和租赁起始日期自动得出
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTENDTIME")]
        public DateTime? F_RentEndTime { get; set; }
        /// <summary>
        /// 租金提醒日期,系统自动处理，依据租金提醒设置、租赁起始日期和出租年限计算
        /// </summary>
        /// <returns></returns>
        [Column("F_RENTREMINDERDATE")]
        public DateTime? F_RentReminderDate { get; set; }
        /// <summary>
        /// 租金到期日期,系统自动处理，依据租金到期设置、租赁起始日期和出租年限计算
        /// </summary>
        /// <returns></returns>
        [Column("F_EXPIREREMINDERDATE")]
        public DateTime? F_ExpireReminderDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        /// <returns></returns>
        [Column("F_FILES")]
        public string F_Files { get; set; }
        /// <summary>
        /// 坐落位置
        /// </summary>
        /// <returns></returns>
        [Column("F_LOCATION")]
        public string F_Location { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        /// <returns></returns>
        [Column("F_ContractNo")]
        public string F_ContractNo { get; set; }


        /// <summary>
        /// 保证金状态
        /// </summary>
        /// <returns></returns>
        [Column("F_RentDepositState")]
        public string F_RentDepositState { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        /// <returns></returns>
        [Column("F_Manager")]
        public string F_Manager { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_RentInfoId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_RentInfoId = keyValue;
        }
        #endregion
    }
}

