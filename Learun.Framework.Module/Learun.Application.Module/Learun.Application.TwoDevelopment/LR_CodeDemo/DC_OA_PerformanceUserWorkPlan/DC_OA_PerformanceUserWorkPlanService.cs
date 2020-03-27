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
    /// 日 期：2019-01-25 17:08
    /// 描 述：DC_OA_PerformanceUserWorkPlan
    /// </summary>
    public class DC_OA_PerformanceUserWorkPlanService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceUserWorkPlanEntity> GetList(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_PerformanceUserWorkPlan t ");
                strSql.Append("  WHERE F_PUWId=@F_PUWId ");
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_PUWId", keyValue, DbType.String);
                return this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(strSql.ToString(), dp);
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
        public IEnumerable<DC_OA_PerformanceUserWorkPlanEntity> GetEvaluate2List(string keyValue)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                List<string> vList = this.BaseRepository().FindList<string>(@"  select t3.F_PEId from DC_OA_PerformanceUserWork t1,DC_OA_PerformanceUserWorkPlan t2,DC_OA_PerformanceEvaluation t3
  where t1.F_PUWId = t2.F_PUWId and t2.F_PUWPId = t3.F_PUWPId and t1.F_PUWId = '" + keyValue + "' and t3.F_EvaluationUserId = '" + user.userId + "'").ToList();
                if (vList.Count <= 0)
                {
                    var wpEntityList = this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(c => c.F_PUWId == keyValue);
                    foreach (var item in wpEntityList)
                    {
                        DC_OA_PerformanceEvaluationEntity model = new DC_OA_PerformanceEvaluationEntity();
                        model.Create();
                        model.F_PUWPId = item.F_PUWPId;
                        this.BaseRepository().Insert(model);
                    }
                }
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT  t1.[F_PUWPId]
                                  , t1.[F_TargetName]
                                  , t1.[F_TargetContent]
                                  , t1.[F_Target]
                                  , t1.[F_TargetExplain]
                                  ,[F_TargetScore]
                                  , t1.[F_Sort]
                                  , t1.[F_ParentId]
                                  , t1.[F_PerformanceInfo]
                                   ,t1.F_SelfScore  as F_PUWId
                                  , t2.F_EvaluationScore as F_SelfScore
                                  , t1.[F_IfTargetDefine]
                              FROM DC_OA_PerformanceUserWorkPlan t1
                              left join DC_OA_PerformanceEvaluation t2 on t1.F_PUWPId = t2.F_PUWPId");
                strSql.Append("  WHERE t1.F_PUWId=@F_PUWId and t2.F_EvaluationUserId=@F_EvaluationUserId");
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                dp.Add("F_PUWId", keyValue, DbType.String);
                dp.Add("F_EvaluationUserId", user.userId, DbType.String);
                return this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(strSql.ToString(), dp).OrderBy(c=>c.F_Sort);
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
        /// 获取DC_OA_PerformanceUserWorkPlan表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceUserWorkPlanEntity GetDC_OA_PerformanceUserWorkPlanEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkPlanEntity>(keyValue);
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
        public DC_OA_PerformanceUserWorkPlanEntity GetEvaluateEntity(string keyValue)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var entity = this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkPlanEntity>(keyValue);
                var temp = this.BaseRepository().FindEntity<DC_OA_PerformanceEvaluationEntity>(c => c.F_PUWPId == keyValue && c.F_EvaluationUserId == user.userId);
                if (temp == null)
                {
                    entity.F_SelfScore = null;
                }
                else
                {
                    entity.F_SelfScore = temp.F_EvaluationScore;
                }
                return entity;
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
                this.BaseRepository().Delete<DC_OA_PerformanceUserWorkPlanEntity>(t => t.F_PUWPId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkPlanEntity entity)
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

        public void SaveEvaluate3Entity(string wpid, int? score)
        {
            UserInfo user = LoginUserInfo.Get();
            var modifyEntity = this.BaseRepository().FindEntity<DC_OA_PerformanceEvaluationEntity>(c => c.F_PUWPId == wpid && c.F_EvaluationUserId == user.userId);
            if (modifyEntity != null)
            {
                modifyEntity.F_EvaluationScore = score;
                this.BaseRepository().Update(modifyEntity);
            }
        }
        #endregion

    }
}
