using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-18 14:38
    /// 描 述：DC_OA_PersonBackUp
    /// </summary>
    public class DC_OA_PersonBackUpEntity 
    {
        #region 实体成员
        /// <summary>
        /// DC_OA_PersonBackupId
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_PERSONBACKUPID")]
        public string DC_OA_PersonBackupId { get; set; }
        /// <summary>
        /// 人员id
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_USERID")]
        public string DC_OA_UserId { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_COMPANYID")]
        public string DC_OA_CompanyId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_DEPTID")]
        public string DC_OA_DeptId { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_STARTDATE")]
        public DateTime? DC_OA_Startdate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_ENDDATE")]
        public DateTime? DC_OA_Enddate { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 报备原因
        /// </summary>
        /// <returns></returns>
        [Column("DC_OA_BACKUPREASON")]
        public string DC_OA_BackUpReason { get; set; }
        /// <summary>
        /// 0草稿 ，1审批中 ，-1 驳回，2审核同意
        /// </summary>
        /// <returns></returns>
        [Column("IS_AGREE")]
        public string Is_agree { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.DC_OA_PersonBackupId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.DC_OA_PersonBackupId = keyValue;
        }
        #endregion
    }
}

