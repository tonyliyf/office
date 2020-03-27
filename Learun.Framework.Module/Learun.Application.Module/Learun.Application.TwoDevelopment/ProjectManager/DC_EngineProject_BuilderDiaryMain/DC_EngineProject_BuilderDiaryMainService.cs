using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.Application.TwoDevelopment.EcologyDemo;
using Learun.Application.TwoDevelopment.LR_CodeDemo;

namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 10:59
    /// 描 述：DC_EngineProject_BuilderDiaryMain
    /// </summary>
    public class DC_EngineProject_BuilderDiaryMainService : RepositoryFactory
    {
        private F_Annxles_weaverIBLL annxles = new F_Annxles_weaverBLL();
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
                t.F_BDMId,
                f.F_ProjectName as F_PIId,
                t.F_BDNum,
                d.F_FullName as F_CreateDepartmentId,
                e.F_RealName as F_CreateUserid,
                t.F_CreateDatetime,
                t.F_BuildProgress,
                t.F_BuildMainWork,
                t.F_Attachments
             
                ");
                strSql.Append(@" from DC_EngineProject_BuilderDiaryMain t 

left join LR_Base_Department d on t.F_CreateDepartmentId=d.F_DepartmentId

left join  LR_Base_User e on t.F_CreateUserid=e.F_UserId
left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDatetime >= @startTime AND t.F_CreateDatetime <= @endTime ) ");
                }
                if (!queryParam["F_CreateDepartmentId"].IsEmpty())
                {
                    dp.Add("F_CreateDepartmentId", queryParam["F_CreateDepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateDepartmentId = @F_CreateDepartmentId ");
                }
                if (!queryParam["F_CreateUserid"].IsEmpty())
                {
                    dp.Add("F_CreateUserid", queryParam["F_CreateUserid"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateUserid = @F_CreateUserid ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
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
        public IEnumerable<formtable_main_134Entity> GetPageList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();

            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
                select t.*,h.lastname,t.rzxmmc as  F_PIId from ecology.dbo.formtable_main_134  t join ecology.dbo.hrmresource h on 
        t.txr	 =h.id
                ");


                strSql.Append("  WHERE 1=1 ");

                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.txsj >= @startTime AND t.txsj <= @endTime ) ");
                }
                if (!queryParam["F_CreateDepartmentId"].IsEmpty())
                {
                    dp.Add("F_CreateDepartmentId", queryParam["F_CreateDepartmentId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_CreateDepartmentId = @F_CreateDepartmentId ");
                }
                if (!queryParam["F_CreateUserid"].IsEmpty())
                {
                    dp.Add("F_CreateUserid", queryParam["F_CreateUserid"].ToString(), DbType.String);
                    strSql.Append(" AND h.lastname = @F_CreateUserid ");
                }
                return this.BaseRepository().FindList<formtable_main_134Entity>(strSql.ToString(), dp, pagination);
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
        /// 施工日志
        /// </summary>
        /// <param name="Projectid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetMainRecord(string Projectid, string code)
        {

            try
            {
                var strSql = new StringBuilder();

                strSql.Append(@"
SELECT
	b.*,
	h.lastname,
	b.rzxmmc AS F_PIId,
	f.subcompanyname 
FROM
	(
SELECT
	
	t.* 
FROM
	 ecology.dbo.formtable_main_134 t 
	) b
	JOIN ecology.dbo.hrmresource h ON b.txr = h.id
	JOIN ecology.dbo.HrmSubCompany f ON f.id = b.dwzz 
WHERE
	1 = 1");

                if (!string.IsNullOrEmpty(code))
                {
                    string temp = code.Substring(0, 4) + "-" + code.Substring(4, 2);
                    strSql.Append("and b.txsj like '" + temp + "%'");

                    SimpleLogUtil.WriteTextLog("MainRecordCode", temp, DateTime.Now);
                }
                //无年月参数查询所有
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_PIId", Projectid, DbType.String);
                strSql.Append(" AND b.rzxmmc = @F_PIId ");
                strSql.Append(" order by  b.txsj desc");

                SimpleLogUtil.WriteTextLog("MainRecordstrSql", strSql.ToString(), DateTime.Now);
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                dt.Columns.Add("fj2");
                foreach (DataRow dr in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["fj"].ToString()))
                    {
                        dr["fj"] = annxles.GetWeaverFileUrl(int.Parse(dr["id"].ToString()), "formtable_main_134",true);
                        dr["fj2"] = annxles.GetWeaverFileUrl(int.Parse(dr["id"].ToString()), "formtable_main_134", false);

                        SimpleLogUtil.WriteTextLog("MainRecordstrfj", dr["fj"].ToString(), DateTime.Now);

                    }


                }
                return dt;
            }
            catch (Exception ex)
            {
                SimpleLogUtil.WriteTextLog("MainRecord", ex.Message, DateTime.Now);
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
        /// 最大日期,最小日期
        /// </summary>
        /// <param name="Projectid"></param>
        /// <returns></returns>
        public DataTable MaxTime(string Projectid)
        {

            try
            {
                var strSql = new StringBuilder();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                strSql.Append(@"
SELECT
max(t.txsj) as maxtxsj,
min(t.txsj) as mintxsj
FROM
	 ecology.dbo.formtable_main_134 t 
	WHERE
	1 = 1");
                dp.Add("F_PIId", Projectid, DbType.String);
                strSql.Append(" AND t.rzxmmc = @F_PIId ");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
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
        /// 最大日期
        /// </summary>
        /// <param name="Projectid"></param>
        /// <returns></returns>
        public DataTable MinTime(string Projectid)
        {

            try
            {
                var strSql = new StringBuilder();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                strSql.Append(@"
SELECT
min(t.txsj) as mintxsj
FROM
	 ecology.dbo.formtable_main_134 t 
	WHERE
	1 = 1");
                dp.Add("F_PIId", Projectid, DbType.String);
                strSql.Append(" AND t.rzxmmc = @F_PIId ");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
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


        public formtable_main_134Entity SelectRecord(string id)
        {

            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                select h.lastname,t.rzxmmc as  F_PIId,t.*
from ecology.dbo.formtable_main_134  t join ecology.dbo.hrmresource h on 
        t.txr	 =h.id
                ");
                strSql.Append("  WHERE 1=1 ");

                // 虚拟参数
                var dp = new DynamicParameters(new { });


                dp.Add("F_PIId", id, DbType.String);
                strSql.Append(" AND t.id = @F_PIId ");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                DataTable dt1 = this.BaseRepository().FindTable("select * from DC_EngineProject_ProjectInfo where F_PIId='" + dt.Rows[0]["F_PIId"].ToString() + "'");
                formtable_main_134Entity num1 = new formtable_main_134Entity();

                if (dt1.Rows.Count > 0)
                {
                    num1.F_PIId = dt1.Rows[0]["F_ProjectName"].ToString();
                }
                num1.lastname = dt.Rows[0]["lastname"].ToString();
                num1.rzbh = dt.Rows[0]["rzbh"].ToString();
                num1.txsj = dt.Rows[0]["txsj"].ToString();
                num1.txbm = dt.Rows[0]["txbm"].ToInt();
                num1.tqqk = dt.Rows[0]["tqqk"].ToString();
                num1.sgrs = dt.Rows[0]["sgrs"].ToString();
                num1.sgjx = dt.Rows[0]["sgjx"].ToString();
                num1.sgjzqk = dt.Rows[0]["sgjzqk"].ToString();
                num1.mrjhap = dt.Rows[0]["mrjhap"].ToString();
                num1.fj = dt.Rows[0]["fj"].ToString();

                return num1;

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
        /// 获取DC_EngineProject_BuilderDiaryDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_BuilderDiaryDetailEntity> GetDC_EngineProject_BuilderDiaryDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_EngineProject_BuilderDiaryDetailEntity>(t => t.F_BDDId == keyValue);
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
        /// 获取DC_EngineProject_BuilderDiaryMain表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_BuilderDiaryMainEntity GetDC_EngineProject_BuilderDiaryMainEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_BuilderDiaryMainEntity>(keyValue);
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
        /// 获取DC_EngineProject_BuilderDiaryDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_BuilderDiaryDetailEntity GetDC_EngineProject_BuilderDiaryDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_BuilderDiaryDetailEntity>(t => t.F_BDDId == keyValue);
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
                var dC_EngineProject_BuilderDiaryMainEntity = GetDC_EngineProject_BuilderDiaryMainEntity(keyValue);
                db.Delete<DC_EngineProject_BuilderDiaryMainEntity>(t => t.F_BDMId == keyValue);
                db.Delete<DC_EngineProject_BuilderDiaryDetailEntity>(t => t.F_BDDId == dC_EngineProject_BuilderDiaryMainEntity.F_BDMId);
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
        public void SaveEntity(string keyValue, DC_EngineProject_BuilderDiaryMainEntity entity, List<DC_EngineProject_BuilderDiaryDetailEntity> dC_EngineProject_BuilderDiaryDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_EngineProject_BuilderDiaryMainEntityTmp = GetDC_EngineProject_BuilderDiaryMainEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_EngineProject_BuilderDiaryDetailEntity>(t => t.F_BDDId == dC_EngineProject_BuilderDiaryMainEntityTmp.F_BDMId);
                    if (dC_EngineProject_BuilderDiaryDetailList != null)
                    {
                        foreach (DC_EngineProject_BuilderDiaryDetailEntity item in dC_EngineProject_BuilderDiaryDetailList)
                        {
                            item.Create();
                            item.F_BDDId = dC_EngineProject_BuilderDiaryMainEntityTmp.F_BDMId;
                            db.Insert(item);
                        }
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    if (dC_EngineProject_BuilderDiaryDetailList != null)
                    {
                        foreach (DC_EngineProject_BuilderDiaryDetailEntity item in dC_EngineProject_BuilderDiaryDetailList)
                        {
                            item.Create();
                            item.F_BDDId = entity.F_BDMId;
                            db.Insert(item);
                        }
                    }
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

        #endregion

    }
}
