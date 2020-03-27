using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-14 16:09
    /// 描 述：DC_ASSETS_EquipmentPartsInto
    /// </summary>
    public class DC_ASSETS_EquipmentPartsIntoController : MvcControllerBase
    {
        private DC_ASSETS_EquipmentPartsIntoIBLL dC_ASSETS_EquipmentPartsIntoIBLL = new DC_ASSETS_EquipmentPartsIntoBLL();
        private CodeRuleIBLL iBll = new CodeRuleBLL();
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
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_EquipmentPartsIntoIBLL.GetPageList(paginationobj, queryJson);
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
            var dt = dC_ASSETS_EquipmentPartsIntoIBLL.ExportData(queryJson);
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
            var DC_ASSETS_EquipmentPartsIntoData = dC_ASSETS_EquipmentPartsIntoIBLL.GetDC_ASSETS_EquipmentPartsIntoEntity(keyValue);
            var DC_ASSETS_EquipmentPartsIntoDetailData = dC_ASSETS_EquipmentPartsIntoIBLL.GetDC_ASSETS_EquipmentPartsIntoDetailList(DC_ASSETS_EquipmentPartsIntoData.F_EPInId);
            var jsonData = new
            {
                DC_ASSETS_EquipmentPartsInto = DC_ASSETS_EquipmentPartsIntoData,
                DC_ASSETS_EquipmentPartsIntoDetail = DC_ASSETS_EquipmentPartsIntoDetailData,
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
            dC_ASSETS_EquipmentPartsIntoIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_ASSETS_EquipmentPartsIntoDetailList)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                iBll.UseRuleSeed("10017");
            }
            DC_ASSETS_EquipmentPartsIntoEntity entity = strEntity.ToObject<DC_ASSETS_EquipmentPartsIntoEntity>();
            List<DC_ASSETS_EquipmentPartsIntoDetailEntity> dC_ASSETS_EquipmentPartsIntoDetailList = strdC_ASSETS_EquipmentPartsIntoDetailList.ToObject<List<DC_ASSETS_EquipmentPartsIntoDetailEntity>>();
            dC_ASSETS_EquipmentPartsIntoIBLL.SaveEntity(keyValue, entity, dC_ASSETS_EquipmentPartsIntoDetailList);
            return Success("保存成功！");
        }
        #endregion


        [HttpGet]
        public ActionResult GetDetail(string keyValue)
        {
            return Success(dC_ASSETS_EquipmentPartsIntoIBLL.GetDetail(keyValue));
        }
    }
}
