using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-12 12:57
    /// 描 述：DC_OA_PerformanceUserWorkInterview
    /// </summary>
    public class DC_OA_PerformanceUserWorkInterviewController : MvcControllerBase
    {
        private DC_OA_PerformanceUserWorkInterviewIBLL dC_OA_PerformanceUserWorkInterviewIBLL = new DC_OA_PerformanceUserWorkInterviewBLL();

        #region 视图功能

        [HttpGet]
        //审核办意见
        public ActionResult AdviceForm()
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
        /// 表单页
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
        public ActionResult QueryIndex1()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index1()
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
            var data = dC_OA_PerformanceUserWorkInterviewIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_PerformanceUserWorkInterviewData = dC_OA_PerformanceUserWorkInterviewIBLL.GetDC_OA_PerformanceUserWorkInterviewEntity(keyValue);
            var jsonData = new
            {
                DC_OA_PerformanceUserWorkInterview = DC_OA_PerformanceUserWorkInterviewData,
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
            dC_OA_PerformanceUserWorkInterviewIBLL.DeleteEntity(keyValue);
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
            DC_OA_PerformanceUserWorkInterviewEntity entity = strEntity.ToObject<DC_OA_PerformanceUserWorkInterviewEntity>();
            dC_OA_PerformanceUserWorkInterviewIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion
        public ActionResult Execute(string cid, int r, string advice)
        {
            dC_OA_PerformanceUserWorkInterviewIBLL.Execute(cid, r, advice);
            return Success("保存成功！");
        }
    }
}
