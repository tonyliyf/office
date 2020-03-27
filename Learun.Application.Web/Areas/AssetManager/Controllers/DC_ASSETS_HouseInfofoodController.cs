using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Util;
using System.Data;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 10:22
    /// 描 述：DC_ASSETS_HouseInfofood
    /// </summary>
    public class DC_ASSETS_HouseInfofoodController : MvcControllerBase
    {
        private DC_ASSETS_HouseInfofoodIBLL dC_ASSETS_HouseInfofoodIBLL = new DC_ASSETS_HouseInfofoodBLL();
        private DC_ASSETS_BuildingBaseInfofoodIBLL dC_ASSETS_BuildingBaseInfoIBLL = new DC_ASSETS_BuildingBaseInfofoodBLL();
        private DC_ASSETS_LandBaseInfofoodIBLL dC_ASSETS_LandBaseInfoIBLL = new DC_ASSETS_LandBaseInfofoodBLL();

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
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList( string queryJson )
        {
            var data = dC_ASSETS_HouseInfofoodIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_HouseInfofoodIBLL.GetPageList(paginationobj, queryJson);
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
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var data = dC_ASSETS_HouseInfofoodIBLL.GetEntity(keyValue);
            return Success(data);
        }


        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTotalHouseInfo(string keyValue)
        {
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfofoodIBLL.GetEntity(keyValue);
            if (DC_ASSETS_HouseInfoData != null)
            {
                var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetEntity(DC_ASSETS_HouseInfoData.F_BBIId);
                var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetEntity(DC_ASSETS_BuildingBaseInfoData.F_LBIId);
                var jsonData = new
                {
                    DC_ASSETS_HouseInfo = DC_ASSETS_HouseInfoData,
                    DC_ASSETS_BuildingBaseInfo = DC_ASSETS_BuildingBaseInfoData,
                    DC_ASSETS_LandBaseInfo = DC_ASSETS_LandBaseInfoData
                };
                return Success(jsonData);

            }
            else
            {
                var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetEntity(keyValue);
                var jsonData = new
                {
                   
                    DC_ASSETS_LandBaseInfo = DC_ASSETS_LandBaseInfoData
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
            dC_ASSETS_HouseInfofoodIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue,DC_ASSETS_HouseInfofoodEntity entity)
        {
            dC_ASSETS_HouseInfofoodIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        #endregion

    }
}
