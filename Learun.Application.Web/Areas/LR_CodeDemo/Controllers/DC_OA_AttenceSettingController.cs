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
    /// 日 期：2019-01-16 17:54
    /// 描 述：考勤参数设置
    /// </summary>
    public class DC_OA_AttenceSettingController : MvcControllerBase
    {
        private DC_OA_AttenceSettingIBLL dC_OA_AttenceSettingIBLL = new DC_OA_AttenceSettingBLL();
        private DC_OA_AttenceRecordIBLL dC_OA_AttenceRecord = new DC_OA_AttenceRecordBLL();

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
            string Msg = string.Empty;
            dC_OA_AttenceRecord.SaveRecord(LoginUserInfo.Get(), "114.241133", "30.601936",ref Msg);


            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_OA_AttenceSettingIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_AttenceSettingData = dC_OA_AttenceSettingIBLL.GetDC_OA_AttenceSettingEntity( keyValue );
            var jsonData = new {
                DC_OA_AttenceSetting = DC_OA_AttenceSettingData,
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
            dC_OA_AttenceSettingIBLL.DeleteEntity(keyValue);
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
            DC_OA_AttenceSettingEntity entity = strEntity.ToObject<DC_OA_AttenceSettingEntity>();
            dC_OA_AttenceSettingIBLL.SaveEntity(keyValue,entity);
            return Success("保存成功！");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult UpdateState(string keyValue)
        {
            dC_OA_AttenceSettingIBLL.UpdateStateEntity(keyValue);
            return Success("启用成功！");
        }

        
        #endregion

    }
}
