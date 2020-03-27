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
    /// 日 期：2019-01-26 16:32
    /// 描 述：打卡记录
    /// </summary>
    public class DC_OA_AttenceRecordApi : BaseApi
    {
        private DC_OA_AttenceRecordIBLL dC_OA_AttenceRecordIBLL = new DC_OA_AttenceRecordBLL();

        /// <summary>
        /// 注册接口
        /// <summary>
        public DC_OA_AttenceRecordApi()
            : base("/learun/adms/LR_CodeDemo/DC_OA_AttenceRecord")
        {
            Get["/pagelist"] = GetPageList;
            Get["/list"] = GetList;
            Get["/attencerecordlist"] = GetAttenceRecordList;
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
            var data = dC_OA_AttenceRecordIBLL.GetPageList(parameter.pagination, parameter.queryJson);
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
            var data = dC_OA_AttenceRecordIBLL.GetList(queryJson);
            return Success(data);
        }


        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetAttenceRecordList(dynamic _)
        {
            ReqPageParam parameter = this.GetReqData<ReqPageParam>();
            var data = dC_OA_AttenceRecordIBLL.GetMyPageList(this.userInfo, parameter.pagination, parameter.queryJson);
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
        /// 获取表单数据
        /// <summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetForm(dynamic _)
        {
            string keyValue = this.GetReqData();
            var DC_OA_AttenceRecordData = dC_OA_AttenceRecordIBLL.GetDC_OA_AttenceRecordEntity( keyValue );
            var jsonData = new {
                DC_OA_AttenceRecord = DC_OA_AttenceRecordData,
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
            dC_OA_AttenceRecordIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 考勤打卡
        /// <param name="_"></param>
        /// <summary>
        /// <returns></returns>
        public Response SaveForm(dynamic _)
        {
            ReqFormEntity parameter = this.GetReqData<ReqFormEntity>();

            //DC_OA_AttenceRecordEntity entity = parameter.strEntity.ToObject<DC_OA_AttenceRecordEntity>();
            string Msg = string.Empty;
             bool bTrue = dC_OA_AttenceRecordIBLL.SaveRecord(this.userInfo, parameter.longitude,parameter.latitude, ref Msg);

            var jsonData = new
            {
                info = Msg,
            };
            if (bTrue)
            {
                return Success(jsonData);
            }
            else
            {
                return Fail(jsonData);
            }
        }


        #endregion

        #region 私有类

        /// <summary>
        /// 表单实体类
        /// <summary>
        private class ReqFormEntity {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }


        #endregion

    }
}
