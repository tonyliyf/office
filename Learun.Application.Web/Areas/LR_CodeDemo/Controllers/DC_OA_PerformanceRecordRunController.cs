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
    /// 日 期：2019-01-24 17:30
    /// 描 述：DC_OA_PerformanceRecordRun
    /// </summary>
    public class DC_OA_PerformanceRecordRunController : MvcControllerBase
    {
        private DC_OA_PerformanceRecordRunIBLL dC_OA_PerformanceRecordRunIBLL = new DC_OA_PerformanceRecordRunBLL();

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
        [HttpGet]
        public ActionResult SelectForm()
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
            var data = dC_OA_PerformanceRecordRunIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_PerformanceRecordRunData = dC_OA_PerformanceRecordRunIBLL.GetDC_OA_PerformanceRecordRunEntity(keyValue);
            var jsonData = new
            {
                DC_OA_PerformanceRecordRun = DC_OA_PerformanceRecordRunData,
            };
            return Success(jsonData);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserList(string tid)
        {
            var data = dC_OA_PerformanceRecordRunIBLL.GetUserList(tid);
            return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetCheckerList(string tid)
        {
            var data = dC_OA_PerformanceRecordRunIBLL.GetCheckerList(tid);
            return Success(data);
        }
        #endregion
        [HttpPost]
        [AjaxOnly]
        public ActionResult SaveUserList(string rid, string userIds)
        {
            dC_OA_PerformanceRecordRunIBLL.SaveUserList(rid, userIds);
            return Success("保存成功");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetUserIdList(string rid)
        {
            string userIds;
            var data = dC_OA_PerformanceRecordRunIBLL.GetUserIdList(rid, out userIds);
            return Success(new
            {
                userInfoList = data,
                userIds = userIds
            });
        }
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
            dC_OA_PerformanceRecordRunIBLL.DeleteEntity(keyValue);
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
            DC_OA_PerformanceRecordRunEntity entity = strEntity.ToObject<DC_OA_PerformanceRecordRunEntity>();
            dC_OA_PerformanceRecordRunIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

    }
}
