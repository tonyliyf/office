using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using Learun.Util.Excel;
using System;
using System.Linq;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 11:36
    /// 描 述：DC_ASSETS_LandBaseInfo
    /// </summary>
    public class DC_ASSETS_LandBaseInfoController : MvcControllerBase
    {
        private DC_ASSETS_LandBaseInfoIBLL dC_ASSETS_LandBaseInfoIBLL = new DC_ASSETS_LandBaseInfoBLL();
        private DC_ASSETS_HouseInfoIBLL dC_ASSETS_HouseInfoIBLL = new DC_ASSETS_HouseInfoBLL();
        private CodeRuleIBLL iBll = new CodeRuleBLL();
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
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IndexCom()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Index1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult QueryIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LandBaseContract()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LandBaseIdleFeesPayment()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LandBaseStartComplete()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ExcelImport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IndexNoLand()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IndexFox()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form3()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form4()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LandBaseMortgage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LandInfoReport()
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
        public ActionResult MapForm()
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
            var dt = dC_ASSETS_LandBaseInfoIBLL.ExportData(queryJson);
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

        [HttpPost, ValidateInput(false)]
        public void GetExportComLandbase(string queryJson, string fileName, string exportField, string columnJson)
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
            var dt = dC_ASSETS_LandBaseInfoIBLL.GetExportComLandbase();
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

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree(string unit)
        {
            var data = dC_ASSETS_LandBaseInfoIBLL.GetTree(unit);
            return Success(data);
        }


        /// <summary>
        /// 获取综合查询数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetComLandbase(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_LandBaseInfoIBLL.GetComLandbase(queryJson);

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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson,string type)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            paginationobj.rows = 20;
            var data = dC_ASSETS_LandBaseInfoIBLL.GetPageList(paginationobj, queryJson,type);
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
            var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfoEntity(keyValue);
            var jsonData = new
            {
                DC_ASSETS_LandBaseInfo = DC_ASSETS_LandBaseInfoData,
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
            dC_ASSETS_LandBaseInfoIBLL.DeleteEntity(keyValue);
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
                iBll.UseRuleSeed("10011");
            }
            DC_ASSETS_LandBaseInfoEntity entity = strEntity.ToObject<DC_ASSETS_LandBaseInfoEntity>();
            dC_ASSETS_LandBaseInfoIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

        [HttpGet]
        [AjaxOnly]
        public ActionResult StatisticsLandInfo()
        {
            return Success(dC_ASSETS_LandBaseInfoIBLL.StatisticsLandInfo());
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult Import(string keyValue)
        {


            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);
            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "金源房产土地2", true);
            //dC_ASSETS_LandBaseInfoIBLL.ImportEntity2NoBuilding(dt);
             dC_ASSETS_LandBaseInfoIBLL.ImportEntity(dt);
            //dC_ASSETS_HouseInfoIBLL.UpdateComHouse();
              return Success("导入成功");
        }

        public ActionResult StatisticsLandInfoByArea(DateTime startDate,DateTime endDate)
        {
            return Success(dC_ASSETS_LandBaseInfoIBLL.StatisticsLandInfoByArea(startDate,endDate));
        }
        public ActionResult StatisticsLandInfoByAreaEx(DateTime startDate, DateTime endDate)
        {
            var result = dC_ASSETS_LandBaseInfoIBLL.StatisticsLandInfoByAreaEx(startDate, endDate);
            var categoryList = result.AsEnumerable().Select(c => c["areaname"].ToString()).Distinct().OrderBy(c => c);
            var stateList = result.AsEnumerable().Select(c => c["type"].ToString()).Distinct().OrderBy(c => c);
            Dictionary<string, List<int>> SeriesData = new Dictionary<string, List<int>>();
            foreach (var str in categoryList)
            {
                List<int> data = new List<int>();
                foreach (var str1 in stateList)
                {
                    var tempresult = result.AsEnumerable().FirstOrDefault(c => c["type"].ToString() == str1 && c["areaname"].ToString() == str);
                    if (tempresult == null)
                    {
                        data.Add(0);
                    }
                    else
                    {
                        data.Add( Convert.ToInt32( tempresult["count"]));
                    }
                }
                SeriesData.Add(str, data);
            }
            return Json(new
            {
                categoryList = categoryList,
                SeriesData = SeriesData.OrderBy(c => c.Key),
                stateList = stateList
            });
        }
    }
}
