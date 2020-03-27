using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-29 11:22
    /// 描 述：会议通知回执
    /// </summary>
    public class DC_OA_MeettingRelationEntity 
    {
        #region 实体成员
        /// <summary>
        /// MeettingId
        /// </summary>
        [Column("MEETTINGID")]
        public string MeettingId { get; set; }
        /// <summary>
        /// Userid
        /// </summary>
        [Column("USERID")]
        public string Userid { get; set; }
        /// <summary>
        /// Flag
        /// </summary>
        [Column("FLAG")]
        public int? Flag { get; set; }
        /// <summary>
        /// MeettingType
        /// </summary>
        [Column("MEETTINGTYPE")]
        public int? MeettingType { get; set; }
        /// <summary>
        /// 0不参加，1参加
        /// </summary>
        [Column("ISJOIN")]
        public int? IsJoin { get; set; }
        /// <summary>
        /// 0未读，1已读 ，默认为未读
        /// </summary>
        [Column("ISREADORRETURN")]
        public int? IsReadorReturn { get; set; }
        /// <summary>
        /// 不参加原因
        /// </summary>
        [Column("F_REASON")]
        public string F_Reason { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        [Column("F_READDATE")]
        public DateTime? F_ReadDate { get; set; }
        /// <summary>
        /// 会议开始时间
        /// </summary>
        [Column("F_STARTDATE")]
        public DateTime? F_StartDate { get; set; }
        /// <summary>
        /// 会议内容
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }



        /// <summary>
        /// 引用流程id
        /// </summary>
        [Column("F_WorkFlowId")]
        public string F_Workflowid { get; set; }


        /// <summary>
        /// 会议地址
        /// </summary>
        [Column("F_Address")]
        public string F_Address { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create(UserInfo userInfo)
      {
            this.MeettingId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue, UserInfo userInfo)
        {
            this.MeettingId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

