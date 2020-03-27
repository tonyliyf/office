using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading;
using Aspose.Words;
using System;
using Aspose.Words.Tables;
using Learun.Application.WorkFlow;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-06 16:45
    /// 描 述：DC_OA_PurchaseDeposit
    /// </summary>
    public class DC_OA_PurchaseDepositController : MvcControllerBase
    {
        private DC_OA_PurchaseDepositIBLL dC_OA_PurchaseDepositIBLL = new DC_OA_PurchaseDepositBLL();

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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson,string isPower)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PurchaseDepositIBLL.GetPageList(paginationobj, queryJson,isPower);
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
            var DC_OA_PurchaseDepositData = dC_OA_PurchaseDepositIBLL.GetDC_OA_PurchaseDepositEntity(keyValue);
            var DC_OA_PurchaseDepositDetailData = dC_OA_PurchaseDepositIBLL.GetDC_OA_PurchaseDepositDetailList(DC_OA_PurchaseDepositData.F_PurchaseDepositId);
            var jsonData = new
            {
                DC_OA_PurchaseDeposit = DC_OA_PurchaseDepositData,
                DC_OA_PurchaseDepositDetail = DC_OA_PurchaseDepositDetailData,
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
            dC_OA_PurchaseDepositIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_PurchaseDepositDetailList)
        {
            DC_OA_PurchaseDepositEntity entity = strEntity.ToObject<DC_OA_PurchaseDepositEntity>();
            List<DC_OA_PurchaseDepositDetailEntity> dC_OA_PurchaseDepositDetailList = strdC_OA_PurchaseDepositDetailList.ToObject<List<DC_OA_PurchaseDepositDetailEntity>>();
            dC_OA_PurchaseDepositIBLL.SaveEntity(keyValue, entity, dC_OA_PurchaseDepositDetailList);
            return Success("保存成功！");
        }
        #endregion


        public void OpenDoc(string keyValue)
        {
            const int COPY_ROW_NUM = 3;//列头行索引  0开始数
            DataTable dt = dC_OA_PurchaseDepositIBLL.GetEntityEx(keyValue);
            if (dt != null && dt.Rows.Count > 0)
            {
                string tempPath = Server.MapPath("~/Template/采购保证金退还表.doc");
                string FilePath = Config.GetValue("AnnexesFile");
                string outputPath = FilePath + "/" + keyValue + "_退还单.doc";
                Utils.DeleteFile(FilePath + "/" + keyValue + "_退还单.doc");
                Utils.DeleteFile(FilePath + "/" + keyValue + "_退还单.pdf");
                //载入模板
                var doc = new Document(tempPath);
                DataTable dt1 = dC_OA_PurchaseDepositIBLL.GetListEntityEx(keyValue);
                if (dt1.Rows.Count > 0)
                {
                    NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true); //拿到所有表格
                    Aspose.Words.Tables.Table table = allTables[0] as Aspose.Words.Tables.Table;
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            var row = table.Rows[COPY_ROW_NUM];
                            row.Cells[1].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["name"] ?? "").ToString();
                            row.Cells[2].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["money"] ?? "").ToString();
                            row.Cells[3].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["yesorno"] ?? "").ToString();
                            row.Cells[4].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["reason"] ?? "").ToString();
                        }
                        else
                        {
                            var row = table.Rows[COPY_ROW_NUM].Clone(true) as Aspose.Words.Tables.Row;
                            row.Cells[1].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["name"] ?? "").ToString();
                            row.Cells[2].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["money"] ?? "").ToString();
                            row.Cells[3].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["yesorno"] ?? "").ToString();
                            row.Cells[4].Paragraphs[0].Runs[0].Text = (dt1.Rows[i]["reason"] ?? "").ToString();
                            table.Rows.Insert(COPY_ROW_NUM  + i, row);
                        }
                    }
                }
                String[] fieldNames = new String[] { "department", "projectno", "projectname", "money", "advice1", "advice2" };
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
                //保存合并后的文档
                doc.Save(outputPath);
                Thread.Sleep(1);
                FileConvertoPdfUtil.PreviewFile(outputPath, "doc");
            }
        }
    }
}
