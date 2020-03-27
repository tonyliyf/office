using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Organization;
using System.Linq;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 16:28
    /// 描 述：DC_OA_OfficeWoodsReply
    /// </summary>
    public class DC_OA_OfficeWoodsReplyController : MvcControllerBase
    {
        private DC_OA_OfficeWoodsReplyIBLL dC_OA_OfficeWoodsReplyIBLL = new DC_OA_OfficeWoodsReplyBLL();
        private DC_OA_OfficeWoodsIBLL dC_OA_OfficeWoodsIBLL = new DC_OA_OfficeWoodsBLL();
        private UserIBLL userIbll = new UserBLL();

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
        [HttpGet]
        public ActionResult TotalForm()
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
            var data = dC_OA_OfficeWoodsReplyIBLL.GetPageList(paginationobj, queryJson);
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
        public ActionResult GetDC_OA_OfficeWoodsReplyDetailTotalListByMonth(string month)
        {
            double sum;
            return Success(new
            {
                table = dC_OA_OfficeWoodsReplyIBLL.GetDC_OA_OfficeWoodsReplyDetailTotalListByMonth(month, out sum),
                sum = sum
            });
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var DC_OA_OfficeWoodsReplyData = dC_OA_OfficeWoodsReplyIBLL.GetDC_OA_OfficeWoodsReplyEntity(keyValue);
            var DC_OA_OfficeWoodsReplyDetailData = dC_OA_OfficeWoodsReplyIBLL.GetDC_OA_OfficeWoodsReplyDetailList(DC_OA_OfficeWoodsReplyData.F_OfficeWoodsReplyId);
            var jsonData = new
            {
                DC_OA_OfficeWoodsReply = DC_OA_OfficeWoodsReplyData,
                DC_OA_OfficeWoodsReplyDetail = DC_OA_OfficeWoodsReplyDetailData,
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
            var DC_OA_OfficeWoodsReplyData = dC_OA_OfficeWoodsReplyIBLL.GetEntityByProcessId(processId);
            IEnumerable<DC_OA_OfficeWoodsReplyDetailEntity> DC_OA_OfficeWoodsReplyDetailData = null;
            if (DC_OA_OfficeWoodsReplyData != null)
            {
                DC_OA_OfficeWoodsReplyDetailData = dC_OA_OfficeWoodsReplyIBLL.GetDC_OA_OfficeWoodsReplyDetailList(DC_OA_OfficeWoodsReplyData.F_OfficeWoodsReplyId);
            }
            var jsonData = new
            {
                DC_OA_OfficeWoodsReply = DC_OA_OfficeWoodsReplyData,
                DC_OA_OfficeWoodsReplyDetail = DC_OA_OfficeWoodsReplyDetailData,
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
            dC_OA_OfficeWoodsReplyIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_OfficeWoodsReplyDetailList)
        {
            DC_OA_OfficeWoodsReplyEntity entity = strEntity.ToObject<DC_OA_OfficeWoodsReplyEntity>();
            List<DC_OA_OfficeWoodsReplyDetailEntity> dC_OA_OfficeWoodsReplyDetailList = strdC_OA_OfficeWoodsReplyDetailList.ToObject<List<DC_OA_OfficeWoodsReplyDetailEntity>>();
            DC_OA_OfficeWoodsEntity woods = null;
            var list = userIbll.GetAllList().Where(i => i.F_DepartmentId == entity.F_CurrentDeptId);
            double dCheckMoney = list.Count() * 120;//预算金额
            double dTotalMoney = 0;

            foreach (DC_OA_OfficeWoodsReplyDetailEntity item in dC_OA_OfficeWoodsReplyDetailList)
            {
                woods = dC_OA_OfficeWoodsIBLL.GetDC_OA_OfficeWoodsEntity(item.F_WoodId);
                dTotalMoney += (double)item.F_Nums * (double)woods.DC_Price;
            }
            if(dTotalMoney>dCheckMoney)
            {
                return Fail(string.Format("超过部门办公用品预算金额{0}元,提交失败!", dCheckMoney));
            }
            entity.F_SumMoney = dTotalMoney;
            dC_OA_OfficeWoodsReplyIBLL.SaveEntity(keyValue, entity, dC_OA_OfficeWoodsReplyDetailList);
            return Success("保存成功！");
        }
        #endregion

    }
}
