using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using Learun.Util.Excel;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-05-23 12:01
    /// 描 述：DC_ASSETS_LandHandUpInfo
    /// </summary>
    public class DC_ASSETS_LandHandUpInfoController : MvcControllerBase
    {
        private DC_ASSETS_LandHandUpInfoIBLL dC_ASSETS_LandHandUpInfoIBLL = new DC_ASSETS_LandHandUpInfoBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
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
        /// 地图页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MapForm()
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

        public ActionResult ExcelImport()
        {
            return View();
        }
        #endregion

        #region 获取数据
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
            var dt = dC_ASSETS_LandHandUpInfoIBLL.ExportData(queryJson);
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
                        Column = columnModel.name.ToLower(),
                        ExcelColumn = columnModel.label,
                        Alignment = columnModel.align,
                    });
                }
            }
            ExcelHelper.ExcelDownload(dt, excelconfig);
            // ExcelHelper.ExcelExport(dt,)

        }
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
            paginationobj.rows = 20;
            var data = dC_ASSETS_LandHandUpInfoIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_ASSETS_LandHandUpInfoData = dC_ASSETS_LandHandUpInfoIBLL.GetDC_ASSETS_LandHandUpInfoEntity( keyValue );
            var jsonData = new {
                DC_ASSETS_LandHandUpInfo = DC_ASSETS_LandHandUpInfoData,
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
            dC_ASSETS_LandHandUpInfoIBLL.DeleteEntity(keyValue);
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
            DC_ASSETS_LandHandUpInfoEntity entity = strEntity.ToObject<DC_ASSETS_LandHandUpInfoEntity>();
            dC_ASSETS_LandHandUpInfoIBLL.SaveEntity(keyValue,entity);
            return Success("保存成功！");
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult Import(string keyValue)
        {
            string aa = keyValue;
            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);

            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "sheet1", true);
            dC_ASSETS_LandHandUpInfoIBLL.ImportEntity(dt);
          //  dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);
            // dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);


            return Success("导入成功");
        }
        #endregion

    }
}
