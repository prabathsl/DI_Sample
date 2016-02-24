using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DI_Castle.Models;
using System.Reflection;
using System.Web.Mvc;
using DI_Castle.Controllers;

namespace DI_Castle.Services
{
    public class DependancyInstallerService : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Register dependency
            container.Register(Component.For<IUserService>().ImplementedBy<UserService>());
            container.Register(Component.For<UserController>());

            //All Controller registration

            //var contollers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();

            //for (int i = 0; i < contollers.Count; i++)
            //{
            //    container.Register(Component.For(contollers[i]));
            //}
        }
    }
}