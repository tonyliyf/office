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
    /// 日 期：2019-01-25 15:26
    /// 描 述：DC_OA_PRREvaluationUserRelation
    /// </summary>
    public class DC_OA_PRREvaluationUserRelationController : MvcControllerBase
    {
        private DC_OA_PRREvaluationUserRelationIBLL dC_OA_PRREvaluationUserRelationIBLL = new DC_OA_PRREvaluationUserRelationBLL();

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
        public ActionResult GetList(string rid)
        {
            var data = dC_OA_PRREvaluationUserRelationIBLL.GetList(rid);
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
            var DC_OA_PRREvaluationUserRelationData = dC_OA_PRREvaluationUserRelationIBLL.GetDC_OA_PRREvaluationUserRelationEntity(keyValue);
            var jsonData = new
            {
                DC_OA_PRREvaluationUserRelation = DC_OA_PRREvaluationUserRelationData,
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
            dC_OA_PRREvaluationUserRelationIBLL.DeleteEntity(keyValue);
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
            DC_OA_PRREvaluationUserRelationEntity entity = strEntity.ToObject<DC_OA_PRREvaluationUserRelationEntity>();
            if (dC_OA_PRREvaluationUserRelationIBLL.SaveEntity(keyValue, entity))
            {
                return Success("保存成功！");
            }
            else
            {
                return Fail("不能添加相同人员！");
            }
        }
        #endregion

    }
}
