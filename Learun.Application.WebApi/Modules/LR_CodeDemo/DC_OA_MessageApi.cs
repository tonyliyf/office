using Nancy;
using Learun.Util;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Application.Message;
using System.Data;

namespace Learun.Application.WebApi
{
    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2019-05-06 14:58 
    /// 描 述：消息类型 
    /// </summary> 
    public class DC_OA_MessageApi : BaseApi
    {
        private DC_OA_MessageIBLL dC_OA_MessageIBLL = new DC_OA_MessageBLL();

        /// <summary> 
        /// 注册接口 
        /// <summary> 
        public DC_OA_MessageApi()
            : base("/learun/adms/LR_CodeDemo/DC_OA_Message")
        {
            Get["/pagelist"] = GetPageList;
            Get["/list"] = GetList;
            Get["/form"] = GetForm;
            Post["/delete"] = DeleteForm;
            Post["/save"] = SaveForm;

            Get["/GetOAMessage"] = GetOAMessage;
            Get["/GetMessageList"] = GetMessageList;
            Post["/EnterMessage"] = EnterMessage;


        }
        #region 获取数据 

        /// <summary> 
        /// 获取页面显示列表分页数据 
        /// <summary> 
        /// <param name="_"></param> 
        /// <returns></returns> 
        public Response GetPageList(dynamic _)
        {
            ReqPageParam parameter = this.GetReqData<ReqPageParam>();
            var data = dC_OA_MessageIBLL.GetPageList(parameter.pagination, parameter.queryJson);
            var jsonData = new
            {
                rows = data,
                total = parameter.pagination.total,
                page = parameter.pagination.page,
                records = parameter.pagination.records
            };
            return Success(jsonData);
        }


        public Response GetOAMessage(dynamic _)
        {
            ReqPageParam parameter = this.GetReqData<ReqPageParam>();
            DataTable dt = dC_OA_MessageIBLL.GetMsgCount();
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i]["count"].IsEmpty())
                {

                    count += int.Parse(dt.Rows[i]["count"].ToString());
                }
            }
            var jsonData = new
            {
                rows = dt,
                total = count

            };
            return Success(jsonData);
        }


        public Response GetMessageList(dynamic _)
        {
            ReqMessage parameter = GetReqData<ReqMessage>();
           
          //  var queryParam = parameter.queryJson.ToJObject();
            string code = "";
            string content = "";
            string isRead = "";
            if (!parameter.code.IsEmpty())
            {
                code = parameter.code;
            }
            //if (!queryParam["content"].IsEmpty())
            //{
            //    code = queryParam["content"].ToString();
            //}
            if (!parameter.isRead.IsEmpty())
            {
                isRead = parameter.isRead;
            }


            var data = dC_OA_MessageIBLL.GetMessageList(parameter.pagination,code,content,isRead);
            var jsonData = new
            {
                rows = data,
                total = parameter.pagination.total,
                page = parameter.pagination.page,
                records = parameter.pagination.records
            };
            return Success(jsonData);
        }
        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="_"></param> 
        /// <returns></returns> 
        public Response GetList(dynamic _)
        {
            string queryJson = this.GetReqData();
            var data = dC_OA_MessageIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary> 
        /// 获取表单数据 
        /// <summary> 
        /// <param name="_"></param> 
        /// <returns></returns> 
        public Response GetForm(dynamic _)
        {
            string keyValue = this.GetReqData();
            var DC_OA_MessageData = dC_OA_MessageIBLL.GetEntity(keyValue);
            var jsonData = new
            {
                DC_OA_Message = DC_OA_MessageData,
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据 

        /// <summary> 
        /// 删除实体数据 
        /// <param name="_"></param> 
        /// <summary> 
        /// <returns></returns> 
        public Response DeleteForm(dynamic _)
        {
            string keyValue = this.GetReqData();
            dC_OA_MessageIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary> 
        /// 保存实体数据（新增、修改） 
        /// <param name="_"></param> 
        /// <summary> 
        /// <returns></returns> 
        public Response SaveForm(dynamic _)
        {
            ReqFormEntity parameter = this.GetReqData<ReqFormEntity>();
            DC_OA_MessageEntity entity = parameter.strEntity.ToObject<DC_OA_MessageEntity>();
           // dC_OA_MessageIBLL.SaveEntity(this.userInfo, parameter.keyValue, entity);
            return Success("保存成功！");
        }


        /// <summary> 
        /// 获取页面显示列表数据 
        /// <summary> 
        /// <param name="_"></param> 
        /// <returns></returns> 
        public Response EnterMessage(dynamic _)
        {
            string Messageid = this.GetReqData();
            bool bEnter = dC_OA_MessageIBLL.EnterMessage(Messageid);
            if (bEnter)
            {
                return Success("确认成功");
            }
            else
            {

                return Fail("确认失败");
            }
           
        }
        #endregion

        #region 私有类 

        /// <summary> 
        /// 表单实体类 
        /// <summary> 
        private class ReqFormEntity
        {
            public string keyValue { get; set; }
            public string strEntity { get; set; }
        }
        
        private class ReqMessage: ReqPageParam
        {

            public string code { get; set; }
            public string isRead { get; set; }
        }
        #endregion

    }
}