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
    /// 日 期：2019-01-26 11:12
    /// 描 述：DC_OA_PerformanceUserWork
    /// </summary>
    public class DC_OA_PerformanceUserWorkController : MvcControllerBase
    {
        private DC_OA_PerformanceUserWorkIBLL dC_OA_PerformanceUserWorkIBLL = new DC_OA_PerformanceUserWorkBLL();

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
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_PerformanceUserWorkData = dC_OA_PerformanceUserWorkIBLL.GetDC_OA_PerformanceUserWorkEntity(keyValue);
            var jsonData = new
            {
                DC_OA_PerformanceUserWork = DC_OA_PerformanceUserWorkData,
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
            var data = dC_OA_PerformanceUserWorkIBLL.GetTree();
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
            dC_OA_PerformanceUserWorkIBLL.DeleteEntity(keyValue);
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
            DC_OA_PerformanceUserWorkEntity entity = strEntity.ToObject<DC_OA_PerformanceUserWorkEntity>();
            dC_OA_PerformanceUserWorkIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

        [HttpPost]
        [AjaxOnly]
        public ActionResult DoExcute(string rid)
        {
            if (dC_OA_PerformanceUserWorkIBLL.ExistWork(rid))
            {
                return Fail("不能重复添加!");
            }
            else
            {
                dC_OA_PerformanceUserWorkIBLL.DoExcute(rid);
                return Success("保存成功");
            }
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult BeginCheck(string wid)
        {
            if (dC_OA_PerformanceUserWorkIBLL.BeginCheck(wid))
            {
                return Success("发起成功");
            }
            else
            {
                return Fail("发起失败");
            }
        }
    }
}
