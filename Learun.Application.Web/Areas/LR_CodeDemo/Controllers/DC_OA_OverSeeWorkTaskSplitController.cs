using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.DataBase.Repository;
using Learun.Application.WorkFlow;
using System.Linq;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 17:28
    /// 描 述：DC_OA_OverSeeWorkTaskSplit
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkTaskSplitIBLL dC_OA_OverSeeWorkTaskSplitIBLL = new DC_OA_OverSeeWorkTaskSplitBLL();
        private DC_OA_OverSeeWorkClosingIBLL overSeekWorkClosingIBLL = new DC_OA_OverSeeWorkClosingBLL();
        private DC_OA_OverSeeWorkDelayIBLL overSeekWorkDelayIBLL = new DC_OA_OverSeeWorkDelayBLL();
        private DC_OA_OverSeeWorkIBLL dc_OA_OverSeeWorkIBLL = new DC_OA_OverSeeWorkBLL();

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
        public ActionResult Form2()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ExecuteIndex()
        {
            return View();
        }
        public ActionResult ProcessForm()
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
            var data = dC_OA_OverSeeWorkTaskSplitIBLL.GetPageList(paginationobj, queryJson);
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
            var data = dC_OA_OverSeeWorkTaskSplitIBLL.GetPageListEx(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult Createflow(string keyValue)
        {

            string key = overSeekWorkClosingIBLL.Createflow(keyValue);
            var jsonData = new
            {
                key = key,

            };


            // return RedirectToAction("NWFContainerForm", "NWFProcess", new { area ="LR_NewWorkFlow", processId = key, tabIframeId=key, type= "draftCreate" });

            // return View(string.Format("LR_NewWorkFlow/NWFProcess/NWFContainerForm?processId ={0}&tabIframeId ={1}&type={2}", key,key, "draftCreate"));


            return Success(jsonData);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Createflow1(string keyValue)
        {

            string key = overSeekWorkDelayIBLL.Createflow(keyValue);
            var jsonData = new
            {
                key = key,

            };


            // return RedirectToAction("NWFContainerForm", "NWFProcess", new { area ="LR_NewWorkFlow", processId = key, tabIframeId=key, type= "draftCreate" });

            // return View(string.Format("LR_NewWorkFlow/NWFProcess/NWFContainerForm?processId ={0}&tabIframeId ={1}&type={2}", key,key, "draftCreate"));


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
            var DC_OA_OverSeeWorkData = dC_OA_OverSeeWorkTaskSplitIBLL.GetDC_OA_OverSeeWorkEntity(keyValue);
            var jsonData = new
            {
                DC_OA_OverSeeWork = DC_OA_OverSeeWorkData,
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
            var data = dC_OA_OverSeeWorkTaskSplitIBLL.GetTree();
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
            dC_OA_OverSeeWorkTaskSplitIBLL.DeleteEntity(keyValue);
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
            DC_OA_OverSeeWorkEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkEntity>();
            dC_OA_OverSeeWorkTaskSplitIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetGanttData(string keyValue)
        {
            return Success(dC_OA_OverSeeWorkTaskSplitIBLL.GetGanttData(keyValue));
        }
        public ActionResult GetProcessPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var param = queryJson.ToJObject();
            var title = param["title"].IsEmpty() ? "%" : "%" + param["title"].ToString() + "%";
            var startTime = param["StartTime"].IsEmpty() ? new DateTime(1900,1,1) : Convert.ToDateTime(param["StartTime"]);
            var endTime = param["EndTime"].IsEmpty() ? DateTime.Now : Convert.ToDateTime(param["EndTime"]);
            string sql = "select * from LR_NWF_Process where F_CreateDate>@startTime and F_CreateDate<@endTime and F_Title like @title";
            var qparam = new { startTime = startTime, endTime = endTime, title = title };
            var result = new RepositoryFactory().BaseRepository().FindList<NWFProcessEntity>(sql, qparam, paginationobj);
            var jsonData = new
            {
                rows = result,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        public ActionResult ConnectProcess(string keyValue, string processId)
        {
            dC_OA_OverSeeWorkTaskSplitIBLL.ConnectProcess(keyValue, processId);
            return Success("操作成功!");
        }
        #endregion

    }
}
