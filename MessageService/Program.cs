using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learun.Util.Quartz;
using Topshelf;

namespace MessageService
{
    class Program
    {
        static void Main(string[] args)
        {

            //HostFactory.Run(x =>
            //{
            //    x.Service<QuartzServiceRunner>(s =>
            //    {
            //        s.ConstructUsing(name => new QuartzServer());
            //        s.WhenStarted(tc => tc.Start());
            //        s.WhenStopped(tc => tc.Stop());
            //    });
            //    x.RunAsLocalSystem();
            //    x.StartAutomatically();
            //    x.SetDescription("消息服务器");
            //    x.SetDisplayName("MessageService");
            //    x.SetServiceName("MessageService");
            //});

            //HostFactory.Run(x =>
            //{
            //    x.Service<QuartzServer>();
            //    x.SetDescription("消息服务器");
            //    x.SetDisplayName("MessageService");
            //    x.SetServiceName("MessageService");
            //});
            log4net.Config.XmlConfigurator.Configure();
            MyServiceConfigure.Configure();
        }

    }
    
}
