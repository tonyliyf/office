using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Util;

namespace Learun.Application.TwoDevelopment.EcologyDemo.SuperviseTask
{
    public class SuperviseInfoBll:SuperviseInfoIBll
    {

        private SuperviseInfoService superviseInfoServiceService = new SuperviseInfoService();


        public DataTable GetUserid(string cookieid)
        {
            try
            {
                return superviseInfoServiceService.GetUserid(cookieid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }

        public DataTable GetTaskInfo(int type)
        {

            try
            {
                return superviseInfoServiceService.GetTaskInfo(type);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }


        public DataTable GetTaskDetailInfo(int id)
        {

            try
            {
                return superviseInfoServiceService.GetTaskDetailInfo(id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }
        public DataTable GetSubTaskInfo(int taskid)
        {

            try
            {
                return superviseInfoServiceService.GetSubTaskInfo(taskid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }

        public DataTable GetSubTaskDetailInfo(int id)
        {

            try
            {
                return superviseInfoServiceService.GetSubTaskDetailInfo(id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }


        public DataSet GetTaskPl(string taskid)
        {

            try
            {
                return superviseInfoServiceService.GetTaskPl(taskid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }

        public DataTable GetMaxTaskInfo(string userid, string type)
        {

            try
            {
                return superviseInfoServiceService.GetMaxTaskInfo(userid, type);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }
        public DataTable GetMaxTasklist(string id)
        {

            try
            {
                return superviseInfoServiceService.GetMaxTasklist(id);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void UpdateTasklist(string keyValue, uf_durwzxnewEntity entity)
        {
            try
            {
                superviseInfoServiceService.UpdateTasklist(keyValue, entity);
            }
            catch (Exception ex)
            {
                SimpleLogUtil.WriteTextLog("督办任务修改", ex.Message, DateTime.Now);
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveTasklist(string keyValue)
        {
            try
            {
                superviseInfoServiceService.SaveTasklist(keyValue);
            }
            catch (Exception ex)
            {
                SimpleLogUtil.WriteTextLog("督办任务办结", ex.Message, DateTime.Now);
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        public DataTable GetMaxTaskNum(string userid)
        {

            try
            {
                return superviseInfoServiceService.GetMaxTaskNum(userid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }
        public DataTable GetMaxAssistNum(string userid)
        {

            try
            {
                return superviseInfoServiceService.GetMaxAssistNum(userid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }
        public DataTable GetMaxEndNum(string userid)
        {

            try
            {
                return superviseInfoServiceService.GetMaxEndNum(userid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }


        public DataSet GetSubTaskPl(string taskid,string subid)
        {

            try
            {
                return superviseInfoServiceService.GetSubTaskPl(taskid,subid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }


        }
    }
}
