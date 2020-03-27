using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using System;
using System.Linq;




namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 17:40
    /// 描 述：DC_ASSETS_HouseInfo
    /// </summary>
    public class DC_ASSETS_HouseInfoController : MvcControllerBase
    {
        private DC_ASSETS_HouseInfoIBLL dC_ASSETS_HouseInfoIBLL = new DC_ASSETS_HouseInfoBLL();
        private DC_ASSETS_BuildingBaseInfoIBLL dC_ASSETS_BuildingBaseInfoIBLL = new DC_ASSETS_BuildingBaseInfoBLL();
        private DC_ASSETS_LandBaseInfoIBLL dC_ASSETS_LandBaseInfoIBLL = new DC_ASSETS_LandBaseInfoBLL();
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
        [HttpGet]
        public ActionResult FormInfo()
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
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IndexLand()
        {
            return View();
        }

        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult IndexNoLand()
        {
            return View();
        }


        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CeticateImport()
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
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormLand()
        {
            return View();
        }

        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FormNOLand()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HouseInfoReport()
        {
            return View();
        }


        [HttpGet]
        public ActionResult HouseGisInfo()
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
            var dt = dC_ASSETS_HouseInfoIBLL.ExportData(queryJson);
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
        public void ExportHouseExcel(string queryJson, string fileName, string exportField, string columnJson)
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
            var dt = dC_ASSETS_HouseInfoIBLL.ExportHouseData(queryJson);
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



        [HttpPost, ValidateInput(false)]
        public void ExportLandHouseExcel(string queryJson, string fileName, string exportField, string columnJson)
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
            var dt = dC_ASSETS_HouseInfoIBLL.ExportLandHouseData(queryJson);
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
            ExcelHelper.ExcelDownload(dt, excelconfig, true);
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
            var data = dC_ASSETS_HouseInfoIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetTotalPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            paginationobj.rows = 20;
            var data = dC_ASSETS_HouseInfoIBLL.GetTotalPageList(paginationobj, queryJson);
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
        public ActionResult GetTotalNoLandPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            paginationobj.rows = 20;
            var data = dC_ASSETS_HouseInfoIBLL.GetTotalNoLandPageList(paginationobj, queryJson);
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
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree(string keyValue)
        {
            var data = dC_ASSETS_HouseInfoIBLL.GetTree(keyValue);
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
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfoIBLL.GetDC_ASSETS_HouseInfoEntity(keyValue);

            DC_ASSETS_HouseInfoEntity HouseInfo = DC_ASSETS_HouseInfoData;
            HouseInfo.F_UseCategories_build = DC_ASSETS_HouseInfoData.F_UseCategories;
            HouseInfo.F_RoomUsage_build = DC_ASSETS_HouseInfoData.F_RoomUsage;
            HouseInfo.F_PropertyOwner_build = DC_ASSETS_HouseInfoData.F_PropertyOwner;
            HouseInfo.F_PropertyOwnerCertificateType_build = DC_ASSETS_HouseInfoData.F_PropertyOwnerCertificateType;
            HouseInfo.F_UseStatus_build = DC_ASSETS_HouseInfoData.F_UseStatus;
            HouseInfo.F_RentPurpose_build = DC_ASSETS_HouseInfoData.F_RentPurpose;
            HouseInfo.F_IfUse_build = DC_ASSETS_HouseInfoData.F_IfUse;
            HouseInfo.F_PictureAccessories_build = DC_ASSETS_HouseInfoData.F_PictureAccessories;
            HouseInfo.F_RentCertificateNo_build = DC_ASSETS_HouseInfoData.F_RentCertificateNo;

            var jsonData = new
            {
                DC_ASSETS_HouseInfo = HouseInfo,
            };
            return Success(jsonData);
        }


        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetHouseInfoLandbase(string keyValue)
        {
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfoIBLL.GetHouseInfoLandbase(keyValue);
            var jsonData = new
            {
                DC_ASSETS_HouseInfo = DC_ASSETS_HouseInfoData,
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetHouseInfo(string keyValue)
        {
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfoIBLL.GetDC_ASSETS_HouseInfo(keyValue);
            var jsonData = new
            {
                DC_ASSETS_HouseInfo = DC_ASSETS_HouseInfoData,
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTotalHouseInfo(string keyValue)
        {
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfoIBLL.GetDC_ASSETS_HouseInfo(keyValue);
            DC_ASSETS_HouseInfoData.F_PictureAccessories_HouseInfo = DC_ASSETS_HouseInfoData.F_PictureAccessories;
            // Houseentity.F_PictureAccessories = Houseentity.F_PictureAccessories_HouseInfo;
            //  DC_ASSETS_HouseInfoData.F_Address+
            var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfo(DC_ASSETS_HouseInfoData.F_BBIId);
            var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfoEntity(DC_ASSETS_BuildingBaseInfoData.F_LBIId);
            var jsonData = new
            {
                DC_ASSETS_HouseInfo = DC_ASSETS_HouseInfoData,
                DC_ASSETS_BuildingBaseInfo = DC_ASSETS_BuildingBaseInfoData,
                DC_ASSETS_LandBaseInfo = DC_ASSETS_LandBaseInfoData
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTotalHouseNoLandInfo(string keyValue)
        {
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfoIBLL.GetDC_ASSETS_HouseInfo(keyValue);
            var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfo(DC_ASSETS_HouseInfoData.F_BBIId);

            var jsonData = new
            {
                DC_ASSETS_HouseInfo = DC_ASSETS_HouseInfoData,
                DC_ASSETS_BuildingBaseInfo = DC_ASSETS_BuildingBaseInfoData,

            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public void UpdateComHouse(string keyValue)
        {
            dC_ASSETS_HouseInfoIBLL.UpdateComHouse();

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
            dC_ASSETS_HouseInfoIBLL.DeleteEntity(keyValue);
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
                iBll.UseRuleSeed("10013");
            }
            DC_ASSETS_HouseInfoEntity entity = strEntity.ToObject<DC_ASSETS_HouseInfoEntity>();
            dC_ASSETS_HouseInfoIBLL.SaveEntity(keyValue, entity);
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
        public ActionResult SaveTotalForm(string keyValue, string strLandEntity, string strBuildingEntity, string strHouseEntity)
        {
            DC_ASSETS_LandBaseInfoEntity Landentity = strLandEntity.ToObject<DC_ASSETS_LandBaseInfoEntity>();
            DC_ASSETS_BuildingBaseInfoEntity Buildingentity = strBuildingEntity.ToObject<DC_ASSETS_BuildingBaseInfoEntity>();
            DC_ASSETS_HouseInfoEntity Houseentity = strHouseEntity.ToObject<DC_ASSETS_HouseInfoEntity>();
            Houseentity.F_PictureAccessories = Houseentity.F_PictureAccessories_HouseInfo;
            if (keyValue.Length > 0)
            {

                // Buildingentity.F_LBIId = Landentity.F_LBIId;
                // Houseentity.F_BBIId = Buildingentity.F_BBIId;
                //Landentity.F_LBIId = Buildingentity.F_LBIId;
                var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfoEntity(Landentity.F_LandName, Landentity.F_LandCertificate);
                if (DC_ASSETS_LandBaseInfoData != null)
                {
                    Landentity.F_LBIId = DC_ASSETS_LandBaseInfoData.F_LBIId;
                    Buildingentity.F_LBIId = Landentity.F_LBIId;
                }


            }
            else
            {
                if (string.IsNullOrEmpty(Buildingentity.F_LBIId))
                {
                    var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfoEntity(Landentity.F_LandName, Landentity.F_LandCertificate);
                    if (DC_ASSETS_LandBaseInfoData != null)
                    {
                        Landentity.F_LBIId = DC_ASSETS_LandBaseInfoData.F_LBIId;
                        Buildingentity.F_LBIId = Landentity.F_LBIId;
                    }
                }
                else
                {
                    Landentity.F_LBIId = Buildingentity.F_LBIId;
                    var DC_ASSETS_BuildingBaseInfoEntityData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfoEntity(Landentity.F_LBIId, Buildingentity.F_ConstructionName);
                    if (DC_ASSETS_BuildingBaseInfoEntityData != null)
                    {
                        Buildingentity.F_BBIId = DC_ASSETS_BuildingBaseInfoEntityData.F_BBIId;
                        Houseentity.F_BBIId = Buildingentity.F_BBIId;
                    }
                }

            }
            dC_ASSETS_HouseInfoIBLL.SaveTotalEntity(keyValue, Landentity, Buildingentity, Houseentity);
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
        public ActionResult SaveTotalFormNoLand(string keyValue, string strBuildingEntity, string strHouseEntity)
        {
            DC_ASSETS_BuildingBaseInfoEntity Buildingentity = strBuildingEntity.ToObject<DC_ASSETS_BuildingBaseInfoEntity>();
            DC_ASSETS_HouseInfoEntity Houseentity = strHouseEntity.ToObject<DC_ASSETS_HouseInfoEntity>();
            //  Houseentity.F_PictureAccessories = Houseentity.F_PictureAccessories_HouseInfo;
            if (keyValue.Length > 0)
            {

                Buildingentity.F_BBIId = Houseentity.F_BBIId;

            }
            else
            {
                if (string.IsNullOrEmpty(Houseentity.F_BBIId))
                {

                    var DC_ASSETS_BuildingBaseInfoEntityData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfo(Buildingentity.F_FormerUnit, Buildingentity.F_ConstructionName);
                    if (DC_ASSETS_BuildingBaseInfoEntityData != null)
                    {
                        Buildingentity.F_BBIId = DC_ASSETS_BuildingBaseInfoEntityData.F_BBIId;
                        Houseentity.F_BBIId = Buildingentity.F_BBIId;
                    }
                }



            }
            dC_ASSETS_HouseInfoIBLL.SaveTotalEntity(keyValue, Buildingentity, Houseentity);
            return Success("保存成功！");
        }

        [AjaxOnly]
        public ActionResult StatisticsHouseInfo(DateTime startDate, DateTime endDate)
        {
            return Success(dC_ASSETS_HouseInfoIBLL.StatisticsHouseInfo(startDate, endDate));
        }
        [AjaxOnly]
        public ActionResult StatisticsHouseInfoEx(DateTime startDate, DateTime endDate)
        {
            var result = dC_ASSETS_HouseInfoIBLL.StatisticsHouseInfoEx(startDate, endDate);
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


        [HttpPost]
        [AjaxOnly]
        public ActionResult ImportCeticate(string keyValue)
        {
            try
            {

                string FileDirectory = Config.GetValue("AppDownUrl");
                AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);
                ZipHelper.UnGzipFile(entity.F_FilePath, FileDirectory);
                string temp = entity.F_FileName.Replace(entity.F_FileExtensions, "");
                ZipHelper.UnGzipFile(entity.F_FilePath, FileDirectory);
                string Msg = string.Empty;
                dC_ASSETS_HouseInfoIBLL.ImportCertiate(FileDirectory,temp, ref Msg);
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
        #endregion

    }
}
