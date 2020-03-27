using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.ProjectManager;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using Learun.Util.Excel;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.Web.Areas.ProjectManager.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-30 15:42
    /// 描 述：项目考勤记录
    /// </summary>
    public class ProjectAttenceRecordController : MvcControllerBase
    {
        private ProjectAttenceRecordIBLL projectAttenceRecordIBLL = new ProjectAttenceRecordBLL();
        private AnnexesFileIBLL annexesFileIBLL = new AnnexesFileBLL();
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
        /// 导入页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExcelImport()
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
            var data = projectAttenceRecordIBLL.GetPageList(paginationobj, queryJson);
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
            var Project_AttenceRecordData = projectAttenceRecordIBLL.GetProject_AttenceRecordEntity( keyValue );
            var DC_EngineProject_ProjectInfoData = projectAttenceRecordIBLL.GetDC_EngineProject_ProjectInfoEntity( Project_AttenceRecordData.F_ProjectId );
            var jsonData = new {
                Project_AttenceRecord = Project_AttenceRecordData,
                DC_EngineProject_ProjectInfo = DC_EngineProject_ProjectInfoData,
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
            var data = projectAttenceRecordIBLL.GetTree();
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
            projectAttenceRecordIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_EngineProject_ProjectInfoEntity)
        {
            Project_AttenceRecordEntity entity = strEntity.ToObject<Project_AttenceRecordEntity>();
            string time = "";

            string Month = DateTime.Now.Month.ToString();

            if (Convert.ToInt32(Month) < 10)
            {
                time = DateTime.Now.Year.ToString() + "-0" + DateTime.Now.Month.ToString();
            }
            else
            {
                time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
            }
            entity.F_Month = time;
            entity.Project_AttenceDate = DateTime.Now;
            DC_EngineProject_ProjectInfoEntity dC_EngineProject_ProjectInfoEntity = strdC_EngineProject_ProjectInfoEntity.ToObject<DC_EngineProject_ProjectInfoEntity>();
            projectAttenceRecordIBLL.SaveEntity(keyValue,entity,dC_EngineProject_ProjectInfoEntity);
            return Success("保存成功！");
        }



        [HttpGet]
        public ActionResult GetProjectAttenced(string projectid)
        {
            string time = "";

            string Month = DateTime.Now.Month.ToString();

            if (Convert.ToInt32(Month) < 10)
            {
                time = DateTime.Now.Year.ToString() + "-0" + DateTime.Now.Month.ToString();
            }
            else
            {
                time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
            }
            return Success(projectAttenceRecordIBLL.GetRecord1(projectid,time));
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Import(string keyValue)
        {
            AnnexesFileEntity entity = annexesFileIBLL.GetAnnexedFileEntity(keyValue);

            DataTable dt = ExcelUtil.ExcelToDataTable(entity.F_FilePath, "sheet1", true);
            projectAttenceRecordIBLL.ImportEntity(dt);
            return Success("导入成功");
        }

        #endregion

    }
}
