using Aspose.Words;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.WorkFlow;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-05 15:16
    /// 描 述：DC_OA_PurchaseReply
    /// </summary>
    public class DC_OA_PurchaseReplyController : MvcControllerBase
    {
        private DC_OA_PurchaseReplyIBLL dC_OA_PurchaseReplyIBLL = new DC_OA_PurchaseReplyBLL();
        private DC_OA_PurchaseAuditIBLL dc_oa_autditBll = new DC_OA_PurchaseAuditBLL();
        private DC_OA_PurchaseAuditResultIBLL resultBLL = new DC_OA_PurchaseAuditResultBLL();

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
        public ActionResult GetList(string queryJson)
        {
            var data = dC_OA_PurchaseReplyIBLL.GetList(queryJson);
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
            var data = dC_OA_PurchaseReplyIBLL.GetPageList(paginationobj, queryJson,isPower);
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
            var data = dC_OA_PurchaseReplyIBLL.GetEntity(keyValue);
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
            dC_OA_PurchaseReplyIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, DC_OA_PurchaseReplyEntity entity)
        {
            dC_OA_PurchaseReplyIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion


        public void OpenDoc(string keyValue)
        {
            DataTable dt = dC_OA_PurchaseReplyIBLL.GetEntityEx(keyValue);
            if (dt != null && dt.Rows.Count > 0)
            {
                string tempPath = Server.MapPath("~/Template/采购需求申请及审核审批表.doc");
                string FilePath = Config.GetValue("AnnexesFile");
                string outputPath = FilePath + "/" + keyValue + "_审批单.doc";
                Utils.DeleteFile(FilePath + "/" + keyValue + "_审批单.doc");
                Utils.DeleteFile(FilePath + "/" + keyValue + "_审批单.pdf");
                //载入模板
                var doc = new Document(tempPath);
                String[] fieldNames = new String[] { "department","replyno","projectno","projectname","contract",
                    "tel","projectType","woodtype","money","review","method","yesorno1","contentno","auditinfo","remark","platform","money1","advice1","advice2" };
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



        [HttpGet]
        public ActionResult GetPurchase()
        {
            UserInfo user = LoginUserInfo.Get();
            List<Hashtable> data = new List<Hashtable>();
            var purplay = dC_OA_PurchaseReplyIBLL.GetListbyUserid(user.userId);
            var audit = dc_oa_autditBll.GetListbyUserid(user.userId);
            var result = resultBLL.GetListbyUserid(user.userId);

            Hashtable ht = new Hashtable();
                       

            return Success(data);
        }
    }
}
