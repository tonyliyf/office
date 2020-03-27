using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.TwoDevelopment.SystemDemo;
namespace Learun.Application.TwoDevelopment.ProjectManager
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-15 15:20
    /// 描 述：DC_EngineProject_ProjectInfoContract
    /// </summary>
    public class DC_EngineProject_ProjectInfoContractService : RepositoryFactory
    {

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
                var queryParam = queryJson.ToJObject();

                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PICId,
                f.F_ProjectName as F_PIId,
                t.F_ProjectStage,
                t.F_ContractType,
                t.F_ContractCode,
                t.F_ContractName,
                t.F_ContractMoney,
                t.F_SettlementMethod,
                t.F_PayMethod,
                t.F_PartyAUnit,
                t.F_PartyABlameMan,
                t.F_PartyBUnit,
                t.F_PartyBBlameMan,
                t.F_SigningTime,
                t.F_Remarks
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectInfoContract t  left join DC_EngineProject_ProjectInfo f on f.F_PIId=t.F_PIId");
                string num = queryParam["F_PIId"].ToString();

                //strSql.Append("  WHERE t.F_PIId='086df13d-160b-4767-8767-82dcc2035fa9'");
                strSql.Append("  WHERE t.F_PIId='" + queryParam["F_PIId"].ToString() + "'");

                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["F_ContractName"].IsEmpty())
                {
                    dp.Add("F_ContractName", "%" + queryParam["F_ContractName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ContractName Like @F_ContractName ");
                }
                if (!queryParam["F_ContractType"].IsEmpty())
                {
                    dp.Add("F_ContractType", queryParam["F_ContractType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ContractType = @F_ContractType ");
                }
                if (!queryParam["F_SigningTime"].IsEmpty())
                {
                    dp.Add("F_SigningTime", queryParam["F_SigningTime"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_SigningTime = @F_SigningTime ");
                }
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString(), dp);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("F_ProjectStage", "88");
                dic.Add("F_ContractType", "EngineeringContractType");
                dic.Add("F_SettlementMethod", "SettlementMethod");
                dic.Add("F_PayMethod", "PayMethod");
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
        public DataTable GetProjectContractType()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
               select b.F_ItemName,b.F_ItemValue from LR_Base_DataItem a  left join LR_Base_DataItemDetail b on  a.F_ItemId=b.F_ItemId  where a.F_ItemCode='EngineeringContractType'  
                ");
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
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_EngineProject_ProjectInfoContractEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();

                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PICId,
                t.F_PIId,
                t.F_ProjectStage,
                t.F_ContractType,
                t.F_ContractCode,
                t.F_ContractName,
                t.F_ContractMoney,
                t.F_SettlementMethod,
                t.F_PayMethod,
                t.F_PartyAUnit,
                t.F_PartyABlameMan,
                t.F_PartyBUnit,
                t.F_PartyBBlameMan,
                t.F_SigningTime,
                t.F_Remarks,
                t.F_ContractAppendices,
                b.F_ProjectName
                ");
                strSql.Append("  FROM DC_EngineProject_ProjectInfoContract t left join DC_EngineProject_ProjectInfo b on t.F_PIId=b.F_PIId where 1=1 ");
             
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["F_ContractName"].IsEmpty())
                {
                    dp.Add("F_ContractName", "%" + queryParam["F_ContractName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ContractName Like @F_ContractName ");
                }
                if (!queryParam["F_ProjectName"].IsEmpty())
                {
                    dp.Add("F_ProjectName", "%" + queryParam["F_ProjectName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND b.F_ProjectName Like @F_ProjectName ");
                }
                if (!queryParam["F_ContractType"].IsEmpty())
                {
                    dp.Add("F_ContractType", queryParam["F_ContractType"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ContractType = @F_ContractType ");
                }
                if (!queryParam["F_SigningTime"].IsEmpty())
                {
                    dp.Add("F_SigningTime", queryParam["F_SigningTime"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_SigningTime = @F_SigningTime ");
                }
                return this.BaseRepository().FindList<DC_EngineProject_ProjectInfoContractEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_EngineProject_ProjectInfoContract表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_EngineProject_ProjectInfoContractEntity GetDC_EngineProject_ProjectInfoContractEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_EngineProject_ProjectInfoContractEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_EngineProject_ProjectInfoContractEntity>(t => t.F_PICId == keyValue);
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
        public void SaveEntity(string keyValue, DC_EngineProject_ProjectInfoContractEntity entity)
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

        public void UpdateProjectContract()
        {
            var db = this.BaseRepository().BeginTrans();
            DC_EngineProject_ProjectInfoContractEntity entity = null;

            try
            {
                var ContractList = db.FindList<DC_EngineProject_ProjectInfoContractEntity>(@"select t.*  FROM ecology.dbo.formtable_main_130 t   join  ecology.dbo.workflow_requestbase r
on t.requestid = r.requestid where r.currentnodetype = 3");

                //var ContractList = db.FindList<DC_EngineProject_ProjectInfoContractEntity>(@"select t.*  FROM ecology.dbo.formtable_main_130 t   ");
                foreach (var item in ContractList)
                {
                    entity = db.FindEntity<DC_EngineProject_ProjectInfoContractEntity>(i => i.id == item.id);
                    if(entity==null)
                    {
                        item.Create();
                        db.Insert(item);
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
