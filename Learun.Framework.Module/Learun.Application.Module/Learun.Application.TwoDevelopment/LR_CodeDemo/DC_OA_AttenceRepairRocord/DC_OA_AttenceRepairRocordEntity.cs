using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-10 14:09
    /// 描 述：DC_OA_AttenceRepairRocord
    /// </summary>
    public class DC_OA_AttenceRepairRocordEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_RepairRecordId
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REPAIRRECORDID")]
        public string DC_OA_RepairRecordId { get; set; }
        /// <summary>
        /// 补卡人id
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REPAIRRECORDUSERID")]
        public string DC_OA_RepairRecordUserId { get; set; }
        /// <summary>
        /// 补卡理由
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REPAIRREASON")]
        public string DC_OA_RepairReason { get; set; }
        /// <summary>
        /// 补卡部门
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REPAIRDEPTID")]
        public string DC_OA_RepairDeptId { get; set; }
        /// <summary>
        /// 补卡公司
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REPAIRCOMPANYID")]
        public string DC_OA_RepairCompanyId { get; set; }
        /// <summary>
        /// (上午签到、上午签退、下午签到、下午签退）
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REPAIRTYPE")]
        public string Dc_OA_RepairType { get; set; }
        /// <summary>
        /// 有效标志0否1是
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLEDMARK")]
        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>
        /// <returns></returns>
        [Column("F_DELETEMARK")]
        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        /// <returns></returns>
        [Column("F_SORTCODE")]
        public int? F_SortCode { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public int? F_Description { get; set; }
        /// <summary>
        /// 补卡时间
        /// </summary>
        /// <returns></returns>
        [Column("F_REPAIRDATE")]
        public DateTime? F_RepairDate { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        /// <returns></returns>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
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
            this.DC_OA_RepairRecordId = keyValue;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

