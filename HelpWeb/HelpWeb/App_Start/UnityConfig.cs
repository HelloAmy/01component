using Help.Common.Service.IContract;
using Help.Common.Service.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.WebApi;

namespace HelpWeb.App_Start
{
    public static class UnityConfig
    {
        public static UnityContainer Container { get; private set; }

        public static void RegisterComponents(HttpConfiguration config)
        {
            // Controller是不能被依赖注入进去的，只有ApiController可以
            // 因为Controller只会执行不带参数的构造函数
            Container = new UnityContainer();

            Container.RegisterType<IUserManagerDataContract, UserManagerDataService>(new PerRequestLifetimeManager(), new InjectionConstructor());
            config.DependencyResolver = new UnityDependencyResolver(Container);
        }
    }
}