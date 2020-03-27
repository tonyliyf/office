using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-16 17:45
    /// 描 述：DC_ASSETS_HouseRentIncome
    /// </summary>
    public class DC_ASSETS_HouseRentIncomeController : MvcControllerBase
    {
        private DC_ASSETS_HouseRentIncomeIBLL dC_ASSETS_HouseRentIncomeIBLL = new DC_ASSETS_HouseRentIncomeBLL();

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
            var data = dC_ASSETS_HouseRentIncomeIBLL.GetPageList(paginationobj, queryJson);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string F_HRInId)
        {
            var data = dC_ASSETS_HouseRentIncomeIBLL.GetList(F_HRInId);
            var jsonData = new
            {
                DC_ASSETS_HouseRentIncome = data,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue,string keyword)
        {
            if (keyword == null || keyword == "")
            {
                var DC_ASSETS_HouseRentIncomeData = dC_ASSETS_HouseRentIncomeIBLL.GetDC_ASSETS_HouseRentIncomeEntityByHDid(keyValue).OrderBy(i => i.F_Renter).ThenBy(i => i.F_PlanPayDate);

                var jsonData = new
                {
                    DC_ASSETS_HouseRentIncome = DC_ASSETS_HouseRentIncomeData,
                };

                return Success(jsonData);
            }
            else
            {

                var DC_ASSETS_HouseRentIncomeData = dC_ASSETS_HouseRentIncomeIBLL.GetDC_ASSETS_HouseRentIncomeEntityByHDid(keyValue).Where(i=>i.F_Renter.Contains(keyword)||i.F_ContractNumber.Contains(keyword)).OrderBy(i => i.F_Renter).ThenBy(i => i.F_PlanPayDate);

                var jsonData = new
                {
                    DC_ASSETS_HouseRentIncome = DC_ASSETS_HouseRentIncomeData,
                };

                return Success(jsonData);

            }
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
            dC_ASSETS_HouseRentIncomeIBLL.DeleteEntity(keyValue);
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
            List<DC_ASSETS_HouseRentIncomeEntity> entity = strEntity.ToObject<List<DC_ASSETS_HouseRentIncomeEntity>>();
            dC_ASSETS_HouseRentIncomeIBLL.SaveEntity(keyValue,entity);
            return Success("保存成功！");
        }
        #endregion

    }
}
