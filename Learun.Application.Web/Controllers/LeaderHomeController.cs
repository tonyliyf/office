using Learun.Application.Base.SystemModule;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.TwoDevelopment.OAReport;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Learun.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.03.09
    /// 描 述：主页控制器
    /// </summary>
    public class LeaderHomeController : MvcControllerBase
    {
        private reportIBLL report = new reportBLL();
        #region 视图功能
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            string learn_UItheme = WebHelper.GetCookie("Learn_ADMS_V6.1_UItheme1");
            return View("AdminWindos");
            //switch (learn_UItheme)
            //{
            //    case "1":
            //        return View("AdminDefault");      // 经典版本
            //    case "2":
            //        return View("AdminAccordion");    // 手风琴版本
            //    case "3":
            //        return View("AdminWindos");       // Windos版本
            //    case "4":
            //        return View("AdminTop");          // 顶部菜单版本
            //    default:
            //        return View("AdminDefault");      // 经典版本
            //}
        }
        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop()
        {
            return View("AdminDesktopTemp");
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp()
        {
            return View();
        }
        #endregion

        private ICache cache = CacheFactory.CaChe();

        #region 清空缓存
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ClearRedis()
        {
            for (int i = 0; i < 16; i++)
            {
                cache.RemoveAll(i);
            }
            return Success("清空成功");
        }
        #endregion

        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleName, string moduleUrl)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 2;
            logEntity.F_OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Visit);
            logEntity.F_OperateAccount = userInfo.account;
            logEntity.F_OperateUserId = userInfo.userId;
            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "访问地址：" + moduleUrl;
            logEntity.WriteLog();
            return Success("ok");
        }

        [HttpPost]
        public ActionResult GetMapMarkers(int type)
        {
            return Json(new MapService().GetMapMarkers(type));
        }

        [AjaxOnly]
        [HttpGet]
        public ActionResult GetLeaderData()
        {

            DateTime dtStart = DateTime.Now.AddMonths(-6);
            DateTime dtEnd = DateTime.Now;
            var data = report.GetLeaderData(dtStart, dtEnd);
            DataTable dt = data.Clone();
            DataRow dtRow = null;
            for (int i = 0; i < 6; i++)
            {
                string month = dtEnd.AddMonths(0 - i).ToString("yyyyMM");
                for (int j = 1; j < 4; j++)
                {
                    dtRow = dt.NewRow();
                    DataRow[] dttemp = data.Select(string.Format("type={0} and Month ={1}", j, month));

                    if (dttemp != null && dttemp.Length > 0)
                    {

                        dtRow["SumMoney"] = dttemp[0]["SumMoney"].ToString();
                    }
                    else
                    {
                        dtRow["SumMoney"] = 0;
                    }
                    dtRow["Month"] = month;
                    dtRow["type"] = j;
                    dt.Rows.Add(dtRow);

                }
            }
            dt.AcceptChanges();

            DataTable dtsort = dt.Clone();
            dtsort = dt.Rows.Cast<DataRow>().OrderBy(r => r["Month"].ToString()).CopyToDataTable();

            var jsonData = new
            {
                rows = dtsort,
                length = dt.Rows.Count

            };
            return Success(jsonData);


        }
        [AjaxOnly]
        [HttpGet]
        public ActionResult GetFlowData()
        {

            //F_Category  sums
            var data = report.GetFlowData();

            var jsonData = new
            {
                rows = data,

            };
            return Success(jsonData);

        }


        [HttpPost]
        public ActionResult StatisticsForEchart()
        {
            var result = new DC_OA_OverSeeWorkBLL().StatisticForEChart();
            var categoryList = result.Select(c => c.type).Distinct().OrderBy(c => c);
            var stateList = result.Select(c => c.state).Distinct().OrderBy(c => c);
            Dictionary<string, List<int>> SeriesData = new Dictionary<string, List<int>>();
            foreach (var str in categoryList)
            {
                List<int> data = new List<int>();
                foreach (var str1 in stateList)
                {
                    var tempresult = result.FirstOrDefault(c => c.state == str1 && c.type == str);
                    if (tempresult == null)
                    {
                        data.Add(0);
                    }
                    else
                    {
                        data.Add(tempresult.count);
                    }
                }
                SeriesData.Add(str, data);
            }
            return Json(new
            {
                categoryList = categoryList,
                SeriesData = SeriesData.OrderBy(c => c.Key),
                stateList = stateList
            });
        }

        [HttpPost]
        public ActionResult StatisticsRentForEChart()
        {
            var result = new DC_ASSETS_HouseRentIncomeBLL().StatisticsForEChart();
            var stateList = new List<string>();
            var categoryList = new List<string> { "房屋", "广告牌" };
            Dictionary<string, List<double>> SeriesData = new Dictionary<string, List<double>>();
            DateTime now = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                stateList.Add(now.AddMonths(0 - i).ToString("yyyyMM"));
            }
            foreach (var str in categoryList)
            {
                List<double> data = new List<double>();
                foreach (var str1 in stateList)
                {
                    var tempresult = result.FirstOrDefault(c => c.month == str1 && c.type == str);
                    if (tempresult == null)
                    {
                        data.Add(0);
                    }
                    else
                    {
                        data.Add(tempresult.money);
                    }
                }
                SeriesData.Add(str, data);
            }
            return Json(new
            {
                categoryList = categoryList,
                SeriesData = SeriesData.OrderBy(c => c.Key),
                stateList = stateList
            });
        }
//        /LeaderHome/GetHouseList1
///LeaderHome/GetLandList1
///LeaderHome/BoardList


        public ActionResult HouseRentIncome(string code)
        {
            return Success(new MapService().HouseRentIncome(code));
        }
        public ActionResult Houselist(string code)
        {
            return Success(new MapService().House1(code));
        }
        public ActionResult House(string code)
        {
            return Success(new MapService().House(code));
        }
        public ActionResult BuildingBase(string code)
        {
            return Success(new MapService().BuildingBase(code));
        }
        public ActionResult GetLandList1(string code,string address)
        {
            return Success(new MapService().GetLandList1(code, address));
        }
        public ActionResult BoardList(string code, string address)
        {
            return Success(new MapService().BoardList(code, address));
        }
        
        public ActionResult GetHouseList1(string code, string address)
        {
            return Success(new MapService().GetHouseList1(code, address));
        }
        public ActionResult GetHouseList(string type,string name,string index)
        {
            return Success(new MapService().GetHouseList(type,name,index));
        }
        public ActionResult GetLandList(string type,string name,string index)
        {
            return Success(new MapService().GetLandList(type,name,index));
        }
        public ActionResult GetAdBoardList(string type,string name,string index)
        {
            return Success(new MapService().GetAdBoardList(type,name,index));
        }
        public ActionResult GetProjectList(string type,string name,string index)
        {
            return Success(new MapService().GetProjectList(type,name,index));
        }
    }
}