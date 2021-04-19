using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShootingStars.Startup))]
namespace ShootingStars
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
