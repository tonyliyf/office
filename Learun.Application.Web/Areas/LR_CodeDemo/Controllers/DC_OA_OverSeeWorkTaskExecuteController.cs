using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:47
    /// 描 述：DC_OA_OverSeeWorkTaskExecute
    /// </summary>
    public class DC_OA_OverSeeWorkTaskExecuteController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkTaskExecuteIBLL dC_OA_OverSeeWorkTaskExecuteIBLL = new DC_OA_OverSeeWorkTaskExecuteBLL();

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
            var data = dC_OA_OverSeeWorkTaskExecuteIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetPageListEx(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_OverSeeWorkTaskExecuteIBLL.GetPageListEx(paginationobj, queryJson);
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
            var DC_OA_OverSeeWorkTaskSplitData = dC_OA_OverSeeWorkTaskExecuteIBLL.GetDC_OA_OverSeeWorkTaskSplitEntity(keyValue);
            var DC_OA_OverSeeWorkTaskExecuteData = dC_OA_OverSeeWorkTaskExecuteIBLL.GetDC_OA_OverSeeWorkTaskExecuteList(DC_OA_OverSeeWorkTaskSplitData.F_SecondId);
            var jsonData = new
            {
                DC_OA_OverSeeWorkTaskSplit = DC_OA_OverSeeWorkTaskSplitData,
                DC_OA_OverSeeWorkTaskExecute = DC_OA_OverSeeWorkTaskExecuteData,
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
            dC_OA_OverSeeWorkTaskExecuteIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteFormEx(string keyValue)
        {
            dC_OA_OverSeeWorkTaskExecuteIBLL.DeleteEntityEx(keyValue);
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
        public ActionResult SaveForm(string TID, string PID, string keyValue, string strEntity)
        {
            DC_OA_OverSeeWorkTaskSplitEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkTaskSplitEntity>();
            dC_OA_OverSeeWorkTaskExecuteIBLL.SaveEntity(TID, PID, keyValue, entity);
            return Success("保存成功！");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFormEx(string keyValue, string strEntity)
        {
            DC_OA_OverSeeWorkTaskExecuteEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkTaskExecuteEntity>();
            dC_OA_OverSeeWorkTaskExecuteIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataEx(string keyValue)
        {
            var DC_OA_OverSeeWorkTaskExecuteData = dC_OA_OverSeeWorkTaskExecuteIBLL.GetDC_OA_OverSeeWorkTaskExecuteEntity(keyValue);
            var jsonData = new
            {
                DC_OA_OverSeeWorkTaskExecute = DC_OA_OverSeeWorkTaskExecuteData,
            };
            return Success(jsonData);
        }
        #endregion

    }
}
