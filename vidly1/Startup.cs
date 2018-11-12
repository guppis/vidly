using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vidly1.Startup))]
namespace vidly1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
