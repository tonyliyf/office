using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-07 11:49
    /// 描 述：广告招租
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentMainController : MvcControllerBase
    {
        private DC_ASSETS_BusStopBillboardsRentMainIBLL dC_ASSETS_BusStopBillboardsRentMainIBLL = new DC_ASSETS_BusStopBillboardsRentMainBLL();
        private DC_ASSETS_HouseInfoIBLL dc_houseBll = new DC_ASSETS_HouseInfoBLL();

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
        [HttpGet]
        public ActionResult BoardRentReport()
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
            var data = dC_ASSETS_BusStopBillboardsRentMainIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
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
            var dt = dC_ASSETS_BusStopBillboardsRentMainIBLL.ExportData(queryJson);
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
        /// 获取广告牌维修显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList1(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_BusStopBillboardsRentMainIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_ASSETS_BusStopBillboardsRentMainData = dC_ASSETS_BusStopBillboardsRentMainIBLL.GetDC_ASSETS_BusStopBillboardsRentMainEntity(keyValue);
            var DC_ASSETS_BusStopBillboardsRentDetailData = dC_ASSETS_BusStopBillboardsRentMainIBLL.GetDC_ASSETS_BusStopBillboardsRentDetailList(DC_ASSETS_BusStopBillboardsRentMainData.F_BSBRMId);
            var jsonData = new
            {
                DC_ASSETS_BusStopBillboardsRentMain = DC_ASSETS_BusStopBillboardsRentMainData,
                DC_ASSETS_BusStopBillboardsRentDetail = DC_ASSETS_BusStopBillboardsRentDetailData,
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
            dC_ASSETS_BusStopBillboardsRentMainIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_ASSETS_BusStopBillboardsRentDetailList,string F_BSBId)
        {
            DC_ASSETS_BusStopBillboardsRentMainEntity entity = strEntity.ToObject<DC_ASSETS_BusStopBillboardsRentMainEntity>();
            List<DC_ASSETS_BusStopBillboardsRentDetailEntity> dC_ASSETS_BusStopBillboardsRentDetailList = strdC_ASSETS_BusStopBillboardsRentDetailList.ToObject<List<DC_ASSETS_BusStopBillboardsRentDetailEntity>>();
            //判断是否为新增
            if (F_BSBId!="") {
                dC_ASSETS_BusStopBillboardsRentDetailList[0].F_BSBId = F_BSBId;
            }
            dC_ASSETS_BusStopBillboardsRentMainIBLL.SaveEntity(keyValue, entity, dC_ASSETS_BusStopBillboardsRentDetailList);
            return Success("保存成功！");
        }
        #endregion
        public ActionResult StatisticsRentEx()
        {
            var result = new DC_ASSETS_HouseRentIncomeBLL().StatisticsForEChart();
            var stateList = new List<string>();
            var categoryList = new List<string> { "广告牌" };
            Dictionary<string, List<double>> SeriesData = new Dictionary<string, List<double>>();
            DateTime now = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                stateList.Add(now.AddMonths(0 - i).ToString("yyyyMM"));
            }
            foreach (var str in categoryList)
            {
                List<double> data = new List<double>();
                foreach (var str1 in stateList)
                {
                    var tempresult = result.FirstOrDefault(c => c.month == str1 && c.type == str);
                    if (tempresult == null)
                    {
                        data.Add(0);
                    }
                    else
                    {
                        data.Add(tempresult.money);
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
        public ActionResult StatisticsRent()
        {
            var result = new DC_ASSETS_HouseRentIncomeBLL().StatisticsForEChart().Where(c=>c.type=="广告牌");
            return Success(result);
        }
    }
}
