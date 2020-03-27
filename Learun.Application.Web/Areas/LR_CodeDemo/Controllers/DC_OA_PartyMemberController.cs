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
    /// 日 期：2019-01-09 15:20
    /// 描 述：DC_OA_PartyMember
    /// </summary>
    public class DC_OA_PartyMemberController : MvcControllerBase
    {
        private DC_OA_PartyMemberIBLL dC_OA_PartyMemberIBLL = new DC_OA_PartyMemberBLL();

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
            var data = dC_OA_PartyMemberIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_PartyMemberData = dC_OA_PartyMemberIBLL.GetDC_OA_PartyMemberEntity(keyValue);
            var DC_OA_PartyMemberDependentsData = dC_OA_PartyMemberIBLL.GetDC_OA_PartyMemberDependentsList(DC_OA_PartyMemberData.F_PartyMemberGUID);
            var jsonData = new
            {
                DC_OA_PartyMember = DC_OA_PartyMemberData,
                DC_OA_PartyMemberDependents = DC_OA_PartyMemberDependentsData,
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
            var data = dC_OA_PartyMemberIBLL.GetTree();
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
            dC_OA_PartyMemberIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_PartyMemberDependentsList)
        {
            DC_OA_PartyMemberEntity entity = strEntity.ToObject<DC_OA_PartyMemberEntity>();
            List<DC_OA_PartyMemberDependentsEntity> dC_OA_PartyMemberDependentsList = strdC_OA_PartyMemberDependentsList.ToObject<List<DC_OA_PartyMemberDependentsEntity>>();
            dC_OA_PartyMemberIBLL.SaveEntity(keyValue, entity, dC_OA_PartyMemberDependentsList);
            return Success("保存成功！");
        }
        #endregion

    }
}
