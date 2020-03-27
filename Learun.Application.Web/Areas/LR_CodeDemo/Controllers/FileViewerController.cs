using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using System.Linq;
using System.Text.RegularExpressions;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    public class FileViewerController : MvcControllerBase
    {
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        // GET: LR_CodeDemo/FileViewer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileViewer(string fid)
        {
            return View();
                     
        }


        public ActionResult ImageViewer()
        {
            return View();

        }
        public ActionResult GetImageList(string folderIdList)
        {

            string virtualPath =Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
            string temp = virtualPath.Replace("\\", "/");

          

            if (!string.IsNullOrWhiteSpace(folderIdList))
            {
                string[] imgType = { "jpg", "png", "gif","jpeg","bmp" };
             
                var arr = folderIdList.Split(',');
                List<AnnexesFileEntity> list = new List<AnnexesFileEntity>();
                foreach (var str in arr)
                {
                    list.AddRange(annexesFileIBLL.GetList(str));
                }
                list = list.Where(c => imgType.Contains(c.F_FileType)).ToList();
              
                foreach(var item in list)
                {
                    //item.F_FilePath = DirFileHelper.ConvertSpecifiedPathToRelativePath(item.F_FilePath);
                    // item.F_FilePath = item.F_FilePath.Replace(virtualPath.Replace("\\", "/"),Server.MapPath("/")　);
                    item.F_FilePath = Regex.Replace(item.F_FilePath, temp, Request.ApplicationPath, RegexOptions.IgnoreCase);

                    
                }

                return Success(list);
            }
            return Fail("id无效");
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode(string fid)
        {
           // string aa = DirFileHelper.urlconvertor(@"d:/oaSystem/doc/fileAnnexes/System/20191113/0d706474-676a-41f6-80ee-dd21489c61d8.jpg");
            
            var entity = annexesFileIBLL.GetEntity(fid);
            return File( FileConvertoPdfUtil.PreviewFile(entity.F_FilePath), @"image/Gif");
        }

        public ActionResult GetList(string folderIdList, string queryJson)
        {
            if (!string.IsNullOrWhiteSpace(folderIdList))
            {
                var param = queryJson.ToJObject();
                string type = param["type"].IsEmpty() ? "" : param["type"].ToString();
                string[] imgType = { "jpg", "png" };
                string[] documentType = { "xlsx", "docx", "txt", "doc", "xls" };
                var arr = folderIdList.Split(',');
                List<AnnexesFileEntity> list = new List<AnnexesFileEntity>();
                foreach (var str in arr)
                {
                    list.AddRange(annexesFileIBLL.GetList(str));
                }
                switch (type)
                {
                    case "1":
                        list = list.Where(c => documentType.Contains(c.F_FileType)).ToList();
                        break;
                    case "2":
                        list = list.Where(c => imgType.Contains(c.F_FileType)).ToList();
                        break;
                    case "3":
                        list = list.Where(c => !imgType.Contains(c.F_FileType) && !documentType.Contains(c.F_FileType)).ToList();
                        break;
                    default:
                        break;
                }
                return Success(list);
            }
            return Fail("id无效");
        }


        public void FileViewerWnd(string fid)
        {
            var entity = annexesFileIBLL.GetEntity(fid);
            FileConvertoPdfUtil.PreviewFile(entity.F_FilePath, entity.F_FileType.ToLower());
        }

       
    }
}