using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Nancy;
using Learun.Util;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.Base.SystemModule;
using System.Collections;
using System.Data;
using Learun.Application.TwoDevelopment.EcologyDemo;
using Learun.Application.TwoDevelopment.EcologyDemo.SuperviseTask;


namespace Learun.Application.WebApi.Modules.SuperviseManager
{
    public class SuperviseInfoApi : BaseApi
    {
        private SuperviseInfoIBll superviseinfo = new SuperviseInfoBll();
        private Uf_DbrwplbIBLL plinfo = new Uf_DbrwplbBLL();

        public SuperviseInfoApi()
       : base("/learun/adms/SuperviseManager/SuperviseInfoApi")
        {

            Get["/GetUserid"] = GetUserid;

          
            Get["/GetTaskInfo"] = GetTaskInfo;

            Get["/GetTaskDetailInfo"] = GetTaskDetailInfo;

            Get["/GetSubTaskInfo"] = GetSubTaskInfo;

            Get["/GetSubTaskDetailInfo"] = GetSubTaskDetailInfo;


            Get["/GetTaskPl"] = GetTaskPl;

            Get["/GetSubTaskPl"] = GetSubTaskPl;


            Post["/savePl"] = SavePl;

            Get["/GetMaxTaskInfo"] = GetMaxTaskInfo;

            Get["/GetMaxTaskNum"] = GetMaxTaskNum;

            Get["/GetMaxTasklist"] = GetMaxTasklist;

            Post["/UpdateTasklist"] = UpdateTasklist;

            Get["/SaveTasklist"] = SaveTasklist;

            Post["/SavePlHF"] = SavePlHF;
        }

        /// <summary>
        ///  主办任务，协办任务，办结任务接口数据列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMaxTaskInfo(dynamic _)
        {
            
            string temp = this.GetReqData();
           // LogUtil.WriteTextLog("督办任务", temp, DateTime.Now);
            var queryParam = temp.ToJObject();
            if (!queryParam["userid"].IsEmpty()&& !queryParam["type"].IsEmpty())
            {
                var data = superviseinfo.GetMaxTaskInfo(queryParam["userid"].ToString(), queryParam["type"].ToString());

                return Success(data);
            }

            return null;
        }
        /// <summary>
        ///  任务数据数量
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMaxTaskNum(dynamic _)
        {

            string temp = this.GetReqData();
            //LogUtil.WriteTextLog("督办任务数据数量", temp, DateTime.Now);
            var queryParam = temp.ToJObject();

            if (!queryParam["userid"].IsEmpty())
            {
                //LogUtil.WriteTextLog("督办任务数据数量", queryParam.ToString(), DateTime.Now);
                var data = superviseinfo.GetMaxTaskNum(queryParam["userid"].ToString());
                var data1 = superviseinfo.GetMaxAssistNum(queryParam["userid"].ToString());
                var data2 = superviseinfo.GetMaxEndNum(queryParam["userid"].ToString());
                var jsonData = new
                {
                    MaxTaskNum = data,
                    MaxAssistNum = data1,
                    MaxEndNum = data2,
                };

                return Success(jsonData);
            }

            return null;
        }
        /// <summary>
        ///  执行任务详细
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMaxTasklist(dynamic _)
        {

            string temp = this.GetReqData();
            //LogUtil.WriteTextLog("执行任务详细", temp, DateTime.Now);
            var queryParam = temp.ToJObject();
            if (!queryParam["id"].IsEmpty() )
            {
                var data = superviseinfo.GetMaxTasklist(queryParam["id"].ToString());

                return Success(data);
            }

            return null;
        }
        /// <summary> 
        /// 保存执行任务实体数据（修改） 
        /// <param name="_"></param> 
        /// <summary> 
        /// <returns></returns> 
        public Response UpdateTasklist(dynamic _)
        {
       
            ReqFormEntity parameter = this.GetReqData<ReqFormEntity>();
            SimpleLogUtil.WriteTextLog("保存数据", parameter.strEntity, DateTime.Now);
           uf_durwzxnewEntity entity = parameter.strEntity.ToObject<uf_durwzxnewEntity>();
            SimpleLogUtil.WriteTextLog("保存数据", parameter.keyValue, DateTime.Now);
            superviseinfo.UpdateTasklist(parameter.keyValue, entity);
            var jsonData = new
            {
                msg = "保存成功！",
            };

            return Success(jsonData);
        }
        /// <summary> 
        /// 保存执行任务实体数据（办结） 
        /// <param name="_"></param> 
        /// <summary> 
        /// <returns></returns> 
        public Response SaveTasklist(dynamic _)
        {
            string temp = this.GetReqData();
            
            var queryParam = temp.ToJObject();

            if (!queryParam["keyValue"].IsEmpty())
            {
                superviseinfo.SaveTasklist(queryParam["keyValue"].ToString());
                var jsonData = new
                {
                    msg = "办结成功！",
                };
                return Success(jsonData);
            }
            else {
                var jsonData = new
                {
                    msg = "id为空，保存失败！",
                };
                return Success("id为空，保存失败！");
            }
           
       
        }

        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetUserid(dynamic _)
        {


            string temp = this.GetReqData();
            //LogUtil.WriteTextLog("cookie", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
             // 虚拟参数

            if (!queryParam["cookieid"].IsEmpty())
            {
                var data = superviseinfo.GetUserid(queryParam["cookieid"].ToString());
                return Success(data);
            }

            return null;

          


        }


        /// <summary>
        /// 获取主任务
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetTaskInfo(dynamic _)
        {


            string temp = this.GetReqData();
           // LogUtil.WriteTextLog("temp2333", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            int type = 0;
            // 虚拟参数

            if (!queryParam["type"].IsEmpty())
            {
                type = int.Parse(queryParam["type"].ToString());
            }

            var data = superviseinfo.GetTaskInfo(type);
            return Success(data);

           
        }



        /// <summary>
        /// 主任务详细
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetTaskDetailInfo(dynamic _)
        {


            string temp = this.GetReqData();
           // LogUtil.WriteTextLog("temp2333", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            int id = 0;
            // 虚拟参数

            if (!queryParam["id"].IsEmpty())
            {
                id = int.Parse(queryParam["id"].ToString());
            }

            var data = superviseinfo.GetTaskDetailInfo(id);
            return Success(data);


        }

        /// <summary>
        /// /子任务
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetSubTaskInfo(dynamic _)
        {


            string temp = this.GetReqData();
          // LogUtil.WriteTextLog("taskid", temp, DateTime.Now);

            var queryParam = temp.ToJObject();

         //   LogUtil.WriteTextLog("taskid", queryParam["taskid"].ToString(), DateTime.Now);
            // 虚拟参数

            if (!queryParam["taskid"].IsEmpty())
            {
                var data = superviseinfo.GetSubTaskInfo(int.Parse(queryParam["taskid"].ToString()));
                return Success(data);
            }

            else
            {

                return null;
            }


        }


        /// <summary>
        /// 子任务详细
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetSubTaskDetailInfo(dynamic _)
        {


            string temp = this.GetReqData();
           // LogUtil.WriteTextLog("子任务详细1", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            int id = 0;
            // 虚拟参数

            if (!queryParam["id"].IsEmpty())
            {
                id = int.Parse(queryParam["id"].ToString());

                //LogUtil.WriteTextLog("子任务详细2", id.ToString(), DateTime.Now);
            }
           // LogUtil.WriteTextLog("子任务详细3", id.ToString(), DateTime.Now);
            var data = superviseinfo.GetSubTaskDetailInfo(id);
            return Success(data);


        }


        /// <summary>
        /// 获取任务评论详细
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetTaskPl(dynamic _)
        {


            string temp = this.GetReqData();
          //  LogUtil.WriteTextLog("temhhhhh", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
          
            // 虚拟参数

            if (!queryParam["id"].IsEmpty())
            {
                var data = superviseinfo.GetTaskPl(queryParam["id"].ToString());
                return Success(data);
            }

            else
            {

                return null;
            }
  
        }



        /// <summary>
        /// 获取子任务评论详细
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetSubTaskPl(dynamic _)
        {


            string temp = this.GetReqData();
          //  LogUtil.WriteTextLog("temp2333", temp, DateTime.Now);

            var queryParam = temp.ToJObject();
            // 虚拟参数
          //  LogUtil.WriteTextLog("subid", queryParam["subid"].ToString(), DateTime.Now);
            if (!queryParam["id"].IsEmpty()&&!queryParam["subid"].IsEmpty())
            {
                var data = superviseinfo.GetSubTaskPl(queryParam["id"].ToString(), queryParam["subid"].ToString());
                return Success(data);
            }
            else
            {

                return null;
            }

        }

       


        /// <summary> 
        /// 保存评论实体数据（新增、修改） 
        /// <param name="_"></param> 
        /// <summary> 
        /// <returns></returns> 
        public Response SavePl(dynamic _)
        {
            ReqFormEntity parameter = this.GetReqData<ReqFormEntity>();
            SimpleLogUtil.WriteTextLog("parameter.strEntity", parameter.strEntity, DateTime.Now);
            uf_dbrwplbEntity entity = parameter.strEntity.ToObject<uf_dbrwplbEntity>();
            plinfo.SaveEntity("", entity);
            return Success("保存成功！");
        }
        /// <summary> 
        /// 保存评论回复实体数据（新增、修改） 
        /// <param name="_"></param> 
        /// <summary> 
        /// <returns></returns> 
        public Response SavePlHF(dynamic _)
        {
            ReqFormEntity parameter = this.GetReqData<ReqFormEntity>();
            SimpleLogUtil.WriteTextLog("parameter.strEntity", parameter.strEntity, DateTime.Now);
            uf_dbrwplbEntity entity = parameter.strEntity.ToObject<uf_dbrwplbEntity>();
            plinfo.SavePLHF("", entity, parameter.replyid);
            var jsonData = new
            {
                msg = "回复成功！",
            };

            return Success(jsonData);
        }

        #region 私有类 

        /// <summary> 
        /// 表单实体类 
        /// <summary> 
        private class ReqFormEntity
        {
            public string keyValue { get; set; }
            public string strEntity { get; set; }
            public string replyid { get; set; }
        }
        #endregion
    }


}