using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dobachesky_Assn2.Startup))]
namespace Dobachesky_Assn2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
