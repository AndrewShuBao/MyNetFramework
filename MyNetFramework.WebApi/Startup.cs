using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyNetFramework.WebApi.Startup))]

namespace MyNetFramework.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
