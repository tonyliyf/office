using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Nancy;
using Learun.Util;
using Learun.Application.TwoDevelopment.ProjectManager;


namespace Learun.Application.WebApi.Modules.ProjectManager
{
    public class DC_EngineProject_BuilderDiaryMainApi : BaseApi
    {
        private DC_EngineProject_BuilderDiaryMainIBLL dC_EngineProject_BuilderDiaryMainIBLL = new DC_EngineProject_BuilderDiaryMainBLL();

        /// <summary> 
        /// 注册接口 
        /// <summary> 
        public DC_EngineProject_BuilderDiaryMainApi()
            : base("/learun/adms/ProjectManager/DC_EngineProject_BuilderDiaryMain")
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
            var data = dC_EngineProject_BuilderDiaryMainIBLL.GetPageList(parameter.pagination, parameter.queryJson);
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
            ReqPageParam parameter = this.GetReqData<ReqPageParam>();
            var data = dC_EngineProject_BuilderDiaryMainIBLL.GetPageList(parameter.pagination, parameter.queryJson);
            return Success(data);
            //string queryJson = this.GetReqData();
            //var data = dC_EngineProject_BuilderDiaryMainIBLL.GetList(queryJson);
            //return Success(data);

        }
        /// <summary> 
        /// 获取表单数据 
        /// <summary> 
        /// <param name="_"></param> 
        /// <returns></returns> 
        public Response GetForm(dynamic _)
        {
            string keyValue = this.GetReqData();
            var DC_EngineProject_BuilderDiaryMainData = dC_EngineProject_BuilderDiaryMainIBLL.GetDC_EngineProject_BuilderDiaryMainEntity(keyValue);
            var DC_EngineProject_BuilderDiaryDetailData = dC_EngineProject_BuilderDiaryMainIBLL.GetDC_EngineProject_BuilderDiaryDetailList(DC_EngineProject_BuilderDiaryMainData.F_BDMId);
            var jsonData = new
            {
                DC_EngineProject_BuilderDiaryMain = DC_EngineProject_BuilderDiaryMainData,
                DC_EngineProject_BuilderDiaryDetail = DC_EngineProject_BuilderDiaryDetailData,
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
            dC_EngineProject_BuilderDiaryMainIBLL.DeleteEntity(keyValue);
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
            DC_EngineProject_BuilderDiaryMainEntity entity = parameter.strEntity.ToObject<DC_EngineProject_BuilderDiaryMainEntity>();
            List<DC_EngineProject_BuilderDiaryDetailEntity> dC_EngineProject_BuilderDiaryDetailList = parameter.strdC_EngineProject_BuilderDiaryDetailList.ToObject<List<DC_EngineProject_BuilderDiaryDetailEntity>>();
            dC_EngineProject_BuilderDiaryMainIBLL.SaveEntity( parameter.keyValue, entity, dC_EngineProject_BuilderDiaryDetailList);
            return Success("保存成功！");
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
            public string strdC_EngineProject_BuilderDiaryDetailList { get; set; }
        }
        #endregion
    }
}