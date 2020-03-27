using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Learun.Application.Organization;
using Learun.Application.Base.AuthorizeModule;
using System.Collections;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-01-26 12:10
    /// 描 述：DC_OA_PerformanceExecute
    /// </summary>
    public class DC_OA_PerformanceExecuteService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceExecuteEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_PEId,
                t.F_PUWId
                ");
                strSql.Append("  FROM DC_OA_PerformanceExecute t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_PerformanceExecuteEntity>(strSql.ToString(), dp, pagination);
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
        public List<DC_OA_PerformanceExecuteEntity> GetList(string keyValue)
        {
            var list = this.BaseRepository().FindList<DC_OA_PerformanceExecuteEntity>(c => c.F_PUWId == keyValue).OrderByDescending(c => c.F_PointDateTime).ToList();
            list.ForEach(c =>
            {
                var user = this.BaseRepository().FindEntity<UserEntity>(x => x.F_UserId == c.F_PointUserId);
                if (user != null)
                {
                    c.F_PointUserId = user.F_RealName;
                }
            });
            return list;
        }
        /// <summary>
        /// 获取DC_OA_PerformanceExecute表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceExecuteEntity GetDC_OA_PerformanceExecuteEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceExecuteEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PerformanceExecuteEntity>(t => t.F_PEId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceExecuteEntity entity)
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
        public HeaderInfoData GetHeadData(string wid)
        {
            var wEntity = this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkEntity>(c => c.F_PUWId == wid);
            var planList = this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(c => c.F_PUWId == wid).ToList();
            if (wEntity == null)
            {
                return new HeaderInfoData();
            }
            else
            {
                var result = new HeaderInfoData();
                result.dateString = wEntity.F_AppraisalCycleValue;
                result.decScore = wEntity.F_DutyReduceScore.HasValue ? wEntity.F_DutyReduceScore.Value.ToString("f2") : "";
                result.incScore = wEntity.F_AwardAddScore.HasValue ? wEntity.F_AwardAddScore.Value.ToString("f2") : "";
                var total = GetTotalScore(wid);
                result.totalScore = total.HasValue ? total.Value.ToString("f2") : "";
                decimal selfScore = 0;
                foreach (var item in planList)
                {
                    if (item.F_SelfScore.HasValue)
                    {
                        selfScore += item.F_SelfScore.Value.ToDecimal();
                    }
                }
                result.selfScore = selfScore.ToString("f2");
                if (total.HasValue)
                {
                    decimal resultScore = total.Value;
                    if (wEntity.F_DutyReduceScore.HasValue)
                    {
                        resultScore -= wEntity.F_DutyReduceScore.Value;
                    }
                    if (wEntity.F_AwardAddScore.HasValue)
                    {
                        resultScore += wEntity.F_AwardAddScore.Value;
                    }
                    result.resultScore = resultScore.ToString("f2");
                }
                result.tableName = wEntity.F_PUWName;
                var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == wEntity.F_PUWUserId);
                if (user != null)
                {
                    var department = this.BaseRepository().FindEntity<DepartmentEntity>(c => c.F_DepartmentId == user.F_DepartmentId);
                    if (department != null)
                    {
                        result.department = department.F_FullName;
                    }
                    var postIdList = this.BaseRepository().FindList<UserRelationEntity>(c => c.F_UserId == user.F_UserId && c.F_Category == 2).Select(c => c.F_ObjectId).ToList();
                    var postList = this.BaseRepository().FindList<PostEntity>(c => postIdList.Contains(c.F_PostId)).ToList();
                    result.post = "";
                    postList.ForEach(c => result.post += c.F_Name + ",");
                    if (result.post.Length > 0)
                    {
                        result.post = result.post.Substring(0, result.post.Length - 1);
                    }
                }
                return result;
            }
        }
        public List<TableHeadModel> GetColumes(string wid)
        {
            List<TableHeadModel> list = new List<TableHeadModel>();
            list.Add(new TableHeadModel("指标名称", "F_TargetName"));
            list.Add(new TableHeadModel("指标内容", "F_TargetContent", 200));
            list.Add(new TableHeadModel("考核目标", "F_Target", 200));
            list.Add(new TableHeadModel("评分说明", "F_TargetExplain", 300));
            list.Add(new TableHeadModel("指标分值", "F_TargetScore"));
            list.Add(new TableHeadModel("完成情况", "F_PerformanceInfo"));
            list.Add(new TableHeadModel("自评分（权重）", "F_SelfScore"));
            var wEntity = this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkEntity>(c => c.F_PUWId == wid);
            if (wEntity != null)
            {
                var rEntity = this.BaseRepository().FindEntity<DC_OA_PerformanceRecordRunEntity>(c => c.F_PRRId == wEntity.F_PRRId);
                if (rEntity != null)
                {
                    var dList = this.BaseRepository().FindList<DC_OA_PRREvaluationUserRelationEntity>(c => c.F_PRRId == rEntity.F_PRRId);
                    if (dList.Count() > 0)
                    {
                        foreach (var dItem in dList)
                        {
                            list.Add(new TableHeadModel(GetNameByUserId(dItem.F_EvaluationUserId) +
                                "评价（" + dItem.F_EvaluationWeight.ToString("f2") + "）", dItem.F_EvaluationUserId.Replace("-", "") + "_score", 150));
                        }
                    }
                }
            }
            return list;
        }
        private string GetNameByUserId(string id)
        {
            var user = this.BaseRepository().FindEntity<UserEntity>(c => c.F_UserId == id);
            return user == null ? "" : user.F_RealName;
        }
        private decimal? GetTotalScore(string wid)
        {
            decimal total = 0;
            var wEntity = this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkEntity>(c => c.F_PUWId == wid);
            var planList = this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(c => c.F_PUWId == wid).ToList();
            var planIdList = planList.Select(c => c.F_PUWPId).ToList();
            var rList = this.BaseRepository().FindList<DC_OA_PerformanceEvaluationEntity>(c => planIdList.Contains(c.F_PUWPId)).ToList();
            if (wEntity != null)
            {
                var relationList = this.BaseRepository().FindList<DC_OA_PRREvaluationUserRelationEntity>(c => c.F_PRRId == wEntity.F_PRRId);
                foreach (var item in planList)
                {
                    if (item.F_SelfScore.HasValue)
                    {
                        total += item.F_SelfScore.Value * wEntity.F_SelfWeight.ToDecimal();
                    }
                }
                foreach (var rItem in rList)
                {
                    var rObj = relationList.Where(c => c.F_EvaluationUserId == rItem.F_EvaluationUserId).FirstOrDefault();
                    if (rObj != null)
                    {
                        if (rItem.F_EvaluationScore.HasValue)
                        {
                            total += rObj.F_EvaluationWeight.ToDecimal() * rItem.F_EvaluationScore.Value;
                        }
                    }
                }
                return total;
            }
            return null;
        }
        public List<Hashtable> GetRows(string wid)
        {
            var columes = GetColumes(wid);
            List<Hashtable> rowData = new List<Hashtable>();
            Hashtable hashTotalCount = new Hashtable();
            var wEntity = this.BaseRepository().FindEntity<DC_OA_PerformanceUserWorkEntity>(c => c.F_PUWId == wid);
            var planList = this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(c => c.F_PUWId == wid).ToList();
            var planIdList = planList.Select(c => c.F_PUWPId).ToList();
            var evaluateList = this.BaseRepository().FindList<DC_OA_PerformanceEvaluationEntity>(c => planIdList.Contains(c.F_PUWPId)).ToList();
            var evaluateStrList = evaluateList.Select(c => c.F_EvaluationUserId).Distinct();
            foreach (var colume in columes)
            {
                if (colume.name == "F_TargetScore" || colume.name == "F_SelfScore")
                {
                    hashTotalCount.Add(colume.name, 0m);
                }
                else
                {
                    hashTotalCount.Add(colume.name, null);
                }
            }
            foreach (var plan in planList)
            {
                Hashtable hashRow = new Hashtable();
                hashRow.Add("F_PUWPId", plan.F_PUWPId);
                hashRow.Add("F_ParentId", plan.F_ParentId);
                foreach (var colume in columes)
                {
                    Type t = typeof(DC_OA_PerformanceUserWorkPlanEntity);
                    var value = t.GetProperty(colume.name);
                    if (value != null)
                    {
                        hashRow.Add(colume.name, value.GetValue(plan, null));
                    }
                    else
                    {
                        if (colume.name.EndsWith("_score"))
                        {
                            foreach (var str in evaluateStrList)
                            {
                                if (colume.name == str.Replace("-", "") + "_score")
                                {
                                    hashRow.Add(colume.name, evaluateList.Where(c => c.F_EvaluationUserId == str && plan.F_PUWPId == c.F_PUWPId).FirstOrDefault().F_EvaluationScore);
                                    break;
                                }
                            }
                        }
                    }
                }
                rowData.Add(hashRow);
            }
            var tempHashList = rowData.Where(c => IsLeaf(c["F_PUWPId"].ToString())).ToList();
            if (tempHashList.Count > 0)
            {
                foreach (DictionaryEntry de in tempHashList[0])
                {
                    if (de.Key.ToString().ToLower().EndsWith("score"))
                    {
                        hashTotalCount[de.Key] = tempHashList.Sum(c => c[de.Key] == null ? 0m : c[de.Key].ToDecimal());
                    }
                }
            }

            hashTotalCount["F_TargetName"] = "合计";
            hashTotalCount["F_PUWPId"] = Guid.NewGuid().ToString();
            hashTotalCount["F_ParentId"] = "";

            var resultList = new List<Hashtable>();
            MargeRow(tempHashList, resultList, rowData);
            resultList.Add(hashTotalCount);
            rowData.Clear();
            foreach (var hash in resultList)
            {
                var temphash = (Hashtable)hash.Clone();
                foreach (DictionaryEntry de in hash)
                {
                    if (de.Key.ToString() == "F_SelfScore")
                    {
                        temphash[de.Key] = hash[de.Key] == null ? "" : hash[de.Key].ToDecimal().ToString("f2");
                    }
                    else if (de.Key.ToString() == "F_TargetScore")
                    {
                        temphash[de.Key] = hash[de.Key] == null ? "" : hash[de.Key].ToDecimal().ToString("f2");
                    }
                    else if (de.Key.ToString().ToLower().EndsWith("score"))
                    {
                        temphash[de.Key] = hash[de.Key] == null ? "" : hash[de.Key].ToDecimal().ToString("f2");
                    }
                    else
                    {
                        temphash[de.Key] = hash[de.Key] == null ? "" : hash[de.Key].ToString();
                    }
                }
                rowData.Add(temphash);
            }
            return rowData;
        }
        public bool IsLeaf(string wpid)
        {
            return this.BaseRepository().FindList<DC_OA_PerformanceUserWorkPlanEntity>(c => c.F_ParentId == wpid).Count() <= 0;
        }
        #endregion
        private class IdValuePair
        {
            public string id { get; set; }
            public Dictionary<string, decimal> value { get; set; }
        }
        private void MargeRow(List<Hashtable> source, List<Hashtable> target, List<Hashtable> rowData)
        {
            if (source.Count > 0)
            {
                target.AddRange(source);
                var margeData = source.Where(c => c["F_ParentId"] != null && c["F_ParentId"].ToString().Length > 0).GroupBy(c => c["F_ParentId"]).Select(c =>
                    {
                        var pair = new IdValuePair();
                        pair.id = c.Key.ToString();
                        pair.value = new Dictionary<string, decimal>();
                        foreach (DictionaryEntry de in source[0])
                        {
                            if (de.Key.ToString().ToLower().EndsWith("score"))
                            {
                                pair.value.Add(de.Key.ToString(), c.Sum(x => x[de.Key] == null ? 0 : x[de.Key].ToDecimal()));
                            }
                        }
                        return pair;
                    }).ToList();
                source.Clear();
                foreach (var mItem in margeData)
                {
                    foreach (var item in rowData)
                    {

                        if (item["F_PUWPId"].ToString() == mItem.id)
                        {
                            foreach (KeyValuePair<string, decimal> kypair in mItem.value)
                            {
                                item[kypair.Key] = kypair.Value;
                            }
                            source.Add(item);
                        }
                    }
                }
                MargeRow(source, target, rowData);
            }
        }
    }
}
