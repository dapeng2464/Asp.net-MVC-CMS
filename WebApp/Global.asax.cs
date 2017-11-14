using CMS.Admin;
using CMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace WebApp
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start ( )
        {
            AreaRegistration.RegisterAllAreas ( );

            WebApiConfig.Register ( GlobalConfiguration.Configuration );
            FilterConfig.RegisterGlobalFilters ( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes ( RouteTable.Routes );
            //
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles ( BundleTable.Bundles );
            AuthConfig.RegisterAuth ( );

            // Ioc
            var container = new UnityContainer ( );
            DependencyRegisterType.Container_Sys ( ref container );
            DependencyResolver.SetResolver ( new UnityDependencyResolver ( container ) );
        }
    }
}