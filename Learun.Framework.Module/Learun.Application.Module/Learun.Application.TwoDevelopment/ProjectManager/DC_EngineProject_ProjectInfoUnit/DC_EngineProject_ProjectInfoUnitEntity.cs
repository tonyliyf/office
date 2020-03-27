using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 15:56
    /// 描 述：工程项目单位信息管理
    /// </summary>
    public class DC_EngineProject_ProjectInfoUnitEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_PIUID")]
        public string F_PIUId { get; set; }
        /// <summary>
        /// 工程项目基本信息主键
        /// </summary>
        [Column("F_PIID")]
        public string F_PIId { get; set; }
        /// <summary>
        /// 工程项目单位类型,取值数据字典，如建设单位、勘察单位、设计单位、施工单位、监理单位
        /// </summary>
        [Column("F_UNITTYPE")]
        public string F_UnitType { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [Column("F_UNITNAME")]
        public string F_UnitName { get; set; }
        /// <summary>
        /// 单位地址
        /// </summary>
        [Column("F_UNITADDRESS")]
        public string F_UnitAddress { get; set; }
        /// <summary>
        /// 单位联系人
        /// </summary>
        [Column("F_UNITCONTACT")]
        public string F_UnitContact { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        [Column("F_UNITCONTACTPHONE")]
        public string F_UnitContactPhone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("F_REMARKS")]
        public string F_Remarks { get; set; }
        /// <summary>
        /// 记录部门名称
        /// </summary>
        [Column("F_CREATEDEPARTMENT")]
        public string F_CreateDepartment { get; set; }
        /// <summary>
        /// 记录部门主键
        /// </summary>
        [Column("F_CREATEDEPARTMENTID")]
        public string F_CreateDepartmentId { get; set; }
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

        /// <summary>
        /// 公司法人
        /// </summary>
        [Column("F_Manager")]
        public string F_Manager { get; set; }

        /// <summary>
        /// 评价等级
        /// </summary>
        [Column("F_Evaluation")]
        public string F_Evaluation { get; set; }

        /// <summary>
        ///资质证书
        /// </summary>
        [Column("F_CerticateZizi")]
        public string F_CerticateZizi { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        [Column("F_CertifacateNo")]
        public string F_CertifacateNo { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        [Column("F_File")]
        public string F_File { get; set; }


        /// <summary>
        /// 是否有效
        /// </summary>
        [Column("F_Flag")]
        public string F_Flag { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_PIUId = Guid.NewGuid().ToString();
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
            this.F_PIUId = keyValue;
        }
        #endregion
    }
}

