using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using Learun.Application.Organization;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-24 09:40
    /// 描 述：DC_OA_PerformanceAppraisal
    /// </summary>
    public class DC_OA_PerformanceAppraisalController : MvcControllerBase
    {
        private DC_OA_PerformanceAppraisalIBLL dC_OA_PerformanceAppraisalIBLL = new DC_OA_PerformanceAppraisalBLL();
        private PostIBLL postIBLL = new PostBLL();
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
        public ActionResult SelectForm()
        {
            return View();

        }
        [HttpGet]
        public ActionResult LookForm()
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
        public ActionResult GetList(string queryJson)
        {
            var data = dC_OA_PerformanceAppraisalIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_PerformanceAppraisalData = dC_OA_PerformanceAppraisalIBLL.GetDC_OA_PerformanceAppraisalEntity(keyValue);
            var jsonData = new
            {
                DC_OA_PerformanceAppraisal = DC_OA_PerformanceAppraisalData,
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
            var data = dC_OA_PerformanceAppraisalIBLL.GetTree();
            return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSelect(string tid)
        {
            var data = dC_OA_PerformanceAppraisalIBLL.GetList(JsonConvert.SerializeObject(new { F_PATId = tid }));
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
            dC_OA_PerformanceAppraisalIBLL.DeleteEntity(keyValue);
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
            DC_OA_PerformanceAppraisalEntity entity = strEntity.ToObject<DC_OA_PerformanceAppraisalEntity>();
            dC_OA_PerformanceAppraisalIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPostList(string companyId, string departmentId)
        {
            var data = postIBLL.GetList(companyId, "", departmentId);
            return Success(data);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult InsertPostRalation(string tid, string postIds)
        {
            dC_OA_PerformanceAppraisalIBLL.InsertPostRalation(tid, postIds);
            return Success("保存成功");
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPostIdList(string tid)
        {
            string postIds;
            var data = dC_OA_PerformanceAppraisalIBLL.GetPostIdList(tid, out postIds);
            return Success(new
            {
                userInfoList = data,
                userIds = postIds
            });
        }
        #endregion

    }
}
