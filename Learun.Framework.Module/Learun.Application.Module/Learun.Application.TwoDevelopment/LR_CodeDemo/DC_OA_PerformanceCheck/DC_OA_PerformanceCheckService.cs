using Dapper;
using Learun.Application.Organization;
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
    /// 日 期：2019-03-29 15:44
    /// 描 述：DC_OA_PerformanceCheck
    /// </summary>
    public class DC_OA_PerformanceCheckService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();

                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_PerformanceCheck t ");
                strSql.Append("  WHERE 1=1  and t.F_CheckUserid='"+user.userId+"'");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                return this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageListH(string queryJson)
        {
            try
            {
         
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_CheckUserid,
                t.F_CheckUserDeptId
                ");
                strSql.Append("  FROM DC_OA_PerformanceCheck t ");
                strSql.Append("  WHERE 1=1  and t.F_EmpolyeeCheckId='" + queryJson + "'");

               
        
                return this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString());
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList7(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_PerformanceCheck t");
                strSql.Append("  WHERE 1=1 and t.F_CheckUserDeptId='" + user.departmentId + "'");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });

                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId", "%" + queryParam["F_UserId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND t.F_CheckUserid like @F_UserId ");
                }
                return this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList8(Pagination pagination, string queryJson)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.*
                ");
                strSql.Append("  FROM DC_OA_PerformanceCheck t");
                strSql.Append("  WHERE 1=1 and t.F_AuditUserid='" + user.userId + "' and t.F_CheckSate='1'");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });


                return this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);
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
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList1(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT * from (SELECT * FROM DC_OA_PerformanceCheck where  F_CheckTemplateRefid is NULL or F_CheckTemplateRefid ='1') b");        
                strSql.Append("  WHERE 1=1  ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CheckUserDeptId"].IsEmpty())
                {
                    dp.Add("F_CheckUserDeptId", "%" + queryParam["F_CheckUserDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_CheckUserDeptId ");
                }

                IEnumerable <DC_OA_PerformanceCheckEntity> list = this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);

                foreach (DC_OA_PerformanceCheckEntity obj in list) {              
                        //扣分合计
                        obj.F_KofenNum =(100 - Convert.ToInt32(obj.F_CheckNumber)) + Convert.ToInt32(obj.F_JixaoNumber);
                        //上级领导扣分
                        obj.F_CheckNumber = (100 - Convert.ToInt32(obj.F_CheckNumber));
                        //加分合计
                        obj.F_JiafenNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber)) - Convert.ToInt32(obj.F_KofenNum);     
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
        /// 获取部室领导显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList3(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                string datatime = DateTime.Now.ToString("yyyy");
                if (queryJson == "{}")
                {
                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='4' and F_CheckStartTime like '%" + datatime + "%'");
                }
                else {

                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='4'");
                }
             
       
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CheckUserDeptId"].IsEmpty())
                {
                    dp.Add("F_CheckUserDeptId", "%" + queryParam["F_CheckUserDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_CheckUserDeptId ");
                }
                if (!queryParam["F_CheckStartTime"].IsEmpty())
                {
                    dp.Add("F_CheckStartTime", "%" + queryParam["F_CheckStartTime"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckStartTime like @F_CheckStartTime ");
                }
                IEnumerable<DC_OA_PerformanceCheckEntity> list = this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);

                foreach (DC_OA_PerformanceCheckEntity obj in list)
                {
                  
                    //扣分合计
                    obj.F_KofenNum = (100 - Convert.ToInt32(obj.F_CheckNumber)) + Convert.ToInt32(obj.F_JixaoNumber);
                    //上级领导扣分
                    obj.F_CheckNumber = (100 - Convert.ToInt32(obj.F_CheckNumber));
                    //加分合计
                    obj.F_JiafenNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber)) - Convert.ToInt32(obj.F_KofenNum);    
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
        /// 获取部室员工显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList4(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
            
                string datatime = DateTime.Now.ToString("yyyy");
                string datatime1 = DateTime.Now.ToString("MM");
                if (queryJson == "{}")
                {
                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='1' and convert(nvarchar,F_CheckStartTime,111) like '%" + datatime +"/"+ datatime1+"%'");
                }
                else
                {

                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='1'");
                }


                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_OA_AttenceDeptId"].IsEmpty())
                {
                    dp.Add("F_OA_AttenceDeptId", "%" + queryParam["F_OA_AttenceDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_OA_AttenceDeptId ");
                }
              

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( b.F_CheckStartTime >= @F_CheckStartTime AND b.datetime <= @EndTime ) ");
                }

                IEnumerable<DC_OA_PerformanceCheckEntity> list = this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);

                foreach (DC_OA_PerformanceCheckEntity obj in list)
                {

                    //扣分合计
                    obj.F_KofenNum =(100- Convert.ToInt32(obj.F_CheckNumber)) + Convert.ToInt32(obj.F_JixaoNumber);

                    //上级领导扣分
                    obj.F_CheckNumber = (100 - Convert.ToInt32(obj.F_CheckNumber));

                    //加分合计
                    obj.F_JiafenNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber)) - Convert.ToInt32(obj.F_KofenNum);

          
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
        /// 获取部室领导显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList5(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                string datatime = DateTime.Now.ToString("yyyy");
                string datatime1 = DateTime.Now.ToString("MM");
                //第一次加载默认为当前年当前月
                if (queryJson == "{}")
                {
                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='3' and convert(nvarchar,F_CheckStartTime,111) like '%" + datatime + "/" + datatime1 + "%'");
                }
                else
                {

                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='3'");
                }


                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_OA_AttenceDeptId"].IsEmpty())
                {
                    dp.Add("F_OA_AttenceDeptId", "%" + queryParam["F_OA_AttenceDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_OA_AttenceDeptId ");
                }
                
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( b.F_CheckStartTime >= @StartTime AND b.F_CheckStartTime <= @EndTime )");
                }
                IEnumerable<DC_OA_PerformanceCheckEntity> list = this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);

                foreach (DC_OA_PerformanceCheckEntity obj in list)
                {

                    //扣分合计
                    obj.F_KofenNum =(100- Convert.ToInt32(obj.F_CheckNumber)) + Convert.ToInt32(obj.F_JixaoNumber);

                    //上级领导扣分
                    obj.F_CheckNumber = (100 - Convert.ToInt32(obj.F_CheckNumber));

                    //加分合计
                    obj.F_JiafenNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber) + Convert.ToInt32(obj.F_GeneralManagerScore) + Convert.ToInt32(obj.F_ChairmanScore)) - Convert.ToInt32(obj.F_KofenNum);

                    //得分
                    obj.F_deriveNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber)) - Convert.ToInt32(obj.F_KofenNum);
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
        /// 获取班子成员显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DC_OA_PerformanceCheckEntity> GetPageList6(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();

                string datatime = DateTime.Now.ToString("yyyy");
                string datatime1 = DateTime.Now.ToString("MM");
                //第一次加载默认为当前年当前月
                if (queryJson == "{}")
                {
                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='5' and convert(nvarchar,F_CheckStartTime,111) like '%" + datatime + "/" + datatime1 + "%'");
                }
                else
                {

                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='5'");
                }


                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_OA_AttenceDeptId"].IsEmpty())
                {
                    dp.Add("F_OA_AttenceDeptId", "%" + queryParam["F_OA_AttenceDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_OA_AttenceDeptId ");
                }

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("StartTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("EndTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( b.F_CheckStartTime >= @StartTime AND b.F_CheckStartTime <= @EndTime )");
                }
                IEnumerable<DC_OA_PerformanceCheckEntity> list = this.BaseRepository().FindList<DC_OA_PerformanceCheckEntity>(strSql.ToString(), dp, pagination);

                foreach (DC_OA_PerformanceCheckEntity obj in list)
                {

                    //扣分合计
                    obj.F_KofenNum =(100- Convert.ToInt32(obj.F_CheckNumber)) + Convert.ToInt32(obj.F_JixaoNumber)+Convert.ToInt32(obj.F_manageComments) + Convert.ToInt32(obj.F_GeneralNumber) + Convert.ToInt32(obj.F_ChairmanNumber);

                    //上级领导扣分
                    obj.F_CheckNumber = (100 - Convert.ToInt32(obj.F_CheckNumber));

                    //合计得分
                    obj.F_JiafenNum = (Convert.ToInt32(obj.F_BaseNumber) + Convert.ToInt32(obj.F_AddNumber)) - Convert.ToInt32(obj.F_KofenNum);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetPageList2(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT * from (SELECT * FROM DC_OA_PerformanceCheck where  F_CheckTemplateRefid is NULL or F_CheckTemplateRefid ='1') b");
                strSql.Append("  WHERE 1=1  ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CheckUserDeptId"].IsEmpty())
                {
                    dp.Add("F_CheckUserDeptId", "%" + queryParam["F_CheckUserDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_CheckUserDeptId ");
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public DataTable GetPageList12(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                string datatime = DateTime.Now.ToString("yyyy");
                if (queryJson == "{}")
                {
                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='4' and F_CheckStartTime like '%" + datatime + "%'");
                }
                else
                {

                    strSql.Append("SELECT * FROM DC_OA_PerformanceCheck b ");
                    strSql.Append("  WHERE 1=1  and F_CheckTemplateRefid ='4'");
                }


                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_CheckUserDeptId"].IsEmpty())
                {
                    dp.Add("F_CheckUserDeptId", "%" + queryParam["F_CheckUserDeptId"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckUserDeptId like @F_CheckUserDeptId ");
                }
                if (!queryParam["F_CheckStartTime"].IsEmpty())
                {
                    dp.Add("F_CheckStartTime", "%" + queryParam["F_CheckStartTime"].ToString() + "%", DbType.String);
                    strSql.Append("  AND b.F_CheckStartTime like @F_CheckStartTime ");
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
        /// 获取树形数据 
        /// </summary> 
        /// <returns></returns> 
        public DataTable GetSqlTree()
        {
            try
            {
                return this.BaseRepository().FindTable(" select * from LR_Base_Department ");
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
        /// 获取DC_OA_PerformanceCheck表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public DC_OA_PerformanceCheckEntity GetDC_OA_PerformanceCheckEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DC_OA_PerformanceCheckEntity>(keyValue);
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
                this.BaseRepository().Delete<DC_OA_PerformanceCheckEntity>(t => t.F_EmpolyeeCheckId == keyValue);
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
        public void SaveEntity(string keyValue, DC_OA_PerformanceCheckEntity entity)
        {
            try
            {
                UserInfo user = LoginUserInfo.Get();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.F_Level = user.F_Level;
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.F_Level = user.F_Level;
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
        public bool SaveEntityEx(string keyValue, DC_OA_PerformanceCheckEntity entity)
        {
            try
            {
               
                var temp = this.BaseRepository().FindEntity<DC_OA_PerformanceCheckEntity>(keyValue);
                if (!string.IsNullOrEmpty(keyValue) && temp.F_CheckSate == "1")
                {
                    entity.Modify(keyValue);
                    entity.F_CheckSate = "2";
                    this.BaseRepository().Update(entity);
                    return true;
                }
                else
                {
                    return false;
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

        public DC_OA_PerformanceCheckTemplateEntity GetTemplateEntity(int type)
        {
            UserInfo user = LoginUserInfo.Get();
            RoleBLL BLL = new RoleBLL();
            string timetype = type == 1 ? "年度" : "月度";
            var Template = this.BaseRepository().FindList<DC_OA_PerformanceCheckTemplateEntity>(c => c.F_Enabled == "1" && c.F_TimeType == timetype)
                .OrderByDescending(c => c.F_level);
            var roleList = BLL.GetRoleList(user.userId);
            foreach (var item in Template)
            {
                foreach (var role in roleList)
                {
                    if (item.F_Roleid.Contains(role.F_RoleId))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public bool Commit(string keyValue, string checkerid)
        {
            var entity = this.BaseRepository().FindEntity<DC_OA_PerformanceCheckEntity>(keyValue);
            if (entity == null || entity.F_CheckSate != "0")
            {
                return false;
            }
            else
            {
                entity.F_CheckSate = "1";
                entity.F_AuditUserid = checkerid;
                this.BaseRepository().Update(entity);
                return true;
            }
        }
    }
}
