using Nancy;
using Learun.Util;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ProjectManager;
namespace Learun.Application.WebApi
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2019-03-25 14:53
    /// 描 述：DC_EngineProject_MeetingRecord
    /// </summary>
    public class DC_EngineProject_MeetingRecordApi : BaseApi
    {
        private DC_EngineProject_MeetingRecordIBLL dC_EngineProject_MeetingRecordIBLL = new DC_EngineProject_MeetingRecordBLL();

        /// <summary>
        /// 注册接口
        /// <summary>
        public DC_EngineProject_MeetingRecordApi()
            : base("/learun/adms/ProjectManager/DC_EngineProject_MeetingRecord")
        {
            Get["/pagelist"] = GetPageList;
            Get["/list"] = GetList;
            Get["/form"] = GetForm;
            Post["/delete"] = DeleteForm;
            Post["/save"] = SaveForm;
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
            var data = dC_EngineProject_MeetingRecordIBLL.GetPageList(parameter.pagination, parameter.queryJson);
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
            var data = dC_EngineProject_MeetingRecordIBLL.GetList(queryJson);
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
            var DC_EngineProject_MeetingRecordData = dC_EngineProject_MeetingRecordIBLL.GetDC_EngineProject_MeetingRecordEntity( keyValue );
            var jsonData = new {
                DC_EngineProject_MeetingRecord = DC_EngineProject_MeetingRecordData,
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
            dC_EngineProject_MeetingRecordIBLL.DeleteEntity(keyValue);
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
            DC_EngineProject_MeetingRecordEntity entity = parameter.strEntity.ToObject<DC_EngineProject_MeetingRecordEntity>();
            dC_EngineProject_MeetingRecordIBLL.SaveEntity(this.userInfo,parameter.keyValue,entity);
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
