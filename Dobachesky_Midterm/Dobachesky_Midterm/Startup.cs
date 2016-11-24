using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dobachesky_Midterm.Startup))]
namespace Dobachesky_Midterm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
