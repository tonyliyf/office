using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Learun.Application.Base.SystemModule;
using Learun.Util.Excel;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 13:45
    /// 描 述：DC_ASSETS_HouseRentMain
    /// </summary>
    public class DC_ASSETS_HouseRentMainController : MvcControllerBase
    {
        private DC_ASSETS_HouseRentMainIBLL dC_ASSETS_HouseRentMainIBLL = new DC_ASSETS_HouseRentMainBLL();
        private DC_ASSETS_HouseInfoIBLL dc_houseBll = new DC_ASSETS_HouseInfoBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        private DC_ASSETS_HouseRentDetailIBLL dC_ASSETS_HouseRentDetailIBLL = new DC_ASSETS_HouseRentDetailBLL();
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
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form2()
        {
            return View();
        }

        public ActionResult ExcelImport()
        {
            return View();
        }

        public ActionResult ExcelImportPlan()
        {
            return View();
        }


        [HttpGet]
        public ActionResult IndexFox()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormFox()
        {
            return View();
        }

        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormInfo()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HouseRentReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ImageImport()
        {
            return View();
        }

     
        [HttpGet]
        public ActionResult SelectForm()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FormRent()
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
            var data = dC_ASSETS_HouseRentMainIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetHouseRentList(string queryJson)
        {
           
            var data = dc_houseBll.GetHouseRentInfoPageList(queryJson);
         
            return Success(data);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetHouseRentDetaiList(string strdC_ASSETS_HouseRentDetailList,string ids)
        {
            var data = dC_ASSETS_HouseRentDetailIBLL.GetRentList(ids);
            var temp = ids;
            List<DC_ASSETS_HouseRentDetailEntity> dC_ASSETS_HouseRentDetailList = strdC_ASSETS_HouseRentDetailList.ToObject<List<DC_ASSETS_HouseRentDetailEntity>>();
            // var data = dc_houseBll.GetHouseRentInfoPageList("");
            if (data != null)
            {
                foreach (var item in data)
                {
                    item.F_ConstructionName = item.F_Transferor;
                    item.F_HouseName = item.F_Location;
                    item.F_ConstructionArea = item.F_RentArea.ToString();
                    dC_ASSETS_HouseRentDetailList.Add(item);
                }

            }
            return Success(dC_ASSETS_HouseRentDetailList);
        }

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetMainData()
        {
            var data = dC_ASSETS_HouseRentMainIBLL.GetMainList().OrderByDescending(i => i.F_CreateDatetime);
            return Success(data);
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
            var dt = dC_ASSETS_HouseRentMainIBLL.ExportData(queryJson);
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
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_ASSETS_HouseRentMainData = dC_ASSETS_HouseRentMainIBLL.GetDC_ASSETS_HouseRentMainEntity(keyValue);
            var DC_ASSETS_HouseRentDetailData = dC_ASSETS_HouseRentMainIBLL.GetDC_ASSETS_HouseRentDetailList(DC_ASSETS_HouseRentMainData.F_HRMId);
            var jsonData = new
            {
                DC_ASSETS_HouseRentMain = DC_ASSETS_HouseRentMainData,
                DC_ASSETS_HouseRentDetail = DC_ASSETS_HouseRentDetailData,
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
            dC_ASSETS_HouseRentMainIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_ASSETS_HouseRentDetailList)
        {
            DC_ASSETS_HouseRentMainEntity entity = strEntity.ToObject<DC_ASSETS_HouseRentMainEntity>();
            List<DC_ASSETS_HouseRentDetailEntity> dC_ASSETS_HouseRentDetailList = strdC_ASSETS_HouseRentDetailList.ToObject<List<DC_ASSETS_HouseRentDetailEntity>>();
            dC_ASSETS_HouseRentMainIBLL.SaveEntity(keyValue, entity, dC_ASSETS_HouseRentDetailList);
            return Success("保存成功！");
        }


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm2(string keyValue, string strEntity)
        {
            DC_ASSETS_HouseRentMainEntity entity = strEntity.ToObject<DC_ASSETS_HouseRentMainEntity>();
          
            dC_ASSETS_HouseRentMainIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
      
        [AjaxOnly]
        public ActionResult SaveCopyForm(string ids)
        {
            var temp = ids;
           /// DC_ASSETS_HouseRentMainEntity entity = strEntity.ToObject<DC_ASSETS_HouseRentMainEntity>();

           // dC_ASSETS_HouseRentMainIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion
        [HttpGet]
        [AjaxOnly]
        public ActionResult StatisticsRentInfo()
        {
            return Success(dC_ASSETS_HouseRentMainIBLL.StatisticsRentInfo());
        }

        public ActionResult StatisticsRentEx()
        {
            var result = new DC_ASSETS_HouseRentIncomeBLL().StatisticsForEChart();
            var stateList = new List<string>();
            var categoryList = new List<string> { "房屋" };
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
            var result = new DC_ASSETS_HouseRentIncomeBLL().StatisticsForEChart().Where(c => c.type == "房屋");
            return Success(result);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Import(string keyValue)
        {
            string aa = keyValue;
            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);

            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "sheet1", false);
            string msg = string.Empty;
            if(dC_ASSETS_HouseRentMainIBLL.ImportRent(dt ,ref  msg))
            {
                return Success("导入成功");

            }
            else
            {

                return Fail(msg);
            }
           // dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);
            // dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);


            return Success("导入成功");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult ImportCeticate(string keyValue)
        {
            try
            {

                string FileDirectory = Config.GetValue("AppDownUrl");
                AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);
                string temp = entity.F_FileName.Replace(entity.F_FileExtensions, "");
                ZipHelper.UnGzipFile(entity.F_FilePath, FileDirectory);
                string Msg = string.Empty;

                dC_ASSETS_HouseRentMainIBLL.ImportCertiate(FileDirectory, temp, ref Msg);
              /// dC_ASSETS_HouseInfoIBLL.ImportCertiate(FileDirectory, ref Msg);
                if (Msg != string.Empty)
                {
                    return Fail(Msg);
                }
                else
                {
                    return Success("导入成功");
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult ImportPlan(string keyValue)
        {
            string aa = keyValue;
            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);

            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "", false);
            dC_ASSETS_HouseRentMainIBLL.ImportPlan(dt);
            // dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);
            // dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);


            return Success("导入成功");
        }


       
    }
}
