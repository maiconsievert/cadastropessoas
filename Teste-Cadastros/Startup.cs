using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Teste_Cadastros.Startup))]
namespace Teste_Cadastros
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
