using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using Learun.Util.Operat;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Learun.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.03.09
    /// 描 述：主页控制器
    /// </summary>
    public class AssetHomeController : MvcControllerBase
    {
        private DC_ASSETS_BusStopBillboardsRentDetailIBLL iBLL = new DC_ASSETS_BusStopBillboardsRentDetailBLL();
        private DC_ASSETS_BusStopBillboardsIBLL boardsIBll = new DC_ASSETS_BusStopBillboardsBLL();
        private DC_ASSETS_HouseRentMainIBLL iBllMain = new DC_ASSETS_HouseRentMainBLL();
        private DC_ASSETS_HouseRentDetailIBLL iBllDetail = new DC_ASSETS_HouseRentDetailBLL();
        private DC_ASSETS_HouseInfoIBLL iBllhouse = new DC_ASSETS_HouseInfoBLL();
        

        private UserIBLL userBll = new UserBLL();

        #region 视图功能
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string userid)
        {
           
            string learn_UItheme = WebHelper.GetCookie("Learn_ADMS_V6.1_UItheme1");
            return View("AdminDefault");
            //switch (learn_UItheme)
            //{
            //    case "1":
            //        return View("AdminDefault");      // 经典版本
            //    case "2":
            //        return View("AdminAccordion");    // 手风琴版本
            //    case "3":
            //        return View("AdminWindos");       // Windos版本
            //    case "4":
            //        return View("AdminTop");          // 顶部菜单版本
            //    default:
            //        return View("AdminDefault");      // 经典版本
            //}
        }
        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop()
        {
            return View("AdminDesktopTemp");
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp()
        {
            return View();
        }
        #endregion

        private ICache cache = CacheFactory.CaChe();

        #region 清空缓存
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ClearRedis()
        {
            for (int i = 0; i < 16; i++)
            {
                cache.RemoveAll(i);
            }
            return Success("清空成功");
        }
        #endregion

        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleName, string moduleUrl)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 2;
            logEntity.F_OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Visit);
            logEntity.F_OperateAccount = userInfo.account;
            logEntity.F_OperateUserId = userInfo.userId;
            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "访问地址：" + moduleUrl;
            logEntity.WriteLog();
            return Success("ok");
        }
        //aaa
        [HttpPost]
        public ActionResult GetMapMarkers(int type = 0)
        {
            return Json(new MapService().GetMapMarkers(type));
        }
        /// <summary>
        /// 房屋租赁合同到期提醒
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTaskHouse() {
            List<Task> listtask = new List<Task>();
            Task task = null;
            //房屋合同临近到期，房屋合同到期

            var list = iBllMain.GetDetail_InfoList();
            foreach (var item in list) {

                item.F_RentStartTime = Convert.ToDateTime(item.F_RentStartTime);
                //获取起始年限
               //int num = item.F_RentStartTime.ToString().Split('/')[0].ToInt();
                //赋值并拼接

               // string time = (num + item.F_RentAge).ToString()+"/"+ item.F_RentStartTime.ToString().Split('/')[1]+"/"+ item.F_RentStartTime.ToString().Split('/')[2].Split(' ')[0];

               // string time = (num + item.F_RentAge).ToString()+"/"+ item.F_RentStartTime.ToString().Split('/')[1]+"/"+ item.F_RentStartTime.ToString().Split('/')[2].Split(' ')[0];

                //   string time = (num + item.F_RentAge).ToString()+"/"+ item.F_RentStartTime.ToString().Split('/')[1]+"/"+ item.F_RentStartTime.ToString().Split('/')[2].Split(' ')[0];

                //强转类型赋值

                item.F_RentEndTime = ((DateTime)item.F_RentStartTime).AddYears(item.F_RentAge.ToInt());




                if (item.F_RentEndTime.HasValue) {

                    //DateTime dtTemp = ((DateTime)item.F_RentEndTime);
                    //临近一个月，房屋合同到期，则提醒
                    if (item.F_RentEndTime >= DateTime.Now && item.F_RentEndTime < DateTime.Now.AddMonths(1) && !item.F_RentEndTime.IsEmpty())
                    {
                        task = new Task();
                        task.Content = string.Format("房屋合同临近到期提醒:{0}编号为：{1}的合同快到期了,请尽快处理，到期时间:{2},租赁人{3}- 电话{4}",
                           item.F_Location, item.F_ContractNo, ((DateTime)item.F_RentEndTime).ToString("yyyy-MM-dd"), item.F_Renter, item.F_RenterPhone);
                        task.Id = item.F_RentDetailId;
                        task.type = "3";
                        listtask.Add(task);

                    }
                    //租金到期提醒
                    if (item.F_RentEndTime <= DateTime.Now && !item.F_RentEndTime.IsEmpty())
                    {
                        task = new Task();
                        task.Content = string.Format("房屋合同到期提醒:{0}编号为：{1}的合同已到期了,请抓紧处理，到期时间:{2},租赁人{3}- 电话{4}",
                           item.F_Location, item.F_ContractNo, ((DateTime)item.F_RentEndTime).ToString("yyyy-MM-dd"), item.F_Renter, item.F_RenterPhone);
                        task.Id = item.F_RentDetailId;
                        task.type = "3";
                        listtask.Add(task);

                    }

                }
            }
            var jsonData = new
            {
                rows = listtask

            };
            return Success(jsonData);
        }
        /// <summary>
        /// 广告租赁合同到期提醒
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTaskboard()
        {
            List<Task> listtask = new List<Task>();
            Task task = null;
            //广告租赁合同临近到期，广告租赁合同合同到期

            var list = iBLL.GetList();
            foreach (var item in list) {

                item.F_RentStartTime = Convert.ToDateTime(item.F_RentStartTime);
                //获取起始年限
                //int num = item.F_RentStartTime.ToString().Split('/')[0].ToInt();
                //赋值并拼接

                //string time = (num + item.F_RentAge).ToString() + "/" + item.F_RentStartTime.ToString().Split('/')[1] + "/" + item.F_RentStartTime.ToString().Split('/')[2].Split(' ')[0];

                //string time = (num + item.F_RentAge).ToString() + "/" + item.F_RentStartTime.ToString().Split('/')[1] + "/" + item.F_RentStartTime.ToString().Split('/')[2].Split(' ')[0];

               // string time = (num + item.F_RentAge).ToString() + "/" + item.F_RentStartTime.ToString().Split('/')[1] + "/" + item.F_RentStartTime.ToString().Split('/')[2].Split(' ')[0];

                //强转类型赋值

                item.F_RentEndTime = ((DateTime)item.F_RentStartTime).AddYears(item.F_RentAge.ToInt());

                if (item.F_RentEndTime.HasValue) {
                    DateTime dtTemp = ((DateTime)item.F_RentEndTime);

                    //广告租赁合同临近一个月到期
                    if (((DateTime)item.F_RentEndTime).AddMonths(-1) >= DateTime.Now && DateTime.Now> item.F_RentEndTime)
                        {
                            DC_ASSETS_BusStopBillboardsEntity entity = boardsIBll.GetDC_ASSETS_BusStopBillboardsEntity(item.F_BSBId);
                            task = new Task();
                            task.Content = string.Format("广告租赁合同临近到期提醒:{0}{1}广告牌的合同快到期了,请尽快处理，到期时间:{2},租赁人{3}- 电话{4}",
                                entity.F_InstallationLocation, item.F_BillboardsName, ((DateTime)item.F_RentEndTime).ToString("yyyy-MM-dd"),item.F_Renter,item.F_RenterPhone);
                            task.Id = item.F_BSBRDId;
                            task.type = "4";
                            listtask.Add(task);

                        }
                    //广告租赁合同到期
                    if (item.F_RentEndTime >= DateTime.Now)
                    {
                        DC_ASSETS_BusStopBillboardsEntity entity = boardsIBll.GetDC_ASSETS_BusStopBillboardsEntity(item.F_BSBId);
                        task = new Task();
                        task.Content = string.Format("广告租赁合同到期提醒：{0}{1}广告牌的合同已到期了,请抓紧处理，到期时间:{2},租赁人{3}- 电话{4}",
                            entity.F_InstallationLocation, item.F_BillboardsName, ((DateTime)item.F_RentEndTime).ToString("yyyy-MM-dd"), item.F_Renter, item.F_RenterPhone);
                        task.Id = item.F_BSBRDId;
                        task.type = "4";
                        listtask.Add(task);
                    }

                }
            }

            var jsonData = new
            {
                rows = listtask

            };
            return Success(jsonData);
        }
        public ActionResult GetTaskData()
        {
            List<Task> listtask = new List<Task>();
            Task task = null;
            //房屋租金临近，房屋租金到期 广告租金临近，广告租金到期，

            var list = iBllDetail.GetHouseRentDetailInfoList();
            foreach(var item in list)
            {
                if(item.F_PlanPayDate.HasValue)
                {

                    DateTime dtTemp = ((DateTime)item.F_PlanPayDate);
                    //临近一个月，没有交款时间和金额，则提醒
                    if(dtTemp>=DateTime.Now&&dtTemp<DateTime.Now.AddMonths(1)&&item.F_ActualPrice<1&& item.F_PaymentDate.IsEmpty())
                    {
                        task = new Task();
                        task.Content = string.Format("房屋租金临近提醒:{0}{1}租金快到期了,请尽快处理，到期时间:{2},租赁人{3}- 电话{4}",
                           item.F_Address, item.F_HouseName, ((DateTime)item.F_PlanPayDate).ToString("yyyy-MM-dd"),item.F_Renter,item.F_RenterPhone);
                        task.Id = item.F_HRDId;
                        task.type = "1";
                        listtask.Add(task);

                    }
                    //租金到期提醒
                    if (dtTemp<= DateTime.Now &&item.F_ActualPrice < 1 && item.F_PaymentDate.IsEmpty())
                    {
                        task = new Task();
                        task.Content = string.Format("房屋租金到期提醒:{0}{1}租金已到期了,请抓紧处理，到期时间:{2},租赁人{3}- 电话{4}",
                           item.F_Address, item.F_HouseName, ((DateTime)item.F_PlanPayDate).ToString("yyyy-MM-dd"), item.F_Renter, item.F_RenterPhone);
                        task.Id = item.F_HRDId;
                        task.type = "1";
                        listtask.Add(task);

                    }

                }


            }

          //  var list = iBllDetail.GetHouseRentDetailList();
            //foreach (var item in list)
            //{
            //    //房屋租金临近提醒
            //    if (item.F_RentReminderDate <= DateTime.Now && item.F_ExpireReminderDate > DateTime.Now)
            //    {
            //        DC_ASSETS_HouseInfoEntity houseinfo = iBllhouse.GetDC_ASSETS_HouseInfoEntity(item.F_HouseID);
            //        task = new Task();
            //        task.Content = string.Format("房屋租金临近提醒:{0}{1}租金快到期了,请尽快处理，到期时间:{2}",
            //           houseinfo.F_BuildingAddress, item.F_HouseName, ((DateTime)item.F_ExpireReminderDate).ToString("yyyy-MM-dd"));
            //        task.Id = item.F_HRDId;
            //        task.type = "1";
            //        listtask.Add(task);

            //    }
            //}

            //foreach (var item in list)
            //{
            //    //房屋租金到期提醒
            //    if (item.F_ExpireReminderDate <= DateTime.Now)
            //    {
            //        DC_ASSETS_HouseInfoEntity houseinfo = iBllhouse.GetDC_ASSETS_HouseInfoEntity(item.F_HouseID);
            //        task = new Task();
            //        task.Content = string.Format("房屋租金到期提醒:{0}{1}租金已到期了,请抓紧处理，到期时间:{2}",
            //           houseinfo.F_BuildingAddress, item.F_HouseName, ((DateTime)item.F_ExpireReminderDate).ToString("yyyy-MM-dd"));
            //        task.Id = item.F_HRDId;
            //        task.type = "1";
            //        listtask.Add(task);
            //    }
            //}

            var list1 = iBLL.GetBusStopBillboardsRentList();
            foreach (var item in list1)
            {
                //租金临近提醒日期
                if (item.F_RentReminderDate <= DateTime.Now && item.F_ExpireReminderDate > DateTime.Now)
                {
                    DC_ASSETS_BusStopBillboardsEntity entity = boardsIBll.GetDC_ASSETS_BusStopBillboardsEntity(item.F_BSBId);
                    task = new Task();
                    task.Content = string.Format("广告租金临近提醒:{0}{1}租金快到期了,请尽快处理，到期时间:{2}",
                        entity.F_InstallationLocation, item.F_BillboardsName, ((DateTime)item.F_ExpireReminderDate).ToString("yyyy-MM-dd"));
                    task.Id = item.F_BSBRDId;
                    task.type = "2";
                    listtask.Add(task);

                }
            }


            foreach (var item in list1)
            {
                //租金到期提醒日期
                if (item.F_ExpireReminderDate <= DateTime.Now)
                {
                    DC_ASSETS_BusStopBillboardsEntity entity = boardsIBll.GetDC_ASSETS_BusStopBillboardsEntity(item.F_BSBId);
                    task = new Task();
                    task.Content = string.Format("广告租金到期提醒：{0}{1}租金已到期了,请抓紧处理，到期时间:{2}",
                        entity.F_InstallationLocation, item.F_BillboardsName, ((DateTime)item.F_ExpireReminderDate).ToString("yyyy-MM-dd"));
                    task.Id = item.F_BSBRDId;
                    task.type = "2";
                    listtask.Add(task);
                }

            }

            var jsonData = new
            {
                rows = listtask

            };
            return Success(jsonData);


        }
    }

    public class Task
    {
        public string Content { get; set; }
        public string Id { get; set; }
        public string type { get; set; }
    }
}