using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.AssetManager;
using System.Web.Mvc;
using System.Collections.Generic;
using Learun.Application.Message;
using System;
using System.Globalization;

namespace Learun.Application.Web.Areas.AssetManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-23 10:20
    /// 描 述：DC_ASSETS_BusStopBillboardsRentIncome
    /// </summary>
    public class DC_ASSETS_BusStopBillboardsRentIncomeController : MvcControllerBase
    {
        private DC_ASSETS_BusStopBillboardsRentIncomeIBLL dC_ASSETS_BusStopBillboardsRentIncomeIBLL = new DC_ASSETS_BusStopBillboardsRentIncomeBLL();

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
        public ActionResult GetPageList(string pagination, string queryJson,string F_BSBRDId)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_ASSETS_BusStopBillboardsRentIncomeIBLL.GetPageList(paginationobj, queryJson, F_BSBRDId);
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
            var DC_ASSETS_BusStopBillboardsRentIncomeData = dC_ASSETS_BusStopBillboardsRentIncomeIBLL.GetDC_ASSETS_BusStopBillboardsRentIncomeEntity( keyValue );
            var jsonData = new {
                DC_ASSETS_BusStopBillboardsRentIncome = DC_ASSETS_BusStopBillboardsRentIncomeData,
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
            dC_ASSETS_BusStopBillboardsRentIncomeIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm( string keyValue, string strEntity, string F_BSBRDId)
        {
            DC_ASSETS_BusStopBillboardsRentIncomeEntity entity = strEntity.ToObject<DC_ASSETS_BusStopBillboardsRentIncomeEntity>();

            if (F_BSBRDId!="") {
                entity.F_BSBRDId = F_BSBRDId;

            }
            dC_ASSETS_BusStopBillboardsRentIncomeIBLL.SaveEntity(keyValue,entity);
            DC_ASSETS_BusStopBillboardsRentDetailEntity entiy = dC_ASSETS_BusStopBillboardsRentIncomeIBLL.GetDC_ASSETS_BusStopBillboardsRentDetailEntity(F_BSBRDId);
            string data = entiy.F_RentReminderDate.ToString().Split(' ')[0];
            string data1 = data.Split('/')[0];
            string data2 = data.Split('/')[1];
            string data3 = data.Split('/')[2];
            data1 = (Convert.ToInt32(data1) + 1).ToString() + "/" + data2 + "/" + data3;
            string data4 = entiy.F_ExpireReminderDate.ToString().Split(' ')[0];
            string data5 = data.Split('/')[0];
            string data6 = data.Split('/')[1];
            string data7 = data.Split('/')[2];
            data4 = (Convert.ToInt32(data5) + 1).ToString()+"/"+ data6+"/"+ data7;
            entiy.F_RentReminderDate = data1.ToDate();
            entiy.F_ExpireReminderDate = data4.ToDate();
            dC_ASSETS_BusStopBillboardsRentIncomeIBLL.SaveEntity1(entiy);
            return Success("保存成功！");
        }

        [HttpPost]
        [AjaxOnly]
        public void SendOsNoticeMsg()
        {
            var data = dC_ASSETS_BusStopBillboardsRentIncomeIBLL.GetPageList1();
            string msg = "";


            UserInfo user = LoginUserInfo.Get();
            foreach (DC_ASSETS_BusStopBillboardsEntity obj in data)
            {

                msg = "广告牌:" + obj.F_BillboardsName + "一月后即将到期！";

                new LR_StrategyInfoBLL().SendMessageByUserIds("BusStopBillboardsRentIncome", msg, user.userId);
                msg = "";
            }



        }
        #endregion

    }
}
