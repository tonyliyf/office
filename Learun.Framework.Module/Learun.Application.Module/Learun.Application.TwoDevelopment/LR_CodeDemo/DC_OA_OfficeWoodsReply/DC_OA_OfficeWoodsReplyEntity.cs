using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 16:28
    /// 描 述：DC_OA_OfficeWoodsReply
    /// </summary>
    public class DC_OA_OfficeWoodsReplyEntity
    {

       

        #region 实体成员

        /// <summary>
        /// 当前用户公司
        /// </summary>
        [Column("F_CURRENTCOMPANYID")]
        public string F_CurrentCompanyId { get; set; }
        /// <summary>
        /// 当前部门Id
        /// </summary>
        [Column("F_CURRENTDEPTID")]
        public string F_CurrentDeptId { get; set; }
        /// <summary>
        /// 申请月份
        /// </summary>
        [Column("F_REPLYMONTH")]
        public string F_ReplyMonth { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_OFFICEWOODSREPLYID")]
        public string F_OfficeWoodsReplyId { get; set; }
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
        /// 当前用户Id
        /// </summary>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_FILE")]
        public string F_File { get; set; }
        /// <summary>
        /// -1,驳回，2审批同意，1审批当中
        /// </summary>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        /// <summary>
        /// 1.申请信息,2汇总信息
        /// </summary>  
        [Column("F_TYPE")]
        public int? F_type { get; set; }
        [Column("F_SumMoney")]
        public double? F_SumMoney { get; set; }

        /// <summary>
        /// 申请编号
        /// </summary>
        [Column("F_REPLYIDNO")]
        public string F_ReplyIdNo { get; set; }
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
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_OfficeWoodsReplyId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

