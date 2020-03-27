using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-02-07 14:22 
    /// 描 述：DC_OA_PurchasePublic 
    /// </summary> 
    public class DC_OA_PurchasePublicService : RepositoryFactory
    {
        #region 获取数据 

        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="queryJson">查询参数</param> 
        /// <returns></returns> 
        public IEnumerable<DC_OA_PurchasePublicEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
                t.F_PurchasePublicId, 
                t.F_PurchaseName, 
                t.F_PurchaseProjectNo, 
                t.F_CurrentCompanyName, 
                t.F_CurrentDeptName, 
                t.F_PurchaseMethod, 
                t.F_buyPlatform, 
                t.F_DealMoney, 
                t.F_CreateUserName, 
                t.F_DealUserPhone,
                t.Is_agree
                ");
                strSql.Append("  FROM DC_OA_PurchasePublic t ");
              
                var queryParam = queryJson.ToJObject();
                // 虚拟参数 
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CurrentCompanyName"].IsEmpty())
                {
                    dp.Add("F_CurrentCompanyName", "%" + queryParam["F_CurrentCompanyName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_CurrentCompanyName Like @F_CurrentCompanyName ");
                }
                if (!queryParam["F_PurchaseProjectNo"].IsEmpty())
                {
                    dp.Add("F_PurchaseProjectNo", "%" + queryParam["F_PurchaseProjectNo"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PurchaseProjectNo Like @F_PurchaseProjectNo ");
                }
                if (!queryParam["F_buyPlatform"].IsEmpty())
                {
                    dp.Add("F_buyPlatform", "%" + queryParam["F_buyPlatform"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_buyPlatform Like @F_buyPlatform ");
                }
                if (!queryParam["F_PurchaseMethod"].IsEmpty())
                {
                    dp.Add("F_PurchaseMethod", "%" + queryParam["F_PurchaseMethod"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PurchaseMethod Like @F_PurchaseMethod ");
                }
                return this.BaseRepository().FindList<DC_OA_PurchasePublicEntity>(strSql.ToString(), dp, pagination);
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

        public DataTable GetList(Pagination pagination, string queryJson)
        {
           
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@" 
                 t.f_purchasename,
                 t.f_purchaseprojectno,
                 t.f_currentcompanyname,
                 t.f_currentdeptname,
                 t.f_purchasemethod,
                 t.f_buyplatform,
                 t.f_dealmoney,
                 t.f_createusername,
                 t.f_dealuserphone,
                 t.is_agree,
                 t.F_PurchasePublicId
                ");
                strSql.Append("  FROM DC_OA_PurchasePublic t ");
                strSql.Append("  WHERE is_agree=2 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数 
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CurrentCompanyName"].IsEmpty())
                {
                    dp.Add("F_CurrentCompanyName", "%" + queryParam["F_CurrentCompanyName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_CurrentCompanyName Like @F_CurrentCompanyName ");
                }
                if (!queryParam["F_PurchaseProjectNo"].IsEmpty())
                {
                    dp.Add("F_PurchaseProjectNo", "%" + queryParam["F_PurchaseProjectNo"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PurchaseProjectNo Like @F_PurchaseProjectNo ");
                }
                if (!queryParam["F_buyPlatform"].IsEmpty())
                {
                    dp.Add("F_buyPlatform", "%" + queryParam["F_buyPlatform"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_buyPlatform Like @F_buyPlatform ");
                }
                if (!queryParam["F_PurchaseMethod"].IsEmpty())
                {
                    dp.Add("F_PurchaseMethod", "%" + queryParam["F_PurchaseMethod"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_PurchaseMethod Like @F_PurchaseMethod ");
                }
                return this.BaseRepository().FindTable(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_PurchasePublicDetail表数据 
        /// <summary> 
        /// <returns></returns> 
        public IEnumerable<DC_OA_PurchasePublicDetailEntity> GetDC_OA_PurchasePublicDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_PurchasePublicDetailEntity>(t => t.DC_OA_PurchasePublicRefId == keyValue);
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
        /// 获取DC_OA_PurchasePublic表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DC_OA_PurchasePublicEntity GetDC_OA_PurchasePublicEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PurchasePublicEntity>(keyValue);
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
        /// 获取DC_OA_PurchasePublicDetail表实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DC_OA_PurchasePublicDetailEntity GetDC_OA_PurchasePublicDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PurchasePublicDetailEntity>(t => t.DC_OA_PurchasePublicRefId == keyValue);
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
                var dC_OA_PurchasePublicEntity = GetDC_OA_PurchasePublicEntity(keyValue);
                db.Delete<DC_OA_PurchasePublicEntity>(t => t.F_PurchasePublicId == keyValue);
                db.Delete<DC_OA_PurchasePublicDetailEntity>(t => t.DC_OA_PurchasePublicRefId == dC_OA_PurchasePublicEntity.F_PurchasePublicId);
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
        public void SaveEntity(string keyValue, DC_OA_PurchasePublicEntity entity, List<DC_OA_PurchasePublicDetailEntity> dC_OA_PurchasePublicDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_PurchasePublicEntityTmp = GetDC_OA_PurchasePublicEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_OA_PurchasePublicDetailEntity>(t => t.DC_OA_PurchasePublicRefId == dC_OA_PurchasePublicEntityTmp.F_PurchasePublicId);
                    foreach (DC_OA_PurchasePublicDetailEntity item in dC_OA_PurchasePublicDetailList)
                    {
                        item.Create();
                        item.DC_OA_PurchasePublicRefId = dC_OA_PurchasePublicEntityTmp.F_PurchasePublicId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_OA_PurchasePublicDetailEntity item in dC_OA_PurchasePublicDetailList)
                    {
                        item.Create();
                        item.DC_OA_PurchasePublicRefId = entity.F_PurchasePublicId;
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