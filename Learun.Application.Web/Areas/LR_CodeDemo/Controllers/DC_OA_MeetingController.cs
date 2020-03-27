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
    /// 日 期：2019-02-27 15:58
    /// 描 述：DC_OA_Meeting
    /// </summary>
    public class DC_OA_MeetingController : MvcControllerBase
    {
        private DC_OA_MeetingIBLL dC_OA_MeetingIBLL = new DC_OA_MeetingBLL();
        private DC_OA_MeetingSubjectSumIBLL dC_OA_MeetingSubjectSumIBLL = new DC_OA_MeetingSubjectSumBLL();

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
        [HttpGet]
        public ActionResult MeetingReport()
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
        public ActionResult SeminarMeettingForm()
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
        public ActionResult GetPageList(string queryJson)
        {
            return Success(dC_OA_MeetingIBLL.GetPageList(queryJson));
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_MeetingData = dC_OA_MeetingIBLL.GetDC_OA_MeetingEntity(keyValue);
            var jsonData = new
            {
                DC_OA_Meeting = DC_OA_MeetingData,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataByProcessId(string processId)
        {
            var DC_OA_MeetingData = dC_OA_MeetingIBLL.GetEntityByProcessId(processId);
            var jsonData = new
            {
                DC_OA_Meeting = DC_OA_MeetingData,
            };
            return Success(jsonData);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormDataByProcessIdEx(string processId)
        {
            var DC_OA_MeetingData = dC_OA_MeetingIBLL.GetEntityByProcessId(processId);
            var DC_OA_MeetingSubject = dC_OA_MeetingSubjectSumIBLL.GetDC_OA_MeetingSubjectSumList(DC_OA_MeetingData.F_SubjectSumId);
            var jsonData = new
            {
                DC_OA_Meeting = DC_OA_MeetingData,
                DC_OA_MeetingSubject = DC_OA_MeetingSubject
            };
            return Success(jsonData);
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
            dC_OA_MeetingIBLL.DeleteEntity(keyValue);
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
            DC_OA_MeetingEntity entity = strEntity.ToObject<DC_OA_MeetingEntity>();
            dC_OA_MeetingIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

        public ActionResult GetMeetingList()
        {
            return Success(dC_OA_MeetingIBLL.GetMeetingList());
        }
    }
}
