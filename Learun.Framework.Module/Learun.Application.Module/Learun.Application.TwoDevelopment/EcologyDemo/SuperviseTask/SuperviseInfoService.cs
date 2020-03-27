using Dapper;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.EcologyDemo.SuperviseTask
{
    public class SuperviseInfoService : RepositoryFactory
    {
        private Uf_DbrwplbIBLL plBll = new Uf_DbrwplbBLL();



        public DataTable GetUserid(string cookieid)
        {
            try
            {
                if (!string.IsNullOrEmpty(cookieid))
                {
                    var strSql = new StringBuilder();
                    strSql.Append(@"
                        SELECT  F_WeaverId from LR_Base_User  where 1=1 
                ");

                    strSql.Append(string.Format("  and F_Account ='{0}'", cookieid.ToString()));
                   
                    DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
       

                    return dt;
                }
                return null;
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

        public DataTable GetTaskInfo(int type)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                        SELECT  * from ecology.dbo. uf_dbrwcxnew   where 1=1 
                ");

                strSql.Append(string.Format("  and dbrwfl ={0}", type));
                strSql.Append(" order by id desc");
               DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(dt, new string[] { "qtbm", "xzbm" });
                sevices.ConvertDataByWeaveHrmResouce(dt, new string[] { "qtbmfzr", "zbr", "xzbmfzr", "xzr", "modedatacreater", "zrld", "xzfzrnew" });

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


        public DataTable GetTaskDetailInfo(int id)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                        SELECT  * from ecology.dbo. uf_dbrwcxnew   where 1=1 
                ");

                strSql.Append(string.Format("  and id ={0}", id));

               // strSql.Append(" order by id desc");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(dt, new string[] { "qtbm", "xzbm" });
                sevices.ConvertDataByWeaveHrmResouce(dt, new string[] { "zrld", "zbr", "modedatacreater","xzfzrnew", "xzrnew" });

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


        public DataTable GetSubTaskInfo(int taskid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                        SELECT  * from ecology.dbo.uf_durwzxnew  where 1=1 
                ");

                strSql.Append(string.Format("  and lxmxid ='{0}'", taskid.ToString()));

                strSql.Append(" order by id desc");
                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(dt, new string[] { "zbbm", "ssks" });
                sevices.ConvertDataByWeaveHrmResouce(dt, new string[] { "zbr", "zxr", "modedatacreater" });

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


        public DataTable GetSubTaskDetailInfo(int id)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"
                        SELECT  * from ecology.dbo.uf_durwzxnew  where 1=1 
                ");

                strSql.Append(string.Format("  and id ={0}", id));

                DataTable dt = this.BaseRepository().FindTable(strSql.ToString());
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(dt, new string[] { "zbbm", "ssks" });
                sevices.ConvertDataByWeaveHrmResouce(dt, new string[] { "zbr", "zxr", "modedatacreater" });

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



        public DataSet GetTaskPl(string id)
        {
            try
            {


                return plBll.GettableList(id, "");
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
        /// 主办任务，协办任务，办结任务接口数据列表
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetMaxTaskInfo(string userid,string type)
        {
            try
            {
                var strSql = new StringBuilder();
                //主办任务(未完结)
                if (type == "1") {
                  
                    strSql.Append(@"
                       select id,rwmc,zbbm,zbr,zxr,ssks,rwlx,jbrq,yqbjrq,rwzt,jd from ecology.dbo.uf_durwzxnew  where zbr=" + userid + " and rwzt !=1 ");
                }//协办任务(未完结)
                else if (type == "2") {

                    strSql.Append(@"
                       select a.id,a.rwmc,a.zbbm,a.zbr,a.zxr,a.ssks,a.rwlx,a.jbrq,a.yqbjrq,a.rwzt,a.jd,a.lxmxid from ecology.dbo.uf_durwzxnew a
 
                       left join  	ecology.dbo.uf_dbrwcxnew b  on a.lxmxid=b.lxmxid   where b.xzfzrnew like '%" + userid + "%'   and a.rwzt !=1");


                }//完结任务（主办，协办）
                else if (type == "3") {

                    strSql.Append(@"
                       select * from  (select a.id,a.rwmc,a.zbbm,a.zbr,a.zxr,a.ssks,a.rwlx,a.jbrq,a.yqbjrq,a.rwzt,a.jd,a.lxmxid from ecology.dbo.uf_durwzxnew a
 
                       left join  	ecology.dbo.uf_dbrwcxnew b  on a.lxmxid=b.lxmxid   where b.xzfzrnew like '%"+ userid + "%' or a.zbr="+ userid + "  ) d where   d.rwzt =1");

                } 

               //SimpleLogUtil.WriteTextLog("督办任务", strSql.ToString(), DateTime.Now);
                //主办任务数据源(未完结)
                DataTable MaxTask = this.BaseRepository().FindTable(strSql.ToString());
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(MaxTask, new string[] { "zbbm", "ssks" });
                sevices.ConvertDataByWeaveHrmResouce(MaxTask, new string[] { "zbr", "zxr" });

               // SimpleLogUtil.WriteTextLog("督办任务", MaxTask.ToString(), DateTime.Now);
                return MaxTask;
            }
            catch (Exception ex)
            {
                
                if (ex is ExceptionEx)
                {
                    
                    throw;
                }
                else
                {
                    SimpleLogUtil.WriteTextLog("督办任务", ex.ToString(), DateTime.Now);
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }
        /// <summary>
        /// 执行任务详细
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetMaxTasklist(string id)
        {
            try
            {
                var strSql = new StringBuilder();
                //任务详细sql
                strSql.Append(@"
                      select id,rwmc,zbbm,zbr,zxr,ssks,rwlx,jbrq,yqbjrq,rwzt,jd from ecology.dbo.uf_durwzxnew  where id=" + id + " ");

                 SimpleLogUtil.WriteTextLog("任务详细sql", strSql.ToString(), DateTime.Now);
                //任务详细
                DataTable MaxTask = this.BaseRepository().FindTable(strSql.ToString());
                DataConvertSerivers sevices = new DataConvertSerivers();
                sevices.ConvertDataByWeaveDepartment(MaxTask, new string[] { "zbbm", "ssks" });
                sevices.ConvertDataByWeaveHrmResouce(MaxTask, new string[] { "zbr", "zxr" });

                // SimpleLogUtil.WriteTextLog("督办任务", MaxTask.ToString(), DateTime.Now);
                return MaxTask;
            }
            catch (Exception ex)
            {

                if (ex is ExceptionEx)
                {

                    throw;
                }
                else
                {
                    SimpleLogUtil.WriteTextLog("任务详细", ex.ToString(), DateTime.Now);
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }


        /// <summary>
        /// 保存实体数据（修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void UpdateTasklist(string keyValue, uf_durwzxnewEntity entity)
        {
            try
            {

                var strSql = new StringBuilder();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    strSql.Append(@"
                       UPDATE ecology.dbo.uf_durwzxnew set rwzt="+ entity.rwzt + " , jbrq='"+ entity.jbrq + "' , yqbjrq ='" + entity.yqbjrq + "' , jd="+ entity.jd+ " where  id=" + keyValue + " ");

                    SimpleLogUtil.WriteTextLog("修改sql", strSql.ToString(), DateTime.Now);
                    this.BaseRepository().ExecuteBySql(strSql.ToString());
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
        /// <summary>
        /// 保存实体数据（修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveTasklist(string keyValue)
        {
            try
            {
              
                var strSql = new StringBuilder();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    strSql.Append(@"
                       UPDATE ecology.dbo.uf_durwzxnew set rwzt=1 where  id=" + keyValue + " ");
                       this.BaseRepository().FindTable(strSql.ToString());
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
        
        /// <summary>
        /// 主办任务数据数量
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetMaxTaskNum(string userid)
        {
            try
            {
              
                //主办任务数量(未完结)
                var strSq2 = new StringBuilder();
                strSq2.Append(@"
                       select COUNT(*) as num from ecology.dbo.uf_durwzxnew  where zbr=" + userid + " and rwzt !=1");

                SimpleLogUtil.WriteTextLog("主办任务数量sql", strSq2.ToString(), DateTime.Now);
                //主办任务数据源(未完结)
                DataTable MaxTask = this.BaseRepository().FindTable(strSq2.ToString());

                return MaxTask;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    SimpleLogUtil.WriteTextLog("主办任务数量", ex.ToString(), DateTime.Now);
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }
        /// <summary>
        /// 协办任务数据数量
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetMaxAssistNum(string userid)
        {
            try
            {

                //协办任务数量（为完结）
                var strSq4 = new StringBuilder();
                strSq4.Append(@"
                       select COUNT(*) as num from ecology.dbo.uf_durwzxnew a
 
                       left join  	ecology.dbo.uf_dbrwcxnew b  on a.lxmxid=b.lxmxid   where b.xzfzrnew like '%" + userid + "%'   and a.rwzt !=1");
                SimpleLogUtil.WriteTextLog("协办任务数量sql", strSq4.ToString(), DateTime.Now);
                DataTable MaxTask = this.BaseRepository().FindTable(strSq4.ToString());

                return MaxTask;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    SimpleLogUtil.WriteTextLog("协办任务数量", ex.ToString(), DateTime.Now);
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }
        /// <summary>
        /// 完结任务数量（主办，协办）
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetMaxEndNum(string userid)
        {
            try
            {
                //完结任务数量（主办，协办）
                var strSq6 = new StringBuilder();
                strSq6.Append(@"
                       select COUNT(*) as num from  (select a.* from ecology.dbo.uf_durwzxnew a
 
                       left join  	ecology.dbo.uf_dbrwcxnew b  on a.lxmxid=b.lxmxid   where b.xzfzrnew like '%" + userid + "%' or a.zbr=" + userid + "  ) d where   d.rwzt =1");
                SimpleLogUtil.WriteTextLog("完结任务数量sql", strSq6.ToString(), DateTime.Now);
                DataTable MaxTask = this.BaseRepository().FindTable(strSq6.ToString());

                return MaxTask;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    SimpleLogUtil.WriteTextLog("完结任务数量", ex.ToString(), DateTime.Now);
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }


        public DataSet GetSubTaskPl(string id,string taskid)
        {
            try
            {


                return plBll.GettableList(id, taskid);
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
