using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetCSharpWeb.Startup))]
namespace NetCSharpWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
