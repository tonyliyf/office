using Learun.Application.OA.Schedule;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_OAModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.7.11
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleController : MvcControllerBase
    {
        private ScheduleIBLL scheduleIBLL = new ScheduleBLL();

        #region 视图功能
        /// <summary>
        /// 管理页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取日程数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetList()
        {
            List<Hashtable> data = new List<Hashtable>();
            UserInfo user = LoginUserInfo.Get();
            var list = scheduleIBLL.GetList().Where(i => i.F_CreateUserId == user.userId);
            foreach (ScheduleEntity entity in list)
            {
                Hashtable ht = new Hashtable();
                ht["id"] = entity.F_ScheduleId;
                ht["title"] = entity.F_ScheduleContent;
                ht["end"] = (entity.F_EndDate.ToDate().ToString("yyyy-MM-dd") + " " + entity.F_EndTime.Substring(0, 2) + ":" + entity.F_EndTime.Substring(2, 2)).ToDate().ToString("yyyy-MM-dd HH:mm:ss");
                ht["start"] = (entity.F_StartDate.ToDate().ToString("yyyy-MM-dd") + " " + entity.F_StartTime.Substring(0, 2) + ":" + entity.F_StartTime.Substring(2, 2)).ToDate().ToString("yyyy-MM-dd HH:mm:ss");
                ht["allDay"] = false;
                data.Add(ht);
            }
            return ToJsonResult(data);
        }


        [HttpGet]
        public ActionResult GetCanlderList(string days)
        {
            List<Hashtable> data = new List<Hashtable>();
            UserInfo user = LoginUserInfo.Get();
            var list = scheduleIBLL.GetList().Where(i => i.F_CreateUserId == user.userId);
            foreach (ScheduleEntity entity in list)
            {
                if (entity.F_StartDate.ToDate().ToString("yyyyMMdd") == days)
                {
                    Hashtable ht = new Hashtable();
                    ht["id"] = entity.F_ScheduleId;
                    ht["title"] = entity.F_ScheduleContent;
                    // ht["end"] = (entity.F_EndDate.ToDate().ToString("yyyy-MM-dd") + " " + entity.F_EndTime.Substring(0, 2) + ":" + entity.F_EndTime.Substring(2, 2)).ToDate().ToString("yyyy-MM-dd HH:mm:ss");
                    ht["start"] = entity.F_StartDate.ToDate().ToString("yyyy-MM-dd HH:MM");
                    ht["allDay"] = false;
                    data.Add(ht);
                }
            }
            return Success(data);
        }


        [HttpPost]
        public ActionResult AddCanlderList(string days,string JosnData)
        {
            List<Hashtable> data = new List<Hashtable>();
            UserInfo user = LoginUserInfo.Get();
            string daystemp = days.Substring(0, 4) + "-" + days.Substring(4, 2) + "-" + days.Substring(6, 2);
            var list = scheduleIBLL.GetList().Where(i => i.F_CreateUserId == user.userId);
            IEnumerable<Task> listtask = JosnData.ToObject<IEnumerable<Task>>();
            var listSchedule = new List<ScheduleEntity>();
            foreach(var item in listtask)
            {
                ScheduleEntity entity = new ScheduleEntity();
                entity.F_CreateUserId = user.userId;
                entity.F_CreateDate = DateTime.ParseExact(days, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                entity.F_StartDate = item.start;
                entity.F_ScheduleContent = item.Title;
                listSchedule.Add(entity);
            }

            scheduleIBLL.UpdateEntity(daystemp, user.userId, listSchedule);


            return Success("操作成功");
        }
        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = scheduleIBLL.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            //scheduleIBLL.RemoveForm(keyValue);
            new RepositoryFactory().BaseRepository().ExecuteBySql("delete LR_OA_Schedule where F_ScheduleId = '" + keyValue+"'");
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, ScheduleEntity entity)
        {
            scheduleIBLL.SaveForm(keyValue, entity);
            return Success("操作成功。");
        }
        #endregion
    }

    public class Task
    {
        public string Title { get; set; }
        public DateTime start { get; set; }

    }
}