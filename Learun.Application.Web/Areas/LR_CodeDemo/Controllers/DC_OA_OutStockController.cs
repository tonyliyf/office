using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-10 15:49
    /// 描 述：DC_OA_OutStock
    /// </summary>
    public class DC_OA_OutStockController : MvcControllerBase
    {
        private DC_OA_OutStockIBLL dC_OA_OutStockIBLL = new DC_OA_OutStockBLL();
        private CodeRuleIBLL iBll = new CodeRuleBLL();

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
            var data = dC_OA_OutStockIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_OutStockData = dC_OA_OutStockIBLL.GetDC_OA_OutStockEntity(keyValue);
            var DC_OA_OutStockDetailsData = dC_OA_OutStockIBLL.GetDC_OA_OutStockDetailsList(DC_OA_OutStockData.DC_OA_OutStockId);
            var jsonData = new
            {
                DC_OA_OutStock = DC_OA_OutStockData,
                DC_OA_OutStockDetails = DC_OA_OutStockDetailsData,
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
            var DC_OA_OutStockData = dC_OA_OutStockIBLL.GetDC_OA_OutStockEntity(keyValue);
            if (DC_OA_OutStockData.DC_OA_OutStockState == "2")
            {
                return Fail("单据已出库,不能删除！");
            }
            dC_OA_OutStockIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_OutStockDetailsList)
        {
            DC_OA_OutStockEntity entity = strEntity.ToObject<DC_OA_OutStockEntity>();
            var DC_OA_OutStockData = dC_OA_OutStockIBLL.GetDC_OA_OutStockEntity(keyValue);
            if (DC_OA_OutStockData != null && DC_OA_OutStockData.DC_OA_OutStockState == "2")
            {
                return Fail("单据已出库,不能修改！");
            }

            if (string.IsNullOrEmpty(keyValue))
            {
                iBll.UseRuleSeed("10010");
            }
            List<DC_OA_OutStockDetailsEntity> dC_OA_OutStockDetailsList = strdC_OA_OutStockDetailsList.ToObject<List<DC_OA_OutStockDetailsEntity>>();
            dC_OA_OutStockIBLL.SaveEntity(keyValue, entity, dC_OA_OutStockDetailsList);
            string msg = "保存成功！";
            if (entity.DC_OA_OutStockState == "2")
            {
                if (dC_OA_OutStockIBLL.OutStock(entity.DC_OA_OutStockId, entity, dC_OA_OutStockDetailsList))
                {
                    msg = "出库成功！";
                }
                else
                {
                    return Fail("出库失败！请检查库存");
                }
            }
            return Success(msg);
        }
        #endregion
        /// <summary>
        /// 入库操作
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>

        [HttpPost]
        [AjaxOnly]
        public ActionResult OutStock(string keyValue)
        {

            var DC_OA_OutStockEntity = dC_OA_OutStockIBLL.GetDC_OA_OutStockEntity(keyValue);
            if (DC_OA_OutStockEntity.DC_OA_OutStockState == "2")
            {
                return Fail("单据已出库,不能重复出库，出库失败！");
            }
            List<DC_OA_OutStockDetailsEntity> temps = dC_OA_OutStockIBLL.GetDC_OA_OutStockDetailsList(DC_OA_OutStockEntity.DC_OA_OutStockId).ToList();
            if (dC_OA_OutStockIBLL.OutStock(keyValue, DC_OA_OutStockEntity, temps))
            {
                return Success("出库成功！");
            }
            return Fail("出库失败！请检查库存");
        }
    }
}
