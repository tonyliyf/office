using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-09 15:49
    /// 描 述：DC_OA__PartyBranch
    /// </summary>
    public class DC_OA_PartyBranchEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PARTYBRANCHGUID")]
        public string F_PartyBranchGUID { get; set; }
        /// <summary>
        /// 党组织编号
        /// </summary>
        [Column("F_PARTYBRANCHCODE")]
        public string F_PartyBranchCode { get; set; }
        /// <summary>
        /// 党组织名称
        /// </summary>
        [Column("F_PARTYBRANCHNAME")]
        public string F_PartyBranchName { get; set; }
        /// <summary>
        /// 上级党组织编号，及父级节点主键
        /// </summary>
        [Column("F_PPARTYBRANCHCODE")]
        public string F_PPartyBranchCode { get; set; }
        /// <summary>
        /// 批准日期
        /// </summary>
        [Column("F_APPROVALDATE")]
        public DateTime? F_ApprovalDate { get; set; }
        /// <summary>
        /// 届满日期
        /// </summary>
        [Column("F_EXPIRYTIME")]
        public DateTime? F_ExpiryTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARK")]
        public string F_Remark { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Column("F_CREATEDATE")]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 归属企业组织主键,取自系统公司信息表，存储主键
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// 归属企业组织，取自系统公司表，存储公司名称
        /// </summary>
        [Column("F_COMPNAY")]
        public string F_Compnay { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PartyBranchGUID = Guid.NewGuid().ToString();
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
            this.F_PartyBranchGUID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

