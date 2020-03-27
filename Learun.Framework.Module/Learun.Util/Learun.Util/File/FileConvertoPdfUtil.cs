using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Saving;
using ImageSaveOptions = Aspose.Words.Saving.ImageSaveOptions;

namespace Learun.Util
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileConvertoPdfUtil
    {

        /// <summary>
        ///doc文件转pdf操作
        /// </summary>
        /// <param name="path"></param>
        public static void GetWordDataByAspose(string path)
        {
            Aspose.Words.Document doc = new Aspose.Words.Document(path);
            doc.Save(path.Substring(0, path.LastIndexOf(".")) + ".pdf", Aspose.Words.SaveFormat.Pdf);

        }

        /// <summary>
        ///doc文件转pdf操作
        /// </summary>
        /// <param name="path"></param>
        public static void GetExelDataByAspose(string path)
        {
            Workbook wb = new Workbook(path);

            wb.Save(path.Substring(0, path.LastIndexOf(".")) + ".pdf", Aspose.Cells.SaveFormat.Pdf);

        }

        public static string ConvetWordToImage(string path, string FloderPath, string FileName, out int count)
        {
            Document doc = new Document(path);
            //保存为PDF文件，此处的SaveFormat支持很多种格式，如图片，epub,rtf 等等
            ImageSaveOptions imageOptions = new ImageSaveOptions(Aspose.Words.SaveFormat.Png);
            imageOptions.PrettyFormat = true;
            imageOptions.Resolution = 150;//设置图片质量(越大越清晰)
            StringBuilder buf = new StringBuilder();
            string filetemp = FileName.Remove(FileName.LastIndexOf("."));
            for (int i = 0; i < doc.PageCount; i++)
            {
                imageOptions.PageIndex = i;
                string filename = string.Format("{0}{1}{2}{3}", FloderPath, filetemp, i, ".png");
                doc.Save(filename, imageOptions);
                buf.Append(filetemp+i+".png");
                buf.Append(",");
            }
            count = doc.PageCount;
            if (count > 0)
            {
                return buf.ToString().Substring(0, buf.ToString().Length - 1);
            }
            return string.Empty;

        }

        /// <summary>
        /// 文件预览
        /// </summary>
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        public static void PreviewFile(string filepath, string FileType)
        {
            string filepath1 = filepath.Substring(0, filepath.LastIndexOf(".")) + ".pdf"; ;


            if (FileType == "xlsx" || FileType == "xls")
            {
                //文件名
                if (!DirFileHelper.IsExistFile(filepath1))
                {
                    GetExelDataByAspose(filepath);
                }
                filepath = filepath1;
            }
            if (FileType == "docx" || FileType == "doc")
            {
                if (!DirFileHelper.IsExistFile(filepath1))
                {
                    //添加word转pdf格式
                    GetWordDataByAspose(filepath);
                }
                filepath = filepath1;
            }

            System.Web.HttpContext.Current.Response.ClearContent();
            switch (FileType)
            {
                case "jpg":
                    System.Web.HttpContext.Current.Response.ContentType = "image/jpeg";
                    break;
                case "gif":
                    System.Web.HttpContext.Current.Response.ContentType = "image/gif";
                    break;
                case "png":
                    System.Web.HttpContext.Current.Response.ContentType = "image/png";
                    break;
                case "bmp":
                    System.Web.HttpContext.Current.Response.ContentType = "application/x-bmp";
                    break;
                case "jpeg":
                    System.Web.HttpContext.Current.Response.ContentType = "image/jpeg";
                    break;
                case "doc":
                    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                    break;
                case "docx":
                    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                    break;
                case "ppt":
                    System.Web.HttpContext.Current.Response.ContentType = "application/x-ppt";
                    break;
                case "pptx":
                    System.Web.HttpContext.Current.Response.ContentType = "application/x-ppt";
                    break;
                case "xls":
                    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                    break;
                case "xlsx":
                    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                    break;
                case "pdf":
                    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                    break;
                case "txt":
                    System.Web.HttpContext.Current.Response.ContentType = "text/plain";
                    break;
                case "csv":
                    System.Web.HttpContext.Current.Response.ContentType = "";
                    break;
                default:
                    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
                    break;
            }

            System.Web.HttpContext.Current.Response.Charset = "GB2312";
            System.Web.HttpContext.Current.Response.WriteFile(filepath);
            // System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        }



        /// <summary>
        /// 文件预览
        /// </summary>
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        public static Byte[] PreviewFile(string filepath)
        {
            

            byte[] data = File.ReadAllBytes(filepath);
             return data;
         
        }




    }
}
