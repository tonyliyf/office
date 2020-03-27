using Learun.Util;
using System.Data;
using System.Linq;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.WorkFlow;
using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-12 15:16
    /// 描 述：发文管理
    /// </summary>
    public class DC_OA_DispatchOfficialDocManagerController : MvcControllerBase
    {
        private DC_OA_DispatchOfficialDocManagerIBLL dC_OA_DispatchOfficialDocManagerIBLL = new DC_OA_DispatchOfficialDocManagerBLL();
        private UserIBLL userIBLL = new UserBLL();
        private CodeRuleIBLL CodeRuleIBLL = new CodeRuleBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        private DC_OA_ArchivesIBLL dC_OA_ArchivesIBLL = new DC_OA_ArchivesBLL();
        #region 视图功能

        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form_1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form_2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form_3()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form_4()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form_5()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DoCompleteForm()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form3()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DealIndex()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DealTable(string keyValue)
        {
            DC_OA_DispatchOfficialDocEntity model = dC_OA_DispatchOfficialDocManagerIBLL.GetDC_OA_DispatchOfficialDocEntity(keyValue);
            ViewBag.code = model.F_FileCode.Replace("【", "〔").Replace("】", "〕").Replace("[", "〔").Replace("]", "〕");
            switch (model.F_DenseGrade)
            {
                case "1":
                    ViewBag.grade = "绝密";
                    break;
                case "2":
                    ViewBag.grade = "机密";
                    break;
                case "3":
                    ViewBag.grade = "秘密";
                    break;
                case "4":
                    ViewBag.grade = "一般";
                    break;
                default:
                    break;
            }
            switch (model.F_EmergencyLevel)
            {
                case "1":
                    ViewBag.level = "正常";
                    break;
                case "2":
                    ViewBag.level = "重要";
                    break;
                case "3":
                    ViewBag.level = "紧急";
                    break;
                default:
                    break;
            }
            ViewBag.maintitle = model.F_DocTemplate + "发文处理单";
            ViewBag.title = model.F_Title;
            ViewBag.department = dC_OA_DispatchOfficialDocManagerIBLL.GetDepartmentNameById(model.F_DraftDepartmentId);
            ViewBag.oper = model.F_DraftUserId;
            ViewBag.sendto = model.F_SendTo;
            ViewBag.copyto = model.F_CopyTo;
            ViewBag.sendtoid = model.F_SendToID;
            ViewBag.copytoid = model.F_CopyToID;
            ViewBag.printnum = model.F_PrintNum;
            ViewBag.reviewname = model.F_ReviewUser;
            ViewBag.reviewid = model.F_ReviewUserId;
            ViewBag.checkname = model.F_ProofreadUser;
            ViewBag.checkid = model.F_ProofreadUserId;
            List<string> list = dC_OA_DispatchOfficialDocManagerIBLL.GetAdviceByProcessId(model.F_DODId, Config.GetValue("fileSignatureImg"));
            ViewBag.checkadvice = "";
            ViewBag.signadvice = "";
            if (list.Count > 1)
            {
                ViewBag.checkadvice = list[0];
                ViewBag.signadvice = list[1];
            }
            return View();
        }

        [HttpGet]
        public ActionResult UploadForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TreeView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SettingForm()
        {
            return View();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_DispatchOfficialDocManagerIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetDealIndexPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_DispatchOfficialDocManagerIBLL.GetDealIndexPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_DispatchOfficialDocData = dC_OA_DispatchOfficialDocManagerIBLL.GetDC_OA_DispatchOfficialDocEntity(keyValue);
            var LR_NWF_TaskLogData = dC_OA_DispatchOfficialDocManagerIBLL.GetLR_NWF_TaskLogList(DC_OA_DispatchOfficialDocData.F_DODId);
            var jsonData = new
            {
                DC_OA_DispatchOfficialDoc = DC_OA_DispatchOfficialDocData,
                LR_NWF_TaskLog = LR_NWF_TaskLogData,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataByProcessId(string processId)
        {
            var DC_OA_DispatchOfficialDocData = dC_OA_DispatchOfficialDocManagerIBLL.GetEntityByProcessId(processId);
            IEnumerable<NWFTaskLogEntity> LR_NWF_TaskLogData = null;

            if (DC_OA_DispatchOfficialDocData != null)
            {
                LR_NWF_TaskLogData = dC_OA_DispatchOfficialDocManagerIBLL.GetLR_NWF_TaskLogList(DC_OA_DispatchOfficialDocData.F_DODId);


            }

            var jsonData = new
            {
                DC_OA_DispatchOfficialDoc = DC_OA_DispatchOfficialDocData,
                LR_NWF_TaskLog = LR_NWF_TaskLogData.OrderByDescending(i => i.F_CreateDate),
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            dC_OA_DispatchOfficialDocManagerIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity, string strlR_NWF_TaskLogList)
        {
            DC_OA_DispatchOfficialDocEntity entity = strEntity.ToObject<DC_OA_DispatchOfficialDocEntity>();
            List<NWFTaskLogEntity> lR_NWF_TaskLogList = strlR_NWF_TaskLogList.ToObject<List<NWFTaskLogEntity>>();
            dC_OA_DispatchOfficialDocManagerIBLL.SaveEntity(keyValue, entity, lR_NWF_TaskLogList);
            if (string.IsNullOrEmpty(keyValue))
            {
                CodeRuleIBLL.UseRuleSeed("10002");
            }
            return Success("保存成功！");
        }
        #endregion

        /// <summary>
        /// 办结
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DoComplete(string keyValue, string strEntity)
        {
            dC_OA_DispatchOfficialDocManagerIBLL.DoComplete(keyValue);
            DC_OA_ArchivesEntity entity = strEntity.ToObject<DC_OA_ArchivesEntity>();
            dC_OA_ArchivesIBLL.SaveEntity(keyValue, entity);
            return Success("归档成功！");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetCompleteFormData(string keyValue)
        {
            if (dC_OA_ArchivesIBLL.GetDC_OA_ArchivesEntity(keyValue) == null)
            {
                var guid = Guid.NewGuid().ToString();
                DC_OA_ArchivesEntity model = new DC_OA_ArchivesEntity();
                model.Create();
                model.DC_OA_ArchivesId = keyValue;
                model.F_Files = guid;
                model.DC_OA_Year = DateTime.Now.Year;
                model.DC_OA_ArchiveType = "行政管理类";
                model.DC_OA_NO = "152";
                DC_OA_DispatchOfficialDocManagerService service = new DC_OA_DispatchOfficialDocManagerService();
                service.BaseRepository().Insert(model);
                var dModel = dC_OA_DispatchOfficialDocManagerIBLL.GetEntityByProcessId(keyValue);
                var fileList = annexesFileIBLL.GetList(dModel.F_FileContent_New);
                foreach (var item in fileList)
                {
                    var redFileName = item.F_FilePath.Replace(item.F_FileExtensions, "") + "_s" + item.F_FileExtensions;
                    var destName = item.F_FilePath.Replace(item.F_FileExtensions, "") + "_t" + item.F_FileExtensions;
                    var destName1 = item.F_FilePath.Replace(item.F_FileExtensions, "") + "_z" + item.F_FileExtensions;
                    //复制原本文件
                    item.F_FolderId = guid;
                    item.F_Id = item.F_Id + new Random().Next(0, 999);
                    System.IO.File.Copy(item.F_FilePath, destName, true);
                    item.F_FilePath = destName;
                    service.BaseRepository().Insert(item);
                    if (System.IO.File.Exists(redFileName))//复制套红后文件
                    {
                        System.IO.File.Copy(redFileName, destName1, true);
                        item.F_FolderId = guid;
                        item.F_Id = item.F_Id + new Random().Next(0, 999);
                        item.F_FilePath = destName1;
                        item.F_FileName = item.F_FileName + "(套红)";
                        service.BaseRepository().Insert(item);
                    }

                }
            }
            var DC_OA_ArchivesData = dC_OA_ArchivesIBLL.GetDC_OA_ArchivesEntity(keyValue);
            var jsonData = new
            {
                DC_OA_Archives = DC_OA_ArchivesData,
            };
            return Success(jsonData);
        }
        public ActionResult SendTo(string keyValue, string sendto, string sendtoid, string copyto, string copytoid, string ReviewUserName,
            string ReviewUserId, string ProofreadUserName, string ProofreadUserId, string PrintNum)
        {
            var entity = dC_OA_DispatchOfficialDocManagerIBLL.GetDC_OA_DispatchOfficialDocEntity(keyValue);
            if (entity != null)
            {
                dC_OA_DispatchOfficialDocManagerIBLL.SendTo(keyValue, sendto, sendtoid, copyto, copytoid, ReviewUserName,
                    ReviewUserId, ProofreadUserName, ProofreadUserId, PrintNum);
                return Success("保存成功！");
            }
            else
            {
                return Success("请求失败！");
            }
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetTreeData(string keyValue, int isSend)
        {
            return Json(dC_OA_DispatchOfficialDocManagerIBLL.GetDepartmentTreeNode(keyValue, isSend));
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveSetting(string keyValue, string strEntity)
        {
            DC_OA_DispatchOfficialDocEntity entity = strEntity.ToObject<DC_OA_DispatchOfficialDocEntity>();
            dC_OA_DispatchOfficialDocManagerIBLL.SaveSetting(keyValue, entity);
            return Success("保存成功！");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult IsSettingTemplate(string keyValue)
        {
            return Success(new { result = dC_OA_DispatchOfficialDocManagerIBLL.IsSettingTemplate(keyValue) });
        }
        [HttpPost]
        public ActionResult savenewfile(string keyValue, string guid)
        {
            dC_OA_DispatchOfficialDocManagerIBLL.savenewfile(keyValue, guid);
            return Success("保存成功！");
        }
        [HttpPost]
        public ActionResult getnewfile(string keyValue)
        {
            return Json(new { file = dC_OA_DispatchOfficialDocManagerIBLL.getnewfile(keyValue) });
        }
        [HttpPost]
        public ActionResult IsSend(string keyValue)
        {
            return Json(new { result = dC_OA_DispatchOfficialDocManagerIBLL.IsSend(keyValue) });
        }
        [HttpGet]
        public ActionResult GetProcessStep()
        {
            return Success(dC_OA_DispatchOfficialDocManagerIBLL.GetProcessStep());
        }
    }
}
