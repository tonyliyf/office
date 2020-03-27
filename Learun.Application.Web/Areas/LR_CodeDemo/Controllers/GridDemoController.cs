using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2018.04.12
    /// 描 述：表格演示
    /// </summary>
    public class GridDemoController : MvcControllerBase
    {
        /// <summary>
        /// 普通表格
        /// </summary>
        /// <returns></returns>
        public ActionResult CommonIndex()
        {
            return View();
        }


        /// <summary>
        /// 编辑表格
        /// </summary>
        /// <returns></returns>
        public ActionResult EditIndex()
        {
            return View();
        }

        /// <summary>
        /// 报表表格
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportIndex()
        {
            return View();
        }
    }
}