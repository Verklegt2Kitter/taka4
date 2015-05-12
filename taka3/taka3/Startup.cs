using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(taka3.Startup))]
namespace taka3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
