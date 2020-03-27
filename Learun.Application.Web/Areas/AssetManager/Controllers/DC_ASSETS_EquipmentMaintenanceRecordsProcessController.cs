using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-18 17:47
    /// 描 述：DC_ASSETS_EquipmentMaintenanceRecordsProcess
    /// </summary>
    public class DC_ASSETS_EquipmentMaintenanceRecordsProcessController : MvcControllerBase
    {
        private DC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL dC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL = new DC_ASSETS_EquipmentMaintenanceRecordsProcessBLL();

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
        public ActionResult GetPageList(string pagination, string queryJson, string PID)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL.GetPageList(paginationobj, queryJson, PID);
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
            var DC_ASSETS_EquipmentMaintenanceRecordsProcessData = dC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL.GetDC_ASSETS_EquipmentMaintenanceRecordsProcessEntity(keyValue);
            var DC_ASSETS_EquipmentMaintenancePartsUseData = dC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL.GetDC_ASSETS_EquipmentMaintenancePartsUseList(DC_ASSETS_EquipmentMaintenanceRecordsProcessData.F_EMRPId);
            var jsonData = new
            {
                DC_ASSETS_EquipmentMaintenanceRecordsProcess = DC_ASSETS_EquipmentMaintenanceRecordsProcessData,
                DC_ASSETS_EquipmentMaintenancePartsUse = DC_ASSETS_EquipmentMaintenancePartsUseData,
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
            dC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_ASSETS_EquipmentMaintenancePartsUseList, string PID)
        {
            DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity entity = strEntity.ToObject<DC_ASSETS_EquipmentMaintenanceRecordsProcessEntity>();
            List<DC_ASSETS_EquipmentMaintenancePartsUseEntity> dC_ASSETS_EquipmentMaintenancePartsUseList = strdC_ASSETS_EquipmentMaintenancePartsUseList.ToObject<List<DC_ASSETS_EquipmentMaintenancePartsUseEntity>>();
           
            dC_ASSETS_EquipmentMaintenanceRecordsProcessIBLL.SaveEntity(keyValue, entity, dC_ASSETS_EquipmentMaintenancePartsUseList, PID);
            return Success("保存成功！");
        }
        #endregion

    }
}
