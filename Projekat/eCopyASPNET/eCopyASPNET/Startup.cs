using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCopyASPNET.Startup))]
namespace eCopyASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
