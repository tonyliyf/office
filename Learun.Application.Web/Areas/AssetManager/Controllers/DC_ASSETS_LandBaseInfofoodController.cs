using Learun.Application.Base.SystemModule;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Util;
using Learun.Util.Excel;
using System.Data;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-08-16 09:48
    /// 描 述：粮食土地房屋信息管理
    /// </summary>
    public class DC_ASSETS_LandBaseInfofoodController : MvcControllerBase
    {
        private DC_ASSETS_HouseInfofoodIBLL dC_ASSETS_HouseInfofoodIBLL = new DC_ASSETS_HouseInfofoodBLL();
        private DC_ASSETS_BuildingBaseInfofoodIBLL dC_ASSETS_BuildingBaseInfoIBLL = new DC_ASSETS_BuildingBaseInfofoodBLL();
        private DC_ASSETS_LandBaseInfofoodIBLL dC_ASSETS_LandBaseInfoIBLL = new DC_ASSETS_LandBaseInfofoodBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();

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
        public ActionResult MapForm()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ExcelImport()
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
            var data = dC_ASSETS_LandBaseInfoIBLL.GetList(queryJson);
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
            paginationobj.rows = 20;
            var data = dC_ASSETS_LandBaseInfoIBLL.GetPageList(paginationobj, queryJson);
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
            var data = dC_ASSETS_LandBaseInfoIBLL.GetEntity(keyValue);
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
                DC_ASSETS_HouseInfoData.F_PictureAccessories_HouseInfo = DC_ASSETS_HouseInfoData.F_PictureAccessories;
                var DC_ASSETS_BuildingBaseInfoData = dC_ASSETS_BuildingBaseInfoIBLL.GetEntity(DC_ASSETS_HouseInfoData.F_BBIId);
                var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetEntity(DC_ASSETS_BuildingBaseInfoData.F_LBIId);
                var jsonData = new
                {
                    DC_ASSETS_HouseInfofood = DC_ASSETS_HouseInfoData,
                    DC_ASSETS_BuildingBaseInfofood = DC_ASSETS_BuildingBaseInfoData,
                    DC_ASSETS_LandBaseInfofood = DC_ASSETS_LandBaseInfoData
                };
                return Success(jsonData);

            }
            else
            {
                var DC_ASSETS_LandBaseInfoDatafood = dC_ASSETS_LandBaseInfoIBLL.GetEntity(keyValue);
                var DC_ASSETS_BuildingBaseInfoData = new DC_ASSETS_BuildingBaseInfofoodEntity();
                DC_ASSETS_BuildingBaseInfoData.F_LBIId = keyValue;
               var jsonData = new
                {

                    DC_ASSETS_LandBaseInfofood = DC_ASSETS_LandBaseInfoDatafood,
                    DC_ASSETS_BuildingBaseInfofood = DC_ASSETS_BuildingBaseInfoData
               };
                return Success(jsonData);

            }
        }


        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveTotalForm(string keyValue, string strLandEntity, string strBuildingEntity, string strHouseEntity)
        {
            DC_ASSETS_LandBaseInfofoodEntity Landentity = strLandEntity.ToObject<DC_ASSETS_LandBaseInfofoodEntity>();
            DC_ASSETS_BuildingBaseInfofoodEntity Buildingentity = strBuildingEntity.ToObject<DC_ASSETS_BuildingBaseInfofoodEntity>();
            DC_ASSETS_HouseInfofoodEntity Houseentity = strHouseEntity.ToObject<DC_ASSETS_HouseInfofoodEntity>();
            Houseentity.F_PictureAccessories = Houseentity.F_PictureAccessories_HouseInfo;
            if (keyValue.Length > 0)
            {
                var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfofoodIBLL.GetEntity(keyValue);
                if(DC_ASSETS_HouseInfoData!=null)
                {
                    Houseentity.F_HouseID = DC_ASSETS_HouseInfoData.F_HouseID;
                    Houseentity.F_BBIId = DC_ASSETS_HouseInfoData.F_BBIId;
                    Buildingentity.F_BBIId = DC_ASSETS_HouseInfoData.F_BBIId;

                }
              

                   
            }
            else
            {
                    if (string.IsNullOrEmpty(Buildingentity.F_LBIId))
                    {
                        var DC_ASSETS_LandBaseInfoData = dC_ASSETS_LandBaseInfoIBLL.GetDC_ASSETS_LandBaseInfofoodEntity(Landentity.F_LandName, Landentity.F_LandCertificate);
                        if (DC_ASSETS_LandBaseInfoData != null)
                        {
                            Landentity.F_LBIId = DC_ASSETS_LandBaseInfoData.F_LBIId;
                            Buildingentity.F_LBIId = Landentity.F_LBIId;
                        }
                    }
                    else
                    {
                        Landentity.F_LBIId = Buildingentity.F_LBIId;
                        var DC_ASSETS_BuildingBaseInfoEntityData = dC_ASSETS_BuildingBaseInfoIBLL.GetDC_ASSETS_BuildingBaseInfofoodEntity(Landentity.F_LBIId, Buildingentity.F_ConstructionName);
                        if (DC_ASSETS_BuildingBaseInfoEntityData != null)
                        {
                            Buildingentity.F_BBIId = DC_ASSETS_BuildingBaseInfoEntityData.F_BBIId;
                            Houseentity.F_BBIId = Buildingentity.F_BBIId;
                        }
                    }

              

            }
            dC_ASSETS_HouseInfofoodIBLL.SaveTotalEntity(keyValue, Landentity, Buildingentity, Houseentity);
            return Success("保存成功！");
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
            var DC_ASSETS_HouseInfoData = dC_ASSETS_HouseInfofoodIBLL.GetEntity(keyValue);
            if (DC_ASSETS_HouseInfoData != null)
            {
                dC_ASSETS_HouseInfofoodIBLL.DeleteEntity(keyValue);
                dC_ASSETS_BuildingBaseInfoIBLL.DeleteEntity(DC_ASSETS_HouseInfoData.F_BBIId);
            }
            else
            {

                dC_ASSETS_LandBaseInfoIBLL.DeleteEntity(keyValue);
            }
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
        public ActionResult SaveForm(string keyValue,DC_ASSETS_LandBaseInfofoodEntity entity)
        {
            dC_ASSETS_LandBaseInfoIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult Import(string keyValue)
        {


            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);
            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "粮食", true);
            //dC_ASSETS_LandBaseInfoIBLL.ImportEntity2NoBuilding(dt);
            dC_ASSETS_LandBaseInfoIBLL.ImportEntity(dt);
            //dC_ASSETS_HouseInfoIBLL.UpdateComHouse();
            return Success("导入成功");
        }
        #endregion

    }
}
