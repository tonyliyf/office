using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-02-26 16:28
    /// 描 述：DC_OA_OfficeWoodsReply
    /// </summary>
    public class DC_OA_OfficeWoodsReplyService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_OfficeWoodsReplyEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_OfficeWoodsReplyId,
                t.F_ReplyIdNo,
                t.F_ReplyMonth,
                t.F_CurrentCompanyId,
                t.F_CurrentDeptId,
                t.F_CreateUserId,
                t.F_CreateDate,
                t.F_File,
                t.F_Description
                ");
                strSql.Append("  FROM DC_OA_OfficeWoodsReply t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_OfficeWoodsReplyEntity>(strSql.ToString(), dp, pagination);

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


        public DataTable GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
           
                strSql.Append(@"
              SELECT  
                    c.F_FullName AS companyname,
                    r.F_FullName AS deptname, 
                    f_replymonth, 
                    d.f_woodname,
                    f.dc_oa_woodstype	,
                    f.dc_price, 
                    f.dc_unit, 
                    d.f_nums, 
                    F_OfficeWoodsReplyId
                FROM
	                DC_OA_OfficeWoodsReply t
	                LEFT JOIN DC_OA_officeWoodsReplyDetail d ON t.F_OfficeWoodsReplyId = d.F_ReplyId
	                LEFT JOIN LR_Base_Company c ON t.F_CurrentCompanyId = c.F_CompanyId
	                LEFT JOIN LR_Base_Department r ON t.F_CurrentDeptId = r.F_DepartmentId
	                left join DC_OA_OfficeWoods f on d.F_WoodId =f.DC_OA_WoodsId
	                where  t.F_type =1 and Is_agree ='2' 
                ");
             
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty())
                {

                    dp.Add("StartTime", queryParam["StartTime"].ToString(), DbType.String);
                    strSql.Append("  AND t.F_ReplyMonth = @StartTime  ");
                }

                if (!queryParam["F_Company"].IsEmpty())
                {
                    dp.Add("F_Company", "%" + queryParam["F_Company"].ToString() + "%", DbType.String);
                    strSql.Append("  AND c.F_FullName  Like @F_Company ");
                }
                if (!queryParam["F_Dept"].IsEmpty())
                {
                    dp.Add("F_Dept", "%" + queryParam["F_Dept"].ToString() + "%", DbType.String);
                    strSql.Append("  AND  r.F_FullName Like @F_Dept ");
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

        /// <summary>
        /// 获取DC_OA_OfficeWoodsReplyDetail表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<DC_OA_OfficeWoodsReplyDetailEntity> GetDC_OA_OfficeWoodsReplyDetailList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<DC_OA_OfficeWoodsReplyDetailEntity>(t => t.F_ReplyId == keyValue);
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
        public List<DC_OA_OfficeWoodsReplyDetailEntity> GetDC_OA_OfficeWoodsReplyDetailTotalListByMonth(string month, out double sum)
        {
            try
            {
                sum = 0f;
                List<DC_OA_OfficeWoodsReplyDetailEntity> list = new List<DC_OA_OfficeWoodsReplyDetailEntity>();
                var replyList = this.BaseRepository().FindList<DC_OA_OfficeWoodsReplyEntity>(c => c.Is_agree == "2" && c.F_type == 1 && c.F_ReplyMonth == month);
                foreach (var item in replyList)
                {
                    var detailList = this.BaseRepository().FindList<DC_OA_OfficeWoodsReplyDetailEntity>(c => c.F_ReplyId == item.F_OfficeWoodsReplyId && c.F_Nums.HasValue);
                    if (item.F_SumMoney.HasValue)
                    {
                        sum += item.F_SumMoney.Value;
                    }
                    foreach (var item1 in detailList)
                    {
                        if (list.Exists(c => c.F_WoodId == item1.F_WoodId))
                        {
                            list.Where(c => c.F_WoodId == item1.F_WoodId).First().F_Nums += item1.F_Nums;
                        }
                        else
                        {
                            list.Add(item1);
                        }
                    }
                }
                return list;
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
        /// 获取DC_OA_OfficeWoodsReply表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OfficeWoodsReplyEntity GetDC_OA_OfficeWoodsReplyEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OfficeWoodsReplyEntity>(keyValue);
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
        /// 获取DC_OA_OfficeWoodsReplyDetail表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_OfficeWoodsReplyDetailEntity GetDC_OA_OfficeWoodsReplyDetailEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OfficeWoodsReplyDetailEntity>(t => t.F_ReplyId == keyValue);
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
        public DC_OA_OfficeWoodsReplyEntity GetEntityByProcessId(string processId)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_OfficeWoodsReplyEntity>(t => t.F_OfficeWoodsReplyId == processId);
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
                var dC_OA_OfficeWoodsReplyEntity = GetDC_OA_OfficeWoodsReplyEntity(keyValue);
                db.Delete<DC_OA_OfficeWoodsReplyEntity>(t => t.F_OfficeWoodsReplyId == keyValue);
                db.Delete<DC_OA_OfficeWoodsReplyDetailEntity>(t => t.F_ReplyId == dC_OA_OfficeWoodsReplyEntity.F_OfficeWoodsReplyId);
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
        public void SaveEntity(string keyValue, DC_OA_OfficeWoodsReplyEntity entity, List<DC_OA_OfficeWoodsReplyDetailEntity> dC_OA_OfficeWoodsReplyDetailList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var dC_OA_OfficeWoodsReplyEntityTmp = GetDC_OA_OfficeWoodsReplyEntity(keyValue);
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<DC_OA_OfficeWoodsReplyDetailEntity>(t => t.F_ReplyId == dC_OA_OfficeWoodsReplyEntityTmp.F_OfficeWoodsReplyId);
                    foreach (DC_OA_OfficeWoodsReplyDetailEntity item in dC_OA_OfficeWoodsReplyDetailList)
                    {
                        item.Create();
                        item.F_ReplyId = dC_OA_OfficeWoodsReplyEntityTmp.F_OfficeWoodsReplyId;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (DC_OA_OfficeWoodsReplyDetailEntity item in dC_OA_OfficeWoodsReplyDetailList)
                    {
                        item.Create();
                        item.F_ReplyId = entity.F_OfficeWoodsReplyId;
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
