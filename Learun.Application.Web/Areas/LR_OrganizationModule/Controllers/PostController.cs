using Learun.Application.Organization;
using Learun.Util;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_OrganizationModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.03.09
    /// 描 述：岗位管理
    /// </summary>
    public class PostController : MvcControllerBase
    {
        private PostIBLL postIBLL = new PostBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        #region 获取视图
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 岗位选择页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectForm() {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取岗位列表信息
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string companyId, string keyword,string departmentId)
        {
            var data = postIBLL.GetList(companyId, keyword, departmentId);
            return Success(data);
        }
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree(string companyId)
        {
            var data = postIBLL.GetTree(companyId);
            return Success(data);
        }
        /// <summary>
        /// 获取岗位名称
        /// </summary>
        /// <param name="keyValue">岗位主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetEntityName(string keyValue)
        {
            if (keyValue == "0")
            {
                return SuccessString("");
            }
            var data = postIBLL.GetEntity(keyValue);
            return SuccessString(data.F_Name);
        }
        /// <summary>
        /// 获取岗位实体数据
        /// </summary>
        /// <param name="keyValue">岗位主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetEntity(string keyValue)
        {
            var data = postIBLL.GetEntity(keyValue);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, PostEntity entity)
        {
            postIBLL.SaveEntity(keyValue, entity);
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
            postIBLL.VirtualDelete(keyValue);
            return Success("删除成功！");
        }


        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPostList()
        {
            var data = postIBLL.GetList().Where(i=>i.F_DeleteMark ==0);
            List<PostEntity> list = new List<PostEntity>();
            string companyname = string.Empty;
            string deptname = string.Empty;
            foreach (var item in data)
            {
                 companyname = string.Empty;
                 deptname = string.Empty;
                CompanyEntity companyEntity = companyIBLL.GetEntity(item.F_CompanyId);
                DepartmentEntity departEntity = departmentIBLL.GetEntity(item.F_DepartmentId);
                if(companyEntity!=null)
                {
                    companyname = companyIBLL.GetEntity(item.F_CompanyId).F_FullName;
                }
                if(departEntity != null)
                {
                    deptname = departmentIBLL.GetEntity(item.F_DepartmentId).F_FullName;
                }
                                     
                item.F_Name = companyname + "-" + deptname + "-" + item.F_Name;
                list.Add(item);
            }
            return Success(list);
        }

        public ActionResult GetEntityNameByUserId(string userid=null)
        {
           UserInfo userInfo = LoginUserInfo.Get();
            if (userid == null)
            {
               userid= userInfo.userId;


            }
            var PostList = postIBLL.GetPostList(userid);

            string temp = string.Empty;

            foreach(PostEntity item in PostList)
            {
                temp += item.F_Name;
                temp += ",";
            }
            
            if(temp!=string.Empty)
            {
                return SuccessString(temp.Substring(0,temp.Length-1));

            }
            else
            {
                return SuccessString(temp);
            }
        }



        #endregion
    }
}