using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projectIT.Startup))]
namespace projectIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
