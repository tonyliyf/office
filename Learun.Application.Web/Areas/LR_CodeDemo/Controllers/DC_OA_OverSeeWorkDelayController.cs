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
    /// 日 期：2019-03-02 16:37
    /// 描 述：DC_OA_OverSeeWorkDelay
    /// </summary>
    public class DC_OA_OverSeeWorkDelayController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkDelayIBLL dC_OA_OverSeeWorkDelayIBLL = new DC_OA_OverSeeWorkDelayBLL();

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
            var data = dC_OA_OverSeeWorkDelayIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_OverSeeWorkDelayData = dC_OA_OverSeeWorkDelayIBLL.GetDC_OA_OverSeeWorkDelayEntity(keyValue);
            var DC_OA_OverSeeWorkDelayDetailedData = dC_OA_OverSeeWorkDelayIBLL.GetDC_OA_OverSeeWorkDelayDetailedList(DC_OA_OverSeeWorkDelayData.F_OSWDId);
            var jsonData = new
            {
                DC_OA_OverSeeWorkDelay = DC_OA_OverSeeWorkDelayData,
                DC_OA_OverSeeWorkDelayDetailed = DC_OA_OverSeeWorkDelayDetailedData,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataByProcessId(string processId)
        {
            var DC_OA_OverSeeWorkDelayData = dC_OA_OverSeeWorkDelayIBLL.GetEntityByProcessId(processId);
            IEnumerable<DC_OA_OverSeeWorkDelayDetailedEntity> DC_OA_OverSeeWorkDelayDetailedData = null;
            if (DC_OA_OverSeeWorkDelayData != null)
            {
                DC_OA_OverSeeWorkDelayDetailedData = dC_OA_OverSeeWorkDelayIBLL.GetDC_OA_OverSeeWorkDelayDetailedList(DC_OA_OverSeeWorkDelayData.F_OSWDId);
            }
            var jsonData = new
            {
                DC_OA_OverSeeWorkDelay = DC_OA_OverSeeWorkDelayData,
                DC_OA_OverSeeWorkDelayDetailed = DC_OA_OverSeeWorkDelayDetailedData,
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
            dC_OA_OverSeeWorkDelayIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_OverSeeWorkDelayDetailedList)
        {
            DC_OA_OverSeeWorkDelayEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkDelayEntity>();
            List<DC_OA_OverSeeWorkDelayDetailedEntity> dC_OA_OverSeeWorkDelayDetailedList = strdC_OA_OverSeeWorkDelayDetailedList.ToObject<List<DC_OA_OverSeeWorkDelayDetailedEntity>>();
            dC_OA_OverSeeWorkDelayIBLL.SaveEntity(keyValue, entity, dC_OA_OverSeeWorkDelayDetailedList);
            return Success("保存成功！");
        }
        #endregion
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetInitData(string keyValue)
        {
            var DC_OA_OverSeeWorkClosingData = dC_OA_OverSeeWorkDelayIBLL.GetWorkEntity(keyValue);
            var DC_OA_OverSeeWorkClosingDetailedData = dC_OA_OverSeeWorkDelayIBLL.StatisticsWorkByWorkIds(keyValue);
            var jsonData = new
            {
                DC_OA_OverSeeWorkDelay = DC_OA_OverSeeWorkClosingData,
                DC_OA_OverSeeWorkDelayDetailed = DC_OA_OverSeeWorkClosingDetailedData,
            };
            return Success(jsonData);
        }
    }
}
