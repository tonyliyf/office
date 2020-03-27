using Learun.Application.OA.LR_StampManage;
using Learun.Util;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_OAModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 敏捷开发框架
    /// Copyright (c) 2013-2017 信息技术有限公司
    /// 创建人：-框架开发组（王飞）
    /// 日 期：2018.11.19
    /// 描 述：印章管理
    /// </summary>
    public class LR_StampInfoController : MvcControllerBase
    {
        private LR_StampManageIBLL lr_StampManageIBLL = new LR_StampManageBLL();


        #region 视图功能 
        /// <summary>
        /// 管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult StampDetailIndex()
        {
            return View();
        }

        public ActionResult EqualForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet] [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = lr_StampManageIBLL.GetPageList(paginationobj, queryJson);
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
        /// 获取所有的印章信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string keyword)
        {
            var data = lr_StampManageIBLL.GetList(keyword);
            return Success(data);
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetImg(string keyValue)
        {
           lr_StampManageIBLL.GetImg(keyValue);
            return Success("获取成功！");
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 保存印章
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, LR_StampManageEntity entity)
        {
            lr_StampManageIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功。");

}
        /// <summary>
        /// 删除印章
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            lr_StampManageIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        #endregion

        #region 扩展方法
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">印章实体</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadFile(string keyValue, LR_StampManageEntity entity)
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return HttpNotFound();
            }

            string FileEextension = Path.GetExtension(files[0].FileName);
            entity.F_ImgFile = FileEextension;//图片后缀名
            lr_StampManageIBLL.SaveEntity(keyValue, entity);

            string fileHeadImg = Config.GetValue("Stamp");
            string fullFileName = string.Format("{0}/{1}{2}", fileHeadImg, entity.F_StampId, entity.F_ImgFile);

            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);

            return Success("保存成功。");
        }

        /// <summary>
        /// 启用/停用
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="state">状态 1启用 0禁用</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult UpDateSate(string keyValue, int state)
        {
            lr_StampManageIBLL.UpdateState(keyValue, state);
            return Success((state == 1 ? "启用" : "禁用") + "成功！");
        }
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult EqualForm(string keyValue, string Password)
        {
            var result = lr_StampManageIBLL.EqualPassword(keyValue, Password);
            if (result)
            {
                return Success("密码验证成功！");
            }
            else
            {
                return Fail("密码不正确！");
            }

        }
        #endregion
    }
}