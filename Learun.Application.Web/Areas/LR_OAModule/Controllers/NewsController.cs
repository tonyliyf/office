using Learun.Application.OA;
using Learun.DataBase.Repository;
using Learun.Util;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Learun.Application.Web.Areas.LR_OAModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：新闻管理
    /// </summary>
    public class NewsController : MvcControllerBase
    {
        private NewsIBLL newsIBLL = new NewsBLL();

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

        public ActionResult ShowDetail(string key)
        {
            var data = newsIBLL.GetEntity(key);

            ViewBag.content = WebHelper.HtmlDecode(data.F_NewsContent);
            ViewBag.title = data.F_FullHead;
            ViewBag.author = data.F_AuthorName;
            if (data.F_ReleaseTime.HasValue)
            {
                ViewBag.date = data.F_ReleaseTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
            }
            else
            {
                ViewBag.date = "";
            }

            return View();

        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="categoryId">类型</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = newsIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }

        public ActionResult GetPageListByCategory(string typeid)
        {
            var fac = new RepositoryFactory();
            List<string> categoryList = fac.BaseRepository().FindList<string>("select distinct F_CategoryId from LR_OA_News where F_TypeId=" + typeid).ToList();
            Dictionary<string, List<NewsEntity>> result = new Dictionary<string, List<NewsEntity>>();
            foreach (var item in categoryList)
            {
                var templist = fac.BaseRepository().FindList<NewsEntity>(@"select top 5 [F_NewsId],[F_FullHead], CONVERT(varchar(100), F_ReleaseTime, 20) as [F_Category] 
                    from LR_OA_News where F_CategoryId = @category order by F_ReleaseTime desc",
                    new
                    {
                        category = item
                    }).ToList();
                result.Add(item, templist);
            }
            return Json(result);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public ActionResult GetEntity(string keyValue)
        {
            var data = newsIBLL.GetEntity(keyValue);
            data.F_NewsContent = WebHelper.HtmlDecode(data.F_NewsContent);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AjaxOnly, ValidateInput(false)]
        public ActionResult SaveForm(string keyValue, NewsEntity entity)
        {
            entity.F_NewsContent = entity.F_NewsContent;
            newsIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }
        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            newsIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        #endregion
    }
}