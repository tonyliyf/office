using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.WorkFlow;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using Newtonsoft.Json;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 DYT-OA V1.0 企业敏捷开发框架
    /// Copyright (c) 2018-2019 武汉东雅图科技技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-14 12:10
    /// 描 述：收文管理
    /// </summary>
    public class DC_OA_ReceiveOfficialDocManagerService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_ReceiveOfficialDocEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_ReceiveOfficialDoc t ");
                strSql.Append("  WHERE is_agree =  2 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (user.userId != "System")
                {
                    dp.Add("F_DepartmentId", user.departmentId, DbType.String);
                    strSql.Append(" AND t.F_DepartmentId = @F_DepartmentId ");
                }
                if (!queryParam["F_FileCode"].IsEmpty())
                {
                    dp.Add("F_FileCode", "%" + queryParam["F_FileCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_FileCode Like @F_FileCode ");
                }
                if (!queryParam["F_DenseGrade"].IsEmpty())
                {
                    dp.Add("F_DenseGrade", queryParam["F_DenseGrade"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_DenseGrade = @F_DenseGrade ");
                }
                if (!queryParam["F_ReceiveCode"].IsEmpty())
                {
                    dp.Add("F_ReceiveCode", "%" + queryParam["F_ReceiveCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ReceiveCode Like @F_ReceiveCode ");
                }
                if (!queryParam["F_ReceiveDate"].IsEmpty())
                {
                    dp.Add("F_ReceiveDate", queryParam["F_ReceiveDate"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ReceiveDate = @F_ReceiveDate ");
                }
                if (!queryParam["F_SenderDepartment"].IsEmpty())
                {
                    dp.Add("F_SenderDepartment", queryParam["F_SenderDepartment"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_SenderDepartment = @F_SenderDepartment ");
                }
                return this.BaseRepository().FindList<DC_OA_ReceiveOfficialDocEntity>(strSql.ToString(), dp, pagination);
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
                t.F_RODId,
                t.F_SenderDepartment as department,
                t.F_ReceiveCode as code,
                t.F_FileCode as filecode,
                t.F_ReceiveDate as date,
                t.F_Title as title,
                (select top 1 F_Des from LR_NWF_TaskLog where F_ProcessId= t.F_RODId and F_NodeId='" + GetNodeIdOfSecondStep() + @"' order by F_CreateDate desc ) as advice,
                (select stuff((select '->'+F_NodeName+','+F_CreateUserName+','+CONVERT(varchar(100), F_CreateDate, 21)+','+F_Des  FROM [LR_NWF_TaskLog] where F_ProcessId=t.F_RODId
                 order by F_CreateDate for xml path (''),Type).value('.','NVARCHAR(MAX)'),1,2,'')) as step,
                 case  when is_agree!='2' then '审核中' when is_agree='2' and  (F_IfCompletion!='1' or F_IfCompletion is null) then '办结' when is_agree='2' and F_IfCompletion='1' then '归档' else  '审核中' end as result
                ");
                strSql.Append("  FROM DC_OA_ReceiveOfficialDoc t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( date >= @startTime AND date <= @endTime ) ");
                }
                if (!queryParam["F_FileCode"].IsEmpty())
                {
                    dp.Add("F_FileCode", "%" + queryParam["F_FileCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND filecode Like @F_FileCode ");
                }
                if (!queryParam["F_ReceiveCode"].IsEmpty())
                {
                    dp.Add("F_ReceiveCode", "%" + queryParam["F_ReceiveCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND code Like @F_ReceiveCode ");
                }
                if (!queryParam["F_SenderDepartment"].IsEmpty())
                {
                    dp.Add("F_SenderDepartment", queryParam["F_SenderDepartment"].ToString(), DbType.String);
                    strSql.Append(" AND department = @F_SenderDepartment ");
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
        /// 获取DC_OA_ReceiveOfficialDoc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_ReceiveOfficialDocEntity GetDC_OA_ReceiveOfficialDocEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_ReceiveOfficialDocEntity>(keyValue);
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
        public NWFTaskLogEntity GetNWFTaskLogEntity(string keyValue)
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
        public DC_OA_ReceiveOfficialDocEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_ReceiveOfficialDocEntity>(t => t.F_RODId == processId);
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
                var dC_OA_ReceiveOfficialDocEntity = GetDC_OA_ReceiveOfficialDocEntity(keyValue);
                db.Delete<DC_OA_ReceiveOfficialDocEntity>(t => t.F_RODId == keyValue);
                db.Delete<NWFTaskLogEntity>(t => t.F_ProcessId == dC_OA_ReceiveOfficialDocEntity.F_RODId);
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
        public void SaveEntity(string keyValue, DC_OA_ReceiveOfficialDocEntity entity, List<NWFTaskLogEntity> lR_NWF_TaskLogList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_ReceiveOfficialDocEntityTmp = GetDC_OA_ReceiveOfficialDocEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
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
            var model = this.BaseRepository().FindEntity<DC_OA_ReceiveOfficialDocEntity>(keyValue);
            model.F_IfCompletion = 1;
            model.F_CompetionDate = DateTime.Now;
            model.F_CompetionUserId = info.userId;
            this.BaseRepository().Update(model);
        }
        public List<string> GetAdviceByProcessId(string keyValue, string signaturePath)
        {
            StringBuilder sb;
            List<string> list = new List<string>();
            var modellist = base.BaseRepository().FindList<NWFTaskLogEntity>(c => c.F_ProcessId == keyValue).ToList();
            if (modellist.Count > 0)
            {
                Action<Func<NWFTaskLogEntity, bool>> func = (lambda) =>
                 {
                     sb = new StringBuilder();
                     var list1 = modellist.Where(lambda).ToList();
                     if (list1.Count > 0)
                     {
                         foreach (var item in list1)
                         {
                             sb.Append("<p>" + item.F_CreateUserName + ":");
                             sb.Append(item.F_Des + "  " + (item.F_CreateDate.HasValue ? item.F_CreateDate.Value.ToString("yyyy.MM.dd") : "") + "</p>");
                         }
                     }
                     list.Add(sb.ToString());
                 };
                func(c => c.F_NodeName == "拟办");
                func(c => c.F_NodeName == "批示");
                //func(c => c.F_NodeName == "总经理批示" || c.F_NodeName == "董事长批示");
                func(c => c.F_NodeName == "承办");
                func(c => c.F_NodeName == "传阅节点");
                func(c => c.F_NodeName == "办理");
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
        private string GetNodeIdOfSecondStep()
        {
            string sql = @"declare @sid nvarchar(50)
                          select @sid = F_Id from LR_NWF_SchemeInfo where F_Name like '%金润源收文审批%'
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
    public class selectdata
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class processdata
    {
        public List<node> nodes { get; set; }
    }
    public class node
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
