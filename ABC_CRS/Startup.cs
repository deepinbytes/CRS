using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABC_CRS.Startup))]
namespace ABC_CRS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
