using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaNET_CesarGayo.Startup))]
namespace TiendaNET_CesarGayo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
