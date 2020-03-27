using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.WorkFlow;
using Learun.Application.Base.SystemModule;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-14 12:10
    /// 描 述：收文管理
    /// </summary>
    public class DC_OA_ReceiveOfficialDocManagerController : MvcControllerBase
    {
        private DC_OA_ReceiveOfficialDocManagerIBLL dC_OA_ReceiveOfficialDocManagerIBLL = new DC_OA_ReceiveOfficialDocManagerBLL();
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
        public ActionResult Form()
        {
            return View();
        }
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
        [HttpGet]
        public ActionResult DealTable(string keyValue)
        {
            UserInfo user = LoginUserInfo.Get();
            var model = dC_OA_ReceiveOfficialDocManagerIBLL.GetDC_OA_ReceiveOfficialDocEntity(keyValue);
            ViewBag.code = model.F_FileCode.Replace("【", "〔").Replace("】", "〕").Replace("[", "〔").Replace("]", "〕");
            ViewBag.recivecode = model.F_ReceiveCode;
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
            if (user.departmentId == "7b463d09-530c-4d4c-9a72-d617daa25fd4")
            {
                ViewBag.maintitle1 = model.F_DocTemplate;
                ViewBag.maintitle2 = "市场开发部收文处理单";
                ViewBag.txt1 = "来文单位";
                ViewBag.txt2 = "市场开发部意见";
            }
            else
            {
                ViewBag.maintitle1 = model.F_DocTemplate;
                ViewBag.maintitle2 = "收文处理单";
                ViewBag.txt1 = "来文部室";
                ViewBag.txt2 = "拟办意见";
            }
            ViewBag.title = model.F_Title;
            ViewBag.department = model.F_SenderDepartment;
            ViewBag.printnum = model.F_PrintNum;
            if (model.F_ReceiveDate.HasValue)
            {
                ViewBag.time = model.F_ReceiveDate.Value.ToString("yyyy年MM月dd日");
            }
            else
            {
                ViewBag.time = "";
            }
            List<string> list = dC_OA_ReceiveOfficialDocManagerIBLL.GetAdviceByProcessId(model.F_RODId, Config.GetValue("fileSignatureImg"));
            ViewBag.advice1 = "";
            ViewBag.advice2 = "";
            ViewBag.advice3 = "";
            ViewBag.advice4 = "";
            ViewBag.advice5 = "";
            if (list.Count >= 5)
            {
                ViewBag.advice1 = list[0];
                ViewBag.advice2 = list[1];
                ViewBag.advice3 = list[2];
                ViewBag.advice4 = list[3];
                ViewBag.advice5 = list[4];
            }
            if (user.departmentId == "7b463d09-530c-4d4c-9a72-d617daa25fd4")
            {
                return View("DealTable1");
            }
            else
            {
                return View("DealTable");
            }
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
            var data = dC_OA_ReceiveOfficialDocManagerIBLL.GetPageList(paginationobj, queryJson);
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
            var data = dC_OA_ReceiveOfficialDocManagerIBLL.GetDealIndexPageList(paginationobj, queryJson);
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
            var DC_OA_ReceiveOfficialDocData = dC_OA_ReceiveOfficialDocManagerIBLL.GetDC_OA_ReceiveOfficialDocEntity(keyValue);
            var LR_NWF_TaskLogData = dC_OA_ReceiveOfficialDocManagerIBLL.GetLR_NWF_TaskLogList(DC_OA_ReceiveOfficialDocData.F_RODId);
            var jsonData = new
            {
                DC_OA_ReceiveOfficialDoc = DC_OA_ReceiveOfficialDocData,
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
            var DC_OA_ReceiveOfficialDocData = dC_OA_ReceiveOfficialDocManagerIBLL.GetEntityByProcessId(processId);
            IEnumerable<NWFTaskLogEntity> LR_NWF_TaskLogData = null;
            if (DC_OA_ReceiveOfficialDocData != null)
            {
                LR_NWF_TaskLogData = dC_OA_ReceiveOfficialDocManagerIBLL.GetLR_NWF_TaskLogList(DC_OA_ReceiveOfficialDocData.F_RODId);
            }
            var jsonData = new
            {
                DC_OA_ReceiveOfficialDoc = DC_OA_ReceiveOfficialDocData,
                LR_NWF_TaskLog = LR_NWF_TaskLogData,
            };
            return Success(jsonData);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataByProcessIdEnd(string processId)
        {
            var DC_OA_ReceiveOfficialDocData = dC_OA_ReceiveOfficialDocManagerIBLL.GetEntityByProcessId(processId);
            IEnumerable<NWFTaskLogEntity> LR_NWF_TaskLogData = null;
            if (DC_OA_ReceiveOfficialDocData != null)
            {
                LR_NWF_TaskLogData = dC_OA_ReceiveOfficialDocManagerIBLL.GetLR_NWF_TaskLogList(DC_OA_ReceiveOfficialDocData.F_RODId);
            }
            List<NWFTaskLogEntity> AskList = new List<NWFTaskLogEntity>();//拟办数据集
            List<NWFTaskLogEntity> DisList = new List<NWFTaskLogEntity>();//分发数据集
            List<NWFTaskLogEntity> DealList = new List<NWFTaskLogEntity>();//分发数据集
            List<NWFTaskLogEntity> AuditList = new List<NWFTaskLogEntity>();//批示数据集
            List<NWFTaskLogEntity> ReadList = new List<NWFTaskLogEntity>();//传阅数据集

            if (LR_NWF_TaskLogData != null)
            {
                foreach (NWFTaskLogEntity item in LR_NWF_TaskLogData)
                {
                    if (item.F_NodeName == "拟办")
                    {
                        AskList.Add(item);

                    }
                    else if (item.F_NodeName == "分发")
                    {
                        DisList.Add(item);

                    }
                    else if (item.F_NodeName == "处理")
                    {
                        DealList.Add(item);
                    }
                    else if (item.F_NodeName == "批示")
                    {
                        AuditList.Add(item);
                    }
                    else if (item.F_NodeName == "传阅")
                    {
                        ReadList.Add(item);
                    }


                }


            }

            var jsonData = new
            {
                DC_OA_ReceiveOfficialDoc = DC_OA_ReceiveOfficialDocData,
                LR_NWF_TaskLog = LR_NWF_TaskLogData,
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
            dC_OA_ReceiveOfficialDocManagerIBLL.DeleteEntity(keyValue);
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
            DC_OA_ReceiveOfficialDocEntity entity = strEntity.ToObject<DC_OA_ReceiveOfficialDocEntity>();
            List<NWFTaskLogEntity> lR_NWF_TaskLogList = strlR_NWF_TaskLogList.ToObject<List<NWFTaskLogEntity>>();
            dC_OA_ReceiveOfficialDocManagerIBLL.SaveEntity(keyValue, entity, lR_NWF_TaskLogList);
            if (string.IsNullOrEmpty(keyValue))
            {
                CodeRuleIBLL.UseRuleSeed("10001");
            }
            return Success("保存成功！");
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
                var dModel = dC_OA_ReceiveOfficialDocManagerIBLL.GetEntityByProcessId(keyValue);
                var fileList = annexesFileIBLL.GetList(dModel.F_Attachments);
                foreach (var item in fileList)
                {
                    var destName = item.F_FilePath.Replace(item.F_FileExtensions, "") + "_t" + item.F_FileExtensions;
                    //复制原本文件
                    item.F_FolderId = guid;
                    item.F_Id = item.F_Id + new Random().Next(0, 999);
                    System.IO.File.Copy(item.F_FilePath, destName, true);
                    item.F_FilePath = destName;
                    service.BaseRepository().Insert(item);
                }
            }
            var DC_OA_ArchivesData = dC_OA_ArchivesIBLL.GetDC_OA_ArchivesEntity(keyValue);
            var jsonData = new
            {
                DC_OA_Archives = DC_OA_ArchivesData,
            };
            return Success(jsonData);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult DoComplete(string keyValue, string strEntity)
        {
            dC_OA_ReceiveOfficialDocManagerIBLL.DoComplete(keyValue);
            DC_OA_ArchivesEntity entity = strEntity.ToObject<DC_OA_ArchivesEntity>();
            dC_OA_ArchivesIBLL.SaveEntity(keyValue, entity);
            return Success("归档成功！");
        }
        [HttpGet]
        public ActionResult GetProcessStep()
        {
            return Success(dC_OA_ReceiveOfficialDocManagerIBLL.GetProcessStep());
        }
        #endregion

    }
}
