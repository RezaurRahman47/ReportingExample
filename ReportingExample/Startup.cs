using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReportingExample.Startup))]
namespace ReportingExample
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
