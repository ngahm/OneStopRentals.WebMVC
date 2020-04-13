using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneStopRentals.WebMVC.Startup))]
namespace OneStopRentals.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
