using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-03 15:50
    /// 描 述：DC_OA_InStock
    /// </summary>
    public class DC_OA_InStockController : MvcControllerBase
    {
        private DC_OA_InStockIBLL dC_OA_InStockIBLL = new DC_OA_InStockBLL();
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
            var data = dC_OA_InStockIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_InStockData = dC_OA_InStockIBLL.GetDC_OA_InStockEntity( keyValue );
            var DC_OA_InStockDetailsData = dC_OA_InStockIBLL.GetDC_OA_InStockDetailsList( DC_OA_InStockData.DC_OA_InStockId );
            var jsonData = new {
                DC_OA_InStock = DC_OA_InStockData,
                DC_OA_InStockDetails = DC_OA_InStockDetailsData,
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
            var DC_OA_InStockData = dC_OA_InStockIBLL.GetDC_OA_InStockEntity(keyValue);
            if (DC_OA_InStockData.DC_OA_InStockState == "2")
            {
                return Fail("单据已入库,不能删除！");
            }
           
            dC_OA_InStockIBLL.DeleteEntity(keyValue);

           return Success("删除成功！");
        }


        /// <summary>
        /// 入库操作
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>

        [HttpPost]
        [AjaxOnly]
        public ActionResult InStock(string keyValue)
        {
            //dC_OA_InStockIBLL.DeleteEntity(keyValue);

            var DC_OA_InStockData = dC_OA_InStockIBLL.GetDC_OA_InStockEntity(keyValue);
            if(DC_OA_InStockData.DC_OA_InStockState =="2")
            {
                return Fail("单据已入库,不能重复入库，入库失败！");
            }
            var DC_OA_InStockDetailsData = dC_OA_InStockIBLL.GetDC_OA_InStockDetailsList(DC_OA_InStockData.DC_OA_InStockId);

            List<DC_OA_InStockDetailsEntity> temps = new List<DC_OA_InStockDetailsEntity>();

            foreach(DC_OA_InStockDetailsEntity item in DC_OA_InStockDetailsData)
            {
                temps.Add(item);
            }

            dC_OA_InStockIBLL.InStock(keyValue, DC_OA_InStockData, temps);


            return Success("入库成功！");
        }


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_InStockDetailsList)
        {

            var DC_OA_InStockData = dC_OA_InStockIBLL.GetDC_OA_InStockEntity(keyValue);
            DC_OA_InStockEntity entity = strEntity.ToObject<DC_OA_InStockEntity>();
            if (DC_OA_InStockData!=null&&DC_OA_InStockData.DC_OA_InStockState == "2")
            {
                return Fail("单据已入库,不能修改！");
            }
            if(string.IsNullOrEmpty(keyValue))
            {
                iBll.UseRuleSeed("10009");
            }
            List<DC_OA_InStockDetailsEntity> dC_OA_InStockDetailsList = strdC_OA_InStockDetailsList.ToObject<List<DC_OA_InStockDetailsEntity>>();
            dC_OA_InStockIBLL.SaveEntity(keyValue,entity,dC_OA_InStockDetailsList);
            string msg = "保存成功！";

            if (entity.DC_OA_InStockState=="2")
            {
              
               dC_OA_InStockIBLL.InStock(entity.DC_OA_InStockId, entity, dC_OA_InStockDetailsList);
                msg = "入库成功！";
            }
            return Success(msg);
        }
        #endregion

    }
}
