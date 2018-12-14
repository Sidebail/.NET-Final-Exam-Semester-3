using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F2018Pranks.Startup))]
namespace F2018Pranks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
