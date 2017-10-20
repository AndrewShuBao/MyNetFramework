using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyDotNetFramework.WebApi.Startup))]

namespace MyDotNetFramework.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
