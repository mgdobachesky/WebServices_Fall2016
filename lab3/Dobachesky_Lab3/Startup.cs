using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dobachesky_Lab3.Startup))]
namespace Dobachesky_Lab3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
