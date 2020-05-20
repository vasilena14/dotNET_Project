using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotorcycleManagement.Startup))]
namespace MotorcycleManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
