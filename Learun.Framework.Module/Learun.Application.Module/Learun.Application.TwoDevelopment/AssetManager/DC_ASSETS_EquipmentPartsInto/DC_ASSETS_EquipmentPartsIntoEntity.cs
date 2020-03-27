using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.AssetManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 16:09
    /// 描 述：DC_ASSETS_EquipmentPartsInto
    /// </summary>
    public class DC_ASSETS_EquipmentPartsIntoEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_EPINID")]
        public string F_EPInId { get; set; }
        /// <summary>
        /// 入库单号,取系统入库单号
        /// </summary>
        [Column("F_INTONUMBER")]
        public string F_IntoNumber { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        [Column("F_INTODATETIME")]
        public DateTime? F_IntoDatetime { get; set; }
        /// <summary>
        /// 入库类型，取数据字典表
        /// </summary>
        [Column("F_INTOTYPE")]
        public string F_IntoType { get; set; }
        /// <summary>
        /// 使用部门主键
        /// </summary>
        [Column("F_USEDEPARTMENTID")]
        public string F_UseDepartmentId { get; set; }
        /// <summary>
        /// 使用部门
        /// </summary>
        [Column("F_USEDEPARTMENT")]
        public string F_UseDepartment { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录人主键
        /// </summary>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserid { get; set; }
        /// <summary>
        /// 记录人
        /// </summary>
        [Column("F_CREATEUSER")]
        public string F_CreateUser { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        [Column("F_CREATEDATETIME")]
        public DateTime? F_CreateDatetime { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_EPInId = Guid.NewGuid().ToString();
            UserInfo user = LoginUserInfo.Get();
            this.F_CreateDepartmentId = user.departmentId;
            this.F_CreateUserid = user.userId;
            this.F_CreateDatetime = DateTime.Now;
            this.F_CreateUser = user.realName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_EPInId = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

