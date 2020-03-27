using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 14:32
    /// 描 述：DC_ASSETS_HouseRentDetail
    /// </summary>
    public class DC_ASSETS_HouseRentDetailController : MvcControllerBase
    {
        private DC_ASSETS_HouseRentDetailIBLL dC_ASSETS_HouseRentDetailIBLL = new DC_ASSETS_HouseRentDetailBLL();
        private DC_ASSETS_HouseInfoIBLL dC_ASSETS_HouseInfoIBLL = new DC_ASSETS_HouseInfoBLL();

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
        public ActionResult FormInfo()
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
            var data = dC_ASSETS_HouseRentDetailIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetRentPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            paginationobj.rows = 20;
            var data = dC_ASSETS_HouseRentDetailIBLL.GetRentPageList(paginationobj, queryJson);
            List<DC_ASSETS_HouseRentDetailEntity> list = new List<DC_ASSETS_HouseRentDetailEntity>();
            foreach(var item in data)
            {
                item.F_FormerUnit = dC_ASSETS_HouseInfoIBLL.GetOwnerByHouseId(item.F_HouseID);
                list.Add(item);
            }

            var queryParam = queryJson.ToJObject();
          
            if (!queryParam["F_Assignee"].IsEmpty())
            {
                var temp = list.Where(i => i.F_FormerUnit == queryParam["F_Assignee"].ToString());
                var jsonData = new
                {
                    rows = temp,
                    total = paginationobj.total,
                    page = paginationobj.page,
                    records = paginationobj.records
                };
                return Success(jsonData);
            }
            else
            {
                var jsonData = new
                {
                    rows = list,
                    total = paginationobj.total,
                    page = paginationobj.page,
                    records = paginationobj.records
                };
                return Success(jsonData);

            }
           
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
            var dt = dC_ASSETS_HouseRentDetailIBLL.ExportData(queryJson);
            jfGridModel columnModel1 = null;
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
            string[] temp1 = new string[] { "Renter", "phone", "F_DoThings", "Area", "ContractNo" ,"starttime", "age", "price", "Deposit", "F_Manager", "marks" };
            string[] temp2 = new string[] { "承租人", "电话","从事业务","租借面积", "合同号","开始租期","租期年限", "年租金", "押金","负责人","备注" };
            for(int i=0;i<temp1.Length;i++)
            {
                columnModel1 = new jfGridModel();
                columnModel1.name = temp1[i];
                columnModel1.label = temp2[i];
                columnList.Add(columnModel1);

            }
            foreach (jfGridModel columnModel in columnList)
            {
                if (exportFieldMap.ContainsKey(columnModel.name) || string.IsNullOrEmpty(exportField))
                {
                    if (columnModel1.label == "租金信息") continue;
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
           
            var DC_ASSETS_HouseRentDetailData = dC_ASSETS_HouseRentDetailIBLL.GetHouseRentDetailEntity(keyValue);
            var DC_ASSETS_HouseRentDetailData_infoData = dC_ASSETS_HouseRentDetailIBLL.GetDC_ASSETS_HouseRentDetailInfoList(keyValue);
            var jsonData = new
            {
                DC_ASSETS_HouseRentDetail = DC_ASSETS_HouseRentDetailData,
                DC_ASSETS_HouseRentDetail_Info = DC_ASSETS_HouseRentDetailData_infoData
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormNewData(string keyValue)
        {

            var DC_ASSETS_HouseRentDetailData = dC_ASSETS_HouseRentDetailIBLL.GetHouseRentDetail(keyValue);
            IEnumerable<DC_ASSETS_HouseRentDetail_InfoEntity> DC_ASSETS_HouseRentDetailData_infoData = null;
            if (DC_ASSETS_HouseRentDetailData != null) {
                 DC_ASSETS_HouseRentDetailData_infoData = dC_ASSETS_HouseRentDetailIBLL.GetDC_ASSETS_HouseRentDetailInfoList(DC_ASSETS_HouseRentDetailData.F_HRDId);
            }
        
            var jsonData = new
            {
                DC_ASSETS_HouseRentDetail = DC_ASSETS_HouseRentDetailData,
                DC_ASSETS_HouseRentDetail_Info = DC_ASSETS_HouseRentDetailData_infoData
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataByHouseId (string keyValue)
        {


            //var DC_ASSETS_HouseRentDetailData = dC_ASSETS_HouseRentDetailIBLL.GetDC_ASSETS_HouseRentDetailEntityByHouseId(keyValue);
            //if (DC_ASSETS_HouseRentDetailData != null)
            //{
            //    var DC_ASSETS_HouseRentDetailData_infoData = dC_ASSETS_HouseRentDetailIBLL.GetDC_ASSETS_HouseRentDetailInfoList(DC_ASSETS_HouseRentDetailData.F_HRDId);
            //    var jsonData = new
            //    {
            //        DC_ASSETS_HouseRentDetail = DC_ASSETS_HouseRentDetailData,
            //        DC_ASSETS_HouseRentDetail_Info = DC_ASSETS_HouseRentDetailData_infoData
            //    };
            //    return Success(jsonData);
            //}
            //else
            //{
            //    var jsonData = new
            //    {
            //        DC_ASSETS_HouseRentDetail = DC_ASSETS_HouseRentDetailData,

            //    };
            //    return Success(jsonData);

            //}
            return null;
           
        }


        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetHouseRentDetail(string keyValue)
        {
            var DC_ASSETS_HouseRentDetailData = dC_ASSETS_HouseRentDetailIBLL.GetDC_ASSETS_HouseRentDetailEntity(keyValue);
            var jsonData = new
            {
                DC_ASSETS_HouseRentDetail = DC_ASSETS_HouseRentDetailData,
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
            var data = dC_ASSETS_HouseRentDetailIBLL.GetTree();
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
            dC_ASSETS_HouseRentDetailIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_ASSETS_HouseRentDetailInfoList)
        {
            DC_ASSETS_HouseRentDetailEntity entity = strEntity.ToObject<DC_ASSETS_HouseRentDetailEntity>();
            List<DC_ASSETS_HouseRentDetail_InfoEntity> dC_ASSETS_HouseRentDetailList = strdC_ASSETS_HouseRentDetailInfoList.ToObject<List<DC_ASSETS_HouseRentDetail_InfoEntity>>();
            dC_ASSETS_HouseRentDetailIBLL.SaveEntity(keyValue, entity, dC_ASSETS_HouseRentDetailList);
            return Success("保存成功！");
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetMinRentPrice(string keyValue)
        {
            return Success(new { result = dC_ASSETS_HouseRentDetailIBLL.GetMinRentPrice(keyValue) });
        }
        #endregion

    }
}
