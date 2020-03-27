using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 12:10
    /// 描 述：DC_OA_PerformanceExecute
    /// </summary>
    public class DC_OA_PerformanceExecuteController : MvcControllerBase
    {
        private DC_OA_PerformanceExecuteIBLL dC_OA_PerformanceExecuteIBLL = new DC_OA_PerformanceExecuteBLL();
        private DC_OA_PerformanceUserWorkIBLL dC_OA_PerformanceUserWorkIBLL = new DC_OA_PerformanceUserWorkBLL();
        private DC_OA_PerformanceUserWorkPlanIBLL dC_OA_PerformanceUserWorkPlanIBLL = new DC_OA_PerformanceUserWorkPlanBLL();

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
        public ActionResult Info()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdviceForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Evaluate1Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Evaluate2Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Evaluate3Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Evaluate1Form()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Evaluate2Form()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Evaluate3Form()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditTable1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditTable2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditTable3()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditTable4()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditInfoWnd(string keyValue)
        {
            var list = dC_OA_PerformanceExecuteIBLL.GetList(keyValue);
            return View(list);
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
            var data = dC_OA_PerformanceUserWorkIBLL.GetPageList(paginationobj, queryJson);
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
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetWorkPlanPageList(string keyValue)
        {
            var data = dC_OA_PerformanceUserWorkPlanIBLL.GetList(keyValue);
            return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetRows(string wid)
        {
            var data = dC_OA_PerformanceExecuteIBLL.GetRows(wid);
            return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetColumes(string wid)
        {
            var data = dC_OA_PerformanceExecuteIBLL.GetColumes(wid);
            return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetHeadData(string wid)
        {
            var data = dC_OA_PerformanceExecuteIBLL.GetHeadData(wid);
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
            var DC_OA_PerformanceExecuteData = dC_OA_PerformanceExecuteIBLL.GetDC_OA_PerformanceExecuteEntity(keyValue);
            var jsonData = new
            {
                DC_OA_PerformanceExecute = DC_OA_PerformanceExecuteData,
            };
            return Success(jsonData);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult IsLeaf(string wpid)
        {
            return Success(new { result = dC_OA_PerformanceExecuteIBLL.IsLeaf(wpid) });
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
            dC_OA_PerformanceExecuteIBLL.DeleteEntity(keyValue);
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
            DC_OA_PerformanceExecuteEntity entity = strEntity.ToObject<DC_OA_PerformanceExecuteEntity>();
            dC_OA_PerformanceExecuteIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion
        /// <summary>
        /// 评估
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="text"></param>
        /// <param name="agree"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult Evaluate1(string wid, string text, int agree)
        {
            if (dC_OA_PerformanceUserWorkIBLL.Evaluate1(wid, text, agree))
            {
                return Success("操作成功");
            }
            else
            {
                return Fail("操作失败");
            }
        }
        /// <summary>
        /// 自评
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult Evaluate2(string wid)
        {
            if (dC_OA_PerformanceUserWorkIBLL.Evaluate2(wid))
            {
                return Success("操作成功");
            }
            else
            {
                return Fail("操作失败");
            }
        }
        /// <summary>
        /// 评价
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="text"></param>
        /// <param name="agree"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult Evaluate3(string wid)
        {
            if (dC_OA_PerformanceUserWorkIBLL.Evaluate3(wid))
            {
                return Success("操作成功");
            }
            else
            {
                return Fail("操作失败");
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="text"></param>
        /// <param name="agree"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult Evaluate4(string wid, string text, int agree, int? decScore, int? incScore, int? resultScore)
        {
            if (dC_OA_PerformanceUserWorkIBLL.Evaluate4(wid, text, agree, decScore, incScore, resultScore))
            {
                return Success("操作成功");
            }
            else
            {
                return Fail("操作失败");
            }
        }
    }
}
