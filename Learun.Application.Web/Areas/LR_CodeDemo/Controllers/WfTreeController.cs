using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Learun.Application.Base.AuthorizeModule;
using System.Text;
using Learun.Application.Organization;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-09 15:49
    /// 描 述：DC_OA__PartyBranch
    /// </summary>
    public class WfTreeController : MvcControllerBase
    {
        private UserRelationIBLL userRelationIBLL = new UserRelationBLL();
        private DepartmentIBLL departmentIBLL = new DepartmentBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private UserIBLL userIBLL = new UserBLL();
        private PostBLL postBll = new PostBLL();
        WfTreeService service = new WfTreeService();
        public ActionResult TreeView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetTreeData()
        {
            return Json(service.GetTreeData());
        }
        [HttpPost]
        public ActionResult GetUserIdsByPostId(string postId)
        {
            List<string> list = new List<string>();
            List<string> postIdList = postId.Split(',').ToList();
            //var data = userRelationIBLL.GetUserIdList(postIdList);
            var data = userIBLL.GetAllList().Where(c => postIdList.Contains(c.F_DepartmentId)).ToList();
            foreach (var user in data)
            {
                list.Add(user.F_UserId);
            }
            list = list.Distinct().ToList();
            return Json(list);
        }


        public List<TreeModel> GetDept()
        {
            var Companydata = companyIBLL.GetList();
            var DeptData = departmentIBLL.GetList();
            List<TreeModel> list = new List<TreeModel>();
            TreeModel node;
            foreach (var item in Companydata)
            {
                node = new TreeModel();
                node.id = item.F_CompanyId;
                node.text = item.F_FullName;
                node.title = item.F_FullName;
                node.parentId = item.F_ParentId;
                if (item.F_ParentId=="0")
                {
                    node.isexpand = true;
                }
                list.Add(node);
            }

            foreach (var item in DeptData)
            {
                node = new TreeModel();

                node.text = item.F_FullName;
                node.title = item.F_FullName;
                node.id = item.F_DepartmentId;
                node.parentId = item.F_ParentId;
                if (item.F_ParentId == "0")
                {
                    node.parentId = item.F_CompanyId;
                }

                list.Add(node);
            }

            return list;
        }
        /// <summary>
        /// 获得部门树
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDeptTree()
        {
            List<TreeModel> list = GetDept();
            return Success(list.ToTree("0"));

        }


        /// <summary>
        /// 获得岗位树
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPostTree()
        {
            var Companydata = companyIBLL.GetList();
            var DeptData = departmentIBLL.GetList();
            var PostData = postBll.GetList();
            List<TreeModel> list = new List<TreeModel>();
            TreeModel node;
            foreach (var item in Companydata)
            {
                node = new TreeModel();
                node.id = item.F_CompanyId;
                node.text = item.F_FullName;
                node.title = item.F_FullName;
                node.parentId = item.F_ParentId;
                list.Add(node);
            }

            //foreach (var item in DeptData)
            //{
            //    node = new TreeModel();
            //    node.text = item.F_FullName;
            //    node.title = item.F_FullName;
            //    node.id = item.F_DepartmentId;
            //    node.parentId = item.F_ParentId;
            //    if (item.F_ParentId == "0")
            //    {
            //        node.parentId = item.F_CompanyId;
            //    }

            //    list.Add(node);
            //}

            foreach(var item in PostData)
            {
                node = new TreeModel();
                node.text = item.F_Name;
                node.title = item.F_Name;
                node.id = item.F_PostId;
                node.parentId = item.F_ParentId;
               if (item.F_ParentId == "0")
                {
                    node.parentId = item.F_CompanyId;
                }
                list.Add(node);
            }
            return Success(list.ToTree("0"));

        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserTree()
        {

            List<TreeModel> list = GetDept();
            var UserData = userIBLL.GetAllList();
            TreeModel node;

            foreach (var item in UserData)
            {
                node = new TreeModel();
                node.text = item.F_RealName;
                node.title = item.F_RealName;
                node.id = item.F_UserId;
                node.parentId = item.F_DepartmentId;
                list.Add(node);
            }

            return Success(list.ToTree("0"));

        }


    }
}
