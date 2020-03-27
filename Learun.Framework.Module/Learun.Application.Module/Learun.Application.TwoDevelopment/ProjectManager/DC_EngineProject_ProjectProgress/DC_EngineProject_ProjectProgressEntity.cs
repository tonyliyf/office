using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-11-01 16:53
    /// 描 述：DC_EngineProject_ProjectProgress
    /// </summary>
    public class DC_EngineProject_ProjectProgressEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_id
        /// </summary>
        [Column("F_ID")]
        public string F_id { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        [Column("F_MONTH")]
        public string F_month { get; set; }
        /// <summary>
        /// 填写人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 进度（%）
        /// </summary>
        [Column("F_PROCEEDINGS")]
        public double? F_proceedings { get; set; }
        /// <summary>
        /// 填写时间
        /// </summary>
        [Column("F_TIME")]
        public DateTime? F_time { get; set; }
        /// <summary>
        /// 汇报内容
        /// </summary>
        [Column("F_SUMMARIZE")]
        public string F_summarize { get; set; }
        /// <summary>
        /// 下月计划
        /// </summary>
        [Column("F_PLAN")]
        public string F_plan { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARK")]
        public string F_remark { get; set; }
        /// <summary>
        /// 填写部门
        /// </summary>
        [Column("F_DEPARTMENT")]
        public string F_Department { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_id = Guid.NewGuid().ToString();
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateUser = user.userId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

