using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using Learun.Util.Excel;
using System.Linq;
namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 10:05
    /// 描 述：DC_ASSETS_BusStopBillboards
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsController : MvcControllerBase
    {
        private DC_ASSETS_BusStopBillboardsIBLL dC_ASSETS_BusStopBillboardsIBLL = new DC_ASSETS_BusStopBillboardsBLL();
        private CodeRuleIBLL iBll = new CodeRuleBLL();
       
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        #region 视图功能
        [HttpGet]
        public ActionResult MapForm()
        {
            return View();
        }
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

        [HttpGet]
        public ActionResult ExcelImport()
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
        public ActionResult GetPageList(string queryJson)
        {
            
            var data = dC_ASSETS_BusStopBillboardsIBLL.GetPageList(queryJson).OrderBy(i=>i.F_BillboardsName);
           
            return Success(data);
        }

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree()
        {
            var data = dC_ASSETS_BusStopBillboardsIBLL.GetTree();
            return Success(data);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_ASSETS_BusStopBillboardsData = dC_ASSETS_BusStopBillboardsIBLL.GetDC_ASSETS_BusStopBillboardsEntity(keyValue);
            var jsonData = new
            {
                DC_ASSETS_BusStopBillboards = DC_ASSETS_BusStopBillboardsData,
            };
            return Success(jsonData);
        }

        [HttpPost, ValidateInput(false)]
        public void ExportExcel(string queryJson, string fileName, string exportField, string columnJson)
        {
            //var dt = dC_ASSETS_LandBaseInfoIBLL.GetExportData(queryJson);

            //设置导出格式
            ExcelConfig excelconfig = new ExcelConfig();
            excelconfig.Title = Server.UrlDecode(fileName);
            excelconfig.TitleFont = "微软雅黑";
            excelconfig.TitlePoint = 15;
            excelconfig.FileName = Server.UrlDecode(fileName) + ".xls";
            excelconfig.IsAllSizeColumn = true;
            excelconfig.ColumnEntity = new List<ColumnModel>();
            //表头
            List<jfGridModel> columnList = columnJson.ToList<jfGridModel>();
            var dt = dC_ASSETS_BusStopBillboardsIBLL.ExportData(queryJson);
            //行数据
            // DataTable rowData = dataJson.ToTable();
            //写入Excel表头
            Dictionary<string, string> exportFieldMap = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(exportField))
            {
                string[] exportFields = exportField.Split(',');
                foreach (var field in exportFields)
                {
                    if (!exportFieldMap.ContainsKey(field))
                    {
                        exportFieldMap.Add(field, "1");
                    }
                }
            }

            foreach (jfGridModel columnModel in columnList)
            {
                if (exportFieldMap.ContainsKey(columnModel.name) || string.IsNullOrEmpty(exportField))
                {
                    excelconfig.ColumnEntity.Add(new ColumnModel()
                    {
                        Column = columnModel.name,
                        ExcelColumn = columnModel.label,
                        Alignment = columnModel.align,
                    });
                }
            }
            ExcelHelper.ExcelDownload(dt, excelconfig);
            // ExcelHelper.ExcelExport(dt,)

        }
        #endregion


        [HttpPost]
        [AjaxOnly]
        public ActionResult Import(string keyValue)
        {


            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);
            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "sheet2", true);
            dC_ASSETS_BusStopBillboardsIBLL.ImportEntity(dt);
            //dC_ASSETS_HouseInfoIBLL.UpdateComHouse();
            return Success("导入成功");
        }
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
            dC_ASSETS_BusStopBillboardsIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                iBll.UseRuleSeed("10014");
            }
            DC_ASSETS_BusStopBillboardsEntity entity = strEntity.ToObject<DC_ASSETS_BusStopBillboardsEntity>();
            dC_ASSETS_BusStopBillboardsIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

    }
}
