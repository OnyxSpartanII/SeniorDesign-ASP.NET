using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeniorDesignWebApp.Startup))]
namespace SeniorDesignWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
