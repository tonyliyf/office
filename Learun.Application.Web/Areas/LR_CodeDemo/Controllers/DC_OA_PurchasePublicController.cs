using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Aspose.Words;
using System.Threading;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.AssetManager;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架 
    /// Copyright (c) 2013-2018 信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicController : MvcControllerBase
    {
        private DC_OA_PurchasePublicIBLL dC_OA_PurchasePublicIBLL = new DC_OA_PurchasePublicBLL();
        private CompanyIBLL companyIBLL = new CompanyBLL();
        private DC_OA_PurchaseCompanyIBLL dC_OA_PurchaseCompanyIBLL = new DC_OA_PurchaseCompanyBLL();
        private DC_ASSETS_ContactUnitIBLL dc_Assets_ContactUnitIBLL = new DC_ASSETS_ContactUnitBLL();
        private DC_OA_PurchaseAuditIBLL auditIBll = new DC_OA_PurchaseAuditBLL();

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
            var data = dC_OA_PurchasePublicIBLL.GetPageList(paginationobj, queryJson);
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
            var DC_OA_PurchasePublicData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicEntity(keyValue);
            var DC_OA_PurchasePublicDetailData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicDetailList(DC_OA_PurchasePublicData.F_PurchasePublicId);
            var jsonData = new
            {
                DC_OA_PurchasePublic = DC_OA_PurchasePublicData,
                DC_OA_PurchasePublicDetail = DC_OA_PurchasePublicDetailData,
            };
            return Success(jsonData);
        }
        #endregion

        /// <summary>
        /// 查看开标公告标头
        /// </summary>
        /// <param name="keyValue"></param>
        public void OpenDocTitle(string keyValue)
        {
            var DC_OA_PurchasePublicData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicEntity(keyValue);
            string tempPath = Server.MapPath("~/Template/公开招标文件.doc");
            string FilePath = Config.GetValue("AnnexesFile");
            string outputPath = FilePath + "/" + DC_OA_PurchasePublicData.F_PurchasePublicId + "_招标文件.doc";
            Utils.DeleteFile(FilePath + "/" + DC_OA_PurchasePublicData.F_PurchasePublicId + "_招标文件.doc");
            Utils.DeleteFile(FilePath + "/" + DC_OA_PurchasePublicData.F_PurchasePublicId + "_招标文件.pdf");
            //载入模板
            var doc = new Document(tempPath);
            String[] fieldNames = new String[] { "CompanyName", "ProjectName", "CompanyName1", "Leader", "DalLiCompanyName", "DaiLiLeader", "Times" };
            Object[] fieldValues = new Object[7];
            fieldValues[0] = DC_OA_PurchasePublicData.F_CurrentCompanyName;
            fieldValues[1] = DC_OA_PurchasePublicData.F_PurchaseName;
            fieldValues[2] = DC_OA_PurchasePublicData.F_CurrentCompanyName;
            CompanyEntity entity = companyIBLL.GetEntity(DC_OA_PurchasePublicData.F_CurrentCompanyId);

            if (entity.F_Manager != null)
            {
                fieldValues[3] = entity.F_Manager;
            }

            fieldValues[4] = "____";
            fieldValues[5] = "____";
            DC_OA_PurchaseAuditEntity audit = auditIBll.GetEntity(DC_OA_PurchasePublicData.F_PurchaseAuditRefId);
            if (!string.IsNullOrEmpty(audit.F_PurchaseCompanyId))
            {
                //DC_OA_PurchaseCompanyEntity dailiEntity = dC_OA_PurchaseCompanyIBLL.GetDC_OA_PurchaseCompanyEntity(audit.F_PurchaseCompanyId);
                DC_ASSETS_ContactUnitEntity dailiEntity = dc_Assets_ContactUnitIBLL.GetDC_ASSETS_ContactUnitEntity(audit.F_PurchaseCompanyId);
                if (dailiEntity != null)
                {
                    fieldValues[4] = dailiEntity.F_UnitName;
                    fieldValues[5] = dailiEntity.F_Contacts;
                }

            }

             

            fieldValues[6] = DateTime.Now.ToString("yyyyMMdd");

            ////合并模版，相当于页面的渲染
            doc.MailMerge.Execute(fieldNames, fieldValues);
            ////保存合并后的文档
            doc.Save(outputPath);
            Thread.Sleep(1);
            FileConvertoPdfUtil.PreviewFile(outputPath, "doc");


        }

        /// <summary>
        /// 查看开标公告
        /// </summary>
        /// <param name="keyValue"></param>
        public void OpenDoc(string keyValue)
        {

            var DC_OA_PurchasePublicData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicEntity(keyValue);
            var DC_OA_PurchasePublicDetailData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicDetailList(DC_OA_PurchasePublicData.F_PurchasePublicId);

            string FilePath = Config.GetValue("AnnexesFile");
            string tempPath = Server.MapPath("~/Template/采购公告发布及开标时间表.doc");
            string outputPath = FilePath + "/" + DC_OA_PurchasePublicData.F_PurchasePublicId + ".doc";
            Utils.DeleteFile(FilePath + "/" + DC_OA_PurchasePublicData.F_PurchasePublicId + ".doc");
            Utils.DeleteFile(FilePath + "/" + DC_OA_PurchasePublicData.F_PurchasePublicId + ".pdf");
            //载入模板
            var doc = new Document(tempPath);
            //提供数据源
            String[] fieldNames = new String[] { "F_CurrentCompanyName", "F_PurchaseProjectNo", "F_PurchaseName", "F_CreateUserName", "F_DealUserPhone", "F_DealMoney", "F_PurchaseMethod", "F_buyPlatform","F_ModifyDate","F_ModifyUserName", "F_PublicTime1", "F_AuditPublicTime1","F_SecondAuditPublicTime1",
            "F_OpenTime1","F_OpenTimelater1","F_IsPurchase1","F_PublicTime2", "F_AuditPublicTime2","F_SecondAuditPublicTime2","F_OpenTime2","F_OpenTimelater2","F_IsPurchase2","F_PublicTime3", "F_AuditPublicTime3","F_SecondAuditPublicTime3","F_OpenTime3","F_OpenTimelater3","F_IsPurchase3"};
            Object[] fieldValues = new Object[28];
            fieldValues[0] = DC_OA_PurchasePublicData.F_CurrentCompanyName;
            fieldValues[1] = DC_OA_PurchasePublicData.F_PurchaseProjectNo;
            fieldValues[2] = DC_OA_PurchasePublicData.F_PurchaseName;
            fieldValues[3] = DC_OA_PurchasePublicData.F_CreateUserName;
            fieldValues[4] = DC_OA_PurchasePublicData.F_DealUserPhone;
            fieldValues[5] = DC_OA_PurchasePublicData.F_DealMoney;
            fieldValues[6] = DC_OA_PurchasePublicData.F_PurchaseMethod;
            fieldValues[7] = DC_OA_PurchasePublicData.F_buyPlatform;
            fieldValues[8] = Utils.DateTimeToString(DC_OA_PurchasePublicData.F_ModifyDate, "yyyy-MM-dd");
            fieldValues[9] = DC_OA_PurchasePublicData.F_ModifyUserName;
            var sorted = DC_OA_PurchasePublicDetailData.OrderBy(f => f.F_PublicTime);
            int i = 0;
            if (sorted.Count() > 0)
            {
                foreach (var item in sorted)
                {
                    fieldValues[10 + i] = Utils.DateTimeToString(item.F_PublicTime, "yyyyMMdd");
                    fieldValues[11 + i] = Utils.DateTimeToString(item.F_AuditPublicTime, "yyyyMMdd");
                    fieldValues[12 + i] = Utils.DateTimeToString(item.F_SecondAuditPublicTime, "yyyyMMdd");
                    fieldValues[13 + i] = Utils.DateTimeToString(item.F_OpenTime, "yyyyMMdd");
                    fieldValues[14 + i] = Utils.DateTimeToString(item.F_OpenTimelater, "yyyyMMdd");

                    if (!string.IsNullOrEmpty(item.F_IsPurchase) && item.F_IsPurchase == "2")
                    {
                        fieldValues[15 + i] = "否";
                    }
                    else if (!string.IsNullOrEmpty(item.F_IsPurchase))
                    {

                        fieldValues[15 + i] = "是";
                    }

                    i += 6;
                }
            }
            ////合并模版，相当于页面的渲染
            doc.MailMerge.Execute(fieldNames, fieldValues);
            ////保存合并后的文档
            doc.Save(outputPath);
            Thread.Sleep(1);
            FileConvertoPdfUtil.PreviewFile(outputPath, "doc");

        }

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
            dC_OA_PurchasePublicIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }


        /// <summary> 
        /// 更新实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        [HttpPost]
        [AjaxOnly]
        public ActionResult update(string keyValue)
        {
            var DC_OA_PurchasePublicData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicEntity(keyValue);
            if (DC_OA_PurchasePublicData.Is_agree == "2")
            {
                return Fail("已完成，不能重复提交！");
            }

            DC_OA_PurchasePublicData.Is_agree = "2";

            var DC_OA_PurchasePublicDetailData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicDetailList(keyValue).ToList();
            dC_OA_PurchasePublicIBLL.SaveEntity(keyValue, DC_OA_PurchasePublicData, DC_OA_PurchasePublicDetailData);

            return Success("提交成功！");
        }
        /// <summary> 
        /// 保存实体数据（新增、修改） 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity, string strdC_OA_PurchasePublicDetailList)
        {
            DC_OA_PurchasePublicEntity entity = strEntity.ToObject<DC_OA_PurchasePublicEntity>();

            var DC_OA_PurchasePublicData = dC_OA_PurchasePublicIBLL.GetDC_OA_PurchasePublicEntity(keyValue);
            if (DC_OA_PurchasePublicData != null && DC_OA_PurchasePublicData.Is_agree == "2")
            {
                return Fail("已完成，不能进行修改！");
            }

            List<DC_OA_PurchasePublicDetailEntity> dC_OA_PurchasePublicDetailList = strdC_OA_PurchasePublicDetailList.ToObject<List<DC_OA_PurchasePublicDetailEntity>>();
            dC_OA_PurchasePublicIBLL.SaveEntity(keyValue, entity, dC_OA_PurchasePublicDetailList);
            return Success("保存成功！");
        }
        #endregion

    }
}