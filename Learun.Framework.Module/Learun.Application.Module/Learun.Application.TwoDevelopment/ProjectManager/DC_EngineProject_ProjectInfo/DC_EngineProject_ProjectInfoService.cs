using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.Application.TwoDevelopment.EcologyDemo;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-09 13:57
    /// 描 述：DC_EngineProject_ProjectInfo
    /// </summary>
    public class DC_EngineProject_ProjectInfoService : RepositoryFactory
    {
        private formtable_main_150IBLL bll150 =new formtable_main_150BLL();
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData1(string queryJson)
        {
            try
            {

                var strSql = new StringBuilder();
             
                strSql.Append(@"  SELECT 
                   t1.[F_ProjectYear]
                  ,c.F_FullName as [F_JRYCompany]
                  ,t1.[F_ProjectState]
                  ,t1.[F_ProjectBuildType]
                  ,t1.[F_EngineeringCost]
                  ,t2.F_AreaName as F_CommunityCode
                  ,t1.[F_ProjectAddress]
                  ,t1.[F_PlannedStartDate]
                  ,t1.[F_PlannedEndDate]
                  ,t1.[F_ProjectProgress]
                FROM [DC_EngineProject_ProjectInfo] t1
                left join lr_base_area t2 on t1.F_CommunityCode=t2.F_AreaId
 left join LR_Base_Company c on t1.F_JRYCompany=c.F_CompanyId"
                );

                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_ProjectApprovalDate >= @startTime AND t.F_ProjectApprovalDate <= @endTime ) ");
                }
               
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_ProjectState", "OS_F_State");
                dic.Add("F_ProjectBuildType", "EngineeringProjectBuildType");
            
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
                return dt;
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable ExportData(string queryJson)
        {
            try
            {
   
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                f.F_ProjectName as F_PIId,
                t.F_ProjectItemNumber,
                t.F_ProjectName,
                c.F_FullName as F_JRYCompany,
                t.F_ProjectBuildType,
                t.F_ProjectSizeClassify,
                t.F_ProjectState,
                t.F_ProjectYear,
                t.F_CommunityCode,
                t.F_EngineeringCost,
                t.F_ProjectAddress,
                t.F_ProjectApprovalDate,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate
                ");
                strSql.Append(@" from DC_EngineProject_ProjectInfo t 

left join LR_Base_Company c on t.F_JRYCompany=c.F_CompanyId

left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_ProjectApprovalDate >= @startTime AND t.F_ProjectApprovalDate <= @endTime ) ");
                }
                if (!queryParam["F_ProjectName"].IsEmpty())
                {
                    dp.Add("F_ProjectName", "%" + queryParam["F_ProjectName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ProjectName Like @F_ProjectName ");
                }
                if (!queryParam["F_JRYCompany"].IsEmpty())
                {
                    dp.Add("F_JRYCompany", queryParam["F_JRYCompany"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_JRYCompany = @F_JRYCompany ");
                }
                if (!queryParam["F_ProjectYear"].IsEmpty())
                {
                    dp.Add("F_ProjectYear", "%" + queryParam["F_ProjectYear"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ProjectYear Like @F_ProjectYear ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_ProjectBuildType", "EngineeringProjectBuildType");
                dic.Add("F_EngineeringCost", "EngineeringProjectScale");
                dic.Add("F_ProjectState", "OS_F_State");
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByDataItem(dt, dic);
                return dt;
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PIId,
                t.F_ProjectItemNumber,
                t.F_ProjectName,
                t.F_JRYCompany,
                t.F_ProjectBuildType,
                t.F_ProjectSizeClassify,
                t.F_ProjectState,
                t.F_ProjectYear,
                t.F_CommunityCode,
                t.F_ProjectAddress,
                t.F_ProjectApprovalDate,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectInfo t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_ProjectApprovalDate >= @startTime AND t.F_ProjectApprovalDate <= @endTime ) ");
                }
                if (!queryParam["F_ProjectName"].IsEmpty())
                {
                    dp.Add("F_ProjectName", "%" + queryParam["F_ProjectName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ProjectName Like @F_ProjectName ");
                }
                if (!queryParam["F_JRYCompany"].IsEmpty())
                {
                    dp.Add("F_JRYCompany", queryParam["F_JRYCompany"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_JRYCompany = @F_JRYCompany ");
                }
                if (!queryParam["F_ProjectYear"].IsEmpty())
                {
                    dp.Add("F_ProjectYear", "%" + queryParam["F_ProjectYear"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ProjectYear Like @F_ProjectYear ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_EngineProject_ProjectInfo表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoEntity GetDC_EngineProject_ProjectInfoEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectInfoEntity>(keyValue);
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(" select * from LR_Base_Company ");
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
        /// 获取树形数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetProjectSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(" select * from DC_EngineProject_ProjectInfo ");
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
            try
            {
                this.BaseRepository().Delete<DC_EngineProject_ProjectInfoEntity>(t => t.F_PIId == keyValue);
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
        /// 修改实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void UpdeteEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PIId,
                t.F_ProjectItemNumber,
                t.F_ProjectName,
                t.F_JRYCompany,
                t.F_ProjectBuildType,
                t.F_ProjectSizeClassify,
                t.F_ProjectState,
                t.F_ProjectYear,
                t.F_CommunityCode,
                t.F_ProjectAddress,
                t.F_ProjectApprovalDate,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectInfo t ");
                strSql.Append("  WHERE t.F_PIId='"+ keyValue + "' ");

                IEnumerable<DC_EngineProject_ProjectInfoEntity> List = this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(strSql.ToString());

                DC_EngineProject_ProjectInfoEntity s = null;

                foreach (Object obj in List)
                {
                    if (obj is DC_EngineProject_ProjectInfoEntity)//这个是类型的判断，这里Student是一个类或结构
                    {
                         s = (DC_EngineProject_ProjectInfoEntity)obj;
                    }

                }
               
                //修改状态
                s.F_ProjectState = "5";
                this.BaseRepository().Update(s);
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
        ///// <summary>
        ///// 修改实体数据
        ///// <param name="keyValue">主键</param>
        ///// <summary>
        ///// <returns></returns>
        //public string UpdeteEntity1(string keyValue)
        //{

        //    string name = "";

        //    try
        //    {
        //        var strSql = new StringBuilder();
        //        strSql.Append("SELECT ");
        //        strSql.Append(@"
        //        t.F_ProjectState
        //        ");
        //        strSql.Append("  FROM DC_EngineProject_ProjectInfo t ");
        //        strSql.Append("  WHERE t.F_PIId='" + keyValue + "' ");

        //        IEnumerable<DC_EngineProject_ProjectInfoEntity> List = this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(strSql.ToString());

        //        DC_EngineProject_ProjectInfoEntity s = null;

        //        foreach (Object obj in List)
        //        {
        //            if (obj is DC_EngineProject_ProjectInfoEntity)//这个是类型的判断，这里Student是一个类或结构
        //            {
        //                s = (DC_EngineProject_ProjectInfoEntity)obj;
        //            }

        //        }
               
        //        if (s.F_ProjectState=="5") {

        //            name = "已办结项目不可编辑";
        //        }
        //        //修改状态
        //        s.F_ProjectState = "5";
        //        this.BaseRepository().Update(s);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is ExceptionEx)
        //        {
        //            throw;
        //        }
        //        else
        //        {
        //            throw ExceptionEx.ThrowServiceException(ex);
        //        }
        //    }
        //}
        //public static void Print(IEnumerable<DC_EngineProject_ProjectInfoEntity> myList)
        //{
        //    DC_EngineProject_ProjectInfoEntity s = null;
        //    foreach (Object obj in myList)
        //    {
        //        if (obj is DC_EngineProject_ProjectInfoEntity)//这个是类型的判断，这里Student是一个类或结构
        //        {
        //             s = (DC_EngineProject_ProjectInfoEntity)obj;
        //        }


        //    }
        //    this.BaseRepository().Update(s);
        //}
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
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


        public IEnumerable<DC_EngineProject_ProjectInfoEntity> StatisticsProjectInfo(DateTime startDate, DateTime endDate)
        {
            return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(
               @"  SELECT 
                   t1.[F_ProjectYear]
                  ,t1.[F_JRYCompany]
                  ,t1.[F_ProjectState]
                  ,t1.[F_ProjectBuildType]
                  ,t1.[F_EngineeringCost]
                  ,t2.F_AreaName as F_CommunityCode
                  ,t1.[F_ProjectAddress]
                  ,t1.[F_PlannedStartDate]
                  ,t1.[F_PlannedEndDate]
                  ,t1.[F_ProjectProgress]
                FROM [DC_EngineProject_ProjectInfo] t1
                left join lr_base_area t2 on t1.F_CommunityCode=t2.F_AreaId where f_createdatetime >= @startDate and f_createdatetime <= @endDate"
                , new { startDate = startDate, endDate = endDate });
        }

        public DataTable StatisticsProjectInfoByCategory(DateTime startDate, DateTime endDate)
        {
            return this.BaseRepository().FindTable(@"
              select
              count(*) as [count],
              (select top 1 f_fullname from lr_base_company where f_companyid = f_jrycompany) as company,
              case when f_projectstate =  0 then '执行中'
              when f_projectstate =  1 then '延期'
              when f_projectstate =  2 then '暂停'
              when f_projectstate =  3 then '终止'
              when f_projectstate =  4 then '已验收'
              when f_projectstate =  5 then '已结案' else '' end as state
              from dc_engineproject_projectinfo 
              where F_CreateDatetime>=@startDate and F_CreateDatetime<=@endDate
              group by f_projectstate,f_jrycompany
            ", new { startDate = startDate, endDate = endDate });
        }

        /// <summary>
        /// 门户数据
        /// 获得项目信息数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectInfoEntity> GetProjectInfo(string F_ProjectAddress)
        {


            var strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(@"
                t.F_PIId,
                t.F_ProjectItemNumber,
                t.F_ProjectName,
                c.F_FullName as F_JRYCompany,
                t.F_ProjectBuildType,
                t.F_ProjectSizeClassify,
                t.F_ProjectState,
                t.F_ProjectYear,
                t.F_CenterpointCoordinates,
                t.F_CommunityCode,
                t.F_EngineeringCost,
                t.F_ProjectAddress,
                t.F_ProjectApprovalDate,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate
                ");
            strSql.Append(@" from DC_EngineProject_ProjectInfo t 

left join LR_Base_Company c on t.F_JRYCompany=c.F_CompanyId

 where f_projectstate =0 and F_ProjectAddress='"+ F_ProjectAddress + "'");
            return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(strSql.ToString());

        }
        /// <summary>
        /// 门户数据
        /// 获得项目信息数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectInfoEntity> GetProjectInfo1()
        {


            var strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(@"
                t.F_PIId,
                t.F_ProjectItemNumber,
                t.F_ProjectName,
                c.F_FullName as F_JRYCompany,
                t.F_ProjectBuildType,
                t.F_ProjectSizeClassify,
                t.F_ProjectState,
                t.F_ProjectYear,
                t.F_CenterpointCoordinates,
                t.F_CommunityCode,
                t.F_EngineeringCost,
                t.F_ProjectAddress,
                t.F_ProjectApprovalDate,
                t.F_PlannedStartDate,
                t.F_PlannedEndDate
                ");
            strSql.Append(@" from DC_EngineProject_ProjectInfo t 

left join LR_Base_Company c on t.F_JRYCompany=c.F_CompanyId");

           // return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(strSql.ToString());
            var list = this.BaseRepository().FindList<DC_EngineProject_ProjectInfoEntity>(strSql.ToString());
            foreach (var item in list)
            {
                var temp = bll150.GetLastformtable_main_150Entity(item.F_PIId);
                if(temp!=null)
                {
                    item.Percent =(float) temp.jd;

                }
                else
                {
                    item.Percent = 0;
                }

            }
            return list;

        }
        /// <summary>
        /// 获得合同数据
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public DataTable GetProjectContract(string ProjectId, string F_ItemValue,string F_PICId)
        {
            var strSql = new StringBuilder();
            //虚拟参数
            var dp = new DynamicParameters(new { });

            strSql.Append("SELECT ");
            strSql.Append(@"
t.F_PICId
,t.F_PIId
,t.F_ContractType
,t.F_ContractCode
,t.F_ContractName
,t.F_ContractMoney
,t.F_SettlementMethod
,t.F_PayMethod
,b.F_FileName
,b.F_FolderId
,b.F_FilePath as F_ContractAppendices
,t.F_PartyAUnit
,t.F_PartyABlameMan
,t.F_PartyBUnit
,t.F_PartyBBlameMan
,t.F_SigningTime
,t.F_Remarks
                ");
            strSql.Append("  FROM DC_EngineProject_ProjectInfoContract t left join LR_Base_AnnexesFile b on b.F_FolderId=t.F_ContractAppendices");


            //strSql.Append("  WHERE t.F_PIId='086df13d-160b-4767-8767-82dcc2035fa9'");
            strSql.Append("  WHERE 1=1");
            if (!F_PICId.IsEmpty())
            {
                dp.Add("F_PICId", F_PICId, DbType.String);
                strSql.Append(" AND t.F_PICId = @F_PICId ");
            }
            if (!ProjectId.IsEmpty())
            {
                dp.Add("ProjectId", ProjectId, DbType.String);
                strSql.Append(" AND t.F_PIId = @ProjectId ");
            }
            if (!F_ItemValue.IsEmpty())
            {
                dp.Add("F_ItemValue", F_ItemValue, DbType.String);
                strSql.Append(" AND t.F_ContractType = @F_ItemValue ");
            }

            SimpleLogUtil.WriteTextLog("Contract", strSql.ToString(), DateTime.Now);
            DataTable dt = this.BaseRepository().FindTable(strSql.ToString(),dp);

            SimpleLogUtil.WriteTextLog("Contractdt",dt.Rows.Count.ToString(), DateTime.Now);
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("F_ContractType", "EngineeringContractType");
            dic.Add("F_SettlementMethod", "SettlementMethod");
            dic.Add("F_PayMethod", "PayMethod");
            DataConvertSerivers sevices = new DataConvertSerivers();
            sevices.ConvertDataByDataItem(dt, dic);
            return dt;
        }

        /// <summary>
        /// 获得合同数据
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public DataTable GetProjectContract1(string ProjectId)
        {
            var strSql = new StringBuilder();
            //虚拟参数
            var dp = new DynamicParameters(new { });

            strSql.Append("SELECT ");
            strSql.Append(@"
t.F_PICId
,t.F_PIId
,t.F_ContractType
,t.F_ContractCode
,t.F_ContractName
,t.F_ContractMoney
,t.F_SettlementMethod
,t.F_PayMethod
,b.F_FileName
,b.F_FolderId
,b.F_FilePath as F_ContractAppendices
,t.F_PartyAUnit
,t.F_PartyABlameMan
,t.F_PartyBUnit
,t.F_PartyBBlameMan
,t.F_SigningTime
,t.F_Remarks
                ");
            strSql.Append("  FROM DC_EngineProject_ProjectInfoContract t left join LR_Base_AnnexesFile b on b.F_FolderId=t.F_ContractAppendices");


            //strSql.Append("  WHERE t.F_PIId='086df13d-160b-4767-8767-82dcc2035fa9'");
            strSql.Append("  WHERE 1=1");    
            if (ProjectId.IsEmpty())
            {
                dp.Add("ProjectId", ProjectId, DbType.String);
                strSql.Append(" AND t.F_PIId = @ProjectId ");
            }
            SimpleLogUtil.WriteTextLog("Contract", strSql.ToString(), DateTime.Now);
            DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("F_ContractType", "EngineeringContractType");
            dic.Add("F_SettlementMethod", "SettlementMethod");
            dic.Add("F_PayMethod", "PayMethod");
            DataConvertSerivers sevices = new DataConvertSerivers();
            sevices.ConvertDataByDataItem(dt, dic);
            return dt;
        }



        /// <summary>
        /// 获得合同状态
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public DataTable GetProjectOS_F_State()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"
              select b.F_ItemName,b.F_ItemValue from LR_Base_DataItem a  left join LR_Base_DataItemDetail b on  a.F_ItemId=b.F_ItemId  where a.F_ItemCode='OS_F_State' ORDER BY b.F_ItemValue 
                ");
            DataTable dt = this.BaseRepository().FindTable(strSql.ToString()); 
            return dt;
        }
    }
}
