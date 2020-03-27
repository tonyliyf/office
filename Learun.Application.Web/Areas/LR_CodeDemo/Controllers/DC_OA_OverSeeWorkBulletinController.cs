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
    /// 日 期：2019-03-01 15:48
    /// 描 述：DC_OA_OverSeeWorkBulletin
    /// </summary>
    public class DC_OA_OverSeeWorkBulletinController : MvcControllerBase
    {
        private DC_OA_OverSeeWorkBulletinIBLL dC_OA_OverSeeWorkBulletinIBLL = new DC_OA_OverSeeWorkBulletinBLL();

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
            var data = dC_OA_OverSeeWorkBulletinIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult StatisticsWorkByWorkIds(string workIds)
        {
            return Success(dC_OA_OverSeeWorkBulletinIBLL.StatisticsWorkByWorkIds(workIds));
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_OverSeeWorkBulletinData = dC_OA_OverSeeWorkBulletinIBLL.GetDC_OA_OverSeeWorkBulletinEntity(keyValue);
            var DC_OA_OverSeeWorkBulletinDetailedData = dC_OA_OverSeeWorkBulletinIBLL.GetDC_OA_OverSeeWorkBulletinDetailedList(DC_OA_OverSeeWorkBulletinData.F_DOBId);
            var jsonData = new
            {
                DC_OA_OverSeeWorkBulletin = DC_OA_OverSeeWorkBulletinData,
                DC_OA_OverSeeWorkBulletinDetailed = DC_OA_OverSeeWorkBulletinDetailedData,
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
            var DC_OA_OverSeeWorkBulletinData = dC_OA_OverSeeWorkBulletinIBLL.GetEntityByProcessId(processId);
            var DC_OA_OverSeeWorkBulletinDetailedData = dC_OA_OverSeeWorkBulletinIBLL.GetDetailList(processId);
            var jsonData = new
            {
                DC_OA_OverSeeWorkBulletin = DC_OA_OverSeeWorkBulletinData,
                DC_OA_OverSeeWorkBulletinDetailed = DC_OA_OverSeeWorkBulletinDetailedData,
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
            dC_OA_OverSeeWorkBulletinIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string workIds)
        {
            DC_OA_OverSeeWorkBulletinEntity entity = strEntity.ToObject<DC_OA_OverSeeWorkBulletinEntity>();
            dC_OA_OverSeeWorkBulletinIBLL.SaveEntity(keyValue, entity, workIds);
            return Success("保存成功！");
        }
        #endregion

    }
}
