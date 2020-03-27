using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Collections;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-19 15:47
    /// 描 述：DC_OA_UseHoliday
    /// </summary>
    public class DC_OA_UseHolidayController : MvcControllerBase
    {
        private DC_OA_UseHolidayIBLL dC_OA_UseHolidayIBLL = new DC_OA_UseHolidayBLL();

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
            var data = dC_OA_UseHolidayIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_UseHolidayData = dC_OA_UseHolidayIBLL.GetDC_OA_UseHolidayEntity(keyValue);
            var jsonData = new
            {
                DC_OA_UseHoliday = DC_OA_UseHolidayData,
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
            var data = dC_OA_UseHolidayIBLL.GetTree();
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
        public ActionResult DeleteForm()
        {
            dC_OA_UseHolidayIBLL.DeleteEntity();
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
        public ActionResult SaveForm(string keyValue, double days)
        {
            dC_OA_UseHolidayIBLL.SaveEntity(keyValue, days);
            return Success("保存成功！");
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetRestYHoliday()
        {
            UserInfo user = LoginUserInfo.Get();
            return Success(new { result = dC_OA_UseHolidayIBLL.GetTotalDaysByUserId(user.userId) - dC_OA_UseHolidayIBLL.GetUserDaysByUserId(user.userId) });
        }


        [HttpGet]
        public ActionResult GetYearHoliday()
        {
            UserInfo user = LoginUserInfo.Get();
            double totaldays = dC_OA_UseHolidayIBLL.GetTotalDaysByUserId(user.userId);
            double usedays = dC_OA_UseHolidayIBLL.GetUserDaysByUserId(user.userId);
            double leavedays = totaldays - usedays;
            List<Hashtable> data = new List<Hashtable>();
            Hashtable ht = new Hashtable();
            ht["total"] = totaldays;
            ht["use"] = usedays;
            ht["leave"]= leavedays;
            data.Add(ht);
          
            return Success(data);
        }


        #endregion

    }
}
