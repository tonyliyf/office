using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.ProjectManager;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Learun.Application.Web.Areas.ProjectManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 13:57
    /// 描 述：DC_EngineProject_ProjectInfo
    /// </summary>
    public class DC_EngineProject_ProjectInfoController : MvcControllerBase
    {
        private DC_EngineProject_ProjectInfoIBLL dC_EngineProject_ProjectInfoIBLL = new DC_EngineProject_ProjectInfoBLL();

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
        public ActionResult MapForm()
        {
            return View();
        }
        /// <summary>
        /// 查看页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form1()
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
        public ActionResult ProjectInfoReport()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProjectInfoCategoryReport()
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
            var dt = dC_EngineProject_ProjectInfoIBLL.ExportData(queryJson);
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
        public void ExportExcel1(string queryJson, string fileName, string exportField, string columnJson)
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
            var dt = dC_EngineProject_ProjectInfoIBLL.ExportData1(queryJson);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_EngineProject_ProjectInfoIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_EngineProject_ProjectInfoData = dC_EngineProject_ProjectInfoIBLL.GetDC_EngineProject_ProjectInfoEntity(keyValue);
            var jsonData = new
            {
                DC_EngineProject_ProjectInfo = DC_EngineProject_ProjectInfoData,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree()
        {
            var data = dC_EngineProject_ProjectInfoIBLL.GetTree();
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
            dC_EngineProject_ProjectInfoIBLL.DeleteEntity(keyValue);
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
            if (strEntity == "")
            {
                return Success("退出");
            }
            else {
                DC_EngineProject_ProjectInfoEntity entity = strEntity.ToObject<DC_EngineProject_ProjectInfoEntity>();
                dC_EngineProject_ProjectInfoIBLL.SaveEntity(keyValue, entity);
                return Success("保存成功！");
            }
           
        }
       
        /// <summary>
        /// 保存实体数据（办结）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [AjaxOnly]
        public ActionResult UpdeteEntity(string keyValue)
        {
            dC_EngineProject_ProjectInfoIBLL.UpdeteEntity(keyValue);
            return Success("办结成功！");
        }

        public ActionResult UpdeteEntity1()
        {
            return Success("已办结项目不可编辑！");
        }
        #endregion
        public ActionResult StatisticsProjectInfo(DateTime startDate, DateTime endDate)
        {
            return Success(dC_EngineProject_ProjectInfoIBLL.StatisticsProjectInfo(startDate, endDate));
        }
        public ActionResult StatisticsProjectInfoByCategory(DateTime startDate, DateTime endDate)
        {
            return Success(dC_EngineProject_ProjectInfoIBLL.StatisticsProjectInfoByCategory(startDate, endDate));
        }
        public ActionResult StatisticsProjectInfoByCategoryEx(DateTime startDate, DateTime endDate)
        {
            var result = dC_EngineProject_ProjectInfoIBLL.StatisticsProjectInfoByCategory(startDate, endDate);
            var categoryList = result.AsEnumerable().Select(c => c["company"].ToString()).Distinct().OrderBy(c => c);
            var stateList = result.AsEnumerable().Select(c => c["state"].ToString()).Distinct().OrderBy(c => c);
            Dictionary<string, List<int>> SeriesData = new Dictionary<string, List<int>>();
            foreach (var str in categoryList)
            {
                List<int> data = new List<int>();
                foreach (var str1 in stateList)
                {
                    var tempresult = result.AsEnumerable().FirstOrDefault(c => c["state"].ToString() == str1 && c["company"].ToString() == str);
                    if (tempresult == null)
                    {
                        data.Add(0);
                    }
                    else
                    {
                        data.Add(Convert.ToInt32(tempresult["count"]));
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

        #region 门户数据


        #endregion 
    }
}
