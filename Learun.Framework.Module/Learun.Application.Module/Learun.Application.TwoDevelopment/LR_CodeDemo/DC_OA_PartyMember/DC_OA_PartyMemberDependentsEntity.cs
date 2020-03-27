using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-09 16:57
    /// 描 述：j111
    /// </summary>
    public class DC_OA_PartyMemberDependentsEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_GUID")]
        public string F_GUID { get; set; }
        /// <summary>
        /// 党员主键，取自党员信息表
        /// </summary>
        [Column("F_PARTYMEMBERGUID")]
        public string F_PartyMemberGUID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column("F_GENDER")]
        public string F_Gender { get; set; }
        /// <summary>
        /// 关系名称，取自数据字典表，存储关系名称
        /// </summary>
        [Column("F_APPELLATIONNAME")]
        public string F_AppellationName { get; set; }
        /// <summary>
        /// 政治面貌名称，取自数据字典表，存储政治面貌名称
        /// </summary>
        [Column("F_POLITICALTYPENAME")]
        public string F_PoliticalTypeName { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        [Column("F_COMPANYDUTIES")]
        public string F_CompanyDuties { get; set; }
        /// <summary>
        /// 职业类型名称，取自数据字典表，存储职业类型名称
        /// </summary>
        [Column("F_OCCUPATIONTYPE")]
        public string F_OccupationType { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Column("F_CONTACTINFO")]
        public string F_ContactInfo { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_GUID = Guid.NewGuid().ToString();
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
            this.F_GUID = keyValue;
        }
        #endregion
    }
}

