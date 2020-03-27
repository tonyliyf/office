﻿using Learun.Util;
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
    /// 日 期：2019-03-02 12:34
    /// 描 述：DC_OA_OverSeeWorkClosing
    /// </summary>
    public class DC_OA_OverSeeWorkClosingController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkClosingIBLL dC_OA_OverSeeWorkClosingIBLL = new DC_OA_OverSeeWorkClosingBLL();

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
            var data = dC_OA_OverSeeWorkClosingIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_OverSeeWorkClosingData = dC_OA_OverSeeWorkClosingIBLL.GetDC_OA_OverSeeWorkClosingEntity(keyValue);
            var DC_OA_OverSeeWorkClosingDetailedData = dC_OA_OverSeeWorkClosingIBLL.GetDC_OA_OverSeeWorkClosingDetailedList(DC_OA_OverSeeWorkClosingData.F_OSWCId);
            var jsonData = new
            {
                DC_OA_OverSeeWorkClosing = DC_OA_OverSeeWorkClosingData,
                DC_OA_OverSeeWorkClosingDetailed = DC_OA_OverSeeWorkClosingDetailedData,
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
            var DC_OA_OverSeeWorkClosingData = dC_OA_OverSeeWorkClosingIBLL.GetEntityByProcessId(processId);
            IEnumerable<DC_OA_OverSeeWorkClosingDetailedEntity> DC_OA_OverSeeWorkClosingDetailedData = null;
            if (DC_OA_OverSeeWorkClosingData != null)
            {
                DC_OA_OverSeeWorkClosingDetailedData = dC_OA_OverSeeWorkClosingIBLL.GetDC_OA_OverSeeWorkClosingDetailedList(DC_OA_OverSeeWorkClosingData.F_OSWCId);
            }
            var jsonData = new
            {
                DC_OA_OverSeeWorkClosing = DC_OA_OverSeeWorkClosingData,
                DC_OA_OverSeeWorkClosingDetailed = DC_OA_OverSeeWorkClosingDetailedData,
            };
            return Success(jsonData);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetInitData(string keyValue)
        {
            var DC_OA_OverSeeWorkClosingData = dC_OA_OverSeeWorkClosingIBLL.GetWorkEntity(keyValue);
            var DC_OA_OverSeeWorkClosingDetailedData = dC_OA_OverSeeWorkClosingIBLL.StatisticsWorkByWorkIds(keyValue);
            var jsonData = new
            {
                DC_OA_OverSeeWorkClosing = DC_OA_OverSeeWorkClosingData,
                DC_OA_OverSeeWorkClosingDetailed = DC_OA_OverSeeWorkClosingDetailedData,
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
            dC_OA_OverSeeWorkClosingIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_OverSeeWorkClosingDetailedList)
        {
            DC_OA_OverSeeWorkClosingEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkClosingEntity>();
            List<DC_OA_OverSeeWorkClosingDetailedEntity> dC_OA_OverSeeWorkClosingDetailedList = strdC_OA_OverSeeWorkClosingDetailedList.ToObject<List<DC_OA_OverSeeWorkClosingDetailedEntity>>();
            dC_OA_OverSeeWorkClosingIBLL.SaveEntity(keyValue, entity, dC_OA_OverSeeWorkClosingDetailedList);
            return Success("保存成功！");
        }
        #endregion

    }
}