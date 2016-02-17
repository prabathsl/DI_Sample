using DI_Unity.App_Start;
using DI_Unity.Services;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI_Unity.Startup))]
namespace DI_Unity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
    }
}
