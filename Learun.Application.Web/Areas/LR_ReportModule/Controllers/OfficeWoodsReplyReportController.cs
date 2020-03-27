using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Newtonsoft.Json;

namespace Learun.Application.Web.Areas.LR_ReportModule.Controllers
{
    public class OfficeWoodsReplyReportController : MvcControllerBase
    {
        private DC_OA_OfficeWoodsReplyIBLL officeWoodsIBLL = new DC_OA_OfficeWoodsReplyBLL();
        // GET: LR_ReportModule/OfficeWoodsReplyReport
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageList(string queryJson)
        {
            
            var data = officeWoodsIBLL.GetList(queryJson);
              
            return Success(data);

   

            
        }
    }
}