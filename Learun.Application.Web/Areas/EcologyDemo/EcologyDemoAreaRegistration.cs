using System.Web.Mvc;

namespace Learun.Application.Web.Areas.EcologyDemo
{
    public class EcologyDemoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EcologyDemo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EcologyDemo_default",
                "EcologyDemo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}