using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Megastore.Startup))]
namespace Megastore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
