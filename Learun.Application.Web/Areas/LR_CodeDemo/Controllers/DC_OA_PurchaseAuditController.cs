using Aspose.Words;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.WorkFlow;
using Learun.Util;
using System;
using System.Data;
using System.Threading;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-05 15:24
    /// 描 述：DC_OA_PurchaseAudit
    /// </summary>
    public class DC_OA_PurchaseAuditController : MvcControllerBase
    {
        private DC_OA_PurchaseAuditIBLL dC_OA_PurchaseAuditIBLL = new DC_OA_PurchaseAuditBLL();

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
        public ActionResult Form()
        {
             return View();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList( string queryJson )
        {
            var data = dC_OA_PurchaseAuditIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson,string isPower)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PurchaseAuditIBLL.GetPageList(paginationobj, queryJson,isPower);
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
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var data = dC_OA_PurchaseAuditIBLL.GetEntity(keyValue);
            return Success(data);
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
            dC_OA_PurchaseAuditIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue,DC_OA_PurchaseAuditEntity entity)
        {
            dC_OA_PurchaseAuditIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion
        public void OpenDoc(string keyValue)
        {
            DataTable dt = dC_OA_PurchaseAuditIBLL.GetEntityEx(keyValue);
            if (dt != null && dt.Rows.Count > 0)
            {
                string tempPath = Server.MapPath("~/Template/采购文件审核审批表.doc");
                string FilePath = Config.GetValue("AnnexesFile");
                string outputPath = FilePath + "/" + keyValue + "_审核单.doc";
                Utils.DeleteFile(FilePath + "/" + keyValue + "_审核单.doc");
                Utils.DeleteFile(FilePath + "/" + keyValue + "_审核单.pdf");
                //载入模板
                var doc = new Document(tempPath);
                String[] fieldNames = new String[] { "department","projectno","projectname","contract",
                    "tel","projectType","woodtype","money1","money2","money3","method","platform","proxy","advice1","advice2" };
                Object[] fieldValues = new Object[fieldNames.Length];
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    fieldValues[i] = dt.Columns.Contains(fieldNames[i]) ? (dt.Rows[0][fieldNames[i]] ?? "").ToString() : "";
                }
                NWFTaskIBLL bll = new NWFTaskBLL();
                fieldValues[fieldValues.Length - 2] = bll.GetTaskLogInfo(keyValue, 1);
                fieldValues[fieldValues.Length - 1] = bll.GetTaskLogInfo(keyValue, 2);
                ////合并模版，相当于页面的渲染
                doc.MailMerge.Execute(fieldNames, fieldValues);
                ////保存合并后的文档
                doc.Save(outputPath);
                Thread.Sleep(1);
                FileConvertoPdfUtil.PreviewFile(outputPath, "doc");
            }
        }
    }
}
