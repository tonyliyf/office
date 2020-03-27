using Learun.Util; 
using System.Data; 
using Learun.Application.TwoDevelopment.LR_CodeDemo; 
using System.Web.Mvc; 
using System.Collections.Generic; 
  
namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers 
{ 
    /// <summary> 
    /// �� �� Learun-ADMS V7.0.3 �������ݿ������ 
    /// Copyright (c) 2013-2018 �Ϻ�������Ϣ�������޹�˾ 
    /// �� ������������Ա 
    /// �� �ڣ�2019-05-10 09:59 
    /// �� ����DC_OA_SignContents 
    /// </summary> 
    public class DC_OA_SignContentController : MvcControllerBase 
    { 
        private DC_OA_SignContentIBLL dC_OA_SignContentsIBLL = new DC_OA_SignContentBLL(); 
  
        #region ��ͼ���� 
  
        /// <summary> 
        /// ��ҳ�� 
        /// <summary> 
        /// <returns></returns> 
        [HttpGet] 
        public ActionResult Index() 
        { 
             return View(); 
        } 
        /// <summary> 
        /// ��ҳ 
        /// <summary> 
        /// <returns></returns> 
        [HttpGet] 
        public ActionResult Form() 
        { 
             return View(); 
        } 
        #endregion 
  
        #region ��ȡ���� 
  
        /// <summary> 
        /// ��ȡҳ����ʾ�б����� 
        /// <summary> 
        /// <param name="queryJson">��ѯ����</param> 
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
        /// ��ȡ������ 
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
  
        #region �ύ���� 
  
        /// <summary> 
        /// ɾ��ʵ������ 
        /// <param name="keyValue">����</param> 
        /// <summary> 
        /// <returns></returns> 
        [HttpPost] 
        [AjaxOnly] 
        public ActionResult DeleteForm(string keyValue) 
        { 
            dC_OA_SignContentsIBLL.DeleteEntity(keyValue); 
            return Success("ɾ���ɹ���"); 
        } 
        /// <summary> 
        /// ����ʵ�����ݣ��������޸ģ� 
        /// <param name="keyValue">����</param> 
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
            return Success("����ɹ���"); 
        }
        /// <summary>
        /// ����ʵ�����ݣ��������޸ģ�
        /// <param name="keyValue">����</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveForm1(string keyValue)
        {
            dC_OA_SignContentsIBLL.SaveEntity1(keyValue);
            return Success("����ɹ���");
        }
        #endregion

    } 
} 
