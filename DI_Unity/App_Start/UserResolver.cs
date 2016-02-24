using Microsoft.Practices.Unity;
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
<<<<<<< HEAD

        /// <summary>
        /// For one object 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
=======
>>>>>>> bdaf81554470d970c83ba8625d5fda03a61c6bd7
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

<<<<<<< HEAD
        /// <summary>
        /// For multiple objects 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
=======
>>>>>>> bdaf81554470d970c83ba8625d5fda03a61c6bd7
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