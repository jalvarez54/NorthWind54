using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5Ef6WebApiDataFirstNthW.Startup))]
namespace Mvc5Ef6WebApiDataFirstNthW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
