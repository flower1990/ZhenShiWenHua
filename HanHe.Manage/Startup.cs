using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HanHe.Manage.Startup))]
namespace HanHe.Manage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
