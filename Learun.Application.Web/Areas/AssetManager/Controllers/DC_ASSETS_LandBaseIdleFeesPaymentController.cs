﻿using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-21 16:31
    /// 描 述：DC_ASSETS_LandBaseIdleFeesPayment
    /// </summary>
    public class DC_ASSETS_LandBaseIdleFeesPaymentController : MvcControllerBase
    {
        private DC_ASSETS_LandBaseIdleFeesPaymentIBLL dC_ASSETS_LandBaseIdleFeesPaymentIBLL = new DC_ASSETS_LandBaseIdleFeesPaymentBLL();

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
            var data = dC_ASSETS_LandBaseIdleFeesPaymentIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_ASSETS_LandBaseIdleFeesPaymentData = dC_ASSETS_LandBaseIdleFeesPaymentIBLL.GetDC_ASSETS_LandBaseIdleFeesPaymentEntity( keyValue );
            var jsonData = new {
                DC_ASSETS_LandBaseIdleFeesPayment = DC_ASSETS_LandBaseIdleFeesPaymentData,
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
            var data = dC_ASSETS_LandBaseIdleFeesPaymentIBLL.GetTree();
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
            dC_ASSETS_LandBaseIdleFeesPaymentIBLL.DeleteEntity(keyValue);
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
            DC_ASSETS_LandBaseIdleFeesPaymentEntity entity = strEntity.ToObject<DC_ASSETS_LandBaseIdleFeesPaymentEntity>();
            dC_ASSETS_LandBaseIdleFeesPaymentIBLL.SaveEntity(keyValue,entity);
            return Success("保存成功！");
        }
        #endregion

    }
}