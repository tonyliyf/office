using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.EcologyDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-09-06 11:15
    /// 描 述：广告牌维修记录
    /// </summary>
    public class BusStopBillboardsRepairRecordService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<formtable_main_129Entity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
              
                strSql.Append(@"
              select d.F_BillboardsName ,d.F_InstallationLocation,h.lastname,m.* from ecology.dbo.formtable_main_129  m  join  ecology.dbo.workflow_requestbase r
on m.requestid = r.requestid join  DC_ASSETS_BusStopBillboards d on m.ggpmc = d.F_BSBId join ecology.dbo.hrmresource h on 
m.sqyh =h.id where r.currentnodetype=3

                ");
              
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["sqyh"].IsEmpty())
                {
                    dp.Add("sqyh", "%" + queryParam["sqyh"].ToString() + "%", DbType.String);
                    strSql.Append(" AND h.lastname Like @sqyh ");
                }
                return this.BaseRepository().FindList<formtable_main_129Entity>(strSql.ToString(),dp, pagination);
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
        public formtable_main_129Entity GetDC_EngineProject_formtable_main_129Entity(string keyValue)
        {
            try
            {
                return this.BaseRepository("ecologySql").FindEntity<formtable_main_129Entity>(keyValue);
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
