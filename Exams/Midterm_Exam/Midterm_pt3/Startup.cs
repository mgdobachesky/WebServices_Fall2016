using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Midterm_pt3.Startup))]
namespace Midterm_pt3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
