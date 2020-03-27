using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Util;
using Learun.Util.Operat;
using Nancy;
namespace Learun.Application.WebApi
{
    public class AppUtil : BaseApi
    {

        public AppUtil()
        : base("/learun/adms/apputil")
        {


            Get["/info"] = Info;

        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns> 
        Response Info(dynamic _)
        {
            var datainfo = new AppInfo();
            datainfo.AppName = Config.GetValue("AppName");
            datainfo.version = Config.GetValue("appversion");
            datainfo.Updatetime = Config.GetValue("Updatetime");
            datainfo.Url = Config.GetValue("Url");
            var jsonData = new
            {
                data = datainfo,
            };
            return Success(jsonData);
        }


    }

    public class AppInfo
    {

        public string AppName { get; set; }
        public string version { get; set; }

        public string Updatetime { get; set; }

        public string Url { get; set; }

    }
}