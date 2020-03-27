using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;
using System;
using System.Linq;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-07 11:19
    /// 描 述：DC_OA_OverSeeWork
    /// </summary>
    public class DC_OA_OverSeeWorkPlatFormController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkIBLL dC_OA_OverSeeWorkIBLL = new DC_OA_OverSeeWorkBLL();
        private CodeRuleIBLL CodeRuleIBLL = new CodeRuleBLL();
        #region 视图功能

        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.count1 = dC_OA_OverSeeWorkIBLL.GetCount2("执行中");
            ViewBag.count2 = dC_OA_OverSeeWorkIBLL.GetCount2("逾期");
            ViewBag.count3 = dC_OA_OverSeeWorkIBLL.GetCount2("临近");
            ViewBag.count4 = dC_OA_OverSeeWorkIBLL.GetCount2("办结");
            ViewBag.count5 = dC_OA_OverSeeWorkIBLL.GetCount2("延期");

            ViewBag.taskCount1 = dC_OA_OverSeeWorkIBLL.GetTaskCountByCategory("政府工作报告");
            ViewBag.taskCount2 = dC_OA_OverSeeWorkIBLL.GetTaskCountByCategory("总经理办公室");
            ViewBag.taskCount3 = dC_OA_OverSeeWorkIBLL.GetTaskCountByCategory("重点建设项目");
            ViewBag.taskCount4 = dC_OA_OverSeeWorkIBLL.GetTaskCountByCategory("投资项目");
            ViewBag.taskCount5 = dC_OA_OverSeeWorkIBLL.GetTaskCountByCategory("日常督办");

            ViewBag.mytaskCount1 = dC_OA_OverSeeWorkIBLL.GetMyTaskCount();
            ViewBag.mytaskCount2 = dC_OA_OverSeeWorkIBLL.GetMyTaskCountEx();
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


    }
}
