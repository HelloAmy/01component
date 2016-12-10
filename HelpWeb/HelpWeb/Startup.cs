using Help.Common.Service.IContract;
using Help.Common.Service.Service;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(HelpWeb.Startup))]
namespace HelpWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Help.Common.Service.StartUp.AutoMapperStart();
            AreaRegistration.RegisterAllAreas();

            // WebApi的配置
            //HttpConfiguration config = GlobalConfiguration.Configuration;
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
            //config.EnsureInitialized();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ConfigureAuth(app);
            var container = this.BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/DBCreater/SQLGenerator"),
                ExpireTimeSpan = TimeSpan.FromMinutes(60),
                SlidingExpiration = true
            });
        }

        IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserManagerDataContract, UserManagerDataService>(new PerRequestLifetimeManager(), new InjectionConstructor());

            return container;
        }
    }
}