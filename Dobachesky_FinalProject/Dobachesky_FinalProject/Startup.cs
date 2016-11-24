using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dobachesky_FinalProject.Startup))]
namespace Dobachesky_FinalProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
