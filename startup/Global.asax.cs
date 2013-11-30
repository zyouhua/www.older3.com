using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using mpq;
using startup.i;

namespace startup
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            StartupSingleton startupSingleton_ = __singleton<StartupSingleton>._instance();
            startupSingleton_._runStart();
        }

        protected void Application_End()
        {
            Mpq mpq_ = __singleton<Mpq>._instance();
            mpq_._runClose();

            StartupSingleton startupSingleton_ = __singleton<StartupSingleton>._instance();
            startupSingleton_._runQuit();
        }
    }
}
