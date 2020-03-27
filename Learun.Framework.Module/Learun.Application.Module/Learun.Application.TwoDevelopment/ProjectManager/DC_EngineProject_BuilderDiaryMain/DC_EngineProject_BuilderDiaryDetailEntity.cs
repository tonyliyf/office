using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 10:59
    /// 描 述：DC_EngineProject_BuilderDiaryMain
    /// </summary>
    public class DC_EngineProject_BuilderDiaryDetailEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_BDDID")]
        public string F_BDDId { get; set; }
        /// <summary>
        /// 主表主键
        /// </summary>
        [Column("F_BDMID")]
        public string F_BDMId { get; set; }
        /// <summary>
        /// 施工班组
        /// </summary>
        [Column("F_WORKTEAM")]
        public string F_WorkTeam { get; set; }
        /// <summary>
        /// 工作人数
        /// </summary>
        [Column("F_WORKERS")]
        public int? F_Workers { get; set; }
        /// <summary>
        /// 施工内容
        /// </summary>
        [Column("F_WORKCONTENT")]
        public string F_WorkContent { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_BDDId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_BDDId = keyValue;
        }
        #endregion
    }
}

