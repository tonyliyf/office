using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.ProjectManager;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.ProjectManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-03 15:13
    /// 描 述：项目评价科目
    /// </summary>
    public class DC_EngineProject_EvaluationSubjectController : MvcControllerBase
    {
        private DC_EngineProject_EvaluationSubjectIBLL dC_EngineProject_EvaluationSubjectIBLL = new DC_EngineProject_EvaluationSubjectBLL();

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
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = dC_EngineProject_EvaluationSubjectIBLL.GetPageList(paginationobj, queryJson).OrderBy(i => i.F_Sort) ;
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
            var DC_EngineProject_EvaluationSubjectData = dC_EngineProject_EvaluationSubjectIBLL.GetDC_EngineProject_EvaluationSubjectEntity( keyValue );
            var jsonData = new {
                DC_EngineProject_EvaluationSubject = DC_EngineProject_EvaluationSubjectData,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree()
        {
            var data = dC_EngineProject_EvaluationSubjectIBLL.GetTree();
            return Success(data);
        }

        /// <summary>
        /// 获取左侧树形数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetSubjectTree()
        {
            var data = dC_EngineProject_EvaluationSubjectIBLL.GetSubjectTree();
            return Success(data);
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
            dC_EngineProject_EvaluationSubjectIBLL.DeleteEntity(keyValue);
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
            DC_EngineProject_EvaluationSubjectEntity entity = strEntity.ToObject<DC_EngineProject_EvaluationSubjectEntity>();
            dC_EngineProject_EvaluationSubjectIBLL.SaveEntity(keyValue,entity);
            return Success("保存成功！");
        }
        #endregion

    }
}
