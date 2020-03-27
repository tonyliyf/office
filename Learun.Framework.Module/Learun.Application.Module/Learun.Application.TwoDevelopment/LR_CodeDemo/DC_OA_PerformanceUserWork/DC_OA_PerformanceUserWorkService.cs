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
    /// 日 期：2019-01-26 11:12
    /// 描 述：DC_OA_PerformanceUserWork
    /// </summary>
    public class DC_OA_PerformanceUserWorkService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceUserWorkModel> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PUWId,
                t.F_PUWName,
                t.F_PUWUserId,
                t.F_PUWDepartmentId,
                t.F_AppraisalCycleValue,
                t.F_SelfWeight,
                t.F_PEPoint,
                case when (select count(*) from DC_OA_PRREvaluationUserRelation where F_PRRId=t.F_PRRId and F_EvaluationUserId=@PRRUID)>0 then 'true' else 'false' end as isChecker
                ");
                strSql.Append("  FROM DC_OA_PerformanceUserWork t where 1=1");
                var queryParam = queryJson.ToJObject();
                var dp = new DynamicParameters(new { });
                if (queryParam["F_PEPoint"].IsEmpty())
                {
                    if (user.userId != "System")
                    {
                        strSql.Append(@"  and ((select count(*) from DC_OA_PRREvaluationUserRelation where F_PRRId=t.F_PRRId and F_EvaluationUserId=@PRRUID)>0 
                        or t.F_PUWUserId=@PRRUID) ");
                    }
                }
                else
                {
                    var pointName = queryParam["F_PEPoint"].ToString();
                    dp.Add("F_PEPoint", pointName, DbType.String);
                    strSql.Append("  and t.F_PEPoint=@F_PEPoint ");
                    if (pointName == "考核评估" && user.userId != "System")
                    {
                        strSql.Append(@"  and (select count(*) from DC_OA_PRREvaluationUserRelation where F_PRRId=t.F_PRRId and F_EvaluationUserId=@PRRUID)>0 ");
                    }
                    else if (pointName == "考核自评" && user.userId != "System")
                    {
                        strSql.Append(@" and  (select count(*) from DC_OA_PRRSelfUserRelation where F_PRRId=t.F_PRRId and F_SelfUserId=@PRRUID)>0  ");
                    }
                    else if (pointName == "考核评价" && user.userId != "System")
                    {
                        strSql.Append(@"  and (select count(*) from DC_OA_PRREvaluationUserRelation where F_PRRId=t.F_PRRId and F_EvaluationUserId=@PRRUID)>0 ");
                    }
                }
                dp.Add("PRRUID", user.userId, DbType.String);
                return this.BaseRepository().FindList<DC_OA_PerformanceUserWorkModel>(strSql.ToString(), dp, pagination);
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
        /// 获取DC_OA_PerformanceUserWork表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceUserWorkEntity GetDC_OA_PerformanceUserWorkEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkEntity>(keyValue);
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
                string sql;
                UserInfo user = LoginUserInfo.Get();
                if (user.userId != "System")
                {
                    sql = @"  select 0 as pid,t1.F_PRRId as id , t1.F_PerformanceName as name from 
                  DC_OA_PerformanceRecordRun t1,DC_OA_PRRSelfUserRelation t2
                  where t1.F_PRRId=t2.F_PRRId";
                    sql += " and t2.F_SelfUserId = '" + user.userId + "'";
                }
                else
                {
                    sql = @"select 0 as pid,t1.F_PRRId as id , t1.F_PerformanceName as name from 
                  DC_OA_PerformanceRecordRun t1";
                }
                return this.BaseRepository().FindTable(sql);
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
                this.BaseRepository().Delete<DC_OA_PerformanceUserWorkEntity>(t => t.F_PUWId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceUserWorkEntity entity)
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


        public void DoExcute(string rid)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var rEntity = db.FindEntity<DC_OA_PerformanceRecordRunEntity>(rid);
                if (rEntity != null)
                {
                    var tEntity = db.FindEntity<DC_OA_PerformanceAppraisalTemplateEntity>(rEntity.F_PATId);
                    if (tEntity != null)
                    {
                        DateTime now = DateTime.Now;
                        UserInfo user = LoginUserInfo.Get();
                        DC_OA_PerformanceUserWorkEntity wModel = new DC_OA_PerformanceUserWorkEntity();
                        List<DC_OA_PerformanceUserWorkPlanEntity> weModelList = new List<DC_OA_PerformanceUserWorkPlanEntity>();
                        List<DC_OA_PerformanceAppraisalEntity> source = db.FindList<DC_OA_PerformanceAppraisalEntity>(c => c.F_PATId == rEntity.F_PATId).ToList();
                        wModel.Create();

                        wModel.F_AppraisalCycleType = rEntity.F_AppraisalCycleType;
                        wModel.F_AppraisalCycleValue = wModel.F_AppraisalCycleType == 1 ? now.ToString("yyyyMM") : now.ToString("yyyy");
                        wModel.F_PEPoint = "工作计划";
                        wModel.F_PRRId = rid;
                        wModel.F_PUWDepartmentId = user.departmentId;
                        wModel.F_PUWName = rEntity.F_PerformanceName + wModel.F_AppraisalCycleValue + (wModel.F_AppraisalCycleType == 1 ? "月度" : "年度") + "考核表";
                        wModel.F_PUWUserId = user.userId;
                        wModel.F_SelfWeight = rEntity.F_SelfWeight;
                        wModel.F_IfSelfJudge = rEntity.F_IfSelfJudge ?? 0;
                        foreach (var item in source.Where(c => c.F_ParentId == ""))
                        {
                            GenerateTree(wModel.F_PUWId, "", weModelList, source, item);
                        }

                        db.Insert(wModel);
                        db.Insert(weModelList);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }

        }

        private void GenerateTree(string wid, string pid, List<DC_OA_PerformanceUserWorkPlanEntity> target,
            List<DC_OA_PerformanceAppraisalEntity> source, DC_OA_PerformanceAppraisalEntity cNode)
        {
            var guid = Guid.NewGuid().ToString();
            DC_OA_PerformanceUserWorkPlanEntity wpEntity = new DC_OA_PerformanceUserWorkPlanEntity()
            {
                F_PUWPId = guid,
                F_IfTargetDefine = cNode.F_IfTargetDefine,
                F_ParentId = pid,
                F_PUWId = wid,
                F_Sort = cNode.F_Sort,
                F_Target = cNode.F_Target,
                F_TargetContent = cNode.F_TargetContent,
                F_TargetExplain = cNode.F_TargetExplain,
                F_TargetName = cNode.F_TargetName,
                F_TargetScore = cNode.F_TargetScore
            };
            target.Add(wpEntity);
            foreach (var item in source.Where(c => c.F_ParentId == cNode.F_PAId))
            {
                GenerateTree(wid, guid, target, source, item);
            }
        }

        public bool ExistWork(string rid)
        {
            UserInfo user = LoginUserInfo.Get();
            DateTime now = DateTime.Now;
            var nowStr1 = now.ToString("yyyyMM");
            var nowStr2 = now.ToString("yyyy");
            return this.BaseRepository().
                FindList<DC_OA_PerformanceUserWorkEntity>(c => c.F_PRRId == rid &&
                (c.F_AppraisalCycleValue == nowStr1 || c.F_AppraisalCycleValue == nowStr2) && c.F_PUWUserId == user.userId)
                .Count() > 0;
        }
        //开始考核
        public bool BeginCheck(string wid)
        {
            var db = this.BaseRepository().BeginTrans();

            try
            {
                var wEntity = db.FindEntity<DC_OA_PerformanceUserWorkEntity>(wid);
                if (wEntity != null && wEntity.F_PEPoint == "工作计划")
                {

                    wEntity.F_PEPoint = "考核评估";
                    db.Update(wEntity);
                    DC_OA_PerformanceExecuteEntity log = new DC_OA_PerformanceExecuteEntity();
                    log.Create();
                    log.F_PEPoint = "工作计划";
                    log.F_PointState = 1;
                    log.F_PointText = "";
                    log.F_PUWId = wid;
                    db.Insert(log);
                    db.Commit();
                    return true;
                }
                else
                {
                    db.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        //考核评估
        public bool Evaluate1(string wid, string text, int agree)
        {
            var db = this.BaseRepository().BeginTrans();

            try
            {
                var wEntity = db.FindEntity<DC_OA_PerformanceUserWorkEntity>(wid);
                if (wEntity != null && wEntity.F_PEPoint == "考核评估")
                {

                    if (agree == 1)
                    {
                        if (wEntity.F_IfSelfJudge == 1)
                        {
                            wEntity.F_PEPoint = "考核自评";
                        }
                        else
                        {
                            wEntity.F_PEPoint = "考核评价";
                        }
                    }
                    else
                    {
                        wEntity.F_PEPoint = "工作计划";
                    }
                    db.Update(wEntity);
                    DC_OA_PerformanceExecuteEntity log = new DC_OA_PerformanceExecuteEntity();
                    log.Create();
                    log.F_PEPoint = "考核评估";
                    log.F_PointState = agree;
                    log.F_PointText = text;
                    log.F_PUWId = wid;
                    db.Insert(log);
                    db.Commit();
                    return true;
                }
                else
                {
                    db.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        //考核自评
        public bool Evaluate2(string wid)
        {
            var db = this.BaseRepository().BeginTrans();

            try
            {
                var wEntity = db.FindEntity<DC_OA_PerformanceUserWorkEntity>(wid);
                if (wEntity != null && wEntity.F_PEPoint == "考核自评")
                {
                    wEntity.F_PEPoint = "考核评价";
                    db.Update(wEntity);
                    DC_OA_PerformanceExecuteEntity log = new DC_OA_PerformanceExecuteEntity();
                    log.Create();
                    log.F_PEPoint = "考核自评";
                    log.F_PointState = 1;
                    log.F_PointText = "";
                    log.F_PUWId = wid;
                    db.Insert(log);
                    db.Commit();
                    return true;
                }
                else
                {
                    db.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        //多人评价
        public bool Evaluate3(string wid)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var user = LoginUserInfo.Get();
                var wEntity = db.FindEntity<DC_OA_PerformanceUserWorkEntity>(wid);
                if (wEntity != null && wEntity.F_PEPoint == "考核评价")
                {
                    var rEntity = db.FindEntity<DC_OA_PerformanceRecordRunEntity>(wEntity.F_PRRId);
                    if (rEntity != null)
                    {

                        DC_OA_PerformanceExecuteEntity log = new DC_OA_PerformanceExecuteEntity();
                        var curCheckerList = db.FindList<DC_OA_PerformanceExecuteEntity>(c => c.F_PUWId == wid && c.F_PEPoint == "考核评价")
    .Select(c => c.F_PointUserId);
                        var totalCheckerList = db.FindList<DC_OA_PRREvaluationUserRelationEntity>(c => c.F_PRRId == rEntity.F_PRRId)
                            .Select(c => c.F_EvaluationUserId);
                        bool b = true;
                        if (!curCheckerList.Contains(user.userId))
                        {
                            log.Create();
                            log.F_PEPoint = "考核评价";
                            log.F_PUWId = wid;
                            log.F_PointState = 1;
                            log.F_PointText = "";
                            db.Insert(log);
                        }
                        foreach (var item in totalCheckerList)
                        {
                            if (!curCheckerList.Contains(item) && item != log.F_PointUserId)
                            {
                                b = false;
                                break;
                            }
                        }
                        if (b)
                        {
                            wEntity.F_PEPoint = "考核审核";
                            db.Update(wEntity);
                        }
                        db.Commit();
                        return true;
                    }
                    else
                    {
                        db.Rollback();
                        return false;
                    }
                }
                else
                {
                    db.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        //考核审核
        public bool Evaluate4(string wid, string text, int agree, int? decScore, int? incScore, int? resultScore)
        {
            var db = this.BaseRepository().BeginTrans();

            try
            {
                var wEntity = db.FindEntity<DC_OA_PerformanceUserWorkEntity>(wid);
                if (wEntity != null && wEntity.F_PEPoint == "考核审核")
                {

                    if (agree == 1)
                    {
                        wEntity.F_PEPoint = "考核完成";
                        wEntity.F_DutyReduceScore = decScore;
                        wEntity.F_PerformanceScore = resultScore;
                        wEntity.F_AwardAddScore = incScore;
                    }
                    else
                    {
                        wEntity.F_PEPoint = "工作计划";
                    }
                    db.Update(wEntity);
                    DC_OA_PerformanceExecuteEntity log = new DC_OA_PerformanceExecuteEntity();
                    log.Create();
                    log.F_PEPoint = "考核审核";
                    log.F_PointState = agree;
                    log.F_PointText = text;
                    log.F_PUWId = wid;
                    db.Insert(log);
                    db.Commit();
                    return true;
                }
                else
                {
                    db.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
    }
}
