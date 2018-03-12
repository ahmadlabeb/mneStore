using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mneStore.Startup))]
namespace mneStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
