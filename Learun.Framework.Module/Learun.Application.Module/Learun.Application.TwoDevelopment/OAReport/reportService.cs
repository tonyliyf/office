using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.OAReport
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 10:44
    /// 描 述：报表
    /// </summary>
    public class reportService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取报表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT  ");
                strSql.Append(@"
                t.f_chanceid,
                t.f_encode,
                t.f_fullname,
                t.f_sourceid,
                t.f_stageid,
                t.f_successrate,
                t.f_amount,
                t.f_profit,
                t.f_chancetypeid,
                t.f_salecost,
                t.f_dealdate,
                t.f_istocustom,
                t.f_companyname,
                t.f_companynatureid,
                t.f_companyaddress,
                t.f_companysite,
                t.f_companydesc,
                t.f_province,
                t.f_city,
                t.f_contacts,
                t.f_mobile,
                t.f_tel,
                t.f_fax,
                t.f_qq,
                t.f_email,
                t.f_wechat,
                t.f_hobby,
                t.f_traceuserid,
                t.f_traceusername,
                t.f_chancestate,
                t.f_alertdatetime,
                t.f_alertstate,
                t.f_sortcode,
                t.f_deletemark,
                t.f_enabledmark,
                t.f_description,
                t.f_createdate,
                t.f_createuserid,
                t.f_createusername,
                t.f_modifydate,
                t.f_modifyuserid,
                t.f_modifyusername
                ");
                strSql.Append("  FROM (select * from lr_crm_chance)t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["f_encode"].IsEmpty())
                {
                    dp.Add("f_encode", "%" + queryParam["f_encode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.f_encode Like @f_encode ");
                }
                if (!queryParam["f_fullname"].IsEmpty())
                {
                    dp.Add("f_fullname", "%" + queryParam["f_fullname"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.f_fullname Like @f_fullname ");
                }
                if (!queryParam["f_salecost"].IsEmpty())
                {
                    dp.Add("f_salecost", "%" + queryParam["f_salecost"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.f_salecost Like @f_salecost ");
                }
                if (!queryParam["f_profit"].IsEmpty())
                {
                    dp.Add("f_profit", "%" + queryParam["f_profit"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.f_profit Like @f_profit ");
                }
                return this.BaseRepository().FindTable(strSql.ToString(), dp);
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

        public DataTable GetLeaderData(DateTime dtStart, DateTime dtEnd)
        {
            //DateTime dtStart = DateTime.Now.AddMonths(-6);
            var dp = new DynamicParameters(new { });
            //DateTime dtEnd = DateTime.Now;
            dp.Add("startTime", dtStart, DbType.DateTime);
            dp.Add("endTime", dtEnd, DbType.DateTime);
            string strSql = @"select sum(t.F_ApproveMoney)SumMoney,CONVERT(varchar(6), F_CreateDate, 112)Month ,1 as type
           from DC_OA_AppropriationApprove t where is_agree = '2' and t.F_CreateDate >= @startTime AND t.F_CreateDate < @endTime  GROUP BY CONVERT(varchar(6), F_CreateDate, 112)
union select sum(t.F_Money)SumMoney,CONVERT(varchar(6), F_CreateDate, 112)Month ,2 as type
from DC_OA_LargeCostPay t where is_agree = '2' and t.F_CreateDate >= @startTime AND t.F_CreateDate < @endTime GROUP BY CONVERT(varchar(6), F_CreateDate, 112)
union  select sum(t.F_ReimbursementMoney)SumMoney,CONVERT(varchar(6), F_CreateDate, 112)Month ,3 as type
from DC_OA_CostReimbursementGather t where is_agree = '2'  and t.F_CreateDate >= @startTime AND t.F_CreateDate < @endTime GROUP BY CONVERT(varchar(6), F_CreateDate, 112)";

            try
            {
                return this.BaseRepository().FindTable(strSql.ToString(), dp);

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


        public DataTable GetFlowData()
        {

            DateTime dtStart = DateTime.Now.AddMonths(-6);
            var dp = new DynamicParameters(new { });
            DateTime dtEnd = DateTime.Now;
            dp.Add("startTime", dtStart, DbType.DateTime);
            dp.Add("endTime", dtEnd, DbType.DateTime);
            string strSql = @"SELECT  t.F_Category,count(*) sums from  LR_Nwf_process r join  LR_NWF_Scheme  p
              on  p.F_Id = r.F_SchemeId  join  LR_NWF_SchemeInfo t on  t.F_Id = p.F_SchemeInfoId
                where r.F_IsFinished =1   and r.F_CreateDate >= @startTime AND r.F_CreateDate < @endTime group by t.F_Category";
            try
            {
                return this.BaseRepository().FindTable(strSql.ToString(),dp);

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

    }
}
#endregion

