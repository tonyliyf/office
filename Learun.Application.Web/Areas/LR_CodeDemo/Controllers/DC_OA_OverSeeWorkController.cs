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
    public class DC_OA_OverSeeWorkController : MvcControllerBase
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
        [HttpGet]
        public ActionResult OverSeeWorkReport()
        {
            return View();
        }
        public ActionResult OverSeeWorkReport1()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OSCategoryReport()
        {
            return View();
        }
        public ActionResult ScoreForm()
        {
            return View();
        }
        public ActionResult OverSeePrint(string keyValue)
        {
            return View(dC_OA_OverSeeWorkIBLL.GetDC_OA_OverSeeWorkEntity(keyValue));
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
            var data = dC_OA_OverSeeWorkIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult StatisticsWorkByCurrentMonth(DateTime startDate, DateTime endDate)
        {
            return Success(dC_OA_OverSeeWorkIBLL.StatisticsWorkByCurrentMonth(startDate, endDate, "", ""));
        }
        [AjaxOnly]
        public ActionResult StatisticsByCategory(DateTime startDate, DateTime endDate)
        {
            return Success(dC_OA_OverSeeWorkIBLL.StatisticsByCategory(startDate, endDate));
        }
        [AjaxOnly]
        public ActionResult StatisticsByCategoryEx(DateTime startDate, DateTime endDate)
        {
            var result = dC_OA_OverSeeWorkIBLL.StatisticsByCategoryEx(startDate, endDate);
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
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_OverSeeWorkData = dC_OA_OverSeeWorkIBLL.GetDC_OA_OverSeeWorkEntity(keyValue);
            var jsonData = new
            {
                DC_OA_OverSeeWork = DC_OA_OverSeeWorkData,
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
            var data = dC_OA_OverSeeWorkIBLL.GetTree();
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
            dC_OA_OverSeeWorkIBLL.DeleteEntity(keyValue);
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
            DC_OA_OverSeeWorkEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkEntity>();
            dC_OA_OverSeeWorkIBLL.SaveEntity(keyValue, entity);
            if (string.IsNullOrEmpty(keyValue))
            {
                CodeRuleIBLL.UseRuleSeed("10000");
            }
            return Success("保存成功！");
        }

        public ActionResult EnterOverSeeWork(string keyValue)
        {
            dC_OA_OverSeeWorkIBLL.EnterOverSeeWork(keyValue);
            return Success("操作成功");
        }
        public ActionResult GetCount()
        {
            return Success(new[]{
                dC_OA_OverSeeWorkIBLL.GetCount("执行中"),
                dC_OA_OverSeeWorkIBLL.GetCount("逾期"),
                dC_OA_OverSeeWorkIBLL.GetCount("临近"),
                dC_OA_OverSeeWorkIBLL.GetCount("办结"),
                dC_OA_OverSeeWorkIBLL.GetCount("延期")
            });
        }
        public ActionResult GetCount1()
        {
            return Success(new[]{
                dC_OA_OverSeeWorkIBLL.GetCount1("执行中"),
                dC_OA_OverSeeWorkIBLL.GetCount1("逾期"),
                dC_OA_OverSeeWorkIBLL.GetCount1("临近"),
                dC_OA_OverSeeWorkIBLL.GetCount1("办结"),
                dC_OA_OverSeeWorkIBLL.GetCount1("延期")
            });
        }
        public ActionResult GetScore(string keyValue)
        {
            double score; string advice;
            dC_OA_OverSeeWorkIBLL.GetScore(keyValue, out score, out advice);
            return Success(new
            {
                score = score,
                advice = advice
            });
        }
        public ActionResult AddScore(string keyValue, double score, string advice)
        {
            dC_OA_OverSeeWorkIBLL.AddScore(keyValue, score, advice);
            return Success("保存成功");
        }
        #endregion


        public ActionResult GetPlatformListByState(string state)
        {
            return Success(dC_OA_OverSeeWorkIBLL.GetPlatformListByState(state));
        }

        public ActionResult GetTaskByTypeAndMonth()
        {
            return Success(dC_OA_OverSeeWorkIBLL.GetTaskByTypeAndMonth());
        }

        public ActionResult GetTaskPercentByCategory()
        {
            return Success(dC_OA_OverSeeWorkIBLL.GetTaskPercentByCategory());
        }
    }
}
