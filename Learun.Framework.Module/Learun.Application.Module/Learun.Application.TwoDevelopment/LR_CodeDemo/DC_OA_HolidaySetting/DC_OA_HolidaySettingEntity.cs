using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-04 11:32
    /// 描 述：节假日设置
    /// </summary>
    public class DC_OA_HolidaySettingEntity 
    {
        #region 实体成员
        /// <summary>
        /// 节假日主键
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_HOLIDAY")]
        public string DC_OA_Holiday { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_DATE")]
        public DateTime? DC_OA_Date { get; set; }
        /// <summary>
        /// 星期几
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_WEEK")]
        public string DC_OA_Week { get; set; }
        /// <summary>
        /// 标注（国庆，元旦等）
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_REMARKS")]
        public string DC_OA_Remarks { get; set; }
        /// <summary>
        /// 0.工作日 1.休息日  2.补休
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_ISWORK")]
        public int? DC_OA_IsWork { get; set; }
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
        /// 编辑日期
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 当前用户id
        /// </summary>
        /// <returns></returns>
        [Column("F_CURRENTUSERID")]
        public string F_CurrentUserId { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_Holiday = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserName = "system";
           // this.F_CreateUserName = userInfo.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.DC_OA_Holiday = keyValue;
            this.F_ModifyDate = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
    }
}

