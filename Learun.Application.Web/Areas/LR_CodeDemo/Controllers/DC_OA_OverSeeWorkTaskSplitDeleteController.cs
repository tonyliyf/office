using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using Learun.Application.Message;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-08 15:54
    /// 描 述：DC_OA_OverSeeWorkTaskSplitDelete
    /// </summary>
    public class DC_OA_OverSeeWorkTaskSplitDeleteController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkTaskSplitDeleteIBLL dC_OA_OverSeeWorkTaskSplitDeleteIBLL = new DC_OA_OverSeeWorkTaskSplitDeleteBLL();
        private DC_OA_OverSeeWorkClosingIBLL overSeekWorkClosingIBLL = new DC_OA_OverSeeWorkClosingBLL();

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
        public ActionResult ExecuteIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ExecuteForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NoticeForm()
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
        public ActionResult GetList(string keyValue, string queryJson)
        {
            var data = dC_OA_OverSeeWorkTaskSplitDeleteIBLL.GetList(keyValue, queryJson);
            return Success(data);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetListEx(string keyValue, string queryJson)
        {
            var data = dC_OA_OverSeeWorkTaskSplitDeleteIBLL.GetListEx(keyValue, queryJson);
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
            var DC_OA_OverSeeWorkTaskSplitData = dC_OA_OverSeeWorkTaskSplitDeleteIBLL.GetDC_OA_OverSeeWorkTaskSplitEntity(keyValue);
            var jsonData = new
            {
                DC_OA_OverSeeWorkTaskSplit = DC_OA_OverSeeWorkTaskSplitData,
            };
            return Success(jsonData);
        }
        #endregion
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSelect(string tid)
        {
            var data = dC_OA_OverSeeWorkTaskSplitDeleteIBLL.GetList(JsonConvert.SerializeObject(new { F_OSWId = tid }));
            return Success(data);
        }
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
            dC_OA_OverSeeWorkTaskSplitDeleteIBLL.DeleteEntity(keyValue);
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
            DC_OA_OverSeeWorkTaskSplitEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkTaskSplitEntity>();
            dC_OA_OverSeeWorkTaskSplitDeleteIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetNoticeMembersData(string keyValue)
        {
            string noticeContent;
            return Success(new
            {
                userdata = dC_OA_OverSeeWorkTaskSplitDeleteIBLL.GetNoticeMembersData(keyValue, out noticeContent),
                text = noticeContent
            });
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult SendOsNoticeMsg(string msg, string userlist)
        {
            new LR_StrategyInfoBLL().SendMessageByUserIds("OSNotice", msg, userlist);
            return Success("操作成功");
        }
        #endregion

    }
}
