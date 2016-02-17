﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DI_Unity.App_Start
{
    /// <summary>
    /// Resolver 
    /// </summary>
    internal class UserResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public UserResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}