using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:47
    /// 描 述：DC_OA_OverSeeWorkTaskExecute
    /// </summary>
    public class DC_OA_OverSeeWorkTaskExecuteEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主表主键
        /// </summary>
        [Column("F_SECONDID")]
        public string F_SecondId { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_THIRDID")]
        public string F_ThirdId { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        [Column("F_EXECUTEDATE")]
        public DateTime F_ExecuteDate { get; set; }
        /// <summary>
        /// 执行情况
        /// </summary>
        [Column("F_EXECUTECONTENT")]
        public string F_ExecuteContent { get; set; }
        /// <summary>
        /// 执行人部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 执行人部门
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 执行人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 执行人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_ThirdId = Guid.NewGuid().ToString();
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_ThirdId = keyValue;
        }
        #endregion
    }
}

