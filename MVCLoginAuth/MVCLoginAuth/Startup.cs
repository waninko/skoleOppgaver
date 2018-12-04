using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLoginAuth.Startup))]
namespace MVCLoginAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
