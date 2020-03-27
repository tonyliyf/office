using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-02 16:09
    /// 描 述：CachetReq
    /// </summary>
    public class CachetReqEntity 
    {
        #region 实体成员

        /// <summary>
        /// 标题
        /// </summary>
        [Column("F_TITLE")]
        public string F_Title { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        [Column("F_DEPT")]
        public string F_Dept { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        [Column("F_APPLICANT")]
        public string F_Applicant { get; set; }

        /// <summary>
        /// 公章类型
        /// </summary>
        [Column("F_CACHETYPE")]
        public string F_CacheType { get; set; }
        /// <summary>
        /// 受函单位
        /// </summary>
        [Column("F_LETTERUNIT")]
        public string F_LetterUnit { get; set; }
        /// <summary>
        /// 函件名称
        /// </summary>
        [Column("F_LETTERNAME")]
        public string F_LetterName { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Column("F_DATATIME")]
        public DateTime? F_Datatime { get; set; }
        /// <summary>
        /// 相关项目
        /// </summary>
        [Column("F_PROJECT")]
        public string F_Project { get; set; }
        /// <summary>
        /// 相关客户
        /// </summary>
        [Column("F_CUSTOMER")]
        public string F_Customer { get; set; }
        /// <summary>
        /// 使用原因
        /// </summary>
        [Column("F_USEREASON")]
        public string F_UseReason { get; set; }
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 签字意见
        /// </summary>
        [Column("F_OPINION")]
        public string F_Opinion { get; set; }
        /// <summary>
        /// F_Remark
        /// </summary>
        [Column("F_REMARK")]
        public string F_Remark { get; set; }
        /// <summary>
        /// F_UseDate
        /// </summary>
        [Column("F_USEDATE")]
        public DateTime? F_UseDate { get; set; }
        /// <summary>
        /// F_FileNum
        /// </summary>
        [Column("F_FILENUM")]
        public string F_FileNum { get; set; }


        /// <summary>
        /// 紧急程度
        /// </summary>
        [Column("F_DEGREE")]
        public string F_Degree { get; set; }
        /// <summary>
        /// 函件编号
        /// </summary>
        [Column("F_LETTERID")]
        public string F_LetterId { get; set; }
        /// <summary>
        /// 相关文档
        /// </summary>
        [Column("F_FILE")]
        public string F_File { get; set; }
        /// <summary>
        /// 相关流程
        /// </summary>
        [Column("F_PROCESS")]
        public string F_Process { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_Id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

