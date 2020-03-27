using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.ProjectManager;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.ProjectManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-15 15:20
    /// 描 述：DC_EngineProject_ProjectInfoContract
    /// </summary>
    public class DC_EngineProject_ProjectInfoContractController : MvcControllerBase
    {
        private DC_EngineProject_ProjectInfoContractIBLL dC_EngineProject_ProjectInfoContractIBLL = new DC_EngineProject_ProjectInfoContractBLL();
        private DC_EngineProject_ProjectInfoApprovalDataIBLL dataIBll = new DC_EngineProject_ProjectInfoApprovalDataBLL();

        #region 视图功能
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
        public ActionResult QueryIndex()
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
            var dt = dC_EngineProject_ProjectInfoContractIBLL.ExportData(queryJson);
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
            var data = dC_EngineProject_ProjectInfoContractIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetPageInfoList(string queryJson)
        {

            
            var data = dataIBll.GetPageInfoList(queryJson);
            var jsonData = new
            {
                rows = data,
               
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
            var DC_EngineProject_ProjectInfoContractData = dC_EngineProject_ProjectInfoContractIBLL.GetDC_EngineProject_ProjectInfoContractEntity( keyValue );
            var jsonData = new {
                DC_EngineProject_ProjectInfoContract = DC_EngineProject_ProjectInfoContractData,
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
            dC_EngineProject_ProjectInfoContractIBLL.DeleteEntity(keyValue);
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
                DC_EngineProject_ProjectInfoContractEntity entity = strEntity.ToObject<DC_EngineProject_ProjectInfoContractEntity>();
                dC_EngineProject_ProjectInfoContractIBLL.SaveEntity(keyValue, entity);
                return Success("保存成功！");
            }
           
        }
        #endregion

    }
}
