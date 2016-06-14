using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Uniplac.Mercado.Apresentacao.Webforms.Startup))]
namespace Uniplac.Mercado.Apresentacao.Webforms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
