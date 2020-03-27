using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Learun.Util;
using Learun.Application.TwoDevelopment.ProjectManager;

namespace Learun.Application.WebApi.Modules.ProjectManager
{
    public class DC_EngineProject_ProjectExaminationSuperviseApi : BaseApi
    {
        private DC_EngineProject_ProjectExaminationSuperviseIBLL dC_EngineProject_ProjectExaminationSuperviseIBLL = new DC_EngineProject_ProjectExaminationSuperviseBLL();

        /// <summary> 
        /// 注册接口 
        /// <summary> 
        public DC_EngineProject_ProjectExaminationSuperviseApi()
            : base("/learun/adms/ProjectManager/DC_EngineProject_ProjectExaminationSupervise")
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
            var data = dC_EngineProject_ProjectExaminationSuperviseIBLL.GetPageList(parameter.pagination, parameter.queryJson);
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

            var data = dC_EngineProject_ProjectExaminationSuperviseIBLL.GetPageList(parameter.pagination, parameter.queryJson);
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
            var DC_EngineProject_ProjectExaminationSuperviseData = dC_EngineProject_ProjectExaminationSuperviseIBLL.GetDC_EngineProject_ProjectExaminationSuperviseEntity(keyValue);
            var jsonData = new
            {
                DC_EngineProject_ProjectExaminationSupervise = DC_EngineProject_ProjectExaminationSuperviseData,
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
            dC_EngineProject_ProjectExaminationSuperviseIBLL.DeleteEntity(keyValue);
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
            DC_EngineProject_ProjectExaminationSuperviseEntity entity = parameter.strEntity.ToObject<DC_EngineProject_ProjectExaminationSuperviseEntity>();
            dC_EngineProject_ProjectExaminationSuperviseIBLL.SaveEntity(parameter.keyValue, entity);
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
        }
        #endregion

    }
}