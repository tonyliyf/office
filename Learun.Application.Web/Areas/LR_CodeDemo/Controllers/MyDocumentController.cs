using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.OA.File.FileFolder;
using Learun.Application.OA.File.FilePreview;
using System.IO;
using Learun.Application.Base.SystemModule;
using Learun.Application.OA.File.FileInfo;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    public class MyDocumentController : MvcControllerBase
    {
        private MyDocumentService service = new MyDocumentService();
        private FileFolderIBLL fileFolderBLL = new FileFolderBLL();
        private FileInfoIBLL fileInfoBLL = new FileInfoBLL();
        private FilePreviewIBLL filePreviewIBLL = new FilePreviewBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        // GET: LR_CodeDemo/MyDocument
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult NWFContainerForm()
        {
            return View();
        }
        public ActionResult DownForm()
        {
            return View();
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = service.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList1(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = service.GetPageList1(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        public ActionResult GetTree()
        {
            return Success(service.GetTree());
        }

        [HttpPost]
        public ActionResult UploadifyFile(string fileid)
        {
            try
            {
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                string userId = LoginUserInfo.Get().userId;
                string fileGuid = Guid.NewGuid().ToString();
                var data = annexesFileIBLL.GetEntity(fileid);
                long filesize = Convert.ToInt64(data.F_FileSize);
                string FileEextension = Path.GetExtension(data.F_FileName);
                string uploadDate = DateTime.Now.ToString("yyyyMMdd");
                string virtualPath = string.Format("~/Resource/DocumentFile/{0}/{1}/{2}{3}", userId, uploadDate, fileGuid, FileEextension);
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    System.IO.File.Copy(data.F_FilePath, fullFileName);
                    //文件信息写入数据库
                    FileInfoEntity fileInfoEntity = new FileInfoEntity();
                    fileInfoEntity.Create();
                    fileInfoEntity.F_FileId = fileGuid;
                    fileInfoEntity.F_FolderId = "0";
                    fileInfoEntity.F_FileName = data.F_FileName;
                    fileInfoEntity.F_FilePath = virtualPath;
                    fileInfoEntity.F_FileSize = filesize.ToString();
                    fileInfoEntity.F_FileExtensions = FileEextension;
                    fileInfoEntity.F_FileType = FileEextension.Replace(".", "");
                    fileInfoBLL.SaveForm("", fileInfoEntity);
                }
                return Success("上传成功。");
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }
    }
}