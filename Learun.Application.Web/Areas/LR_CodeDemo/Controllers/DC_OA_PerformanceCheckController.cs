using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-29 15:44
    /// 描 述：DC_OA_PerformanceCheck
    /// </summary>
    public class DC_OA_PerformanceCheckController : MvcControllerBase
    {
        private DC_OA_PerformanceCheckIBLL dC_OA_PerformanceCheckIBLL = new DC_OA_PerformanceCheckBLL();

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
        public ActionResult Index1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form(int type)//1年度 2月度 
        {
            UserInfo user = LoginUserInfo.Get();
            ViewBag.name = user.realName;
            var template = dC_OA_PerformanceCheckIBLL.GetTemplateEntity(type);
            if (template == null)
            {
                ViewBag.templateid = "";
                if (type == 1)
                {
                    return View("Form1");
                }
                else
                {
                    return View("Form2");
                }
            }
            else
            {
                ViewBag.templateid = template.F_TemplateId;
                switch (template.F_Path)
                {
                    case "员工月度考核模板": return View("Form2");
                    case "员工年度考核模板": return View("Form1");
                    case "部室负责人月度考核模板": return View("Form3");
                    case "部室负责人年度考核模板": return View("Form4");
                    case "班子成员月度考核模板": return View("Form5");
                    case "班子成员年度考核模板": return View("Form6");
                    default:
                        break;
                }
            }
            return View("Form1");
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
        public ActionResult Form5()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form6()
        {
            return View();
        }
        [HttpGet]
        public ActionResult baobiao()
        {
            return View();
        }
        [HttpGet]
        public ActionResult baobiao4()
        {
            return View();
        }
        #endregion

        public ActionResult baobiao4x()
        {
            return View();
        }
        public ActionResult baobiao4xForm()
        {
            return View();
        }
        public ActionResult baobiao4z()
        {
            return View();
        }
        public ActionResult baobiao4zForm()
        {
            return View();
        }
        public ActionResult baobiao4gForm()
        {
            return View();
        }
        public ActionResult baobiao4g()
        {
            return View();
        }
     
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
            var data = dC_OA_PerformanceCheckIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetPageList7(string pagination, string queryJson)
        {  

            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList7(paginationobj, queryJson);
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
        public ActionResult GetPageList8(string pagination, string queryJson)
        {

            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList8(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        public void ExportExcel(string fileName, string columnJson, string exportField, string queryJson)
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
            DataTable dt = dC_OA_PerformanceCheckIBLL.GetPageList2(queryJson);
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

        public void ExportExcel1(string fileName, string columnJson, string exportField, string queryJson)
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
            DataTable dt = dC_OA_PerformanceCheckIBLL.GetPageList12(queryJson);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList1(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList1(paginationobj, queryJson);

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
        public ActionResult GetPageList3(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList3(paginationobj, queryJson);

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
        public ActionResult GetPageList4(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList4(paginationobj, queryJson);

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
        public ActionResult GetPageList5(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList5(paginationobj, queryJson);

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
        public ActionResult GetPageList6(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_PerformanceCheckIBLL.GetPageList6(paginationobj, queryJson);

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
            var DC_OA_PerformanceCheckData = dC_OA_PerformanceCheckIBLL.GetDC_OA_PerformanceCheckEntity(keyValue);

            //扣分合计
            DC_OA_PerformanceCheckData.F_KofenNum =(100- Convert.ToInt32(DC_OA_PerformanceCheckData.F_CheckNumber))+ Convert.ToInt32(DC_OA_PerformanceCheckData.F_JixaoNumber);

            //上级领导扣分
            DC_OA_PerformanceCheckData.F_CheckNumber = (100 - Convert.ToInt32(DC_OA_PerformanceCheckData.F_CheckNumber));

            //加分合计
            DC_OA_PerformanceCheckData.F_JiafenNum = (Convert.ToInt32(DC_OA_PerformanceCheckData.F_BaseNumber) + Convert.ToInt32(DC_OA_PerformanceCheckData.F_AddNumber)) - Convert.ToInt32(DC_OA_PerformanceCheckData.F_KofenNum);

            //得分F_deriveNum

            var jsonData = new
            {
                DC_OA_PerformanceCheck = DC_OA_PerformanceCheckData,
            };
   

            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataZ(string keyValue)
        {
            var DC_OA_PerformanceCheckData = dC_OA_PerformanceCheckIBLL.GetDC_OA_PerformanceCheckEntity(keyValue);

            //扣分合计
            DC_OA_PerformanceCheckData.F_KofenNum =(100- Convert.ToInt32(DC_OA_PerformanceCheckData.F_CheckNumber)) + Convert.ToInt32(DC_OA_PerformanceCheckData.F_JixaoNumber);

            //上级领导扣分
            DC_OA_PerformanceCheckData.F_CheckNumber = (100 - Convert.ToInt32(DC_OA_PerformanceCheckData.F_CheckNumber));

            //得分
            DC_OA_PerformanceCheckData.F_deriveNum = (Convert.ToInt32(DC_OA_PerformanceCheckData.F_BaseNumber) + Convert.ToInt32(DC_OA_PerformanceCheckData.F_AddNumber)) - Convert.ToInt32(DC_OA_PerformanceCheckData.F_KofenNum);

            //加分合计
            DC_OA_PerformanceCheckData.F_JiafenNum = (Convert.ToInt32(DC_OA_PerformanceCheckData.F_BaseNumber) + Convert.ToInt32(DC_OA_PerformanceCheckData.F_AddNumber)+Convert.ToInt32(DC_OA_PerformanceCheckData.F_GeneralManagerScore)+Convert.ToInt32(DC_OA_PerformanceCheckData.F_ChairmanScore)) - Convert.ToInt32(DC_OA_PerformanceCheckData.F_KofenNum);
            var jsonData = new
            {
                DC_OA_PerformanceCheck = DC_OA_PerformanceCheckData,
            };


            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataG(string keyValue)
        {
            var obj = dC_OA_PerformanceCheckIBLL.GetDC_OA_PerformanceCheckEntity(keyValue);

            //扣分合计
            obj.F_KofenNum =(100- Convert.ToInt32(obj.F_CheckNumber)) + Convert.ToInt32(obj.F_JixaoNumber) + Convert.ToInt32(obj.F_manageComments) + Convert.ToInt32(obj.F_GeneralNumber) + Convert.ToInt32(obj.F_ChairmanNumber);

            //上级领导扣分
            obj.F_CheckNumber = (100 - Convert.ToInt32(obj.F_CheckNumber));

            //合计得分
            obj.F_JiafenNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber)) - Convert.ToInt32(obj.F_KofenNum);
            var jsonData = new
            {
                DC_OA_PerformanceCheck = obj,
            };

            return Success(jsonData);
        }

        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataH(string keyValue)
        {
            var obj = dC_OA_PerformanceCheckIBLL.GetPageListH(keyValue);

            DC_OA_PerformanceCheckEntity num1 = new DC_OA_PerformanceCheckEntity();

            foreach (DC_OA_PerformanceCheckEntity num  in obj) {

                num1.F_CheckUserid = num.F_CheckUserid;
                num1.F_CheckUserDeptId = num.F_CheckUserDeptId;

            }


            var jsonData = new
            {
                DC_OA_PerformanceCheck = obj,
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
            var data = dC_OA_PerformanceCheckIBLL.GetTree();
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
            dC_OA_PerformanceCheckIBLL.DeleteEntity(keyValue);
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
            UserInfo userinfo = LoginUserInfo.Get();
            DC_OA_PerformanceCheckEntity entity = strEntity.ToObject<DC_OA_PerformanceCheckEntity>();
            entity.F_CheckUserDeptId = userinfo.departmentId;
            entity.F_CheckUserCompayId = userinfo.companyId;
            dC_OA_PerformanceCheckIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFormEx(string keyValue, string strEntity)
        {
            UserInfo userinfo = LoginUserInfo.Get();
            DC_OA_PerformanceCheckEntity entity = strEntity.ToObject<DC_OA_PerformanceCheckEntity>();
            entity.F_CheckUserDeptId = userinfo.departmentId;
            entity.F_CheckUserCompayId = userinfo.companyId;
            if (dC_OA_PerformanceCheckIBLL.SaveEntityEx(keyValue, entity))
            {
                return Success("保存成功！");
            }
            else
            {
                return Fail("操作失败");
            }
        }
        #endregion

        public ActionResult Commit(string keyValue, string checkerId)
        {
            if (dC_OA_PerformanceCheckIBLL.Commit(keyValue, checkerId))
            {
                return Success("操作成功");
            }
            else
            {
                return Fail("发起失败");
            }
        }
    }
}
