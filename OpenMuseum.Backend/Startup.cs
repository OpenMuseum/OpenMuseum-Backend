using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenMuseum.Backend.Startup))]
namespace OpenMuseum.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
