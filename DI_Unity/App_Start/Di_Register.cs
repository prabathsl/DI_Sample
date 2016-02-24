using DI_Unity.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI_Unity.App_Start
{
    public static class Di_Register
    {
        /// <summary>
        /// Register And resolver of Dependency 
        /// </summary>
        public static void RegisterDependancy()
        {
            IUnityContainer container = new UnityContainer();
            RegisterDependancy(container);

            DependencyResolver.SetResolver(new UserResolver(container));
        }

        /// <summary>
        /// Type registration
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterDependancy(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();
        }
    }
}