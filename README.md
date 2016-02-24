# Dependancy  Injection Sample 

Here we gonna Use it in real code
First I create MVC project and Add following classes to it.


public interface IUserService
   {
       string GetUserName(string name);
   }

 

public class UserService : IUserService
    {
        public string GetUserName(string name)
        {
            return string.Format("Hello {0}", name);
        }
    } 

Then  I create My MVC UserController and Its View. Code is same as I did in prev post


public class UserController : Controller
   {
       private IUserService _userService;
 
       public UserController(IUserService userService)
       {
           _userService = userService;
       }
       // GET: User
       public ActionResult Index()
       {
           ViewBag.UserMessage = _userService.GetUserName("Dependency Unity");
           return View();
       }
   }


Here is View


@{
    ViewBag.Title = "Index";
}
 
<h2>@ViewBag.UserMessage</h2> 

 

 

 That's all. 


Now I'm gonna install Unity Nuget package for DI framework
 Then real Dependency Injection begins.


Main Focus  

    Register
    Resolver

 We use dependency Injection Register for register dependency  and resolver for resolve dependency.  It will be done by Unity framework for you if you implement it



1. Create Class DI_Register 


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

 


2. Create UserResolver Class for dependency resolving. It will  using the Unity's IDependancyResolver Interface for resolving implementation . It eill take care of your dependency resolving 



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
 
       /// <summary>
       /// For one object 
       /// </summary>
       /// <param name="serviceType"></param>
       /// <returns></returns>
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
 
       /// <summary>
       /// For multiple objects 
       /// </summary>
       /// <param name="serviceType"></param>
       /// <returns></returns>
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


 3. Then go to the AppStart (startup.auth.cs) and call dependency register in application bigining


Di_Register.RegisterDependancy(); 






 Then Run and see the magic :)



