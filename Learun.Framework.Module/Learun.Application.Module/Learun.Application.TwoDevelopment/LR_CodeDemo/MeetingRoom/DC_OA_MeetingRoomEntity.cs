using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 17:44
    /// 描 述：会议室管理
    /// </summary>
    public class DC_OA_MeetingRoomEntity 
    {
        #region 实体成员
        /// <summary>
        /// 会议室主键id
        /// </summary>
        [Column("DC_OA_MEETINGROOMID")]
        public string Dc_OA_MeetingRoomId { get; set; }
        /// <summary>
        /// 会议室名称
        /// </summary>
        [Column("DC_OA_MEETINGROOMNAME")]
        public string DC_OA_MeetingRoomName { get; set; }
        /// <summary>
        /// 会议室状态（空闲，使用当中）
        /// </summary>
        [Column("DC_OA_MEETINGROOMSTATE")]
        public string DC_OA_MeetingRoomState { get; set; }
        /// <summary>
        /// 会议室地点
        /// </summary>
        [Column("DC_OA_MEETINGROOMPLACE")]
        public string DC_OA_MeetingRoomPlace { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Column("F_CONTAINER")]
        public int  F_Container { get; set; }

           /// <summary>
        /// 会议室编号
        /// </summary>
        [Column("F_ROOMNO")]
        public string F_RoomNo { get; set; }
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
        /// 编辑人
        /// </summary>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Dc_OA_MeetingRoomId = Guid.NewGuid().ToString();
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_CreateUserId = userInfo.userId;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.Dc_OA_MeetingRoomId = keyValue;
            UserInfo userInfo = LoginUserInfo.Get();
            this.F_ModifyUserId = userInfo.userId;
            this.F_ModifyUserName = userInfo.realName;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

