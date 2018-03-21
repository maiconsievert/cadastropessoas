using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadastroPessoas.Startup))]
namespace CadastroPessoas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
