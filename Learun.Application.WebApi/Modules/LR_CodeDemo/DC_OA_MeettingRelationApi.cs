using Nancy;
using Learun.Util;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
namespace Learun.Application.WebApi
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-04-29 11:22
    /// 描 述：会议通知回执
    /// </summary>
    public class DC_OA_MeettingRelationApi : BaseApi
    {
        private DC_OA_MeettingRelationIBLL dC_OA_MeettingRelationIBLL = new DC_OA_MeettingRelationBLL();

        /// <summary>
        /// 注册接口
        /// <summary>
        public DC_OA_MeettingRelationApi()
            : base("/learun/adms/LR_CodeDemo/DC_OA_MeettingRelation")
        {
            Get["/pagelist"] = GetPageList;
            Get["/list"] = GetList;
            Get["/GetCount"] = GetCount;
            Get["/form"] = GetForm;
            Post["/delete"] = DeleteForm;
            Post["/save"] = SaveForm;
            Post["/update"] = update;
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
            var data = dC_OA_MeettingRelationIBLL.GetPageList(parameter.pagination, parameter.queryJson);
            var jsonData = new
            {
                rows = data,
                total = parameter.pagination.total,
                page = parameter.pagination.page,
                records = parameter.pagination.records
            };
            return Success(jsonData);
        }


        public Response GetCount(dynamic _)
        {
            int count= dC_OA_MeettingRelationIBLL.GetMeetingCount();
            return Success(count.ToString());
        }
        
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetList(dynamic _)
        {
            string queryJson = this.GetReqData();
            var data = dC_OA_MeettingRelationIBLL.GetList(queryJson);
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
            var DC_OA_MeettingRelationData = dC_OA_MeettingRelationIBLL.GetDC_OA_MeettingRelationEntity( keyValue );
            var jsonData = new {
                DC_OA_MeettingRelation = DC_OA_MeettingRelationData,
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
            dC_OA_MeettingRelationIBLL.DeleteEntity(keyValue);
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
            DC_OA_MeettingRelationEntity entity = parameter.strEntity.ToObject<DC_OA_MeettingRelationEntity>();
            dC_OA_MeettingRelationIBLL.UpdateEntity(parameter.keyValue, entity.F_Reason);
           // dC_OA_MeettingRelationIBLL.SaveEntity(this.userInfo,parameter.keyValue,entity);
            return Success("保存成功！");
        }

        public Response update(dynamic _)
        {
            ReqFormEntity parameter = this.GetReqData<ReqFormEntity>();
            // string F_Reason = this.GetReqData().F_Reason;
            DC_OA_MeettingRelationEntity entity = parameter.strEntity.ToObject<DC_OA_MeettingRelationEntity>();
            dC_OA_MeettingRelationIBLL.UpdateEntity(parameter.keyValue, entity.F_Reason);
            return Success("保存成功！");
        }
        #endregion

        #region 私有类

        /// <summary>
        /// 表单实体类
        /// <summary>
        private class ReqFormEntity {
            public string keyValue { get; set; }
            public string strEntity{ get; set; }
        }
        #endregion

    }
}
