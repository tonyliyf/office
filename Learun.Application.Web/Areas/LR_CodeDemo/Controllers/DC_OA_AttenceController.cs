using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架 
    /// Copyright (c) 2013-2018 信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-01-30 10:23 
    /// 描 述：DC_OA_Attence 
    /// </summary> 
    public class DC_OA_AttenceController : MvcControllerBase
    {
        private DC_OA_AttenceIBLL dC_OA_AttenceIBLL = new DC_OA_AttenceBLL();

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
        /// <param name = "queryJson" > 查询参数 </ param >
        /// < returns ></ returns >
        //[HttpGet]
        //[AjaxOnly]
        //public ActionResult GetPageList(string queryJson)
        //{
        //    if (string.IsNullOrEmpty(queryJson))
        //    {
        //        return Success(null);
        //    }
        //    var data = dC_OA_AttenceIBLL.GetPageList(queryJson);
        //    var jsonData = new
        //    {
        //        rows = data,
        //    };
        //    return Success(jsonData);
        //}


        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson,string isPower)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            paginationobj.rows = 25;
            if((string.IsNullOrEmpty(queryJson)||queryJson=="{}")&& isPower.IsEmpty())
            {
                return Success(null);
            }
            var data = dC_OA_AttenceIBLL.GetPageList(paginationobj, queryJson,isPower);
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
        public ActionResult GetAttenceRecord(string month,string userid)
        {

            if (string.IsNullOrEmpty(userid))
            {
                UserInfo user = LoginUserInfo.Get();
                userid = user.userId;
            }
            DataTable dt = dC_OA_AttenceIBLL.GetAttenceRocord(month, userid);
           
            return Success(dt);


          

          
        }


        string GetType(string info)
        {
            string types = "0";
            if (info.Contains("请假"))
            {
                types = "1";
            }
            else if (info.Contains("出差"))
            {
                types = "2";
            }
            else if (info.Contains("加班"))
            {
                types = "3";
            }

            return types;

        }


        [HttpPost, ValidateInput(false)]
        public void ExportExcel(string fileName, string columnJson,  string exportField,string queryJson)
        {
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
            DataTable dt = dC_OA_AttenceIBLL.GetDataSource(queryJson);
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
        }
        /// <summary> 
        /// 获取表单数据 
        /// <summary> 
        /// <returns></returns> 
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_AttenceData = dC_OA_AttenceIBLL.GetDC_OA_AttenceEntity(keyValue);
            var jsonData = new
            {
                DC_OA_Attence = DC_OA_AttenceData,
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
            var data = dC_OA_AttenceIBLL.GetTree();
            return Success(data);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Create()
        {
            int year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            DateTime dtStart = new DateTime(year, Month - 1, 1);
            DateTime dtEnd = new DateTime(year, Month, 1);

            if (dC_OA_AttenceIBLL.InsertDC_OA_AttenceByMonth(dtStart, dtEnd))
            {
                return Success("生成成功！");
            }
            return Fail("生成失败");
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
            dC_OA_AttenceIBLL.DeleteEntity(keyValue);
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
            DC_OA_AttenceEntity entity = strEntity.ToObject<DC_OA_AttenceEntity>();
            dC_OA_AttenceIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

    }
}
