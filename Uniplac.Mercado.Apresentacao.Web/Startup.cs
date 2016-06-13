using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Uniplac.Mercado.Apresentacao.Web.Startup))]
namespace Uniplac.Mercado.Apresentacao.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
