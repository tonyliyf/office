using Learun.Application.Message;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.AssetManager;
using Learun.Application.TwoDevelopment.SystemDemo;
using Learun.Application.Web.App_Start.AttenceJob;
using Learun.Application.Web.App_Start.BaseJob;
using Learun.Application.Web.App_Start.LogJob;
using Learun.Application.Web.App_Start.Wearver;
using Learun.Application.WorkFlow;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using Learun.Util.Quartz;
using Learun.Util.SendSms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Learun.Application.Web
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 敏捷开发框架
    /// Copyright (c) 2013-2018 信息技术有限公司
    /// 创建人：-框架开发组
    /// 日 期：2017.03.08
    /// 描 述：应用程序全局设置
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        private NWFProcessIBLL nWFProcessIBLL = new NWFProcessBLL();
        private UserIBLL userIBLL = new UserBLL();
        private DC_ASSETS_HouseInfoIBLL houseBll = new DC_ASSETS_HouseInfoBLL();
        /// <summary>
        /// 启动应用程序
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // houseBll.UpdateComHouse();
          //    DataUtil util = new DataUtil();
            ////  util.InitLandfoodData();
            //   util.InitBusStopBillboardsData();
            //   util.InitLandData();
            //   util.InitBuildingData();
            //   util.InitHouseData();
            //启动的时候清除全部缓存

            // string filePath = Config.GetValue("fileHeadImgTemp");
            // string uploadDate = DateTime.Now.ToString("yyyyMMdd");
            // return Success(files[0].Name);
            //  string fileGuid = Guid.NewGuid().ToString();

            //string virtualPath = string.Format("{0}/{1}/{2}{3}", filePath, uploadDate, "d3a1570b-b88b-4aba-9278-f19a38b53e12", ".png");
            //  UserEntity userEntity = userIBLL.FaceLogin(virtualPath);

            MessageDo messageDo = new MessageDo();
          //  messageDo.ExcuteMessageInterface();
            // messageDo.Excute();
           // messageDo.ExcuteJavaInterface();

            ICache cache = CacheFactory.CaChe();
            cache.RemoveAll(6);
            //var listemp = nWFProcessIBLL.GetMyAPPTaskPageList("system");
            //  var userInfo = LoginUserInfo.Get();

            //  var data = nWFProcessIBLL.GetProcessDetails("734a14f1-0143-11c6-e252-262ca7c2b690", "022d6314-4848-45a1-9557-139d239b6945", userInfo);
            //var listemp = nWFProcessIBLL.GetMyAPPTaskPageList("462af38a-6164-4b2c-a0eb-1345fa643955");
            // List<NWFProcessEntity> list = new List<NWFProcessEntity>();
            //  var list = nWFProcessIBLL.GetMyPageList("462af38a-6164-4b2c-a0eb-1345fa643955","", "");
            // var listemp = nWFProcessIBLL.GetMyAPPTaskPageList("462af38a-6164-4b2c-a0eb-1345fa643955", "", "");

            //SendSmsBase SmsClass = new SendSmsBase();
            //SmsClass = SendSmsFactory.CreateFactory("WJSendSms");
            //string content = "您的手机号：" + "18062072886" + "，注册验证码："  + "，一天内提交有效，如不是本人操作请忽略！";
            //string returncode = SmsClass.SendSmsInfo("18062072886", content);
            //if (returncode == "账户余额不足")
            //{

            //    SmsClass = SendSmsFactory.CreateFactory("WJSendSms");
            //    SmsClass.SendSmsInfo("1387152165", content);
            //}
            //JobManage job = new JobManage();
            //LR_StrategyInfoIBLL bll = new LR_StrategyInfoBLL();
            //var LR_StrategyList = bll.GetList("");
            //foreach(LR_MS_StrategyInfoEntity item in LR_StrategyList)
            //{
            //    if (string.IsNullOrEmpty(item.F_Assembly)) continue;
            //    //Assembly asm = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "/bin/"+ item.F_Assembly);////我们要调用的dll文件路径
            //    //加载dll后,需要使用dll中某类.
            //    //Type t = asm.GetType(item.F_ClassName);//获取类名，必须 命名空间+类名
            //    job.AddJob(item.F_Assembly, item.F_ClassName, item.F_StrategyCode, item.F_CornTimes);
            //}

            // LR_StrategyInfoIBLL bll = new LR_StrategyInfoBLL();
            //  bll.SendMessageByUserIds("Advace", "AAAA广告租金到期了", "0de67129-c91f-4183-8f69-862368eab693,128cdf31-2ac0-4596-84ab-45ed22a5299b");

           //BaseJobScheduler.Start();;
            WfJobScheduler.Start();
           // BaseJobScheduler.Start();
            AttenceJobScheduler.Start();
           LogJobScheduler.Start();

            //添加删除日志操作
            //LogJobScheduler.Start();
        }

        /// <summary>
        /// 应用程序错误处理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
        }


        protected void Application_End(object sender, EventArgs e)
        {
          
       
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Config.GetValue("BaseUrl"));
                HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
                string desc = rsp.StatusDescription;
                // Log4NetHelper.WriteInfo(desc);
            }
            catch (Exception ex)
            {
                // Log4NetHelper.WriteExcepetion(ex);
            }
        }
    }
}
