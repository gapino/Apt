using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apartamentos.Startup))]
namespace Apartamentos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
