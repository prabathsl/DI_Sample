using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Castle.Windsor;
using DI_Castle.Services;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(DI_Castle.Startup))]

namespace DI_Castle
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new WindsorContainer();
            container.Install(new DependancyInstallerService());


            var ControllerFactory = new ControllerFactoryService(container);

            // Add the Controller Factory into the MVC web request pipeline
            ControllerBuilder.Current.SetControllerFactory(ControllerFactory);
        }
    }
}
