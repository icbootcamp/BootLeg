using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootLeg.Startup))]
namespace BootLeg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
