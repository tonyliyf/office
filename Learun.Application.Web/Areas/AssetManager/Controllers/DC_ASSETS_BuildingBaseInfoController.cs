using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using Learun.Util.Excel;
using System.Web.Script.Serialization;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-13 15:11
    /// 描 述：DC_ASSETS_BuildingBaseInfo
    /// </summary>
    public class DC_ASSETS_BuildingBaseInfoController : MvcControllerBase
    {
        private DC_ASSETS_BuildingBaseInfoIBLL dC_ASSETS_BuildingBaseInfoIBLL = new DC_ASSETS_BuildingBaseInfoBLL();
        private CodeRuleIBLL iBll = new CodeRuleBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
        #region 视图功能
        [HttpGet]
        public ActionResult MapForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult IndexFox()
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
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index1()
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
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_BuildingBaseInfoIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            return Success(jsonData);
        }


        [HttpPost, ValidateInput(false)]
        public void ExportExcel(string queryJson, string fileName, string exportField, string columnJson)
        {
            //var dt = dC_ASSETS_LandBaseInfoIBLL.GetExportData(queryJson);
            //DataUtil util = new TwoDevelopment.SystemDemo.DataUtil();
            //util.InitGetData();
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
            var dt = dC_ASSETS_BuildingBaseInfoIBLL.ExportData(queryJson);
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
        public ActionResult GetTree(string keyValue)
        {
            var data = dC_ASSETS_BuildingBaseInfoIBLL.GetTree(keyValue);
            return Success(data);
        }

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTreeLandbase(string unit)
        {
            var data = dC_ASSETS_BuildingBaseInfoIBLL.GetTreeLandbase(unit);
            
            return Success(data);
        }
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult GetMapList(string Typecode,string Street,string pageSize, string index)
        {
           DataTable dt = dC_ASSETS_BuildingBaseInfoIBLL.GetMapList(Typecode, Street, pageSize, index);
            return Success(dt);

            //string Mapdata = dC_ASSETS_BuildingBaseInfoIBLL.GetMapList(Typecode, Street);

            // return Mapdata;
        }

        [HttpGet]
        public ActionResult GetStreet()
        {
            DataTable dt = dC_ASSETS_BuildingBaseInfoIBLL.GetStreet();
            return Success(dt);

        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfo(keyValue);
            var jsonData = new
            {
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
        public ActionResult GetFormDataForm(string keyValue)
        {
            var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfoEntity(keyValue);
            if (DC_ASSETS_BuildingBaseInfoData!=null) {

                DC_ASSETS_BuildingBaseInfoData.F_PictureAccessories_building = DC_ASSETS_BuildingBaseInfoData.F_PictureAccessories;
                DC_ASSETS_BuildingBaseInfoData.F_OtherAccessories_building = DC_ASSETS_BuildingBaseInfoData.F_OtherAccessories;
            }
                
            
            var jsonData = new
            {
                DC_ASSETS_BuildingBaseInfo = DC_ASSETS_BuildingBaseInfoData,
            };
            return Success(jsonData);
        }



        public ActionResult ExcelImport()
        {
            return View();
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
            dC_ASSETS_BuildingBaseInfoIBLL.DeleteEntity(keyValue);
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
                iBll.UseRuleSeed("10012");
            }
            DC_ASSETS_BuildingBaseInfoEntity entity = strEntity.ToObject<DC_ASSETS_BuildingBaseInfoEntity>();
            dC_ASSETS_BuildingBaseInfoIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }


        [HttpPost]
       [AjaxOnly]
        public ActionResult Import(string keyValue)
        {
            string aa = keyValue;
            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);

            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "sheet1", false);
            dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);
           // dC_ASSETS_BuildingBaseInfoIBLL.ImportEntity(dt);


            return Success("导入成功");
        }
        #endregion

    }
}
