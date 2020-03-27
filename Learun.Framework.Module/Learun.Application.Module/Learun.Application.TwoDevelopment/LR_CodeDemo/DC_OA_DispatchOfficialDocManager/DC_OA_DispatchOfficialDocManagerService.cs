using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.WorkFlow;
using Learun.Application.Organization;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-12 15:16
    /// 描 述：发文管理
    /// </summary>
    public class DC_OA_DispatchOfficialDocManagerService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_DispatchOfficialDocEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_DispatchOfficialDoc t ");
                strSql.Append("  WHERE (select F_IsFinished from LR_NWF_Process where F_Id= F_DODId)= 1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_FileCode"].IsEmpty())
                {
                    dp.Add("F_FileCode", "%" + queryParam["F_FileCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FileCode Like @F_FileCode ");
                }
                if (!queryParam["F_Title"].IsEmpty())
                {
                    dp.Add("F_Title", "%" + queryParam["F_Title"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Title Like @F_Title ");
                }
                if (!queryParam["F_CreateDate"].IsEmpty())
                {
                    dp.Add("F_CreateDate", queryParam["F_CreateDate"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateDate = @F_CreateDate ");
                }
                if (!queryParam["F_CreateUserId"].IsEmpty())
                {
                    dp.Add("F_CreateUserId", queryParam["F_CreateUserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateUserId = @F_CreateUserId ");
                }
                return this.BaseRepository().FindList<DC_OA_DispatchOfficialDocEntity>(strSql.ToString(), dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        public IEnumerable<ReciveFileReturnDataModel> GetDealIndexPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_DODId,
                t.F_DepartmentId as department,
                t.F_FileCode as filecode,
                 CONVERT(varchar(100), t.F_CreateDate, 23) as date,
                t.F_Title as title,
                (select top 1 F_Des from LR_NWF_TaskLog where F_ProcessId= t.F_DODId and F_NodeId='" + GetNodeIdOfSecondStep() + @"' order by F_CreateDate desc ) as advice,
                (select stuff((select '->'+F_NodeName+','+F_CreateUserName+','+CONVERT(varchar(100), F_CreateDate, 21)+','+F_Des  FROM [LR_NWF_TaskLog] where F_ProcessId=t.F_DODId
                 order by F_CreateDate for xml path (''),Type).value('.','NVARCHAR(MAX)'),1,2,'')) as step,
                 case  when is_agree!='2' then '审核中' when is_agree='2' and (F_IfCompletion!='1' or F_IfCompletion is null) then '办结' when is_agree='2' and F_IfCompletion='1' then '归档' else  '审核中' end as result
                ");
                strSql.Append("  FROM DC_OA_DispatchOfficialDoc t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_FileCode"].IsEmpty())
                {
                    dp.Add("F_FileCode", "%" + queryParam["F_FileCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FileCode  Like @F_FileCode ");
                }
                if (!queryParam["F_DepartmentId"].IsEmpty())
                {
                    dp.Add("F_DepartmentId", queryParam["F_DepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DepartmentId = @F_DepartmentId ");
                }
                if (!queryParam["processState"].IsEmpty())
                {
                    dp.Add("processState", queryParam["processState"].ToString(), DbType.String);
                    strSql.Append(" AND    ( case  when is_agree!='2' then '审核中' when is_agree='2' and F_IfCompletion='0' then '办结' when is_agree='2' and F_IfCompletion='1' then '归档' else  '审核中' end ) = @processState ");
                }
                return this.BaseRepository().FindList<ReciveFileReturnDataModel>(strSql.ToString(), dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取LR_NWF_TaskLog表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<NWFTaskLogEntity> GetLR_NWF_TaskLogList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<NWFTaskLogEntity>(t => t.F_ProcessId == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取DC_OA_DispatchOfficialDoc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_DispatchOfficialDocEntity GetDC_OA_DispatchOfficialDocEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取LR_NWF_TaskLog表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public NWFTaskLogEntity GetLR_NWF_TaskLogEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<NWFTaskLogEntity>(t => t.F_ProcessId == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取主表实体数据
        /// <param name="processId">流程实例ID</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_DispatchOfficialDocEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(t => t.F_DODId == processId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var dC_OA_DispatchOfficialDocEntity = GetDC_OA_DispatchOfficialDocEntity(keyValue);
                db.Delete<DC_OA_DispatchOfficialDocEntity>(t => t.F_DODId == keyValue);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_OA_DispatchOfficialDocEntity entity, List<NWFTaskLogEntity> lR_NWF_TaskLogList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_DispatchOfficialDocEntityTmp = GetDC_OA_DispatchOfficialDocEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //db.Delete<NWFTaskLogEntity>(t=>t.F_ProcessId == dC_OA_DispatchOfficialDocEntityTmp.F_DODId);
                    //foreach (NWFTaskLogEntity item in lR_NWF_TaskLogList)
                    //{
                    //    item.Create();
                    //    item.F_ProcessId = dC_OA_DispatchOfficialDocEntityTmp.F_DODId;
                    //    db.Insert(item);
                    //}
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    //foreach (NWFTaskLogEntity item in lR_NWF_TaskLogList)
                    //{
                    //    item.Create();
                    //    item.F_ProcessId = entity.F_DODId;
                    //    db.Insert(item);
                    //}
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        public void DoComplete(string keyValue)
        {
            UserInfo info = LoginUserInfo.Get();
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            model.F_IfCompletion = 1;
            model.F_CompletionDate = DateTime.Now;
            model.F_CompletionUserId = info.userId;
            this.BaseRepository().Update(model);
        }

        public void SaveSetting(string keyValue, DC_OA_DispatchOfficialDocEntity entity)
        {
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            model.F_RedHead = entity.F_RedHead;
            model.F_DocTemplate = entity.F_DocTemplate;
            this.BaseRepository().Update(model);
        }

        public bool IsSettingTemplate(string keyValue)
        {
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            return !string.IsNullOrWhiteSpace(model.F_DocTemplate);
        }

        public string GetDepartmentNameById(string departmentId)
        {
            var model = base.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == departmentId);
            return model.F_FullName;
        }
        public List<string> GetAdviceByProcessId(string keyValue, string signaturePath)
        {
            StringBuilder sb;
            List<string> list = new List<string>();
            var modellist = base.BaseRepository().FindList<NWFTaskLogEntity>(c => c.F_ProcessId == keyValue).ToList();
            if (modellist.Count > 0)
            {
                sb = new StringBuilder();
                var list1 = modellist.Where(c => c.F_NodeName.Contains("审稿")).ToList();
                if (list1.Count > 0)
                {
                    foreach (var item in list1)
                    {
                        sb.Append("<p>" + item.F_CreateUserName + ":");
                        sb.Append(item.F_Des + "    " + (item.F_CreateDate.HasValue ? item.F_CreateDate.Value.ToString("yyyy.MM.dd") : "") + "</p>");
                    }
                }
                list.Add(sb.ToString());
                sb = new StringBuilder();
                var list2 = modellist.Where(c => c.F_NodeName.Contains("签发")).ToList();
                if (list2.Count > 0)
                {
                    foreach (var item in list2)
                    {
                        var tempPath = signaturePath + "/" + item.F_CreateUserId + ".png";
                        if (false)
                        {
                            sb.Append("<p><img src=\"data:image/png;base64," + FileToBase64(tempPath) + "\"/>:");
                        }
                        else
                        {
                            sb.Append("<p>" + item.F_CreateUserName + ":");
                        }
                        sb.Append(item.F_Des + "     " + (item.F_CreateDate.HasValue ? item.F_CreateDate.Value.ToString("yyyy.MM.dd") : "") + "</p>");
                    }
                }
                list.Add(sb.ToString());
            }
            return list;

        }
        private String FileToBase64(string fileName)
        {
            string strRet = null;

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, bt.Length);
                strRet = Convert.ToBase64String(bt);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRet;
        }
        public List<EasyUiTreeModel> GetDepartmentTreeNode(string keyValue, int isSend)
        {
            //部门列表和公司列表
            var companyList = this.BaseRepository().FindList<CompanyEntity>(c => c.F_DeleteMark == 0 && c.F_EnabledMark == 1).ToList();
            var departmentList = this.BaseRepository().FindList<DepartmentEntity>(c => c.F_DeleteMark == 0 && c.F_EnabledMark == 1).ToList();
            DC_OA_DispatchOfficialDocEntity entity = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            if (entity.F_CopyToID == null)
            {
                entity.F_CopyToID = "";
            }
            if (entity.F_SendToID == null)
            {
                entity.F_SendToID = "";
            }
            List<string> ids;
            if (isSend == 1)
            {
                ids = entity.F_SendToID.Split(',').ToList();
            }
            else
            {
                ids = entity.F_CopyToID.Split(',').ToList();
            }
            var rootCompany = companyList.FirstOrDefault(c => c.F_ParentId == "0");
            //根节点
            List<EasyUiTreeModel> rootContainer = new List<EasyUiTreeModel>() { new EasyUiTreeModel(rootCompany.F_CompanyId, rootCompany.F_FullName, false, false, ids.Contains(rootCompany.F_CompanyId), true) };
            RenderCompanyNode(rootContainer[0], departmentList, companyList, ids);
            return rootContainer;
        }

        private void RenderCompanyNode(EasyUiTreeModel node, List<DepartmentEntity> departmentList, List<CompanyEntity> companyList, List<string> ids)
        {
            if (!node.attributes.isDepartment)
            {
                var companyfolder = new EasyUiTreeModel(node.id + "_Company", "子公司", true, false, ids.Contains(node.id + "_Company"), false, node.text);
                var departmentfolder = new EasyUiTreeModel(node.id + "_Department", "子部门", true, false, ids.Contains(node.id + "_Department"), false, node.text);

                //添加子公司
                var companyresult = companyList.Where(c => c.F_ParentId == node.id).ToList();
                foreach (var companyitem in companyresult)
                {
                    var childcompanynode = new EasyUiTreeModel(companyitem.F_CompanyId, companyitem.F_FullName, false, false, ids.Contains(companyitem.F_CompanyId));
                    RenderCompanyNode(childcompanynode, departmentList, companyList, ids);
                    companyfolder.children.Add(childcompanynode);
                }
                if (companyresult.Count > 0)
                {
                    node.children.Add(companyfolder);
                }

                //添加子部门
                var departmentresult = departmentList.Where(c => c.F_CompanyId == node.id && c.F_ParentId == "0").ToList();
                foreach (var departmentitem in departmentresult)
                {
                    var childdepartmentnode = new EasyUiTreeModel(departmentitem.F_DepartmentId, departmentitem.F_FullName, false, true, ids.Contains(departmentitem.F_DepartmentId));
                    RenderDepartmentNode(childdepartmentnode, departmentList, ids);
                    departmentfolder.children.Add(childdepartmentnode);
                }
                if (departmentresult.Count > 0)
                {
                    node.children.Add(departmentfolder);
                }
            }
        }
        private void RenderDepartmentNode(EasyUiTreeModel node, List<DepartmentEntity> departmentList, List<string> ids)
        {
            if (node.attributes.isDepartment)
            {
                var departmentresult = departmentList.Where(c => c.F_ParentId == node.id).ToList();
                foreach (var departmentitem in departmentresult)
                {
                    var childdepartmentnode = new EasyUiTreeModel(departmentitem.F_DepartmentId, departmentitem.F_FullName, false, true, ids.Contains(departmentitem.F_DepartmentId));
                    RenderDepartmentNode(childdepartmentnode, departmentList, ids);
                    node.children.Add(childdepartmentnode);
                }
            }
        }

        public void SendTo(string keyValue, string sendto, string sendtoid, string copyto, string copytoid, string ReviewUserName,
            string ReviewUserId, string ProofreadUserName, string ProofreadUserId, string PrintNum)
        {
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);

            model.F_SendTo = sendto;
            model.F_SendToID = sendtoid;

            model.F_CopyTo = copyto;
            model.F_CopyToID = copytoid;

            model.F_ReviewUser = ReviewUserName;
            model.F_ReviewUserId = ReviewUserId;
            model.F_ReviewDate = DateTime.Now;

            model.F_ProofreadUser = ProofreadUserName;
            model.F_ProofreadUserId = ProofreadUserId;
            model.F_ProofreadDate = DateTime.Now;
            int temp;
            if (int.TryParse(PrintNum, out temp))
            {
                model.F_PrintNum = temp;
            }
            else
            {
                model.F_PrintNum = null;
            }
            this.BaseRepository().Update(model);
        }

        public void savenewfile(string keyValue, string guid)
        {
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            model.F_FileContent_ENew = guid;
            this.BaseRepository().Update(model);
        }
        public string getnewfile(string keyValue)
        {
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            if (model == null)
            {
                return "";
            }
            return model.F_FileContent_ENew;
        }
        public bool IsSend(string keyValue)
        {
            var model = this.BaseRepository().FindEntity<DC_OA_DispatchOfficialDocEntity>(keyValue);
            return !string.IsNullOrWhiteSpace(model.F_SendToID);
        }

        private string GetNodeIdOfSecondStep()
        {
            string sql = @"declare @sid nvarchar(50)
                          select @sid = F_Id from LR_NWF_SchemeInfo where F_Name like '%金润源发文审批%'
                          select top 1 F_Content from LR_NWF_Scheme where F_SchemeInfoId = @sid order by F_CreateDate desc";
            string json = base.BaseRepository().FindObject(sql).ToString();
            processdata data = JsonConvert.DeserializeObject<processdata>(json);
            List<selectdata> list = new List<selectdata>();
            foreach (var item in data.nodes)
            {
                list.Add(new selectdata() { key = item.id, value = item.name });
            }
            foreach (var item in list)
            {
                if (item.value.Contains("拟办"))
                {
                    return item.key;
                }
            }
            return "";
        }
        public List<selectdata> GetProcessStep()
        {
            //string sql = @"declare @sid nvarchar(50)
            //              select @sid = F_Id from LR_NWF_SchemeInfo where F_Name like '%金润源收文审批%'
            //              select top 1 F_Content from LR_NWF_Scheme where F_SchemeInfoId = @sid order by F_CreateDate desc";
            //string json = base.BaseRepository().FindObject(sql).ToString();
            //processdata data = JsonConvert.DeserializeObject<processdata>(json);
            //List<selectdata> list = new List<selectdata>();
            //foreach (var item in data.nodes)
            //{
            //    list.Add(new selectdata() { key = item.id, value = item.name });
            //}
            List<selectdata> list = new List<selectdata>();
            list.Add(new selectdata() { key = "审核中", value = "审核中" });
            list.Add(new selectdata() { key = "办结", value = "办结" });
            list.Add(new selectdata() { key = "归档", value = "归档" });
            return list;
        }
        #endregion

    }
}
