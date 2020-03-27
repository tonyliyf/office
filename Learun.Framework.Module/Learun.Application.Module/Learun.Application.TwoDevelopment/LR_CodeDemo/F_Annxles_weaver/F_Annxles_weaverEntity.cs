using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-12-16 10:45
    /// 描 述：F_Annxles_weaver
    /// </summary>
    public class F_Annxles_weaverEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        /// <returns></returns>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        /// <returns></returns>
        [Column("F_FILENAME")]
        public string F_FileName { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        /// <returns></returns>
        [Column("F_FILEPATH")]
        public string F_FilePath { get; set; }
        /// <summary>
        /// 泛微业务表Id
        /// </summary>
        /// <returns></returns>
        [Column("F_WEAVERID")]
        public int? F_weaverid { get; set; }
        /// <summary>
        /// 泛微附件doc表id
        /// </summary>
        /// <returns></returns>
        [Column("F_WEAVERDOCID")]
        public int? F_Weaverdocid { get; set; }
        /// <summary>
        /// 泛微附件表id
        /// </summary>
        /// <returns></returns>
        [Column("F_WEAVERIMAGEID")]
        public int? F_WeaverImageId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("F_COMMETS")]
        public string F_commets { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <returns></returns>
        [Column("F_ENABLED")]
        public int? F_enabled { get; set; }
        /// <summary>
        /// 取自哪个表
        /// </summary>
        /// <returns></returns>
        [Column("F_WEAVERTABLE")]
        public string F_Weavertable { get; set; }
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
    }
}

