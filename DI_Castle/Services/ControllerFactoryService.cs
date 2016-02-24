using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DI_Castle.Services
{
    /// <summary>
    /// For MVC Container Resolving 
    /// </summary>
    public class ControllerFactoryService: DefaultControllerFactory
    {
        public IWindsorContainer Container { get; protected set; }


        public ControllerFactoryService(IWindsorContainer container)
        {
            Container = container;
        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            // Retrieve the requested controller from Castle
            return Container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            // If controller implements IDisposable, clean it up responsibly
            var disposableController = controller as IDisposable;
            if (disposableController != null)
            {
                disposableController.Dispose();
            }

            // Inform Castle that the controller is no longer required
            Container.Release(controller);
        }

    }
}