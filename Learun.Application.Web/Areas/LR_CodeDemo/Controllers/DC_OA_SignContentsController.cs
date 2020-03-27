using Learun.Util; 
using System.Data; 
using Learun.Application.TwoDevelopment.LR_CodeDemo; 
using System.Web.Mvc; 
using System.Collections.Generic; 
  
namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers 
{ 
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-05-10 09:59 
    /// 描 述：DC_OA_SignContents 
    /// </summary> 
    public class DC_OA_SignContentController : MvcControllerBase 
    { 
        private DC_OA_SignContentIBLL dC_OA_SignContentsIBLL = new DC_OA_SignContentBLL(); 
  
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
            var data = dC_OA_SignContentsIBLL.GetPageList(paginationobj, queryJson); 
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
            var DC_OA_SignContentsData = dC_OA_SignContentsIBLL.GetDC_OA_SignContentsEntity( keyValue ); 
            var jsonData = new { 
                DC_OA_SignContents = DC_OA_SignContentsData, 
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
            dC_OA_SignContentsIBLL.DeleteEntity(keyValue); 
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
            DC_OA_SignContentsEntity entity = strEntity.ToObject<DC_OA_SignContentsEntity>();
            entity.Sign_Type = 0;
            dC_OA_SignContentsIBLL.SaveEntity(keyValue,entity); 
            return Success("保存成功！"); 
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveForm1(string keyValue)
        {
            dC_OA_SignContentsIBLL.SaveEntity1(keyValue);
            return Success("保存成功！");
        }
        #endregion

    } 
} 
