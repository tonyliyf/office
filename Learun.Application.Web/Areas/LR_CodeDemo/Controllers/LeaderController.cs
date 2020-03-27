using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    public class LeaderController : MvcControllerBase
    {
        // GET: LR_CodeDemo/Leader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLeaderData()
        {
            var data = string.Empty;
            return Success(data);
        }
    }
}