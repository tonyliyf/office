using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.EcologyDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.EcologyDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-06 11:15
    /// 描 述：广告牌维修记录
    /// </summary>
    public class BusStopBillboardsRepairRecordController : MvcControllerBase
    {
        private BusStopBillboardsRepairRecordIBLL busStopBillboardsRepairRecordIBLL = new BusStopBillboardsRepairRecordBLL();

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
            var data = busStopBillboardsRepairRecordIBLL.GetPageList(paginationobj, queryJson);
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
            var formtable_main_129Entity = busStopBillboardsRepairRecordIBLL.GetDC_EngineProject_formtable_main_129Entity(keyValue);
            var jsonData = new
            {
                formtable_main_129Entity = formtable_main_129Entity,
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 提交数据
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity)
        {
                return Success("退出");
        }
        #endregion


    }
}
