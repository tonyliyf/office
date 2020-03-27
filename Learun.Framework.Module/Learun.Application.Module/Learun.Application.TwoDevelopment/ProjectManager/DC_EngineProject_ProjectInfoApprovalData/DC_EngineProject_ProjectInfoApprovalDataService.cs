using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.Application.Base.SystemModule;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 15:19
    /// 描 述：DC_EngineProject_ProjectInfoApprovalData
    /// </summary>
    public class DC_EngineProject_ProjectInfoApprovalDataService : RepositoryFactory
    {
        private DataItemIBLL dataItemIBLL = new DataItemBLL();
        #region 获取数据
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
                t.F_PICADId,
                f.F_ProjectName as F_PIId,
                t.F_ProjectStage,
                t.F_DataCode,
                t.F_DataName,
                e.F_RealName as F_CreateUserid,
                d.F_FullName as F_CreateDepartmentId,
                t.F_Remarks
                ");
                strSql.Append(@" from DC_EngineProject_ProjectInfoApprovalData t 

left join LR_Base_Department d on t.F_CreateDepartmentId=d.F_DepartmentId

left join  LR_Base_User e on t.F_CreateUserid=e.F_UserId
left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
                if (!queryParam["F_ProjectStage"].IsEmpty())
                {
                    dp.Add("F_ProjectStage", queryParam["F_ProjectStage"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ProjectStage = @F_ProjectStage ");
                }
                if (!queryParam["F_DataCode"].IsEmpty())
                {
                    dp.Add("F_DataCode", "%" + queryParam["F_DataCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DataCode Like @F_DataCode ");
                }
                if (!queryParam["F_DataName"].IsEmpty())
                {
                    dp.Add("F_DataName", "%" + queryParam["F_DataName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DataName Like @F_DataName ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_ProjectStage", "EngineeringProjectStage");
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


        public DataTable GetProjectInfo(string queryJosn)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT p.F_ProjectName,p.F_ProjectItemNumber ,p.F_ActualStartDate,p.F_ProjectBuildType,d.F_ProjectStage,d.F_PlannedStartDate,d.F_PlannedEndDate,
d.F_ActualEndDate, d.F_Remarks,d.F_DataName,d.F_DataCode FROM DC_EngineProject_ProjectInfo p left join  DC_EngineProject_ProjectInfoApprovalData d
on p.F_PIId = d.F_PIId
");

            strSql.Append("  WHERE 1=1 ");
            //var queryParam = queryJosn.ToJObject();
            //// 虚拟参数
            var dp = new DynamicParameters(new { });
            //if (!queryParam["F_PIId"].IsEmpty())
            //{
            //    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
            //    strSql.Append(" AND t.F_PIId = @F_PIId ");
            //}
            //if (!queryParam["F_ProjectStage"].IsEmpty())
            //{
            //    dp.Add("F_ProjectStage", queryParam["F_ProjectStage"].ToString(), DbType.String);
            //    strSql.Append(" AND t.F_ProjectStage = @F_ProjectStage ");
            //}
            //if (!queryParam["F_DataCode"].IsEmpty())
            //{
            //    dp.Add("F_DataCode", "%" + queryParam["F_DataCode"].ToString() + "%", DbType.String);
            //    strSql.Append(" AND t.F_DataCode Like @F_DataCode ");
            //}
            if (!queryJosn.IsEmpty())
            {
                dp.Add("keyword", "%" + queryJosn + "%", DbType.String);
                strSql.Append(" AND p.F_ProjectName Like @keyword ");
            }

            strSql.Append("   order by F_projectName ");

            DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
            return dt;

        }


        public DataTable GetBeforeProjectInfoss(string ProjectId)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT p.F_ProjectName,p.F_ProjectItemNumber ,p.F_ActualStartDate,p.F_ProjectBuildType,d.F_ProjectStage,d.F_PlannedStartDate,d.F_PlannedEndDate,
d.F_ActualEndDate, d.F_Remarks,d.F_DataName,d.F_DataCode,d.F_DataPhoto,d.F_Attachment  FROM DC_EngineProject_ProjectInfo p left join  DC_EngineProject_ProjectInfoApprovalData d
on p.F_PIId = d.F_PIId
");

            strSql.Append("  WHERE 1=1 ");
            //var queryParam = queryJosn.ToJObject();
            //// 虚拟参数
            var dp = new DynamicParameters(new { });
            //if (!queryParam["F_PIId"].IsEmpty())
            //{
            //    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
            //    strSql.Append(" AND t.F_PIId = @F_PIId ");
            //}
            //if (!queryParam["F_ProjectStage"].IsEmpty())
            //{
            //    dp.Add("F_ProjectStage", queryParam["F_ProjectStage"].ToString(), DbType.String);
            //    strSql.Append(" AND t.F_ProjectStage = @F_ProjectStage ");
            //}
            //if (!queryParam["F_DataCode"].IsEmpty())
            //{
            //    dp.Add("F_DataCode", "%" + queryParam["F_DataCode"].ToString() + "%", DbType.String);
            //    strSql.Append(" AND t.F_DataCode Like @F_DataCode ");
            //}
            if (!ProjectId.IsEmpty())
            {
                dp.Add("ProjectId", ProjectId, DbType.String);
                strSql.Append(" AND p.F_PIId = @ProjectId ");
            }


            DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
            return dt;

        }


        public DataTable GetProjectBeforeInfo(string queryJosn)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT p.F_ProjectName,p.F_ProjectItemNumber ,p.F_ActualStartDate,p.F_ProjectBuildType,d.F_ProjectStage,d.F_PlannedStartDate,d.F_PlannedEndDate,
d.F_ActualEndDate, d.F_Remarks FROM DC_EngineProject_ProjectInfo p left join  DC_EngineProject_ProjectInfoApprovalData d
on p.F_PIId = d.F_PIId ");

            strSql.Append("  WHERE 1=1 ");
            var queryParam = queryJosn.ToJObject();
            // 虚拟参数
            var dp = new DynamicParameters(new { });
            if (!queryParam["F_PIId"].IsEmpty())
            {
                dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                strSql.Append(" AND t.F_PIId = @F_PIId ");
            }
            if (!queryParam["F_ProjectStage"].IsEmpty())
            {
                dp.Add("F_ProjectStage", queryParam["F_ProjectStage"].ToString(), DbType.String);
                strSql.Append(" AND t.F_ProjectStage = @F_ProjectStage ");
            }
            if (!queryParam["F_DataCode"].IsEmpty())
            {
                dp.Add("F_DataCode", "%" + queryParam["F_DataCode"].ToString() + "%", DbType.String);
                strSql.Append(" AND t.F_DataCode Like @F_DataCode ");
            }
            if (!queryParam["F_DataName"].IsEmpty())
            {
                dp.Add("F_DataName", "%" + queryParam["F_DataName"].ToString() + "%", DbType.String);
                strSql.Append(" AND t.F_DataName Like @F_DataName ");
            }
            DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
            return dt;

        }
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectInfoApprovalDataEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                  t.*,b.F_ProjectName
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectInfoApprovalData t left join DC_EngineProject_ProjectInfo b on t.F_PIId=b.F_PIId ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
                if (!queryParam["F_ProjectName"].IsEmpty())
                {
                    strSql.Append(" AND b.F_ProjectName like '%" + queryParam["F_ProjectName"].ToString() + "%' ");
                }
                if (!queryParam["F_ProjectStage"].IsEmpty())
                {
                    dp.Add("F_ProjectStage", queryParam["F_ProjectStage"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ProjectStage = @F_ProjectStage ");
                }
                if (!queryParam["F_DataCode"].IsEmpty())
                {
                    dp.Add("F_DataCode", "%" + queryParam["F_DataCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DataCode Like @F_DataCode ");
                }
                if (!queryParam["F_DataName"].IsEmpty())
                {
                    dp.Add("F_DataName", "%" + queryParam["F_DataName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DataName Like @F_DataName ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoApprovalDataEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_EngineProject_ProjectInfoApprovalInfo> GetPageInfoList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@" WITH 
                TREE AS( 
                    SELECT * FROM LR_Base_DataItem 
                    WHERE   F_ItemCode = 'EngineeringProjectStage'
                    UNION ALL 
                    SELECT LR_Base_DataItem.* FROM LR_Base_DataItem, TREE 
                    WHERE LR_Base_DataItem.F_ParentId = TREE.F_ItemId
                ) 
                SELECT * FROM TREE ");
                var list = this.BaseRepository().FindList<DC_EngineProject_ProjectInfoApprovalInfo>(strSql.ToString());
                var list3 = new List<DC_EngineProject_ProjectInfoApprovalInfo>();
                foreach (var item in list)
                {
                    list3.Add(item);
                    var data = dataItemIBLL.GetDetailList(item.F_ItemCode);
                    foreach (var temp in data)
                    {
                        DC_EngineProject_ProjectInfoApprovalInfo b = new DC_EngineProject_ProjectInfoApprovalInfo();
                        b.F_ItemId = temp.F_ItemDetailId;
                        b.F_ParentId = item.F_ItemId;
                        b.F_ItemName = temp.F_ItemName;
                        list3.Add(b);

                    }


                }


                strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                  t.*,b.F_ProjectName
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectInfoApprovalData t left join DC_EngineProject_ProjectInfo b on t.F_PIId=b.F_PIId ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PIId"].IsEmpty())
                {
                    dp.Add("F_PIId", queryParam["F_PIId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PIId = @F_PIId ");
                }
               
                var list2 = this.BaseRepository().FindList<DC_EngineProject_ProjectInfoApprovalDataEntity>(strSql.ToString(), dp);

                foreach(DC_EngineProject_ProjectInfoApprovalInfo info in list3)
                {
                    foreach(DC_EngineProject_ProjectInfoApprovalDataEntity item in list2 )
                    {
                        if(item.F_ProjectStage ==info.F_ItemId)
                        {
                            info.F_DataPhoto = item.F_DataPhoto;
                            info.F_Attachment = item.F_Attachment;
                            info.F_DataName = item.F_DataName;

                        }

                    }


                }
                return list3;

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
        /// 获取DC_EngineProject_ProjectInfoApprovalData表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoApprovalDataEntity GetDC_EngineProject_ProjectInfoApprovalDataEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectInfoApprovalDataEntity>(keyValue);
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
                return this.BaseRepository().FindTable(@" WITH 
TREE AS( 
    SELECT * FROM LR_Base_DataItem 
    WHERE   F_ItemCode = 'EngineeringProjectStage'
    UNION ALL 
    SELECT LR_Base_DataItem.* FROM LR_Base_DataItem, TREE 
    WHERE LR_Base_DataItem.F_ParentId = TREE.F_ItemId
) 
SELECT * FROM TREE ");
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
        public DataTable GetBeforSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(@" WITH 
TREE AS( 
    SELECT * FROM LR_Base_DataItem 
    WHERE   F_ItemCode = 'ProjectBegin'
    UNION ALL 
    SELECT LR_Base_DataItem.* FROM LR_Base_DataItem, TREE 
    WHERE LR_Base_DataItem.F_ParentId = TREE.F_ItemId
) 
SELECT * FROM TREE ");
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
        public DataTable GetUnitTree()
        {
            try
            {
                return this.BaseRepository().FindTable(@" SELECT * from DC_EngineProject_ProjectInfoUnit
 ");
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

        public DataTable GetUnitOtherTree()
        {
            try
            {
                return this.BaseRepository().FindTable(@" SELECT * from DC_ASSETS_ContactUnit where F_UnitType=1
 ");
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
                this.BaseRepository().Delete<DC_EngineProject_ProjectInfoApprovalDataEntity>(t => t.F_PICADId == keyValue);
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoApprovalDataEntity entity)
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

    }
}
