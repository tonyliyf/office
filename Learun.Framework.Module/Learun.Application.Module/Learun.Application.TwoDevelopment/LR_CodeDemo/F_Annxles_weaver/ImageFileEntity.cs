using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    public class ImageFileEntity
    {
        #region 实体成员 
        /// <summary> 
        /// imagefileid 
        /// </summary> 
        /// <returns></returns> 
        [Column("IMAGEFILEID")]
        public int? imagefileid { get; set; }
        /// <summary> 
        /// imagefilename 
        /// </summary> 
        /// <returns></returns> 
        [Column("IMAGEFILENAME")]
        public string imagefilename { get; set; }
        /// <summary> 
        /// imagefiletype 
        /// </summary> 
        /// <returns></returns> 
        [Column("IMAGEFILETYPE")]
        public string imagefiletype { get; set; }
        /// <summary> 
        /// imagefile 
        /// </summary> 
        /// <returns></returns> 
        [Column("IMAGEFILE")]
        public string imagefile { get; set; }
        /// <summary> 
        /// imagefileused 
        /// </summary> 
        /// <returns></returns> 
        [Column("IMAGEFILEUSED")]
        public int? imagefileused { get; set; }
        /// <summary> 
        /// filerealpath 
        /// </summary> 
        /// <returns></returns> 
        [Column("FILEREALPATH")]
        public string filerealpath { get; set; }
        /// <summary> 
        /// iszip 
        /// </summary> 
        /// <returns></returns> 
        [Column("ISZIP")]
        public string iszip { get; set; }
        /// <summary> 
        /// isencrypt 
        /// </summary> 
        /// <returns></returns> 
        [Column("ISENCRYPT")]
        public string isencrypt { get; set; }
        /// <summary> 
        /// fileSize 
        /// </summary> 
        /// <returns></returns> 
        [Column("FILESIZE")]
        public string fileSize { get; set; }
        /// <summary> 
        /// downloads 
        /// </summary> 
        /// <returns></returns> 
        [Column("DOWNLOADS")]
        public int? downloads { get; set; }
        /// <summary> 
        /// miniimgpath 
        /// </summary> 
        /// <returns></returns> 
        [Column("MINIIMGPATH")]
        public string miniimgpath { get; set; }
        /// <summary> 
        /// imgsize 
        /// </summary> 
        /// <returns></returns> 
        [Column("IMGSIZE")]
        public string imgsize { get; set; }
        /// <summary> 
        /// isFTP 
        /// </summary> 
        /// <returns></returns> 
        [Column("ISFTP")]
        public string isFTP { get; set; }
        /// <summary> 
        /// FTPConfigId 
        /// </summary> 
        /// <returns></returns> 
        [Column("FTPCONFIGID")]
        public int? FTPConfigId { get; set; }
        /// <summary> 
        /// isaesencrypt 
        /// </summary> 
        /// <returns></returns> 
        [Column("ISAESENCRYPT")]
        public int? isaesencrypt { get; set; }
        /// <summary> 
        /// aescode 
        /// </summary> 
        /// <returns></returns> 
        [Column("AESCODE")]
        public string aescode { get; set; }
        /// <summary> 
        /// TokenKey 
        /// </summary> 
        /// <returns></returns> 
        [Column("TOKENKEY")]
        public string TokenKey { get; set; }
        /// <summary> 
        /// StorageStatus 
        /// </summary> 
        /// <returns></returns> 
        [Column("STORAGESTATUS")]
        public string StorageStatus { get; set; }
        /// <summary> 
        /// comefrom 
        /// </summary> 
        /// <returns></returns> 
        [Column("COMEFROM")]
        public string comefrom { get; set; }
        /// <summary> 
        /// objId 
        /// </summary> 
        /// <returns></returns> 
        [Column("OBJID")]
        public int? objId { get; set; }
        /// <summary> 
        /// objotherpara 
        /// </summary> 
        /// <returns></returns> 
        [Column("OBJOTHERPARA")]
        public string objotherpara { get; set; }
        /// <summary> 
        /// delfilerealpath 
        /// </summary> 
        /// <returns></returns> 
        [Column("DELFILEREALPATH")]
        public string delfilerealpath { get; set; }
        #endregion

        #region 扩展操作 
        
        #endregion
    }
}
