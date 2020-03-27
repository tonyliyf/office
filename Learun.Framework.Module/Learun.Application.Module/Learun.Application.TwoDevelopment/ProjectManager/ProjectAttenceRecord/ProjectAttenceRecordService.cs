using Dapper;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-07-30 15:42
    /// 描 述：项目考勤记录
    /// </summary>
    public class ProjectAttenceRecordService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Project_AttenceRecordEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                string time = "";

                string Month = DateTime.Now.Month.ToString();

                if (Convert.ToInt32(Month) < 10)
                {
                    time = DateTime.Now.Year.ToString() + "-0" + DateTime.Now.Month.ToString();
                }
                //else
                //{
                //    time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();
                //}
                var strSql = new StringBuilder();
                strSql.Append("SELECT top 1000000");
                strSql.Append(@"
                t.Project_AttenceRecordId,
                t.F_CreateUserName,
                t.F_Month,
                t.F_SecondAttenceDateTime,
                t.F_FirstAttenceDateTime,
                t.F_ProjectId,
                t.F_Titile,
                t.F_Class,
                t.Project_AttenceDateTime,
                t.Project_AttenceDate,
                t.F_Description,
                t.F_SupervisionCompany,
                t.F_BuildCompany,
                t.F_constructionCompany,
                t.Project_Attencedays,
                t.Project_Attencednumber,
                t.Project_mode,
                t.Project_code,
                t.Project_compare
                ");
                strSql.Append("  FROM Project_AttenceRecord t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CompanyName"].IsEmpty())
                {
                    string name = queryParam["F_CompanyName"].ToString();
                   
                    strSql.Append(" AND t.F_SupervisionCompany like '%"+ name + "%' or t.F_BuildCompany like '%"+name+ "%' or F_constructionCompany like '%"+name+"%' ");
                }
                


                if (!queryParam["F_Month"].IsEmpty())
                {
                    dp.Add("F_Month", queryParam["F_Month"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Month = @F_Month ");
                }
                //else
                //{
                //    dp.Add("F_Month", time, DbType.String);
                //    strSql.Append(" AND t.F_Month = @F_Month ");

                //}
                //strSql.Append("order by F_ProjectId, F_Month,F_CreateUserName,Project_AttenceDate  ");
                return this.BaseRepository().FindList<Project_AttenceRecordEntity>(strSql.ToString(),dp, pagination);
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

        public DataTable GetRecord(string Projectid,string Month,string code)
        {

            var strSql = new StringBuilder();
        
            strSql.Append(@"
               SELECT
	top 1000000 t.Project_AttenceRecordId,
	t.F_CreateUserName,
   	SUBSTRING(t.F_Month,0,5)Years,
	t.F_Month,
	t.F_SecondAttenceDateTime,
	t.F_FirstAttenceDateTime,
	b.F_ProjectName,
    b.F_PIId AS F_ProjectId,
	t.F_Titile,
	t.F_Class,
	t.Project_AttenceDateTime,
	t.Project_AttenceDate,
	t.F_Description,
    t.F_SupervisionCompany,
    t.F_BuildCompany,
    t.F_constructionCompany
FROM
	Project_AttenceRecord t
	LEFT JOIN DC_EngineProject_ProjectInfo b ON b.F_PIId = t.F_ProjectId
                ");

            strSql.Append("  WHERE 1=1 ");
           
            // 虚拟参数
              var dp = new DynamicParameters(new { });
           
                dp.Add("F_ProjectId", Projectid, DbType.String);
                strSql.Append(" AND t.F_ProjectId = @F_ProjectId ");
            //查询监理单位不为空的数据
            if (code == "1")
            {
                strSql.Append(" AND t.F_SupervisionCompany != '' ");
            }
            //查询监理单位为空的数据为参建单位
            else if(code == "2")
            {
                strSql.Append(" AND t.F_SupervisionCompany = '' ");
            }
                strSql.Append(" order by F_Month desc  ");

            DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);

            Dictionary<string, string> dic = new Dictionary<string, string>();
           
            dic.Add("F_Titile", "ProjectTitle");
          
            DataConvertSerivers sevices = new DataConvertSerivers();
            sevices.ConvertDataByDataItem(dt, dic);
            return dt;




        }
        public DataTable GetRecord1(string Projectid, string Month)
        {

            var strSql = new StringBuilder();

            strSql.Append(@"
               SELECT
	top 1000000 t.Project_AttenceRecordId,
	t.F_CreateUserName,
   	SUBSTRING(t.F_Month,0,5)Years,
	t.F_Month,
	t.F_SecondAttenceDateTime,
	t.F_FirstAttenceDateTime,
	b.F_ProjectName AS F_ProjectId,
	t.F_Titile,
	t.F_Class,
	t.Project_AttenceDateTime,
	t.Project_AttenceDate,
	t.F_Description,
    t.F_SupervisionCompany
FROM
	Project_AttenceRecord t
	LEFT JOIN DC_EngineProject_ProjectInfo b ON b.F_PIId = t.F_ProjectId
                ");

            strSql.Append("  WHERE 1=1 ");

            // 虚拟参数
            var dp = new DynamicParameters(new { });

            dp.Add("F_ProjectId", Projectid, DbType.String);
            strSql.Append(" AND t.F_ProjectId = @F_ProjectId ");
            strSql.Append(" order by F_Month desc  ");
            //dp.Add("F_Month", Month, DbType.String);
            //strSql.Append(" AND t.F_Month = @F_Month ");

            DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("F_Titile", "ProjectTitle");

            DataConvertSerivers sevices = new DataConvertSerivers();
            sevices.ConvertDataByDataItem(dt, dic);
            return dt;
        }

        /// <summary>
        /// 获取Project_AttenceRecord表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Project_AttenceRecordEntity GetProject_AttenceRecordEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Project_AttenceRecordEntity>(keyValue);
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
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectInfoEntity>(t=>t.F_PIId == keyValue);
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
                return this.BaseRepository().FindTable(@" select  F_PIId ,F_ProjectName from DC_EngineProject_ProjectInfo
where f_projectstate =0  ");
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
                this.BaseRepository().Delete<Project_AttenceRecordEntity>(t => t.Project_AttenceRecordId == keyValue);
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
        public void SaveEntity(string keyValue, Project_AttenceRecordEntity entity,DC_EngineProject_ProjectInfoEntity dC_EngineProject_ProjectInfoEntity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var project_AttenceRecordEntityTmp = GetProject_AttenceRecordEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //db.Delete<DC_EngineProject_ProjectInfoEntity>(t=>t.F_PIId == project_AttenceRecordEntityTmp.F_ProjectId);
                    //dC_EngineProject_ProjectInfoEntity.Create();
                    //dC_EngineProject_ProjectInfoEntity.F_PIId = project_AttenceRecordEntityTmp.F_ProjectId;
                    //db.Insert(dC_EngineProject_ProjectInfoEntity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    //dC_EngineProject_ProjectInfoEntity.Create();
                    //dC_EngineProject_ProjectInfoEntity.F_PIId = entity.F_ProjectId;
                    //db.Insert(dC_EngineProject_ProjectInfoEntity);
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
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="dtTable"></param>
        /// <returns></returns>
        public bool Import_LandHandUpInfoEntity(DataTable dtTable)
        {
            var db = this.BaseRepository().BeginTrans();
            Project_AttenceRecordEntity entity = null;
            DataTable dt1 =   this.BaseRepository().FindTable(@" select F_ProjectName,F_PIId from DC_EngineProject_ProjectInfo ");

            Hashtable ht = new Hashtable();
            foreach (DataRow dr in dt1.Rows)
            {
                ht.Add(""+ dr["F_ProjectName"].ToString() + "",""+ dr["F_PIId"].ToString() + "");
            }
            string temp1 = string.Empty;
            int f = 0;
            try
            {
                foreach (DataRow dt in dtTable.Rows)
                {
                    entity = new Project_AttenceRecordEntity();
                    string name = dt[0].ToString();
                    if (!ht.Contains(""+dt[0]+"")) continue;
                    
                    if (!dt[0].IsEmpty())
                    {
                        string n = ht["" + dt[0] + ""].ToString();
                       entity.F_ProjectId = ht[""+ dt[0] + ""].ToString();
                    }
                    if (!dt[1].IsEmpty())
                    {
                        entity.F_SupervisionCompany = dt[1].ToString();
                    }
                    if (!dt[2].IsEmpty())
                    {
                        entity.F_BuildCompany = dt[2].ToString();
                    }
                    if (!dt[3].IsEmpty())
                    {
                        entity.F_constructionCompany = dt[3].ToString();
                    }
                    if (!dt[4].IsEmpty())
                    {
                        entity.F_Project_AttenceDeptId = dt[4].ToString();
                    }
                    if (!dt[5].IsEmpty())
                    {
                        entity.F_CreateUserName = dt[5].ToString();
                    }
                    if (!dt[6].IsEmpty())
                    {
                        entity.Project_Attencedays = dt[6].ToString();

                    }
                    if (!dt[7].IsEmpty())
                    {
                        entity.Project_Attencednumber = dt[7].ToString();

                    }
                    if (!dt[8].IsEmpty())
                    {
                        int num = dt[8].ToString().Split(' ')[1].Split(':')[0].ToInt();
                        if (num >= 12)
                        {
                            //早上打卡时间
                            entity.F_FirstAttenceDateTime = dt[8].ToString().ToDate();
                        }
                        else {
                            //下午打卡时间
                            entity.F_SecondAttenceDateTime = dt[8].ToString().ToDate();

                        }
                       

                    }
                    if (!dt[9].IsEmpty())
                    {
                        entity.Project_mode = dt[9].ToString();

                    }
                    if (!dt[10].IsEmpty())
                    {
                        entity.Project_code = dt[10].ToString();

                    }
                    if (!dt[11].IsEmpty())
                    {
                        entity.Project_compare = dt[11].ToString();

                    }
                    entity.Create();
                   int q= db.Insert<Project_AttenceRecordEntity>(entity);
                    f++;

                }

                db.Commit();
            }
            catch (Exception ex)
            {
                temp1 = f.ToString();
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

            return true;
        }

        #endregion

    }
}
